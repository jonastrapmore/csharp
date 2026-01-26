# F-PLANETEN
Als ruimte liefhebber ben je helemaal gefascineerd door ons universum. Het is jouw taak als onderzoeker om een werkende console applicatie te programmeren. We willen graag informatie opvragen over planeten die rond een ster draaien. Veel succes!

## Opdrachtomschrijving
De appliatie start eerst met een hoofdmenu te vragen. De mogelijke opties zijn ``Afsluiten`` en ``Ster kiezen``. Het programma blijft actief totdat de gebruiker kiest voor ``Afsluiten``.

Wanneer de gebruiker kiest voor `Ster kiezen`, moet hij of zij één van de volgende sterren ingeven (rekening houdend met hoofd/kleine letters):
1. zon
2. luhman16
3. proxima-centauri

Na het kiezen van de ster zal de gebruiker een submenu te zien krijgen. De mogelijke opties van het submenu zijn ``Toon alle planeten``, ``Toon planeet dichtste van ster``, ``Toon planeet verste van ster`` en tot slot ``Toon alle planeten van type``.

Afhankelijk van de keuze wordt de juiste methode uitgevoerd. Bij de optie ``Toon planeet verste van ster`` moet je eerst vragen naar het gewenste type planeet. Alleen de types ``rots``, ``gasreus`` en ``ijsreus`` zijn toegelaten (rekening houdend met hoofd/kleine letters).

Na het afhandelen van een submenu-optie wordt opnieuw het hoofdmenu getoond.

### Methodes
Je mag zelf hulp methodes toevoegen, maar je bent hier niet tot verplicht. Onderstaande methodes moeten verplicht geprogrammeerd **en** gebruikt worden.

#### **`void PrintInfoPlaneet(string naam, string afstandSter, string planeetType, string leeftijd)`** 
Deze methode zal volgende informatie op het scherm printen:
``Planeet '{naam}' met een afstand van {afstandSter} miljoen km van zijn ster. De planeet is een {planeetType} en is {leeftijd} miljoen jaar oud.``

#### **`List<string> LeesPlaneten(string ster)`** 
Deze methode zal een ster bestand uitlezen. De methode geeft een lijst van planeten (string) terug.

#### **`void ToonPlaneten(string ster)`** 
Drukt alle planeten rond de ster af met behulp van `PrintInfoPlaneet`.

#### **`void ToonPlanetenVanType(string ster, string type)`** 
Drukt alle planeten van het gegeven type af met behulp van `PrintInfoPlaneet`.

#### **`void ToonDichtstePlaneet(string ster)`** 
Drukt de planeet af die zich het dichtst bij de ster bevindt met behulp van `PrintInfoPlaneet`.  
**Let op: de volgorde in de tekstbestanden mag niet worden aangepast!**

#### **`void ToonVerstePlaneet(string ster)`** 
Drukt de planeet af die zich het verst van de ster bevindt met behulp van `PrintInfoPlaneet`.  
**Let op: de volgorde in de tekstbestanden mag niet worden aangepast!**

## Tekstbestanden 

Er zijn 3 tekstbestanden genaamd `zon.txt`, `luhman16.txt` en `proxima-centauri.txt`. Elk tekstbestand bevat verschillende planeten die rond de ster draaien. De info van de planeten is als volgt opgebouwd:

1. Naam planeet
2. Type planeet
3. Leeftijd in miljoen jaar
4. Afstand van ster in miljoen km

## Voorbeelden

### Afsluiten
```
1. Afsluiten
2. Ster kiezen
Kies een optie uit het menu: 1
```

### Kiezen voor zon en tonen van alle planeten
```
1. Afsluiten
2. Ster kiezen
Kies een optie uit het menu: 2

Kies een ster (zon, luhman16 of proxima-centauri): zon

1. Toon alle planeten
2. Toon planeet dichtste van ster
3. Toon planeet verste van ster
4. Toon alle planeten van type
Kies een optie uit het menu: 1

Planeet 'Mercurius' met een afstand van 58 miljoen km van zijn ster. De planeet is een rots en is 4,5 miljoen jaar oud.
Planeet 'Venus' met een afstand van 108 miljoen km van zijn ster. De planeet is een rots en is 4,5 miljoen jaar oud.
Planeet 'Aarde' met een afstand van 147 miljoen km van zijn ster. De planeet is een rots en is 4,6 miljoen jaar oud.
Planeet 'Mars' met een afstand van 207 miljoen km van zijn ster. De planeet is een rots en is 4,6 miljoen jaar oud.
Planeet 'Jupiter' met een afstand van 742 miljoen km van zijn ster. De planeet is een gasreus en is 4,6 miljoen jaar oud.
Planeet 'Saturnus' met een afstand van 1479 miljoen km van zijn ster. De planeet is een gasreus en is 4,6 miljoen jaar oud.
Planeet 'Uranus' met een afstand van 2871 miljoen km van zijn ster. De planeet is een ijsreus en is 4,6 miljoen jaar oud.
Planeet 'Neptunus' met een afstand van 4495 miljoen km van zijn ster. De planeet is een ijsreus en is 4,6 miljoen jaar oud.

1. Afsluiten
2. Ster kiezen
Kies een optie uit het menu: 1
```

