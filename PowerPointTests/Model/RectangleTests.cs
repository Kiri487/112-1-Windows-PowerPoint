using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPointTests.MockObject;

namespace PowerPoint.Model.Tests
{
    [TestClass()]
    public class RectangleTests
    {
        Rectangle _rectangle;
        PrivateObject _rectanglePrivate;
        MockGraphics _mockGraphics;
        PrivateObject _mockGraphicsPrivate;
        const string RECTANGLE = "矩形";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            CoordinatePoint upperLeftPoint = new CoordinatePoint(10, 20);
            CoordinatePoint lowerRightPoint = new CoordinatePoint(30, 50);

            _rectangle = new Rectangle(upperLeftPoint, lowerRightPoint);
            _rectanglePrivate = new PrivateObject(_rectangle);
            _mockGraphics = new MockGraphics();
            _mockGraphicsPrivate = new PrivateObject(_mockGraphics);
        }

        // Set point test
        [TestMethod()]
        public void SetPointTest()
        {
            _rectangle.SetPoint(new CoordinatePoint(30, 10), new CoordinatePoint(80, 30));
            Assert.AreEqual("(30, 10), (80, 30)", _rectangle.GetInfo(1, 1));
        }

        // Get info test
        [TestMethod()]
        public void GetInfoTest()
        {
            Assert.AreEqual("(10, 20), (30, 50)", _rectangle.GetInfo(1, 1));
        }

        // Get name test
        [TestMethod()]
        public void GetNameTest()
        {
            Assert.AreEqual(RECTANGLE, _rectangle.GetName());
        }

        // Get upper left point test
        [TestMethod()]
        public void GetUpperLeftPointTest()
        {
            Assert.AreEqual(_rectanglePrivate.GetFieldOrProperty("_upperLeftPoint"), _rectangle.GetUpperLeftPoint());
        }

        // Get lower right point test
        [TestMethod()]
        public void GetLowerRightPointTest()
        {
            Assert.AreEqual(_rectanglePrivate.GetFieldOrProperty("_lowerRightPoint"), _rectangle.GetLowerRightPoint());
        }

        // Get start point test
        [TestMethod()]
        public void GetStartPointTest()
        {
            Assert.AreEqual(_rectanglePrivate.GetFieldOrProperty("_upperLeftPoint"), _rectangle.GetStartPoint());
        }

        // Get end point test
        [TestMethod()]
        public void GetEndPointTest()
        {
            Assert.AreEqual(_rectanglePrivate.GetFieldOrProperty("_lowerRightPoint"), _rectangle.GetEndPoint());
        }

        // Draw test
        [TestMethod()]
        public void DrawTest()
        {
            _rectangle.Draw(_mockGraphics);
            Assert.AreEqual(_rectanglePrivate.GetFieldOrProperty("_upperLeftPoint"), _mockGraphicsPrivate.GetFieldOrProperty("_upperLeftPoint"));
            Assert.AreEqual(_rectanglePrivate.GetFieldOrProperty("_width"), _mockGraphicsPrivate.GetFieldOrProperty("_width"));
            Assert.AreEqual(_rectanglePrivate.GetFieldOrProperty("_height"), _mockGraphicsPrivate.GetFieldOrProperty("_height"));
            Assert.AreEqual(RECTANGLE, _mockGraphics.GetDrawType());
            Assert.IsTrue(_mockGraphics.IsSuccessful());
        }

        // Draw test with negative width
        [TestMethod()]
        public void DrawTestWithNegativeWidth()
        {
            CoordinatePoint upperLeftPoint = new CoordinatePoint(30, 20);
            CoordinatePoint lowerRightPoint = new CoordinatePoint(10, 50);
            _rectangle = new Rectangle(upperLeftPoint, lowerRightPoint);
            _rectanglePrivate = new PrivateObject(_rectangle);

            _rectangle.Draw(_mockGraphics);
            Assert.AreEqual("(10, 20)", ((CoordinatePoint)_mockGraphicsPrivate.GetFieldOrProperty("_upperLeftPoint")).ToString());
            Assert.AreEqual(-(float)_rectanglePrivate.GetFieldOrProperty("_width"), (float)_mockGraphicsPrivate.GetFieldOrProperty("_width"));
            Assert.AreEqual(_rectanglePrivate.GetFieldOrProperty("_height"), _mockGraphicsPrivate.GetFieldOrProperty("_height"));
            Assert.AreEqual(RECTANGLE, _mockGraphics.GetDrawType());
            Assert.IsTrue(_mockGraphics.IsSuccessful());
        }

