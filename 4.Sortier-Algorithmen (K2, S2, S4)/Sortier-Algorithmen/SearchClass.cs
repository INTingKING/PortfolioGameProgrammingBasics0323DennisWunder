using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortier_Algorithmen
{
    internal class SearchClass
    {
        public static int[] SearchSort(int[] inputArray)
        {
            int[] outputArray = inputArray;

            Console.WriteLine(
                "Which sortering method do you want to use?\n    Rise - 1\n    Fall - 2\n    Zic Zac - 3\n(Choose by typing a number(1/2/3))"
            );
            string stringInput = Console.ReadLine();
            while (stringInput != "1" && stringInput != "2" && stringInput != "3")
            {
                stringInput = Console.ReadLine();
            }
            int.TryParse(stringInput, out int intOutput);

            Console.Clear();

            switch (intOutput)
            {
                case 1:
                    outputArray = Rise(inputArray);
                    break;
                case 2:
                    outputArray = Fall(inputArray);
                    break;
                case 3:
                    outputArray = ZicZac(inputArray);
                    break;
            }

            return outputArray;
        }

        public static int[] Rise(int[] inputArray)
        {
            int remainingLength = 0;
            List<int> sortList = new List<int>();
            int saveSpot = 0;
            while (remainingLength < inputArray.Length)
            {
                int counter = 0;
                int smallestNumber = 10000001;
                while (counter < inputArray.Length)
                {
                    if (smallestNumber > inputArray[counter])
                    {
                        smallestNumber = inputArray[counter];
                        saveSpot = counter;
                    }
                    counter++;
                }
                sortList.Add(smallestNumber);
                inputArray[saveSpot] = 10000001;
                remainingLength++;
            }
            int[] outputArray = sortList.ToArray();
            return outputArray;
        }

        public static int[] Fall(int[] inputArray)
        {
            int remainingLength = 0;
            List<int> sortList = new List<int>();
            int saveSpot = 0;
            while (remainingLength < inputArray.Length)
            {
                int counter = 0;
                int smallestNumber = 0;
                while (counter < inputArray.Length)
                {
                    if (smallestNumber < inputArray[counter])
                    {
                        smallestNumber = inputArray[counter];
                        saveSpot = counter;
                    }
                    counter++;
                }
                sortList.Add(smallestNumber);
                inputArray[saveSpot] = 0;
                remainingLength++;
            }
            int[] outputArray = sortList.ToArray();
            return outputArray;
        }

        public static int[] ZicZac(int[] inputArray)
        {
            int remainingLength = 0;
            List<int> sortList = new List<int>();
            int saveSpot = 0;
            int smallestNumber = 10000001;
            while (remainingLength < inputArray.Length)
            {
                int counter = 0;

                if (remainingLength % 2 == 0)
                {
                    while (counter < inputArray.Length)
                    {
                        if (smallestNumber > inputArray[counter] && inputArray[counter] != 0)
                        {
                            smallestNumber = inputArray[counter];
                            saveSpot = counter;
                        }

                        counter++;
                    }
                    smallestNumber = 0;
                }
                else
                {
                    while (counter < inputArray.Length)
                    {
                        if (smallestNumber < inputArray[counter])
                        {
                            smallestNumber = inputArray[counter];
                            saveSpot = counter;
                        }
                        counter++;
                    }
                    smallestNumber = 10000001;
                }

                sortList.Add(inputArray[saveSpot]);
                inputArray[saveSpot] = 0;
                remainingLength++;
            }
            int[] outputArray = sortList.ToArray();
            return outputArray;
        }
    }
}
