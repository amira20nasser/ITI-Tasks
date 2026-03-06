using System;

namespace Lab3ITI;

class ComplexNumber
{
    private int real;
    private int imaginary;
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

    public ComplexNumber Add(ComplexNumber other)
    {
        ComplexNumber result = new ComplexNumber();
        result.Real = this.Real + other.Real;
        result.Imaginary = this.Imaginary + other.Imaginary;
        return result;
    }

    public string ToString()
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