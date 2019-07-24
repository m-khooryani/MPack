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
    }
}
