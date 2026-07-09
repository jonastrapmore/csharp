using System.Text.RegularExpressions;

namespace consoleapp.Models.BugBuster;

public partial class BugBusterError
{

    // These properties can be used to determine the error state
    public string ErrorDescription { get; set; }
    public string ErrorCode { get; set; }

    // Special property that uses a lookup table to translate the error into Dutch
    // A few errorcodes will hint the student in the correct direction
    // These are not defined inside the lookup table
    // I know - verwennerij!
    public string? ErrorDescriptionHumanReadable
    {
        get
        {
            Match match;
            switch (ErrorCode)
            {
                case "CS1061":
                case "CS0117":
                    match = CS1061Regex().Match(ErrorDescription);
                    if (match.Success)
                        return $"Je hebt een methode of property niet geprogrammeerd (spellingsfout?). Gelieve '{match.Groups[2].Value}' aan te maken in de klasse '{match.Groups[1].Value}'.";
                    break;

                case "CS1729":
                    match = CS1729Regex().Match(ErrorDescription);
                    if (match.Success)
                        return $"De klasse '{match.Groups[1].Value}' bevat geen constructor die {match.Groups[2].Value} argumenten accepteert. Gelieve een constructor met exact {match.Groups[2].Value} parameters te voorzien.";
                    break;

                case "CS0122":
                    match = CS0122Regex().Match(ErrorDescription);
                    if (match.Success)
                        return $"De member '{match.Groups[2].Value}' van de klasse '{match.Groups[1].Value}' is niet toegankelijk. Mogelijk is de toegangsmethode (public/protected/private) fout. Gelieve te controleren of deze correct is.";
                    break;

                case "CS1503":
                    match = CS1503Regex().Match(ErrorDescription);
                    if (match.Success)
                        return $"Je probeert een '{match.Groups[1].Value}' toe te wijzen of door te geven op een plaats waar een '{match.Groups[2].Value}' verwacht wordt. Controleer de types van je attributen, parameters of returnwaardes van de methodes en constructors.";
                    break;

                case "CS0029":
                    match = CS0029Regex().Match(ErrorDescription);
                    if (match.Success)
                        return $"Je probeert een '{match.Groups[1].Value}' toe te wijzen of door te geven op een plaats waar een '{match.Groups[2].Value}' verwacht wordt. Controleer de types van je attributen, parameters of returnwaardes van de methodes en constructors.";
                    match = CS0029Regex2().Match(ErrorDescription);
                    if (match.Success)
                        return $"Je probeert een '{match.Groups[1].Value}' toe te wijzen of door te geven op een plaats waar een '{match.Groups[2].Value}' verwacht wordt. Controleer de types van je attributen, parameters of returnwaardes van de methodes en constructors.";
                    break;

                case "CS0246":
                    match = CS0246Regex().Match(ErrorDescription);
                    if (match.Success)
                        return $"De klasse '{match.Groups[1].Value}' werd niet gevonden. Mogelijk ben je vergeten deze aan te maken (spellingsfout?).";
                    break;
            }

            return FindInLookupTable(this.ErrorCode) ?? this.ErrorDescription;
        }
    }

    // Some more usefull props
    public string ErrorInFile { get; set; }
    public int ErrorLineNumber { get; set; }
    public string StackTrace { get; set; }

    // Translation lookup table mentioned above
    public static readonly KeyValuePair<string, string>[] LookupTable = [
        new("CS1002", "Er ontbreekt een puntkomma."),
        new("CS1513", "Er ontbreekt een accolade."),
        new("CS0103", "Deze naam is niet gekend in de huidige context."),
        new("CS0117", "De opgegeven member bestaat niet in het type."),
        new("CS0161", "Niet alle codepaden geven een waarde terug."),
        new("CS0535", "De klasse implementeert een interface niet correct."),
        new("CS1061", "Je probeert een methode of property aan te spreken die niet bestaat op dit object."),
        new("CS1729", "Constructor werd niet gevonden met het opgegeven aantal parameters."),
        new("CS0122", "Member is niet toegankelijk vanwege het toegangsniveau."),
        new("CS1503", "Verkeerd datatype gebruikt bij aanroep van constructor of methode."),
        new("CS0029", "Verkeerd datatype gebruikt bij variabele of property."),
        new("CS7036", "Er ontbreekt een constructor in je code.")
    ];

