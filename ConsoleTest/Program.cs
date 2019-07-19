using MPack;
using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A()
            {
                B = new int[] { 1, 2, 3, 4, 5 }
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
    }
}
