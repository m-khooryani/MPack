using MPack;
using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseModel a = new BaseModel()
            {
                //Arr = new int[] { 9894, 521, 25, 26262, 226 },
                //Name = "Moj",
                //X = 89565656,
                //Y = 8989,
            };
            var ss = Newtonsoft.Json.JsonConvert.SerializeObject(a);

            byte[] bytes = Parser.Serialize(a);

        }
    }

    internal class BaseModel
    {
    }
}
