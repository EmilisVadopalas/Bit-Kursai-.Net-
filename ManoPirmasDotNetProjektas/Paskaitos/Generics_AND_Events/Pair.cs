using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.Generics
{
    public class Pair<T,E>
    {
        public T Key { get; init; }
        public E Value { get; set; }

        public Pair(T key, E value)
        {
            Key = key;
            Value = value;
        }
    }

    public class Pair<A,B,C,D,E>
    {
        public A Item1 { get; init; }
        public B Item2 { get; init; }
        public C Item3 { get; init; }
        public D Item4 { get; init; }
        public E Item5 { get; init; }

        public Pair(A item1, B item2, C item3, D item4, E item5)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            Item4 = item4;
            Item5 = item5;
        }
    }


}
