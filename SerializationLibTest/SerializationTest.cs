using System;
using AttrContainerLib;
using SerializationLib;
using UnitTestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace SerializationLibTest
{
    public class DummySerializer : ISerializer
    {
        public void Deserialize(IAttrContainer attrContainer, StreamWriter streamWriter)
        {
            foreach (IAttr attr in attrContainer.Attributes)
            {
                Deserialize(attr, streamWriter);
            }
  
        }

        public void Deserialize(Attr<int> attr, StreamWriter streamWriter)
        {
            streamWriter.WriteLine($"{{{attr.Name}:{attr.Type}:{attr.Value.ToString()}}}");
        }

        public void Deserialize(Attr<string> attr, StreamWriter streamWriter)
        {
            streamWriter.WriteLine($"{{{attr.Name}:{attr.Type}:{attr.Value}}}");
        }

        public void Deserialize(IAttr attr, StreamWriter streamWriter)
        {
            IAttrContainer container = (attr as Attr<AttrContainer>).Value;
            streamWriter.WriteLine($"{{{attr.Name}:{attr.Type}:}}");
            Deserialize(container, streamWriter);
            streamWriter.WriteLine($"}}");
        }

        public void Serialize(IAttrContainer attrContainer, StreamReader streamReader)
        {
            throw new NotImplementedException();
        }

        public void Serialize(IAttr attrContainer, StreamReader streamReader)
        {
            throw new NotImplementedException();
        }

    }
    [TestClass]
    public class SerializationTest
    {

        [TestMethod]
        public void AttrContainerSerialization()
        {
            DummySerializer dummySerializer = new DummySerializer();

            AttrContainer ac = new AttrContainer("AttrName", "AttrContainer");

            ac.AddAttribute(new Attr<string>("StringAttribute", "value"));
            ac.AddAttribute(new Attr<int>("IntAttribute", 123));

            using (var file = new TemporaryFile())
            {
                using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(file.FileInfo.FullName))
                {
                    dummySerializer.Deserialize(ac, streamWriter);
                }
            }



        }
    }
}
