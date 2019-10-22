namespace MPack.Tests
{
    public class TestClass
    {
        [Tag(60)]
        public int A { get; set; }
        [Tag(61)]
        public NumericString B { get; set; }
        [Tag(62)]
        public int C { get; set; }
    }


    public class TestClass2
    {
        [Tag(0)]
        public int A { get; set; }
        [Tag(20)]
        public string A1 { get; set; }
        [Tag(1)]
        [Hex]
        public string B { get; set; }
        [Tag(2)]
        public int C { get; set; }
    }
}
