using MPack;
using System;
using System.Collections.Generic;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A()
            {
                B = new int[] { 1, 2, 3, 4, 5 },
                List = new List<int>() { 1000, 2000, 3000, 4000, 5000 }
            };
            var serializedBytes = Parser.Serialize(a);
            var deserilized = Parser.Deserialize<A>(serializedBytes);
        }
    }

    class A
    {
        [Tag(0)]
        [NFirstItems(2)]
        public int[] B { get; set; }
        [Tag(1)]
        [NFirstItems(3)]
        public List<int> List { get; set; }
    }
}
