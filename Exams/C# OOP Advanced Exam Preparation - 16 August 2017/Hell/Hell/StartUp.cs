public class StartUp
{
    public static void Main()
    {
        IInputReader reader = new ConsoleReader();
        IOutputWriter writer = new ConsoleWriter();
        IHeroFactory heroFactory = new HeroFactory();
        ICommonItemFactory commonItemFactory = new CommonItemFactory();
        IRecipeFactory recipeFactory = new RecipeFactory();
        IManager manager = new HeroManager();

        Engine engine = new Engine(reader, writer, manager, heroFactory, commonItemFactory, recipeFactory);

        engine.Run();
    }
}