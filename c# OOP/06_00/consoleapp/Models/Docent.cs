namespace consoleapp.Models;

public class Docent : Gebruiker
{
    public double Loon { get; set; }
    public Docent(int id, string voornaam, string achternaam, double loon) : base(id, voornaam, achternaam)
    {
        this.Loon = loon;
    }

    public override string ToString()
    {
        return $"{base.ToString()} - {this.Loon} euro/uur.";
    }

    public string ToonDocentLoon()
    {
        return $"{this.Loon} euro/uur.";
    }
}