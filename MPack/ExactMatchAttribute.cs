using System;
using System.Collections.Generic;

namespace MPack
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ExactMatchAttribute : Attribute
    {
        public string[] Matches { private set; get; }
        public IgnoreLevel IgnoreLevel { private set; get; }

        public ExactMatchAttribute(IgnoreLevel ignoreLevel, string firstMatch, params string[] otherMatches)
        {
            this.IgnoreLevel = ignoreLevel;
            var s = new List<string>() { firstMatch };
            s.AddRange(otherMatches);
            this.Matches = s.ToArray();
        }
    }
}
