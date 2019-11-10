using Moq;
using NUnit.Framework;

public class HeroTests
{
    private const int AxeAttackPoints = 20;
    private const int AxeDurabilityPoints = 20;
    private const int TargetHealth = 5;
    private const int TargetXP = 5;

    private class FakeWeapon : IWeapon
    {
        public int AttackPoints => AxeAttackPoints;

        public int DurabilityPoints => AxeDurabilityPoints;

        public void Attack(ITarget target)
        {
            target.TakeAttack(this.AttackPoints);
        }
    }

    private class FakeTarget : ITarget
    {
        public int Health => TargetHealth;

        public int GiveExperience() => TargetXP;

        public bool IsDead() => true;

        public void TakeAttack(int attackPoints)
        { }
    }

    [Test]
    public void HeroGainsXPWhenTargetDies()
    {
        IWeapon fakeWeapon = new FakeWeapon();
        ITarget fakeTarget = new FakeTarget();
        Hero hero = new Hero(".", fakeWeapon);

        hero.Attack(fakeTarget);

        Assert.That(hero.Experience, Is.EqualTo(TargetXP),
            "Hero didn't get XP.");
    }

    [Test]
    public void HeroGainsXPWhenTargetDiesMoq()
    {
        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
        fakeWeapon.Setup(p => p.DurabilityPoints).Returns(10);
        fakeWeapon.Setup(p => p.AttackPoints).Returns(20);
        Mock<ITarget> fakeTarget = new Mock<ITarget>();
        fakeTarget.Setup(p => p.IsDead()).Returns(true);
        fakeTarget.Setup(p => p.Health).Returns(0);
        fakeTarget.Setup(p => p.GiveExperience()).Returns(TargetXP);
        Hero hero = new Hero(".", fakeWeapon.Object);

        hero.Attack(fakeTarget.Object);

        Assert.That(hero.Experience, Is.EqualTo(TargetXP),
            "Hero didn't get XP.");
    }
}