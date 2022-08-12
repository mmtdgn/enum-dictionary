using System;
using System.Collections.Generic;
using UnityEngine;

namespace MD.EnumDictionary.Extensions
{
    public static class EnumDictionaryExtension
    {
        public static (Type, Type) GetValuesType<T, T1, T2>(this List<EnumDictionaryBase<T, T1, T2>> list) where T : Enum { return (typeof(T1), typeof(T2)); }
        public static T1 GetFirstValue<T, T1, T2>(this List<EnumDictionaryBase<T, T1, T2>> list, T key) where T : Enum { return list[(int)(object)key].val1; }
        public static T2 GetSecondValue<T, T1, T2>(this List<EnumDictionaryBase<T, T1, T2>> list, T key) where T : Enum { return list[(int)(object)key].val2; }

        public static void ReOrder<T, T1, T2>(this List<EnumDictionaryBase<T, T1, T2>> _T1) where T : Enum
        {
            int EnumLenght()
            {
                return System.Enum.GetNames(typeof(T)).Length;
            }

            void ReOrder()
            {
                while (_T1.Count != EnumLenght())
                {
                    if (_T1.Count > EnumLenght())
                        _T1.RemoveAt(EnumLenght() - 1);
                    else if (_T1.Count < EnumLenght())
                        _T1.Add(new EnumDictionaryBase<T, T1, T2>
                        (_T1[0].key, _T1[0].val1, _T1[0].val2));
                }

                for (int i = 0; i < EnumLenght(); i++)
                {
                    _T1[i].key = (T)(object)i;
                    _T1[i].IsStaticKey = true;
                    _T1[i].name = " ";
                }
            }

            ReOrder();
        }

    }
}

