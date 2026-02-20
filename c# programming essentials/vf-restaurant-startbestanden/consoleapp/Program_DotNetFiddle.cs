using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

public class Program
{
    // Hardcoded restaurant data (omdat DotNetFiddle geen file I/O ondersteunt)
    private static Dictionary<string, List<string>> restaurantData = new Dictionary<string, List<string>>
    {
        ["pizzahut"] = new List<string>
        {
            "Margherita;Hoofdgerecht;800;8",
            "Quattro Stagioni;Hoofdgerecht;1200;12",
            "Bruschetta;Voorgerecht;350;5",
            "Tiramisu;Nagerecht;450;6"
        },
        ["burgerking"] = new List<string>
        {
            "Whopper;Hoofdgerecht;900;9",
            "Chicken Nuggets;Voorgerecht;400;6",
            "Fries;Bijgerecht;300;3",
            "Ice Cream;Nagerecht;350;4"
        },
        ["sushimania"] = new List<string>
        {
            "Sushi Platter;Hoofdgerecht;1500;18",
            "Miso Soup;Voorgerecht;250;4",
            "Edamame;Voorgerecht;300;5",
            "Green Tea Ice Cream;Nagerecht;400;6"
        }
    };

    public static void Main()
    {
        // Gelieve je voornaam, achternaam, studentnummer en klas in te vullen in onderstaande variabele
        string studentVoornaam = "jonas";
        string studentAchternaam = "trap";
        string studentNummer = "r0225335";
        string studentKlas = "XXX XXX xy.y";

        // Titel van programma (werkt niet in DotNetFiddle)
        Console.WriteLine($"vf-restaurant - {studentVoornaam} {studentAchternaam} ({studentNummer} - {studentKlas})");
        Console.WriteLine();

        // Start vanaf hier met programmeren
        string[] hoofdmenu = new string[] { "Afsluiten", "Restaurant kiezen" };
        int keuzeHoofdmenu;
        string keuzeRestaurant;
        
        //Toon hoofdmenu
        keuzeHoofdmenu = KeuzeMenu(hoofdmenu);
        
        //Herhaal indien keuze != 1
        while (keuzeHoofdmenu != 1)
        {
            //kies restaurant
            do
            {
                keuzeRestaurant = LeesStringNietLeeg("Kies een restaurant (pizzahut, burgerking of sushimania): ").ToLower();
            } while (keuzeRestaurant != "pizzahut" && keuzeRestaurant != "burgerking" && keuzeRestaurant != "sushimania");
            
            //kies welke gerechten te tonen
            string[] subMenu = new string[] { "Toon alle gerechten", "Toon duurste gerecht", 
                            "Toon goedkoopste gerecht","Goedkoopste hoofdgerecht",
                            "Duurste voorgerecht","Alle hoofdgerechten","Alle gerechten Duurste eerst",
                            "Alle gerechten goedkoopste eerst" };
            int keuzeSubMenu = KeuzeMenu(subMenu);
            
            //afhandelen keuze SubMenu
            switch (keuzeSubMenu)
            {
                case 1:
                    ToonGerechten(keuzeRestaurant);
                    break;
                case 2:
                    ToonDuursteGerecht(keuzeRestaurant);
                    break;
                case 3:
                    ToonGoedkoopsteGerecht(keuzeRestaurant);
                    break;
                case 4:
                    ToonGoedkoopsteHoofdgerecht(keuzeRestaurant);
                    break;
                case 5:
                    ToonDuursteVoorgerecht(keuzeRestaurant);
                    break;
                case 6:
                    ToonAlleHoofdgerechten(keuzeRestaurant);
                    break;
                case 7:
                    ToonGerechtenGesorteerd(keuzeRestaurant);
                    break;
                case 8:
                    ToonGerechtenGesorteerdOplopend(keuzeRestaurant);
                    break;
            }
            
            //Stap 4: herhaal keuze
            keuzeHoofdmenu = KeuzeMenu(hoofdmenu);
        }
    }

    //Methodes
    //Check of string leeg is
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

    //check of input een getal
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

    //Bepaal min en max waardes
    static int LeesGetalMinMax(string vraag, int min, int max)
    {
        int getal;
        do
        {
            getal = LeesGetal(vraag);
        } while (getal < min || getal > max);
        return getal;
    }

