using System;
using System.Collections.Generic;

public class UnitBeingAttackedEventArgs : EventArgs
{
    private string unitName;
    private Dictionary<string, Unit> unitByName;

    public UnitBeingAttackedEventArgs(string unitName, Dictionary<string, Unit> unitByName)
    {
        this.UnitName = unitName;
        this.UnitByName = unitByName;
    }

    public string UnitName
    {
        get => this.unitName;
        private set => this.unitName = value;
    }

    public Dictionary<string, Unit> UnitByName
    {
        get => this.unitByName;
        private set => this.unitByName = value;
    }
}