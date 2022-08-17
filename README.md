# Custom Enum Dictionary
Custom Enum Dictionary that allow you declare your own dictionary to manage your data.

## Explanation
This is the Generic Class list containing the Enum key and its values. It's serializable and provides a better UX to manage data. 
Returns values with the given enum key. So, it works similarly to Dictionary and I call it `custom enum dictionary`.

## Benefits
- Serializable dictionary  
- No need to cast to integers with this tool. We can store integer data with enum-dictionary. It also allows different enum keys to be equal to the same integer value. (normally C# not allows that)  
- There are 2 return value types. can be increased  
- Dictionary length updates itself by enum length. 'Add' and 'Remove' are not allowed. Each enum value is automatically serialized  

<b>Reorderable Serialized Enum Dictionary</b><br>

|Example 1| Example 2|
|---|---|
|<img src="/.github/screenshots/I2.png">|<img src="/.github/screenshots/ExampleUsage.png"/>|

## Usage
  1. Define your own enum  
  2. Inherit from the 'EnumDictionary' abstract class into your own class by declaring Dictionary value types. (look at examples)  
  3. Set your data from Inspector and it's ready to use.   
  
* (!) If add a new state to your enum, its updates itself by enum length  
  
### Beware! 
* Enum integer values must be default (0,1,2....)  

## Enum Dictionary Base Variables
| Name            | Description                                          |
| --------------- | ---------------------------------------------------- |
| name            | Name of each element of dictionary elements          |
| key             | (Generic Type Parameter) (enum) Key for dictionary   |
| val1            | (Generic Type Parameter) First Dictionary value      |
| val2            | (Generic Type Parameter) Second Dictionary value     |

## Enum Dictionary
| Name                    |  Description                                |
| ----------------------- | ------------------------------------------- | 
| EnumLenght()            | Returns given `T` type enum's lenght        |
| DictionaryLenghtCheck() | Called by `OnValidate()`automatically. Checks enum length and updates it|
| GetValues(T)            | Returns dictionary values by given enum key |
| SetValues(T , T1)       | Set first dictionary value                  |
| SetValues(T , T2)       | Set second dictionary values                |
| ReOrder()               | Initializer and reorderer for dictionary    |
| D1                      | Custom Dictionary field                     |

```C
public class ExampleUsage : EnumDictionary<States, GameObject, Vector3> { }
```

## Enum Dictionary Extensions
| Extension                  | Returns        | Args                   |Description                                          |
| -------------------------- | -------------- | ------ |-------------------------------------------------------------------- |
| GetValuesType<T, T1, T2>   | `T1` , `T2`    | `T`    | Returns first and second values types |
| GetValues<T, T1, T2>       | `T1` , `T2`    | `T`    | Returns first and second values |
| GetFirstValue<T, T1, T2>   | `T1`           | `T`    | Returns first value with given enum key    |
| GetSecondValue<T, T1, T2>  | `T2`           | `T`    | Returns second value with given enum key   |
| SetFirstValue<T, T1, T2>   |                | `T` , `T1`  | Set first value with given enum key   |
| SetSecondValue<T, T1, T2>  |                | `T` , `T2`  | Set second value with given enum key   |
| Reorder<T, T1, T2>         |                |        | Update dictionary. Called by `OnValidate()`|

## Initiliaze Reorderable List

This is a custom inspector. So for use this inspector, declare your class at `CustomEditor` attribute(Look at example).
### Usage

| 1. Click "Edit Dictionary" button to serialize the dictionary  |  2. Click "Init & Reset" button to Initiliaze the dictionary | 3. Set data and ready to use! |
|:---:|:---:|:---:|
| <img src="/.github/screenshots/I0.png">  |  <img src="/.github/screenshots/I1.png"> | <img src="/.github/screenshots/I2.png"> |

## Dictionary Auto update

### Dictionary automatically updates itself when add a new key to your `Enum` and keeps existing data

|public enum States { State1, State2, State3, State4 };|public enum States { State1, State2, State3, State4, State5 };|
|:---:|:---:|
| <img src="/.github/screenshots/I3.png">  |  <img src="/.github/screenshots/I4.png"> |

-------------------------------------------------------------------------------------------------------------------

## Example Usage of Enum Dictionary

### Instantiating objects with enum dictionary data
Gameobject value is prefab.  
Vector3 value is spawn position.

|Inspector|
|---|
|<img src="/.github/screenshots/ExampleUsage.png"/>|

### Code

```c
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
```
--------------------------------------------------------------------------------------------------------
|Output|
|---|
|<img src="/.github/screenshots/ExampleEditor.png">|
