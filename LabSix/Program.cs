using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSix
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int diceSides, dieOne, dieTwo, timesRolled;
            timesRolled = 0;
            Console.WriteLine("Welcome to the Grand Circus Casino!");
            diceSides = ValidInteger();

            do
            {
                if(timesRolled > 0)
                {
                    bool change;
                    Console.WriteLine("Would you like to change the dice?");
                    change = YesOrNo();
                    if(change)
                    {
                        diceSides = ValidInteger();
                    }
                }

                timesRolled++;
                dieOne = DiceRoll(diceSides, rand);
                dieTwo = DiceRoll(diceSides, rand);

                Console.WriteLine("Roll " + timesRolled + ":");
                Console.WriteLine(dieOne);
                Console.WriteLine(dieTwo);

                SpecialRolls(dieOne, dieTwo);
                Console.WriteLine("Roll Again?");
            } while (YesOrNo());

            Console.WriteLine("Goodbye!");
        }

        private static void SpecialRolls(int dieOne, int dieTwo)
        {
            if (dieOne == 1 && dieTwo == 1)
            { Console.WriteLine("Congrats! Snake eyes!"); }
            if (dieOne == 6 && dieTwo == 6)
            { Console.WriteLine("Congrats! Box Cars!"); }
            if ((dieOne == 7 && dieTwo == 11) || (dieOne == 11 && dieTwo == 7))
            { Console.WriteLine("WOAH! BIG WIN! You rolled craps!"); }
        }

        private static int DiceRoll(int diceSides, Random rand)
        {
            int value = rand.Next(1,diceSides);
            return value;
        }

        private static bool YesOrNo()
        {
            string input;
            bool correctRespone = true;
            while (correctRespone)
            {
                Console.Write("(y/n):");
                input = Console.ReadLine().ToLower();
                if (String.Equals("n", input))
                {
                    return false;
                }
                else if (String.Equals("y", input))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("That is an invalid entry!");
                    continue;
                }
            }
            return false; //should never get hit needed to make it happy.
        }

        public static int ValidInteger()
        {
            String input;
            bool validInput;
            int inputNum;

            Console.WriteLine("How many sides should each die have? ");
            Console.Write("Please Enter a number: ");

            do
            {
                input = Console.ReadLine();
                validInput = int.TryParse(input, out inputNum);
                if (!validInput)
                {
                    Console.WriteLine("Please type a valid Number");
                    validInput = false;
                }
                else if (inputNum < 1)
                {
                    Console.WriteLine("Please type a number greater than zero.");
                    validInput = false;
                }
                else
                {
                    validInput = true;
                }
            } while (!validInput);

            return inputNum;
        }
    }
}
