using MD.EnumDictionary;
using MD.EnumDictionary.Extensions;
using UnityEngine;

public class StringColorEnumDictionary : EnumDictionary.StringColorDict
{
    public (string String, Color Color) GetValuesFromDictionary(States key)
    {
        //return (_T1[(int)key].val1, _T1[(int)key].val2);
        return (_T1.GetFirstValue(key), _T1.GetSecondValue(key));
    }
}