        // Draw with negative height
        [TestMethod()]
        public void DrawTestWithNegativeHeight()
        {
            CoordinatePoint upperLeftPoint = new CoordinatePoint(10, 50);
            CoordinatePoint lowerRightPoint = new CoordinatePoint(30, 20);
            _rectangle = new Rectangle(upperLeftPoint, lowerRightPoint);
            _rectanglePrivate = new PrivateObject(_rectangle);

            _rectangle.Draw(_mockGraphics);
            Assert.AreEqual("(10, 20)", ((CoordinatePoint)_mockGraphicsPrivate.GetFieldOrProperty("_upperLeftPoint")).ToString());
            Assert.AreEqual(_rectanglePrivate.GetFieldOrProperty("_width"), _mockGraphicsPrivate.GetFieldOrProperty("_width"));
            Assert.AreEqual(-(float)_rectanglePrivate.GetFieldOrProperty("_height"), (float)_mockGraphicsPrivate.GetFieldOrProperty("_height"));
            Assert.AreEqual(RECTANGLE, _mockGraphics.GetDrawType());
            Assert.IsTrue(_mockGraphics.IsSuccessful());
        }

        // Draw test with negative width and Height
        [TestMethod()]
        public void DrawTestWithNegativeWidthAndHeight()
        {
            CoordinatePoint upperLeftPoint = new CoordinatePoint(30, 50);
            CoordinatePoint lowerRightPoint = new CoordinatePoint(10, 20);
            _rectangle = new Rectangle(upperLeftPoint, lowerRightPoint);
            _rectanglePrivate = new PrivateObject(_rectangle);

            _rectangle.Draw(_mockGraphics);
            Assert.AreEqual(_rectanglePrivate.GetFieldOrProperty("_lowerRightPoint"), _mockGraphicsPrivate.GetFieldOrProperty("_upperLeftPoint"));
            Assert.AreEqual(-(float)_rectanglePrivate.GetFieldOrProperty("_width"), (float)_mockGraphicsPrivate.GetFieldOrProperty("_width"));
            Assert.AreEqual(-(float)_rectanglePrivate.GetFieldOrProperty("_height"), (float)_mockGraphicsPrivate.GetFieldOrProperty("_height"));
            Assert.AreEqual(RECTANGLE, _mockGraphics.GetDrawType());
            Assert.IsTrue(_mockGraphics.IsSuccessful());
        }

        // Select test
        [TestMethod()]
        public void SelectTest()
        {
            _rectangle.Select(_mockGraphics);
            Assert.AreEqual(_rectanglePrivate.GetFieldOrProperty("_upperLeftPoint"), _mockGraphicsPrivate.GetFieldOrProperty("_upperLeftPoint"));
            Assert.AreEqual(_rectanglePrivate.GetFieldOrProperty("_width"), _mockGraphicsPrivate.GetFieldOrProperty("_width"));
            Assert.AreEqual(_rectanglePrivate.GetFieldOrProperty("_height"), _mockGraphicsPrivate.GetFieldOrProperty("_height"));
            Assert.AreEqual("SelectBorder", _mockGraphics.GetDrawType());
            Assert.IsTrue(_mockGraphics.IsSuccessful());
        }