    //toon keuzemenu
    static int KeuzeMenu(string[] menu)
    {
        for (int i = 0; i < menu.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {menu[i]}");
        }
        return LeesGetalMinMax("Kies een optie uit het menu: ", 1, menu.Length);
    }

    //print lijn met gerechtinfo
    static void PrintInfoGerecht(string naam, string prijs, string type, string calorieen)
    {
        Console.WriteLine($"Gerecht '{naam}' kost {prijs} euro, is een {type} en bevat {calorieen} kcal.");
    }

    static void ToonGerechten(string restaurant)
    {
        List<string> gerechten = FileInlezen(restaurant);
        bool gevonden = false;

        foreach (string gerecht in gerechten)
        {
            string[] data = gerecht.Split(';');
            if (data.Length >= 4)
            {
                PrintInfoGerecht(data[0], data[3], data[1], data[2]);
                gevonden = true;
            }
        }

        if (!gevonden)
        {
            Console.WriteLine("Geen gerechten gevonden.");
        }
    }

    static void ToonDuursteGerecht(string restaurant)
    {
        List<string> gerechten = FileInlezen(restaurant);
        int hoogstePrijs = int.MinValue;
        int hoogsteIndex = -1;

        for (int i = 0; i < gerechten.Count; i++)
        {
            string[] data = gerechten[i].Split(';');
            if (data.Length >= 4)
            {
                int prijsAlsGetal;
                if (int.TryParse(data[3], out prijsAlsGetal) && prijsAlsGetal > hoogstePrijs)
                {
                    hoogstePrijs = prijsAlsGetal;
                    hoogsteIndex = i;
                }
            }
        }

        if (hoogsteIndex >= 0)
        {
            string[] duursteGerecht = gerechten[hoogsteIndex].Split(';');
            PrintInfoGerecht(duursteGerecht[0], duursteGerecht[3], duursteGerecht[1], duursteGerecht[2]);
        }
        else
        {
            Console.WriteLine("Geen gerechten gevonden.");
        }
    }

    static void ToonGoedkoopsteGerecht(string restaurant)
    {
        List<string> gerechten = FileInlezen(restaurant);
        int laagstePrijs = int.MaxValue;
        int laagsteIndex = -1;

        for (int i = 0; i < gerechten.Count; i++)
        {
            string[] data = gerechten[i].Split(';');
            if (data.Length >= 4)
            {
                int prijsAlsGetal;
                if (int.TryParse(data[3], out prijsAlsGetal) && prijsAlsGetal < laagstePrijs)
                {
                    laagstePrijs = prijsAlsGetal;
                    laagsteIndex = i;
                }
            }
        }

        if (laagsteIndex >= 0)
        {
            string[] goedkoopsteGerecht = gerechten[laagsteIndex].Split(';');
            PrintInfoGerecht(goedkoopsteGerecht[0], goedkoopsteGerecht[3],
                             goedkoopsteGerecht[1], goedkoopsteGerecht[2]);
        }
        else
        {
            Console.WriteLine("Geen gerechten gevonden.");
        }
    }

    static void ToonGoedkoopsteHoofdgerecht(string restaurant)
    {
        List<string> gerechten = FileInlezen(restaurant);
        int laagstePrijs = int.MaxValue;
        int laagsteIndex = -1;

        for (int i = 0; i < gerechten.Count; i++)
        {
            string[] data = gerechten[i].Split(';');
            if (data.Length >= 4 && data[1].Trim().ToLower() == "hoofdgerecht")
            {
                int prijsAlsGetal;
                if (int.TryParse(data[3], out prijsAlsGetal) && prijsAlsGetal < laagstePrijs)
                {
                    laagstePrijs = prijsAlsGetal;
                    laagsteIndex = i;
                }
            }
        }

        if (laagsteIndex >= 0)
        {
            string[] goedkoopsteGerecht = gerechten[laagsteIndex].Split(';');
            PrintInfoGerecht(goedkoopsteGerecht[0], goedkoopsteGerecht[3],
                             goedkoopsteGerecht[1], goedkoopsteGerecht[2]);
        }
        else
        {
            Console.WriteLine("Geen hoofdgerechten gevonden.");
        }
    }

