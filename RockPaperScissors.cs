using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class RockPaperScissors : Program
    {
        static String[] RPS = {Translation[5], Translation[6], Translation[7]};
        static List<Char> RPSConsoleKey = new List<char>();

        private static int AIscore;
        private static int PlayerScore;
        private static int RoundCount;
        private static int maxScore = 2;

        public static void StartGame()
        {
            foreach(string word in RPS)
            {
                RPSConsoleKey.Add(word[0]);
            }
            
            Console.Clear();
            
            Console.WriteLine(Translation[8]);

            while (AIscore < 2 && PlayerScore < 2)
            {
                Ai(Player());
                Console.WriteLine(Translation[9] + PlayerScore);
                Console.WriteLine(Translation[10] + AIscore);
            }

            Console.WriteLine("\n"+"----------------");
            
            if (PlayerScore == maxScore)
            {
                Console.WriteLine(Translation[11]);
                playerWins++;
            }

            else if (AIscore == maxScore)
            {
                Console.WriteLine(Translation[12]);
                AIWins++;
            }

            Console.WriteLine("\nPress ANY KEY to return to the main menu");
            var userChoiceMainMenu = Console.ReadKey(true).Key;
            ResetScore();
            Program.Start();
            

            Console.WriteLine("----------------");
        }

        public static String Player()
        {
            Console.WriteLine("");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(Translation[13]);
            Console.WriteLine("---------------------------------------");

            String PlayerResult;
            var playerInput = Console.ReadKey(true).Key;
            if (playerInput == (ConsoleKey) RPSConsoleKey[0])
            {
                PlayerResult = Translation[5];
            }
            else if (playerInput == (ConsoleKey) RPSConsoleKey[1])
            {
                PlayerResult = Translation[6];
            }
            else if (playerInput == (ConsoleKey) RPSConsoleKey[2])
            {

                PlayerResult = Translation[7];
            }
            else
            {
                PlayerResult = "";
            }

            Console.WriteLine(Translation[14]+" : "+PlayerResult);

            return PlayerResult;
        }

        public static void Ai(String PlayerResult)
        {
            Random random = new Random();

            int index = random.Next(RPS.Length);
            var AIResult = RPS[index];

            Console.WriteLine(Translation[15]+" : "+AIResult);
            Console.WriteLine("---------------------------------------");
            RoundCount++;
            Console.Write(Translation[18]+RoundCount+" : ");

            if (PlayerResult == AIResult)
            {
                Console.WriteLine(Translation[17]);
            }
            else if (PlayerResult == RPS[0] && AIResult == RPS[1])
            {
                Console.WriteLine(Translation[15]+Translation[16]);
                AIscore++;
            }
            else if (PlayerResult == RPS[0] && AIResult == RPS[2])
            {
                Console.WriteLine(Translation[14]+Translation[16]);
                PlayerScore++;
            }
            else if (PlayerResult == RPS[1] && AIResult == RPS[2])
            {
                Console.WriteLine(Translation[15]+Translation[16]);
                AIscore++;
            }
            else if (AIResult == RPS[0] && PlayerResult == RPS[1])
            {
                Console.WriteLine(Translation[14]+Translation[16]);
                PlayerScore++;
            }
            else if (AIResult == RPS[0] && PlayerResult == RPS[2])
            {
                Console.WriteLine(Translation[15]+Translation[16]);
                AIscore++;
            }
            else if (AIResult == RPS[1] && PlayerResult == RPS[2])
            {
                Console.WriteLine(Translation[14]+Translation[16]);
                PlayerScore++;
            }
        }
        public static void ResetScore()
        {
        AIscore = 0;
        PlayerScore = 0;
        RoundCount = 0;
        }
    }
}