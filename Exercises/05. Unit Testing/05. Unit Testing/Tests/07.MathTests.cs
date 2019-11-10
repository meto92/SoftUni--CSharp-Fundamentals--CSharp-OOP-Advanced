using System;

using NUnit.Framework;

public class MathTests
{
    [TestCase(-10)]
    [TestCase(-5)]
    [TestCase(0)]
    [TestCase(5)]
    [TestCase(10)]
    public void MathAbsIntegersShouldReturnAbsoluteValue(int value)
    {
        int expectedAbsValue = value < 0 
            ? value * -1
            : value;

        Assert.That(Math.Abs(value), Is.EqualTo(expectedAbsValue),
        "Math.Abs returned incorrect value.");
    }

    [TestCase(-10.1)]
    [TestCase(-5.5)]
    [TestCase(0)]
    [TestCase(5.5)]
    [TestCase(10.1)]
    public void MathAbsDoublesShouldReturnAbsoluteValue(double value)
    {
        double expectedAbsValue = value < 0
            ? value * -1
            : value;

        Assert.That(Math.Abs(value), Is.EqualTo(expectedAbsValue),
        "Math.Abs returned incorrect value.");
    }

    [TestCase(-10.1, -11)]
    [TestCase(-5.5, -6)]
    [TestCase(0, 0)]
    [TestCase(5.5, 5)]
    [TestCase(10.1, 10)]
    public void MathFloorDoublesShouldReturnTheBiggerIntegerWhichIsEqualOrLessThanTheGivenDecimalNumber(double value, double expectedFloorValue)
    {
        Assert.That(Math.Floor(value), Is.EqualTo(expectedFloorValue),
        "Math.Floor returned incorrect value.");
    }
}