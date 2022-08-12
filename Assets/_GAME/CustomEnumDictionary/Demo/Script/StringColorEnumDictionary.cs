using System.Collections.Generic;
using MD.EnumDictionary.Extensions;
using UnityEngine;

namespace MD.EnumDictionary
{
    public class StringColorEnumDictionary : EnumDictionary.StringColorDict
    {
        private void Start()
        {
            Debug.Log(GetString(States.State1));
            Debug.Log(GetColor(States.State2));
        }
        private string GetString(States key)
        {
            //return _T1[(int)key].val1;
            return _T1.GetFirstValue(key);
        }
        private Color GetColor(States key)
        {
            //return _T1[(int)key].val2;
            return _T1.GetSecondValue(key);
        }
    }
}