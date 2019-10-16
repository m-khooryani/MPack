using Newtonsoft.Json;
using System;
using System.Linq;
using System.Numerics;

namespace MPack
{
    [JsonConverter(typeof(NumericStringJsonConverter))]
    public class NumericString
    {
        public int LeadingZeros { get; private set; }
        public BigInteger BigNumber { get; private set; }

        public string Value
        {
            get
            {
                int v = GetStrType(_value);
                bool condition = GetStrType(_value) > 2;
                if (v == 2)
                {
                    return $"{Prefix}{BigNumber.ToString()}";
                }
                return condition ? $"{new string('0', LeadingZeros)}{BigNumber.ToString()}" : _value;
            }
        }
        public string Prefix { get; private set; }

        private string _value;
        public static NumericString Parse(string s)
        {
            int v = GetStrType(s);
            if (v > 2)
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
                    _value = s,
                };
            }
            else if(v == 2)
            {
                int index = GetNumericStringIndex(s);
                return new NumericString()
                {
                    LeadingZeros = 0,
                    _value = s,
                    Prefix = s.Substring(0, index),
                    BigNumber = BigInteger.Parse(s.Substring(index)),
                };
            }
            return new NumericString()
            {
                LeadingZeros = 0,
                _value = s,
            };
        }

        static int GetNumericStringIndex(string value)
        {
            if(!char.IsDigit(value[value.Length - 1]))
            {
                return -1;
            }
            int index = 0;
            bool ok = false;
            for (int i = value.Length - 1; i >= 0; i--)
            {
                if (!char.IsDigit(value[i]))
                {
                    index = i + 1;
                    break;
                }
                if(value[i] != '0')
                {
                    ok = true;
                }
            }
            if (!ok)
            {
                return -1;
            }
            while (value[index] == '0')
            {
                index++;
            }
            return index;
        }

        public int GetStrType()
        {
            var value = Value;
            return GetStrType(value);
        }

        private static int GetStrType(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 1;
            }
            if (value.All(ch => char.IsNumber(ch)))
            {
                if (value.StartsWith("0"))
                {
                    return 4;
                }
                else
                {
                    return 3;
                }
            }
            int index = GetNumericStringIndex(value);
            if(index < value.Length / 2 && index >= 0)
            {
                return 2;
            }
            return 1;
        }

        public override string ToString() => Value;
    }
}
