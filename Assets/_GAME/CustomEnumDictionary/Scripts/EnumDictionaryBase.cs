using System;

namespace MD.EnumDictionary
{
    [Serializable]
    public class EnumDictionaryBase<Tkey, Tval1, Tval2> where Tkey : Enum
    {
        public string name;
        public Tkey key;
        public Tval1 val1;
        public Tval2 val2;
        public bool IsEnumFieldEditable;

        public EnumDictionaryBase(Tkey tkey, Tval1 tval1, Tval2 tval2)
        {
            name = " ";
            this.key = tkey;
            this.val1 = tval1;
            this.val2 = tval2;
            IsEnumFieldEditable = false;
        }
    }
}