using System.Collections.Generic;
using UnityEngine;

namespace MD.EnumDictionary
{
    public enum States { State1, State2, State3, State4, State5 };
    public enum Direction { Backward, Forward, Right, Left, Up, Down };

    //For each combination of variable types, a new abstract class must be declared and the target enum type set.\\
    public class EnumDictionary
    {
        public abstract class StringIntDict : EDictInitializer<States, string, int> { }
        public abstract class StringFloatDict : EDictInitializer<States, string, float> { }
        public abstract class StringColorDict : EDictInitializer<States, string, Color> { }
        public abstract class StringTransformDict : EDictInitializer<States, string, Transform> { }
        public abstract class StringGameObjectDict : EDictInitializer<States, string, GameObject> { }
        public abstract class StringAnimationDict : EDictInitializer<States, string, Animation> { }
        public abstract class GameobjectVector3Dict : EDictInitializer<States, GameObject, Vector3> { }
        public abstract class ObjectEnumDict : EDictInitializer<States, Object, Direction> { }
        //--------------------------------------------------------------------------------------------------------------\\
        public abstract class GameobjectAnimationDict : EDictInitializer<Direction, GameObject, Animation> { }
        public abstract class StringAnimationDictT2 : EDictInitializer<Direction, string, Animation> { }
    }
    //--------------------------------------------------------------------------------------------------------------\\
    //custom usage
    public class EnumDictionaryCustom
    {
        public interface IStringColorDict { public List<EnumDictionaryBase<States, string, Color>> ESC_D { get; } }
        public interface IStringFloatDict { public List<EnumDictionaryBase<States, string, float>> ESF_D { get; } }
        public interface IStringIntDict { public List<EnumDictionaryBase<States, string, int>> ESI_D { get; } }
        public interface IStringTransformDict { public List<EnumDictionaryBase<States, string, Transform>> EST_D { get; } }
        public interface IDirectionAudioDict { public List<EnumDictionaryBase<States, Direction, AudioClip>> EEA_D { get; } }

        //--------------------------------------------------------------------------------------------------------------\\
    }
}