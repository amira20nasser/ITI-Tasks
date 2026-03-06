namespace Lab3ITI;

class Tri
{
    Point p1;
    Point p2;
    Point p3;
    public Tri()
    {
        p1 = null;
        p2 = null;
        p3 = null;
    }
    public Tri(Point p1, Point p2, Point p3)
    {
        this.p1 = p1;
        this.p2 = p2;
        this.p3 = p3;
    }
}

class Cir
{
    Point p1;
    double diameter;
    public Cir()
    {
        p1 = null;
        diameter = 0;

    }
    public Cir(Point p1, double diameter)
    {
        this.p1 = p1;
        this.diameter = diameter;
    }
}