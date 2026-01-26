# VF-RESTAURANT
Je bent enorme fan van fastfood. Het is jouw taak als foodie om een werkende console applicatie te programmeren. We willen graag informatie opvragen over verschillende gerechten van verschillende fastfoodketens. Veel succes!

## Opdrachtomschrijving
De appliatie start eerst met een hoofdmenu te vragen. De mogelijke opties zijn ``Afsluiten`` en ``Restaurant kiezen``. Het programma blijft actief totdat de gebruiker kiest voor ``Afsluiten``.

Wanneer de gebruiker kiest voor `Restaurant kiezen`, moet hij of zij één van de volgende restaurants ingeven (rekening houdend met hoofd/kleine letters):
1. pizzahut
2. burgerking
3. sushimania

Na het kiezen van een restaurant zal de gebruiker een submenu te zien krijgen. De mogelijke opties van het submenu zijn ``Toon alle gerechten`` en ``Toon duurste gerecht``.

Afhankelijk van de keuze wordt de juiste methode uitgevoerd. Na het afhandelen van een submenu-optie wordt opnieuw het hoofdmenu getoond.

### Methodes
Je mag zelf hulp methodes toevoegen, maar je bent hier niet tot verplicht. Onderstaande methodes moeten verplicht geprogrammeerd **en** gebruikt worden.

#### **`void PrintInfoGerecht(string naam, string prijs, string type, string calorieen)`** 
Deze methode zal volgende informatie op het scherm printen:
``Gerecht '{naam}' kost {prijs} euro, is een {type} en bevat {calorieen} kcal.``

#### **`List<string> LeesGerechten(string restaurant)`** 
Deze methode zal een restaurant bestand uitlezen. De methode geeft een lijst van gerechten (string) terug.

#### **`void ToonGerechten(string restaurant)`** 
Drukt alle gerechten van restaurant af met behulp van `PrintInfoGerecht`.

#### **`void ToonDuursteGerecht(string restaurant)`** 
Drukt het duurste gerecht van een restaurant af met behulp van `PrintInfoGerecht`.  
**Let op: de volgorde in de tekstbestanden mag niet worden aangepast!**

## Tekstbestanden 

Er zijn 3 tekstbestanden genaamd `burgerking.txt`, `pizzahut.txt` en `sushimania.txt`. Elk tekstbestand bevat verschillende gerechten. De info van de gerechten is als volgt opgebouwd:

1. Naam gerecht
2. Type gerecht
3. Aantal kcal
4. Prijs in euro

## Voorbeelden

### Afsluiten
```
1. Afsluiten
2. Restaurant kiezen
Kies een optie uit het menu: 1
```

### Kiezen voor burgerking en tonen van alle gerechten
```
1. Afsluiten
2. Restaurant kiezen
Kies een optie uit het menu: 2

Kies een restaurant (pizzahut, burgerking of sushimania): burgerking

1. Toon alle gerechten
2. Toon duurste gerecht
Kies een optie uit het menu: 1

Gerecht 'Whopper' kost 9 euro, is een hoofdgerecht en bevat 850 kcal.
Gerecht 'Chicken Nuggets' kost 6 euro, is een hoofdgerecht en bevat 500 kcal.
Gerecht 'Fries' kost 3 euro, is een voorgerecht en bevat 350 kcal.
Gerecht 'Milkshake' kost 4 euro, is een drank en bevat 400 kcal.
Gerecht 'Cheesecake' kost 5 euro, is een dessert en bevat 450 kcal.

1. Afsluiten
2. Restaurant kiezen
Kies een optie uit het menu: 1
```

### Kiezen voor burgerking en tonen van duurste gerecht
```
1. Afsluiten
2. Restaurant kiezen
Kies een optie uit het menu: 2

Kies een restaurant (pizzahut, burgerking of sushimania): burgerKING

1. Toon alle gerechten
2. Toon duurste gerecht
Kies een optie uit het menu: 2

Gerecht 'Whopper' kost 9 euro, is een hoofdgerecht en bevat 850 kcal.

1. Afsluiten
2. Restaurant kiezen
Kies een optie uit het menu: 1
```

### Kiezen voor pizzahut en tonen van duurste gerecht
```
1. Afsluiten
2. Restaurant kiezen
Kies een optie uit het menu: 2

Kies een restaurant (pizzahut, burgerking of sushimania): pizzahut

1. Toon alle gerechten
2. Toon duurste gerecht
Kies een optie uit het menu: 2

Gerecht 'Pepperoni' kost 10 euro, is een hoofdgerecht en bevat 800 kcal.

1. Afsluiten
2. Restaurant kiezen
Kies een optie uit het menu: 1
```

### Herhaling
```
1. Afsluiten
2. Restaurant kiezen
Kies een optie uit het menu: 2

Kies een restaurant (pizzahut, burgerking of sushimania): sushimania

1. Toon alle gerechten
2. Toon duurste gerecht
Kies een optie uit het menu: 1

Gerecht 'California Roll' kost 7 euro, is een hoofdgerecht en bevat 300 kcal.
Gerecht 'Salmon Nigiri' kost 8 euro, is een hoofdgerecht en bevat 200 kcal.
Gerecht 'Miso Soup' kost 3 euro, is een voorgerecht en bevat 50 kcal.
Gerecht 'Green Tea' kost 2 euro, is een drank en bevat 0 kcal.
Gerecht 'Mochi' kost 4 euro, is een dessert en bevat 120 kcal.

1. Afsluiten
2. Restaurant kiezen
Kies een optie uit het menu: 2

Kies een restaurant (pizzahut, burgerking of sushimania): sushimania

1. Toon alle gerechten
2. Toon duurste gerecht
Kies een optie uit het menu: 2

Gerecht 'Salmon Nigiri' kost 8 euro, is een hoofdgerecht en bevat 200 kcal.

1. Afsluiten
2. Restaurant kiezen
Kies een optie uit het menu: 1
```

### Gegevensvalidatie

#### Ongeldige menu keuze
```
1. Afsluiten
2. Restaurant kiezen
Kies een optie uit het menu: 3
Kies een optie uit het menu: -1
Kies een optie uit het menu: ABC
Kies een optie uit het menu: 0
Kies een optie uit het menu: 1
```

#### Ongeldig restaurant
```
1. Afsluiten
2. Restaurant kiezen
Kies een optie uit het menu: 2

Kies een restaurant (pizzahut, burgerking of sushimania): indy
Kies een restaurant (pizzahut, burgerking of sushimania): OK
Kies een restaurant (pizzahut, burgerking of sushimania): McDonalds
Kies een restaurant (pizzahut, burgerking of sushimania): -1
Kies een restaurant (pizzahut, burgerking of sushimania): burgerpling
Kies een restaurant (pizzahut, burgerking of sushimania): BURGERKING

1. Toon alle gerechten
2. Toon duurste gerecht
Kies een optie uit het menu: 2

Gerecht 'Whopper' kost 9 euro, is een hoofdgerecht en bevat 850 kcal.

1. Afsluiten
2. Restaurant kiezen
Kies een optie uit het menu: 1
```