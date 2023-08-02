using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortier_Algorithmen
{
    internal class SelectionSortClass//Made by following online class! Not my own code!
    {
        public static void SelectionSort(int[] arr)
        {
            int minIndex;
            int save;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                }
                if (minIndex != i)
                {
                    save = arr[minIndex];
                    arr[minIndex] = arr[i];
                    arr[i] = save;
                }
            }
        }
    }
}
