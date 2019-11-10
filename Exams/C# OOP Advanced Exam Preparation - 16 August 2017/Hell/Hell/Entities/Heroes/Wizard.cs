public class Wizard : AbstractHero
{
    private const int WizardInitialStrength = 25;
    private const int WizardInitialAgility = 25;
    private const int WizardInitialIntelligence = 100;
    private const int WizardInitialHitPoints = 100;
    private const int WizardInitialDamage = 250;

    public Wizard(
        string name)
        : base(
            name,
            WizardInitialStrength,
            WizardInitialAgility,
            WizardInitialIntelligence,
            WizardInitialHitPoints,
            WizardInitialDamage)
    { }
}