using System;
using System.Collections.Generic;
using System.Linq;

namespace Study.LabWork1.Features.Task1
{
    public class MySet<T>
    {
        private readonly HashSet<T> _storage;
        public int Size => _storage.Count;

        public MySet(IEnumerable<T> collection)
        {
            _storage = new HashSet<T>(collection ?? Enumerable.Empty<T>());
        }

        public override string ToString()
        {
            return "{" + string.Join(", ", _storage) + "}";
        }

        public static bool operator ==(MySet<T> first, MySet<T> second)
        {
            if (ReferenceEquals(first, second)) return true;
            if (first is null || second is null) return false;

            return first._storage.SetEquals(second._storage);
        }

        public static bool operator !=(MySet<T> first, MySet<T> second)
        {
            return !(first == second);
        }

        public override bool Equals(object obj)
        {
            return this == (obj as MySet<T>);
        }

        public override int GetHashCode()
        {
            return _storage.Count;
        }


        public static MySet<T> operator |(MySet<T> first, MySet<T> second)
        {
            if (first is null || second is null) return new MySet<T>(null);
            return new MySet<T>(first._storage.Union(second._storage));
        }


        public static MySet<T> operator &(MySet<T> first, MySet<T> second)
        {
            if (first is null || second is null) return new MySet<T>(null);
            return new MySet<T>(first._storage.Intersect(second._storage));
        }


        public static MySet<T> operator -(MySet<T> first, MySet<T> second)
        {
            if (first is null || second is null) return new MySet<T>(null);
            return new MySet<T>(first._storage.Except(second._storage));
        }


        public static MySet<T> operator /(MySet<T> first, MySet<T> second)
        {
            if (first is null || second is null) return new MySet<T>(null);

            var union = first._storage.Union(second._storage);
            var intersect = first._storage.Intersect(second._storage);

            return new MySet<T>(union.Except(intersect));
        }
    }
}
