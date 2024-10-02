# DT071G - Programmering i C#.NET, Moment 3

## Gästboksapplikation
Detta är en enkel **Gästboksapplikation** byggd med **C#** och **.NET**. Applikationen tillåter användare att:
- Lägga till gästboksinlägg med namn och meddelande.
- Visa alla befintliga inlägg.
- Ta bort ett gästboksinlägg genom att ange dess index/nummer.

Applikationen sparar alla gästboksinlägg i en JSON-fil (`guestbook.json`) så att inlägg sparas mellan sessioner.

## Funktioner
Konsolapplikationen är uppbyggd med en huvudmeny med följande funktioner:

- **1. Visa alla inlägg**: Visar en lista över alla befintliga inlägg, inklusive namn och meddelandetext för varje inlägg.
- **2. Lägg till ett inlägg**: Användare kan lägga till ett inlägg genom att ange sitt namn och meddelandetext.
- **3. Ta bort ett inlägg**: Visar en lista över alla inlägg och tillåter användare att ta bort ett inlägg genom att ange dess index i listan.
- **Avsluta applikationen**: Användare kan avsluta hela applikationen.

## Använda teknologier
- **C#**
- **.NET Core**
- **JSON-serialisering** för att spara gästboksinlägg i en fil.

## Om
* **Av:** Isa Westling
* **Kurs:** DT171G Programmering i C#.NET
* **Program:** Webbutvecklingsprogrammet
* **År:** 2024
* **Skola:** Mittuniversitetet