using System;

public class Handler
{
    public void OnKingAttacked(object sender, KingAttackedEventArgs args)
    {
        Console.WriteLine(args.Message);
    }
}