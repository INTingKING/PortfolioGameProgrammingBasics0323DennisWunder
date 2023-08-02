using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortier_Algorithmen
{
    internal class MergeSortClass //Made by following online class! Not my own code!
    {
        public static void MergeSort(int[] arr)
        {
            MergeSortRecursive(arr).CopyTo(arr, 0);
        }

        private static int[] MergeSortRecursive(int[] arr)
        {
            if (arr.Length == 1)
                return arr;

            int middle = arr.Length / 2;
            int[] left = new int[middle];
            int[] right = new int[arr.Length - middle];

            for (int i = 0; i < middle; i++)
            {
                left[i] = arr[i];
                right[i] = arr[middle + i];
            }
            if (arr.Length % 2 != 0)
                right[right.Length - 1] = arr[arr.Length - 1];

            left = MergeSortRecursive(left);
            right = MergeSortRecursive(right);

            return Merge(left, right);
        }

        private static int[] Merge(int[] left, int[] right)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int[] ret = new int[left.Length + right.Length];

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] <= right[rightIndex])
                {
                    ret[leftIndex + rightIndex] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    ret[leftIndex + rightIndex] = right[rightIndex];
                    rightIndex++;
                }
            }

            while (leftIndex < left.Length)
            {
                ret[leftIndex + rightIndex] = left[leftIndex];
                leftIndex++;
            }
            while (rightIndex < right.Length)
            {
                ret[leftIndex + rightIndex] = right[rightIndex];
                rightIndex++;
            }

            return ret;
        }
    }
}
