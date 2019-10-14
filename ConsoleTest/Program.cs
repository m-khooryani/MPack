using MPack;
using System;
using System.Numerics;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var ss = new MyClasss()
            {
                //str = NumericString.Parse("62806280628062806280"),
                str = ("62806280628062806280"),
            };
            //var ss = Newtonsoft.Json.JsonConvert.SerializeObject(a);

            byte[] bytes = Parser.Serialize(ss);
            MyClasss sss = Parser.Deserialize<MyClasss>(bytes);
            //BigInteger bigInteger = BigInteger.Parse()
        }
    }

    public class MyClasss
    {
        [Tag(0)]
        public string str { get; set; }
    }
}
