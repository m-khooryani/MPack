using System;

namespace MPack
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TagAttribute : Attribute
    {
        public byte Tag { private set; get; }

        public TagAttribute(byte tag)
        {
            this.Tag = tag;
        }
    }
}
