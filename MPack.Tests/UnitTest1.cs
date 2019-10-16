using DeepEqual.Syntax;
using ExpectedObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            Assert.True(myObject.IsDeepEqual(deserializedObject));
        }

        [Fact]
        public void Test2()
        {
            MyClass myObject = new MyClass()
            {
                SampleInt = 0,
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.True(myObject.IsDeepEqual(deserializedObject));
        }

        [Fact]
        public void Test3()
        {
            MyClass myObject = new MyClass()
            {
                SampleInt = -999,
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.True(myObject.IsDeepEqual(deserializedObject));
        }

        [Fact]
        public void Test4()
        {
            MyClass myObject = new MyClass()
            {
                SampleByte = 120,
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.True(myObject.IsDeepEqual(deserializedObject));
        }

        [Fact]
        public void Test5()
        {
            MyClass myObject = new MyClass()
            {
                ArrayOfInt = new int[] { }
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.True(myObject.IsDeepEqual(deserializedObject));
        }

        [Fact]
        public void Test6()
        {
            MyClass myObject = new MyClass()
            {
                ArrayOfInt = new int[] { 0 }
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.True(myObject.IsDeepEqual(deserializedObject));
        }

        [Fact]
        public void Test7()
        {
            MyClass myObject = new MyClass()
            {
                ArrayOfInt = new int[] { 9 , 456 , -56 , -1 , 98521245, -2 , -989898 }
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.True(myObject.IsDeepEqual(deserializedObject));
        }

        [Fact]
        public void Test8()
        {
            MyClass myObject = new MyClass()
            {
                ArrayOfInt = new int[] { 100 , -200 , 300, -400 , 0 },
                SampleByte = 56,
                SampleInt = 65
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.True(myObject.IsDeepEqual(deserializedObject));
        }

        [Fact]
        public void Test9()
        {
            MyClass myObject = new MyClass()
            {
                SampleString = "رشته فارسی",
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.True(myObject.IsDeepEqual(deserializedObject));
        }

        [Fact]
        public void Test10()
        {
            MyClass myObject = new MyClass()
            {
                SampleString = null,
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.True(myObject.IsDeepEqual(deserializedObject));
        }

        [Fact]
        public void Test11()
        {
            MyClass myObject = new MyClass()
            {
                SampleString = "wertyuiop[hyunmjiko,lbvsdkvbakbdvbvjbajsdbjsbdvjsbvjbsjbhvjbhsvalKSCklAVMnv JKBvhbhbJHVBjkvm sovsds4v64v4sv4 6 4e64few4 6ew4f we4f we532786 386823#$%^&*(#$%^&*(vhsdih ifh ishfihefiuh  hewfhwiehf  fihfhufaweha  f"
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.True(myObject.IsDeepEqual(deserializedObject));
        }

        [Fact]
        public void Test12()
        {
            MyClass myObject = new MyClass()
            {
                SampleDate = new DateTime(2019, 7, 22),
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.True(myObject.IsDeepEqual(deserializedObject));
        }

        [Fact]
        public void Test13()
        {
            MyClass myObject = new MyClass()
            {
                SampleDate = new DateTime(2019, 7, 22, 11, 4, 55),
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.True(myObject.IsDeepEqual(deserializedObject));
        }

        [Fact]
        public void Test14()
        {
            byte[] bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            MyClass myObject = new MyClass()
            {
                SampleGuid = new Guid(bytes),
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.True(myObject.IsDeepEqual(deserializedObject));
        }

        [Fact]
        public void Test15()
        {
            MyClass myObject = new MyClass()
            {
                SampleListInt = new List<int>() { }
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.True(myObject.IsDeepEqual(deserializedObject));
        }

        [Fact]
        public void Test16()
        {
            MyClass myObject = new MyClass()
            {
                SampleListInt = new List<int>() { 0, -1000, 2000, -3000, 999999, 9000, 9001, 9002, 9003, 9004, 9005, 9006, 9007, 9008, 9009, 9010, -9010 }
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.True(myObject.IsDeepEqual(deserializedObject));
        }

        [Fact]
        public void Test17()
        {
            MyClass myObject = new MyClass()
            {
                SampleListInt = new List<int>() { 1 }
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.True(myObject.IsDeepEqual(deserializedObject));
        }

        [Fact]
        public void Test18()
        {
            byte[] bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            MyClass myObject = new MyClass()
            {
                ArrayOfInt = new int[] { 96, 56, 10, 0, -84, 75, -10 },
                SampleListInt = new List<int>() { 100, 350, 645, -897, 0, 1, -1, -2, 1, 0, 0, 0, 2 },
                SampleByte = 89,
                SampleDate = new DateTime(2002, 6, 30),
                SampleGuid = new Guid(bytes),
                SampleInt = int.MaxValue,
                SampleString = "hhh@ggi.com",
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.True(myObject.IsDeepEqual(deserializedObject));
        }

        [Fact]
        public void Test19()
        {
            MyClass myObject = new MyClass()
            {
                SampleIntSet = new HashSet<int>() { 1, 2, 3 }
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.True(myObject.IsDeepEqual(deserializedObject));
        }

        [Fact]
        public void Test20()
        {
            MyClass myObject = new MyClass()
            {
                SampleKVPIntString = new KeyValuePair<int, string>(9898, "9812hsudhvs56444$%^&*("),
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.True(myObject.IsDeepEqual(deserializedObject));
        }

        [Fact]
        public void Test21()
        {
            MyClass myObject = new MyClass()
            {
                SampleKVPIntString = new KeyValuePair<int, string>(0, ""),
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.True(myObject.IsDeepEqual(deserializedObject));
        }

        [Fact]
        public void Test22()
        {
            MyClass myObject = new MyClass()
            {
                SampleKVPStringInt = new KeyValuePair<string, int>("kj456asc46sa4c6s4c^&V78gv8a", 865142),
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.True(myObject.IsDeepEqual(deserializedObject));
        }

        [Fact]
        public void Test23()
        {
            MyClass myObject = new MyClass()
            {
                SampleKVPArrayIntString = new KeyValuePair<int[], string>(new int[] { 1 }, "abc")
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(myObject), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void Test24()
        {
            MyClass myObject = new MyClass()
            {
                SampleKVPArrayIntString = new KeyValuePair<int[], string>(new int[] { 45, 0, 0, 0, 3, -1, -1, -1023, 1023, 999888777, }, "Manchester United")
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(myObject), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void Test25()
        {
            MyClass myObject = new MyClass()
            {
                SampleKVPArrayIntString = new KeyValuePair<int[], string>(new int[] { }, "")
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(myObject), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void Test26()
        {
            byte[] bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            MyClass myObject = new MyClass()
            {
                SampleObject =new MyClass2()
                {
                    ArrayOfInt = new int[] { 0, 0, 0, 1, 2, 99, 9994, 56, 45, 5478, -10, -1, -2, -8, -2048, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                    ListOfInt = new List<int>() { 1, 1 },
                    SampleByte = 255,
                    SampleDate = new DateTime(2002, 6, 9),
                    SampleGuid = new Guid(bytes),
                    SampleInt = int.MinValue,
                    SampleKVPArrayOfIntString = new KeyValuePair<int[], string>(new int[] { 6 }, "aaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbccccccccccccccccccccccccccccccccccccccccccccccccddddddddddddddddddddddddddddddddeeeehjbclabviabvbvkasjbv"),
                    SampleKVPIntString = new KeyValuePair<int, string>(23, "23"),
                    SampleKVPStringInt = new KeyValuePair<string, int>("6a4f6f4a4f5a65f", 37),
                    SampleNullableInt = 10000089,
                    SampleOfEnum = Days.Day2,
                    SampleString = "...@..",
                    SetOfInt = new HashSet<int>() { 9, 8, 7, 6, 5 },
                }
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(myObject), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void Test27()
        {
            byte[] bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            MyClass2 myClass2 = new MyClass2()
            {
                ArrayOfInt = new int[] { 0, 0, 0, 1, 2, 99, 9994, 56, 45, 5478, -10, -1, -2, -8, -2048, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                ListOfInt = new List<int>() { 1, 1 },
                SampleByte = 255,
                SampleDate = new DateTime(2002, 6, 9),
                SampleGuid = new Guid(bytes),
                SampleInt = int.MinValue,
                SampleKVPArrayOfIntString = new KeyValuePair<int[], string>(new int[] { 6 }, "aaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbccccccccccccccccccccccccccccccccccccccccccccccccddddddddddddddddddddddddddddddddeeeehjbclabviabvbvkasjbv"),
                SampleKVPIntString = new KeyValuePair<int, string>(23, "23"),
                SampleKVPStringInt = new KeyValuePair<string, int>("6a4f6f4a4f5a65f", 37),
                SampleNullableInt = 10000089,
                SampleOfEnum = Days.Day2,
                SampleString = "...@..",
                SetOfInt = new HashSet<int>() { 9, 8, 7, 6, 5 },
            };
            MyClass myObject = new MyClass()
            {
                SampleObject = myClass2,
                SampleComplexArray = new MyClass2[] {myClass2 , myClass2, myClass2},
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(myObject), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void Test28()
        {
            MyClass myObject = new MyClass()
            {
                SampleEnum = Days.Day3,
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(myObject), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void Test29()
        {
            MyClass myObject = new MyClass()
            {
                SampleNullableInt = 8988,
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(myObject), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void Test30()
        {
            byte[] bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            MyClass2 myClass2 = new MyClass2()
            {
                ArrayOfInt = new int[] { 0, 0, 0, 1, 2, 99, 9994, 56, 45, 5478, -10, -1, -2, -8, -2048, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                ListOfInt = new List<int>() { 1, 1 },
                SampleByte = 255,
                SampleDate = new DateTime(2002, 6, 9),
                SampleGuid = new Guid(bytes),
                SampleInt = int.MinValue,
                SampleKVPArrayOfIntString = new KeyValuePair<int[], string>(new int[] { 6 }, "aaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbccccccccccccccccccccccccccccccccccccccccccccccccddddddddddddddddddddddddddddddddeeeehjbclabviabvbvkasjbv"),
                SampleKVPIntString = new KeyValuePair<int, string>(23, "23"),
                SampleKVPStringInt = new KeyValuePair<string, int>("6a4f6f4a4f5a65f", 37),
                SampleNullableInt = 10000089,
                SampleOfEnum = Days.Day2,
                SampleString = "...@..",
                SetOfInt = new HashSet<int>() { 9, 8, 7, 6, 5 },
            };
            MyClass myObject = new MyClass()
            {
                SampleObject = myClass2,
                SampleComplexArray = new MyClass2[] { myClass2, myClass2, myClass2 },
                SampleComplexList = new List<MyClass2> { myClass2 }
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(myObject), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void Test31()
        {
            byte[] bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            MyClass2 myClass2 = new MyClass2()
            {
                ArrayOfInt = new int[] { 0, 0, 0, 1, 2, 99, 9994, 56, 45, 5478, -10, -1, -2, -8, -2048, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                ListOfInt = new List<int>() { 1, 1 },
                SampleByte = 255,
                SampleDate = new DateTime(2002, 6, 9),
                SampleGuid = new Guid(bytes),
                SampleInt = int.MinValue,
                SampleKVPArrayOfIntString = new KeyValuePair<int[], string>(new int[] { 6 }, "aaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbccccccccccccccccccccccccccccccccccccccccccccccccddddddddddddddddddddddddddddddddeeeehjbclabviabvbvkasjbv"),
                SampleKVPIntString = new KeyValuePair<int, string>(23, "23"),
                SampleKVPStringInt = new KeyValuePair<string, int>("6a4f6f4a4f5a65f", 37),
                SampleNullableInt = 10000089,
                SampleOfEnum = Days.Day2,
                SampleString = "...@..",
                SetOfInt = new HashSet<int>() { 9, 8, 7, 6, 5 },
            };
            MyClass myObject = new MyClass()
            {
                SampleObject = myClass2,
                SampleComplexArray = new MyClass2[] { myClass2 },
                SampleComplexList = new List<MyClass2> { myClass2, myClass2, myClass2 }
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(myObject), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void Test32()
        {
            byte[] bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            MyClass2 myClass2 = new MyClass2()
            {
                ArrayOfInt = new int[] { 0, 0, 0, 1, 2, 99, 9994, 56, 45, 5478, -10, -1, -2, -8, -2048, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                ListOfInt = new List<int>() { 1, 1 },
                SampleByte = 255,
                SampleDate = new DateTime(2002, 6, 9),
                SampleGuid = new Guid(bytes),
                SampleInt = int.MinValue,
                SampleKVPArrayOfIntString = new KeyValuePair<int[], string>(new int[] { 6 }, "aaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbccccccccccccccccccccccccccccccccccccccccccccccccddddddddddddddddddddddddddddddddeeeehjbclabviabvbvkasjbv"),
                SampleKVPIntString = new KeyValuePair<int, string>(23, "23"),
                SampleKVPStringInt = new KeyValuePair<string, int>("6a4f6f4a4f5a65f", 37),
                SampleNullableInt = 10000089,
                SampleOfEnum = Days.Day2,
                SampleString = "...@..",
                SetOfInt = new HashSet<int>() { 9, 8, 7, 6, 5 },
            };
            MyClass myObject = new MyClass()
            {
                SampleObject = myClass2,
                SampleComplexArray = new MyClass2[] { myClass2, myClass2, myClass2 },
                SampleComplexList = new List<MyClass2> { myClass2, myClass2, myClass2 }
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(myObject), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void Test33()
        {
            byte[] bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            MyClass2 myClass2 = new MyClass2()
            {
                ArrayOfInt = new int[] { 0, 0, 0, 1, 2, 99, 9994, 56, 45, 5478, -10, -1, -2, -8, -2048, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                ListOfInt = new List<int>() { 1, 1 },
                SampleByte = 255,
                SampleDate = new DateTime(2002, 6, 9),
                SampleGuid = new Guid(bytes),
                SampleInt = int.MinValue,
                SampleKVPArrayOfIntString = new KeyValuePair<int[], string>(new int[] { 6 }, "aaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbccccccccccccccccccccccccccccccccccccccccccccccccddddddddddddddddddddddddddddddddeeeehjbclabviabvbvkasjbv"),
                SampleKVPIntString = new KeyValuePair<int, string>(23, "23"),
                SampleKVPStringInt = new KeyValuePair<string, int>("6a4f6f4a4f5a65f", 37),
                SampleNullableInt = 10000089,
                SampleOfEnum = Days.Day2,
                SampleString = "...@..",
                SetOfInt = new HashSet<int>() { 9, 8, 7, 6, 5 },
            };
            MyClass myObject = new MyClass()
            {
                SampleObject = myClass2,
                SampleComplexArray = new MyClass2[] { myClass2 },
                SampleComplexList = new List<MyClass2> { myClass2 }
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(myObject), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void Test34()
        {
            byte[] bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            MyClass2 myClass2 = new MyClass2()
            {
                ArrayOfInt = new int[] { 0, 0, 0, 1, 2, 99, 9994, 56, 45, 5478, -10, -1, -2, -8, -2048, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                ListOfInt = new List<int>() { 1, 1 },
                SampleByte = 255,
                SampleDate = new DateTime(2002, 6, 9),
                SampleGuid = new Guid(bytes),
                SampleInt = int.MinValue,
                SampleKVPArrayOfIntString = new KeyValuePair<int[], string>(new int[] { 6 }, "aaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbccccccccccccccccccccccccccccccccccccccccccccccccddddddddddddddddddddddddddddddddeeeehjbclabviabvbvkasjbv"),
                SampleKVPIntString = new KeyValuePair<int, string>(23, "23"),
                SampleKVPStringInt = new KeyValuePair<string, int>("6a4f6f4a4f5a65f", 37),
                SampleNullableInt = 10000089,
                SampleOfEnum = Days.Day2,
                SampleString = "...@..",
                SetOfInt = new HashSet<int>() { 9, 8, 7, 6, 5 },
            };
            MyClass myObject = new MyClass()
            {
                SampleObject = myClass2,
                SampleComplexArray = new MyClass2[] { },
                SampleComplexList = new List<MyClass2> { myClass2 }
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(myObject), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void Test35()
        {
            byte[] bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            My myObject = new My()
            {
                SampleNullableGuid = new Guid(bytes),
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<My>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(myObject), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void Test36()
        {
            My2 myObject = new My2()
            {
                Set = new SortedSet<int>() { 1, 2, 3 }
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<My2>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(myObject), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void Test37()
        {
            byte[] bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            MyClass2 myClass2 = new MyClass2()
            {
                ArrayOfInt = new int[] { 0, 0, 0, 1, 2, 99, 9994, 56, 45, 5478, -10, -1, -2, -8, -2048, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                ListOfInt = new List<int>() { 1, 1 },
                SampleByte = 255,
                SampleDate = new DateTime(2002, 6, 9),
                SampleGuid = new Guid(bytes),
                NStr = NumericString.Parse("0"),
                SampleInt = int.MinValue,
                SampleKVPArrayOfIntString = new KeyValuePair<int[], string>(new int[] { 6 }, "aaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbccccccccccccccccccccccccccccccccccccccccccccccccddddddddddddddddddddddddddddddddeeeehjbclabviabvbvkasjbv"),
                SampleKVPIntString = new KeyValuePair<int, string>(23, "23"),
                SampleKVPStringInt = new KeyValuePair<string, int>("6a4f6f4a4f5a65f", 37),
                SampleNullableInt = 10000089,
                SampleOfEnum = Days.Day2,
                SampleString = "...@..",
                SetOfInt = new HashSet<int>() { 9, 8, 7, 6, 5 },
            };
            MyClass myObject = new MyClass()
            {
                SampleObject = myClass2,
                SampleComplexArray = new MyClass2[] { },
                SampleComplexList = new List<MyClass2> { myClass2 }
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(myObject), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void Test38()
        {
            byte[] bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            MyClass2 myClass2 = new MyClass2()
            {
                ArrayOfInt = new int[] { 0, 0, 0, 1, 2, 99, 9994, 56, 45, 5478, -10, -1, -2, -8, -2048, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                ListOfInt = new List<int>() { 1, 1 },
                SampleByte = 255,
                SampleDate = new DateTime(2002, 6, 9),
                SampleGuid = new Guid(bytes),
                NStr = NumericString.Parse("0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"),
                SampleInt = int.MinValue,
                SampleKVPArrayOfIntString = new KeyValuePair<int[], string>(new int[] { 6 }, "aaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbccccccccccccccccccccccccccccccccccccccccccccccccddddddddddddddddddddddddddddddddeeeehjbclabviabvbvkasjbv"),
                SampleKVPIntString = new KeyValuePair<int, string>(23, "23"),
                SampleKVPStringInt = new KeyValuePair<string, int>("6a4f6f4a4f5a65f", 37),
                SampleNullableInt = 10000089,
                SampleOfEnum = Days.Day2,
                SampleString = "...@..",
                SetOfInt = new HashSet<int>() { 9, 8, 7, 6, 5 },
            };
            MyClass myObject = new MyClass()
            {
                SampleObject = myClass2,
                SampleComplexArray = new MyClass2[] { },
                SampleComplexList = new List<MyClass2> { myClass2 }
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(myObject), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void Test39()
        {
            byte[] bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            MyClass2 myClass2 = new MyClass2()
            {
                ArrayOfInt = new int[] { 0, 0, 0, 1, 2, 99, 9994, 56, 45, 5478, -10, -1, -2, -8, -2048, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                ListOfInt = new List<int>() { 1, 1 },
                SampleByte = 255,
                SampleDate = new DateTime(2002, 6, 9),
                SampleGuid = new Guid(bytes),
                NStr = NumericString.Parse("00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000009952651651651456165156096440900000000000000000000006416516161688989484115161351165156166000000000000"),
                SampleInt = int.MinValue,
                SampleKVPArrayOfIntString = new KeyValuePair<int[], string>(new int[] { 6 }, "aaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbccccccccccccccccccccccccccccccccccccccccccccccccddddddddddddddddddddddddddddddddeeeehjbclabviabvbvkasjbv"),
                SampleKVPIntString = new KeyValuePair<int, string>(23, "23"),
                SampleKVPStringInt = new KeyValuePair<string, int>("6a4f6f4a4f5a65f", 37),
                SampleNullableInt = 10000089,
                SampleOfEnum = Days.Day2,
                SampleString = "...@..",
                SetOfInt = new HashSet<int>() { 9, 8, 7, 6, 5 },
            };
            MyClass myObject = new MyClass()
            {
                SampleObject = myClass2,
                SampleComplexArray = new MyClass2[] { },
                SampleComplexList = new List<MyClass2> { myClass2 }
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(myObject), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void Test40()
        {
            byte[] bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            MyClass2 myClass2 = new MyClass2()
            {
                ArrayOfInt = new int[] { 0, 0, 0, 1, 2, 99, 9994, 56, 45, 5478, -10, -1, -2, -8, -2048, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                ListOfInt = new List<int>() { 1, 1 },
                SampleByte = 255,
                SampleDate = new DateTime(2002, 6, 9),
                SampleGuid = new Guid(bytes),
                NStr = NumericString.Parse("1"),
                SampleInt = int.MinValue,
                SampleKVPArrayOfIntString = new KeyValuePair<int[], string>(new int[] { 6 }, "aaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbccccccccccccccccccccccccccccccccccccccccccccccccddddddddddddddddddddddddddddddddeeeehjbclabviabvbvkasjbv"),
                SampleKVPIntString = new KeyValuePair<int, string>(23, "23"),
                SampleKVPStringInt = new KeyValuePair<string, int>("6a4f6f4a4f5a65f", 37),
                SampleNullableInt = 10000089,
                SampleOfEnum = Days.Day2,
                SampleString = "...@..",
                SetOfInt = new HashSet<int>() { 9, 8, 7, 6, 5 },
            };
            MyClass myObject = new MyClass()
            {
                SampleObject = myClass2,
                SampleComplexArray = new MyClass2[] { },
                SampleComplexList = new List<MyClass2> { myClass2 }
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(myObject), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void NumericTest()
        {
            TestClass testClass = new TestClass()
            {
                A = 4984,
                B = NumericString.Parse("1"),
                C = 4445511,
            };
            var serializedBytes = Parser.Serialize(testClass);
            var deserializedObject = Parser.Deserialize<TestClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(testClass), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void NumericTest1()
        {
            TestClass testClass = new TestClass()
            {
                A = 4984,
                B = NumericString.Parse("1"),
                C = 4445511,
            };
            var serializedBytes = Parser.Serialize(testClass);
            var deserializedObject = Parser.Deserialize<TestClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(testClass), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void NumericTest2()
        {
            TestClass testClass = new TestClass()
            {
                A = 4984,
                B = NumericString.Parse("111"),
                C = 4445511,
            };
            var serializedBytes = Parser.Serialize(testClass);
            var deserializedObject = Parser.Deserialize<TestClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(testClass), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void NumericTest3()
        {
            TestClass testClass = new TestClass()
            {
                A = 4984,
                B = NumericString.Parse("10"),
                C = 4445511,
            };
            var serializedBytes = Parser.Serialize(testClass);
            var deserializedObject = Parser.Deserialize<TestClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(testClass), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void NumericTest4()
        {
            TestClass testClass = new TestClass()
            {
                A = 4984,
                B = NumericString.Parse("100000000000000000000000000000000000000000000000"),
                C = 4445511,
            };
            var serializedBytes = Parser.Serialize(testClass);
            var deserializedObject = Parser.Deserialize<TestClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(testClass), JsonConvert.SerializeObject(deserializedObject));
        }

        public void NumericTest5()
        {
            TestClass testClass = new TestClass()
            {
                A = 4984,
                B = NumericString.Parse(null),
                C = 4445511,
            };
            var serializedBytes = Parser.Serialize(testClass);
            var deserializedObject = Parser.Deserialize<TestClass>(serializedBytes);
            JsonConvert.DeserializeObject<TestClass>("{\"A\":4984,\"B\":null,\"C\":4445511}");
            Assert.Equal(JsonConvert.SerializeObject(testClass), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void NumericTest41()
        {
            TestClass testClass = new TestClass()
            {
                A = 4984,
                B = NumericString.Parse("0"),
                C = 4445511,
            };
            var serializedBytes = Parser.Serialize(testClass);
            var deserializedObject = Parser.Deserialize<TestClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(testClass), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void NumericTest42()
        {
            TestClass testClass = new TestClass()
            {
                A = 4984,
                B = NumericString.Parse("0000"),
                C = 4445511,
            };
            var serializedBytes = Parser.Serialize(testClass);
            var deserializedObject = Parser.Deserialize<TestClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(testClass), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void NumericTest43()
        {
            TestClass testClass = new TestClass()
            {
                A = 4984,
                B = NumericString.Parse("01"),
                C = 4445511,
            };
            var serializedBytes = Parser.Serialize(testClass);
            var deserializedObject = Parser.Deserialize<TestClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(testClass), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void NumericTest44()
        {
            TestClass testClass = new TestClass()
            {
                A = 4984,
                B = NumericString.Parse("084191911110000000000000000"),
                C = 4445511,
            };
            var serializedBytes = Parser.Serialize(testClass);
            var deserializedObject = Parser.Deserialize<TestClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(testClass), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void NumericTest45()
        {
            TestClass testClass = new TestClass()
            {
                A = 4984,
                B = NumericString.Parse("0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000084191911110000000000000000234523642342348235623582395237357823443243423163251423141236146231412342341231416165231"),
                C = 4445511,
            };
            var serializedBytes = Parser.Serialize(testClass);
            var deserializedObject = Parser.Deserialize<TestClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(testClass), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void NumericTest21()
        {
            TestClass testClass = new TestClass()
            {
                A = 4984,
                B = NumericString.Parse("مجتبی kjs22666666666666666"),
                C = 4445511,
            };
            var serializedBytes = Parser.Serialize(testClass);
            var deserializedObject = Parser.Deserialize<TestClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(testClass), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void NumericTest22()
        {
            TestClass testClass = new TestClass()
            {
                A = 4984,
                B = NumericString.Parse("مجتبی kjs000000000000000000000000000"),
                C = 4445511,
            };
            var serializedBytes = Parser.Serialize(testClass);
            var deserializedObject = Parser.Deserialize<TestClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(testClass), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void NumericTest23()
        {
            TestClass testClass = new TestClass()
            {
                A = 4984,
                B = NumericString.Parse("مجتبی kjs000226666666666666668499844466156161655555555555555551111111111111111111111111111111111111111111111112121212121212"),
                C = 4445511,
            };
            var serializedBytes = Parser.Serialize(testClass);
            var deserializedObject = Parser.Deserialize<TestClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(testClass), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void NumericTest24()
        {
            TestClass testClass = new TestClass()
            {
                A = 4984,
                B = NumericString.Parse("0AA1221122121"),
                C = 4445511,
            };
            var serializedBytes = Parser.Serialize(testClass);
            var deserializedObject = Parser.Deserialize<TestClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(testClass), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void NumericTest25()
        {
            TestClass testClass = new TestClass()
            {
                A = 4984,
                B = NumericString.Parse("0AA1"),
                C = 4445511,
            };
            var serializedBytes = Parser.Serialize(testClass);
            var deserializedObject = Parser.Deserialize<TestClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(testClass), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void NumericTest26()
        {
            TestClass testClass = new TestClass()
            {
                A = 4984,
                B = NumericString.Parse("0AA"),
                C = 4445511,
            };
            var serializedBytes = Parser.Serialize(testClass);
            var deserializedObject = Parser.Deserialize<TestClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(testClass), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void NumericTest27()
        {
            TestClass testClass = new TestClass()
            {
                A = 4984,
                B = NumericString.Parse("نسترن ای عشق مندتسنریدsbgvdjhbadsbvhjabsvbukasbvdbhjvbjuhsdbfdwvbhjsdbvhjdbgubvjdsbjbdvbjzxbjhbJVBJBVjbjvbjbvDBSVBVHJbJBVBJBVJbjvbajhvbjubvckzbxvjbzxdvbkdhzvjuhzsbjkvbsdbvboabvdbvbjvbajbvsbjhvbdskvbadjsvbasbvjhasbvbasjbvjashbvjhasbvjhbvasjbvjajb46145616516515616515665161616161616146466646546515611616161651616165161616165161651616161616161616161616161656161651156594894910000000000000000000011565161616156156165161561615615665616165156561565616561611532318915616515644"),
                C = 4445511,
            };
            var serializedBytes = Parser.Serialize(testClass);
            var deserializedObject = Parser.Deserialize<TestClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(testClass), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void NumericTest28()
        {
            TestClass testClass = new TestClass()
            {
                A = 4984,
                B = NumericString.Parse("a1a1a1a1a11111111111111111111111111111111111111111111111111111"),
                C = 4445511,
            };
            var serializedBytes = Parser.Serialize(testClass);
            var deserializedObject = Parser.Deserialize<TestClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(testClass), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void NumericTest11()
        {
            TestClass testClass = new TestClass()
            {
                A = 4984,
                B = NumericString.Parse("abvdskbvsdvbkdbhvbksdbvbsvcsigvsd%^&*()@#$%^&*   sdvosdv kb  ifhsgdfigidfsydafgyiesdgfygfuigdfdsgufbsbdfsdfhfsjdhbfsjfabfbsldfbdfjbafjbsdhfjabsfbsdhfhzivhisvbwbebwebvvehbwakbbvhjebwghvdsbdvbbubvhjbjebufvewbvcbjebvfwebfhbefvjwevfuveufevfyuwevfjwevvfuvefhvweuvfuwevfhwevfuwevfhwvfuvwefvbiwevfwefb"),
                C = 4445511,
            };
            var serializedBytes = Parser.Serialize(testClass);
            var deserializedObject = Parser.Deserialize<TestClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(testClass), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void NumericTest12()
        {
            TestClass testClass = new TestClass()
            {
                A = 4984,
                B = NumericString.Parse(""),
                C = 4445511,
            };
            var serializedBytes = Parser.Serialize(testClass);
            var deserializedObject = Parser.Deserialize<TestClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(testClass), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void NumericTest13()
        {
            TestClass testClass = new TestClass()
            {
                A = 4984,
                B = NumericString.Parse("   "),
                C = 4445511,
            };
            var serializedBytes = Parser.Serialize(testClass);
            var deserializedObject = Parser.Deserialize<TestClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(testClass), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void Test41()
        {
            byte[] bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            MyClass2 myClass2 = new MyClass2()
            {
                ArrayOfInt = new int[] { 0, 0, 0, 1, 2, 99, 9994, 56, 45, 5478, -10, -1, -2, -8, -2048, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                ListOfInt = new List<int>() { 1, 1 },
                SampleByte = 255,
                SampleDate = new DateTime(2002, 6, 9),
                SampleGuid = new Guid(bytes),
                NStr = NumericString.Parse("01"),
                SampleInt = int.MinValue,
                SampleKVPArrayOfIntString = new KeyValuePair<int[], string>(new int[] { 6 }, "aaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbccccccccccccccccccccccccccccccccccccccccccccccccddddddddddddddddddddddddddddddddeeeehjbclabviabvbvkasjbv"),
                SampleKVPIntString = new KeyValuePair<int, string>(23, "23"),
                SampleKVPStringInt = new KeyValuePair<string, int>("6a4f6f4a4f5a65f", 37),
                SampleNullableInt = 10000089,
                SampleOfEnum = Days.Day2,
                SampleString = "...@..",
                SetOfInt = new HashSet<int>() { 9, 8, 7, 6, 5 },
            };
            MyClass myObject = new MyClass()
            {
                SampleObject = myClass2,
                SampleComplexArray = new MyClass2[] { },
                SampleComplexList = new List<MyClass2> { myClass2 }
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(myObject), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void Test42()
        {
            byte[] bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            MyClass2 myClass2 = new MyClass2()
            {
                ArrayOfInt = new int[] { 0, 0, 0, 1, 2, 99, 9994, 56, 45, 5478, -10, -1, -2, -8, -2048, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                ListOfInt = new List<int>() { 1, 1 },
                SampleByte = 255,
                SampleDate = new DateTime(2002, 6, 9),
                SampleGuid = new Guid(bytes),
                NStr = NumericString.Parse("01"),
                NStrs = new List<NumericString>()
                {
                    NumericString.Parse("0"),
                    NumericString.Parse("98196451651651981941999999999999999999999111122222222222225165165161561665651651655555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555571666516561561"),
                    NumericString.Parse("01"),
                    NumericString.Parse("0000"),
                    NumericString.Parse("0000000000000000000000099"),
                },
                SampleInt = int.MinValue,
                SampleKVPArrayOfIntString = new KeyValuePair<int[], string>(new int[] { 6 }, "aaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbccccccccccccccccccccccccccccccccccccccccccccccccddddddddddddddddddddddddddddddddeeeehjbclabviabvbvkasjbv"),
                SampleKVPIntString = new KeyValuePair<int, string>(23, "23"),
                SampleKVPStringInt = new KeyValuePair<string, int>("6a4f6f4a4f5a65f", 37),
                SampleNullableInt = 10000089,
                SampleOfEnum = Days.Day2,
                SampleString = "...@..",
                SetOfInt = new HashSet<int>() { 9, 8, 7, 6, 5 },
            };
            MyClass myObject = new MyClass()
            {
                SampleObject = myClass2,
                SampleComplexArray = new MyClass2[] { },
                SampleComplexList = new List<MyClass2> { myClass2 }
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(myObject), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void Test43()
        {
            byte[] bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            MyClass2 myClass2 = new MyClass2()
            {
                ArrayOfInt = new int[] { 0, 0, 0, 1, 2, 99, 9994, 56, 45, 5478, -10, -1, -2, -8, -2048, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                ListOfInt = new List<int>() { 1, 1 },
                SampleByte = 255,
                SampleDate = new DateTime(2002, 6, 9),
                SampleGuid = new Guid(bytes),
                NStr = NumericString.Parse("01"),
                NStrs = new List<NumericString>()
                {
                },
                SampleInt = int.MinValue,
                SampleKVPArrayOfIntString = new KeyValuePair<int[], string>(new int[] { 6 }, "aaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbccccccccccccccccccccccccccccccccccccccccccccccccddddddddddddddddddddddddddddddddeeeehjbclabviabvbvkasjbv"),
                SampleKVPIntString = new KeyValuePair<int, string>(23, "23"),
                SampleKVPStringInt = new KeyValuePair<string, int>("6a4f6f4a4f5a65f", 37),
                SampleNullableInt = 10000089,
                SampleOfEnum = Days.Day2,
                SampleString = "...@..",
                SetOfInt = new HashSet<int>() { 9, 8, 7, 6, 5 },
            };
            MyClass myObject = new MyClass()
            {
                SampleObject = myClass2,
                SampleComplexArray = new MyClass2[] { },
                SampleComplexList = new List<MyClass2> { myClass2 }
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(myObject), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void Test44()
        {
            byte[] bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            MyClass2 myClass2 = new MyClass2()
            {
                ArrayOfInt = new int[] { 0, 0, 0, 1, 2, 99, 9994, 56, 45, 5478, -10, -1, -2, -8, -2048, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                ListOfInt = new List<int>() { 1, 1 },
                SampleByte = 255,
                SampleDate = new DateTime(2002, 6, 9),
                SampleGuid = new Guid(bytes),
                NStr = NumericString.Parse("0198989898988988999898989898989898989865"),
                NStrs = new List<NumericString>()
                {
                    NumericString.Parse("0"),
                },
                SampleInt = int.MinValue,
                SampleKVPArrayOfIntString = new KeyValuePair<int[], string>(new int[] { 6 }, "aaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbccccccccccccccccccccccccccccccccccccccccccccccccddddddddddddddddddddddddddddddddeeeehjbclabviabvbvkasjbv"),
                SampleKVPIntString = new KeyValuePair<int, string>(23, "23"),
                SampleKVPStringInt = new KeyValuePair<string, int>("6a4f6f4a4f5a65f", 37),
                SampleNullableInt = 10000089,
                SampleOfEnum = Days.Day2,
                SampleString = "...@..",
                SetOfInt = new HashSet<int>() { 9, 8, 7, 6, 5 },
            };
            MyClass myObject = new MyClass()
            {
                SampleObject = myClass2,
                SampleComplexArray = new MyClass2[] { },
                SampleComplexList = new List<MyClass2> { myClass2 }
            };
            var serializedBytes = Parser.Serialize(myObject);
            var deserializedObject = Parser.Deserialize<MyClass>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(myObject), JsonConvert.SerializeObject(deserializedObject));
        }

        //[Fact]
        //public void Test380()
        //{
        //    A myObject = new A()
        //    {
        //        List = new List<B>()
        //        {
        //            new C()
        //            {
        //                X = 20,
        //                //Password = "123456",
        //            },
        //            //new D()
        //            //{

        //            //},
        //        },
        //    };
        //    var serializedBytes = Parser.Serialize(myObject);
        //    var deserializedObject = Parser.Deserialize<A>(serializedBytes);
        //    Assert.Equal(JsonConvert.SerializeObject(myObject), JsonConvert.SerializeObject(deserializedObject));
        //}

        [Fact]
        public void InheritanceTest()
        {
            Response response = new Response()
            {
                SubResponses = new List<ResponseBase>()
                {
                    new LoginResponse()
                    {
                        ErrorCode = 0,
                        IsSuccessful = true,
                        Toke = "dfnhkjsdvskdgnbsdbvksdghkbsgnjksdijgsdjkgnsjkbgkisjdghbsahbjsdbvfsdfsdkjvnkisdj3456789456789456789456789456789456789sdfyuhasdbgvusdvgyugsduvb1"
                    },
                    new GetUserProfileResponse()
                    {
                        CurrentCustomer = new CurrentUserInfo()
                        {
                            Username = "111111",
                                title = "11111111111111111111111111",
                        },
                        Customers = new List<CustomerInfo>()
                        {
                            new CustomerInfo()
                            {
                                Title = "11111111111111111111111111",
                            },
                            new CustomerInfo()
                            {
                                Title = "11111111111111111111111111",
                            },
                            new CustomerInfo()
                            {
                                Title = "11111111111111111111111111",
                            }
                        }
                    }
                }
            };
            var bytes = Parser.Serialize(response);
            var response2 = Parser.Deserialize<Response>(bytes);
            var type = typeof(Response);
            var bytes2 = Parser.GetBytes<Response>(bytes, type.GetProperty("SubResponses"), 1);
            var dese = Parser.Deserialize<GetUserProfileResponse>(bytes2);
            Assert.NotNull(dese.CurrentCustomer);
            int a=4;
        }

        [Fact]
        public void RequestInheritance()
        {
            Request request = new Request()
            {
                Date = DateTime.Now,
                MessageNumber = 217,
                MobileNumber = "9121234567",
                SubRequests = new List<RequestBase>()
                {
                    new GetUserProfileRequest()
                    {
                        MessageType = 17,
                        Username = "98888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888"
                    },
                    new LoginRequest()
                    {
                        MessageType = 1,
                        Password = "123456",
                        Username = "",
                    },
                },
                Username = "legaltest1",
            };
            var bytes = Parser.Serialize(request);
            var response2 = Parser.Deserialize<Request>(bytes);
            var type = typeof(Request);
            var bytes2 = Parser.GetBytes<Request>(bytes, type.GetProperty("SubRequests"), 0);
            var dese = Parser.Deserialize<GetUserProfileRequest>(bytes2);
            Assert.Equal(17, dese.MessageType);
        }
    }
}
