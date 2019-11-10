using System;
using System.Collections.Generic;

public class Handler
{
    public void OnKingAttacked(object sender, KingBeingAttackedEventArgs args)
    {
        Console.WriteLine(args.Message);
    }

    public void OnUnitBeingAttacke(object sender, UnitBeingAttackedEventArgs args)
    {
        string unitName = args.UnitName;
        Dictionary<string, Unit> unitByName = args.UnitByName;

        if (unitByName.TryGetValue(unitName, out Unit unit))
        {
            unit.TakeHit();

            if (unit.IsDead)
            {
                unitByName.Remove(unitName);
            }
        }
    }
}