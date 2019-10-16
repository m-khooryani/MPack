namespace MPack.Tests
{
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
