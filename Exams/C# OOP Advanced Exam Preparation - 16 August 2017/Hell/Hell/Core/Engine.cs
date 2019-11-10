using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

public class Engine
{
    private IInputReader reader;
    private IOutputWriter writer;
    private IManager heroManager;
    private IHeroFactory heroFactory;
    private ICommonItemFactory commonItemFactory;
    private IRecipeFactory recipeFactory;

    public Engine(
        IInputReader reader,
        IOutputWriter writer,
        IManager manager,
        IHeroFactory heroFactory,
        ICommonItemFactory commonItemFactory,
        IRecipeFactory recipeFactory)
    {
        this.reader = reader;
        this.writer = writer;
        this.heroManager = manager;
        this.heroFactory = heroFactory;
        this.commonItemFactory = commonItemFactory;
        this.recipeFactory = recipeFactory;
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            string inputLine = this.reader.ReadLine().Trim();
            List<string> arguments = this.ParseInput(inputLine);
            this.writer.WriteLine(this.ProcessInput(arguments));
            isRunning = !this.ShouldEnd(inputLine);
        }
    }

    private List<string> ParseInput(string input)
    {
        return input.Split().ToList();
    }

    private void InjectFields(ICommand command)
    {
        FieldInfo[] fieldsToInject = command.GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(f => f.CustomAttributes.
                Any(a => a.AttributeType == typeof(InjectAttribute)))
            .ToArray();

        foreach (FieldInfo field in fieldsToInject)
        {
            field.SetValue(command,
                this.GetType()
                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .First(f => f.FieldType == field.FieldType)
                    .GetValue(this));
        }
    }

    private string ProcessInput(List<string> arguments)
    {
        string command = arguments[0];
        arguments.RemoveAt(0);

        Type commandType = Type.GetType(command + "Command");
        var constructor = commandType.GetConstructor(new Type[] { typeof(IList<string>), typeof(IManager) });

        ICommand cmd = (ICommand) constructor.Invoke(new object[] { arguments, this.heroManager });

        InjectFields(cmd);

        return cmd.Execute();
    }

    private bool ShouldEnd(string inputLine)
    {
        return inputLine.Equals("Quit");
    }
}