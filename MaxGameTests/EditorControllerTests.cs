using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaxGame.Controllers;
using MaxGame.Models;

namespace MaxGameTests
{
    [TestClass]
    public class EditorControllerTests
    {
        MockEditorController controller;
        [TestInitialize]
        public void Init()
        {
            controller = new MockEditorController(new GameArea());
        }

        [TestMethod]
        public void Test_Load()
        {
            controller.FailLoad = true;
            Assert.IsNull(controller.LoadGame("any"));
            controller.FailLoad = false;
            var diffs = controller.LoadGame("any");
            Assert.IsNotNull(diffs);
            Assert.AreEqual(1, diffs.Count);
            Assert.AreEqual(true, diffs[0].Value);
            Assert.AreEqual(1, diffs[0].Row);
            Assert.AreEqual(2, diffs[0].Col);
        }

        [TestMethod]
        public void Test_Clear()
        {
            controller.FailLoad = false;
            controller.LoadGame("any");
            var diffs = controller.Clear();
            Assert.IsNotNull(diffs);
            Assert.AreEqual(1, diffs.Count);
            Assert.AreEqual(false, diffs[0].Value);
            Assert.AreEqual(1, diffs[0].Row);
            Assert.AreEqual(2, diffs[0].Col);
        }

        [TestMethod]
        public void Test_ClickCell()
        {
            var diffs = controller.CellClicked(7, 5);
            Assert.IsNotNull(diffs);
            Assert.AreEqual(1, diffs.Count);
            Assert.AreEqual(true, diffs[0].Value);
            Assert.AreEqual(7, diffs[0].Row);
            Assert.AreEqual(5, diffs[0].Col);
        }
    }

    class MockEditorController : EditorController
    {
        public bool FailLoad { get; set; }

        public MockEditorController(GameArea a) : base(a) { }
        protected override GameArea LoadArea(string file)
        {
            if (FailLoad)
                return null;
            var area = new GameArea();
            area.Fields[1, 2].Toggle();
            return area;
        }
    }
}
