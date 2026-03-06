using System;
namespace Lab2ITI;

public class Program1D
{
    private static int[] readArrayFromUser(int size)
    {
        int[] arr = new int[size];
        Console.WriteLine($"Enter {size} integers:");
        for (int i = 0; i < size; i++)
        {
            Console.Write($"Element {i + 1}: ");
            arr[i] = int.Parse(Console.ReadLine());
        }
        return arr;
    }
    private static void finMaxMin(int[] arr)
    {
        int min = arr[0];
        int max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < min)
                min = arr[i];
            if (arr[i] > max)
                max = arr[i];
        }
        Console.WriteLine($"Min Value: {min}, Max Value: {max}");
    }
    private static void SortArray(int[] arr)
    {
        bool swapped;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {

                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = true;
                }
                if (!swapped)
                    break;
            }
        }
        Console.WriteLine("Sorted Array: " + string.Join(", ", arr));
    }

    private static void SearchIndexOfNumber(int[] arr, int number)
    {
        int length = arr.Length;
        for (int i = 0; i < length; i++)
        {
            if (arr[i] == number)
            {
                Console.WriteLine($"Number {number} found at index: {i}");
                return;
            }
        }
        Console.WriteLine($"Number {number} is not found ");
        return;
    }

    public static void Run()
    {
        char choice;
        do
        {
            Console.WriteLine("******************Menu******************");
            Console.WriteLine("1- array of 10 intergers and get min and max value");
            Console.WriteLine("2- array of 10 integers and sort it ascending without any built in function");
            Console.WriteLine("3- search for a number in an array of 10 integers and return its index");
            Console.WriteLine("q- to quit");
            Console.WriteLine("Enter your choice:");
            choice = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (choice)
            {
                case '1':
                    var arr1 = readArrayFromUser(10);
                    finMaxMin(arr1);
                    break;
                case '2':
                    var arr2 = readArrayFromUser(10);
                    SortArray(arr2);
                    break;
                case '3':
                    var arr3 = readArrayFromUser(10);
                    Console.WriteLine("Enter number to search:");
                    var number = int.Parse(Console.ReadLine());
                    SearchIndexOfNumber(arr3, number);
                    break;
                case 'q':
                    Console.WriteLine("Exiting the program.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        } while (choice != 'q');
    }

}