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


        public static void AddPost() { }
        public static void DeletePost() { }
        public static void DisplayPosts() { }
        public static void SavePosts() { }
        public static void LoadPosts() { }
        public static void ExitProgram() { }
    }
}
