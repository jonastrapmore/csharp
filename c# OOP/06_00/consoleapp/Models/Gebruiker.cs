namespace consoleapp.Models;
public class Gebruiker
{
    public int Id { get; set; }
    public string Voornaam { get; set; }
    public string Achternaam { get; set; }

    public Gebruiker(int id, string voornaam, string achternaam)
    {
        this.Id = id;
        this.Voornaam = voornaam;
        this.Achternaam = achternaam;
    }

    public override string ToString()
    {
        return $"{this.Id} - {this.Voornaam} {this.Achternaam}";
    }

    public override bool Equals(object? obj)
    {
       if (!(obj is Gebruiker gebruiker))
       {
            return false;
       }
       return gebruiker.Id == this.Id && gebruiker.GetType() == this.GetType();

    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Id, this.GetType());
    }
}