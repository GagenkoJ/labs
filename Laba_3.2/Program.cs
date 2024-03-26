Point point1 = new Point(0, 0, "A");
Point point2 = new Point(3, 0, "B");
Point point3 = new Point(3, 4, "C");
//Point point4 = new Point(0, 4, "D");
Figure figure = new Figure(point1, point2, point3);
figure.WriteName();
figure.PerimeterCalculator();

class Point
{
    public int X { get;  }
    public int Y { get;  }
    public string Delta { get;  }

    public Point(int x, int y, string delta)
    {
        X = x;
        Y = y;
        Delta = delta;

    }
}

class Figure
{
    private Point[] myFigure;
    
    public Figure(Point point1, Point point2, Point point3, Point point4, Point point5)
    {
        myFigure = new[] { point1, point2, point3, point4, point5 };
    }
    public Figure(Point point1, Point point2, Point point3, Point point4)
    {
        myFigure = new[] { point1, point2, point3, point4};
    }
    public Figure(Point point1, Point point2, Point point3)
    {
        myFigure = new[] { point1, point2, point3};
    }

    private double LengthSide(Point A, Point B)
    {
        return Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
    }

    public void PerimeterCalculator()
    {
        double P = 0;
        for (int i = 0; i < myFigure.Length - 1; i++)
        {
            P += LengthSide(myFigure[i], myFigure[i + 1]);
        }
        P += LengthSide(myFigure[myFigure.Length - 1], myFigure[0]);
        Console.WriteLine($"Периметр трикутника: {P}");
    }

    public void WriteName()
    {
        
        Console.Write("Трикутник ");
        for (int i = 0; i < myFigure.Length; i++)
        {
            Console.Write(myFigure[i].Delta);
        }
        Console.WriteLine();
    }
}

