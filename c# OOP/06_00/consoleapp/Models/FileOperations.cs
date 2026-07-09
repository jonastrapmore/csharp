namespace consoleapp.Models;

public static class FileOperations
{
    public static string BestandStudenten = "StudentEnPunt.txt";
    public static List<Gebruiker> LeesStudentenEnDocenten()
    {
        List<Gebruiker> gebruikers = new List<Gebruiker>();
        if (!File.Exists(BestandStudenten))
        {
            return gebruikers;
        }

        using StreamReader streamReader = new StreamReader(BestandStudenten);
        while (!streamReader.EndOfStream)
        {
            string record = streamReader.ReadLine();
            string[] data = record.Split(';');
            string type = data[0];
            string voornaam = data[1];
            string achternaam = data[2];
            int.TryParse(data[4], out int id);
            Gebruiker gebruiker = null;

            if (type == "Student")
            {
                double.TryParse(data[3], out double punten);
                gebruiker = new Student(id, voornaam, achternaam, punten);

            }
            else
            {
                double.TryParse(data[3], out double loon);
                gebruiker = new Docent(id, voornaam, achternaam, loon);
            }
            if(!gebruikers.Contains(gebruiker))
            {
                gebruikers.Add(gebruiker);
            }
        }
        return gebruikers;
    }
}