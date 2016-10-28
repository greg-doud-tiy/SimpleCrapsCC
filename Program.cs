using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        Random rnd = new Random(DateTime.Now.Millisecond);
        int RollDice() {
            var d2to12 = rnd.Next(11) + 2; // returns 2 to 12;
            Console.WriteLine("Roll is {0}", d2to12);
            return d2to12;
        }
        bool IsFirstRollWinnerOrLoser(int dice) {
            List<int> ints = new List<int>() { 2, 3, 7, 11, 12 };
            return ints.Contains(dice);
        }
        bool IsFirstRollWinner(int dice) {
            return dice == 7 || dice == 11;
        }
        bool PlayCraps()
        {
            Console.WriteLine("Playing craps here");
            var dice = RollDice();
            if(IsFirstRollWinnerOrLoser(dice)) {
                if(IsFirstRollWinner(dice)) {
                    return true;
                } else {
                    return false;
                }
            }
            var point = dice;
            Console.WriteLine("Point is {0}", point);
            dice = 0; // so it doesn't eq point
            while(dice != 7 && dice != point) {
                dice = RollDice();
            }
            if(dice == 7) {
                return false;
            } else {
                return true;
            }
        }
        void Run()
        {
            Console.WriteLine("Welcome to Simple Craps!");
            Console.WriteLine("Here are the instructions on how to play the game");
            var quit = false;
            do
            {
                var winner = PlayCraps();
                if(winner) {
                    Console.WriteLine("Winner!");
                } else {
                    Console.WriteLine("Loser...");
                }
                quit = AskQuitNow();
            } while (!quit);
        }
        bool AskQuitNow() {
            Console.WriteLine("Quit Now? (Y/N) : ");
            return Console.ReadLine().ToUpper().StartsWith("Y");
        }
        public static void Main(string[] args)
        {
            new Program().Run();
        }
    }
}
