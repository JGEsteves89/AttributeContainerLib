using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttrContainerLib;
using System.IO;

namespace SerializationLib
{
    public interface ISerializer
    {
        void Serialize(IAttrContainer attrContainer, StreamReader streamReader);
        void Deserialize(IAttrContainer attrContainer, StreamWriter streamWriter);
        void Serialize(IAttr attrContainer, StreamReader streamReader);
        void Deserialize(IAttr attrContainer, StreamWriter streamWriter);
    }



}
