using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

namespace MPack.Tests.ExactMatch_Tests
{
    public class UnitTest2
    {
        [Fact]
        public void Test1()
        {
            ABC myObject = new ABC()
            {
                A = 2,
                B = "",
                C = 56,
            };
            var serializedBytes = Parser.SerializeObject(myObject);
            var deserializedObject = Parser.Deserialize<ABC>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(new ABC()), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void Test2()
        {
            ABC myObject = new ABC()
            {
                A = 2,
                B = "B1",
                C = 56,
            };
            var serializedBytes = Parser.SerializeObject(myObject);
            var deserializedObject = Parser.Deserialize<ABC>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(myObject), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void Test3()
        {
            ABC2 aBC2 = new ABC2()
            {
                A = 5624,
                B = new List<ABC>()
                {
                    new ABC()
                    {
                        A = 2,
                        B = "B1",
                        C = 56,
                    },
                    new ABC()
                    {
                        A = 2,
                        B = "B11",
                        C = 56,
                    }
                }
            };
            var serializedBytes = Parser.SerializeObject(aBC2);
            var deserializedObject = Parser.Deserialize<ABC2>(serializedBytes);
            Assert.Single(deserializedObject.B);
        }

        [Fact]
        public void Test4()
        {
            ABC2 aBC2 = new ABC2()
            {
                A = 5624,
                B = new List<ABC>()
                {
                    new ABC()
                    {
                        A = 2,
                        B = "B1",
                        C = 56,
                    },
                    new ABC()
                    {
                        A = 2,
                        B = "B2",
                        C = 56,
                    },
                    new ABC()
                    {
                        A = 2,
                        B = "B11",
                        C = 56,
                    }
                }
            };
            var serializedBytes = Parser.SerializeObject(aBC2);
            var deserializedObject = Parser.Deserialize<ABC2>(serializedBytes);
            Assert.Equal(2, deserializedObject.B.Count);
        }

        [Fact]
        public void Test5()
        {
            ABC2 aBC2 = new ABC2()
            {
                A = 5624,
                B = new List<ABC>()
                {
                    new ABC()
                    {
                        A = 2,
                        B = "B1",
                        C = 56,
                    },
                    new ABC()
                    {
                        A = 2,
                        B = "B2",
                        C = 56,
                    },
                    new ABC()
                    {
                        A = 2,
                        B = "B11",
                        C = 56,
                    },
                    new ExtendedABC()
                    {
                        A =  2,
                        B = "sdvms",
                        B2 = "B1",
                        C = 89,
                    }
                }
            };
            var serializedBytes = Parser.SerializeObject(aBC2);
            var deserializedObject = Parser.Deserialize<ABC2>(serializedBytes);
            Assert.Equal(2, deserializedObject.B.Count);
        }

        [Fact]
        public void Test6()
        {
            ABC2 aBC2 = new ABC2()
            {
                A = 5624,
                B = new List<ABC>()
                {
                    new ABC()
                    {
                        A = 2,
                        B = "B1",
                        C = 56,
                    },
                    new ABC()
                    {
                        A = 2,
                        B = "B2",
                        C = 56,
                    },
                    new ABC()
                    {
                        A = 2,
                        B = "B11",
                        C = 56,
                    },
                    new ExtendedABC()
                    {
                        A =  2,
                        B = "B1",
                        B2 = "B25",
                        C = 89,
                    }
                }
            };
            var serializedBytes = Parser.SerializeObject(aBC2);
            var deserializedObject = Parser.Deserialize<ABC2>(serializedBytes);
            Assert.Equal(2, deserializedObject.B.Count);
        }

        [Fact]
        public void Test11()
        {
            CBA myObject = new CBA()
            {
                A = 2,
                B = "",
                C = 56,
            };
            var serializedBytes = Parser.SerializeObject(myObject);
            var deserializedObject = Parser.Deserialize<CBA>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(new CBA() { A = 2, C = 56 }), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void Test12()
        {
            CBA myObject = new CBA()
            {
                A = 2,
                B = "svbaknvjns",
                C = 56,
            };
            var serializedBytes = Parser.SerializeObject(myObject);
            var deserializedObject = Parser.Deserialize<CBA>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(new CBA() { A = 2, C = 56 }), JsonConvert.SerializeObject(deserializedObject));
        }

        [Fact]
        public void Test13()
        {
            CBA myObject = new CBA()
            {
                A = 2,
                B = "B2",
                C = 56,
            };
            var serializedBytes = Parser.SerializeObject(myObject);
            var deserializedObject = Parser.Deserialize<CBA>(serializedBytes);
            Assert.Equal(JsonConvert.SerializeObject(myObject), JsonConvert.SerializeObject(deserializedObject));
        }
    }

    class CBA
    {
        [Tag(1)]
        public int A { get; set; }
        [Tag(2)]
        [ExactMatch(IgnoreLevel.Property, "B1", "B2")]
        public string B { get; set; }
        [Tag(3)]
        public int C { get; set; }
    }

    class ABC
    {
        [Tag(1)]
        public int A { get; set; }
        [Tag(2)]
        [ExactMatch(IgnoreLevel.Object, "B1", "B2")]
        public string B { get; set; }
        [Tag(3)]
        public int C { get; set; }
    }

    class ExtendedABC : ABC
    {
        [Tag(4)]
        [ExactMatch(IgnoreLevel.Object, "B1", "B2")]
        public string B2 { get; set; }
    }

    class ABC2
    {
        [Tag(1)]
        public int A { get; set; }
        [Tag(2)]
        public List<ABC> B { get; set; }
        [Tag(3)]
        public int C { get; set; }
    }
}
