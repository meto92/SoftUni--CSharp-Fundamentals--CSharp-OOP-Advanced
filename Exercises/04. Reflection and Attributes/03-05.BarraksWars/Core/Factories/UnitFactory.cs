using System;

public class UnitFactory : IUnitFactory
{
    public IUnit CreateUnit(string unitType)
    {
        Type type = Type.GetType(unitType);

        IUnit unit = Activator.CreateInstance(type) as IUnit;

        return unit;
    }
}