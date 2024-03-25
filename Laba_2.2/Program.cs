Triangle triangle = new Triangle(2, 3, 4);
string x = triangle.WhichIsTriangle();
Console.WriteLine("Ваш трикутник " + x);
Console.WriteLine("P: " + triangle.TriangleP());
Console.WriteLine("S: " + triangle.TriangleArea());

class Triangle
{
    public int SideA;
    public int SideB;
    public int SideC;
    public Triangle(int a, int b, int c)
    {
        if (ItIsTriangle(a, b, c))
        {
            SideA = a;
            SideB = b;
            SideC = c;
        }
        else
        {
            Console.WriteLine("fuck");
        }
    }
    
    private bool ItIsTriangle(int a, int b, int c)
    {

        bool x = (a + b > c && a + c > b && c + b > a) ? true : false;
        return x;
    }

    public string WhichIsTriangle ()//(int sideA, int sideB, int sideC)
    {
        string whichIsTriangl;
        int A = SideA;
        int B = SideB;
        int C = SideC;
        bool b = (SideA == SideB && SideB != C);
        bool c = (SideA == SideC && SideB != C);
        bool a = (SideB == SideC && SideB != A);
        if (a == b == c)
        {
            whichIsTriangl = "Рівносторонній";
        }
        else if (a || b || c)// ((a == b != c) || (a == c != b) || (b == c != a))
        {
            whichIsTriangl = "рівнобедрений";
        }
        else
        {
            whichIsTriangl = "різнобічний";
        }
        return whichIsTriangl;
    }

    public double TriangleP()
    {
        double P = SideA + SideB + SideC;
        return P;
    }

    public double TriangleArea()
    {
        double p = TriangleP() / 2;
        double area = Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        return area;
    }
}