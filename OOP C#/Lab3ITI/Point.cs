using System;

namespace Lab3ITI;

class Point
{
    int x, y;
    public Point()
    {
        x = y = 0;
    }
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int X
    {
        get { return x; }
        set { y = value; }
    }
    public int Y
    {
        get { return y; }
        set { y = value; }
    }
}