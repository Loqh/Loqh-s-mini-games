using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication1
{
    public class Program
    {
        private static bool wrongLangContent;
        
        public static String path = Path.Combine(Directory.GetCurrentDirectory());
        public static String langsPath = path + "/langs";
        public static String app_lang = File.ReadAllText(langsPath+"/lang.txt");
        public static String[] english_translation = File.ReadAllLines(langsPath+"/english/english.txt");
        public static String[] english_gameList = File.ReadAllLines(langsPath + "/english/gamelist.txt");
        public static String[] french_translation = File.ReadAllLines(langsPath+"/french/french.txt");
        public static String[] french_gameList = File.ReadAllLines(langsPath + "/french/gamelist.txt");

        public static bool firstStart = true;
        public static int playerWins;
        public static int AIWins;
        
        public static List<String> Translation = new List<string>();
        public static List<String> GameList = new List<string>();
        
        public static void Main(string[] args)
        {
            Start();
        }

        public static void Start()
        {
            Console.Clear();
            CheckTranslation();
            Translate();
            
            var userChoice = Console.ReadKey(true).Key;
            
            while (userChoice != ConsoleKey.D1 && userChoice != ConsoleKey.D2 && userChoice != ConsoleKey.L && userChoice != ConsoleKey.Q)
            {
                userChoice = Console.ReadKey( true).Key;
            }

            if (userChoice == ConsoleKey.L)
            {
                if (app_lang == "en")
                {
                    File.WriteAllText(langsPath + "/lang.txt", "fr");
                }
                
                else if (app_lang == "fr")
                {
                    File.WriteAllText(langsPath + "/lang.txt", "en");
                }

                app_lang = File.ReadAllText(langsPath+"/lang.txt");

                Translation.Clear();
                GameList.Clear();
                Start();
            }
            
            else if (userChoice == ConsoleKey.Q)
            {
                Environment.Exit(0);
            }
            
            else if (userChoice == ConsoleKey.D1)
            {
                RockPaperScissors.StartGame();
            }
            
            else if (userChoice == ConsoleKey.D2)
            {
                CheapSaber.Start();
            }
        }

        public static void CheckTranslation()
        {
            if (app_lang == "en")
            {
                foreach (var line in english_translation)
                {
                    Translation.Add(line);
                }

                foreach (var game in english_gameList)
                {
                    GameList.Add(game);
                }
            }
                
            else if (app_lang == "fr")
            {
                foreach (var line in french_translation)
                {
                    Translation.Add(line);
                }
                
                foreach (var game in french_gameList)
                {
                    GameList.Add(game);
                }
            }
            
            else
            {
               File.WriteAllText(langsPath + "/lang.txt", "en");
               app_lang = File.ReadAllText(langsPath+"/lang.txt");
               wrongLangContent = true;
               CheckTranslation();
            }
        }
        
        public static void Translate()
        {
            Console.Clear();

            if (wrongLangContent)
            {
                Console.WriteLine("! lang.txt content has been reset to English by default !"); 
            }

            if (firstStart)
            {
                Console.WriteLine(Translation[0]+"\n");
                firstStart = false;
            }

            if (playerWins > 0 || AIWins > 0)
            {
                Console.WriteLine(Translation[1]+"\n");
                Console.WriteLine("Player score : "+playerWins);
                Console.WriteLine("AI Score : "+AIWins+"\n");
            }
            
            Console.WriteLine(Translation[2]);
            Console.WriteLine("Q QUIT (IN FILE)"+"\n");
            
            Console.WriteLine("[1] "+Translation[3]+GameList[0]);
            Console.WriteLine("[2] "+Translation[3]+GameList[1]);
            Console.WriteLine("[3] " + Translation[3]);
        }
    }
}