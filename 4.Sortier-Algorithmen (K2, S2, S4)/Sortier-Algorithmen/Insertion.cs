using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortier_Algorithmen
{
    internal class Insertion
    {
        public static int[] InsertionSort(int[] inputArray)
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
            bool isOnce = true;
            int[] outputArray = new int[inputArray.Length];
            for (int y = 0; y < inputArray.Length; y++)
            {
                for (int x = 0; x < inputArray.Length; x++)
                {
                    if (inputArray[y] < outputArray[x] || 0 == outputArray[x])
                    {
                        if (isOnce)
                        {
                            outputArray[x] = inputArray[y];
                            isOnce = false;
                        }
                        else
                        {
                            for (int z = inputArray.Length - 2; z > 0; z--)
                            {
                                if (outputArray[z] != 0)
                                {
                                    outputArray[z + 1] = outputArray[z];
                                }
                                if (outputArray[z] == outputArray[x])
                                {
                                    break;
                                }
                            }
                            outputArray[x] = inputArray[y];
                        }
                        break;
                    }
                }
            }

            return outputArray;
        }

        private static int[] Fall(int[] inputArray)
        {
            bool isOnce = true;
            int[] outputArray = new int[inputArray.Length];
            for (int y = 0; y < inputArray.Length; y++)
            {
                for (int x = 0; x < inputArray.Length; x++)
                {
                    if (inputArray[y] > outputArray[x] || 0 == outputArray[x])
                    {
                        if (isOnce)
                        {
                            outputArray[x] = inputArray[y];
                            isOnce = false;
                        }
                        else
                        {
                            for (int z = inputArray.Length - 2; z > 0; z--)
                            {
                                if (outputArray[z] != 0)
                                {
                                    outputArray[z + 1] = outputArray[z];
                                }
                                if (outputArray[z] == outputArray[x])
                                {
                                    break;
                                }
                            }
                            outputArray[x] = inputArray[y];
                        }
                        break;
                    }
                }
            }

            return outputArray;
        }

        private static int[] ZicZac(int[] inputArray)
        {
            bool isOnce = true;
            int[] outputArray = new int[inputArray.Length];
            int[] newOutputArray = new int[inputArray.Length];

            if (inputArray.Length > 0)
            {
                for (int y = 0; y < inputArray.Length; y++)
                {

                    for (int x = 0; x < inputArray.Length; x++)
                    {
                        if (inputArray[y] < outputArray[x] || 0 == outputArray[x])
                        {
                            //if (isOnce)
                            //{
                            //    outputArray[x] = inputArray[y];
                            //    isOnce = false;
                            //}
                            //else
                            {
                                for (int z = inputArray.Length - 2; z > 0; z--)
                                {
                                    if (outputArray[z] != 0)
                                    {
                                        outputArray[z + 1] = outputArray[z];
                                    }
                                    if (outputArray[z] == outputArray[x])
                                    {
                                        break;
                                    }
                                }
                                outputArray[x] = inputArray[y];
                            }
                            break;
                        }
                    }
                    

                }
            }

            for (int counter = 0; counter < inputArray.Length; counter++)
            {
                inputArray[counter] = outputArray[(outputArray.Length-1) - counter];
            }
            inputArray[0] = outputArray[inputArray.Length-1];
            int counter2 = 0;
            for (int counter = 0; counter < inputArray.Length; counter++)
            {
                if (counter % 2 == 0)
                {
                    newOutputArray[counter] = inputArray[counter2];
                }
                else
                {
                    newOutputArray[counter] = outputArray[counter2];
                    counter2 += 1;
                }
            }
            return newOutputArray;

        }
    }
}
