using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortier_Algorithmen
{
    internal class BubbleSotrtClass//Made by following online class! Not my own code!
    {
        public static void BubbleSort(int[] arr)
        {
            int save;
            for (int i = arr.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        save = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = save;
                    }
                }
            }
        }
    }
}
