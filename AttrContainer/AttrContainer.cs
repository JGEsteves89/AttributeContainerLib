using System;
using System.Collections;
using System.Collections.Generic;

namespace AttrContainerLib
{
    public class AttrContainer : IAttrContainer
    {
        private Dictionary<string, IAttr> Attrs = new Dictionary<string, IAttr>();

        public AttrContainer(string name, string type)
        {
            AddAttribute(new Attr<string>("name", name));
            AddAttribute(new Attr<string>("type", type));
        }

        public void AddAttribute(IAttr attr)
        {
            Attrs.Add(attr.Name, attr);
        }

        public IAttr GetAttribute(string key)
        {
            return Attrs[key];
        }

        public string Name {
            get { return (GetAttribute("name") as Attr<string>).Value; }
        }
        public string Type {
            get { return (GetAttribute("type") as Attr<string>).Value; }
        }

        public IEnumerable<IAttr> Attributes {
            get { return Attrs.Values; }
        }

    }
}