        // Select test with negative width
        [TestMethod()]
        public void SelectTestWithNegativeWidth()
        {
            CoordinatePoint upperLeftPoint = new CoordinatePoint(30, 20);
            CoordinatePoint lowerRightPoint = new CoordinatePoint(10, 50);
            _rectangle = new Rectangle(upperLeftPoint, lowerRightPoint);
            _rectanglePrivate = new PrivateObject(_rectangle);

            _rectangle.Select(_mockGraphics);
            Assert.AreEqual("(10, 20)", ((CoordinatePoint)_mockGraphicsPrivate.GetFieldOrProperty("_upperLeftPoint")).ToString());
            Assert.AreEqual(-(float)_rectanglePrivate.GetFieldOrProperty("_width"), (float)_mockGraphicsPrivate.GetFieldOrProperty("_width"));
            Assert.AreEqual(_rectanglePrivate.GetFieldOrProperty("_height"), _mockGraphicsPrivate.GetFieldOrProperty("_height"));
            Assert.AreEqual("SelectBorder", _mockGraphics.GetDrawType());
            Assert.IsTrue(_mockGraphics.IsSuccessful());
        }

        // Select test with negative height
        [TestMethod()]
        public void SelectTestWithNegativeHeight()
        {
            CoordinatePoint upperLeftPoint = new CoordinatePoint(10, 50);
            CoordinatePoint lowerRightPoint = new CoordinatePoint(30, 20);
            _rectangle = new Rectangle(upperLeftPoint, lowerRightPoint);
            _rectanglePrivate = new PrivateObject(_rectangle);

            _rectangle.Select(_mockGraphics);
            Assert.AreEqual("(10, 20)", ((CoordinatePoint)_mockGraphicsPrivate.GetFieldOrProperty("_upperLeftPoint")).ToString());
            Assert.AreEqual(_rectanglePrivate.GetFieldOrProperty("_width"), _mockGraphicsPrivate.GetFieldOrProperty("_width"));
            Assert.AreEqual(-(float)_rectanglePrivate.GetFieldOrProperty("_height"), (float)_mockGraphicsPrivate.GetFieldOrProperty("_height"));
            Assert.AreEqual("SelectBorder", _mockGraphics.GetDrawType());
            Assert.IsTrue(_mockGraphics.IsSuccessful());
        }

        // Select test with negative width and Height
        [TestMethod()]
        public void SelectTestWithNegativeWidthAndHeight()
        {
            CoordinatePoint upperLeftPoint = new CoordinatePoint(30, 50);
            CoordinatePoint lowerRightPoint = new CoordinatePoint(10, 20);
            _rectangle = new Rectangle(upperLeftPoint, lowerRightPoint);
            _rectanglePrivate = new PrivateObject(_rectangle);

            _rectangle.Select(_mockGraphics);
            Assert.AreEqual(_rectanglePrivate.GetFieldOrProperty("_lowerRightPoint"), _mockGraphicsPrivate.GetFieldOrProperty("_upperLeftPoint"));
            Assert.AreEqual(-(float)_rectanglePrivate.GetFieldOrProperty("_width"), (float)_mockGraphicsPrivate.GetFieldOrProperty("_width"));
            Assert.AreEqual(-(float)_rectanglePrivate.GetFieldOrProperty("_height"), (float)_mockGraphicsPrivate.GetFieldOrProperty("_height"));
            Assert.AreEqual("SelectBorder", _mockGraphics.GetDrawType());
            Assert.IsTrue(_mockGraphics.IsSuccessful());
        }

        // Move test when both positive
        [TestMethod()]
        public void MoveWhenBothPositiveTest()
        {
            _rectangle.Move(10, 10);
            Assert.AreEqual("(20, 30)", _rectanglePrivate.GetFieldOrProperty("_upperLeftPoint").ToString());
            Assert.AreEqual("(40, 60)", _rectanglePrivate.GetFieldOrProperty("_lowerRightPoint").ToString());
        }

        // Move test when both negative
        [TestMethod()]
        public void MoveWhenBothNegativeTest()
        {
            _rectangle.Move(-10, -10);
            Assert.AreEqual("(0, 10)", _rectanglePrivate.GetFieldOrProperty("_upperLeftPoint").ToString());
            Assert.AreEqual("(20, 40)", _rectanglePrivate.GetFieldOrProperty("_lowerRightPoint").ToString());
        }

