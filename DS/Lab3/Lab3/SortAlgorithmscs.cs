using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    internal class SortAlgorithmscs<T> where T : IComparable<T>
    {
        public static void BubbleSort(T[] arr)
        {
            // worst , best case is O(n^2)
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        T temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
    }
}