using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaxGame.Controllers;
using MaxGame.Models;

namespace MaxGameTests
{
    [TestClass]
    public class GameControllerTests
    {
        [TestMethod]
        public void Test_InitGame()
        {
            var area = new GameArea();
            area.Fields[3, 2].Toggle();
            var controller = new GameController(area);
            var initState = controller.GetInitialState();
            Assert.AreEqual(12, initState.Count);
            Assert.AreEqual("", initState[0].ColumnHeader);
            Assert.AreEqual("1 *", initState[2].ColumnHeader);
            Assert.AreEqual("1 *", initState[3].RowHeader);
        }

        [TestMethod]
        public void Test_Difference()
        {
            var area = new GameArea();
            var controller = new GameController(area);
            Assert.IsFalse(controller.IsDifference());
            controller.CellClicked(1, 2);
            Assert.IsTrue(controller.IsDifference());
            controller.CellClicked(1, 2);
            Assert.IsFalse(controller.IsDifference());
        }
    }
}
