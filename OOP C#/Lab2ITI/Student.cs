using System;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
namespace Lab2ITI;

public class Student
{
    private int id;
    private string name;
    private double gpa;

    public int Id
    {
        get { return id; }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("! You set the value in Negative !!!");
                return;
            }
            id = value;
        }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public double GPA
    {

        get
        {

            return gpa;
        }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("! Invalid VALUE!!!");
                return;
            }
            gpa = value;
        }
    }
    public string ToString()
    {
        return $"The Student {name} with #{id} and GPA {gpa}";
    }
}