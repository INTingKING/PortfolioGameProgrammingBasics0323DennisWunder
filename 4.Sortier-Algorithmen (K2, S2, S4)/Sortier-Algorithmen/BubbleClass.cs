using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Sortier_Algorithmen
{
    internal class BubbleClass
    {
        public int[] arr1;

        public static int[] BubbleSort(int[] inputArray)
        {
            int[] outputArray = new int[inputArray.Length];

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

        private static int[] Rise(int[] inputArray)
        {
            int number1;
            if (inputArray.Length > 0)
            {
                for (int y = 0; y < inputArray.Length - 1; y++)
                {
                    int x = 0;
                    while (x < inputArray.Length - 1)
                    {
                        if (inputArray[x] > inputArray[x + 1])
                        {
                            number1 = inputArray[x + 1];
                            inputArray[x + 1] = inputArray[x];
                            inputArray[x] = number1;
                        }
                        x++;
                    }
                }
            }

            return inputArray;
        }

        private static int[] Fall(int[] inputArray)
        {
            int number1;
            if (inputArray.Length > 0)
            {
                for (int y = 0; y < inputArray.Length - 1; y++)
                {
                    int x = inputArray.Length - 1;
                    while (x > 0)
                    {
                        if (inputArray[x] > inputArray[x - 1])
                        {
                            number1 = inputArray[x];
                            inputArray[x] = inputArray[x - 1];
                            inputArray[x - 1] = number1;
                        }
                        x--;
                    }
                }
            }

            return inputArray;
        }

        private static int[] ZicZac(int[] inputArray)
        {
            int number1;
            int inputArrayRemainingLength = inputArray.Length;
            if (inputArray.Length > 0)
            {
                for (int y = 0; y < inputArray.Length - 1; y++)
                {
                    if (y % 2 == 0)
                    {
                        int x = inputArray.Length - 1;
                        while (x > 0)
                        {
                            if (inputArray[x] < inputArray[x - 1])
                            {
                                number1 = inputArray[x];
                                inputArray[x] = inputArray[x - 1];
                                inputArray[x - 1] = number1;
                            }
                            x--;
                        }
                    }
                    else
                    {
                        int x = inputArray.Length - 1;
                        while (x > 0)
                        {
                            if (inputArray[x] > inputArray[x - 1])
                            {
                                number1 = inputArray[x];
                                inputArray[x] = inputArray[x - 1];
                                inputArray[x - 1] = number1;
                            }
                            x--;
                        }
                    }
                    inputArrayRemainingLength--;
                }
            }

            return inputArray;
        }
    }
}
