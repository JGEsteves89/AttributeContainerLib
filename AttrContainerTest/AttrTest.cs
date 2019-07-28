using System;
using AttrContainerLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AttrContainerLibTest
{
    [TestClass]
    public class AttrTest
    {
        [TestMethod]
        public void AttributeString()
        {
            Attr<string> aString = new Attr<string>("StringAttribute", "value");

            Assert.AreEqual("value", aString.Value);
            Assert.AreEqual("StringAttribute", aString.Name);
            Assert.AreEqual("System.String", aString.Type);

            aString.Value = "newValue";
            Assert.AreEqual("newValue", aString.Value);
        }

        [TestMethod]
        public void AttributeInt()
        {
            Attr<int> aInt = new Attr<int>("IntAttribute", 123);

            Assert.AreEqual(123, aInt.Value);
            Assert.AreEqual("IntAttribute", aInt.Name);
            Assert.AreEqual("System.Int32", aInt.Type);

            aInt.Value = 321;
            Assert.AreEqual(321, aInt.Value);
        }
    }
}
