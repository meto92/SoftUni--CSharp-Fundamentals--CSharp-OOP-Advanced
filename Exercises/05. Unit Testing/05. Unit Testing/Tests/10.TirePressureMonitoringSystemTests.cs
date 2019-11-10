using Moq;
using NUnit.Framework;

public class TirePressureMonitoringSystemTests
{
    [TestCase(0)]
    [TestCase(15)]
    [TestCase(16.99)]
    public void LowPressureTireShouldActivateAlarm(double tirePressure)
    {
        Mock<ISensor> fakeSensor = new Mock<ISensor>();
        fakeSensor.Setup(p => p.PopNextPressurePsiValue())
            .Returns(tirePressure);
        IAlarm alarm = new Alarm(fakeSensor.Object);

        alarm.Check();

        Assert.That(alarm.AlarmOn, Is.EqualTo(true),
            "Low pressure tire didn't acitvate alarm.");
    }

    [TestCase(17)]
    [TestCase(19)]
    [TestCase(21)]
    public void MormalPressureTireShouldNotActivateAlarm(double tirePressure)
    {
        Mock<ISensor> fakeSensor = new Mock<ISensor>();
        fakeSensor.Setup(p => p.PopNextPressurePsiValue())
            .Returns(tirePressure);
        IAlarm alarm = new Alarm(fakeSensor.Object);

        alarm.Check();

        Assert.That(alarm.AlarmOn, Is.EqualTo(false),
            "Normal pressure tire acitvated alarm.");
    }

    [TestCase(21.01)]
    [TestCase(25)]
    [TestCase(30)]
    public void HighPressureTireShouldActivateAlarm(double tirePressure)
    {
        Mock<ISensor> fakeSensor = new Mock<ISensor>();
        fakeSensor.Setup(p => p.PopNextPressurePsiValue())
            .Returns(tirePressure);
        IAlarm alarm = new Alarm(fakeSensor.Object);

        alarm.Check();

        Assert.That(alarm.AlarmOn, Is.EqualTo(true),
            "High pressure tire didn't acitvate alarm.");
    }
}