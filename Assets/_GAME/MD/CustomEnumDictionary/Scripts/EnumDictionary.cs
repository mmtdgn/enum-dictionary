/*
 * Written by Mehmet Doğan <mmt.dgn.6634@gmail.com>, July 2022
*/
using System;
using System.Collections.Generic;
using UnityEngine;
using MD.EnumDictionary.Extensions;

namespace MD.EnumDictionary
{
    public abstract class EnumDictionary<T, T1, T2> : MonoBehaviour where T : Enum, IConvertible
    {
        [HideInInspector] private T key;
        [HideInInspector] private T1 val1;
        [HideInInspector] private T2 val2;

        public List<EnumDictionaryBase<T, T1, T2>> D1;

        /// <summary>
        /// Base class method for enum dictionary<br></br><br></br>
        /// <b>Returns</b> Enum length
        /// </summary>
        public int EnumLenght()
        {
            return System.Enum.GetNames(typeof(T)).Length;
        }

        /// <summary>
        /// Generate empty dictionary by enum length<br></br><br></br>
        /// </summary>
        public void ReOrder()
        {
            D1.Clear();

            for (int i = 0; i < EnumLenght(); i++)
            {
                D1.Add(new EnumDictionaryBase<T, T1, T2>(key, val1, val2));
                SetterUp(i);
            }
        }

        /// <summary>
        /// Checks enum lenghts and updates<br></br><br></br>
        /// </summary>
        public void DictionaryLenghtCheck()
        {
            while (D1.Count != EnumLenght())
            {
                if (D1.Count > EnumLenght())
                    D1.RemoveAt(EnumLenght() - 1);
                else if (D1.Count < EnumLenght())
                    D1.Add(new EnumDictionaryBase<T, T1, T2>(key, val1, val2));
            }
            for (int i = 0; i < D1.Count; i++)
            {
                SetterUp(i);
            }
        }

        /// <summary>
        /// Set default dictionary values<br></br><br></br>
        /// </summary>
        private void SetterUp(int index)
        {
            D1[index].key = (T)(object)index;
            D1[index].IsEnumFieldEditable = true;
            D1[index].name = " ";//Clear Element index name/ (R&D: `String.Empty` Not working?)
        }

        /// <summary>
        /// Returns dictionary values by given enum key<br></br><br></br>
        /// <b>Returns</b> First and second value
        /// </summary>
        public (T1 FirstValue, T2 SecondValue) GetValues(T key)
        {
            return (D1.GetFirstValue(key), D1.GetSecondValue(key));
        }

        /// <summary>
        /// Returns dictionary values by given index<br></br><br></br>
        /// <b>Returns</b> First and second value
        /// </summary>

        public (T1 FirstValue, T2 SecondValue) GetValues(int index)
        {
            T key = (T)(object)index;
            return (D1.GetFirstValue(key), D1.GetSecondValue(key));
        }

        /// <summary>
        /// Setter for dictionary values.<br></br><br></br>
        /// </summary>
        /// <param name="key">Key for which enum data will be set</param>
        /// <param name="value1">New first value to write to dictionary</param>
        public void SetValues(T key, T1 value1)
        {
            D1.SetFirstValue(key, value1);
        }

        /// <summary>
        /// Setter for dictionary values.<br></br><br></br>
        /// </summary>
        /// <param name="key">Key for which enum data will be set</param>
        /// <param name="value2">New second value to write to dictionary</param>
        public void SetValues(T key, T2 value2)
        {
            D1.SetSecondValue(key, value2);
        }

        /// <summary>
        /// Set default dictionary values<br></br><br></br>
        /// </summary>
        public virtual void OnValidate()
        {
            if (EnumLenght() == 0)
                ReOrder();
            DictionaryLenghtCheck();
        }
    }
}