using System;
using System.Collections.Generic;
using System.Linq;

// Gelieve je voornaam, achternaam, studentnummer en klas in te vullen in onderstaande variabele
string studentVoornaam = "Jonas";
string studentAchternaam = "Trap";
string studentNummer = "r0335225";
string studentKlas = "GTI GPR a1.1";

// Titel van programma (comentaar voor dotnetfiddle)
// Console.Title = $"f-starwars - {studentVoornaam} {studentAchternaam} ({studentNummer} - {studentKlas})";

Console.WriteLine("=== F-STARWARS ===");
Console.WriteLine($"{studentVoornaam} {studentAchternaam} ({studentNummer} - {studentKlas})");
Console.WriteLine();

// Start vanaf hier met programmeren
string[] menu = ["Afsluiten", "Jedi Bekijken", "Jedi Toevoegen", "Jedi Verwijderen", "Jedi Editeren"];
List<string> jediLijst = new List<string>();
int keuzeMenu; 

//inlezen van keuze
keuzeMenu = KeuzeMenu(menu);

while (keuzeMenu != 1)
{
    switch (keuzeMenu)
    {
        case 2:
            //Jedi Bekijken
            PrintJedi(jediLijst);
            break;
        case 3:
            //Jedi Toevoegen
            NieuweJediToevoegen(jediLijst);           
            break;
        case 4:
            //Jedi Verwijderen
            VerdwijderJedi(jediLijst);
            break;
        case 5:
            //Jedi Editeren
            EditJedi(jediLijst);
            break;
    }
    keuzeMenu = KeuzeMenu(menu);
}

Console.WriteLine("Tot ziens!");

//methodes: 

//toon keuzemenu
int KeuzeMenu(string[] menu)
{
    for (int i = 0; i < menu.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {menu[i]}");
    }
    return LeesGetalMinMax("Kies een optie uit het menu: ", 1, menu.Length);
}

//Bepaal min en max waardes
int LeesGetalMinMax(string vraag, int min, int max)
{
    int getal;
    do
    {
        getal = LeesGetal(vraag);
    } while (getal < min || getal > max);
    return getal;
}

//check of input een getal
int LeesGetal(string vraag)
{
    string output;
    int getal;
    do
    {
        output = LeesStringNietLeeg(vraag);
    } while (!int.TryParse(output, out getal));
    return getal;
}

//Check of string leeg is
string LeesStringNietLeeg(string vraag)
{
    string output;
    do
    {
        Console.Write(vraag);
        output = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(output));
    return output;
}

//afdrukken van de lijst
void PrintJedi(List<string> jedi)
{
    //uitlezen van de lijst als hij leeg is volgende boodschap tonen: Er zijn geen Jedi!
    if (jedi.Count == 0)
    {
        Console.WriteLine("Er zijn geen Jedi!");
        Console.WriteLine();
        return;
    }
    Console.WriteLine("=== Jedi Lijst ===");
    foreach (string naam in jedi)
    {
        Console.WriteLine(naam);
    }
    Console.WriteLine();
}

//nieuw item toevoegen aan de lijst
void NieuweJediToevoegen(List<string> jedi)
{
    //inlezen van nieuwe jedi naam
    string nieuweJedi = LeesStringNietLeeg("Geef de naam van de nieuwe Jedi: ");
    string geformateerdeNaam = char.ToUpper(nieuweJedi[0]) + nieuweJedi.Substring(1).ToLower();
    
    // Case-insensitive check: vergelijk alle namen in lowercase
    if (jedi.Any(j => j.ToLower() == geformateerdeNaam.ToLower()))
    {
        Console.WriteLine($"De Jedi '{geformateerdeNaam}' staat al in de lijst!");
        Console.WriteLine();
        return;
    }
    jedi.Add(geformateerdeNaam);
    Console.WriteLine($"Jedi '{geformateerdeNaam}' toegevoegd!");
    Console.WriteLine();
}

//item verwijderen uit de lijst
void VerdwijderJedi(List<string> jedi)
{
    //inlezen van te verwijderen jedi naam
    string teVerwijderenJedi = LeesStringNietLeeg("Welke Jedi wens je te verwijderen: ");
    string geformateerdeNaam = char.ToUpper(teVerwijderenJedi[0]) + teVerwijderenJedi.Substring(1).ToLower();

    // Case-insensitive check: vergelijk alle namen in lowercase
    // LAMBDA MANIER (korter):
    // string bestaandeJedi = jedi.FirstOrDefault(j => j.ToLower() == geformateerdeNaam.ToLower());
    
    // LANGE MANIER (explicieter):
    string bestaandeJedi = null;
    foreach (string j in jedi)
    {
        if (j.ToLower() == geformateerdeNaam.ToLower())
        {
            bestaandeJedi = j;
            break;
        }
    }
    
    if (bestaandeJedi == null)
    {
        Console.WriteLine($"De Jedi '{geformateerdeNaam}' staat niet in de lijst.");
        Console.WriteLine();
        return;
    }
    jedi.Remove(bestaandeJedi);
    Console.WriteLine($"Jedi '{bestaandeJedi}' is verwijderd!");
    Console.WriteLine();
}

//Item editeren in de lijst en checken of die reeds bestaat. Maar de lijst ophalen voor ze vragen welke te editeren. en dan op dezelfde plaats terug plaaten. Als er lambda kan gebruikt worden, graag in de comments zetten + uitleg en in de code zonder lambda
void EditJedi(List<string> jedi)
{
    //inlezen van te editeren jedi naam
    string teEditerenJedi = LeesStringNietLeeg("Welke Jedi wens je te editeren: ");
    string geformateerdeNaam = char.ToUpper(teEditerenJedi[0]) + teEditerenJedi.Substring(1).ToLower();
    
    // LAMBDA MANIER (korter):
    // string bestaandeJedi = jedi.FirstOrDefault(j => j.ToLower() == geformateerdeNaam.ToLower());
    // Dit zoekt het EERSTE element waar de lowercase naam overeenkomt
    
    // LANGE MANIER (explicieter):
    string bestaandeJedi = null;
    foreach (string j in jedi)
    {
        if (j.ToLower() == geformateerdeNaam.ToLower())
        {
            bestaandeJedi = j;
            break;
        }
    }
    if (bestaandeJedi == null)
    {
        Console.WriteLine($"De Jedi '{geformateerdeNaam}' staat niet in de lijst.");
        Console.WriteLine();
        return;
    }
    string nieuweNaam = LeesStringNietLeeg($"Geef de Jedi '{bestaandeJedi}' een nieuwe naam: ");
    string geformateerdeNieuweNaam = char.ToUpper(nieuweNaam[0]) + nieuweNaam.Substring(1).ToLower();
    // Check of de nieuwe naam al bestaat
    if (jedi.Any(j => j.ToLower() == geformateerdeNieuweNaam.ToLower()))
    {
        Console.WriteLine($"De Jedi '{geformateerdeNieuweNaam}' staat al in de lijst!");
        Console.WriteLine();
        return;
    }
    int index = jedi.IndexOf(bestaandeJedi);
    jedi[index] = geformateerdeNieuweNaam;
    Console.WriteLine($"De Jedi naam is aangepast van '{bestaandeJedi}' naar '{geformateerdeNieuweNaam}'.");
    Console.WriteLine();
}
