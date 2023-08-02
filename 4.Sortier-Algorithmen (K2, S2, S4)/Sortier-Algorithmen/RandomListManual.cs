using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortier_Algorithmen
{
    internal class RandomListManual
    {
        public static int[] MakeRandomList()
        {
            Console.Clear();
            List<int> list = new List<int>();
            int outputInteger = 0;
            string inputString = "0";
            while (true)
            {
                while (outputInteger < 1 || 101 < outputInteger)
                {
                    Console.WriteLine(
                        "Please either enter a number to add to the list or type 'done' to finish the list\n(number must be in range 1-100)"
                    );
                    inputString = Console.ReadLine();
                    if (inputString == "done")
                    {
                        break;
                    }
                    int.TryParse(inputString, out outputInteger);
                    Console.Clear();
                }
                Console.Clear();

                if (inputString == "done" && list.Count > 0)
                {
                    break;
                }
                else if (list.Count < 1 && inputString == "done")
                {
                    Console.WriteLine(
                        "The length of the list must be at least 1 before entering 'done'"
                    );
                    Console.ReadKey(true);
                    inputString = "0";
                }
                if (outputInteger > 0 && outputInteger < 101)
                {
                    Console.Clear();
                    list.Add(outputInteger);
                    Console.WriteLine($"The number {outputInteger} has been added");
                }
                outputInteger = 0;
            }

            int[] randomNumberArray = list.ToArray();

            return randomNumberArray;
        }
    }
}
