using System;
using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private const int InitialAxeDurability = 10;
    private const int InitialAxeAttack = 20;
    private const int InitialDummyHealth = 15;
    private const int InitialDummyExperience = 25;

    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void InitializeObjects()
    {
        this.axe = new Axe(InitialAxeAttack, InitialAxeDurability);
        this.dummy = new Dummy(InitialDummyHealth, InitialDummyExperience);
    }

    [Test]
    public void AxeLoosesDurabilityAfterAttack()
    {
        this.axe.Attack(dummy);

        Assert.That(axe.DurabilityPoints, Is.EqualTo(InitialAxeDurability - 1), "Axe durability doesn't change after attack.");
    }

    [Test]
    public void AxeAttackWithBrokenWeaponShouldThrowException()
    {
        this.axe = new Axe(InitialAxeAttack, 0);

        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));

        Assert.That(ex.Message, Is.EqualTo("Axe is broken."),
            "Broken axe attacked.");

        //Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}