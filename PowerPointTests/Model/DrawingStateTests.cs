using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerPoint.Model.Tests
{
    [TestClass()]
    public class DrawingStateTests
    {
        DrawingState _drawingState;
        PrivateObject _drawingStatePrivate;
        PowerPointModel _model;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _model = new PowerPointModel();
            _drawingState = new DrawingState(_model, 3200, 1800);
            _drawingStatePrivate = new PrivateObject(_drawingState);
        }

        // Update canvas size test
        [TestMethod()]
        public void UpdateCanvasSizeTest()
        {
            _drawingState.UpdateCanvasSize(1600, 900);

            Assert.AreEqual(1600, _drawingStatePrivate.GetFieldOrProperty("_canvasWidth"));
            Assert.AreEqual(900, _drawingStatePrivate.GetFieldOrProperty("_canvasHeight"));
            Assert.AreEqual((float)3200 / (float)1600, _drawingStatePrivate.GetFieldOrProperty("_rateX"));
            Assert.AreEqual((float)1800 / (float)900, _drawingStatePrivate.GetFieldOrProperty("_rateY"));
        }

        // Mouse down test when point X < 0
        [TestMethod()]
        public void MouseDownWhenPointXLessThan0Test()
        {
            _drawingState.MouseDown(-10, 5);
            Assert.IsNull(_drawingState.GetStartPoint());
            Assert.IsNull(_drawingState.GetEndPoint());
            Assert.IsFalse(_drawingState.IsPressed());
        }

        // Mouse down test when point Y < 0
        [TestMethod()]
        public void MouseDownWhenPointYLessThan0Test()
        {
            _drawingState.MouseDown(5, -10);
            Assert.IsNull(_drawingState.GetStartPoint());
            Assert.IsNull(_drawingState.GetEndPoint());
            Assert.IsFalse(_drawingState.IsPressed());
        }

        // Mouse down test
        [TestMethod()]
        public void MouseDownTest()
        {
            _drawingState.MouseDown(10, 30);
            Assert.AreEqual("(10, 30)", _drawingState.GetStartPoint().ToString());
            Assert.AreEqual("(10, 30)", _drawingState.GetEndPoint().ToString());
            Assert.IsTrue(_drawingState.IsPressed());
        }

        // Mouse move when not pressed test
        [TestMethod()]
        public void MouseMoveWhenNotPressedTest()
        {
            Assert.IsFalse(_drawingState.IsPressed());
            _drawingState.MouseMove(10, 30);
            Assert.IsNull(_drawingState.GetEndPoint());
        }

        // Mouse move when is pressed test
        [TestMethod()]
        public void MouseMoveWhenIsPressedTest()
        {
            _drawingState.MouseDown(10, 30);
            Assert.IsTrue(_drawingState.IsPressed());
            _drawingState.MouseMove(20, 40);
            Assert.AreEqual("(10, 30)", _drawingState.GetStartPoint().ToString());
            Assert.AreEqual("(20, 40)", _drawingState.GetEndPoint().ToString());
        }

        // Mouse up when not pressed test
        [TestMethod()]
        public void MouseUpWhenNotPressedTest()
        {
            Assert.IsFalse(_drawingState.IsPressed());
            _drawingState.MouseUp();
            Assert.IsFalse(_drawingState.IsPressed());
        }

        // Mouse up when is pressed test
        [TestMethod()]
        public void MouseUpWhenIsPressedTest()
        {
            _drawingState.MouseDown(10, 30);
            Assert.IsTrue(_drawingState.IsPressed());
            _drawingState.MouseUp();
            Assert.IsFalse(_drawingState.IsPressed());
        }

        // Get _isPressed test
        [TestMethod()]
        public void IsPressedTest()
        {
            _drawingState.MouseDown(20, 30);
            Assert.IsTrue(_drawingState.IsPressed());
            _drawingState.MouseUp();
            Assert.IsFalse(_drawingState.IsPressed());
        }

        // Is cursor change test
        [TestMethod()]
        public void IsCursorChangeTest()
        {
            Assert.IsTrue(_drawingState.IsCursorChange());
        }

        // Get start point test
        [TestMethod()]
        public void GetStartPointTest()
        {
            Assert.IsNull(_drawingState.GetStartPoint());
            _drawingState.MouseDown(10, 30);
            _drawingState.MouseMove(20, 40);
            Assert.AreEqual("(10, 30)", _drawingState.GetStartPoint().ToString());
        }

        // Get end point test
        [TestMethod()]
        public void GetEndPointTest()
        {
            Assert.IsNull(_drawingState.GetEndPoint());
            _drawingState.MouseDown(10, 30);
            _drawingState.MouseMove(20, 40);
            Assert.AreEqual("(20, 40)", _drawingState.GetEndPoint().ToString());
        }
    }
}