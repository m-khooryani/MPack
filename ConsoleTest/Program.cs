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
            Random rand = new Random();
            int testNumber = 0;
            while (true)
            {
                TestClass testClass = new TestClass()
                {
                    A = 4984,
                    B = NumericString.Parse(GS(rand)),
                    C = 4445511,
                };
                var serializedBytes = Parser.Serialize(testClass);
                var deserializedObject = Parser.Deserialize<TestClass>(serializedBytes);
                string v = JsonConvert.SerializeObject(testClass);
                string v1 = JsonConvert.SerializeObject(deserializedObject);
                bool ok = v == v1;
                if (!ok)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(v);
                    Console.WriteLine(v1);
                    Console.ReadKey();
                }
                Console.WriteLine($"test {testNumber++} passed.");
            }
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

    public class TestClass
    {
        [Tag(0)]
        //[Ignore]
        //[JsonIgnore]
        public int A { get; set; }
        [Tag(1)]
        public NumericString B { get; set; }
        [Tag(2)]
        //[Ignore]
        //[JsonIgnore]
        public int C { get; set; }
    }
}
