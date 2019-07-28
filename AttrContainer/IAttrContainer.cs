using System.Collections.Generic;

namespace AttrContainerLib
{
    public interface IAttrContainer
    {
        string Name {
            get;
        }

        string Type {
            get;
        }

        IEnumerable<IAttr> Attributes {
            get;
        }

        void AddAttribute(IAttr attr);
        IAttr GetAttribute(string key);

    }
}