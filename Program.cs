using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DiceRoller
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Type a roll formatted XdY, where X = times and Y = sides (2d6: roll a six-sided die two times). Type 'quit' to quit program.");
            string selection = Console.ReadLine();
            
            while (selection != "quit")
            {
                while (!Regex.Match(selection, "[0-9]d[0-9]").Success)
                {
                    Console.WriteLine("Invalid format, try again");
                    selection = Console.ReadLine();
                }

                int times = Convert.ToInt32(selection.Split('d')[0]);
                int sides = Convert.ToInt32(selection.Split('d')[1]);

                Console.WriteLine("");
                rollDice(sides, times);

                Console.WriteLine("Roll again?");
                selection = Console.ReadLine();
            }
        }

        static void rollDice(int sides, int count)
        {
            int totalValue = 0;
            List<int> rollValues = new List<int>();
            string printValues = "";

            var rand = new Random();

            Console.WriteLine(string.Format("Results for {0}d{1}:", count.ToString(), sides.ToString()));

            for (int i = 0; i < count; i++)
            {
                int result = rand.Next(1, sides);
                totalValue += result;
                rollValues.Add(result);
                printValues += string.Format("{0} ", result.ToString());
            }

            Console.WriteLine(string.Format("Result: {0}", totalValue.ToString()));

            if (count > 1)
                Console.WriteLine(printValues);           
        }
    }
}
