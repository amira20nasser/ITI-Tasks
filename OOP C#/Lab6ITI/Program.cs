namespace Lab6ITI;

class Program
{
    static double sum(Shape[] shapes)
    {
        double total = 0;
        for (int i = 0; i < shapes.Length; i++)
        {
            total += shapes[i].Area();
        }
        return total;

    }


    static double sum(Triangle[] tris, Circle[] cs)
    {
        double total = 0;
        for (int i = 0; i < tris.Length; i++)
        {
            total += tris[i].Area();
        }
        for (int i = 0; i < cs.Length; i++)
        {
            total += cs[i].Area();
        }
        return total;
    }
    static void Main(string[] args)
    {
        int[] arr = { 1, 2 };
        int[] arr2 = { 1, 2, 3 };
        arr = arr2;
        Console.WriteLine(arr.Length); // Output: 3
        Console.WriteLine(arr2.Length); // Output: 3

        arr = new int[] { 4, 5, 6, 7, 8 };
        Console.WriteLine(arr.Length); // Output: 5
        Console.WriteLine(arr2.Length); // Output: 3

    }
}
