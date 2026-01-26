// Gelieve je voornaam, achternaam, studentnummer en klas in te vullen in onderstaande variabele
using System.Security.Cryptography;

string studentVoornaam = "XXXXXXX";
string studentAchternaam = "XXXXXXX";
string studentNummer = "rxxxxxxx";
string studentKlas = "XXX XXX xy.y";


// Titel van programma
Console.Title = $"f-planeten - {studentVoornaam} {studentAchternaam} ({studentNummer} - {studentKlas})";

// Start vanaf hier met programmeren
string[] hoofdmenu = ["Afsluiten", "Ster kiezen"];
int keuzeHoofdmenu;
string keuzeSter;
string typePlaneet;

//Toon het hoofdmenu
keuzeHoofdmenu = keuzeMenu(hoofdmenu);
//herhalen indien keuze =! 1
while (keuzeHoofdmenu !=1)
{
    //kies Ster
    do
    {
        keuzeSter = LeesStringNietLeeg("Kies een ster (zon, luhman16, proxima-cenatauri)");
    }while(keuzeSter != "zon" && keuzeSter != "luhman16" && keuzeSter != "proxima-centauri");
    
    string[] subMenu = ["Toon alle planeten", "Toon planeet dichtste van ster", "Toon planeet verste van ster", "Toon alle planeten van type"];
    int keuzeSubMenu = keuzeMenu(subMenu);

    //afhandelen van submenu
    switch (keuzeSubMenu)
    {
        case 1:
            LeesPlaneten(keuzeSter);
            break;
        case 2:
            ToonDichtstePlaneet(keuzeSter);
            break;
        case 3:
            ToonVerstePlaneet(keuzeSter);
            break;
        case 4:
            do
            {
                Console.WriteLine("Geef een type planeet (rots, gasreus of ijsreus):");
                typePlaneet = Console.ReadLine().ToLower();   
            }while(typePlaneet == "rots" || typePlaneet == "gasreus" || typePlaneet == "ijsreus");
            ToonPlanetenVanType(keuzeSter,typePlaneet);
            break;
    }
}

void LeesPlaneten(string ster)
{
    List<string> planeten = FileInlezen(ster);
    bool gevonden = false;
    foreach(string planeet in planeten)
    {
        string[] data = planeet.Split(";");
        if(data.Length >= 4)
        {
            printInfoPlaneet(data[0],data[3],data[1],data[2]);
            gevonden = true;
        }
    }
    if(!gevonden)
    {
        Console.WriteLine("Geen planeten gevonden");
    }
}

void ToonDichtstePlaneet(string ster)
{
    List<string> planeten = FileInlezen(ster);
    int korstePLaneet = int.MaxValue;
    int laagsteIndex = -1;

    for (int i = 0; i <planeten.Count ; i++)
    {
        string[] data = planeten[i].Split(";");
        if(data.Length >= 4)
        {
            int afstandPlaneet;
            if(int.TryParse(data[3],out afstandPlaneet) && afstandPlaneet < korstePLaneet)
            {
                korstePLaneet = afstandPlaneet;
                laagsteIndex =i;
            }
        }
    }

    if (laagsteIndex >= 0)
    {
        string[] korstePlaneetSter = planeten[laagsteIndex].Split(";");
        printInfoPlaneet(korstePlaneetSter[0],korstePlaneetSter[3],korstePlaneetSter[1],korstePlaneetSter[2]);
    }
    else
    {
        Console.WriteLine("geen planeten gevonden");
    }
}

void ToonVerstePlaneet(string ster)
{
    List<string> planeten = FileInlezen(ster);
    int verstePLaneet = int.MinValue;
    int hoogsteIndex = -1;

    for (int i = 0; i <planeten.Count ; i++)
    {
        string[] data = planeten[i].Split(";");
        if(data.Length >= 4)
        {
            int afstandPlaneet;
            if(int.TryParse(data[3],out afstandPlaneet) && afstandPlaneet > verstePLaneet)
            {
                verstePLaneet = afstandPlaneet;
                hoogsteIndex =i;
            }
        }
    }

    if (hoogsteIndex >= 0)
    {
        string[] verstePlaneetSter = planeten[hoogsteIndex].Split(";");
        printInfoPlaneet(verstePlaneetSter[0],verstePlaneetSter[3],verstePlaneetSter[1],verstePlaneetSter[2]);
    }
    else
    {
        Console.WriteLine("geen planeten gevonden");
    }
}

void ToonPlanetenVanType(string ster, string typePlaneet)
{
    List<string> planeten = FileInlezen(ster);
    bool gevonden = false;

    foreach (string planeet in planeten)
    {
        string[] data = planeet.Split(";");
        if (data.Length >= 4 && data[1] == typePlaneet)
        {
            printInfoPlaneet(data[0],data[3],data[1],data[2]);
            gevonden = true;
        }
        if(!gevonden)
        {
            Console.WriteLine("geen planeten gevonden");
        }
    }
}

//print lijn met planeet info:
void printInfoPlaneet(string naam, string afstandSter, string planeetType, string leeftijd)
{
    Console.WriteLine($"Planeet '{naam}' met een afstand van {afstandSter} miljoen km van zijn ster. De planeet is een {planeetType} en is {leeftijd} miljoen jaar oud.");
}

//file inlezen
List<string> FileInlezen(string ster)
{
    List<string> planeten = [];
    string filename = ster + ".txt";

    if(!File.Exists(filename))
    {
        return planeten;
    }
    using (StreamReader reader = new StreamReader(filename))
    {
        while(!reader.EndOfStream)
        {
            planeten.Add(reader.ReadLine());
        }
    }
    return planeten;
}

//toon keuzemenu: 
int keuzeMenu(string[] menu)
{
    for (int i = 0; i < menu.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {menu[i]}");
    }
    return LeesGetalMinMax("Kies een optie uit het menu: ", 1, menu.Length);
}

//Bepalen van de min en max waarden in de menu
int LeesGetalMinMax(string vraag, int min, int max)
{
    int getal;
    do
    {
        getal = LeesGetal(vraag);
    } while (getal < min || getal > max);
    return getal;
}

//checken of input een getal is
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


//checken of string leeg is: 
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