    // Translation lookup table for color output - each color will represent a different error
    public static readonly KeyValuePair<string, ConsoleColor>[] LookupColorTable = [
        new("CS1002", ConsoleColor.Blue),
        new("CS1513", ConsoleColor.DarkBlue),
        new("CS0103", ConsoleColor.DarkYellow),
        new("CS0117", ConsoleColor.Yellow),
        new("CS0246", ConsoleColor.Magenta),
        new("CS0161", ConsoleColor.Green),
        new("CS0535", ConsoleColor.DarkCyan),
        new("CS1061", ConsoleColor.Cyan),
        new("CS1729", ConsoleColor.Red),
        new("CS0122", ConsoleColor.DarkRed),
        new("CS1503", ConsoleColor.DarkGreen),
        new("CS0029", ConsoleColor.DarkMagenta),
        new("CS7036", ConsoleColor.Yellow)
    ];

    // Different constructors
    public BugBusterError(string error) : this(error, "", "", 0, "") { }

    public BugBusterError(string error, string code) : this(error, code, "", 0, "") { }

    public BugBusterError(string error, string code, string inFile) : this(error, code, inFile, 0, "") { }

    public BugBusterError(string error, string code, string inFile, int lineNumber) : this(error, code, inFile, lineNumber, "") { }

    public BugBusterError(string error, string code, string inFile, int lineNumber, string stackTrace)
    {
        this.ErrorDescription = error;
        this.ErrorCode = code;
        this.ErrorInFile = inFile;
        this.ErrorLineNumber = lineNumber;
        this.StackTrace = stackTrace;
    }

    // ToString method that shows the error more student friendly
    public override string ToString()
    {
        string readable = this.ErrorDescriptionHumanReadable ?? this.ErrorDescription;
        return $"[Bestand: {this.ErrorInFile}, Lijn: {this.ErrorLineNumber}, Code: {this.ErrorCode}] {readable}";
    }

    // Errors are equal when they have the same code, description, line number, file
    public override bool Equals(object? obj)
    {
        if (obj is not BugBusterError other) return false;
        return ErrorDescription == other.ErrorDescription &&
               ErrorCode == other.ErrorCode &&
               ErrorInFile == other.ErrorInFile &&
               ErrorLineNumber == other.ErrorLineNumber;
    }

    // Same as equals
    public override int GetHashCode()
    {
        return HashCode.Combine(ErrorDescription, ErrorCode, ErrorInFile, ErrorLineNumber);
    }

    // Simple static function to look inside static lookup table
    private static string? FindInLookupTable(string code)
    {
        foreach (KeyValuePair<string, string> keypair in LookupTable)
        {
            if (code.Contains(keypair.Key))
            {
                return keypair.Value;
            }
        }
        return null;
    }

    // Returns the unique ConsoleColor for each message
    public ConsoleColor GetColor()
    {
        foreach (KeyValuePair<string, ConsoleColor> pair in LookupColorTable)
        {
            if (ErrorCode.Contains(pair.Key))
                return pair.Value;
        }
        return ConsoleColor.White;
    }

    // Regex generation at compile time
    [GeneratedRegex(@"'(.*?)' does not contain a definition for '(.*?)'")]
    private static partial Regex CS1061Regex();

    [GeneratedRegex(@"'(.*?)' does not contain a constructor that takes (\d+) arguments")]
    private static partial Regex CS1729Regex();

    [GeneratedRegex(@"'(.*?)\.(.*?)' is inaccessible due to its protection level")]
    private static partial Regex CS0122Regex();

    [GeneratedRegex(@"cannot convert from '(.*?)' to '(.*?)'")]
    private static partial Regex CS1503Regex();

    [GeneratedRegex(@"cannot convert type from '(.*?)' to '(.*?)'")]
    private static partial Regex CS0029Regex();

    [GeneratedRegex(@"convert type '(.*?)' to '(.*?)'")]
    private static partial Regex CS0029Regex2();

    [GeneratedRegex(@"The type or namespace name '(.*?)' could not be found")]
    private static partial Regex CS0246Regex();
}