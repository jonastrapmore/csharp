using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace consoleapp.Models.BugBuster;

public static partial class BugBuster
{
    // This static readonly string will show the path to the Class unit tests
    private static readonly string RootFolder = Path.Combine("..", "..", "..", "..");
    private static readonly string ClassTestFolder = Path.Combine(RootFolder, "test", "ClassTests");

    // Enable or disable the Class unit tests
    public static void SetClassTests(bool enabled = true)
    {
        if (enabled)
        {
            EnableClassTests();
            return;
        }

        DisableClassTests();
    }

    // This method will enable all .cs files by changing the extension
    // from .disabled to .cs
    public static void EnableClassTests()
    {
        if (AreClassTestsEnabled()) return;

        foreach (string file in Directory.GetFiles(ClassTestFolder, "*.disabled"))
        {
            string? newFile = Path.ChangeExtension(file, ".cs");
            File.Move(file, newFile);
        }
    }

    // This method will do the exact opposite from EnableClassTests
    // It will do so by changing all .cs files to .disabled
    // We might want to disable the classes so student may test Console IO only
    // Note that student cannot receive any grade for an assignment
    // if there are compile errors for the class(es)
    public static void DisableClassTests()
    {
        if (!AreClassTestsEnabled()) return;

        foreach (string file in Directory.GetFiles(ClassTestFolder, "*.cs"))
        {
            if (file.EndsWith("IoConfig.cs") || file.EndsWith("GlobalUsings.cs")) continue;

            string? newFile = Path.ChangeExtension(file, ".disabled");
            File.Move(file, newFile);
        }
    }

    // Checks the current state of the project!
    // Are the Class Tests disabled or enabled (depends on extension)
    public static bool AreClassTestsEnabled()
    {
        return Directory.GetFiles(ClassTestFolder, "*.cs").Length != 0;
    }

    // This basic method will return a list of error objects if compiling fails!
    // This method may print to console (NOT RECOMMENDED BUT EASY FOR STUDENTS - default true)
    // It might also disable the Class Tests after completing (default false)
    public static List<BugBusterError> CompileClassTests(bool printToConsole = true, bool disableClassTestsAfterRun = false)
    {

        // Enable tests and run compile on tests
        BugBuster.SetClassTests(enabled: true);
        List<BugBusterError> errors = BugBuster.GetCompileErrors();

        // Check if printing to console is enabled
        if (!printToConsole)
        {
            // Maybe disable class tests depending on flag - return errors
            if (disableClassTestsAfterRun) DisableClassTests();
            return errors;
        }

        // Change encoding for printing silly smileys - execute print
        // Remember students NEVER EVER EVER USE CONSOLE CLASS in your own classes
        // As a teacher this is an exception
        Encoding originalEncoding = Console.OutputEncoding;
        ConsoleColor originalColor = Console.ForegroundColor;
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine(BugBuster.ReturnNumberOfErrors(errors) + "\n");
        Console.OutputEncoding = originalEncoding;
        foreach (BugBusterError error in errors)
        {
            Console.ForegroundColor = error.GetColor();
            Console.WriteLine(error + "\n");
        }
        Console.ForegroundColor = originalColor;


        // Maybe disable class tests depending on flag - return errors
        if (disableClassTestsAfterRun) DisableClassTests();
        return errors;
    }

    // Returns the numbers of errors found inside a list of error objects
    // It also uses fun emojis!
    // These can only be print to screen if the encoding is changed to UTF-8!
    // See RunClassTests
    public static string ReturnNumberOfErrors(List<BugBusterError> errors)
    {
        if (errors.Count == 0)
            return "Er zijn geen fouten gevonden in je klasse! 💻👍";

        if (errors.Count == 1)
            return "Er is 1 fout gevonden in een klasse! 💻👎";

        return $"Er zijn {errors.Count} fouten gevonden in je klasse! 💻{string.Concat(Enumerable.Repeat("👎", errors.Count))}";
    }

    // This method is a piece of art!
    // It will create a HashSet of Error objects
    // We try to compile the entire application
    // After we check the compile log
    // If any errors are found we loop over them 
    // Each error will be transformed to a human readable error message
    public static List<BugBusterError> GetCompileErrors()
    {
        // Create empty error list and check if class tests are enabled, hashset for deduped errors
        HashSet<BugBusterError> errors = [];
        if (!AreClassTestsEnabled())
        {
            errors.Add(new BugBusterError("Tests zijn niet enabled of beschikbaar. Gelieve de tests te enable of te kijken of er wel tests aanwezig zijn."));
            return [.. errors];
        }

        // Try executing the process
        (IEnumerable<string>? lines, string? errorMessage) = CompileGetOutput();
        if (lines == null)
        {
            // We could have an out of memory exception or something else going on!
            // If we test a property that is not used in Program.cs this could be
            // the reason why this exception happend
            // Not much we can do!
            errors.Add(new BugBusterError("Fout bij compilatiecontrole.", "", "Onbekend", 0, errorMessage ?? "Onbekend"));
            return [.. errors];
        }

        // Loop over each error and process it
        foreach (string line in lines)
        {
            BugBusterError? error = ProcessCompileOutputline(line);
            if (error == null) continue;
            errors.Add(error);
        }

        // Return entire error list
        return [.. errors];
    }

    // This method returns the compile output
    public static (IEnumerable<string>?, string?) CompileGetOutput()
    {
        // Create a new process object for building the entire application!
        Process process = new()
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = "build",
                WorkingDirectory = RootFolder,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };

        try
        {
            // Execute and wait for process to exit
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string errorOutput = process.StandardError.ReadToEnd();
            process.WaitForExit();

            // Get all error messages from process
            string combined = output + errorOutput;
            IEnumerable<string>? lines = combined.Split('\n')
                .Where(line => line.Contains("error") && line.Contains("ClassTests"))
                .Select(line => line.Trim());

            return (lines, null);
        }
        catch (Exception ex)
        {
            return (null, ex.Message);
        }
    }

    // This method will create a new Error object
    // It uses Regex to find the error information in the single output string
    public static BugBusterError? ProcessCompileOutputline(string line)
    {
        Regex regex = ErrorRegex();
        try
        {
            // Try to find the the needed output data
            Match match = regex.Match(line);
            if (!match.Success) return null;

            // Get all individual data from Match object
            string fullPath = match.Groups["file"].Value.Trim();
            string fileName = Path.GetFileName(fullPath);
            _ = int.TryParse(match.Groups["line"].Value, out int lineNumber);
            string message = match.Groups["message"].Value.Trim();
            string errorCode = match.Groups["code"].Value.Trim();

            // Add new error to list - hopefully all information is present
            return new BugBusterError(message, errorCode, fileName, lineNumber, line);
        }
        catch (Exception ex)
        {
            // If the regex fails - create a general error! We teachers should debug this
            // But only if we have time - which we never have! :-(
            return new BugBusterError("Fout bij verwerken van regel: " + ex.Message, "", "Onbekend", 0, line);
        }
    }

    // Regex generation at compile time
    [GeneratedRegex(@"(?<file>.*\.cs)\((?<line>\d+),\d+\): error (?<code>CS\d+): (?<message>.*)")]
    private static partial Regex ErrorRegex();
}