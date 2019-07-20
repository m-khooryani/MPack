using System;
using Xunit;

namespace MPack.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            MyClass myObject = new MyClass()
            {
                SampleInt = 890,
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.Dee
        }
    }
}
