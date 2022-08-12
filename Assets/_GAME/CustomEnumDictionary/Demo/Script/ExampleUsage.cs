using System;
using System.Collections;
using System.Collections.Generic;
using MD.EnumDictionary;
using MD.EnumDictionary.Extensions;
using UnityEngine;

public class ExampleUsage : EnumDictionary.GameobjectVector3Dict
{
    private IEnumerator Start()
    {
        Debug.Log($"Objects spawning from dictionary...", this.gameObject);
        yield return new WaitForSeconds(1f);
        for (var i = 0; i < EnumLenght(); i++)
        {
            InstantiateObj((States)i);
            Debug.Log($"{Enum.GetName(typeof(States), (States)i)} Object spawned!");
            yield return new WaitForSeconds(1f);
        }
    }

    private void InstantiateObj(States key)
    {
        Instantiate(GetValues(key).GO, GetValues(key).SpawnPoint, Quaternion.identity);
    }

    private (GameObject GO, Vector3 SpawnPoint) GetValues(States key)
    {
        return (_T1.GetFirstValue(key), _T1.GetSecondValue(key));
    }
}
