namespace Lab1ITI;

class Program
{
    static void Main(string[] args)
    {
        var today = DateTime.Today;
        Console.WriteLine($"Today is: {today}");
        Console.WriteLine($"add one day: {today.AddDays(1)}");

        Console.Write("Enter birth day: ");
        int day = int.Parse(Console.ReadLine());

        Console.Write("Enter birth month: ");
        int month = int.Parse(Console.ReadLine());

        Console.Write("Enter birth year: ");
        int year = int.Parse(Console.ReadLine());

        DateTime birthDate;
        birthDate = new DateTime(year, month, day);

        if (birthDate > today)
        {
            Console.WriteLine("Birth date cannot be in the future");
            return;
        }

        int age = today.Year - birthDate.Year;

        // if (birthDate > today.AddYears(-age))
        // {
        //     age--;
        // }

        int months = (today.Month - birthDate.Month + 12) % 12;
        // if (birthDate.Month > today.AddMonths(-months).Month)
        // {
        //     months--;
        // }
        int days = (today.Day - birthDate.Day + 30) % 30;
        // if (birthDate.Day > today.AddMonths(-days).Day)
        // {
        //     days--;
        // }
        Console.WriteLine($"You are {age} years, {months} months, {days} days old.");
    }
}

