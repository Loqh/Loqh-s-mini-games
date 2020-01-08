using System;

namespace ConsoleApplication1
{
    public class CheapSaber
    {
        private static ConsoleKey userInput;
        private static int playerScore;
        public static void Start()
        {
            // c
            while (playerScore < 500)
            {
                GenerateKey();

                var currTime = DateTime.Now;
                var endTime = DateTime.Now.AddSeconds(5);

                while (currTime < endTime)
                {
                    currTime = DateTime.Now;

                    if (Console.KeyAvailable)
                    {
                        var userChoice = Console.ReadKey(true).Key;

                        if (userChoice == userInput)
                        {
                            playerScore += 100;
                            Console.WriteLine("Nice | Score : "+playerScore);
                            Start();
                        }
                        else
                        {
                            playerScore -= 100;
                            Console.WriteLine("Fail | Score : "+playerScore);
                            Start();
                        }   
                    }

                    if (currTime >= endTime)
                    {
                        playerScore -= 100;
                        Console.WriteLine("Timeout | Score : "+playerScore); 
                        Start();
                    }
                }
            }
            Console.WriteLine("\nPress ANY KEY to return to the main menu");
            var userChoiceMainMenu = Console.ReadKey(true).Key;
            ResetScore();
            Program.Start();
        }

        public static void GenerateKey()
        {
            Random random = new Random();
            int nextInput = random.Next(0, 5);

            switch (nextInput)
            {
                case 0: 
                    Console.WriteLine("[_]");
                    userInput = ConsoleKey.Spacebar;
                    break;
                case 1: 
                    Console.WriteLine("[\u2190]");
                    userInput = ConsoleKey.LeftArrow;
                    break;
                case 2: 
                    Console.WriteLine("[\u2192]");
                    userInput = ConsoleKey.RightArrow;
                    break;
                case 3: 
                    Console.WriteLine("[\u2191]");
                    userInput = ConsoleKey.UpArrow;
                    break;
                case 4: 
                    Console.WriteLine("[\u2193]");
                    userInput = ConsoleKey.DownArrow;
                    break;

            }
        }
        public static void ResetScore()
        {
            playerScore = 0;
        }
    }
}