        // Move test when offest X is positive and offest Y is negative
        [TestMethod()]
        public void MoveWhenPositiveXNegativeYTest()
        {
            _rectangle.Move(10, -10);
            Assert.AreEqual("(20, 10)", _rectanglePrivate.GetFieldOrProperty("_upperLeftPoint").ToString());
            Assert.AreEqual("(40, 40)", _rectanglePrivate.GetFieldOrProperty("_lowerRightPoint").ToString());
        }

        // Move test when offest Y is positive and offest X is negative
        [TestMethod()]
        public void MoveWhenPositiveYNegativeXTest()
        {
            _rectangle.Move(-10, 10);
            Assert.AreEqual("(0, 30)", _rectanglePrivate.GetFieldOrProperty("_upperLeftPoint").ToString());
            Assert.AreEqual("(20, 60)", _rectanglePrivate.GetFieldOrProperty("_lowerRightPoint").ToString());
        }

        // Scale test when both positive
        [TestMethod()]
        public void ScaleWhenBothPositiveTest()
        {
            _rectangle.Scale(10, 10);
            Assert.AreEqual("(40, 60)", _rectanglePrivate.GetFieldOrProperty("_lowerRightPoint").ToString());
        }

        // Scale test when both negative
        [TestMethod()]
        public void ScaleWhenBothNegativeTest()
        {
            _rectangle.Scale(-25, -40);
            Assert.AreEqual("(5, 10)", _rectanglePrivate.GetFieldOrProperty("_lowerRightPoint").ToString());
        }

        // Scale test when offest X is positive and offest Y is negative
        [TestMethod()]
        public void ScaleWhenPositiveXNegativeYTest()
        {
            _rectangle.Scale(10, -40);
            Assert.AreEqual("(40, 10)", _rectanglePrivate.GetFieldOrProperty("_lowerRightPoint").ToString());
        }

        // Scale test when offest Y is positive and offest X is negative
        [TestMethod()]
        public void ScaleWhenPositiveYNegativeXTest()
        {
            _rectangle.Scale(-25, 10);
            Assert.AreEqual("(5, 60)", _rectanglePrivate.GetFieldOrProperty("_lowerRightPoint").ToString());
        }

        // Reset point test when scale offest both positive
        [TestMethod()]
        public void ResetPointWhenScaleBothPositiveTest()
        {
            _rectangle.Scale(10, 10);
            _rectangle.ResetPoint();
            Assert.AreEqual("(10, 20)", _rectanglePrivate.GetFieldOrProperty("_upperLeftPoint").ToString());
            Assert.AreEqual("(40, 60)", _rectanglePrivate.GetFieldOrProperty("_lowerRightPoint").ToString());
        }

        // Reset point test when scale offest both negative
        [TestMethod()]
        public void ResetPointTestWhenScaleBothNegative()
        {
            _rectangle.Scale(-25, -40);
            _rectangle.ResetPoint();
            Assert.AreEqual("(5, 10)", _rectanglePrivate.GetFieldOrProperty("_upperLeftPoint").ToString());
            Assert.AreEqual("(10, 20)", _rectanglePrivate.GetFieldOrProperty("_lowerRightPoint").ToString());
        }

        // Reset point test when scale offest X is positive and offest Y is negative
        [TestMethod()]
        public void ResetPointTestWhenScalePositiveXNegativeY()
        {
            _rectangle.Scale(10, -40);
            _rectangle.ResetPoint();
            Assert.AreEqual("(10, 10)", _rectanglePrivate.GetFieldOrProperty("_upperLeftPoint").ToString());
            Assert.AreEqual("(40, 20)", _rectanglePrivate.GetFieldOrProperty("_lowerRightPoint").ToString());
        }

        // Reset point test when scale offest Y is positive and offest X is negative
        [TestMethod()]
        public void ResetPointTestWhenScalePositiveYNegativeX()
        {
            _rectangle.Scale(-25, 10);
            _rectangle.ResetPoint();
            Assert.AreEqual("(5, 20)", _rectanglePrivate.GetFieldOrProperty("_upperLeftPoint").ToString());
            Assert.AreEqual("(10, 60)", _rectanglePrivate.GetFieldOrProperty("_lowerRightPoint").ToString());
        }
    }
}