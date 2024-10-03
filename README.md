# Moment 3 - DT071G - Programmering i C#

### Uppgiftsbeskrivning:
Denna uppgift gick ut på att skapa en konsolapplikation som fungerar som en gästbok, utifrån en given instruktions-lista.
Applikationen är skriven i C# och använder JSON för att lagra data. 

För att starta applikationen, skriv kommando:
```bash
dotnet run
```

### Funktionalitet:
- När användaren startar applikationen visas menyn med 3 olika alternativ (lägg till, ta bort eller avsluta) samt en lista med inlägg i gästboken (om det finns några inlägg)
- Om användaren anger något annat än de alternativ som finns i menyn, genereras ett felmeddelande.
- I gästboken kan användaren lägga till och ta bort valfritt inlägg samt avsluta applikationen.
- När användaren vill lägga till ett inlägg måste den ange "namn" och "meddelande". Om något av dessa fält lämnas tomma genereras ett felmeddelande.
- När användaren vill radera ett inlägg måste den ange ett nummer (index) som matchar något av inläggen. Om användaren anger ett nummer som inte matchar eller annat ogiltigt input genereras ett felmeddelande.
- Samtliga inlägg som läggs till i gästboken serialiseras/deserialiseras och sparas på en json-fil "guestbookData.json". Om användaren raderar inlägg, försvinner de även från denna filen. 
- Vid varje genomfört menyval rensas och skrivs skärmen om. 

### Skapad av:
- Julie Andersson
- Webbutvecklingsprogrammet på Mittuniversitetet i Sundsvall
- Moment 3 i kursen DT071G - Programmering i C#.