using MD.EnumDictionary;
using UnityEngine;

public class StringColorEnumDictionary : EnumDictionary<States, string, Color>
{
    public (string String, Color Color) GetValuesFromDictionary(States key)
    {
        return (GetValues(key).FirstValue, GetValues(key).SecondValue);
    }
}