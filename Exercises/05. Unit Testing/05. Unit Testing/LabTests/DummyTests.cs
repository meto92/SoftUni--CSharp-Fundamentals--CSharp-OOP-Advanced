using System;
using NUnit.Framework;

public class DummyTests
{
    private const int InitialDummyHealth = 15;
    private const int InitialDummyExperience = 25;
    private const int AttackPoints = 10;

    private Dummy dummy;

    [SetUp]
    public void InitializeObjects()
    {
        this.dummy = new Dummy(InitialDummyHealth, InitialDummyExperience);
    }

    [Test]
    public void DummyLosesHealthWhenAttacked()
    {
        dummy.TakeAttack(AttackPoints);

        Assert.That(dummy.Health, Is.EqualTo(InitialDummyHealth - AttackPoints), 
            "Dumy doesn't lose health after attack.");
    }

    [Test]
    public void DeadDummyShouldThrowExceptionWhenAttacked()
    {
        this.dummy = new Dummy(0, InitialDummyExperience);

        Assert.That(() => this.dummy.TakeAttack(AttackPoints), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."), 
            "Attacked dead dummy.");
    }
    
    [Test]
    public void DeadDummyShouldGiveExperience()
    {
        this.dummy = new Dummy(0, InitialDummyExperience);

        int experience = this.dummy.GiveExperience();

        Assert.That(experience > 0, "Dead dummy doesn't give experience.");
    }

    [Test]
    public void AliveDummyShouldNotGiveExperience()
    {
        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(),
            "Alive dummy gives experience.");
        //Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException);
    }
}