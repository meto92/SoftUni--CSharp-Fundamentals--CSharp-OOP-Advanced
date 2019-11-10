using System;
using System.Collections.Generic;

namespace BashSoft.Contracts
{
    public interface ISimpleOrderedBag<T> : IEnumerable<T> where T : IComparable<T>
    {
        int Count { get; }

        int Capacity { get; }

        void Add(T element);

        bool Remove(T element);

        void AddAll(ICollection<T> collection);

        string JoinWith(string joiner);
    }
}