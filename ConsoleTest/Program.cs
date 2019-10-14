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
                str = NumericString.Parse("0000"),
                //str = ("62806280628062806280"),
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
        public NumericString str { get; set; }
    }
}
