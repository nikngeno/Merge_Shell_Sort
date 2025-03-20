using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Merge_Shell_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Stopwatch sw = new Stopwatch();

            Random rand = new Random();
            int[] arr = new int[20000];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(0, 20000);
            }

            int[] arr2 = new int[2000000];
            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = rand.Next(0, 2000000);
            }

            Console.WriteLine("20000 random integers");
            Console.WriteLine("---------------------");
            Console.WriteLine("");
            Console.WriteLine("Merge Sort");
            sw.Start();
            MergeSort(arr);
            sw.Stop();

            Console.WriteLine("Time taken: " + sw.Elapsed.TotalMilliseconds + "ms");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Shell Sort");
            sw.Reset();
            sw.Start();
            ShellSort(arr);
            sw.Stop();
            Console.WriteLine("Time taken: " + sw.Elapsed.TotalMilliseconds + "ms");
            Console.WriteLine("-----------------------");


            Console.WriteLine(""); 
            Console.WriteLine("");
            Console.WriteLine("########################");
            Console.WriteLine("");
            Console.WriteLine("2000000 random integers"); 
            Console.WriteLine("-----------------------");
            Console.WriteLine("");
            Console.WriteLine("Merge Sort");
            sw.Reset();
            sw.Start();
            MergeSort(arr2);
            sw.Stop();
            Console.WriteLine("Time taken: " + sw.Elapsed.TotalMilliseconds + "ms");

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Shell Sort");
            sw.Reset();
            sw.Start();
            ShellSort(arr2);
            sw.Stop();
            Console.WriteLine("Time taken: " + sw.Elapsed.TotalMilliseconds + "ms");
            Console.WriteLine("-----------------------");


        }

        public static void MergeSort(int[] arr)
        {
            int n = arr.Length;
            if (n < 2)
            {
                return;
            }
            int mid = n / 2;
            int[] left = new int[mid];
            int[] right = new int[n - mid];
            for (int i = 0; i < mid; i++)
            {
                left[i] = arr[i];
            }
            for (int i = mid; i < n; i++)
            {
                right[i - mid] = arr[i];
            }
            MergeSort(left);
            MergeSort(right);
            Merge(left, right, arr);
        }
        public static void Merge(int[] left, int[] right, int[] arr)
        {
            int nL = left.Length;
            int nR = right.Length;
            int i = 0, j = 0, k = 0;
            while (i < nL && j < nR)
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }
            while (i < nL)
            {
                arr[k] = left[i];
                i++;
                k++;
            }
            while (j < nR)
            {
                arr[k] = right[j];
                j++;
                k++;
            }
        }

        public static void ShellSort(int[] arr)
        {
            int n = arr.Length;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i += 1)
                {
                    int temp = arr[i];
                    int j;
                    for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                    {
                        arr[j] = arr[j - gap];
                    }
                    arr[j] = temp;
                }
            }
        }
    }
}
