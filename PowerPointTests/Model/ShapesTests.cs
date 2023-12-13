using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPointTests.MockObject;
using System.Threading;

namespace PowerPoint.Model.Tests
{
    [TestClass()]
    public class ShapesTests
    {
        Shapes _shapes;
        PrivateObject _shapesPrivate;
        MockGraphics _mockGraphics;
        PrivateObject _mockGraphicsPrivate;
        const string LINE = "線";
        const string RECTANGLE = "矩形";
        const string CIRCLE = "橢圓";
        const float SELECT_POINT_SIZE = 10;
        const float HALF_SELECT_POINT_SIZE = SELECT_POINT_SIZE / 2;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _shapes = new Shapes();
            _shapesPrivate = new PrivateObject(_shapes);
            _mockGraphics = new MockGraphics();
            _mockGraphicsPrivate = new PrivateObject(_mockGraphics);
        }

        // Add line shape test
        [TestMethod()]
        public void AddLineShapeTest()
        {
            _shapes.AddShape(LINE);
            int length = _shapes.GetShapesListLength();
            Assert.AreEqual(1, length);
            Assert.AreEqual(LINE, _shapes.GetShapeName(length - 1));
        }

        // Add line shape test with point test from upper left to lower right
        [TestMethod()]
        public void AddLineShapeWithPointFromUpperLeftToLowerRightTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(20, 30);

            _shapes.SetDrawingShapeName(LINE);
            _shapes.AddShape(startPoint, endPoint);
            int length = _shapes.GetShapesListLength();

