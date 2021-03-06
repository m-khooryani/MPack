﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace MPack
{
    public class Parser
    {
        public static T Deserialize<T>(byte[] input) where T : new()
        {
            T t = new T();
            T item1 = (T)DeserilizeObject(input, 0, t, input.Length).Item1;
            return item1;
        }

        public static object Deserialize(byte[] serializedBytes, Type type)
        {
            object instance = Activator.CreateInstance(type);
            var deserializedObject = DeserilizeObject(serializedBytes, 0, instance, serializedBytes.Length).Item1;
            return deserializedObject;
        }

        public static byte[] SerializeObject(object objjj)
        {
            var type = objjj.GetType();
            CheckTypeValidation(type);
            PropertyInfo[] propertyInfos = type.GetProperties();

            List<byte> bytes = new List<byte>();
            if (NotAllowdToSerialize(objjj))
            {
                return bytes.ToArray();
            }
            foreach (var propertyInfo in propertyInfos)
            {
                bool isSimple = IsSimple(propertyInfo.PropertyType);
                bool serialize = true;
                foreach (var attribute in propertyInfo.GetCustomAttributes(true))
                {
                    if (attribute is IgnoreAttribute myAttribute)
                    {
                        serialize = false;
                    }
                    else if( attribute is ExactMatchAttribute exactMatch && exactMatch.IgnoreLevel == IgnoreLevel.Property)
                    {
                        string value = propertyInfo.GetValue(objjj, null)?.ToString();
                        if (!exactMatch.Matches.Any(x => x == value))
                        {
                            serialize = false;
                        }
                    }
                }
                if (serialize)
                {
                    foreach (var attribute in propertyInfo.GetCustomAttributes(true))
                    {
                        if (attribute is TagAttribute myAttribute)
                        {
                            var x = propertyInfo.GetValue(objjj);
                            byte tag = myAttribute.Tag;
                            if (x == null)
                            {
                                continue;
                            }
                            bytes.Add(tag);
                            var bytessss = SerializeProperty(x, propertyInfo);
                            bytes.AddRange(bytessss);
                        }
                    }
                }
            }
            return bytes.ToArray();
        }

        private static void CheckTypeValidation(Type type)
        {
            PropertyInfo[] propertyInfos = type.GetProperties();
            Dictionary<byte, PropertyInfo> keyValuePairs = new Dictionary<byte, PropertyInfo>();
            foreach (var propertyInfo in propertyInfos)
            {
                foreach (var attribute in propertyInfo.GetCustomAttributes(true))
                {
                    if (attribute is TagAttribute tagAttribute)
                    {
                        if (keyValuePairs.ContainsKey(tagAttribute.Tag))
                        {
                            throw new Exception($"duplicate tag found. tag: {tagAttribute.Tag}, properties: {keyValuePairs[tagAttribute.Tag].ToString()}, {propertyInfo.ToString()}");
                        }
                        keyValuePairs.Add(tagAttribute.Tag, propertyInfo);
                    }
                }
            }
        }


        public static byte[] GetBytes<T>(byte[] input, PropertyInfo propertyInfo, int iiiiiii)
        {
            var type = typeof(T);
            CheckTypeValidation(type);
            List<byte> bytess = new List<byte>();
            int index = 0;
            PropertyInfo[] propertyInfos = type.GetProperties();
            var fgg = type.GetProperties().SelectMany(x => x.GetCustomAttributes(true).Where(y => y is TagAttribute));
            Dictionary<PropertyInfo, TagAttribute> dictionary = new Dictionary<PropertyInfo, TagAttribute>();

            foreach (var pi in propertyInfos)
            {
                object obj = pi.GetCustomAttributes(true).Where(x => x is TagAttribute).FirstOrDefault();
                if (obj is TagAttribute myAttribute)
                {
                    dictionary.Add(pi, myAttribute);
                }
            }
            for (int i = 0; i < propertyInfos.Length;)
            {
                if (index >= input.Length)
                {
                    break;
                }
                if (!dictionary.Any(x => x.Value.Tag == input[index]))
                {
                    index++;
                    int length = GetLength(input, index);
                    var bytes = input.Skip(index).Take(length).ToArray();
                    index += length;
                    int stringLength = (int)GetObjectFromByteArray2(bytes, typeof(int));
                    index += stringLength;
                    continue;
                }
                i++;
                var pInfo = dictionary.Where(x => x.Value.Tag == input[index]).FirstOrDefault().Key;
                bool deserialize = true;

                foreach (var attribute in pInfo.GetCustomAttributes(true))
                {
                    if (attribute is IgnoreAttribute myAttribute)
                    {
                        deserialize = false;
                    }
                }
                if (!deserialize)
                {
                    continue;
                }
                foreach (var attribute in pInfo.GetCustomAttributes(true))
                {
                    if (attribute is TagAttribute myAttribute)
                    {
                        bytess.Add(myAttribute.Tag);
                        if (fgg.Any(x => (x as TagAttribute).Tag == input[index]))
                        {
                            index++;
                            Func<byte[], int, Type, Tuple<object, List<int>>> deserilizer = FunctionProvider(pInfo.PropertyType);
                            var sss = deserilizer(input, index, pInfo.PropertyType);
                            if (propertyInfo == pInfo)
                            {
                                //iiiiiii++;
                                int xcv = GetLength(input, sss.Item2[iiiiiii]) + sss.Item2[iiiiiii];
                                var bytesss = input.Skip(xcv).Take(sss.Item2[iiiiiii + 1] - (xcv)).ToArray();
                                return bytesss;
                            }
                            if (sss.Item1 != null)
                            {
                                if (pInfo.PropertyType.IsGenericType && pInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                                {
                                    //pInfo.SetValue(t, sss.Item1, null);
                                }
                                else
                                {
                                    //pInfo.SetValue(t, System.Convert.ChangeType(sss.Item1, pInfo.PropertyType), null);
                                }
                            }
                            index = sss.Item2.Last();
                        }
                    }
                }
            }
            throw new NotImplementedException();
        }


        private static byte[] SerializeProperty(object x, PropertyInfo propertyInfo = null)
        {
            var propertyType = x.GetType();
            bool isSimple = IsSimple(propertyType);
            List<byte> bytes = new List<byte>();
            if (propertyType.Equals(typeof(string)))
            {
                var array = GetByteArrayFromString(x.ToString(), propertyInfo);
                byte[] byteArray = GetByteArrayFromPrimitiveObject2(array.Length, typeof(int));
                bytes.AddRange(byteArray);
                bytes.AddRange(array);
            }
            else if (propertyType.Equals(typeof(NumericString)))
            {
                var numericString = x as NumericString;
                int strType = numericString.GetStrType();
                if (strType == 1)
                {
                    var array = GetByteArrayFromString(x.ToString());
                    byte[] byteArray = GetByteArrayFromPrimitiveObject2(array.Length + 1, typeof(int));
                    bytes.AddRange(byteArray);
                    bytes.Add(1);
                    bytes.AddRange(array);
                }
                else if (strType == 2)
                {
                    string prefix = numericString.Prefix;
                    byte[] byteArray = GetByteArrayFromString(prefix);
                    byte[] byteArray2 = GetByteArrayFromPrimitiveObject2(byteArray.Length, typeof(int));
                    byte[] byteArray4 = GetByteArrayFromPrimitiveObject(numericString.BigNumber, numericString.BigNumber.GetType());
                    byte[] byteArray3 = GetByteArrayFromPrimitiveObject2(byteArray2.Length + byteArray4.Length + byteArray.Length + 1, typeof(int));
                    bytes.AddRange(byteArray3);
                    bytes.Add(2);
                    bytes.AddRange(byteArray2);
                    bytes.AddRange(byteArray);
                    bytes.AddRange(byteArray4);
                }
                else if (strType == 3)
                {
                    byte[] byteArray = GetByteArrayFromPrimitiveObject(numericString.BigNumber, numericString.BigNumber.GetType());
                    byte[] byteArray3 = GetByteArrayFromPrimitiveObject2(byteArray.Length + 1, typeof(int));
                    bytes.AddRange(byteArray3);
                    bytes.Add(3);
                    bytes.AddRange(byteArray);
                }
                else if (strType == 4)
                {
                    byte[] byteArray2 = GetByteArrayFromPrimitiveObject2(numericString.LeadingZeros, typeof(int));
                    byte[] byteArray = GetByteArrayFromPrimitiveObject(numericString.BigNumber, numericString.BigNumber.GetType());
                    byte[] byteArray3 = GetByteArrayFromPrimitiveObject2(byteArray2.Length + byteArray.Length + 1, typeof(int));
                    bytes.AddRange(byteArray3);
                    bytes.Add(4);
                    bytes.AddRange(byteArray2);
                    bytes.AddRange(byteArray);
                }
            }
            else if (propertyType.Equals(typeof(Guid)))
            {
                var array = ((Guid)x).ToByteArray();
                byte[] byteArray = GetByteArrayFromPrimitiveObject2(array.Length, typeof(int));
                bytes.AddRange(byteArray);
                bytes.AddRange(array);
            }
            else if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition().Equals(typeof(KeyValuePair<,>)))
            {
                object kvpKey = propertyType.GetProperty("Key").GetValue(x, null);
                object kvpValue = propertyType.GetProperty("Value").GetValue(x, null);
                var keyByteArray = (kvpKey != null) ? SerializeProperty(kvpKey) : new byte[0];
                var valueByteArray = (kvpValue != null) ? SerializeProperty(kvpValue) : new byte[0];
                var keyLengthByteArray = GetByteArrayFromPrimitiveObject2(keyByteArray.Length, typeof(int));
                var valueLengthByteArray = GetByteArrayFromPrimitiveObject2(valueByteArray.Length, typeof(int));
                byte[] byteArray2 = GetByteArrayFromPrimitiveObject2(keyByteArray.Length + valueByteArray.Length + keyLengthByteArray.Length + valueLengthByteArray.Length, typeof(int));
                bytes.AddRange(byteArray2);
                bytes.AddRange(keyLengthByteArray);
                bytes.AddRange(keyByteArray);
                bytes.AddRange(valueLengthByteArray);
                bytes.AddRange(valueByteArray);
            }
            else if (propertyType.IsEnum)
            {
                byte[] byteArray = GetByteArrayFromPrimitiveObject((int)x, typeof(int));
                byte[] byteArray2 = GetByteArrayFromPrimitiveObject2(byteArray.Length, typeof(int));
                bytes.AddRange(byteArray2);
                bytes.AddRange(byteArray);
            }
            else if (isSimple)
            {
                byte[] byteArray = GetByteArrayFromPrimitiveObject(x, propertyType);
                byte[] byteArray2 = GetByteArrayFromPrimitiveObject2(byteArray.Length, typeof(int));
                bytes.AddRange(byteArray2);
                bytes.AddRange(byteArray);
            }
            else if (propertyType.IsArray)
            {
                var array = (Array)x;
                int n = int.MaxValue;
                var nItemsAttribute = propertyInfo?.GetCustomAttributes(typeof(NFirstItemsAttribute)) ?? null;
                if (nItemsAttribute != null && nItemsAttribute.Count() != 0)
                {
                    n = ((NFirstItemsAttribute)nItemsAttribute.First()).N;
                }
                List<byte> tempList = new List<byte>();
                int count = 0;
                foreach (var item in array)
                {
                    if (count == n)
                    {
                        break;
                    }
                    if (NotAllowdToSerialize(item))
                    {
                        continue;
                    }
                    var bytesss = SerializeProperty(item);
                    tempList.AddRange(bytesss);
                    count++;
                }
                byte[] byteArray = GetByteArrayFromPrimitiveObject2(count, typeof(int));
                bytes.AddRange(GetByteArrayFromPrimitiveObject2(byteArray.Length + tempList.Count, typeof(int)));
                bytes.AddRange(byteArray);
                bytes.AddRange(tempList);
            }
            else if (propertyType.IsNonStringEnumerable())
            {
                var enumer = (IEnumerable)x;
                int n = int.MaxValue;
                var nItemsAttribute = propertyInfo.GetCustomAttributes(typeof(NFirstItemsAttribute));
                if (nItemsAttribute != null && nItemsAttribute.Count() != 0)
                {
                    n = ((NFirstItemsAttribute)nItemsAttribute.First()).N;
                }
                List<byte> tempList = new List<byte>();
                int count = 0;
                foreach (var item in enumer)
                {
                    if (count == n)
                    {
                        break;
                    }
                    if (NotAllowdToSerialize(item))
                    {
                        continue;
                    }
                    var bytesss = SerializeProperty(item);
                    tempList.AddRange(bytesss);
                    count++;
                }
                byte[] byteArray = GetByteArrayFromPrimitiveObject2(count, typeof(int));
                bytes.AddRange(GetByteArrayFromPrimitiveObject2(byteArray.Length + tempList.Count, typeof(int)));
                bytes.AddRange(byteArray);
                bytes.AddRange(tempList);
            }
            else
            {
                byte[] byteArray = SerializeObject(x);
                byte[] byteArray2 = GetByteArrayFromPrimitiveObject2(byteArray.Length, typeof(int));
                bytes.AddRange(byteArray2);
                bytes.AddRange(byteArray);
            }
            return bytes.ToArray();
        }

        private static bool NotAllowdToSerialize(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }

            PropertyInfo[] propertyInfo1 = obj.GetType().GetProperties().ToArray();
            if(propertyInfo1 == null || propertyInfo1.Length == 0)
            {
                return false;
            }
            foreach (var propertyInfo in propertyInfo1)
            {
                ExactMatchAttribute exactMatchAttribute = propertyInfo.GetCustomAttribute<ExactMatchAttribute>();
                if (exactMatchAttribute != null && exactMatchAttribute.IgnoreLevel == IgnoreLevel.Object)
                {
                    string value = propertyInfo.GetValue(obj, null)?.ToString();
                    if (!exactMatchAttribute.Matches.Any(x => x == value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static byte[] GetByteArrayFromString(string v, PropertyInfo propertyInfo = null)
        {
            if (propertyInfo != null)
            {
                if (propertyInfo.GetCustomAttribute<HexAttribute>() != null)
                {
                    var hex = v;
                    byte[] bytes = new byte[hex.Length >> 1];
                    for (int i = 0; i < hex.Length; i += 2)
                    {
                        bytes[i >> 1] = Convert.ToByte(hex.Substring(i, 2), 16);
                    }
                    return bytes;
                }
            }
            if (string.IsNullOrEmpty(v))
            {
                return new byte[] { 0 };
            }
            return Encoding.UTF8.GetBytes(v);
        }

        public static byte[] GetBytes<T>(byte[] input, PropertyInfo propertyInfo)
        {
            var type = typeof(T);
            CheckTypeValidation(type);
            List<byte> bytess = new List<byte>();
            int index = 0;
            PropertyInfo[] propertyInfos = type.GetProperties();
            var fgg = type.GetProperties().SelectMany(x => x.GetCustomAttributes(true).Where(y => y is TagAttribute));
            Dictionary<PropertyInfo, TagAttribute> dictionary = new Dictionary<PropertyInfo, TagAttribute>();

            foreach (var pi in propertyInfos)
            {
                object obj = pi.GetCustomAttributes(true).Where(x => x is TagAttribute).FirstOrDefault();
                if (obj is TagAttribute myAttribute)
                {
                    dictionary.Add(pi, myAttribute);
                }
            }
            for (int i = 0; i < propertyInfos.Length;)
            {
                if (index >= input.Length)
                {
                    break;
                }
                if (!dictionary.Any(x => x.Value.Tag == input[index]))
                {
                    index++;
                    int length = GetLength(input, index);
                    var bytes = input.Skip(index).Take(length).ToArray();
                    index += length;
                    int stringLength = (int)GetObjectFromByteArray2(bytes, typeof(int));
                    index += stringLength;
                    continue;
                }
                i++;
                var pInfo = dictionary.Where(x => x.Value.Tag == input[index]).FirstOrDefault().Key;
                bool deserialize = true;

                foreach (var attribute in pInfo.GetCustomAttributes(true))
                {
                    if (attribute is IgnoreAttribute myAttribute)
                    {
                        deserialize = false;
                    }
                }
                if (!deserialize)
                {
                    continue;
                }
                foreach (var attribute in pInfo.GetCustomAttributes(true))
                {
                    if (attribute is TagAttribute myAttribute)
                    {
                        bytess.Add(myAttribute.Tag);
                        if (fgg.Any(x => (x as TagAttribute).Tag == input[index]))
                        {
                            index++;
                            Func<byte[], int, Type, Tuple<object, List<int>>> deserilizer = FunctionProvider(pInfo.PropertyType);
                            var sss = deserilizer(input, index, pInfo.PropertyType);
                            if (propertyInfo == pInfo)
                            {

                            }
                            if (sss.Item1 != null)
                            {
                                if (pInfo.PropertyType.IsGenericType && pInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                                {
                                    //pInfo.SetValue(t, sss.Item1, null);
                                }
                                else
                                {
                                    //pInfo.SetValue(t, System.Convert.ChangeType(sss.Item1, pInfo.PropertyType), null);
                                }
                            }
                            index = sss.Item2.Last();
                        }
                    }
                }
            }
            throw new NotImplementedException();
        }

        private static Tuple<object, List<int>> DeserilizeObject(byte[] input, int startIndex, object t, int LENGTH)
        {
            var type = t.GetType();
            CheckTypeValidation(type);
            int index = startIndex;
            PropertyInfo[] propertyInfos = type.GetProperties();
            var attributes = type.GetProperties().SelectMany(x => x.GetCustomAttributes(true).Where(y => y is TagAttribute));
            Dictionary<PropertyInfo, TagAttribute> dictionary = new Dictionary<PropertyInfo, TagAttribute>();

            foreach (var propertyInfo in propertyInfos)
            {
                object obj = propertyInfo.GetCustomAttributes(true).Where(x => x is TagAttribute).FirstOrDefault();
                if (obj is TagAttribute myAttribute)
                {
                    dictionary.Add(propertyInfo, myAttribute);
                }
            }
            for (int i = 0; i < propertyInfos.Length;)
            {
                if (index >= input.Length || (index - startIndex >= LENGTH))
                {
                    break;
                }
                if (!dictionary.Any(x => x.Value.Tag == input[index]))
                {
                    index++;
                    int length = GetLength(input, index);
                    var bytes = input.Skip(index).Take(length).ToArray();
                    index += length;
                    int stringLength = (int)GetObjectFromByteArray2(bytes, typeof(int));
                    index += stringLength;
                    continue;
                }
                i++;
                var propertyInfo = dictionary.Where(x => x.Value.Tag == input[index]).FirstOrDefault().Key;
                bool deserialize = true;

                foreach (var attribute in propertyInfo.GetCustomAttributes(true))
                {
                    if (attribute is IgnoreAttribute myAttribute)
                    {
                        deserialize = false;
                    }
                }
                if (!deserialize)
                {
                    continue;
                }
                foreach (var attribute in propertyInfo.GetCustomAttributes(true))
                {
                    if (attribute is TagAttribute myAttribute)
                    {
                        if (attributes.Any(x => (x as TagAttribute).Tag == input[index]))
                        {
                            index++;
                            Func<byte[], int, Type, Tuple<object, List<int>>> deserilizer = FunctionProvider(propertyInfo.PropertyType, propertyInfo);
                            var sss = deserilizer(input, index, propertyInfo.PropertyType);
                            if (sss.Item1 != null)
                            {
                                if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                                {
                                    propertyInfo.SetValue(t, sss.Item1, null);
                                }
                                else
                                {
                                    propertyInfo.SetValue(t, Convert.ChangeType(sss.Item1, propertyInfo.PropertyType), null);
                                }
                            }
                            index = sss.Item2.Last();
                        }
                    }
                }
            }
            return new Tuple<object, List<int>>(t, new List<int>() { index });
        }

        private static Type GetCollectionElementType(Type type)
        {
            if (type.Equals(typeof(string)))
            {
                return typeof(string);
            }
            return type.GetGenericArguments()[0];
        }

        private static Type GetArrayElementType(Type type)
        {
            if (type.Equals(typeof(string)))
            {
                return typeof(string);
            }
            return type.GetElementType();
        }

        private static int GetLength(byte[] input, int index)
        {
            int length = 1;
            int iii = index;
            while ((input[iii] & 1) > 0)
            {
                iii++;
                length++;
            }
            return length;
        }

        private static Tuple<object, List<int>> ReadEnumerable(byte[] input, int arrayLength, int index, Type type, Type propertyType)
        {
            List<int> indices = new List<int>() { index };
            Func<object> _genericTemporaryCollectionCreator = CreateDefaultConstructor<object>(type);
            var list = (IList)CreateWrapper(_genericTemporaryCollectionCreator(), propertyType);
            for (int i = 0; i < arrayLength; i++)
            {
                Func<byte[], int, Type, Tuple<object, List<int>>> f = FunctionProvider(propertyType);
                var sss = f(input, index, propertyType);
                list.Add(sss.Item1);
                index = sss.Item2.Last();
                indices.Add(index);
            }
            return new Tuple<object, List<int>>(list, indices);
        }

        private static Tuple<object, List<int>> ReadArray(byte[] input, int arrayLength, int index, Type propertyType)
        {
            List<int> indices = new List<int>();
            var array = Array.CreateInstance(propertyType, arrayLength);
            indices.Add(index);
            for (int i = 0; i < arrayLength; i++)
            {
                Func<byte[], int, Type, Tuple<object, List<int>>> f = FunctionProvider(propertyType);
                var sss = f(input, index, propertyType);
                array.SetValue(sss.Item1, i);
                index = sss.Item2.Last();
                indices.Add(index);
            }
            return new Tuple<object, List<int>>(array, indices);
        }

        private static Func<byte[], int, Type, Tuple<object, List<int>>> FunctionProvider(Type propertyType, PropertyInfo propertyInfo = null)
        {
            if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return FunctionProvider(propertyType.GetGenericArguments()[0]);
            }
            bool isSimple = IsSimple(propertyType);
            Func<byte[], int, Type, Tuple<object, List<int>>> f = null;
            if (propertyType.Equals(typeof(string)) && propertyInfo?.GetCustomAttribute<HexAttribute>() != null)
            {
                f = DeserializeHexString;
            }
            else if (propertyType.Equals(typeof(string)))
            {
                f = DeserializeString;
            }
            else if (propertyType.Equals(typeof(NumericString)))
            {
                f = DeserializeNumericString;
            }
            else if (propertyType.Equals(typeof(Guid)))
            {
                f = DeserializeGuid;
            }
            else if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition().Equals(typeof(KeyValuePair<,>)))
            {
                f = DeserializeKeyValuePair;
            }
            else if (propertyType.IsEnum)
            {
                f = DeserializeEnum;
            }
            else if (isSimple)
            {
                f = DeserializePrimitiveObject;
            }
            else if (propertyType.IsArray)
            {
                f = DeserializeArray;
            }
            else if (propertyType.IsNonStringEnumerable())
            {
                f = DeserializeCollection;
            }
            else
            {
                f = GetObject;
            }
            return f;
        }

        private static Tuple<object, List<int>> DeserializeKeyValuePair(byte[] input, int index, Type propertyType)
        {
            int length = GetLength(input, index);
            var bytes = input.Skip(index).Take(length).ToArray();
            index += length;
            int arrayLength2 = (int)GetObjectFromByteArray2(bytes, typeof(int));
            Tuple<object, List<int>> kjhk = new Tuple<object, List<int>>(null, new List<int>() { index });
            if (arrayLength2 > 0)
            {
                length = GetLength(input, index);
                bytes = input.Skip(index).Take(length).ToArray();
                index += length;
                arrayLength2 = (int)GetObjectFromByteArray2(bytes, typeof(int));
                Type keyType = propertyType.GetGenericArguments()[0];
                var ff = FunctionProvider(keyType);
                var key = arrayLength2 > 0 ? ff(input, index, keyType).Item1 : null;

                index += arrayLength2;
                length = GetLength(input, index);
                bytes = input.Skip(index).Take(length).ToArray();
                index += length;
                arrayLength2 = (int)GetObjectFromByteArray2(bytes, typeof(int));
                Type valueType = propertyType.GetGenericArguments()[1];
                ff = FunctionProvider(valueType);
                var val = arrayLength2 > 0 ? ff(input, index, valueType).Item1 : null;
                var keyValuePair = Activator.CreateInstance(propertyType, new[] { key, val });
                index += arrayLength2;
                kjhk = new Tuple<object, List<int>>(keyValuePair, new List<int>() { index });
            }
            return kjhk;
        }

        private static Tuple<object, List<int>> DeserializeGuid(byte[] input, int index, Type propertyType)
        {
            int length = GetLength(input, index);
            var bytes = input.Skip(index).Take(length).ToArray();
            index += length;
            int arrayLength2 = (int)GetObjectFromByteArray2(bytes, typeof(int));
            Tuple<object, List<int>> kjhk = new Tuple<object, List<int>>(null, new List<int>() { index });
            if (arrayLength2 > 0)
            {
                bytes = input.Skip(index).Take(arrayLength2).ToArray();
                index += arrayLength2;
                kjhk = new Tuple<object, List<int>>(new Guid(bytes), new List<int>() { index });
            }
            return kjhk;
        }

        private static Tuple<object, List<int>> DeserializeEnum(byte[] input, int index, Type propertyType)
        {
            int length = GetLength(input, index);
            var bytes = input.Skip(index).Take(length).ToArray();
            index += length;
            int arrayLength2 = (int)GetObjectFromByteArray2(bytes, typeof(int));
            Tuple<object, List<int>> kjhk = new Tuple<object, List<int>>(null, new List<int>() { index });
            if (arrayLength2 > 0)
            {
                bytes = input.Skip(index).Take(arrayLength2).ToArray();
                index += arrayLength2;
                kjhk = new Tuple<object, List<int>>(Enum.ToObject(propertyType, GetObjectFromByteArray(bytes, typeof(int))), new List<int>() { index });
            }
            return kjhk;
        }

        private static Tuple<object, List<int>> DeserializeString(byte[] input, int index, Type propertyType)
        {
            int length = GetLength(input, index);
            var bytes = input.Skip(index).Take(length).ToArray();
            index += length;
            int stringLength = (int)GetObjectFromByteArray2(bytes, typeof(int));
            string s = null;
            if (stringLength > 0)
            {
                bytes = input.Skip(index).Take(stringLength).ToArray();
                if (bytes.Length == 1 && bytes[0] == 0)
                {
                    s = "";
                }
                else
                {
                    s = Encoding.UTF8.GetString(bytes);
                }
                index += stringLength;
            }
            return new Tuple<object, List<int>>(s, new List<int>() { index });
        }

        private static Tuple<object, List<int>> DeserializeHexString(byte[] input, int index, Type propertyType)
        {
            int length = GetLength(input, index);
            var bytes = input.Skip(index).Take(length).ToArray();
            index += length;
            int stringLength = (int)GetObjectFromByteArray2(bytes, typeof(int));
            string s = "";
            if (stringLength > 0)
            {
                bytes = input.Skip(index).Take(stringLength).ToArray();
                string[] convertedToHexArray = bytes
                    .Select(x => x.ToString("X2"))
                    .ToArray();
                s = string.Join("", convertedToHexArray);
                index += stringLength;
            }
            return new Tuple<object, List<int>>(s, new List<int>() { index });
        }

        private static Tuple<object, List<int>> DeserializeNumericString(byte[] input, int index, Type propertyType)
        {
            int length = GetLength(input, index);
            var bytes = input.Skip(index).Take(length).ToArray();
            index += length;
            int stringLength = (int)GetObjectFromByteArray2(bytes, typeof(int));
            length = GetLength(input, index);
            int strType = input[index];
            StringBuilder stringBuilder = new StringBuilder();
            if (strType == 1)
            {
                bytes = input.Skip(index + 1).Take(stringLength - 1).ToArray();
                if (bytes.Length == 1 && bytes[0] == 0)
                {
                    stringBuilder.Append("");
                }
                else
                {
                    stringBuilder.Append(Encoding.UTF8.GetString(bytes));
                }
                index += stringLength;
            }
            else if (strType == 2)
            {
                index++;
                length = GetLength(input, index);
                bytes = input.Skip(index).Take(length).ToArray();
                int prefixLength = (int)GetObjectFromByteArray2(bytes, typeof(int));
                index += length;
                bytes = input.Skip(index).Take(prefixLength).ToArray();
                if (bytes.Length == 1 && bytes[0] == 0)
                {
                    stringBuilder.Append("");
                }
                else
                {
                    stringBuilder.Append(Encoding.UTF8.GetString(bytes));
                }
                index += prefixLength;
                int bigNumberLength = stringLength - (prefixLength + 1 + length);
                bytes = input.Skip(index).Take(bigNumberLength).ToArray();
                index += bigNumberLength;
                BigInteger bigInteger = GetBigDecimalFromBytes(bytes);
                stringBuilder.Append(bigInteger.ToString());
            }
            else if (strType == 3)
            {
                bytes = input.Skip(index + 1).Take(stringLength - 1).ToArray();
                BigInteger bigInteger = GetBigDecimalFromBytes(bytes);
                stringBuilder.Append(bigInteger.ToString());
                index += stringLength;
            }
            else if (strType == 4)
            {
                index++;
                length = GetLength(input, index);
                bytes = input.Skip(index).Take(length).ToArray();
                int leadingZeros = (int)GetObjectFromByteArray2(bytes, typeof(int));
                stringBuilder.Append(new string('0', leadingZeros));
                index += length;
                int numberOfBytes = stringLength - (length + 1);
                if (numberOfBytes > 0)
                {
                    bytes = input.Skip(index).Take(numberOfBytes).ToArray();
                    BigInteger bigInteger = GetBigDecimalFromBytes(bytes);
                    index += numberOfBytes;
                    stringBuilder.Append(bigInteger.ToString());
                }
            }
            return new Tuple<object, List<int>>(NumericString.Parse(stringBuilder.ToString()), new List<int>() { index });
        }

        private static Tuple<object, List<int>> GetObject(byte[] input, int index, Type propertyType)
        {
            int length = GetLength(input, index);
            var bytes = input.Skip(index).Take(length).ToArray();
            index += length;
            int objectLength = (int)GetObjectFromByteArray2(bytes, typeof(int));
            Tuple<object, List<int>> deserializedObject = new Tuple<object, List<int>>(null, new List<int>() { index });
            if (objectLength > 0)
            {
                var propertyTypeInstance = propertyType.Assembly.CreateInstance(propertyType.FullName);
                deserializedObject = DeserilizeObject(input, index, propertyTypeInstance, objectLength);
                index += objectLength;
            }
            return new Tuple<object, List<int>>(deserializedObject.Item1, new List<int>() { index });
        }

        private static Tuple<object, List<int>> DeserializeCollection(byte[] input, int index, Type propertyType)
        {
            int length = GetLength(input, index);
            var bytes = input.Skip(index).Take(length).ToArray();
            index += length;
            int arrayLength2 = (int)GetObjectFromByteArray2(bytes, typeof(int));
            length = GetLength(input, index);
            bytes = input.Skip(index).Take(length).ToArray();
            index += length;
            arrayLength2 = (int)GetObjectFromByteArray2(bytes, typeof(int));
            Tuple<object, List<int>> kjkj = ReadEnumerable(input, arrayLength2, index, propertyType, GetCollectionElementType(propertyType));
            var list23 = kjkj.Item1;
            object underlyingList = list23 is IWrappedCollection wrappedCollection ? wrappedCollection.UnderlyingCollection : list23;
            kjkj = new Tuple<object, List<int>>(underlyingList, kjkj.Item2);
            return kjkj;
        }

        private static Tuple<object, List<int>> DeserializeArray(byte[] input, int index, Type propertyType)
        {
            int length = GetLength(input, index);
            var bytes = input.Skip(index).Take(length).ToArray();
            index += length;
            int arrayLength2 = (int)GetObjectFromByteArray2(bytes, typeof(int));
            length = GetLength(input, index);
            bytes = input.Skip(index).Take(length).ToArray();
            index += length;
            arrayLength2 = (int)GetObjectFromByteArray2(bytes, typeof(int));
            Tuple<object, List<int>> kjkj = ReadArray(input, arrayLength2, index, GetArrayElementType(propertyType));
            var list23 = kjkj.Item1;
            object underlyingList = list23 is IWrappedCollection wrappedCollection ? wrappedCollection.UnderlyingCollection : list23;
            kjkj = new Tuple<object, List<int>>(underlyingList, kjkj.Item2);
            return kjkj;
        }

        private static Tuple<object, List<int>> DeserializePrimitiveObject(byte[] input, int index, Type propertyType)
        {
            int length = GetLength(input, index);
            var bytes = input.Skip(index).Take(length).ToArray();
            index += length;
            int arrayLength2 = (int)GetObjectFromByteArray2(bytes, typeof(int));
            Tuple<object, List<int>> kjhk = new Tuple<object, List<int>>(null, new List<int>(index));
            if (arrayLength2 > 0)
            {
                bytes = input.Skip(index).Take(arrayLength2).ToArray();
                index += arrayLength2;
                kjhk = new Tuple<object, List<int>>(GetObjectFromByteArray(bytes, propertyType), new List<int>() { index });
            }
            return kjhk;
        }

        private static object GetObjectFromByteArray(byte[] bytes, Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return GetObjectFromByteArray(bytes, type.GetGenericArguments()[0]);
            }
            var signBit = bytes.Last() & 1;
            int sign = signBit > 0 ? -1 : 1;
            if (type.Equals(typeof(string)))
            {
                return Encoding.UTF8.GetString(bytes);
            }
            else if (type.Equals(typeof(long)))
            {
                var a = GetDecimalFromBytes(bytes);
                return a * sign;
            }
            else if (type.Equals(typeof(int)))
            {
                var a = (int)GetDecimalFromBytes(bytes);
                return a * sign;
            }
            else if (type.Equals(typeof(byte)))
            {
                var a = (byte)GetDecimalFromBytes(bytes);
                return a;
            }
            else if (type.Equals(typeof(bool)))
            {
                return bytes[0] != 0;
            }
            else if (type.Equals(typeof(DateTime)))
            {
                long v = (long)GetObjectFromByteArray(bytes, typeof(long));
                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(v).ToLocalTime();
                return dateTimeOffset.DateTime;
            }
            throw new NotImplementedException();
        }

        private static object GetObjectFromByteArray2(byte[] bytes, Type type)
        {
            if (type.Equals(typeof(long)))
            {
                var a = GetDecimalFromBytes2(bytes);
                return a;
            }
            else if (type.Equals(typeof(int)))
            {
                var a = (int)GetDecimalFromBytes2(bytes);
                return a;
            }
            //else if (type.Equals(typeof(byte)))
            //{
            //    var a = (byte)GetDecimalFromBytes(bytes);
            //    return a;
            //}
            throw new NotImplementedException();
        }

        private static byte[] GetByteArrayFromPrimitiveObject2(object x, Type type)
        {
            if (type.Equals(typeof(long)))
            {
                long n = (long)x;
                var binary = Convert.ToString(Math.Abs(n), 2);
                byte[] bytes = GetBytes2(binary);
                return bytes;
            }
            else if (type.Equals(typeof(int)))
            {
                int n = (int)x;
                var binary = Convert.ToString((uint)Math.Abs(n), 2);
                byte[] bytes = GetBytes2(binary);
                return bytes;
            }
            throw new NotImplementedException();
        }

        private static byte[] GetByteArrayFromPrimitiveObject(object x, Type type)
        {
            if (type.Equals(typeof(string)))
            {
                return Encoding.UTF8.GetBytes(x.ToString());
            }
            else if (type.Equals(typeof(BigInteger)))
            {
                BigInteger ns = (BigInteger)x;
                var binary = ns.ToBinaryString();
                var bytes = GetBytes(binary, 1);
                return bytes;
            }
            else if (type.Equals(typeof(long)))
            {
                long n = (long)x;
                var binary = Convert.ToString(Math.Abs(n), 2);
                byte[] bytes = GetBytes(binary, Math.Sign(n));
                return bytes;
            }
            else if (type.Equals(typeof(int)))
            {
                int n = (int)x;
                var binary = Convert.ToString(Math.Abs((long)n), 2);
                byte[] bytes = GetBytes(binary, Math.Sign(n));
                return bytes;
            }
            else if (type.Equals(typeof(byte)))
            {
                byte n = (byte)x;
                var binary = Convert.ToString(Math.Abs(n), 2);
                byte[] bytes = GetBytes(binary, Math.Sign(n));
                return bytes;
            }
            else if (type.Equals(typeof(bool)))
            {
                bool b = (bool)x;
                byte[] bytes = new byte[] { b ? (byte)1 : (byte)0 };
                return bytes;
            }
            else if (type.Equals(typeof(DateTime)))
            {
                DateTime date = (DateTime)x;
                DateTime foo = date.ToUniversalTime();
                long unixTime = ((DateTimeOffset)foo).ToUnixTimeMilliseconds();
                return GetByteArrayFromPrimitiveObject(unixTime, typeof(long));
            }
            else if (type.Equals(typeof(char)))
            {
                char ch = (char)x;
                return new byte[]
                {
                    (byte)ch
                };
            }
            throw new NotImplementedException();
        }

        private static byte[] GetBytes2(string binary)
        {
            StringBuilder builder = new StringBuilder();
            List<string> allBInaries = new List<string>();
            for (int i = 0, j = binary.Length - 1; i < binary.Length; i++, j--)
            {
                if (builder.Length > 0 && builder.Length % 7 == 0 && j > 0)
                {
                    builder.Append('1');
                    allBInaries.Add(builder.ToString());
                    builder = builder.Clear();
                }
                builder.Append(binary[j]);
            }
            if (builder.Length % 8 == 0)
            {
                allBInaries.Add(builder.ToString().Substring(0, 7) + '1');
                char v = builder.ToString()[7];
                builder = builder.Clear().Append(v);
            }
            if (builder.Length % 8 == 0)
            {
                allBInaries.Add(builder.ToString());
                allBInaries.Add(new string('0', 8));
            }
            else
            {
                allBInaries.Add(builder.ToString().PadRight(8, '0'));
            }
            allBInaries[allBInaries.Count - 1] = allBInaries.Last().Remove(7) + '0';
            return allBInaries
                .Select(x => Convert.ToByte(x, 2))
                .ToArray();
        }

        private static byte[] GetBytes(string binary, int sign)
        {
            StringBuilder builder = new StringBuilder();
            List<string> allBInaries = new List<string>();
            for (int i = 0, j = binary.Length - 1; i < binary.Length; i++, j--)
            {
                builder.Append(binary[j]);
                if (builder.Length % 8 == 0)
                {
                    //builder.Append('1');
                    allBInaries.Add(builder.ToString());
                    builder = builder.Clear();
                }
            }
            if (builder.Length % 8 == 0 && builder.Length > 0)
            {
                allBInaries.Add(builder.ToString());
                builder = builder.Clear();
            }
            //builder.Append(sign >= 0 ? '0' : '1');
            allBInaries.Add(builder.ToString().PadRight(8, '0'));

            allBInaries[allBInaries.Count - 1] = allBInaries.Last().Remove(7) + (sign >= 0 ? '0' : '1');
            return allBInaries
                .Select(x => Convert.ToByte(x, 2))
                .ToArray();
        }

        private static string GetDecimalFromBinary(byte[] bytes)
        {
            StringBuilder builder = new StringBuilder(bytes.Length << 2);
            foreach (var @byte in bytes)
            {
                string value = System.Convert.ToString(@byte, 2).PadLeft(4, '0');
                builder.Append(value);
            }
            return builder.ToString();
        }

        private static long GetDecimalFromBytes2(byte[] bytes)
        {
            long s = 0L;
            int b = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (j != 7)
                    {
                        s += ((bytes[i] & (1 << (7 - j))) != 0 ? 1L : 0L) << b++;
                    }
                }
            }
            return s;
        }

        private static long GetDecimalFromBytes(byte[] bytes)
        {
            long s = 0L;
            int b = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == bytes.Length - 1 && j == 7)
                    {
                        break;
                    }
                    s += ((bytes[i] & (1 << (7 - j))) != 0 ? 1L : 0L) << b++;
                }
            }
            return s;
        }

        private static BigInteger GetBigDecimalFromBytes(byte[] bytes)
        {
            BigInteger s = 0;
            int b = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == bytes.Length - 1 && j == 7)
                    {
                        break;
                    }
                    if((bytes[i] & (1 << (7 - j))) != 0)
                    {
                        s += BigInteger.Pow(2, b);
                    }
                    //s += ((bytes[i] & (1 << (7 - j))) != 0 ? 1L : 0L) << b++;
                    b++;
                }
            }
            return s;
        }

        private static bool IsSimple(Type type)
        {
            var typeInfo = type.GetTypeInfo();
            if (typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                // nullable type, check if the nested type is simple.
                return IsSimple(typeInfo.GetGenericArguments()[0]);
            }
            return typeInfo.IsPrimitive
              || typeInfo.IsEnum
              //|| type.Equals(typeof(string))
              || typeInfo.Equals(typeof(DateTime))
              || type.Equals(typeof(decimal));
        }


        private static Expression BuildMethodCall(MethodBase method, Type type, ParameterExpression targetParameterExpression, ParameterExpression argsParameterExpression)
        {
            ParameterInfo[] parametersInfo = method.GetParameters();

            Expression[] argsExpression;
            IList<ByRefParameter> refParameterMap;
            if (parametersInfo.Length == 0)
            {
                argsExpression = ArrayEmpty<Expression>();
                refParameterMap = ArrayEmpty<ByRefParameter>();
            }
            else
            {
                argsExpression = new Expression[parametersInfo.Length];
                refParameterMap = new List<ByRefParameter>();

                for (int i = 0; i < parametersInfo.Length; i++)
                {
                    ParameterInfo parameter = parametersInfo[i];
                    Type parameterType = parameter.ParameterType;
                    bool isByRef = false;
                    if (parameterType.IsByRef)
                    {
                        parameterType = parameterType.GetElementType();
                        isByRef = true;
                    }

                    Expression indexExpression = Expression.Constant(i);

                    Expression paramAccessorExpression = Expression.ArrayIndex(argsParameterExpression, indexExpression);

                    Expression argExpression = EnsureCastExpression(paramAccessorExpression, parameterType, !isByRef);

                    if (isByRef)
                    {
                        ParameterExpression variable = Expression.Variable(parameterType);
                        refParameterMap.Add(new ByRefParameter { Value = argExpression, Variable = variable, IsOut = parameter.IsOut });

                        argExpression = variable;
                    }

                    argsExpression[i] = argExpression;
                }
            }

            Expression callExpression;
            if (method.IsConstructor)
            {
                callExpression = Expression.New((ConstructorInfo)method, argsExpression);
            }
            else if (method.IsStatic)
            {
                callExpression = Expression.Call((MethodInfo)method, argsExpression);
            }
            else
            {
                Expression readParameter = EnsureCastExpression(targetParameterExpression, method.DeclaringType);

                callExpression = Expression.Call(readParameter, (MethodInfo)method, argsExpression);
            }

            if (method is MethodInfo m)
            {
                if (m.ReturnType != typeof(void))
                {
                    callExpression = EnsureCastExpression(callExpression, type);
                }
                else
                {
                    callExpression = Expression.Block(callExpression, Expression.Constant(null));
                }
            }
            else
            {
                callExpression = EnsureCastExpression(callExpression, type);
            }

            if (refParameterMap.Count > 0)
            {
                IList<ParameterExpression> variableExpressions = new List<ParameterExpression>();
                IList<Expression> bodyExpressions = new List<Expression>();
                foreach (ByRefParameter p in refParameterMap)
                {
                    if (!p.IsOut)
                    {
                        bodyExpressions.Add(Expression.Assign(p.Variable, p.Value));
                    }

                    variableExpressions.Add(p.Variable);
                }

                bodyExpressions.Add(callExpression);

                callExpression = Expression.Block(variableExpressions, bodyExpressions);
            }

            return callExpression;
        }
        public delegate object ObjectConstructor<T>(params object[] args);
        internal static IWrappedCollection CreateWrapper(object list, Type collectionItemType)
        {
            var _genericWrapperType = typeof(CollectionWrapper<>).MakeGenericType(collectionItemType);

            Type constructorArgument;

            //if (ReflectionUtils.InheritsGenericDefinition(_genericCollectionDefinitionType, typeof(List<>))
            //    || _genericCollectionDefinitionType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                constructorArgument = typeof(ICollection<>).MakeGenericType(collectionItemType);
            }
            //else
            //{
            //    constructorArgument = _genericCollectionDefinitionType;
            //}

            ConstructorInfo genericWrapperConstructor = _genericWrapperType.GetConstructor(new[] { constructorArgument });
            var _genericWrapperCreator = CreateParameterizedConstructor(genericWrapperConstructor);

            return (IWrappedCollection)_genericWrapperCreator(list);

            throw new NotImplementedException();
        }
        public static T[] ArrayEmpty<T>()
        {
            T[] array = Enumerable.Empty<T>() as T[];
            Debug.Assert(array != null);
            // Defensively guard against a version of Linq where Enumerable.Empty<T> doesn't
            // return an array, but throw in debug versions so a better strategy can be
            // used if that ever happens.
#pragma warning disable CA1825 // Avoid zero-length array allocations.
            return array ?? new T[0];
#pragma warning restore CA1825 // Avoid zero-length array allocations.
        }
        public static ObjectConstructor<object> CreateParameterizedConstructor(MethodBase method)
        {

            Type type = typeof(object);

            ParameterExpression argsParameterExpression = Expression.Parameter(typeof(object[]), "args");

            Expression callExpression = BuildMethodCall(method, type, null, argsParameterExpression);

            LambdaExpression lambdaExpression = Expression.Lambda(typeof(ObjectConstructor<object>), callExpression, argsParameterExpression);

            ObjectConstructor<object> compiled = (ObjectConstructor<object>)lambdaExpression.Compile();
            return compiled;
        }
        private static Expression EnsureCastExpression(Expression expression, Type targetType, bool allowWidening = false)
        {
            Type expressionType = expression.Type;

            // check if a cast or conversion is required
            if (expressionType == targetType || (!expressionType.IsValueType && targetType.IsAssignableFrom(expressionType)))
            {
                return expression;
            }

            if (targetType.IsValueType)
            {
                Expression convert = Expression.Unbox(expression, targetType);

                if (allowWidening && targetType.IsPrimitive)
                {
                    MethodInfo toTargetTypeMethod = typeof(Convert)
                        .GetMethod("To" + targetType.Name, new[] { typeof(object) });

                    if (toTargetTypeMethod != null)
                    {
                        convert = Expression.Condition(
                            Expression.TypeIs(expression, targetType),
                            convert,
                            Expression.Call(toTargetTypeMethod, expression));
                    }
                }

                return Expression.Condition(
                    Expression.Equal(expression, Expression.Constant(null, typeof(object))),
                    Expression.Default(targetType),
                    convert);
            }

            return Expression.Convert(expression, targetType);
        }
        private static Func<T> CreateDefaultConstructor<T>(Type type)
        {

            // avoid error from expressions compiler because of abstract class
            if (type.IsAbstract)
            {
                return () => (T)Activator.CreateInstance(type);
            }

            try
            {
                Type resultType = typeof(T);

                Expression expression = Expression.New(type);

                expression = EnsureCastExpression(expression, resultType);

                LambdaExpression lambdaExpression = Expression.Lambda(typeof(Func<T>), expression);

                Func<T> compiled = (Func<T>)lambdaExpression.Compile();
                return compiled;
            }
            catch
            {
                // an error can be thrown if constructor is not valid on Win8
                // will have INVOCATION_FLAGS_NON_W8P_FX_API invocation flag
                return () => (T)Activator.CreateInstance(type);
            }
        }

    }
}
