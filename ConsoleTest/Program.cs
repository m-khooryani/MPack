using MPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClass2 testClass2 = new TestClass2()
            {
                A = 123,
                A1 = "01",
                B = "0102030405",
                C = 56,
            };
            var serialized = Parser.SerializeObject(testClass2);
            var gh = Parser.Deserialize<TestClass2>(serialized);
        }

        static string GS(Random random)
        {
            int length = random.Next(1000);
            List<char> list = new List<char>();
            int nChars = random.Next(4);
            for (int i = 0; i < nChars; i++)
            {
                list.Add((char)(random.Next(10) + '0'));
            }
            nChars = random.Next(4);
            for (int i = 0; i < nChars; i++)
            {
                list.Add((char)(random.Next(5) + 'A'));
            }
            if(list.Count == 0)
            {
                return string.Empty;
            }
            char[] chars = list.ToArray();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                stringBuilder.Append(chars[random.Next(chars.Length)]);
            }
            return stringBuilder.ToString();
        }
    }

    public class MyFClass
    {
        [Tag(1)]
        public int ID { get; set; }
        [Tag(2)]
        public string AccountNumber { get; set; }
        [Tag(3)]
        public string Pan1 { get; set; }
        [Tag(4)]
        public string Pan2 { get; set; }
        [Tag(5)]
        public string Iban { get; set; }
    }

    public class TestClass
    {
        [Tag(60)]
        //[Ignore]
        //[JsonIgnore]
        public int A { get; set; }
        [Tag(61)]
        public NumericString B { get; set; }
        [Tag(62)]
        //[Ignore]
        //[JsonIgnore]
        public int C { get; set; }
    }

    public class TestClass2
    {
        [Tag(0)]
        public int A { get; set; }
        [Tag(20)]
        public string A1 { get; set; }
        [Tag(1)]
        [Hex]
        public string B { get; set; }
        [Tag(2)]
        public int C { get; set; }
    }
}
