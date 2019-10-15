using System;

namespace MPack
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NFirstItemsAttribute : Attribute
    {
        public int N { get; private set; }

        public NFirstItemsAttribute(int n)
        {
            this.N = n;
        }
    }
}
