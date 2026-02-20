using System;
using System.Collections.Generic;

public class Program
{
    // Hardcoded planet data (DotNetFiddle ondersteunt geen file I/O)
    private static readonly Dictionary<string, List<string>> planetData = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
    {
        ["zon"] = new List<string>
        {
            "Mercurius;rots;4,5;58",
            "Venus;rots;4,5;108",
            "Aarde;rots;4,6;147",
            "Mars;rots;4,6;207",
            "Jupiter;gasreus;4,6;742",
            "Saturnus;gasreus;4,6;1479",
            "Uranus;ijsreus;4,6;2871",
            "Neptunus;ijsreus;4,6;4495"
        },
        ["luhman16"] = new List<string>
        {
            "L16-a;rots;3,1;35",
            "L16-b;gasreus;2,8;74",
            "L16-y;ijsreus;2,5;150"
        },
        ["proxima-centauri"] = new List<string>
        {
            "Proxima b;rots;4,8;7,5",
            "Proxima c;rots;5,0;220",
            "Proxima d;rots;4,5;4,3"
        }
    };

    public static void Main()
    {
        // Gelieve je voornaam, achternaam, studentnummer en klas in te vullen in onderstaande variabele
        string studentVoornaam = "XXXXXXX";
        string studentAchternaam = "XXXXXXX";
        string studentNummer = "rxxxxxxx";
        string studentKlas = "XXX XXX xy.y";

        // Titel van programma (Console.Title werkt niet in DotNetFiddle)
        Console.WriteLine($"f-planeten - {studentVoornaam} {studentAchternaam} ({studentNummer} - {studentKlas})");
        Console.WriteLine();

        // Start vanaf hier met programmeren
        string[] hoofdmenu = new string[] { "Afsluiten", "Ster kiezen" };
        int keuzeHoofdmenu;
        string keuzeSter;
        string typePlaneet;

        //Toon het hoofdmenu
        keuzeHoofdmenu = KeuzeMenu(hoofdmenu);

        //herhalen indien keuze != 1
        while (keuzeHoofdmenu != 1)
        {
            //kies Ster
            do
            {
                keuzeSter = LeesStringNietLeeg("Kies een ster (zon, luhman16, proxima-centauri): ").ToLower();
            } while (keuzeSter != "zon" && keuzeSter != "luhman16" && keuzeSter != "proxima-centauri");

            string[] subMenu = new string[] { "Toon alle planeten", "Toon planeet dichtste van ster", "Toon planeet verste van ster", "Toon alle planeten van type" };
            int keuzeSubMenu = KeuzeMenu(subMenu);

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
                    } while (typePlaneet != "rots" && typePlaneet != "gasreus" && typePlaneet != "ijsreus");
                    ToonPlanetenVanType(keuzeSter, typePlaneet);
                    break;
            }

            keuzeHoofdmenu = KeuzeMenu(hoofdmenu);
        }
    }

    //Methodes
    static string LeesStringNietLeeg(string vraag)
    {
        string output;
        do
        {
            Console.Write(vraag);
            output = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(output));
        return output;
    }

    static int LeesGetal(string vraag)
    {
        string output;
        int getal;
        do
        {
            output = LeesStringNietLeeg(vraag);
        } while (!int.TryParse(output, out getal));
        return getal;
    }

    static int LeesGetalMinMax(string vraag, int min, int max)
    {
        int getal;
        do
        {
            getal = LeesGetal(vraag);
        } while (getal < min || getal > max);
        return getal;
    }

    static int KeuzeMenu(string[] menu)
    {
        for (int i = 0; i < menu.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {menu[i]}");
        }
        return LeesGetalMinMax("Kies een optie uit het menu: ", 1, menu.Length);
    }

    static void PrintInfoPlaneet(string naam, string afstandSter, string planeetType, string leeftijd)
    {
        Console.WriteLine($"Planeet '{naam}' met een afstand van {afstandSter} miljoen km van zijn ster. De planeet is een {planeetType} en is {leeftijd} miljoen jaar oud.");
    }

    static void LeesPlaneten(string ster)
    {
        List<string> planeten = FileInlezen(ster);
        bool gevonden = false;
        foreach (string planeet in planeten)
        {
            string[] data = planeet.Split(';');
            if (data.Length >= 4)
            {
                PrintInfoPlaneet(data[0], data[3], data[1], data[2]);
                gevonden = true;
            }
        }
        if (!gevonden)
        {
            Console.WriteLine("Geen planeten gevonden");
        }
    }

    static void ToonDichtstePlaneet(string ster)
    {
        List<string> planeten = FileInlezen(ster);
        int korstePlaneet = int.MaxValue;
        int laagsteIndex = -1;

        for (int i = 0; i < planeten.Count; i++)
        {
            string[] data = planeten[i].Split(';');
            if (data.Length >= 4)
            {
                int afstandPlaneet;
                if (int.TryParse(data[3], out afstandPlaneet) && afstandPlaneet < korstePlaneet)
                {
                    korstePlaneet = afstandPlaneet;
                    laagsteIndex = i;
                }
            }
        }

        if (laagsteIndex >= 0)
        {
            string[] korstePlaneetSter = planeten[laagsteIndex].Split(';');
            PrintInfoPlaneet(korstePlaneetSter[0], korstePlaneetSter[3], korstePlaneetSter[1], korstePlaneetSter[2]);
        }
        else
        {
            Console.WriteLine("geen planeten gevonden");
        }
    }

    static void ToonVerstePlaneet(string ster)
    {
        List<string> planeten = FileInlezen(ster);
        int verstePlaneet = int.MinValue;
        int hoogsteIndex = -1;

        for (int i = 0; i < planeten.Count; i++)
        {
            string[] data = planeten[i].Split(';');
            if (data.Length >= 4)
            {
                int afstandPlaneet;
                if (int.TryParse(data[3], out afstandPlaneet) && afstandPlaneet > verstePlaneet)
                {
                    verstePlaneet = afstandPlaneet;
                    hoogsteIndex = i;
                }
            }
        }

        if (hoogsteIndex >= 0)
        {
            string[] verstePlaneetSter = planeten[hoogsteIndex].Split(';');
            PrintInfoPlaneet(verstePlaneetSter[0], verstePlaneetSter[3], verstePlaneetSter[1], verstePlaneetSter[2]);
        }
        else
        {
            Console.WriteLine("geen planeten gevonden");
        }
    }

    static void ToonPlanetenVanType(string ster, string typePlaneet)
    {
        List<string> planeten = FileInlezen(ster);
        bool gevonden = false;

        foreach (string planeet in planeten)
        {
            string[] data = planeet.Split(';');
            if (data.Length >= 4 && data[1] == typePlaneet)
            {
                PrintInfoPlaneet(data[0], data[3], data[1], data[2]);
                gevonden = true;
            }
        }

        if (!gevonden)
        {
            Console.WriteLine("geen planeten gevonden");
        }
    }

    static List<string> FileInlezen(string ster)
    {
        if (planetData.TryGetValue(ster, out var planeten))
        {
            return new List<string>(planeten);
        }
        return new List<string>();
    }
}
