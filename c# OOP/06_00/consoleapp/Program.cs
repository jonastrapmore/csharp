//doorsturen naar autograder
List<Gebruiker> gebruikers = FileOperations.LeesStudentenEnDocenten();
string[] menu = new string[gebruikers.Count + 1];
menu[0] = "Afsluiten";
int index = 1;
foreach (Gebruiker gebruiker in gebruikers)
{
    menu[index] = gebruiker.ToString();
    index++;
}


int keuze = KeuzeMenu(menu);

while (keuze != 1)
{
    //selecteren van gekozen gebruiker + sublmenu bepalen afhankelijk van type gebruiker.
    Gebruiker gebruiker = gebruikers[keuze - 2];
    string[] submenu;
    if(gebruiker is Student)
    {
        submenu = new string[] { "ToString", "ToonStudentGeslaagd" };
    }
    else
    {
        submenu = new string[] { "ToString", "ToonDocentLoon" };
    }

    //bepalen van subkeuze
    int subkeuze = KeuzeMenu(submenu);
    if(subkeuze == 1)
    {
        //printen van gebruiker object(tostring zijn van docent of student)
        Console.WriteLine(gebruiker);
    }
    else
    {
        //Kijken of gebruiker van bepaald type is, vervolgens de unieke methode uitvoeren
        if(gebruiker is Student student)
        {
            Console.WriteLine(student.ToonStudentGeslaagd());
        }
        else if(gebruiker is Docent docent)
        {
            Console.WriteLine(docent.ToonDocentLoon());
        }
    }


    keuze = KeuzeMenu(menu);
}

Console.ReadLine();










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

int LeesGetalMinMax(string vraag, int min, int max)
{
    int getal;
    do
    {
        getal = LeesGetal(vraag);
    } while (getal < min || getal > max);
    return getal;
}

int KeuzeMenu(string[] menu)
{
    Console.WriteLine("Opties");
    Console.WriteLine("---------------");
    for (int i = 0; i < menu.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {menu[i]}");
    }
    return LeesGetalMinMax("Geef een keuze: ", 1, menu.Length);
}