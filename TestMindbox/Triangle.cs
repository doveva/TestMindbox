namespace TestMindbox;

public class Triangle : IBaseFigure
{
    private const double Precision = 0.0001;

    private readonly double _sideA;
    private readonly double _sideB;
    private readonly double _sideC;

    public readonly bool IsRight;
    public readonly double Area;


    public Triangle(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 | sideB <= 0 | sideC <= 0)
        {
            throw new Exception("Side values should be more than 0");
        }

        if (sideA >= sideB + sideC | sideB >= sideA + sideC | sideC >= sideA + sideB)
        {
            throw new Exception("Side values should be more less than sum of other 2");
        }

        _sideA = sideA;
        _sideB = sideB;
        _sideC = sideC;

        IsRight = IsRightWithThreeSides(new List<double> { sideA, sideB, sideC });
        Area = GetArea();
    }

    private bool IsRightWithThreeSides(List<double> sides)
    {
        if (sides.Count != 3)
        {
            throw new Exception("You should gave a List with 3 sides");
        }

        double maxSide = sides.Max();
        sides.Remove(maxSide);
        if (maxSide - Math.Sqrt(sides[0] * sides[0] + sides[1] * sides[1]) < Precision)
        {
            return true;
        }
        return false;
    }
    public double GetArea()
    {
        double semiPerimeter = (_sideA + _sideB + _sideC) / 2;
        return Math.Sqrt(semiPerimeter * (semiPerimeter - _sideA) * (semiPerimeter - _sideB) * (semiPerimeter - _sideC));
    }
}

