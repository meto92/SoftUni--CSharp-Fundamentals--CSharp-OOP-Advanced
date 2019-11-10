using static Startup;
using System.Collections.Generic;

public class King : Unit
{
    private const string KingOnAttackedMessage = "King {0} is under attack!";

    private event kingBeingAttackedEventHandler KingAttacked;
    private event UnitBeingAttackedEventHandler UnitBeingAttacked;

    private Handler handler;
    private Dictionary<string, Unit> soldierByName;

    public King(string name)
        : base(name, int.MaxValue)
    {
        this.handler = new Handler();
        this.soldierByName = new Dictionary<string, Unit>();
        this.KingAttacked += handler.OnKingAttacked;
        this.UnitBeingAttacked += this.handler.OnUnitBeingAttacke;
    }

    public void AddSoldier(Unit unit)
    {
        this.soldierByName[unit.Name] = unit;
    }

    public void UnitTakeAttack(string unitName)
    {
        this.UnitBeingAttacked(this, new UnitBeingAttackedEventArgs(unitName, this.soldierByName));
    }

    public void RespondToAttack()
    {
        this.KingAttacked(this, new KingBeingAttackedEventArgs(MessageOnKingAttacked));

        foreach (Unit unit in this.soldierByName.Values)
        {
            this.KingAttacked(unit, new KingBeingAttackedEventArgs(unit.MessageOnKingAttacked));
        }
    }

    public override string MessageOnKingAttacked => string.Format(
        KingOnAttackedMessage,
        base.Name);
}