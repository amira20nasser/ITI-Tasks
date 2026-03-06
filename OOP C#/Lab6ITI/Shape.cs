namespace Lab6ITI;

abstract class Shape
{
    public abstract double Area();
}

class Triangle : Shape
{
    double height, baseLength;
    public Triangle()
    {
        height = baseLength = 0;

    }
    public Triangle(double _height, double _baseLength)
    {
        height = _height;
        baseLength = _baseLength;

    }
    public override double Area()
    {
        return 0.5 * height * baseLength;
    }
}

class Circle : Shape
{
    double diameter;
    public Circle(double _diameter)
    {
        diameter = _diameter;
    }
    public override double Area()
    {
        return Math.PI * diameter * diameter;
    }
}