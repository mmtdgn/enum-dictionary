using System.Collections.Generic;
using MD.EnumDictionary;
using MD.EnumDictionary.Extensions;
using UnityEngine;

public class ExampleImplementation : EnumDictionary.StringIntDict, EnumDictionaryCustom.IStringColorDict,
EnumDictionaryCustom.IStringTransformDict, EnumDictionaryCustom.IDirectionAudioDict
{
    [SerializeField] protected List<EnumDictionaryBase<States, string, Color>> m_ESC_D;
    public List<EnumDictionaryBase<States, string, Color>> ESC_D => m_ESC_D;

    [SerializeField] protected List<EnumDictionaryBase<States, string, Transform>> m_EST_D;
    public List<EnumDictionaryBase<States, string, Transform>> EST_D => m_EST_D;

    [SerializeField] protected List<EnumDictionaryBase<States, Direction, AudioClip>> m_EEA_D;
    public List<EnumDictionaryBase<States, Direction, AudioClip>> EEA_D => m_EEA_D;

    void Start()
    {
        Debug.Log(_T1.GetValues(States.State2).Value1);//Returns values by given enum key.
        // Debug.Log(_T1.GetSecondValue(States.State2));
        // Debug.Log(_T1.GetValues(States.State2));
        // Debug.Log(_T1.GetValues(States.State2).Value1);
        // Debug.Log(_T1.GetValues(States.State2).Value2);
    }

    //Required for auto serialization based on enum length.
    public override void OnValidate()
    {
        //The Dictionary updates whenever you add a new item to the dictionary.(not required if only abstract class is used.)
        base.OnValidate();
        //for interfaces
        m_ESC_D.ReOrder();
        m_EST_D.ReOrder();
        EEA_D.ReOrder();
    }
}
