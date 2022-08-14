# Custom Enum Dictionary
Custom Enum Dictionary that allow you declare your own dictionary to manage your data.

<b>Reorderable Serialized Enum Dictionary</b><br>
<img src="/.github/screenshots/I2.png">

## Usage
1. Only one dictionary usage  
  a. Define your own enum  
  b. Create an `abstract class` and inherit by `EDictInitiliazer` class and declare your value types.(Look at examples)  
  c. Inherit this base class to any desired class. Dictionary defined and serialized by base class. (it is also derived from monobehaviour)  
  d. Set your data from Inspector and it's ready to use.  
2. Multi-Conditional usage  
  a. Define your own enum  
  b. Create an `Interface` and define `EnumDictionaryBase` list property  
  c. Implement any other class. For auto serialization by enum length. Call `RecOrder()` extension at `OnValidate()`  
  d. Set your data from Inspector and it's ready to use  
  
3. (!) If add a new state to your enum, its updates itself by enum length  
  
### Beware! 
  Enum integer values must be default (0,1,2....)  
  No need for integer casting with this tool. Declare your one of values as integer also different enum keys can equal the same integer(and other types) dictionary value  

## Enum Dictionary Base Variables
| Name            | Description                                          |
| --------------- | ---------------------------------------------------- |
| name            | Name of each element of dictionary elements          |
| key             | (Generic Type Parameter) (enum) Key for dictionary   |
| val1            | (Generic Type Parameter) First Dictionary value      |
| val2            | (Generic Type Parameter) Second Dictionary value     |

## Enum Dictionary Initializer
### Methods
| Name                    |  Description                              |
| ----------------------- | ----------------------------------------- |
| EnumLenght()            | Returns given `T` type enum's lenght      |
| DictionaryLenghtCheck() | Called by `OnValidate()`automatically. Checks enum length and updates it|
| ReOrder()               | Initializer and reorderer for dictionary  |


## Enum Dictionary Extensions
| Extension                  | Returns        | Args                   |Description                                          |
| -------------------------- | -------------- | ------ |-------------------------------------------------------------------- |
| GetValuesType<T, T1, T2>   | `T1` , `T2`    | `T`    | Returns first and second values types |
| GetValuesType<T, T1, T2>   | `T1` , `T2`    | `T`    | Returns first and second values |
| GetFirstValue<T, T1, T2>   | `T1`           | `T`    | Returns first value with given enum key    |
| GetSecondValue<T, T1, T2>  | `T2`           | `T`    | Returns second value with given enum key   |
| SetFirstValue<T, T1, T2>   |                | `T` , `T1`  | Set first value with given enum key   |
| SetSecondValue<T, T1, T2>  |                | `T` , `T2`  | Set second value with given enum key   |
| ReOrder<T, T1, T2>         |                |        | Update dictionary. Called by `OnValidate()`|

## Initiliaze Reorderable List

This is a custom inspector. So for use this inspector, declare your class type at `CustomEditor` attribute(Look at example).
### Usage

| 1. Click "Edit Dictionary" button to serialize the dictionary  |  2. Click "Init & Reset" button to Initiliaze the dictionary | 3. Set data and ready to use! |
|:---:|:---:|:---:|
| <img src="/.github/screenshots/I0.png">  |  <img src="/.github/screenshots/I1.png"> | <img src="/.github/screenshots/I2.png"> |

## Dictionary Auto update

### Dictionary automatically updates itself when add a new key to your `Enum` and keeps existing data

|public enum States { State1, State2, State3, State4 };|public enum States { State1, State2, State3, State4, State5 };|
|:---:|:---:|
| <img src="/.github/screenshots/I2.png">  |  <img src="/.github/screenshots/I4.png"> |


## Example Usage of Enum Dictionary

### Instantiating objects with enum dictionary data
Gameobject value is prefab.  
Vector3 value is spawn position.

<img src="/.github/screenshots/ExampleUsage.png"/>

### Code

```c
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
```
### Output
<img src="/.github/screenshots/ExampleEditor.png">

## Interface Implementation

### if more than one dictionaries are needed, the interface implementation should be used
This tool has a handicap for interfaces. `ReOrder()` extension must be called manually in `OnValidate()` for auto serialization based on enum length

<img src="/.github/screenshots/Interface.png"/>

```c
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
        Debug.Log(_T1.GetValues(States.State2).Value1);
    }

    public override void OnValidate()
    {
        base.OnValidate();
        m_ESC_D.ReOrder();
        m_EST_D.ReOrder();
        EEA_D.ReOrder();
    }
}
```

