using System;

using NUnit.Framework;

public class DateTimeNowAddDaysTests
{
    private static class Time
    {
        public static Func<DateTime> Now = () => DateTime.Now;

        public static void SetDateTime(DateTime dateTimeNow)
        {
            Now = () => dateTimeNow;
        }
    }

    [Test]
    public void DateTimeAddingDayInTheMiddleOfMonth()
    {
        Time.SetDateTime(new DateTime(2018, 4, 15));
        DateTime fakeNow = Time.Now();
        DateTime expected = new DateTime(2018, 4, 16);

        fakeNow = fakeNow.AddDays(1);

        Assert.That(fakeNow, Is.EqualTo(expected));
    }

    [Test]
    public void DateTimeAddingDayInTheEndOfMonth()
    {
        Time.SetDateTime(new DateTime(2018, 4, 30));
        DateTime fakeNow = Time.Now();
        DateTime expected = new DateTime(2018, 5, 1);

        fakeNow = fakeNow.AddDays(1);

        Assert.That(fakeNow, Is.EqualTo(expected));
    }

    [Test]
    public void DateTimeAddingNegativeDaysInTheMiddleOfMonth()
    {
        Time.SetDateTime(new DateTime(2018, 4, 15));
        DateTime fakeNow = Time.Now();
        DateTime expected = new DateTime(2018, 4, 10);

        fakeNow = fakeNow.AddDays(-5);

        Assert.That(fakeNow, Is.EqualTo(expected));
    }

    [Test]
    public void DateTimeAddingNegativeDaysInTheBeginningOfMonthShouldGoToPrevMonth()
    {
        Time.SetDateTime(new DateTime(2018, 4, 1));
        DateTime fakeNow = Time.Now();
        DateTime expected = new DateTime(2018, 3, 31);

        fakeNow = fakeNow.AddDays(-1);

        Assert.That(fakeNow, Is.EqualTo(expected));
    }

    [Test]
    public void DateTimeAddingDayToLeapYearOn28Feb()
    {
        Time.SetDateTime(new DateTime(2016, 2, 28));
        DateTime fakeNow = Time.Now();
        DateTime expected = new DateTime(2016, 2, 29);

        fakeNow = fakeNow.AddDays(1);

        Assert.That(fakeNow, Is.EqualTo(expected));
    }

    [Test]
    public void DateTimeAddingDayToNonLeapYearOn28Feb()
    {
        Time.SetDateTime(new DateTime(2018, 2, 28));
        DateTime fakeNow = Time.Now();
        DateTime expected = new DateTime(2018, 3, 1);

        fakeNow = fakeNow.AddDays(1);

        Assert.That(fakeNow, Is.EqualTo(expected));
    }

    [Test]
    public void DateTimeAddingDayToDateTimeMinValue()
    {
        Time.SetDateTime(DateTime.MinValue);
        DateTime fakeNow = Time.Now();
        DateTime expected = new DateTime(1, 1, 2);

        fakeNow = fakeNow.AddDays(1);

        Assert.That(fakeNow, Is.EqualTo(expected));
    }

    [Test]
    public void DateTimeAddingDayToDateTimeMaxValueShouldThrowException()
    {
        Time.SetDateTime(DateTime.MaxValue);
        DateTime fakeNow = Time.Now();

        Assert.Throws<ArgumentOutOfRangeException>(
            () => fakeNow.AddDays(1));
    }
}