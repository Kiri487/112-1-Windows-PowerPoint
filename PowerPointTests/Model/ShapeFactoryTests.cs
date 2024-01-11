using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerPoint.Model.Tests
{
    [TestClass()]
    public class ShapeFactoryTests
    {
        ShapeFactory _shapeFactory;
        CoordinatePoint _startPoint = new CoordinatePoint(10, 10);
        CoordinatePoint _endPoint = new CoordinatePoint(20, 20);
        const string LINE = "線";
        const string RECTANGLE = "矩形";
        const string CIRCLE = "橢圓";
        const int POINT_X_MIN = 0;
        const int POINT_X_MAX = 3200;
        const int POINT_Y_MIN = 0;
        const int POINT_Y_MAX = 1800;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _shapeFactory = new ShapeFactory();
        }

        // Create line shape with point test from upper left to lower right
        [TestMethod()]
        public void CreateLineShapeWithPointFromUpperLeftToLowerRightTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(20, 30);
            Shape line = _shapeFactory.CreateShape(LINE, startPoint, endPoint);

            Assert.AreEqual(LINE, line.GetName());
            Assert.AreEqual("(10, 15)", line.GetUpperLeftPoint().ToString());
            Assert.AreEqual("(20, 30)", line.GetLowerRightPoint().ToString());
        }

        // Create line shape with point test from lower left to upper right
        [TestMethod()]
        public void CreateLineShapeWithPointFromLowerLeftToUpperRightTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(20, 5);
            Shape line = _shapeFactory.CreateShape(LINE, startPoint, endPoint);

            Assert.AreEqual(LINE, line.GetName());
            Assert.AreEqual("(10, 5)", line.GetUpperLeftPoint().ToString());
            Assert.AreEqual("(20, 15)", line.GetLowerRightPoint().ToString());
        }

        // Create line shape with point test from lower right to upper left
        [TestMethod()]
        public void CreateLineShapeWithPointFromLowerRightToUpperLeftTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(3, 5);
            Shape line = _shapeFactory.CreateShape(LINE, startPoint, endPoint);

            Assert.AreEqual(LINE, line.GetName());
            Assert.AreEqual("(3, 5)", line.GetUpperLeftPoint().ToString());
            Assert.AreEqual("(10, 15)", line.GetLowerRightPoint().ToString());
        }

        // Create line shape with point test from upper right to lower left
        [TestMethod()]
        public void CreateLineShapeWithPointFromUpperRightToLowerLeftTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(3, 30);
            Shape line = _shapeFactory.CreateShape(LINE, startPoint, endPoint);

            Assert.AreEqual(LINE, line.GetName());
            Assert.AreEqual("(3, 15)", line.GetUpperLeftPoint().ToString());
            Assert.AreEqual("(10, 30)", line.GetLowerRightPoint().ToString());
        }

        // Create rectangle shape with point test from upper left to lower right
        [TestMethod()]
        public void CreateRectangleShapeWithPointFromUpperLeftToLowerRightTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(20, 30);
            Shape rectangle = _shapeFactory.CreateShape(RECTANGLE, startPoint, endPoint);

            Assert.AreEqual(RECTANGLE, rectangle.GetName());
            Assert.AreEqual("(10, 15)", rectangle.GetUpperLeftPoint().ToString());
            Assert.AreEqual("(20, 30)", rectangle.GetLowerRightPoint().ToString());
        }

        // Create rectangle shape with point test from lower left to upper right
        [TestMethod()]
        public void CreateRectangleShapeWithPointFromLowerLeftToUpperRightTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(20, 5);
            Shape rectangle = _shapeFactory.CreateShape(RECTANGLE, startPoint, endPoint);

            Assert.AreEqual(RECTANGLE, rectangle.GetName());
            Assert.AreEqual("(10, 5)", rectangle.GetUpperLeftPoint().ToString());
            Assert.AreEqual("(20, 15)", rectangle.GetLowerRightPoint().ToString());
        }

        // Create rectangle shape with point test from lower right to upper left
        [TestMethod()]
        public void CreateRectangleShapeWithPointFromLowerRightToUpperLeftTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(3, 5);
            Shape rectangle = _shapeFactory.CreateShape(RECTANGLE, startPoint, endPoint);

            Assert.AreEqual(RECTANGLE, rectangle.GetName());
            Assert.AreEqual("(3, 5)", rectangle.GetUpperLeftPoint().ToString());
            Assert.AreEqual("(10, 15)", rectangle.GetLowerRightPoint().ToString());
        }

        // Create rectangle shape with point test from upper right to lower left
        [TestMethod()]
        public void CreateRectangleShapeWithPointFromUpperRightToLowerLeftTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(3, 30);
            Shape rectangle = _shapeFactory.CreateShape(RECTANGLE, startPoint, endPoint);

            Assert.AreEqual(RECTANGLE, rectangle.GetName());
            Assert.AreEqual("(3, 15)", rectangle.GetUpperLeftPoint().ToString());
            Assert.AreEqual("(10, 30)", rectangle.GetLowerRightPoint().ToString());
        }

        // Create circle shape with point test from upper left to lower right
        [TestMethod()]
        public void CreateCircleShapeWithPointFromUpperLeftToLowerRightTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(20, 30);
            Shape circle = _shapeFactory.CreateShape(CIRCLE, startPoint, endPoint);

            Assert.AreEqual(CIRCLE, circle.GetName());
            Assert.AreEqual("(10, 15)", circle.GetUpperLeftPoint().ToString());
            Assert.AreEqual("(20, 30)", circle.GetLowerRightPoint().ToString());
        }

        // Create circle shape with point test from lower left to upper right
        [TestMethod()]
        public void CreateCircleShapeWithPointFromLowerLeftToUpperRightTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(20, 5);
            Shape circle = _shapeFactory.CreateShape(CIRCLE, startPoint, endPoint);

            Assert.AreEqual(CIRCLE, circle.GetName());
            Assert.AreEqual("(10, 5)", circle.GetUpperLeftPoint().ToString());
            Assert.AreEqual("(20, 15)", circle.GetLowerRightPoint().ToString());
        }

        // Create circle shape with point test from lower right to upper left
        [TestMethod()]
        public void CreateCircleShapeWithPointFromLowerRightToUpperLeftTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(3, 5);
            Shape circle = _shapeFactory.CreateShape(CIRCLE, startPoint, endPoint);

            Assert.AreEqual(CIRCLE, circle.GetName());
            Assert.AreEqual("(3, 5)", circle.GetUpperLeftPoint().ToString());
            Assert.AreEqual("(10, 15)", circle.GetLowerRightPoint().ToString());
        }

        // Create circle shape with point test from upper right to lower left
        [TestMethod()]
        public void CreateCircleShapeWithPointFromUpperRightToLowerLeftTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(3, 30);
            Shape circle = _shapeFactory.CreateShape(CIRCLE, startPoint, endPoint);

            Assert.AreEqual(CIRCLE, circle.GetName());
            Assert.AreEqual("(3, 15)", circle.GetUpperLeftPoint().ToString());
            Assert.AreEqual("(10, 30)", circle.GetLowerRightPoint().ToString());
        }
    }
}