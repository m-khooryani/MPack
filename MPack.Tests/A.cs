using System.Collections.Generic;

namespace MPack.Tests
{
    public class A
    {
        [Tag(250)]
        public List<B> List { get; set; }
        [Tag(251)]
        public int ZZ { get; set; }
    }

    public class B
    {
        [Tag(252)]
        public int X { get; set; }
        [Tag(253)]
        public string Y { get; set; }
    }

    public class C : B
    {
        [Tag(254)]
        public string Password { get; set; }
    }

    public class D : B
    {

    }
}
