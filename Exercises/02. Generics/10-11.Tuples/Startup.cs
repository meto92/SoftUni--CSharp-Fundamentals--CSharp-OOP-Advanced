using System;

public class Startup
{
    private static string[] ReadTupleItems()
    {
        return Console.ReadLine()
            .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
    }

    private static void TestTuples(TupleFactory tupleFactory)
    {
        string[] firstTupleItems = ReadTupleItems();
        string[] secondTupleItems = Console.ReadLine().Split();
        string[] thirdTupleItems = ReadTupleItems();

        string firstTuplePersonName = $"{firstTupleItems[0]} {firstTupleItems[1]}";
        string firstTuplePersonAddress = firstTupleItems[2];

        string secondTuplePersonName = secondTupleItems[0];
        int secondTupleBeerLitersPersonCanDrink = int.Parse(secondTupleItems[1]);

        int thirdTupleInteger = int.Parse(thirdTupleItems[0]);
        double thisrTupleDouble = double.Parse(thirdTupleItems[1]);

        Tuple<string, string> firstTuple =
            tupleFactory.CreateTuple(firstTuplePersonName, firstTuplePersonAddress);
        Tuple<string, int> secondTuple =
            tupleFactory.CreateTuple(
                secondTuplePersonName,
                secondTupleBeerLitersPersonCanDrink);
        Tuple<int, double> thirdTuple =
            tupleFactory.CreateTuple(thirdTupleInteger, thisrTupleDouble);

        Console.WriteLine(firstTuple);
        Console.WriteLine(secondTuple);
        Console.WriteLine(thirdTuple);
    }

    private static void TestThreeuples(TupleFactory tupleFactory)
    {
        string[] firstThreeupleItems = ReadTupleItems();
        string[] secondThreeupleItems = ReadTupleItems();
        string[] thirdThreeupleItems = ReadTupleItems();

        string firstThreeuplePersonName = $"{firstThreeupleItems[0]} {firstThreeupleItems[1]}";
        string firstThreeuplePersonAddress = firstThreeupleItems[2];
        string firstThreeuplePersonTown = firstThreeupleItems[3];

        string secondThreeuplePersonName = secondThreeupleItems[0];
        int secondThreeupleBeerLitersPersonCanDrink = int.Parse(secondThreeupleItems[1]);
        bool secondThreeupleIsPersonDrunk = secondThreeupleItems[2].ToUpper() == "DRUNK";

        string thirdThreeuplePersonName = thirdThreeupleItems[0];
        double thirdThreeupleBalance = double.Parse(thirdThreeupleItems[1]);
        string thirdThreeupleBankName = thirdThreeupleItems[2];

        Threeuple<string, string, string> firstThreeuple =
            tupleFactory.CreateTuple(
                firstThreeuplePersonName,
                firstThreeuplePersonAddress,
                firstThreeuplePersonTown);
        Threeuple<string, int, bool> secondThreeuple =
            tupleFactory.CreateTuple(
                secondThreeuplePersonName,
                secondThreeupleBeerLitersPersonCanDrink,
                secondThreeupleIsPersonDrunk);
        Threeuple<string, double, string> thirdThreeuple =
            tupleFactory.CreateTuple(
                thirdThreeuplePersonName,
                thirdThreeupleBalance,
                thirdThreeupleBankName);

        Console.WriteLine(firstThreeuple);
        Console.WriteLine(secondThreeuple);
        Console.WriteLine(thirdThreeuple);
    }

    public static void Main()
    {
        TupleFactory tupleFactory = new TupleFactory();

        TestTuples(tupleFactory);
        //TestThreeuples(tupleFactory);
    }
}