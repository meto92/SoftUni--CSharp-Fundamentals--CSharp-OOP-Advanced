using System;
using System.Linq;

public class Startup
{
    public delegate void kingBeingAttackedEventHandler(object sender, KingAttackedEventArgs args);

    public static void Main()
    {
        string kingName = Console.ReadLine();
        string[] royalGuardsNames = Console.ReadLine().Split();
        string[] footmenNames = Console.ReadLine().Split();
        
        King king = new King(kingName);

        royalGuardsNames
            .Select(name => new RoyalGuard(name))
            .ToList()
            .ForEach(king.AddSoldier);
        footmenNames
            .Select(name => new Footman(name))
            .ToList()
            .ForEach(king.AddSoldier);        

        string input = null;

        while ((input = Console.ReadLine()) != "End")
        {
            if (input == "Attack King")
            {
                king.RespondToAttack();
            }
            else
            {
                string soldierName = input.Split()[1];

                king.RemoveSoldier(soldierName);
            }
        }
    }
}