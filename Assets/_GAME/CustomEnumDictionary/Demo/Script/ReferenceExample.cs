/*
    Written By Mehmet Doğan 2022
    
*/
using MD.EnumDictionary;
using MD.EnumDictionary.Extensions;
using UnityEngine;

public class ReferenceExample : MonoBehaviour
{
    [Header("Can be referenced from another class")]
    [SerializeField] protected StringColorEnumDictionary m_EnumDictionary;
    [SerializeField] Color m_Color;
    [SerializeField] string m_String;

    void Start()
    {
        m_Color = m_EnumDictionary.GetValuesFromDictionary(States.State2).Color;
        m_String = m_EnumDictionary.GetValuesFromDictionary(States.State2).String;
    }
}
