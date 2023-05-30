using System;
using TestMindbox;
using NUnit.Framework;

namespace TestLibrary;

public class TriangleTests
{
    private double TrustedTriangleAreaCalculator(double sideA, double sideB, double sideC)
    {
        double semiPerimeter = (sideA + sideB + sideC) / 2;
        return Math.Sqrt(semiPerimeter*(semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
    }
    
    [Test]
    public void TestWrongPerimeterSides()
    {
        Assert.Throws<Exception>(() =>
        {
            Triangle wrongTriangle = new Triangle(10, 20, 30);
        });
    }
    
    [Test]
    public void TestNegativeSides()
    {
        Assert.Throws<Exception>(() =>
        {
            Triangle negativeTriangle = new Triangle(10, 20, -30);
        });
    }
    [Test]
    [TestCase(10, 20, 20, 96.824584)]
    public void ManualTestNormalSides(double sideA, double sideB, double sideC, double expected)
    {
        Triangle triangle = new Triangle(10, 20, 20);
        Assert.AreEqual(expected, triangle.Area, 0.001);
    }
    
    [Test]
    [TestCase(10, 20, 20)]
    [TestCase(5, 16, 20)]
    [TestCase(7, 13, 10)]
    public void AutomaticTestNormalSides(double sideA, double sideB, double sideC)
    {
        Triangle triangle = new Triangle(sideA, sideB, sideC);
        Assert.AreEqual(TrustedTriangleAreaCalculator(sideA, sideB, sideC), triangle.Area, 0.001);
    }

    [Test]
    [TestCase(3, 4, 5, true)]
    [TestCase(5, 16, 20, false)]
    public void RightTest(double sideA, double sideB, double sideC, bool isRight)
    {
        Triangle triangle = new Triangle(sideA, sideB, sideC);
        Assert.IsTrue(isRight == triangle.IsRight);
    }
}