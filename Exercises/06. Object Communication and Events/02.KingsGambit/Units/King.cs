using static Startup;
using System.Collections.Generic;

public class King : Unit
{
    private const string KingOnBeingAttackedMessage = "King {0} is under attack!";

    private event kingBeingAttackedEventHandler KingBeingAttacked;

    private Handler handler;
    private Dictionary<string, Unit> soldierByName;

    public King(string name)
        : base(name)
    {
        this.handler = new Handler();
        this.soldierByName = new Dictionary<string, Unit>();
        this.KingBeingAttacked += handler.OnKingAttacked;
    }

    public void AddSoldier(Unit unit)
    {
        this.soldierByName[unit.Name] = unit;
    }

    public void RemoveSoldier(string unitName)
    {
        this.soldierByName.Remove(unitName);
    }

    public void RespondToAttack()
    {
        this.KingBeingAttacked(this, new KingAttackedEventArgs(MessageOnKingAttacked));

        foreach (Unit unit in this.soldierByName.Values)
        {
            this.KingBeingAttacked(unit, new KingAttackedEventArgs(unit.MessageOnKingAttacked));
        }
    }

    public override string MessageOnKingAttacked => string.Format(
        KingOnBeingAttackedMessage,
        base.Name);
}