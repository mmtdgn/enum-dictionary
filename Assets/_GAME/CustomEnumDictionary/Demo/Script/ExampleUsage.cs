using MD.EnumDictionary;
using MD.EnumDictionary.Extensions;
using UnityEngine;

public class ExampleUsage : MonoBehaviour
{
    [Header("Can be referenced from another class")]
    [SerializeField] protected StringColorEnumDictionary EnumDict;

    void Start()
    {
        Debug.Log($"First Argument is : {EnumDict._T1.GetValuesType().Item1} Second Argument is : {EnumDict._T1.GetValuesType().Item2}");
    }
    private Color GetStateColor()
    {
        return EnumDict._T1.GetSecondValue(States.State1);
    }
}
