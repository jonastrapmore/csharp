namespace consoleapp.Models;

public class Student : Gebruiker
{
    public double Punten { get; set; }
    public string Resultaat 
    {
        get
        {
          if(this.Punten < 50)
            {
                return $"Niet geslaagd";
            }
            return $"Geslaagd";
        }
    }
    public Student(int id, string voornaam, string achternaam, double punten) : base(id, voornaam, achternaam)
    {
        this.Punten = punten;
    }

    public override string ToString()
    {
        return $"{base.ToString()} - {this.Punten}/100 - {this.Resultaat}";
    }

    public string ToonStudentGeslaagd()
    {
        return Resultaat;
    }
}