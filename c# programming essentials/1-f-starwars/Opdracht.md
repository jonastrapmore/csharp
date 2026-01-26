# F-STARWARS

Welkom, C-3PO! In deze onzekere tijden is het van uiterst belang om een lijst bij te houden van alle levende Jedi Masters. Het is jouw taak als robot om hier een werkende applicatie te ontwikkelen. Veel succes!

## Opdrachtomschrijving
De appliatie start eerst met een hoofdmenu te tonen. De mogelijke opties zijn ``Afsluiten``, ``Jedi Bekijken``, ``Jedi Toevoegen``, ``Jedi Verwijderen``, ``Jedi Editeren``. Het programma blijft actief totdat de gebruiker kiest voor ``Afsluiten``.

1. **Jedi Bekijken**:
   Printen van alle Jedi Masters in de lijst. Als er geen Jedi Masters zijn print dan `Er zijn geen Jedi!`

2. **Jedi Toevoegen**:
   - Vraag de gebruiker om een Jedi toe te voegen.
   - Controleer of je Jedi al in de lijst voorkomt. Zo ja, geef een melding dat de Jedi al bestaat. Zo nee, voeg de Jedi toe aan de lijst en bevestig dit aan de gebruiker.

3. **Jedi Verwijderen**:
   - Vraag de gebruiker de Jedi dat hij wil verwijderen.
   - Controleer of de Jedi in de lijst aanwezig is. Zo ja, verwijder de Jedi en bevestig de verwijdering. Zo nee, geef een melding dat de Jedi niet bestaat.

4. **Jedi Editeren**:
   - Vraag de gebruiker om een Jedi uit de lijst te kiezen om te bewerken.
   - Vervang de oude naam van de Jedi in de lijst door de nieuwe naam. Geef de nieuwe naam weer na de bewerking.

### Methodes
Je mag zelf hulp methodes toevoegen, maar je bent hier niet tot verplicht. Onderstaande methodes moeten verplicht geprogrammeerd **en** gebruikt worden.

#### **`int KeuzeMenu(string[] menu)`**  
Toont het gegeven menu als een lijst van keuzes en vraagt de gebruiker om een optie te selecteren. Valideert dat de invoer een nummer is binnen het gegeven bereik en retourneert de keuze.

#### **`string LeesStringNietLeeg(string vraag)`**  
Vraagt de gebruiker om een stringinvoer. De invoer mag niet leeg zijn. Als de gebruiker een lege invoer geeft, blijft het programma vragen om een geldige string.

#### **`int LeesGetal(string vraag)`**  
Vraagt de gebruiker om een getal in te voeren en valideert dat het een geldig nummer is. Blijft vragen om een invoer tot een geldig getal is ingevoerd.

#### **`int LeesGetalMinMax(string vraag, int min, int max)`**  
Gebruikt `LeesGetal` om een getal in te lezen, maar controleert dat het binnen de opgegeven minimum- en maximumwaarden valt. Vraagt opnieuw om invoer als het getal buiten het bereik valt.

#### **`void PrintJedi(List<string> jedi)`**  
Print elke Jedi in de lijst. Als er geen Jedi beschikbaar zijn print je `Er zijn geen Jedi!`

## Voorbeelden

### Afsluiten
```
1. Afsluiten
2. Jedi Bekijken
3. Jedi Toevoegen
4. Jedi Verwijderen
5. Jedi Editeren
Kies een optie uit het menu: 1
```

### Toevoegen van Jedi
```
1. Afsluiten
2. Jedi Bekijken
3. Jedi Toevoegen
4. Jedi Verwijderen
5. Jedi Editeren
Kies een optie uit het menu: 3
Geef de naam van de Jedi: Yoda
Jedi 'Yoda' toegevoegd!

1. Afsluiten
2. Jedi Bekijken
3. Jedi Toevoegen
4. Jedi Verwijderen
5. Jedi Editeren
Kies een optie uit het menu: 3
Geef de naam van de Jedi: Ahsoka Tano
Jedi 'Ahsoka Tano' toegevoegd!
```

