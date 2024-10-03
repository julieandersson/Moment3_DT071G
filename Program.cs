using System;
using System.Text.Json;
using System.Globalization;

namespace GuestbookApp
{
    class Program
    {
        // Skapar lista för att lagra alla inlägg i gästboken
        private static List<Post> guestbookPosts = new List<Post>();

        static void Main(string[] args)
        {
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


        public static void DeletePost() { }
        public static void DisplayPosts() { }
        public static void SavePosts() { }
        public static void LoadPosts() { }
        public static void ExitProgram() { }
    }
}