### Kiezen voor zon en type rots
```
1. Afsluiten
2. Ster kiezen
Kies een optie uit het menu: 2

Kies een ster (zon, luhman16 of proxima-centauri): zon

1. Toon alle planeten
2. Toon planeet dichtste van ster
3. Toon planeet verste van ster
4. Toon alle planeten van type
Kies een optie uit het menu: 4

Geef een type planeet (rots, gasreus of ijsreus): rots

Planeet 'Mercurius' met een afstand van 58 miljoen km van zijn ster. De planeet is een rots en is 4,5 miljoen jaar oud.
Planeet 'Venus' met een afstand van 108 miljoen km van zijn ster. De planeet is een rots en is 4,5 miljoen jaar oud.
Planeet 'Aarde' met een afstand van 147 miljoen km van zijn ster. De planeet is een rots en is 4,6 miljoen jaar oud.
Planeet 'Mars' met een afstand van 207 miljoen km van zijn ster. De planeet is een rots en is 4,6 miljoen jaar oud.

1. Afsluiten
2. Ster kiezen
Kies een optie uit het menu: 1
```

### Kiezen voor zon en dichtste planeet
```
1. Afsluiten
2. Ster kiezen
Kies een optie uit het menu: 2

Kies een ster (zon, luhman16 of proxima-centauri): zon

1. Toon alle planeten
2. Toon planeet dichtste van ster
3. Toon planeet verste van ster
4. Toon alle planeten van type
Kies een optie uit het menu: 2

Planeet 'Mercurius' met een afstand van 58 miljoen km van zijn ster. De planeet is een rots en is 4,5 miljoen jaar oud.

1. Afsluiten
2. Ster kiezen
Kies een optie uit het menu: 1
```

### Kiezen voor zon en verste planeet
```
1. Afsluiten
2. Ster kiezen
Kies een optie uit het menu: 2

Kies een ster (zon, luhman16 of proxima-centauri): zon

1. Toon alle planeten
2. Toon planeet dichtste van ster
3. Toon planeet verste van ster
4. Toon alle planeten van type
Kies een optie uit het menu: 3

Planeet 'Neptunus' met een afstand van 4495 miljoen km van zijn ster. De planeet is een ijsreus en is 4,6 miljoen jaar oud.

1. Afsluiten
2. Ster kiezen
Kies een optie uit het menu: 1
```

### Kiezen voor luhman16 en verste planeet
```
1. Afsluiten
2. Ster kiezen
Kies een optie uit het menu: 2

Kies een ster (zon, luhman16 of proxima-centauri): luhman16

1. Toon alle planeten
2. Toon planeet dichtste van ster
3. Toon planeet verste van ster
4. Toon alle planeten van type
Kies een optie uit het menu: 3

Planeet 'L16-γ' met een afstand van 150 miljoen km van zijn ster. De planeet is een ijsreus en is 2,5 miljoen jaar oud.

1. Afsluiten
2. Ster kiezen
Kies een optie uit het menu: 1
```

### Kiezen voor proxima-centauri en type gasreus
```
1. Afsluiten
2. Ster kiezen
Kies een optie uit het menu: 2

Kies een ster (zon, luhman16 of proxima-centauri): proxima-centauri

1. Toon alle planeten
2. Toon planeet dichtste van ster
3. Toon planeet verste van ster
4. Toon alle planeten van type
Kies een optie uit het menu: 4

Geef een type planeet (rots, gasreus of ijsreus): gasreus

1. Afsluiten
2. Ster kiezen
Kies een optie uit het menu: 1
```
*Opgelet: Er zijn geen gasreus planeten die rond proxima-centauri draaien. Je hoeft er geen extra logica / print voor toevoegen.*

### Herhaling
```
1. Afsluiten
2. Ster kiezen
Kies een optie uit het menu: 2

Kies een ster (zon, luhman16 of proxima-centauri): luhman16

1. Toon alle planeten
2. Toon planeet dichtste van ster
3. Toon planeet verste van ster
4. Toon alle planeten van type
Kies een optie uit het menu: 2

Planeet 'L16-a' met een afstand van 35 miljoen km van zijn ster. De planeet is een rots en is 3,1 miljoen jaar oud.

1. Afsluiten
2. Ster kiezen
Kies een optie uit het menu: 2

Kies een ster (zon, luhman16 of proxima-centauri): luhman16

1. Toon alle planeten
2. Toon planeet dichtste van ster
3. Toon planeet verste van ster
4. Toon alle planeten van type
Kies een optie uit het menu: 3

Planeet 'L16-y' met een afstand van 150 miljoen km van zijn ster. De planeet is een ijsreus en is 2,5 miljoen jaar oud.

1. Afsluiten
2. Ster kiezen
Kies een optie uit het menu: 1
```

### Gegevensvalidatie

#### Ongeldige menu keuze
```
1. Afsluiten
2. Ster kiezen
Kies een optie uit het menu: 3
Kies een optie uit het menu: -1
Kies een optie uit het menu: ABC
Kies een optie uit het menu: 0
Kies een optie uit het menu: 1
```

#### Ongeldige ster
```
1. Afsluiten
2. Ster kiezen
Kies een optie uit het menu: 2

Kies een ster (zon, luhman16 of proxima-centauri): sterrenstelsel
Kies een ster (zon, luhman16 of proxima-centauri): zon
```

#### Ongeldige type planeet
```
...
1. Toon alle planeten
2. Toon planeet dichtste van ster
3. Toon planeet verste van ster
4. Toon alle planeten van type
Kies een optie uit het menu: 4

Geef een type planeet (rots, gasreus of ijsreus): plasreus
Geef een type planeet (rots, gasreus of ijsreus): ijsreus

Planeet 'Uranus' met een afstand van 2871 miljoen km van zijn ster. De planeet is een ijsreus en is 4,6 miljoen jaar oud.
Planeet 'Neptunus' met een afstand van 4495 miljoen km van zijn ster. De planeet is een ijsreus en is 4,6 miljoen jaar oud.
...
```