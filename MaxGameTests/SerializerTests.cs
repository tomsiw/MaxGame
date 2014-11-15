using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace MaxGameTests
{
    [TestClass]
    public class SerializerTests
    {
        [TestMethod]
        public void Test_Save()
        {
            var area = new MaxGame.Models.GameArea();
            area.Fields[5, 5].Toggle();
            area.Fields[7, 9].Toggle();
            var serializer = new MockSerializer();
            Assert.IsTrue(serializer.Save(area, "any.txt"));
            var result = serializer.Store;
            var expected = 
@"  0  0  0  0  0  0  0  0  0  0  0  0
  0  0  0  0  0  0  0  0  0  0  0  0
  0  0  0  0  0  0  0  0  0  0  0  0
  0  0  0  0  0  0  0  0  0  0  0  0
  0  0  0  0  0  0  0  0  0  0  0  0
  0  0  0  0  0  1  0  0  0  0  0  0
  0  0  0  0  0  0  0  0  0  0  0  0
  0  0  0  0  0  0  0  0  0  1  0  0
  0  0  0  0  0  0  0  0  0  0  0  0
  0  0  0  0  0  0  0  0  0  0  0  0
  0  0  0  0  0  0  0  0  0  0  0  0
  0  0  0  0  0  0  0  0  0  0  0  0
";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_Load()
        {
            var serializer = new MockSerializer();
            serializer.Store =
@"  0  0  0  0  0  0  0  0  0  0  0  0
  0  0  0  0  0  0  0  0  0  0  0  0
  0  0  0  0  0  0  0  0  0  0  0  0
  0  0  0  0  0  0  0  0  0  0  0  0
  0  0  0  0  0  0  0  0  0  0  0  0
  0  0  0  0  0  1  0  0  0  0  0  0
  0  0  0  0  0  0  0  0  0  0  0  0
  0  0  0  0  0  0  0  0  0  1  0  0
  0  0  0  0  0  0  0  0  0  0  0  0
  0  0  0  0  0  0  0  0  0  0  0  0
  0  0  0  0  0  0  0  0  0  0  0  0
  0  0  0  0  0  0  0  0  0  0  0  0
";

            var area = serializer.Load("any.txt");
            Assert.IsTrue(area.Fields[5, 5].Enabled);
            Assert.IsTrue(area.Fields[7, 9].Enabled);
            Assert.IsFalse(area.Fields[9, 9].Enabled);
            Assert.IsFalse(area.Fields[0, 0].Enabled);
        }
    }

    class MockSerializer : MaxGame.Controllers.GameAreaStorage
    {
        public string Store;

        protected override void SaveText(string text, string file)
        {
            Store = text;
        }

        protected override string LoadText(string file)
        {
            return Store;
        }
    }
}
