using System;
using System.Collections;
using MD.EnumDictionary;
using UnityEngine;

public class ExampleUsage : EnumDictionary<States, GameObject, Vector3>
{
    private IEnumerator Start()
    {
        Debug.Log($"Objects spawning from dictionary...", this.gameObject);
        yield return new WaitForSeconds(1f);
        for (var i = 0; i < EnumLenght(); i++)
        {
            InstantiateObj((States)i);
            Debug.Log($"{Enum.GetName(typeof(States), (States)i)} => {GetValues(i).FirstValue.name} spawned!");
            yield return new WaitForSeconds(1f);
        }
    }

    private void InstantiateObj(States key)
    {
        Instantiate(GetDictionaryValues(key).GO, GetDictionaryValues(key).SpawnPoint, Quaternion.identity);
    }

    private (GameObject GO, Vector3 SpawnPoint) GetDictionaryValues(States key)
    {
        return (GetValues(key).FirstValue, GetValues(key).SecondValue);
    }
}
