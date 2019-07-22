using System;
using System.Collections.Generic;

namespace MPack.Tests
{
    public class MyClass
    {
        [Tag(0)]
        public int SampleInt { get; set; }
        [Tag(1)]
        public byte SampleByte { get; set; }
        [Tag(2)]
        public int[] ArrayOfInt { get; set; }
        [Tag(3)]
        public string SampleString { get; set; }
        [Tag(4)]
        public DateTime SampleDate { get; set; }
        [Tag(5)]
        public Guid SampleGuid { get; set; }
        [Tag(6)]
        public List<int> SampleListInt { get; set; }
        [Tag(7)]
        public HashSet<int> SampleIntSet { get; set; }
        [Tag(8)]
        public KeyValuePair<int, string> SampleKVPIntString { get; set; }
        [Tag(9)]
        public KeyValuePair<string, int> SampleKVPStringInt { get; set; }
        [Tag(10)]
        public KeyValuePair<int[], string> SampleKVPArrayIntString { get; set; }
        [Tag(11)]
        public Days SampleEnum { get; set; }
        [Tag(12)]
        public int? SampleNullableInt { get; set; }
        [Tag(102)]
        public MyClass2 SampleObject { get; set; }
        [Tag(103)]
        public MyClass2[] SampleComplexArray { get; set; }
        [Tag(104)]
        public List<MyClass2> SampleComplexList { get; set; }
    }

    public enum Days
    { 
        Day1,
        Day2,
        Day3,
        Day4,
    }

    public class MyClass2
    {
        [Tag(0)]
        public int SampleInt { get; set; }
        [Tag(1)]
        public byte SampleByte { get; set; }
        [Tag(2)]
        public int[] ArrayOfInt { get; set; }
        [Tag(3)]
        public string SampleString { get; set; }
        [Tag(4)]
        public DateTime SampleDate { get; set; }
        [Tag(5)]
        public Guid SampleGuid { get; set; }
        [Tag(6)]
        public List<int> ListOfInt { get; set; }
        [Tag(7)]
        public HashSet<int> SetOfInt { get; set; }
        [Tag(8)]
        public KeyValuePair<int, string> SampleKVPIntString { get; set; }
        [Tag(9)]
        public KeyValuePair<string, int> SampleKVPStringInt { get; set; }
        [Tag(10)]
        public KeyValuePair<int[], string> SampleKVPArrayOfIntString { get; set; }
        [Tag(11)]
        public Days SampleOfEnum { get; set; }
        [Tag(12)]
        public int? SampleNullableInt { get; set; }
    }
}
