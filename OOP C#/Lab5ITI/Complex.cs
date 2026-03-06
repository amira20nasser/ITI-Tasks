using System;

namespace Lab5ITI;

class ComplexNumber
{
    private int real;
    private int imaginary;
    private static int count = 0;
    public ComplexNumber()
    {
        count++;
        this.real = 0;
        this.imaginary = 0;
    }
    public ComplexNumber(int real, int imaginary)
    {
        count++;
        this.real = real;
        this.imaginary = imaginary;
    }

    public static int Count() => count;

    public int Real
    {
        get { return real; }
        set { real = value; }
    }
    public int Imaginary
    {
        get { return imaginary; }
        set { imaginary = value; }
    }


    public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
    {
        int real = c1.real + c2.real;
        int imaginary = c1.imaginary + c2.imaginary;
        return new ComplexNumber(real, imaginary);
    }
    public static ComplexNumber operator +(ComplexNumber c1, int real)
    {
        int realResult = c1.real + real;
        return new ComplexNumber(realResult, c1.imaginary);
    }

    public static ComplexNumber operator +(int real, ComplexNumber c1)
    {
        int realResult = c1.real + real;
        return new ComplexNumber(realResult, c1.imaginary);
    }

    public static bool operator ==(ComplexNumber c1, ComplexNumber c2)
    {
        bool equalReal = c1.real == c2.real;
        bool equalImaginary = c1.real == c2.real;
        return equalReal && equalImaginary;
    }

    public static bool operator !=(ComplexNumber c1, ComplexNumber c2)
    {
        bool equalReal = c1.real != c2.real;
        bool equalImaginary = c1.real != c2.real;
        return equalReal && equalImaginary;
    }
    public override string ToString()
    {

        // switch (Imaginary)
        // {
        //     case > 0:
        //         if (Imaginary == 1)
        //         {
        //             if (Real == 0)
        //             {
        //                 return "i";
        //             }
        //             return $"{Real} + i";
        //         }
        //         if (Real == 0)
        //         {
        //             return $"{Imaginary}i";
        //         }
        //         return $"{Real} + {Imaginary}i";
        //     case < 0:
        //         if (Imaginary == -1)
        //         {
        //             if (Real == 0)
        //             {
        //                 return "-i";
        //             }
        //             return $"{Real} - i";
        //         }
        //         if (Real == 0)
        //         {
        //             return $"{Imaginary}i";
        //         }
        //         return $"{Real} {Imaginary}i";
        //     default:
        //         return $"{Real}";
        // }

        if (imaginary == 0)
        {
            return $"{real}";
        }
        if (Real == 0)
        {
            return imaginary == 1 ? "i" : imaginary == -1 ? "-i" : $"{imaginary}i";
        }
        string signedImaginary = imaginary > 0 ? imaginary == 1 ? "+i" : $"+{imaginary}i" :
        imaginary == -1 ? "-i" : $"{imaginary}i";

        return $"{real}{signedImaginary}";


    }

}