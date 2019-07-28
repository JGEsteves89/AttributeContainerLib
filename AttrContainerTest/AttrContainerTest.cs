using System;
using System.Collections.Generic;
using AttrContainerLib;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AttrContainerLibTest
{
    [TestClass]
    public class AttrContainerTest
    {
        [TestMethod]
        public void AttrContainerName()
        {
            AttrContainer ac = new AttrContainer("AttrName", "AttrContainer");
            Attr<string> aName = (Attr<string>)ac.GetAttribute("name");

            Assert.AreEqual("AttrName", aName.Value);
        }

        [TestMethod]
        public void AddAttr()
        {
            AttrContainer ac = new AttrContainer("AttrName", "AttrContainer");

            Attr<string> aString = new Attr<string>("StringAttribute", "value");
            Attr<int> aInt = new Attr<int>("IntAttribute", 123);

            ac.AddAttribute(aString);
            ac.AddAttribute(aInt);

            Assert.AreEqual("value", ((Attr<string>)ac.GetAttribute("StringAttribute")).Value);
            Assert.AreEqual(123, ((Attr<int>)ac.GetAttribute("IntAttribute")).Value);
        }

        [TestMethod]
        public void ChangeValueAttr()
        {
            AttrContainer ac = new AttrContainer("AttrName", "AttrContainer");
            Attr<string> aName = (Attr<string>)ac.GetAttribute("name");

            Assert.AreEqual("AttrName", ((Attr<string>)ac.GetAttribute("name")).Value);
            Assert.AreEqual("AttrName", aName.Value);

            aName.Value = "NewName";

            Assert.AreEqual("NewName", ((Attr<string>)ac.GetAttribute("name")).Value);
            Assert.AreEqual("NewName", aName.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Collections.Generic.KeyNotFoundException))]
        public void KeyNotFound()
        {
            AttrContainer ac = new AttrContainer("AttrName", "AttrContainer");
            Attr<int> aInt = ac.GetAttribute("notFound") as Attr<int>;
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException), "An item with the same key has already been added.")]
        public void DuplicatedKey()
        {
            AttrContainer ac = new AttrContainer("AttrName", "AttrContainer");
            ac.AddAttribute(new Attr<string>("name", "NewName"));
        }

        [TestMethod]
        public void AttrContainerOfAttrContainer()
        {
            AttrContainer ac = new AttrContainer("root", "AttrContainer");

            AttrContainer acChild1 = new AttrContainer("Attrchild1", "AttrContainer");
            AttrContainer acChild2 = new AttrContainer("Attrchild2", "AttrContainer");

            ac.AddAttribute(new Attr<AttrContainer>("child1", acChild1));
            ac.AddAttribute(new Attr<AttrContainer>("child2", acChild2));

            Assert.AreEqual("child1", ((Attr<AttrContainer>)ac.GetAttribute("child1")).Name);
            Assert.AreEqual("child2", ((Attr<AttrContainer>)ac.GetAttribute("child2")).Name);

            Assert.AreEqual("Attrchild1", ((ac.GetAttribute("child1") as Attr<AttrContainer>).Value.GetAttribute("name") as Attr<string>).Value);
            Assert.AreEqual("Attrchild2", ((ac.GetAttribute("child2") as Attr<AttrContainer>).Value.GetAttribute("name") as Attr<string>).Value);
        }

        [TestMethod]
        public void GetAttributeList()
        {
            AttrContainer ac = new AttrContainer("AttrName", "AttrContainer");
            ac.AddAttribute(new Attr<string>("StringAttribute", "value"));
            ac.AddAttribute(new Attr<int>("IntAttribute", 123));

            List<IAttr> list = ac.Attributes.ToList();
            Assert.AreEqual(4, list.Count);
            foreach (IAttr item in list)
            {
                Assert.IsNotNull(item.Name);
                Assert.IsNotNull(item.Type);

            }
        }
    }
}
