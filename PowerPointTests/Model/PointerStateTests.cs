using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerPoint.Model.Tests
{
    [TestClass()]
    public class PointerStateTests
    {
        PointerState _pointerState;
        PrivateObject _pointerStatePrivate;
        PowerPointModel _model;
        const string LINE = "線";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _model = new PowerPointModel();
            _pointerState = new PointerState(_model, 3200, 1800);
            _pointerStatePrivate = new PrivateObject(_pointerState);

            // shape to test select
            CoordinatePoint startPoint = new CoordinatePoint(10, 10);
            CoordinatePoint endPoint = new CoordinatePoint(40, 40);
            _model.SetDrawingShapeName(LINE);
            _model.DrawShape(startPoint, endPoint);
        }

        // Update canvas size test
        [TestMethod()]
        public void UpdateCanvasSizeTest()
        {
            _pointerState.UpdateCanvasSize(1600, 900);

            Assert.AreEqual(1600, _pointerStatePrivate.GetFieldOrProperty("_canvasWidth"));
            Assert.AreEqual(900, _pointerStatePrivate.GetFieldOrProperty("_canvasHeight"));
            Assert.AreEqual((float)3200 / (float)1600, _pointerStatePrivate.GetFieldOrProperty("_rateX"));
            Assert.AreEqual((float)1800 / (float)900, _pointerStatePrivate.GetFieldOrProperty("_rateY"));
        }

        // Mouse down test when point X < 0
        [TestMethod()]
        public void MouseDownWhenPointXLessThan0Test()
        {
            _pointerState.MouseDown(-10, 5);
            Assert.IsNull(_pointerState.GetStartPoint());
            Assert.IsNull(_pointerState.GetEndPoint());
            Assert.IsFalse((bool)_pointerStatePrivate.GetFieldOrProperty("_isSelect"));
        }

        // Mouse down test when point Y < 0
        [TestMethod()]
        public void MouseDownWhenPointYLessThan0Test()
        {
            _pointerState.MouseDown(5, -10);
            Assert.IsNull(_pointerState.GetStartPoint());
            Assert.IsNull(_pointerState.GetEndPoint());
            Assert.IsFalse((bool)_pointerStatePrivate.GetFieldOrProperty("_isSelect"));
        }

        // Mouse down test
        [TestMethod()]
        public void MouseDownTest()
        {
            _pointerState.MouseDown(5, 30);
            Assert.AreEqual("(5, 30)", _pointerState.GetStartPoint().ToString());
            Assert.AreEqual("(5, 30)", _pointerState.GetEndPoint().ToString());
            Assert.IsFalse((bool)_pointerStatePrivate.GetFieldOrProperty("_isSelect"));
        }

        // Mouse down test when is select
        [TestMethod()]
        public void MouseDownWhenIsSelectTest()
        {
            _pointerState.MouseDown(20, 30);
            Assert.IsTrue((bool)_pointerStatePrivate.GetFieldOrProperty("_isSelect"));
            _pointerState.MouseDown(20, 30);
            Assert.IsTrue(_pointerState.IsPressed());
        }

        // Mouse down test when cancel select
        [TestMethod()]
        public void MouseDownWhenCancelSelectTest()
        {
            _pointerState.MouseDown(20, 30);
            Assert.IsTrue((bool)_pointerStatePrivate.GetFieldOrProperty("_isSelect"));
            _pointerState.MouseDown(5, 30);
            Assert.IsFalse((bool)_pointerStatePrivate.GetFieldOrProperty("_isSelect"));
        }

        // Mouse move when not scale test
        [TestMethod()]
        public void MouseMoveWhenNotScaleTest()
        {
            Assert.IsFalse(_pointerState.IsScale());
            _pointerState.MouseMove(10, 30);
            Assert.IsNull(_pointerState.GetStartPoint());
            Assert.IsNull(_pointerState.GetEndPoint());
        }

        // Mouse move when is scale test
        [TestMethod()]
        public void MouseMoveWhenIsScaleTest()
        {
            _pointerState.MouseDown(20, 30);
            _pointerState.MouseDown(41, 41);
            Assert.IsTrue(_pointerState.IsScale());

            _pointerState.MouseMove(20, 50);
            Assert.AreEqual("(20, 50)", _pointerState.GetEndPoint().ToString());
        }

        // Mouse move when not pressed test
        [TestMethod()]
        public void MouseMoveWhenNotPressedTest()
        {
            Assert.IsFalse(_pointerState.IsPressed());
            _pointerState.MouseMove(10, 30);
            Assert.IsNull(_pointerState.GetStartPoint());
            Assert.IsNull(_pointerState.GetEndPoint());
        }

        // Mouse move when is pressed test
        [TestMethod()]
        public void MouseMoveWhenIsPressedTest()
        {
            _pointerState.MouseDown(20, 30);
            Assert.IsTrue((bool)_pointerStatePrivate.GetFieldOrProperty("_isSelect"));
            _pointerState.MouseDown(20, 30);
            Assert.IsTrue(_pointerState.IsPressed());

            _pointerState.MouseMove(20, 50);
            Assert.AreEqual("(20, 50)", _pointerState.GetEndPoint().ToString());
        }

        // Mouse up when not pressed test
        [TestMethod()]
        public void MouseUpWhenNotPressedTest()
        {
            Assert.IsFalse(_pointerState.IsPressed());
            _pointerState.MouseUp();
            Assert.IsFalse(_pointerState.IsPressed());
        }

        // Mouse up when is pressed test
        [TestMethod()]
        public void MouseUpWhenIsPressedTest()
        {
            _pointerState.MouseDown(20, 30);
            _pointerState.MouseDown(20, 30);
            Assert.IsTrue(_pointerState.IsPressed());
            _pointerState.MouseUp();
            Assert.IsFalse(_pointerState.IsPressed());
        }

        // Mouse up when is pressed wuth offset X test
        [TestMethod()]
        public void MouseUpWhenIsPressedWithOffsetXTest()
        {
            _pointerState.MouseDown(20, 30);
            _pointerState.MouseDown(20, 30);
            Assert.IsTrue(_pointerState.IsPressed());
            _pointerState.MouseMove(10, 30);
            Assert.IsFalse(_pointerState.IsScale());
            _pointerState.MouseUp();
            Assert.IsFalse(_pointerState.IsPressed());
        }

        // Mouse up when is pressed wuth offset Y test
        [TestMethod()]
        public void MouseUpWhenIsPressedWithOffsetYTest()
        {
            _pointerState.MouseDown(20, 30);
            _pointerState.MouseDown(20, 30);
            Assert.IsTrue(_pointerState.IsPressed());
            _pointerState.MouseMove(20, 40);
            Assert.IsFalse(_pointerState.IsScale());
            _pointerState.MouseUp();
            Assert.IsFalse(_pointerState.IsPressed());
        }

        // Get _isPressed test
        [TestMethod()]
        public void IsPressedTest()
        {
            _pointerState.MouseDown(20, 30);
            _pointerState.MouseDown(20, 30);
            Assert.IsTrue(_pointerState.IsPressed());
            _pointerState.MouseUp();
            Assert.IsFalse(_pointerState.IsPressed());
        }

        // Get _isScale test
        [TestMethod()]
        public void IsScaleTest()
        {
            _pointerState.MouseDown(20, 30);
            _pointerState.MouseDown(41, 41);
            Assert.IsTrue(_pointerState.IsScale());
            _pointerState.MouseUp();
            Assert.IsFalse(_pointerState.IsScale());
        }

        // Get _isCursorChange
        [TestMethod()]
        public void IsCursorChangeTest()
        {
            _pointerState.MouseDown(20, 30);
            _pointerState.MouseMove(41, 41);
            Assert.IsTrue(_pointerState.IsCursorChange());
            _pointerState.MouseUp();
            Assert.IsFalse(_pointerState.IsScale());
        }

        // Get start point test
        [TestMethod()]
        public void GetStartPointTest()
        {
            Assert.IsNull(_pointerState.GetStartPoint());
            _pointerState.MouseDown(20, 30);
            _pointerState.MouseDown(20, 30);

            Assert.AreEqual("(20, 30)", _pointerState.GetStartPoint().ToString());
        }

        // Get end point test
        [TestMethod()]
        public void GetEndPointTest()
        {
            Assert.IsNull(_pointerState.GetEndPoint());
            _pointerState.MouseDown(20, 30);
            _pointerState.MouseDown(20, 30);

            _pointerState.MouseMove(20, 50);
            Assert.AreEqual("(20, 50)", _pointerState.GetEndPoint().ToString());
        }
    }
}