namespace Lab3ITI;

class Line
{
    Point p1;
    Point p2;
    public Line()
    {
        p1 = new Point();
        p2 = new Point();
    }
    public Line(int x1, int y1, int x2, int y2)
    {
        p1 = new Point(x1, y1);
        p2 = new Point(x2, y2);
    }
}


class Rect
{
    Point p1 = new Point();
    Point p2 = new Point();

    public Rect(int x1, int y1, int x2, int y2)
    {
        p1.X = x1;
        p1.Y = y1;
        p2.X = x2;
        p2.Y = y2;
    }
}