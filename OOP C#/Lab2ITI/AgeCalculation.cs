using System;

public class AgeCalculation
{
    public static void Run()
    {
        int year, month, day;
        do
        {
            Console.Write("Please enter your year (1980–2025): ");
            year = int.Parse(Console.ReadLine());
        } while (year < 1980 || year > 2025);

        do
        {
            Console.Write("Please enter your month (1–12): ");
            month = int.Parse(Console.ReadLine());
        } while (month < 1 || month > 12);

        int maxDays = GetDaysInMonth(month, year);
        do
        {
            Console.Write("Please enter your day: ");
            day = int.Parse(Console.ReadLine());
        } while (day < 1 || day > maxDays || day != GetDaysInMonth(month, year));


        DateTime today = DateTime.Today;

        int years = today.Year - year;
        int months = today.Month - month;
        int days = today.Day - day;

        if (days < 0)
        {
            months--;
            int prevMonth = today.Month - 1;
            if (prevMonth == 0)
            {
                prevMonth = 12;
            }
            days += GetDaysInMonth(prevMonth, today.Year);
        }

        if (months < 0)
        {
            years--;
            months += 12;
        }

        Console.WriteLine($"You're {years} years, {months} months, and {days} days old.");
    }

    static int GetDaysInMonth(int month, int year)
    {
        switch (month)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                return 31;
            case 4:
            case 6:
            case 9:
            case 11:
                return 30;
            case 2:
                return IsLeapYear(year) ? 29 : 28;
            default:
                return 0;
        }
    }

    static bool IsLeapYear(int year)
    {
        return year % 4 == 0;
    }
}
