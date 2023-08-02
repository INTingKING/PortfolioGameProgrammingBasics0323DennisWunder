using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Sortier_Algorithmen
{
    internal class Program : RandomListAutomated
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You are in a sorting algorythm program, press enter to continue");
            Console.ReadKey(true);
            while (true)
            {
                int[] randomNumberArray;
                int whoCreatesRandomNumberList = 0;
                while (whoCreatesRandomNumberList != 1 && whoCreatesRandomNumberList != 2)
                {
                    Console.Clear();
                    Console.WriteLine(
                        "Do you want to generate a random number yourself?\n(Yes - 1 / No - 2)"
                    );
                    int.TryParse(Console.ReadLine(), out whoCreatesRandomNumberList);
                }

                {
                    //switch (whoCreatesRandomNumberList)
                    //{
                    //    case 1:
                    //        randomNumberArray = makeRandomList();
                    //        Console.Clear();
                    //        Console.WriteLine("The List has been created:");
                    //        for (int i = 0; i < randomNumberArray.Length; i++)
                    //        {
                    //            Console.WriteLine(randomNumberArray.GetValue(i));
                    //        }
                    //        break;
                    //    case 2:
                    //        randomNumberArray = randomList();
                    //        Console.Clear();
                    //        Console.WriteLine("The List has been created:");
                    //        for (int i = 0; i < randomNumberArray.Length; i++)
                    //        {
                    //            Console.WriteLine(randomNumberArray.GetValue(i));
                    //        }
                    //        break;
                    //}
                    //doesn't work because program thinks that it is possible that non of these cases happen(it's guaranteed based on the function above this one)
                } //didn't work

                if (whoCreatesRandomNumberList == 1)
                {
                    randomNumberArray = Sortier_Algorithmen.RandomListManual.MakeRandomList();
                    Console.Clear();
                }
                else
                {
                    randomNumberArray = Sortier_Algorithmen.RandomListAutomated.RandomListMaker();
                    Console.Clear();
                }

                Console.WriteLine("The List has been created");
                ShowArray(randomNumberArray);

                Console.WriteLine("Press any Button to contue...");
                Console.ReadKey(true);

                {
                    //BubbleSotrtClass.BubbleSort(randomNumberArray);
                    //SelectionSortClass.SelectionSort(randomNumberArray);
                    //MergeSortClass.MergeSort(randomNumberArray);
                } //sorters from OVL

                ConsoleClearAll();

                Console.WriteLine(
                    "Which sorter do you want to use?\n    Bubble - 1\n    Search - 2\n    Insertion - 3\n(Choose by typing a number(1/2/3))"
                );
                string stringInput = Console.ReadLine();
                while (stringInput != "1" && stringInput != "2" && stringInput != "3")
                {
                    stringInput = Console.ReadLine();
                }
                int.TryParse(stringInput, out int intOutput);

                ConsoleClearAll();

                int[] sortedArray = randomNumberArray;
                switch (intOutput)
                {
                    case 1:
                        sortedArray = BubbleClass.BubbleSort(randomNumberArray);
                        break;
                    case 2:
                        sortedArray = SearchClass.SearchSort(randomNumberArray);
                        break;
                    case 3:
                        sortedArray = Insertion.InsertionSort(randomNumberArray);
                        break;
                }

                ConsoleClearAll();

                Console.WriteLine("The List has been sorted");
                ShowArray(sortedArray);
                Console.ReadKey(true);
                int restartProgram = 0;
                while (restartProgram != 1 && restartProgram != 2)
                {
                    Console.Clear();
                    Console.WriteLine("Restart the program?\n(Yes - 1 / No - 2)");
                    int.TryParse(Console.ReadLine(), out restartProgram);
                }
                if (restartProgram == 2)
                {
                    break;
                }
            }
            Console.WriteLine("Program is now closing");
            Console.ReadKey(true);
        }

        private static void ShowArray(int[] randomNumberArray)
        {
            string showArray = "[";

            for (int i = 0; i < randomNumberArray.Length; i++)
            {
                showArray += randomNumberArray[i] + ",";
            }
            showArray = showArray.Substring(0, showArray.Length - 1);
            showArray += "]";

            Console.WriteLine(showArray);
        }

        public static void ConsoleClearAll()
        {
            Console.Clear();
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("\x1b[3J");
            Console.Clear();
        }
    }
}
