using System;
using TestMindbox;
using NUnit.Framework;

namespace TestLibrary;

public class CircleTest
{
    private double TrustedCircleAreaCalculator(double radius)
    {
        return Math.PI * radius * radius ;
    }
    
    
    [Test]
    public void NegativeRadius()
    {
        Assert.Throws<Exception>(() =>
        {
            Circle wrongCircle = new Circle(-10);
        });
    }
    
    [Test]
    public void ZeroRadius()
    {
        Assert.Throws<Exception>(() =>
        {
            Circle wrongCircle = new Circle(0);
        });
    }
    
    [Test]
    public void ManualCorrectRadius()
    {
        double expected = 314.1592653589793;
        Circle circle = new Circle(10);
        Assert.AreEqual(expected, circle.Area, 0.001);
    }
    
    [Test]
    [TestCase(10)]
    [TestCase(20)]
    [TestCase(1724)]
    public void AutomaticCorrectRadius(double radius)
    {
        Circle circle = new Circle(radius);
        Assert.AreEqual(TrustedCircleAreaCalculator(radius), circle.Area, 0.001);
    }
}