### Toevoegen van Jedi die al in de lijst staat
```
1. Afsluiten
2. Jedi Bekijken
3. Jedi Toevoegen
4. Jedi Verwijderen
5. Jedi Editeren
Kies een optie uit het menu: 3
Geef de naam van de Jedi: Yoda
De Jedi 'Yoda' staat al in de lijst!
```

### Verwijderen van Jedi
```
1. Afsluiten
2. Jedi Bekijken
3. Jedi Toevoegen
4. Jedi Verwijderen
5. Jedi Editeren
Kies een optie uit het menu: 4
Welke Jedi wens je te verwijderen: Yoda
Jedi 'Yoda' is verwijderd!
```

### Verwijderen van Jedi die niet in de lijst staat
```
1. Afsluiten
2. Jedi Bekijken
3. Jedi Toevoegen
4. Jedi Verwijderen
5. Jedi Editeren
Kies een optie uit het menu: 4
Welke Jedi wens je te verwijderen: Mace Windu
De Jedi 'Mace Windu' staat niet in de lijst.
```

### Editeren van Jedi
```
1. Afsluiten
2. Jedi Bekijken
3. Jedi Toevoegen
4. Jedi Verwijderen
5. Jedi Editeren
Kies een optie uit het menu: 5
Welke Jedi wens je te editeren: Ahsoka Tano
Geef de Jedi 'Ahsoka Tano' een nieuwe naam: Snips
De Jedi naam is aangepast van 'Ahsoka Tano' naar 'Snips'.
```

### Editeren van Jedi die niet in de lijst staat
```
1. Afsluiten
2. Jedi Bekijken
3. Jedi Toevoegen
4. Jedi Verwijderen
5. Jedi Editeren
Kies een optie uit het menu: 5
Welke Jedi wens je te editeren: Qui-Gon Jinn
De Jedi 'Qui-Gon Jinn' staat niet in de lijst.
```

### Tonen van Jedi
```
1. Afsluiten
2. Jedi Bekijken
3. Jedi Toevoegen
4. Jedi Verwijderen
5. Jedi Editeren
Kies een optie uit het menu: 2
Ahsoka Tano
```

### Tonen van Jedi wanneer er geen zijn
```
1. Afsluiten
2. Jedi Bekijken
3. Jedi Toevoegen
4. Jedi Verwijderen
5. Jedi Editeren
Kies een optie uit het menu: 2
Er zijn geen Jedi!
```

### Herhaling
```
1. Afsluiten
2. Jedi Bekijken
3. Jedi Toevoegen
4. Jedi Verwijderen
5. Jedi Editeren
Kies een optie uit het menu: 3
Geef de naam van de Jedi: Kanan Jarrus
Jedi 'Kanan Jarrus' toegevoegd!

1. Afsluiten
2. Jedi Bekijken
3. Jedi Toevoegen
4. Jedi Verwijderen
5. Jedi Editeren
Kies een optie uit het menu: 5
Welke Jedi wens je te editeren: Kanan Jarrus
Geef de Jedi 'Kanan Jarrus' een nieuwe naam: Caleb Dume
De Jedi naam is aangepast van 'Kanan Jarrus' naar 'Caleb Dume'.

1. Afsluiten
2. Jedi Bekijken
3. Jedi Toevoegen
4. Jedi Verwijderen
5. Jedi Editeren
Kies een optie uit het menu: 2
Caleb Dume

1. Afsluiten
2. Jedi Bekijken
3. Jedi Toevoegen
4. Jedi Verwijderen
5. Jedi Editeren
Kies een optie uit het menu: 1
```

### Gegevensvalidatie
```
1. Afsluiten
2. Jedi Bekijken
3. Jedi Toevoegen
4. Jedi Verwijderen
5. Jedi Editeren
Kies een optie uit het menu: abc
Kies een optie uit het menu: -5
Kies een optie uit het menu: 99
Kies een optie uit het menu: 3
Geef de naam van de Jedi:    
Geef de naam van de Jedi: Luke Skywalker
Jedi 'Luke Skywalker' toegevoegd!
```