    static void ToonDuursteVoorgerecht(string restaurant)
    {
        List<string> gerechten = FileInlezen(restaurant);
        int hoogstePrijs = int.MinValue;
        int hoogsteIndex = -1;

        for (int i = 0; i < gerechten.Count; i++)
        {
            string[] data = gerechten[i].Split(';');
            if (data.Length >= 4 && data[1].Trim().ToLower() == "voorgerecht")
            {
                int prijsAlsGetal;
                if (int.TryParse(data[3], out prijsAlsGetal) && prijsAlsGetal > hoogstePrijs)
                {
                    hoogstePrijs = prijsAlsGetal;
                    hoogsteIndex = i;
                }
            }
        }

        if (hoogsteIndex >= 0)
        {
            string[] duursteGerecht = gerechten[hoogsteIndex].Split(';');
            PrintInfoGerecht(duursteGerecht[0], duursteGerecht[3],
                             duursteGerecht[1], duursteGerecht[2]);
        }
        else
        {
            Console.WriteLine("Geen voorgerechten gevonden.");
        }
    }

    static void ToonAlleHoofdgerechten(string restaurant)
    {
        List<string> gerechten = FileInlezen(restaurant);
        bool gevonden = false;

        foreach (string gerecht in gerechten)
        {
            string[] data = gerecht.Split(';');
            if (data.Length >= 4 && data[1].Trim().ToLower() == "hoofdgerecht")
            {
                PrintInfoGerecht(data[0], data[3], data[1], data[2]);
                gevonden = true;
            }
        }

        if (!gevonden)
        {
            Console.WriteLine("Geen hoofdgerechten gevonden.");
        }
    }

    static void ToonGerechtenGesorteerd(string restaurant)
    {
        List<string> gerechten = FileInlezen(restaurant);
        List<string> geldigeGerechten = new List<string>();
        
        foreach (string gerecht in gerechten)
        {
            if (gerecht.Split(';').Length >= 4)
                geldigeGerechten.Add(gerecht);
        }
        
        bool gevonden = geldigeGerechten.Count > 0;

        geldigeGerechten.Sort(VergelijkVoorAflopend);

        foreach (string gerecht in geldigeGerechten)
        {
            string[] data = gerecht.Split(';');
            PrintInfoGerecht(data[0], data[3], data[1], data[2]);
        }

        if (!gevonden)
        {
            Console.WriteLine("Geen gerechten gevonden.");
        }
    }

    static void ToonGerechtenGesorteerdOplopend(string restaurant)
    {
        List<string> gerechten = FileInlezen(restaurant);
        List<string> geldigeGerechten = new List<string>();
        
        foreach (string gerecht in gerechten)
        {
            if (gerecht.Split(';').Length >= 4)
                geldigeGerechten.Add(gerecht);
        }
        
        bool gevonden = geldigeGerechten.Count > 0; 

        geldigeGerechten.Sort(VergelijkVoorOplopend);

        foreach (string gerecht in geldigeGerechten)
        {
            string[] data = gerecht.Split(';');
            PrintInfoGerecht(data[0], data[3], data[1], data[2]);
        }

        if (!gevonden)
        {
            Console.WriteLine("Geen gerechten gevonden.");
        }
    }

    static int VergelijkVoorAflopend(string g1, string g2)
    {
        int.TryParse(g1.Split(';')[3], out int prijs1);
        int.TryParse(g2.Split(';')[3], out int prijs2);
        return prijs2.CompareTo(prijs1); // duurste eerst
    }

    static int VergelijkVoorOplopend(string g1, string g2)
    {
        string[] data1 = g1.Split(';');
        string[] data2 = g2.Split(';');
        
        if (data1.Length < 4 || data2.Length < 4) return 0;
        
        int.TryParse(data1[3], out int prijs1);
        int.TryParse(data2[3], out int prijs2);
        
        return prijs1.CompareTo(prijs2); // goedkoopste eerst
    }

    static List<string> FileInlezen(string restaurant)
    {
        // In DotNetFiddle gebruiken we hardcoded data ipv file I/O
        if (restaurantData.ContainsKey(restaurant))
        {
            return new List<string>(restaurantData[restaurant]);
        }
        return new List<string>();
    }
}
