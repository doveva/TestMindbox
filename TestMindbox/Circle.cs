namespace TestMindbox;

public class Circle: IBaseFigure
{
    private readonly double _radius;
    public readonly double Area;

    public Circle(double radius)
    {
        if (radius <= 0)
        {
            throw new Exception("Radius can't be 0 or less");
        }
        _radius = radius;
        Area = GetArea();
    }

    public double GetArea()
    {
        return Math.PI * _radius * _radius ;
    }
}