using Newtonsoft.Json;
using System;
using System.Numerics;

namespace MPack
{
    [JsonConverter(typeof(NumericStringJsonConverter))]
    public class NumericString
    {
        public int LeadingZeros { get; private set; }
        public BigInteger BigNumber { get; private set; }

        public string Value => $"{new string('0', LeadingZeros)}{BigNumber.ToString()}";

        public static NumericString Parse(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new Exception($"expected numeric string but string is { (s == null ? "null" : "empty")}");
            }
            int leadingZeros = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '0')
                {
                    leadingZeros++;
                }
                else
                {
                    break;
                }
            }
            if (leadingZeros == s.Length)
            {
                leadingZeros--;
            }
            return new NumericString()
            {
                LeadingZeros = leadingZeros,
                BigNumber = BigInteger.Parse(s),
            };
        }

        public override string ToString() => Value;
    }
}
