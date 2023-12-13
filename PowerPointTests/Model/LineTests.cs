using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPointTests.MockObject;

namespace PowerPoint.Model.Tests
{
    [TestClass()]
    public class LineTests
    {
        Line _line;
        PrivateObject _linePrivate;
        MockGraphics _mockGraphics;
        PrivateObject _mockGraphicsPrivate;
        const string LINE = "線";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 20);
            CoordinatePoint endPoint = new CoordinatePoint(30, 50);

            _line = new Line(startPoint, endPoint);
            _linePrivate = new PrivateObject(_line);
            _mockGraphics = new MockGraphics();
            _mockGraphicsPrivate = new PrivateObject(_mockGraphics);
        }

        // Set point test
        [TestMethod()]
        public void SetPointTest()
        {
            _line.SetPoint(new CoordinatePoint(30, 10), new CoordinatePoint(80, 30));
            Assert.AreEqual("(30, 10), (80, 30)", _line.GetInfo(1, 1));
        }

        // Get info test
        [TestMethod()]
        public void GetInfoTest()
        {
            Assert.AreEqual("(10, 20), (30, 50)", _line.GetInfo(1, 1));
        }

        // Get name test
        [TestMethod()]
        public void GetNameTest()
        {
            Assert.AreEqual(LINE, _line.GetName());
        }

        // Get upper left point test
        [TestMethod()]
        public void GetUpperLeftPointTest()
        {
            Assert.AreEqual(_linePrivate.GetFieldOrProperty("_upperLeftPoint"), _line.GetUpperLeftPoint());
        }

        // Get lower right point test
        [TestMethod()]
        public void GetLowerRightPointTest()
        {
            Assert.AreEqual(_linePrivate.GetFieldOrProperty("_lowerRightPoint"), _line.GetLowerRightPoint());
        }

        // Get start point test
        [TestMethod()]
        public void GetStartPointTest()
        {
            Assert.AreEqual(_linePrivate.GetFieldOrProperty("_startPoint"), _line.GetStartPoint());
        }

        // Get end point test
        [TestMethod()]
        public void GetEndPointTest()
        {
            Assert.AreEqual(_linePrivate.GetFieldOrProperty("_endPoint"), _line.GetEndPoint());
        }

        // Draw test
        [TestMethod()]
        public void DrawTest()
        {
            _line.Draw(_mockGraphics);
            Assert.AreEqual(_linePrivate.GetFieldOrProperty("_startPoint"), _mockGraphicsPrivate.GetFieldOrProperty("_startPoint"));
            Assert.AreEqual(_linePrivate.GetFieldOrProperty("_endPoint"), _mockGraphicsPrivate.GetFieldOrProperty("_endPoint"));
            Assert.AreEqual(LINE, _mockGraphics.GetDrawType());
            Assert.IsTrue(_mockGraphics.IsSuccessful());
        }

        // Select test
        [TestMethod()]
        public void SelectTest()
        {
            _line.Select(_mockGraphics);
            Assert.AreEqual(_linePrivate.GetFieldOrProperty("_width"), _mockGraphicsPrivate.GetFieldOrProperty("_width"));
            Assert.AreEqual(_linePrivate.GetFieldOrProperty("_height"), _mockGraphicsPrivate.GetFieldOrProperty("_height"));
            Assert.AreEqual("SelectBorder", _mockGraphics.GetDrawType());
            Assert.IsTrue(_mockGraphics.IsSuccessful());
        }

        // Select test with negative width
        [TestMethod()]
        public void SelectTestWithNegativeWidth()
        {
            CoordinatePoint startPoint = new CoordinatePoint(0, 0);
            CoordinatePoint endPoint = new CoordinatePoint(10, 10);
            _line = new Line(startPoint, endPoint);
            _linePrivate = new PrivateObject(_line);
            _line.Scale(-20, 0);

            _line.Select(_mockGraphics);
            Assert.AreEqual(-(float)_linePrivate.GetFieldOrProperty("_width"), (float)_mockGraphicsPrivate.GetFieldOrProperty("_width"));
            Assert.AreEqual(_linePrivate.GetFieldOrProperty("_height"), _mockGraphicsPrivate.GetFieldOrProperty("_height"));
            Assert.AreEqual("SelectBorder", _mockGraphics.GetDrawType());
            Assert.IsTrue(_mockGraphics.IsSuccessful());
        }

        // Select test with negative height
        [TestMethod()]
        public void SelectTestWithNegativeHeight()
        {
            CoordinatePoint startPoint = new CoordinatePoint(0, 0);
            CoordinatePoint endPoint = new CoordinatePoint(10, 10);
            _line = new Line(startPoint, endPoint);
            _linePrivate = new PrivateObject(_line);
            _line.Scale(10, -30);

            _line.Select(_mockGraphics);
            Assert.AreEqual(_linePrivate.GetFieldOrProperty("_width"), _mockGraphicsPrivate.GetFieldOrProperty("_width"));
            Assert.AreEqual(-(float)_linePrivate.GetFieldOrProperty("_height"), (float)_mockGraphicsPrivate.GetFieldOrProperty("_height"));
            Assert.AreEqual("SelectBorder", _mockGraphics.GetDrawType());
            Assert.IsTrue(_mockGraphics.IsSuccessful());
        }

        // Select test with negative width and Height
        [TestMethod()]
        public void SelectTestWithNegativeWidthAndHeight()
        {
            CoordinatePoint startPoint = new CoordinatePoint(0, 0);
            CoordinatePoint endPoint = new CoordinatePoint(10, 10);
            _line = new Line(startPoint, endPoint);
            _linePrivate = new PrivateObject(_line);
            _line.Scale(-20, -30);

            _line.Select(_mockGraphics);
            Assert.AreEqual(_linePrivate.GetFieldOrProperty("_lowerRightPoint"), _mockGraphicsPrivate.GetFieldOrProperty("_upperLeftPoint"));
            Assert.AreEqual(-(float)_linePrivate.GetFieldOrProperty("_width"), (float)_mockGraphicsPrivate.GetFieldOrProperty("_width"));
            Assert.AreEqual(-(float)_linePrivate.GetFieldOrProperty("_height"), (float)_mockGraphicsPrivate.GetFieldOrProperty("_height"));
            Assert.AreEqual("SelectBorder", _mockGraphics.GetDrawType());
            Assert.IsTrue(_mockGraphics.IsSuccessful());
        }

        // Move test when both positive
        [TestMethod()]
        public void MoveWhenBothPositiveTest()
        {
            _line.Move(10, 10);
            Assert.AreEqual("(20, 30)", _linePrivate.GetFieldOrProperty("_upperLeftPoint").ToString());
            Assert.AreEqual("(40, 60)", _linePrivate.GetFieldOrProperty("_lowerRightPoint").ToString());
        }

        // Move test when both negative
        [TestMethod()]
        public void MoveWhenBothNegativeTest()
        {
            _line.Move(-10, -10);
            Assert.AreEqual("(0, 10)", _linePrivate.GetFieldOrProperty("_upperLeftPoint").ToString());
            Assert.AreEqual("(20, 40)", _linePrivate.GetFieldOrProperty("_lowerRightPoint").ToString());
        }

        // Move test when offest X is positive and offest Y is negative
        [TestMethod()]
        public void MoveWhenPositiveXNegativeYTest()
        {
            _line.Move(10, -10);
            Assert.AreEqual("(20, 10)", _linePrivate.GetFieldOrProperty("_upperLeftPoint").ToString());
            Assert.AreEqual("(40, 40)", _linePrivate.GetFieldOrProperty("_lowerRightPoint").ToString());
        }

        // Move test when offest Y is positive and offest X is negative
        [TestMethod()]
        public void MoveWhenPositiveYNegativeXTest()
        {
            _line.Move(-10, 10);
            Assert.AreEqual("(0, 30)", _linePrivate.GetFieldOrProperty("_upperLeftPoint").ToString());
            Assert.AreEqual("(20, 60)", _linePrivate.GetFieldOrProperty("_lowerRightPoint").ToString());
        }

        // Scale test when both positive
        [TestMethod()]
        public void ScaleWhenBothPositiveTest()
        {
            _line.Scale(10, 10);
            Assert.AreEqual("(40, 60)", _linePrivate.GetFieldOrProperty("_lowerRightPoint").ToString());
            Assert.AreEqual("(40, 60)", _linePrivate.GetFieldOrProperty("_endPoint").ToString());
        }

        // Scale test when both negative
        [TestMethod()]
        public void ScaleWhenBothNegativeTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(30, 50);
            CoordinatePoint endPoint = new CoordinatePoint(10, 20);
            _line = new Line(startPoint, endPoint);
            _linePrivate = new PrivateObject(_line);

            _line.Scale(-25, -40);
            Assert.AreEqual("(5, 10)", _linePrivate.GetFieldOrProperty("_lowerRightPoint").ToString());
            Assert.AreEqual("(5, 10)", _linePrivate.GetFieldOrProperty("_startPoint").ToString());
        }

        // Scale test when offest X is positive and offest Y is negative
        [TestMethod()]
        public void ScaleWhenPositiveXNegativeYTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(30, 50);
            CoordinatePoint endPoint = new CoordinatePoint(40, 20);
            _line = new Line(startPoint, endPoint);
            _linePrivate = new PrivateObject(_line);

            _line.Scale(10, -40);
            Assert.AreEqual("(50, 10)", _linePrivate.GetFieldOrProperty("_lowerRightPoint").ToString());           
            Assert.AreEqual("(30, 10)", _linePrivate.GetFieldOrProperty("_startPoint").ToString());
            Assert.AreEqual("(50, 20)", _linePrivate.GetFieldOrProperty("_endPoint").ToString());
        }

        // Scale test when offest Y is positive and offest X is negative
        [TestMethod()]
        public void ScaleWhenPositiveYNegativeXTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(40, 20);
            CoordinatePoint endPoint = new CoordinatePoint(30, 50);
            _line = new Line(startPoint, endPoint);
            _linePrivate = new PrivateObject(_line);

            _line.Scale(-25, 10);
            Assert.AreEqual("(15, 60)", _linePrivate.GetFieldOrProperty("_lowerRightPoint").ToString());
            Assert.AreEqual("(15, 20)", _linePrivate.GetFieldOrProperty("_startPoint").ToString());
            Assert.AreEqual("(30, 60)", _linePrivate.GetFieldOrProperty("_endPoint").ToString());
        }

        // Reset point test when scale offest both positive
        [TestMethod()]
        public void ResetPointWhenScaleBothPositiveTest()
        {
            _line.Scale(10, 10);
            _line.ResetPoint();
            Assert.AreEqual("(10, 20)", _linePrivate.GetFieldOrProperty("_upperLeftPoint").ToString());
            Assert.AreEqual("(40, 60)", _linePrivate.GetFieldOrProperty("_lowerRightPoint").ToString());

        }

        // Reset point test when scale offest both negative
        [TestMethod()]
        public void ResetPointTestWhenScaleBothNegative()
        {
            CoordinatePoint startPoint = new CoordinatePoint(30, 50);
            CoordinatePoint endPoint = new CoordinatePoint(10, 20);
            _line = new Line(startPoint, endPoint);
            _linePrivate = new PrivateObject(_line);

            _line.Scale(-25, -40);
            _line.ResetPoint();
            Assert.AreEqual("(5, 10)", _linePrivate.GetFieldOrProperty("_upperLeftPoint").ToString());
            Assert.AreEqual("(10, 20)", _linePrivate.GetFieldOrProperty("_lowerRightPoint").ToString());
        }

        // Reset point test when scale offest X is positive and offest Y is negative
        [TestMethod()]
        public void ResetPointTestWhenScalePositiveXNegativeY()
        {
            CoordinatePoint startPoint = new CoordinatePoint(30, 50);
            CoordinatePoint endPoint = new CoordinatePoint(40, 20);
            _line = new Line(startPoint, endPoint);
            _linePrivate = new PrivateObject(_line);

            _line.Scale(10, -40);
            _line.ResetPoint();
            Assert.AreEqual("(30, 10)", _linePrivate.GetFieldOrProperty("_upperLeftPoint").ToString());
            Assert.AreEqual("(50, 20)", _linePrivate.GetFieldOrProperty("_lowerRightPoint").ToString());
        }

        // Reset point test when scale offest Y is positive and offest X is negative
        [TestMethod()]
        public void ResetPointTestWhenScalePositiveYNegativeX()
        {
            CoordinatePoint startPoint = new CoordinatePoint(40, 20);
            CoordinatePoint endPoint = new CoordinatePoint(30, 50);
            _line = new Line(startPoint, endPoint);
            _linePrivate = new PrivateObject(_line);
            Assert.AreEqual("right to left", _linePrivate.GetFieldOrProperty("_direction"));
            Assert.AreEqual("up", _linePrivate.GetFieldOrProperty("_slope"));

            _line.Scale(-25, 10);
            _line.ResetPoint();
            Assert.AreEqual("(15, 20)", _linePrivate.GetFieldOrProperty("_upperLeftPoint").ToString());
            Assert.AreEqual("(30, 60)", _linePrivate.GetFieldOrProperty("_lowerRightPoint").ToString());
            Assert.AreEqual("left to right", _linePrivate.GetFieldOrProperty("_direction"));
            Assert.AreEqual("down", _linePrivate.GetFieldOrProperty("_slope"));
        }
    }
}