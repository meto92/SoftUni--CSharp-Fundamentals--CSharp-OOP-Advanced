using System;

public class Startup
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

    public static void Main()
    {
        Handler handler = new Handler();
        Dispatcher dispatcher = new Dispatcher();

        dispatcher.NameChange += handler.OnDispatcherNameChange;

        string name = null;

        while ((name = Console.ReadLine()) != "End")
        {
            dispatcher.Name = name;
        }
    }
}