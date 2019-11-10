using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Lake : IEnumerable<int>
{
    private int[] stones;

    public Lake(IEnumerable<int> stones)
    {
        this.stones = stones.ToArray();
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    public IEnumerator<int> GetEnumerator()
    {
        int stonesCount = this.stones.Length;

        for (int i = 0; i < stonesCount; i += 2)
        {
            yield return this.stones[i];
        }

        int lastOddIndex = stonesCount % 2 == 0
            ? stonesCount - 1
            : stonesCount - 2;

        for (int i = lastOddIndex; i >= 0; i -= 2)
        {
            yield return this.stones[i];
        }
    }
}