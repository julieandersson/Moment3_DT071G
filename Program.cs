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

        public static void MainMenu()
        {

        }

        public static void AddPost() { }
        public static void DeletePost() { }
        public static void DisplayPosts() { }
        public static void SavePosts() { }
        public static void LoadPosts() { }
        public static void ExitProgram() { }
    }
}
