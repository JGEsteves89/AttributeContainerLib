using System;
using System.Collections.Generic;
using System.Text;

namespace AttrContainerLib
{
    public class Attr<TValue> : IAttr
    {
        public string Name { get; set; }
        public TValue Value { get; set; }
        public TValue DefaultValue { get; set; }

        public string Type {
            get { return typeof(TValue).ToString(); }
        }

        public Attr(string name, TValue defaultValue)
        {
            Name = name;
            DefaultValue = defaultValue;
            Value = defaultValue;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
