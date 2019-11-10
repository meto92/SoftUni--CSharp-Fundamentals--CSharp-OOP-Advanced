public class TupleFactory
{
    public Tuple<T1, T2> CreateTuple<T1, T2>(T1 item1, T2 item2)
    {
        return new Tuple<T1, T2>(item1, item2);
    }

    public Threeuple<T1, T2, T3> CreateTuple<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
    {
        return new Threeuple<T1, T2, T3>(item1, item2, item3);
    }
}