            Assert.AreEqual(1, length);
            Assert.AreEqual(LINE, _shapes.GetShapeName(length - 1));
            Assert.AreEqual("(10, 15), (20, 30)", _shapes.GetInfo(length - 1, 1, 1));
        }

        // Add line shape test with point test from lower left to upper right
        [TestMethod()]
        public void AddLineShapeWithPointFromLowerLeftToUpperRightTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(20, 5);

            _shapes.SetDrawingShapeName(LINE);
            _shapes.AddShape(startPoint, endPoint);
            int length = _shapes.GetShapesListLength();

            Assert.AreEqual(1, length);
            Assert.AreEqual(LINE, _shapes.GetShapeName(length - 1));
            Assert.AreEqual("(10, 15), (20, 5)", _shapes.GetInfo(length - 1, 1, 1));
        }

        // Add line shape test with point test from lower right to upper left
        [TestMethod()]
        public void AddLineShapeWithPointFromLowerRightToUpperLeftTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(3, 5);

            _shapes.SetDrawingShapeName(LINE);
            _shapes.AddShape(startPoint, endPoint);
            int length = _shapes.GetShapesListLength();

            Assert.AreEqual(1, length);
            Assert.AreEqual(LINE, _shapes.GetShapeName(length - 1));
            Assert.AreEqual("(10, 15), (3, 5)", _shapes.GetInfo(length - 1, 1, 1));
        }

        // Add line shape test with point test from upper right to lower left
        [TestMethod()]
        public void AddLineShapeWithPointFromUpperRightToLowerLeftTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(3, 30);

            _shapes.SetDrawingShapeName(LINE);
            _shapes.AddShape(startPoint, endPoint);
            int length = _shapes.GetShapesListLength();

            Assert.AreEqual(1, length);
            Assert.AreEqual(LINE, _shapes.GetShapeName(length - 1));
            Assert.AreEqual("(10, 15), (3, 30)", _shapes.GetInfo(length - 1, 1, 1));
        }

        // Add rectangle shape test
        [TestMethod()]
        public void AddRectangleShapeTest()
        {
            _shapes.AddShape(RECTANGLE);
            int length = _shapes.GetShapesListLength();
            Assert.AreEqual(1, length);
            Assert.AreEqual(RECTANGLE, _shapes.GetShapeName(length - 1));
        }

        // Add rectangle shape test with point test from upper left to lower right
        [TestMethod()]
        public void AddRectangleShapeWithPointFromUpperLeftToLowerRightTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(20, 30);

            _shapes.SetDrawingShapeName(RECTANGLE);
            _shapes.AddShape(startPoint, endPoint);
            int length = _shapes.GetShapesListLength();

            Assert.AreEqual(1, length);
            Assert.AreEqual(RECTANGLE, _shapes.GetShapeName(length - 1));
            Assert.AreEqual("(10, 15), (20, 30)", _shapes.GetInfo(length - 1, 1, 1));
        }

        // Add rectangle shape test with point test from lower left to upper right
        [TestMethod()]
        public void AddRectangleShapeWithPointFromLowerLeftToUpperRightTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(20, 5);

            _shapes.SetDrawingShapeName(RECTANGLE);
            _shapes.AddShape(startPoint, endPoint);
            int length = _shapes.GetShapesListLength();

            Assert.AreEqual(1, length);
            Assert.AreEqual(RECTANGLE, _shapes.GetShapeName(length - 1));
            Assert.AreEqual("(10, 5), (20, 15)", _shapes.GetInfo(length - 1, 1, 1));
        }

        // Add rectangle shape test with point test from lower right to upper left
        [TestMethod()]
        public void AddRectangleShapeWithPointFromLowerRightToUpperLeftTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(3, 5);

            _shapes.SetDrawingShapeName(RECTANGLE);
            _shapes.AddShape(startPoint, endPoint);
            int length = _shapes.GetShapesListLength();

            Assert.AreEqual(1, length);
            Assert.AreEqual(RECTANGLE, _shapes.GetShapeName(length - 1));
            Assert.AreEqual("(3, 5), (10, 15)", _shapes.GetInfo(length - 1, 1, 1));
        }

        // Add rectangle shape test with point test from upper right to lower left
        [TestMethod()]
        public void AddRectangleShapeWithPointFromUpperRightToLowerLeftTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(3, 30);

            _shapes.SetDrawingShapeName(RECTANGLE);
            _shapes.AddShape(startPoint, endPoint);
            int length = _shapes.GetShapesListLength();

            Assert.AreEqual(1, length);
            Assert.AreEqual(RECTANGLE, _shapes.GetShapeName(length - 1));
            Assert.AreEqual("(3, 15), (10, 30)", _shapes.GetInfo(length - 1, 1, 1));
        }

        // Add circle shape test
        [TestMethod()]
        public void AddCircleShapeTest()
        {
            _shapes.AddShape(CIRCLE);
            int length = _shapes.GetShapesListLength();
            Assert.AreEqual(1, length);
            Assert.AreEqual(CIRCLE, _shapes.GetShapeName(length - 1));
        }

        // Add circle shape test with point test from upper left to lower right
        [TestMethod()]
        public void AddCircleShapeWithPointFromUpperLeftToLowerRightTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(20, 30);

            _shapes.SetDrawingShapeName(CIRCLE);
            _shapes.AddShape(startPoint, endPoint);
            int length = _shapes.GetShapesListLength();

            Assert.AreEqual(1, length);
            Assert.AreEqual(CIRCLE, _shapes.GetShapeName(length - 1));
            Assert.AreEqual("(10, 15), (20, 30)", _shapes.GetInfo(length - 1, 1, 1));
        }

        // Add circle shape test with point test from lower left to upper right
        [TestMethod()]
        public void AddCircleShapeWithPointFromLowerLeftToUpperRightTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(20, 5);

            _shapes.SetDrawingShapeName(CIRCLE);
            _shapes.AddShape(startPoint, endPoint);
            int length = _shapes.GetShapesListLength();

            Assert.AreEqual(1, length);
            Assert.AreEqual(CIRCLE, _shapes.GetShapeName(length - 1));
            Assert.AreEqual("(10, 5), (20, 15)", _shapes.GetInfo(length - 1, 1, 1));
        }

        // Add circle shape test with point test from lower right to upper left
        [TestMethod()]
        public void AddCircleShapeWithPointFromLowerRightToUpperLeftTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(3, 5);

            _shapes.SetDrawingShapeName(CIRCLE);
            _shapes.AddShape(startPoint, endPoint);
            int length = _shapes.GetShapesListLength();

            Assert.AreEqual(1, length);
            Assert.AreEqual(CIRCLE, _shapes.GetShapeName(length - 1));
            Assert.AreEqual("(3, 5), (10, 15)", _shapes.GetInfo(length - 1, 1, 1));
        }

        // Add circle shape test with point test from upper right to lower left
        [TestMethod()]
        public void AddCircleShapeWithPointFromUpperRightToLowerLeftTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(3, 30);

            _shapes.SetDrawingShapeName(CIRCLE);
            _shapes.AddShape(startPoint, endPoint);
            int length = _shapes.GetShapesListLength();

            Assert.AreEqual(1, length);
            Assert.AreEqual(CIRCLE, _shapes.GetShapeName(length - 1));
            Assert.AreEqual("(3, 15), (10, 30)", _shapes.GetInfo(length - 1, 1, 1));
        }

        // Create line shape with point test from upper left to lower right
        [TestMethod()]
        public void CreateLineShapeWithPointFromUpperLeftToLowerRightTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(20, 30);
            Shape line = _shapes.CreateShape(LINE, startPoint, endPoint);

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
            Shape line = _shapes.CreateShape(LINE, startPoint, endPoint);

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
            Shape line = _shapes.CreateShape(LINE, startPoint, endPoint);

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
            Shape line = _shapes.CreateShape(LINE, startPoint, endPoint);

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
            Shape rectangle = _shapes.CreateShape(RECTANGLE, startPoint, endPoint);

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
            Shape rectangle = _shapes.CreateShape(RECTANGLE, startPoint, endPoint);

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
            Shape rectangle = _shapes.CreateShape(RECTANGLE, startPoint, endPoint);

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
            Shape rectangle = _shapes.CreateShape(RECTANGLE, startPoint, endPoint);

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
            Shape circle = _shapes.CreateShape(CIRCLE, startPoint, endPoint);

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
            Shape circle = _shapes.CreateShape(CIRCLE, startPoint, endPoint);

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
            Shape circle = _shapes.CreateShape(CIRCLE, startPoint, endPoint);

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
            Shape circle = _shapes.CreateShape(CIRCLE, startPoint, endPoint);

            Assert.AreEqual(CIRCLE, circle.GetName());
            Assert.AreEqual("(3, 15)", circle.GetUpperLeftPoint().ToString());
            Assert.AreEqual("(10, 30)", circle.GetLowerRightPoint().ToString());
        }

        // Delete shape when no line is selected test
        [TestMethod()]
        public void DeleteShapeWhenNoLineIsSelectedTest()
        {
            Assert.AreEqual(0, _shapes.GetShapesListLength());

            _shapes.AddShape(LINE);
            int length = _shapes.GetShapesListLength();

            _shapes.DeleteShape();
            Assert.AreEqual(length, _shapes.GetShapesListLength());
        }

        // Delete selected line shape test
        [TestMethod()]
        public void DeleteSelectedLineShapeTest()
        {
            Assert.AreEqual(0, _shapes.GetShapesListLength());

            _shapes.AddShape(LINE);
            _shapes.SetSelectShape(0);
            int length = _shapes.GetShapesListLength();

            _shapes.DeleteShape();
            Assert.AreEqual(length - 1, _shapes.GetShapesListLength());
        }

        // Delete line shape with index test when list just has one element
        [TestMethod()]
        public void DeleteLineShapeWithIndexWhenListJustHasOneElementTest()
        {
            Assert.AreEqual(0, _shapes.GetShapesListLength());

            _shapes.AddShape(LINE);
            Assert.AreEqual(LINE, _shapes.GetShapeName(_shapes.GetShapesListLength() - 1));
            int index = _shapes.GetShapesListLength() - 1;
            Assert.AreEqual(1, _shapes.GetShapesListLength());

            _shapes.DeleteShape(index);
            Assert.AreEqual(0, _shapes.GetShapesListLength());
        }

        // Delete line shape with index test when the deleted shape is the first
        [TestMethod()]
        public void DeleteLineShapeWithIndexWhenShapeIsTheFirstTest()
        {
            _shapes.AddShape(LINE);
            Thread.Sleep(30);
            _shapes.AddShape(LINE);
            Thread.Sleep(30);
            _shapes.AddShape(LINE);
            int length = _shapes.GetShapesListLength();
            string info = _shapes.GetInfo(0, 1, 1);

            _shapes.DeleteShape(0);
            Assert.AreEqual(length - 1, _shapes.GetShapesListLength());
            Assert.AreNotEqual(info, _shapes.GetInfo(0, 1, 1));
        }

        // Delete line shape with index test when the deleted shape is the middle
        [TestMethod()]
        public void DeleteLineShapeWithIndexWhenShapeIsTheMiddleTest()
        {
            _shapes.AddShape(LINE);
            Thread.Sleep(30);
            _shapes.AddShape(LINE);
            Thread.Sleep(30);
            _shapes.AddShape(LINE);
            int length = _shapes.GetShapesListLength();
            string info = _shapes.GetInfo(1, 1, 1);

            _shapes.DeleteShape(1);
            Assert.AreEqual(length - 1, _shapes.GetShapesListLength());
            Assert.AreNotEqual(info, _shapes.GetInfo(1, 1, 1));
        }

        // Delete line shape with index test when the deleted shape is the last
        [TestMethod()]
        public void DeleteLineShapeWithIndexWhenShapeIsTheLastTest()
        {
            _shapes.AddShape(LINE);
            Thread.Sleep(30);
            _shapes.AddShape(LINE);
            Thread.Sleep(30);
            _shapes.AddShape(LINE);
            int length = _shapes.GetShapesListLength();
            string info = _shapes.GetInfo(length - 1, 1, 1);

            _shapes.DeleteShape(length - 1);
            Assert.AreEqual(length - 1, _shapes.GetShapesListLength());
            Assert.AreNotEqual(info, _shapes.GetInfo(_shapes.GetShapesListLength() - 1, 1, 1));
        }

        // Delete line shape when the deleted shape is selected
        [TestMethod()]
        public void DeleteLineShapeWithIndexWhenShapeIsSelectedTest()
        {
            Assert.AreEqual(0, _shapes.GetShapesListLength());

            _shapes.AddShape(LINE);
            _shapes.SetSelectShape(0);
            int length = _shapes.GetShapesListLength();

            _shapes.DeleteShape(0);
            Assert.AreEqual(length - 1, _shapes.GetShapesListLength());
        }

        // Delete shape when no rectangle is selected test
        [TestMethod()]
        public void DeleteShapeWhenNoRectangleIsSelectedTest()
        {
            Assert.AreEqual(0, _shapes.GetShapesListLength());

            _shapes.AddShape(RECTANGLE);
            int length = _shapes.GetShapesListLength();

            _shapes.DeleteShape();
            Assert.AreEqual(length, _shapes.GetShapesListLength());
        }

        // Delete selected rectangle shape test
        [TestMethod()]
        public void DeleteSelectedRectangleShapeTest()
        {
            Assert.AreEqual(0, _shapes.GetShapesListLength());

            _shapes.AddShape(RECTANGLE);
            _shapes.SetSelectShape(0);
            int length = _shapes.GetShapesListLength();

            _shapes.DeleteShape();
            Assert.AreEqual(length - 1, _shapes.GetShapesListLength());
        }

        // Delete rectangle shape with index test when list just has one element
        [TestMethod()]
        public void DeleteRectangleShapeWithIndexWhenListJustHasOneElementTest()
        {
            Assert.AreEqual(0, _shapes.GetShapesListLength());

            _shapes.AddShape(RECTANGLE);
            Assert.AreEqual(RECTANGLE, _shapes.GetShapeName(_shapes.GetShapesListLength() - 1));
            int index = _shapes.GetShapesListLength() - 1;
            Assert.AreEqual(1, _shapes.GetShapesListLength());

            _shapes.DeleteShape(index);
            Assert.AreEqual(0, _shapes.GetShapesListLength());
        }

        // Delete rectangle shape with index test when the deleted shape is the first
        [TestMethod()]
        public void DeleteRectangleShapeWithIndexWhenShapeIsTheFirstTest()
        {
            _shapes.AddShape(RECTANGLE);
            Thread.Sleep(30);
            _shapes.AddShape(RECTANGLE);
            Thread.Sleep(30);
            _shapes.AddShape(RECTANGLE);
            int length = _shapes.GetShapesListLength();
            string info = _shapes.GetInfo(0, 1, 1);

            _shapes.DeleteShape(0);
            Assert.AreEqual(length - 1, _shapes.GetShapesListLength());
            Assert.AreNotEqual(info, _shapes.GetInfo(0, 1, 1));
        }

        // Delete rectangle shape with index test when the deleted shape is the middle
        [TestMethod()]
        public void DeleteRectangleShapeWithIndexWhenShapeIsTheMiddleTest()
        {
            _shapes.AddShape(RECTANGLE);
            Thread.Sleep(30);
            _shapes.AddShape(RECTANGLE);
            Thread.Sleep(30);
            _shapes.AddShape(RECTANGLE);
            int length = _shapes.GetShapesListLength();
            string info = _shapes.GetInfo(1, 1, 1);

            _shapes.DeleteShape(1);
            Assert.AreEqual(length - 1, _shapes.GetShapesListLength());
            Assert.AreNotEqual(info, _shapes.GetInfo(1, 1, 1));
        }

        // Delete rectangle shape with index test when the deleted shape is the last
        [TestMethod()]
        public void DeleteRectangleShapeWithIndexWhenShapeIsTheLastTest()
        {
            _shapes.AddShape(RECTANGLE);
            Thread.Sleep(30);
            _shapes.AddShape(RECTANGLE);
            Thread.Sleep(30);
            _shapes.AddShape(RECTANGLE);
            int length = _shapes.GetShapesListLength();
            string info = _shapes.GetInfo(length - 1, 1, 1);

            _shapes.DeleteShape(length - 1);
            Assert.AreEqual(length - 1, _shapes.GetShapesListLength());
            Assert.AreNotEqual(info, _shapes.GetInfo(_shapes.GetShapesListLength() - 1, 1, 1));
        }

        // Delete rectangle shape when the deleted shape is selected
        [TestMethod()]
        public void DeleteRectangleShapeWithIndexWhenShapeIsSelectedTest()
        {
            Assert.AreEqual(0, _shapes.GetShapesListLength());

            _shapes.AddShape(RECTANGLE);
            _shapes.SetSelectShape(0);
            int length = _shapes.GetShapesListLength();

            _shapes.DeleteShape(0);
            Assert.AreEqual(length - 1, _shapes.GetShapesListLength());
        }

        // Delete shape when no circle is selected test
        [TestMethod()]
        public void DeleteShapeWhenNoCircleIsSelectedTest()
        {
            Assert.AreEqual(0, _shapes.GetShapesListLength());

            _shapes.AddShape(CIRCLE);
            int length = _shapes.GetShapesListLength();

            _shapes.DeleteShape();
            Assert.AreEqual(length, _shapes.GetShapesListLength());
        }

        // Delete selected circle shape test
        [TestMethod()]
        public void DeleteSelectedCircleShapeTest()
        {
            Assert.AreEqual(0, _shapes.GetShapesListLength());

            _shapes.AddShape(CIRCLE);
            _shapes.SetSelectShape(0);
            int length = _shapes.GetShapesListLength();

            _shapes.DeleteShape();
            Assert.AreEqual(length - 1, _shapes.GetShapesListLength());
        }

        // Delete circle shape with index test when list just has one element
        [TestMethod()]
        public void DeleteCircleShapeWithIndexWhenListJustHasOneElementTest()
        {
            Assert.AreEqual(0, _shapes.GetShapesListLength());

            _shapes.AddShape(CIRCLE);
            Assert.AreEqual(CIRCLE, _shapes.GetShapeName(_shapes.GetShapesListLength() - 1));
            int index = _shapes.GetShapesListLength() - 1;
            Assert.AreEqual(1, _shapes.GetShapesListLength());

            _shapes.DeleteShape(index);
            Assert.AreEqual(0, _shapes.GetShapesListLength());
        }

        // Delete circle shape with index test when the deleted shape is the first
        [TestMethod()]
        public void DeleteCircleShapeWithIndexWhenShapeIsTheFirstTest()
        {
            _shapes.AddShape(CIRCLE);
            Thread.Sleep(30);
            _shapes.AddShape(CIRCLE);
            Thread.Sleep(30);
            _shapes.AddShape(CIRCLE);
            int length = _shapes.GetShapesListLength();
            string info = _shapes.GetInfo(0, 1, 1);

            _shapes.DeleteShape(0);
            Assert.AreEqual(length - 1, _shapes.GetShapesListLength());
            Assert.AreNotEqual(info, _shapes.GetInfo(0, 1, 1));
        }

        // Delete circle shape with index test when the deleted shape is the middle
        [TestMethod()]
        public void DeleteCircleShapeWithIndexWhenShapeIsTheMiddleTest()
        {
            _shapes.AddShape(CIRCLE);
            Thread.Sleep(30);
            _shapes.AddShape(CIRCLE);
            Thread.Sleep(30);
            _shapes.AddShape(CIRCLE);
            int length = _shapes.GetShapesListLength();
            string info = _shapes.GetInfo(1, 1, 1);

            _shapes.DeleteShape(1);
            Assert.AreEqual(length - 1, _shapes.GetShapesListLength());
            Assert.AreNotEqual(info, _shapes.GetInfo(1, 1, 1));
        }

        // Delete circle shape with index test when the deleted shape is the last
        [TestMethod()]
        public void DeleteCircleShapeWithIndexWhenShapeIsTheLastTest()
        {
            _shapes.AddShape(CIRCLE);
            Thread.Sleep(30);
            _shapes.AddShape(CIRCLE);
            Thread.Sleep(30);
            _shapes.AddShape(CIRCLE);
            int length = _shapes.GetShapesListLength();
            string info = _shapes.GetInfo(length - 1, 1, 1);

            _shapes.DeleteShape(length - 1);
            Assert.AreEqual(length - 1, _shapes.GetShapesListLength());
            Assert.AreNotEqual(info, _shapes.GetInfo(_shapes.GetShapesListLength() - 1, 1, 1));
        }

        // Delete circle shape when the deleted shape is selected
        [TestMethod()]
        public void DeleteCircleShapeWithIndexWhenShapeIsSelectedTest()
        {
            Assert.AreEqual(0, _shapes.GetShapesListLength());

            _shapes.AddShape(CIRCLE);
            _shapes.SetSelectShape(0);
            int length = _shapes.GetShapesListLength();

            _shapes.DeleteShape(0);
            Assert.AreEqual(length - 1, _shapes.GetShapesListLength());
        }

        // Set linr point test
        [TestMethod()]
        public void SetLinePointTest()
        {
            _shapes.AddShape(LINE);
            _shapes.SetPoint(0, new CoordinatePoint(30, 10), new CoordinatePoint(80, 30));
            Assert.AreEqual("(30, 10), (80, 30)", _shapes.GetInfo(0, 1, 1));
        }

        // Set linr point test
        [TestMethod()]
        public void SetRectanglePointTest()
        {
            _shapes.AddShape(RECTANGLE);
            _shapes.SetPoint(0, new CoordinatePoint(30, 10), new CoordinatePoint(80, 30));
            Assert.AreEqual("(30, 10), (80, 30)", _shapes.GetInfo(0, 1, 1));
        }

        // Set linr point test
        [TestMethod()]
        public void SetCirclePointTest()
        {
            _shapes.AddShape(CIRCLE);
            _shapes.SetPoint(0, new CoordinatePoint(30, 10), new CoordinatePoint(80, 30));
            Assert.AreEqual("(30, 10), (80, 30)", _shapes.GetInfo(0, 1, 1));
        }

        // Get line info test
        [TestMethod()]
        public void GetLineInfoTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(20, 30);
            _shapes.SetDrawingShapeName(LINE);
            _shapes.AddShape(startPoint, endPoint);

            Assert.AreEqual("(10, 15), (20, 30)", _shapes.GetInfo(0, 1, 1));
        }

        // Get rectangle info test
        [TestMethod()]
        public void GetRectangleInfoTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(20, 30);
            _shapes.SetDrawingShapeName(RECTANGLE);
            _shapes.AddShape(startPoint, endPoint);

            Assert.AreEqual("(10, 15), (20, 30)", _shapes.GetInfo(0, 1, 1));
        }

        // Get circle info test
        [TestMethod()]
        public void GetCircleInfoTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(20, 30);
            _shapes.SetDrawingShapeName(CIRCLE);
            _shapes.AddShape(startPoint, endPoint);

            Assert.AreEqual("(10, 15), (20, 30)", _shapes.GetInfo(0, 1, 1));
        }

        // Get line name test
        [TestMethod()]
        public void GetLineNameTest()
        {
            _shapes.AddShape(LINE);
            Assert.AreEqual(LINE, _shapes.GetShapeName(0));
        }

        // Get rectangle name test
        [TestMethod()]
        public void GetRectangleNameTest()
        {
            _shapes.AddShape(RECTANGLE);
            Assert.AreEqual(RECTANGLE, _shapes.GetShapeName(0));
        }

        // Get circle name test
        [TestMethod()]
        public void GetCircleNameTest()
        {
            _shapes.AddShape(CIRCLE);
            Assert.AreEqual(CIRCLE, _shapes.GetShapeName(0));
        }

        // Get line shape date test
        [TestMethod()]
        public void GetLineShapeDataTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(20, 30);
            _shapes.SetDrawingShapeName(LINE);
            _shapes.AddShape(startPoint, endPoint);

            Assert.AreEqual(LINE, _shapes.GetShapeData(0, 1, 1)[1]);
            Assert.AreEqual("(10, 15), (20, 30)", _shapes.GetShapeData(0, 1, 1)[2]);
        }

        // Get rectangle shape date test
        [TestMethod()]
        public void GetRectangleShapeDataTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(20, 30);
            _shapes.SetDrawingShapeName(RECTANGLE);
            _shapes.AddShape(startPoint, endPoint);

            Assert.AreEqual(RECTANGLE, _shapes.GetShapeData(0, 1, 1)[1]);
            Assert.AreEqual("(10, 15), (20, 30)", _shapes.GetShapeData(0, 1, 1)[2]);
        }

        // Get circle shape date test
        [TestMethod()]
        public void GetCircleShapeDataTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(20, 30);
            _shapes.SetDrawingShapeName(CIRCLE);
            _shapes.AddShape(startPoint, endPoint);

            Assert.AreEqual(CIRCLE, _shapes.GetShapeData(0, 1, 1)[1]);
            Assert.AreEqual("(10, 15), (20, 30)", _shapes.GetShapeData(0, 1, 1)[2]);
        }

        // Get shapes list length test when list is empty
        [TestMethod()]
        public void GetShapesListLengthWhenListIsEmptyTest()
        {
            Assert.AreEqual(0, _shapes.GetShapesListLength());
        }

        // Get shapes list length test when list is not empty
        [TestMethod()]
        public void GetShapesListLengthWhenListIsNotEmptyTest()
        {
            int length = 5000;
            for (int i = 0; i < length; i++)
            {
                _shapes.AddShape(LINE);
            }

            Assert.AreEqual(length, _shapes.GetShapesListLength());
        }

        // Set drawing shape name to line test
        [TestMethod()]
        public void SetDrawingShapeNameToLineTest()
        {
            Assert.IsNull(_shapesPrivate.GetFieldOrProperty("_drawingShapeName"));
            _shapes.SetDrawingShapeName(LINE);
            Assert.AreEqual(LINE, (string)_shapesPrivate.GetFieldOrProperty("_drawingShapeName"));
        }

        // Set drawing shape name to rectangle test
        [TestMethod()]
        public void SetDrawingShapeNameToRectangleTest()
        {
            Assert.IsNull(_shapesPrivate.GetFieldOrProperty("_drawingShapeName"));
            _shapes.SetDrawingShapeName(RECTANGLE);
            Assert.AreEqual(RECTANGLE, (string)_shapesPrivate.GetFieldOrProperty("_drawingShapeName"));
        }

        // Set drawing shape name to circle test
        [TestMethod()]
        public void SetDrawingShapeNameToCirclrTest()
        {
            Assert.IsNull(_shapesPrivate.GetFieldOrProperty("_drawingShapeName"));
            _shapes.SetDrawingShapeName(CIRCLE);
            Assert.AreEqual(CIRCLE, (string)_shapesPrivate.GetFieldOrProperty("_drawingShapeName"));
        }

        // Create drawing shape when drawing shape name is null test
        [TestMethod()]
        public void CreateDrawingShapeWhenDrawingShapeNameIsNullTest()
        {
            Assert.IsNull(_shapesPrivate.GetFieldOrProperty("_drawingShapeName"));

            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(20, 30);
            _shapes.CreateDrawingShape(startPoint, endPoint);
            Assert.IsNull(_shapesPrivate.GetFieldOrProperty("_drawingShape"));
        }

        // Create drawing shape test
        [TestMethod()]
        public void CreateDrawingShapeTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(20, 30);
            _shapes.SetDrawingShapeName(LINE);
            Assert.IsNotNull(_shapesPrivate.GetFieldOrProperty("_drawingShapeName"));
            Assert.AreEqual(LINE, (string)_shapesPrivate.GetFieldOrProperty("_drawingShapeName"));

            _shapes.CreateDrawingShape(startPoint, endPoint);
            Assert.IsNotNull(_shapesPrivate.GetFieldOrProperty("_drawingShape"));
            Assert.AreEqual("(10, 15), (20, 30)", ((Shape)_shapesPrivate.GetFieldOrProperty("_drawingShape")).GetInfo(1, 1));
        }

        // Delete drawing shape test
        [TestMethod()]
        public void DeleteDrawingShapeTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(20, 30);
            _shapes.SetDrawingShapeName(LINE);
            _shapes.CreateDrawingShape(startPoint, endPoint);
            Assert.IsNotNull(_shapesPrivate.GetFieldOrProperty("_drawingShape"));

            _shapes.DeleteDrawingShape();
            Assert.IsNull(_shapesPrivate.GetFieldOrProperty("_drawingShape"));
        }

        // Draw line shape test
        [TestMethod()]
        public void DrawLineTest()
        {
            _shapes.AddShape(LINE);
            _shapes.Draw(_mockGraphics);
            Assert.AreEqual(_shapes.GetInfo(0, 1, 1), _mockGraphicsPrivate.GetFieldOrProperty("_startPoint").ToString() + ", " + _mockGraphicsPrivate.GetFieldOrProperty("_endPoint").ToString());
            Assert.AreEqual(LINE, _mockGraphics.GetDrawType());
            Assert.IsTrue(_mockGraphics.IsSuccessful());
        }

        // Draw rectangle shape test
        [TestMethod()]
        public void DrawRectangleTest()
        {
            _shapes.AddShape(RECTANGLE);
            _shapes.Draw(_mockGraphics);
            Assert.AreEqual(_shapes.GetInfo(0, 1, 1).Substring(0, _shapes.GetInfo(0, 1, 1).IndexOf(", (")), _mockGraphicsPrivate.GetFieldOrProperty("_upperLeftPoint").ToString());
            Assert.AreEqual(RECTANGLE, _mockGraphics.GetDrawType());
            Assert.IsTrue(_mockGraphics.IsSuccessful());
        }

        // Draw circle shape test
        [TestMethod()]
        public void DrawCircleTest()
        {
            _shapes.AddShape(CIRCLE);
            _shapes.Draw(_mockGraphics);
            Assert.AreEqual(_shapes.GetInfo(0, 1, 1).Substring(0, _shapes.GetInfo(0, 1, 1).IndexOf(", (")), _mockGraphicsPrivate.GetFieldOrProperty("_upperLeftPoint").ToString());
            Assert.AreEqual(CIRCLE, _mockGraphics.GetDrawType());
            Assert.IsTrue(_mockGraphics.IsSuccessful());
        }

        // Draw drawing shape test
        [TestMethod()]
        public void DrawDrawingShapeTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 15);
            CoordinatePoint endPoint = new CoordinatePoint(20, 30);
            _shapes.SetDrawingShapeName(LINE);
            _shapes.CreateDrawingShape(startPoint, endPoint);
            Assert.IsNotNull(_shapesPrivate.GetFieldOrProperty("_drawingShape"));

            _shapes.Draw(_mockGraphics);
            Assert.AreEqual(startPoint , (CoordinatePoint)_mockGraphicsPrivate.GetFieldOrProperty("_startPoint"));
            Assert.AreEqual(endPoint, (CoordinatePoint)_mockGraphicsPrivate.GetFieldOrProperty("_endPoint"));
            Assert.AreEqual(LINE, _mockGraphics.GetDrawType());
            Assert.IsTrue(_mockGraphics.IsSuccessful());
        }

        // Draw selected shape test
        [TestMethod()]
        public void DrawSelectedShapeTest()
        {
            _shapes.AddShape(RECTANGLE);
            _shapes.SetSelectShape(0);

            _shapes.Draw(_mockGraphics);
            Assert.AreEqual(_shapes.GetInfo(0, 1, 1).Substring(0, _shapes.GetInfo(0, 1, 1).IndexOf(", (")), _mockGraphicsPrivate.GetFieldOrProperty("_upperLeftPoint").ToString());
            Assert.AreEqual("SelectBorder", _mockGraphics.GetDrawType());
            Assert.IsTrue(_mockGraphics.IsSuccessful());
        }

        // Is line select test
        [TestMethod()]
        public void IsLineSelectTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 10);
            CoordinatePoint endPoint = new CoordinatePoint(40, 40);
            _shapes.SetDrawingShapeName(LINE);
            _shapes.AddShape(startPoint, endPoint);

            for(int x = 0; x <= 50; x += 10)
            {
                for(int y = 0; y <= 50; y += 10)
                {
                    if (x >= startPoint.GetPointX() && x <= endPoint.GetPointX() && y >= startPoint.GetPointY() && y <= endPoint.GetPointY())
                        Assert.IsTrue(_shapes.IsSelect(x, y));
                    else
                        Assert.IsFalse(_shapes.IsSelect(x, y));
                }
            }
        }

        // Is rectangle select test
        [TestMethod()]
        public void IsRectangleSelectTest()
        {
            CoordinatePoint upperLeftPoint = new CoordinatePoint(10, 10);
            CoordinatePoint lowerRightPoint = new CoordinatePoint(40, 40);
            _shapes.SetDrawingShapeName(RECTANGLE);
            _shapes.AddShape(upperLeftPoint, lowerRightPoint);

            for (int x = 0; x <= 50; x += 10)
            {
                for (int y = 0; y <= 50; y += 10)
                {
                    if (x >= upperLeftPoint.GetPointX() && x <= lowerRightPoint.GetPointX() && y >= upperLeftPoint.GetPointY() && y <= lowerRightPoint.GetPointY())
                        Assert.IsTrue(_shapes.IsSelect(x, y));
                    else
                        Assert.IsFalse(_shapes.IsSelect(x, y));
                }
            }
        }

        // Is circle select test
        [TestMethod()]
        public void IsCircleSelectTest()
        {
            CoordinatePoint upperLeftPoint = new CoordinatePoint(10, 10);
            CoordinatePoint lowerRightPoint = new CoordinatePoint(40, 40);
            _shapes.SetDrawingShapeName(CIRCLE);
            _shapes.AddShape(upperLeftPoint, lowerRightPoint);

            for (int x = 0; x <= 50; x += 10)
            {
                for (int y = 0; y <= 50; y += 10)
                {
                    if (x >= upperLeftPoint.GetPointX() && x <= lowerRightPoint.GetPointX() && y >= upperLeftPoint.GetPointY() && y <= lowerRightPoint.GetPointY())
                        Assert.IsTrue(_shapes.IsSelect(x, y));
                    else
                        Assert.IsFalse(_shapes.IsSelect(x, y));
                }
            }
        }

        // Set select shape test
        [TestMethod()]
        public void SetSelectShapeTest()
        {
            _shapes.AddShape(LINE);
            _shapes.AddShape(RECTANGLE);
            _shapes.AddShape(CIRCLE);
            int index = 1;

            _shapes.SetSelectShape(index);
            Assert.AreEqual(RECTANGLE, ((Shape)_shapesPrivate.GetFieldOrProperty("_selectedShape")).GetName());
            Assert.AreEqual(index, (int)_shapesPrivate.GetFieldOrProperty("_selectedShapeIndex"));
        }

        // Set select shape out of index test
        [TestMethod()]
        public void SetSelectShapeOutOfIndexTest()
        {
            _shapes.AddShape(LINE);
            _shapes.AddShape(RECTANGLE);
            _shapes.AddShape(CIRCLE);

            int index = 4;
            _shapes.SetSelectShape(index);
            Assert.IsNull((Shape)_shapesPrivate.GetFieldOrProperty("_selectedShape"));

            index = -1;
            _shapes.SetSelectShape(index);
            Assert.IsNull((Shape)_shapesPrivate.GetFieldOrProperty("_selectedShape"));
        }

        // Cancel select shape test
        [TestMethod()]
        public void CanceltSelectShapeTest()
        {
            _shapes.AddShape(LINE);
            _shapes.SetSelectShape(0);
            Assert.IsNotNull((Shape)_shapesPrivate.GetFieldOrProperty("_selectedShape"));

            _shapes.CancelSelect();
            Assert.IsNull((Shape)_shapesPrivate.GetFieldOrProperty("_selectedShape"));
        }

        // Move shape when no select shape test
        [TestMethod()]
        public void MoveWhenNoSelectShapeTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 10);
            CoordinatePoint endPoint = new CoordinatePoint(40, 40);
            _shapes.SetDrawingShapeName(LINE);
            _shapes.AddShape(startPoint, endPoint);
            Assert.IsNull((Shape)_shapesPrivate.GetFieldOrProperty("_selectedShape"));

            _shapes.Move(10, 20);
            Assert.AreEqual("(10, 10), (40, 40)", _shapes.GetInfo(0, 1, 1));
        }

        // Move select shape test
        [TestMethod()]
        public void MoveSelectShapeTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 10);
            CoordinatePoint endPoint = new CoordinatePoint(40, 40);
            _shapes.SetDrawingShapeName(LINE);
            _shapes.AddShape(startPoint, endPoint);
            _shapes.SetSelectShape(0);
            Assert.IsNotNull((Shape)_shapesPrivate.GetFieldOrProperty("_selectedShape"));

            _shapes.Move(10, 20);
            Assert.AreEqual("(20, 30), (50, 60)", _shapes.GetInfo(0, 1, 1));
        }

        // Is line shape scale test
        [TestMethod()]
        public void IsLineScaleTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 10);
            CoordinatePoint endPoint = new CoordinatePoint(40, 40);
            _shapes.SetDrawingShapeName(LINE);
            _shapes.AddShape(startPoint, endPoint);
            _shapes.SetSelectShape(0);

            for (int x = 30; x <= 50; x ++)
            {
                for (int y = 30; y <= 50; y ++)
                {
                    if (x >= endPoint.GetPointX() - HALF_SELECT_POINT_SIZE && 
                        x <= endPoint.GetPointX() + HALF_SELECT_POINT_SIZE && 
                        y >= endPoint.GetPointY() - HALF_SELECT_POINT_SIZE && 
                        y <= endPoint.GetPointY() + HALF_SELECT_POINT_SIZE)
                        Assert.IsTrue(_shapes.IsScale(x, y, 1, 1));
                    else
                        Assert.IsFalse(_shapes.IsScale(x, y, 1, 1));
                }
            }
        }

        // Is rectangle shape scale test
        [TestMethod()]
        public void IsRectangleScaleTest()
        {
            CoordinatePoint upperLeftPoint = new CoordinatePoint(10, 10);
            CoordinatePoint lowerRightPoint = new CoordinatePoint(40, 40);
            _shapes.SetDrawingShapeName(RECTANGLE);
            _shapes.AddShape(upperLeftPoint, lowerRightPoint);
            _shapes.SetSelectShape(0);

            for (int x = 30; x <= 50; x++)
            {
                for (int y = 30; y <= 50; y++)
                {
                    if (x >= lowerRightPoint.GetPointX() - HALF_SELECT_POINT_SIZE &&
                        x <= lowerRightPoint.GetPointX() + HALF_SELECT_POINT_SIZE &&
                        y >= lowerRightPoint.GetPointY() - HALF_SELECT_POINT_SIZE &&
                        y <= lowerRightPoint.GetPointY() + HALF_SELECT_POINT_SIZE)
                        Assert.IsTrue(_shapes.IsScale(x, y, 1, 1));
                    else
                        Assert.IsFalse(_shapes.IsScale(x, y, 1, 1));
                }
            }
        }

        // Is circle shape scale test
        [TestMethod()]
        public void IsCircleScaleTest()
        {
            CoordinatePoint upperLeftPoint = new CoordinatePoint(10, 10);
            CoordinatePoint lowerRightPoint = new CoordinatePoint(40, 40);
            _shapes.SetDrawingShapeName(CIRCLE);
            _shapes.AddShape(upperLeftPoint, lowerRightPoint);
            _shapes.SetSelectShape(0);

            for (int x = 30; x <= 50; x++)
            {
                for (int y = 30; y <= 50; y++)
                {
                    if (x >= lowerRightPoint.GetPointX() - HALF_SELECT_POINT_SIZE &&
                        x <= lowerRightPoint.GetPointX() + HALF_SELECT_POINT_SIZE &&
                        y >= lowerRightPoint.GetPointY() - HALF_SELECT_POINT_SIZE &&
                        y <= lowerRightPoint.GetPointY() + HALF_SELECT_POINT_SIZE)
                        Assert.IsTrue(_shapes.IsScale(x, y, 1, 1));
                    else
                        Assert.IsFalse(_shapes.IsScale(x, y, 1, 1));
                }
            }
        }

        // Scale shape when no select shape test
        [TestMethod()]
        public void ScaleWhenNoSelectShapeTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 10);
            CoordinatePoint endPoint = new CoordinatePoint(40, 40);
            _shapes.SetDrawingShapeName(LINE);
            _shapes.AddShape(startPoint, endPoint);
            Assert.IsNull((Shape)_shapesPrivate.GetFieldOrProperty("_selectedShape"));

            _shapes.Scale(10, 20);
            Assert.AreEqual("(10, 10), (40, 40)", _shapes.GetInfo(0, 1, 1));
        }

        // Scale select shape test
        [TestMethod()]
        public void ScaleSelectShapeTest()
        {
            CoordinatePoint startPoint = new CoordinatePoint(10, 10);
            CoordinatePoint endPoint = new CoordinatePoint(40, 40);
            _shapes.SetDrawingShapeName(LINE);
            _shapes.AddShape(startPoint, endPoint);
            _shapes.SetSelectShape(0);
            Assert.IsNotNull((Shape)_shapesPrivate.GetFieldOrProperty("_selectedShape"));

            _shapes.Scale(10, 20);
            Assert.AreEqual("(10, 10), (50, 60)", _shapes.GetInfo(0, 1, 1));
        }

        // Reset shape point when no select shape test
        [TestMethod()]
        public void ResetPointWhenNoSelectShapeTest()
        {
            CoordinatePoint upperLeftPoint = new CoordinatePoint(10, 10);
            CoordinatePoint lowerRightPoint = new CoordinatePoint(20, 20);
            _shapes.SetDrawingShapeName(RECTANGLE);
            _shapes.AddShape(upperLeftPoint, lowerRightPoint);
            Assert.IsNull((Shape)_shapesPrivate.GetFieldOrProperty("_selectedShape"));

            _shapes.Scale(-15, -15);
            _shapes.ResetPoint();
            Assert.AreEqual("(10, 10), (20, 20)", _shapes.GetInfo(0, 1, 1));
        }

        // Reset select shape point test
        [TestMethod()]
        public void ResetSelectShapePointTest()
        {
            CoordinatePoint upperLeftPoint = new CoordinatePoint(10, 10);
            CoordinatePoint lowerRightPoint = new CoordinatePoint(20, 20);
            _shapes.SetDrawingShapeName(RECTANGLE);
            _shapes.AddShape(upperLeftPoint, lowerRightPoint);
            _shapes.SetSelectShape(0);
            Assert.IsNotNull((Shape)_shapesPrivate.GetFieldOrProperty("_selectedShape"));

            _shapes.Scale(-15, -15);
            _shapes.ResetPoint();
            Assert.AreEqual("(5, 5), (10, 10)", _shapes.GetInfo(0, 1, 1));
        }
    }
}