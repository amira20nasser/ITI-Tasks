
namespace Lab6ITI;

class GeoShape
{
    protected double dim1, dim2;
    public GeoShape(double _dim1, double _dim2)
    {
        dim1 = _dim1;
        dim2 = _dim2;
    }
    protected void setDim1(double _dim1) => dim1 = _dim1;
    protected void setDim2(double _dim1) => dim1 = _dim1;
}

class Rectangle : GeoShape
{
    public Rectangle(double _dim1, double _dim2) : base(_dim1, _dim2) { }

    public double Area() => dim1 * dim2;
}



class Sqaure : GeoShape
{
    public Sqaure(double _dim1) : base(_dim1, _dim1) { }

    public double Area() => dim1 * dim2;
}