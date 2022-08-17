using UnityEngine;

public class ReferenceExample : MonoBehaviour
{
    [Header("The dictionary can be referenced from another class")]
    [SerializeField] protected StringColorEnumDictionary m_EnumDictionary;
    [Space(10)]
    [SerializeField] States m_State;
    States m_OldState;
    [Space(10)]
    [SerializeField] Color m_Color;
    [SerializeField] string m_String;

    void Start()
    {
        GetData();
    }

    private void Update()
    {
        if (m_OldState == m_State) return;
        GetData();
    }

    public void GetData()
    {
        m_Color = m_EnumDictionary.GetValuesFromDictionary(m_State).Color;
        m_String = m_EnumDictionary.GetValuesFromDictionary(m_State).String;
        m_OldState = m_State;
    }
}
