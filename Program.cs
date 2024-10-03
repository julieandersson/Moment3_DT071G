using System;
using System.Text.Json;
using System.Globalization;

namespace GuestbookApp
{
    class Program
    {
        // Skapar lista för att lagra alla inlägg i gästboken
        private static List<Post> guestbookPosts = new List<Post>();
        private static string guestbookFile = "guestbookData.json";

        static void Main(string[] args)
        {
            LoadPosts(); // Laddar in sparade inlägg från filen
            MainMenu(); // Visa huvudmenyn
        }

        // Metod för att visa menyn med olika val
        public static void MainMenu()
        {
            while (true) // Loopar och visar menyn tills att användaren har avslutat programmet
            {
               Console.Clear();
               Console.WriteLine("J U L I E S  G Ä S T B O K");
               Console.WriteLine("1 - Lägg till inlägg");
               Console.WriteLine("2 - Ta bort inlägg");
               Console.WriteLine("X - Avsluta\n");

               DisplayPosts(); // Visar befintliga inlägg om det finns några

               char input = Console.ReadKey(true).KeyChar; // Läser in användarens val

               // Skapar en switch-sats för att hantera användarens val
               switch (input)
               {
                   case '1':
                       AddPost(); // Lägg till nytt inlägg
                       break;
                   case '2':
                       DeletePost(); // Ta bort inlägg
                       break;
                   case 'X':
                   case 'x':
                       ExitProgram(); // Avsluta programmet
                       break;
                   default:
                       Console.WriteLine("Ogiltigt val. Försök igen."); // Felmeddelande om användaren anger annat än 1, 2, x eller X
                       break;
        }
    }
}

        // Lägger till ett nytt inlägg i gästboken
        public static void AddPost() 
        { 
            Console.Clear(); // Rensar konsoll
            Post newPost = new Post(); // Skapar nytt postobjekt

            newPost.Author = PromptForInput("Ange ditt namn: ");
            newPost.Message = PromptForInput("Skriv ditt inlägg: ");

            guestbookPosts.Add(newPost); // Lägger till det nya inlägget i listan

            SavePosts(); // Sparar alla inlägg

            Console.WriteLine("Inlägget har sparats!"); // Bekräftelse när inlägg har sparats
            ReturnToMenu();
        }

        // Metod för att se så att inget fält är tomt
        public static string PromptForInput(string prompt)
        {
            string? input;
            do
            {
                // Inväntar användarens input
                Console.Write(prompt);
                input = Console.ReadLine();

                // Om input är tomt, be användaren försöka igen 
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Fältet får inte vara tomt. Försök igen.");
                }
            } while (string.IsNullOrEmpty(input)); // Fortsätter tills att input inte är tomt

            // Returnerar input när det är giltigt
            return input;
        }

        // Visar meddelande och väntar på att användaren ska trycka på valfri knapp
        public static void ReturnToMenu()
        {
            Console.WriteLine("\nTryck på valfri knapp för att återvända till menyn.");
            Console.ReadKey(); // Väntar på knapptryckning
        }

        
        public static void DisplayPosts()
        { 

            // Rubrik för gästboksinläggen
            Console.WriteLine("\nG Ä S T B O K S I N L Ä G G\n");

            // Kollar om det finns några inlägg i gästboken
            if (guestbookPosts.Count == 0)
            {
                // Meddelande om inga inlägg hittas
                Console.WriteLine("Inga inlägg hittades.\n");
            } else {
                // Loopar igenom alla inlägg och visar dem med index, namn och meddelande
                for (int i = 0; i < guestbookPosts.Count; i++)
                {
                    Console.WriteLine($"[{i}] {guestbookPosts[i].Author} - {guestbookPosts[i].Message}\n");
                }
            }
        }

        // Sparar alla gästboksinlägg till en JSON-fil
        public static void SavePosts()
        { 
            // Serialiserar listan med inlägg till JSON-format
            string jsonData = JsonSerializer.Serialize(guestbookPosts, new JsonSerializerOptions { WriteIndented = true});
            // Skriver ut JSON-datan till filen "guestbookData.json"
            File.WriteAllText(guestbookFile, jsonData);
        }

        // Läser in gästboksinläggen från en JSON-fil
        public static void LoadPosts()
        { 
            // Kollar om filen finns
            if (File.Exists(guestbookFile))
            {
               // Läser in data från filen
                string jsonData = File.ReadAllText(guestbookFile);
               // Deserialiserar JSON-datan tillbaka till en lista med inlägg
                guestbookPosts = JsonSerializer.Deserialize<List<Post>>(jsonData) ?? new List<Post>();
            }
        }

        // Tar bort ett inlägg från gästboken
        public static void DeletePost()
        {
            // Kontrollerar om det finns några inlägg att ta bort
            if (guestbookPosts.Count == 0)
            {
                // Om det inte finns några inlägg, skicka meddelande till användaren och återgå till meny
                Console.WriteLine("Det finns inga inlägg att ta bort.");
                ReturnToMenu();
                return; // Om inga inlägg finns, avsluta metoden
            }

            bool validInput = false; // Kolla om användaren anger ett giltigt nummer

            // Visar inläggslistan tills att användaren anger ett giltigt nummer 
            // Användaren får möjlighet att försöka igen om hen anger ett felaktigt nummer, utan att behöva gå tillbaka till menyn
            while (!validInput)
            {
                // Visar alla inlägg som finns så att användaren kan se vad de vill ta bort
                DisplayPosts();
                string input = PromptForInput("Ange numret på inlägget du vill ta bort: ");

                // Kontrollera om input är ett giltigt nummer som motsvarar ett inlägg i listan
                if (int.TryParse(input, out int index) && index >= 0 && index < guestbookPosts.Count)
                {
                    // Tar bort inlägget
                    guestbookPosts.RemoveAt(index);
                    // Sparar ändringarna till JSONfilen
                    SavePosts();
                    // Meddelande att inlägget har tagits bort
                    Console.WriteLine("Inlägget har tagits bort.");
                    validInput = true; // Stoppar loopen när giltigt nummer har angetts

                } else {
                    // Om input inte är giltigt, visa felmeddelande och be användaren att försöka igen 
                    Console.WriteLine("Numret du angav finns inte. Försök igen.");
                }
            }

            ReturnToMenu(); // Går tillbaka till menyn efter att inlägget tagits bort
         }
    
        // Avsluta programmet
        public static void ExitProgram()
        {
            Console.Clear();
            Console.WriteLine("Tack för att du använde gästboken. Hejdå!");
            Environment.Exit(0);
         }
    }
}
