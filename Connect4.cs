using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApplication1
{
    public class Connect4
    {
        // private static char[] userShoot = {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-'};

        private static Char[] Crossbar = {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-'};
        private static Char[] Top = {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'O', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'};
        private static Char[] Middle = {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '(', '|', ')', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'};
        private static Char[] Bottom = {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '/', ' ', '\\', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'};

        private static Random random = new Random();
        public static void Start()
        {
            for (int i = 1; i <= 3; i++)
            {
                displayShoots();
            }

            End();
        }

        public static void displayShoots()
        {
            generateShoot();
            displayGoal();
            Reset();
            Thread.Sleep(2000);
        }

        public static void userShoots()
        {
            
        }

        public static void displayGoal()
        {
            Console.Clear();
            
            foreach (var element in Crossbar)
            {
                Console.Write(element);
            }

            Console.WriteLine(" ");
                    
            foreach (var element in Top)
            {
                Console.Write(element);
            }

            Console.WriteLine(" ");
                    
            foreach (var element in Middle)
            {
                Console.Write(element);
            }

            Console.WriteLine(" ");

            foreach (var element in Bottom)
            {
                Console.Write(element);
            }
        }

        public static void generateShoot()
        {
            int generateHeight = random.Next(0, 4);

            Char[] heightResult = Bottom;

            switch (generateHeight)
            {
                case 0: heightResult = Crossbar;
                    break;
                case 1: heightResult = Top;
                    break;
                case 2: heightResult = Middle;
                    break;
                case 3: heightResult = Bottom;
                    break;
            }
            
            int generateWidth = random.Next(0, heightResult.Length);

            heightResult[generateWidth] = 'O';
            List<int> list = new List<int>();
            list.Add(generateHeight);
            list.Add(generateWidth);
        }

        public static void Reset()
        {
        Char[] resetCrossbar = {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-'};
        Char[] resetTop = {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'O', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'};
        Char[] resetMiddle = {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '(', '|', ')', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'};
        Char[] resetBottom = {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '/', ' ', '\\', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'};

        Crossbar = resetCrossbar;
        Top = resetTop;
        Middle = resetMiddle;
        Bottom = resetBottom;
        }

        public static void End()
        {
            Console.WriteLine("\nPress ANY KEY to return to the main menu");
            var userChoiceMainMenu = Console.ReadKey(true).Key;
            // ResetScore();
            Program.Start();
        }
    }
}