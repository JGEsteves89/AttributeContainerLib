using System;
using AttrContainerLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AttrContainerLibTest
{
    public class ObjectTest: AttrContainer
    {
        public ObjectTest(bool child = false) : base("ObjectTest", "ObjectTest")
        {
            AddAttribute(new Attr<string>("Value1", "This is the value 1"));
            AddAttribute(new Attr<int>("Value2", 2));
            if (child)
                AddAttribute(new Attr<ObjectTest>("otChild", new ObjectTest()));
        }
    }

    [TestClass]
    public class AttrObjectTest
    {
        [TestMethod]
        public void ObjectTest()
        {
            ObjectTest ot = new ObjectTest(true);

            Assert.AreEqual("ObjectTest", ot.Name);
            Assert.AreEqual("This is the value 1", (ot.GetAttribute("Value1") as Attr<string>).Value);
            Assert.AreEqual(2, (ot.GetAttribute("Value2") as Attr<int>).Value);
        }
        [TestMethod]
        public void ObjectOfObject()
        {
            ObjectTest ot = new ObjectTest(true);

            Assert.AreEqual("ObjectTest", (ot.GetAttribute("name") as Attr<string>).Value);
            Assert.AreEqual("ObjectTest", (ot.GetAttribute("name") as Attr<string>).Value);

        }
    }
}
