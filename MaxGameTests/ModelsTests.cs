using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaxGameTests
{
    [TestClass]
    public class ModelsTests
    {
        [TestMethod]
        public void Test_GameArea()
        {
            var area = new MaxGame.Models.GameArea();
            Assert.IsNotNull(area.Fields);
            Assert.AreEqual(2, area.Fields.Rank);
            Assert.AreEqual(12, area.Fields.GetLength(0));
            Assert.AreEqual(12, area.Fields.GetLength(1));
        }

        [TestMethod]
        public void Test_Rows_Symeric()
        {
            var area = new MaxGame.Models.GameArea();
            for (var i = 0; i < 12; i++ )
                area.Fields[11-i, i].Toggle();

            var row0 = new MaxGame.Models.Row(area, 0);
            var row11 = new MaxGame.Models.Row(area, 11);
            Assert.AreEqual(false, row0.Projection[0]);
            Assert.AreEqual(false, row0.Projection[1]);
            Assert.AreEqual(true, row11.Projection[0]);
            Assert.AreEqual(false, row11.Projection[1]);
        }

        [TestMethod]
        public void Test_Columns_Symeric()
        {
            var area = new MaxGame.Models.GameArea();
            for (var i = 0; i < 12; i++)
                area.Fields[11 - i, i].Toggle();

            var col0 = new MaxGame.Models.Column(area, 0);
            var col11 = new MaxGame.Models.Column(area, 11);
            Assert.AreEqual(false, col0.Projection[0]);
            Assert.AreEqual(false, col0.Projection[1]);
            Assert.AreEqual(true, col11.Projection[0]);
            Assert.AreEqual(false, col11.Projection[1]);
        }

        [TestMethod]
        public void Test_Rows_NonSymeric()
        {
            var area = new MaxGame.Models.GameArea();
            for (var i = 0; i < 12; i++)
                area.Fields[(5 + i) % 12, i].Toggle();

            var row0 = new MaxGame.Models.Row(area, 0);
            var row11 = new MaxGame.Models.Row(area, 11);
            Assert.AreEqual(false, row0.Projection[6]);
            Assert.AreEqual(true, row0.Projection[7]);
            Assert.AreEqual(false, row0.Projection[8]);
            Assert.AreEqual(false, row11.Projection[5]);
            Assert.AreEqual(true, row11.Projection[6]);
            Assert.AreEqual(false, row11.Projection[7]);
        }

        [TestMethod]
        public void Test_Cols_NonSymeric()
        {
            var area = new MaxGame.Models.GameArea();
            for (var i = 0; i < 12; i++)
                area.Fields[(5 + i) % 12, i].Toggle();

            var col0 = new MaxGame.Models.Column(area, 0);
            var col11 = new MaxGame.Models.Column(area, 11);
            Assert.AreEqual(false, col0.Projection[4]);
            Assert.AreEqual(true, col0.Projection[5]);
            Assert.AreEqual(false, col0.Projection[6]);
            Assert.AreEqual(false, col11.Projection[3]);
            Assert.AreEqual(true, col11.Projection[4]);
            Assert.AreEqual(false, col11.Projection[5]);
        }

        [TestMethod]
        public void Test_RowsCols_ToString()
        {
            var areaTxt =
@"  0  1  1  0  1  0  1  0  1  1  1  0
  0  0  0  0  1  0  1  0  0  0  0  0
  0  0  0  0  0  0  0  0  0  0  0  0
  0  0  0  0  0  0  0  0  0  0  0  0
  0  0  1  0  0  0  0  0  0  0  0  0
  0  0  1  0  0  1  0  0  0  0  0  0
  0  0  0  0  0  0  0  0  0  0  0  0
  0  0  1  0  0  0  0  0  0  1  0  0
  0  0  1  0  0  0  0  0  0  0  0  0
  0  0  1  0  0  0  0  0  0  0  0  0
  0  0  1  0  0  0  0  0  0  0  0  0
  0  0  1  0  0  0  0  0  0  0  0  0
";
            var area = new MaxGame.Models.GameArea();
            area.FromString(areaTxt);
            var row0 = new MaxGame.Models.Row(area, 0);
            var row1 = new MaxGame.Models.Row(area, 1);
            var txtRep = row0.ToString();
            Assert.AreEqual("2,1,1,3", txtRep);
            txtRep = row1.ToString();
            Assert.AreEqual("1,1", txtRep);

            var col2 = new MaxGame.Models.Column(area, 2);
            txtRep = col2.ToString();
            Assert.AreEqual("1,2,5", txtRep);
        }
    }
}
