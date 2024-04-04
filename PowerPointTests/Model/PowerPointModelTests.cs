using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPointTests.MockObject;
using System.Threading;

namespace PowerPoint.Model.Tests
{
    [TestClass()]
    public class PowerPointModelTests
    {
        PowerPointModel _model;
        PrivateObject _modelPrivate;
        MockGraphics _mockGraphics;
        PrivateObject _mockGraphicsPrivate;
        CoordinatePoint _startPoint = new CoordinatePoint(10, 10);
        CoordinatePoint _endPoint = new CoordinatePoint(20, 20);
        const string LINE = "線";
        const string RECTANGLE = "矩形";
        const string CIRCLE = "橢圓";
        const string POINTER_MODE = "Pointer";
        const string DRAWING_MODE = "Drawing";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _model = new PowerPointModel();
            _modelPrivate = new PrivateObject(_model);
            _mockGraphics = new MockGraphics();
            _mockGraphicsPrivate = new PrivateObject(_mockGraphics);
        }

        // Add line shape test
        [TestMethod()]
        public void AddLineShapeTest()
        {
            _model.SetDrawingShapeName(LINE);
            _model.AddShape( _startPoint, _endPoint);
            int length = _model.GetShapesListLength();
            Assert.AreEqual(1, length);
            Assert.AreEqual(LINE, (_model.GetShapeData(length - 1))[1]);
        }

        // Add rectangle shape test
        [TestMethod()]
        public void AddRectangleShapeTest()
        {
            _model.SetDrawingShapeName(RECTANGLE);
            _model.AddShape(_startPoint, _endPoint);
            int length = _model.GetShapesListLength();
            Assert.AreEqual(1, length);
            Assert.AreEqual(RECTANGLE, (_model.GetShapeData(length - 1))[1]);
        }

        // Add circle shape test
        [TestMethod()]
        public void AddCircleShapeTest()
        {
            _model.SetDrawingShapeName(CIRCLE);
            _model.AddShape(_startPoint, _endPoint);
            int length = _model.GetShapesListLength();
            Assert.AreEqual(1, length);
            Assert.AreEqual(CIRCLE, (_model.GetShapeData(length - 1))[1]);
        }

        // Delete shape test when no selected shape
        [TestMethod()]
        public void DeleteWhenNoSelectedShapeTest()
        {
            _model.SetDrawingMode();
            _model.SetDrawingShapeName(LINE);
            _model.ProcessPointerPressed(10, 20);
            _model.ProcessPointerMoved(30, 50);
            _model.ProcessPointerReleased();
            Assert.AreEqual(1, _model.GetShapesListLength());

            _model.SetPointerMode();
            _model.DeleteShape();
            Assert.AreEqual(1, _model.GetShapesListLength());
        }

        // Delete shape test when selected shape
        [TestMethod()]
        public void DeleteSelectedShapeTest()
        {
            _model.SetDrawingMode();
            _model.SetDrawingShapeName(LINE);
            _model.ProcessPointerPressed(10, 20);
            _model.ProcessPointerMoved(30, 50);
            _model.ProcessPointerReleased();
            Assert.AreEqual(1, _model.GetShapesListLength());

            _model.SetPointerMode();
            _model.ProcessPointerPressed(20, 30);
            _model.ProcessPointerReleased();
            _model.DeleteShape();
            Assert.AreEqual(0, _model.GetShapesListLength());
        }

        // Delete line shape with index test when list just has one element
        [TestMethod()]
        public void DeleteLineShapeWithIndexWhenListJustHasOneElementTest()
        {
            Assert.AreEqual(0, _model.GetShapesListLength());
            _model.SetDrawingShapeName(LINE);
            _model.AddShape( _startPoint, _endPoint);
            Assert.AreEqual(LINE, (_model.GetShapeData(_model.GetShapesListLength() - 1))[1]);
            int index = _model.GetShapesListLength() - 1;
            Assert.AreEqual(1, _model.GetShapesListLength());

            _model.DeleteShape(index);
            Assert.AreEqual(0, _model.GetShapesListLength());
        }

        // Delete line shape with index test when the deleted shape is the first
        [TestMethod()]
        public void DeleteLineShapeWithIndexWhenShapeIsTheFirstTest()
        {
            for (int i = 1; i < 4; i++)
            {
                _startPoint = new CoordinatePoint(10 * i, 20 * i);
                _endPoint = new CoordinatePoint(30 * i, 50 * i);
                _model.SetDrawingShapeName(LINE);
                _model.AddShape(_startPoint, _endPoint);
            }
            int length = _model.GetShapesListLength();
            string info = _model.GetShapeData(0)[2];

            _model.DeleteShape(0);
            Assert.AreEqual(length - 1, _model.GetShapesListLength());
            Assert.AreNotEqual(info, _model.GetShapeData(0)[2]);
        }

        // Delete line shape with index test when the deleted shape is the middle
        [TestMethod()]
        public void DeleteLineShapeWithIndexWhenShapeIsTheMiddleTest()
        {
            for (int i = 1; i < 4; i++)
            {
                _startPoint = new CoordinatePoint(10 * i, 20 * i);
                _endPoint = new CoordinatePoint(30 * i, 50 * i);
                _model.SetDrawingShapeName(LINE);
                _model.AddShape(_startPoint, _endPoint);
            }
            int length = _model.GetShapesListLength();
            string info = _model.GetShapeData(1)[2];

            _model.DeleteShape(1);
            Assert.AreEqual(length - 1, _model.GetShapesListLength());
            Assert.AreNotEqual(info, _model.GetShapeData(1)[2]);
        }

        // Delete line shape with index test when the deleted shape is the last
        [TestMethod()]
        public void DeleteLineShapeWithIndexWhenShapeIsTheLastTest()
        {
            for (int i = 1; i < 4; i++)
            {
                _startPoint = new CoordinatePoint(10 * i, 20 * i);
                _endPoint = new CoordinatePoint(30 * i, 50 * i);
                _model.SetDrawingShapeName(LINE);
                _model.AddShape(_startPoint, _endPoint);
            }
            int length = _model.GetShapesListLength();
            string info = _model.GetShapeData(length - 1)[2];

            _model.DeleteShape(length - 1);
            Assert.AreEqual(length - 1, _model.GetShapesListLength());
            Assert.AreNotEqual(info, _model.GetShapeData(_model.GetShapesListLength() - 1));
        }

        // Delete rectangle shape with index test when list just has one element
        [TestMethod()]
        public void DeleteRectangleShapeWithIndexWhenListJustHasOneElementTest()
        {
            Assert.AreEqual(0, _model.GetShapesListLength());

            _model.SetDrawingShapeName(RECTANGLE);
            _model.AddShape(_startPoint, _endPoint);
            Assert.AreEqual(RECTANGLE, (_model.GetShapeData(_model.GetShapesListLength() - 1))[1]);
            int index = _model.GetShapesListLength() - 1;
            Assert.AreEqual(1, _model.GetShapesListLength());

            _model.DeleteShape(index);
            Assert.AreEqual(0, _model.GetShapesListLength());
        }

        // Delete rectangle shape with index test when the deleted shape is the first
        [TestMethod()]
        public void DeleteRectangleShapeWithIndexWhenShapeIsTheFirstTest()
        {
            for (int i = 1; i < 4; i++)
            {
                _startPoint = new CoordinatePoint(10 * i, 20 * i);
                _endPoint = new CoordinatePoint(30 * i, 50 * i);
                _model.SetDrawingShapeName(RECTANGLE);
                _model.AddShape(_startPoint, _endPoint);
            }
            _model.AddShape(_startPoint, _endPoint);
            int length = _model.GetShapesListLength();
            string info = _model.GetShapeData(0)[2];

            _model.DeleteShape(0);
            Assert.AreEqual(length - 1, _model.GetShapesListLength());
            Assert.AreNotEqual(info, _model.GetShapeData(0)[2]);
        }

        // Delete rectangle shape with index test when the deleted shape is the middle
        [TestMethod()]
        public void DeleteRectangleShapeWithIndexWhenShapeIsTheMiddleTest()
        {
            for (int i = 1; i < 4; i++)
            {
                _startPoint = new CoordinatePoint(10 * i, 20 * i);
                _endPoint = new CoordinatePoint(30 * i, 50 * i);
                _model.SetDrawingShapeName(RECTANGLE);
                _model.AddShape(_startPoint, _endPoint);
            }
            int length = _model.GetShapesListLength();
            string info = _model.GetShapeData(1)[2];

            _model.DeleteShape(1);
            Assert.AreEqual(length - 1, _model.GetShapesListLength());
            Assert.AreNotEqual(info, _model.GetShapeData(1)[2]);
        }

        // Delete rectangle shape with index test when the deleted shape is the last
        [TestMethod()]
        public void DeleteRectangleShapeWithIndexWhenShapeIsTheLastTest()
        {
            for (int i = 1; i < 4; i++)
            {
                _startPoint = new CoordinatePoint(10 * i, 20 * i);
                _endPoint = new CoordinatePoint(30 * i, 50 * i);
                _model.SetDrawingShapeName(RECTANGLE);
                _model.AddShape(_startPoint, _endPoint);
            }
            int length = _model.GetShapesListLength();
            string info = _model.GetShapeData(length - 1)[2];

            _model.DeleteShape(length - 1);
            Assert.AreEqual(length - 1, _model.GetShapesListLength());
            Assert.AreNotEqual(info, _model.GetShapeData(_model.GetShapesListLength() - 1));
        }

        // Delete circle shape with index test when list just has one element
        [TestMethod()]
        public void DeleteCircleleShapeWithIndexWhenListJustHasOneElementTest()
        {
            Assert.AreEqual(0, _model.GetShapesListLength());

            _model.SetDrawingShapeName(CIRCLE);
            _model.AddShape(_startPoint, _endPoint);
            Assert.AreEqual(CIRCLE, (_model.GetShapeData(_model.GetShapesListLength() - 1))[1]);
            int index = _model.GetShapesListLength() - 1;
            Assert.AreEqual(1, _model.GetShapesListLength());

            _model.DeleteShape(index);
            Assert.AreEqual(0, _model.GetShapesListLength());
        }

        // Delete circle shape with index test when the deleted shape is the first
        [TestMethod()]
        public void DeleteCircleShapeWithIndexWhenShapeIsTheFirstTest()
        {
            for (int i = 1; i < 4; i++)
            {
                _startPoint = new CoordinatePoint(10 * i, 20 * i);
                _endPoint = new CoordinatePoint(30 * i, 50 * i);
                _model.SetDrawingShapeName(CIRCLE);
                _model.AddShape(_startPoint, _endPoint);
            }
            int length = _model.GetShapesListLength();
            string info = _model.GetShapeData(0)[2];

            _model.DeleteShape(0);
            Assert.AreEqual(length - 1, _model.GetShapesListLength());
            Assert.AreNotEqual(info, _model.GetShapeData(0)[2]);
        }

        // Delete circle shape with index test when the deleted shape is the middle
        [TestMethod()]
        public void DeleteCircleShapeWithIndexWhenShapeIsTheMiddleTest()
        {
            for (int i = 1; i < 4; i++)
            {
                _startPoint = new CoordinatePoint(10 * i, 20 * i);
                _endPoint = new CoordinatePoint(30 * i, 50 * i);
                _model.SetDrawingShapeName(CIRCLE);
                _model.AddShape(_startPoint, _endPoint);
            }
            int length = _model.GetShapesListLength();
            string info = _model.GetShapeData(1)[2];

            _model.DeleteShape(1);
            Assert.AreEqual(length - 1, _model.GetShapesListLength());
            Assert.AreNotEqual(info, _model.GetShapeData(1)[2]);
        }

        // Delete circle shape with index test when the deleted shape is the last
        [TestMethod()]
        public void DeleteCircleShapeWithIndexWhenShapeIsTheLastTest()
        {
            for (int i = 1; i < 4; i++)
            {
                _startPoint = new CoordinatePoint(10 * i, 20 * i);
                _endPoint = new CoordinatePoint(30 * i, 50 * i);
                _model.SetDrawingShapeName(CIRCLE);
                _model.AddShape(_startPoint, _endPoint);
            }
            int length = _model.GetShapesListLength();
            string info = _model.GetShapeData(length - 1)[2];

            _model.DeleteShape(length - 1);
            Assert.AreEqual(length - 1, _model.GetShapesListLength());
            Assert.AreNotEqual(info, _model.GetShapeData(_model.GetShapesListLength() - 1));
        }

        // Get shapes list length test when list is empty
        [TestMethod()]
        public void GetShapesListLengthWhenListIsEmptyTest()
        {
            Assert.AreEqual(0, _model.GetShapesListLength());
        }

        // Get shapes list length test when list is not empty
        [TestMethod()]
        public void GetShapesListLengthWhenListIsNotEmptyTest()
        {
            int length = 5000;
            for (int i = 0; i < length; i++)
            {
                _model.AddShape( _startPoint, _endPoint);
            }

            Assert.AreEqual(length, _model.GetShapesListLength());
        }

        // Get line shape data test
        [TestMethod()]
        public void GetLineShapeDataTest()
        {
            _model.SetDrawingShapeName(LINE);
            _model.AddShape( _startPoint, _endPoint);
            Assert.AreEqual(LINE, (_model.GetShapeData(_model.GetShapesListLength() - 1))[1]);
        }

        // Get rectangle shape data test
        [TestMethod()]
        public void GetRectangleShapeDataTest()
        {
            _model.SetDrawingShapeName(RECTANGLE);
            _model.AddShape(_startPoint, _endPoint);
            Assert.AreEqual(RECTANGLE, (_model.GetShapeData(_model.GetShapesListLength() - 1))[1]);
        }

        // Get circle shape data test
        [TestMethod()]
        public void GetCircleShapeDataTest()
        {
            _model.SetDrawingShapeName(CIRCLE);
            _model.AddShape(_startPoint, _endPoint);
            Assert.AreEqual(CIRCLE, (_model.GetShapeData(_model.GetShapesListLength() - 1))[1]);
        }

        // Draw line shape test
        [TestMethod()]
        public void DrawLineTest()
        {
            _model.SetDrawingShapeName(LINE);
            _model.AddShape( _startPoint, _endPoint);
            _model.Draw(_mockGraphics);
            Assert.AreEqual(_model.GetShapeData(0)[2], _mockGraphicsPrivate.GetFieldOrProperty("_startPoint").ToString() + ", " + _mockGraphicsPrivate.GetFieldOrProperty("_endPoint").ToString());
            Assert.AreEqual(LINE, _mockGraphics.GetDrawType());
            Assert.IsTrue(_mockGraphics.IsSuccessful());
        }

        // Draw rectangle shape test
        [TestMethod()]
        public void DrawRectangleTest()
        {
            _model.SetDrawingShapeName(RECTANGLE);
            _model.AddShape(_startPoint, _endPoint);
            _model.Draw(_mockGraphics);
            Assert.AreEqual(_model.GetShapeData(0)[2].Substring(0, _model.GetShapeData(0)[2].IndexOf(", (")), _mockGraphicsPrivate.GetFieldOrProperty("_upperLeftPoint").ToString());
            Assert.AreEqual(RECTANGLE, _mockGraphics.GetDrawType());
            Assert.IsTrue(_mockGraphics.IsSuccessful());
        }

        // Draw circle shape test
        [TestMethod()]
        public void DrawCircleTest()
        {
            _model.SetDrawingShapeName(CIRCLE);
            _model.AddShape(_startPoint, _endPoint);
            _model.Draw(_mockGraphics);
            Assert.AreEqual(_model.GetShapeData(0)[2].Substring(0, _model.GetShapeData(0)[2].IndexOf(", (")), _mockGraphicsPrivate.GetFieldOrProperty("_upperLeftPoint").ToString());
            Assert.AreEqual(CIRCLE, _mockGraphics.GetDrawType());
            Assert.IsTrue(_mockGraphics.IsSuccessful());
        }

        // Draw drawing shape test
        [TestMethod()]
        public void DrawDrawingShapeTest()
        {
            _model.SetDrawingMode();
            _model.SetDrawingShapeName(LINE);
            _model.ProcessPointerPressed(10, 20);
            _model.Draw(_mockGraphics);
            Assert.AreEqual("(10, 20)", _mockGraphicsPrivate.GetFieldOrProperty("_startPoint").ToString());

            _model.ProcessPointerMoved(30, 50);
            _model.Draw(_mockGraphics);
            Assert.AreEqual("(30, 50)", _mockGraphicsPrivate.GetFieldOrProperty("_endPoint").ToString());

            Assert.AreEqual(LINE, _mockGraphics.GetDrawType());
            Assert.IsTrue(_mockGraphics.IsSuccessful());
            _model.ProcessPointerReleased();
        }

        // Draw selected shape test
        [TestMethod()]
        public void DrawSelectedShapeTest()
        {
            _model.SetDrawingMode();
            _model.SetDrawingShapeName(LINE);
            _model.ProcessPointerPressed(10, 20);
            _model.ProcessPointerMoved(30, 50);
            _model.ProcessPointerReleased();

            _model.SetPointerMode();
            _model.ProcessPointerPressed(20, 30);
            _model.ProcessPointerReleased();

            _model.Draw(_mockGraphics);
            Assert.AreEqual("(10, 20)", _mockGraphicsPrivate.GetFieldOrProperty("_upperLeftPoint").ToString());
            Assert.AreEqual("SelectBorder", _mockGraphics.GetDrawType());
            Assert.IsTrue(_mockGraphics.IsSuccessful());
        }

        // Get mode test
        [TestMethod()]
        public void GetModeTest()
        {
            _model.SetPointerMode();
            Assert.AreEqual(POINTER_MODE, _model.GetMode());
            _model.SetDrawingMode();
            Assert.AreEqual(DRAWING_MODE, _model.GetMode());
        }

        // Set pointer mode test
        [TestMethod()]
        public void SetPointerModeTest()
        {
            _model.SetPointerMode();
            Assert.AreEqual(POINTER_MODE, _model.GetMode());
        }

        // Set drawing mode test
        [TestMethod()]
        public void SetDrawingModeTest()
        {
            _model.SetDrawingMode();
            Assert.AreEqual(DRAWING_MODE, _model.GetMode());
        }

        // Is cursor change test
        [TestMethod()]
        public void IsCursorChangeTest()
        {
            _model.SetDrawingMode();
            Assert.IsTrue(_model.IsCursorChange());
            _model.SetPointerMode();
            Assert.IsFalse(_model.IsCursorChange());
        }

        // Set drawing mode when selected test
        [TestMethod()]
        public void SetDrawingModeWhenSelectedTest()
        {
            _model.SetDrawingMode();
            _model.SetDrawingShapeName(LINE);
            _model.ProcessPointerPressed(10, 20);
            _model.ProcessPointerMoved(30, 50);
            _model.ProcessPointerReleased();

            _model.SetPointerMode();
            _model.ProcessPointerPressed(20, 30);
            _model.ProcessPointerReleased();

            _model.SetDrawingMode();
            Assert.AreEqual(DRAWING_MODE, _model.GetMode());

            _model.Draw(_mockGraphics);
            Assert.AreNotEqual("SelectBorder", _mockGraphics.GetDrawType());
        }

        // Set drawing shape name to line test
        [TestMethod()]
        public void SetDrawingShapeNameToLineTest()
        {
            _model.SetDrawingShapeName(LINE);
            _model.SetDrawingMode();
            _model.ProcessPointerPressed(10, 20);
            _model.Draw(_mockGraphics);
            Assert.AreEqual(LINE, _mockGraphics.GetDrawType());
        }

        // Set drawing shape name to rectangle test
        [TestMethod()]
        public void SetDrawingShapeNameToRectangleTest()
        {

            _model.SetDrawingShapeName(RECTANGLE);
            _model.SetDrawingMode();
            _model.ProcessPointerPressed(10, 20);
            _model.Draw(_mockGraphics);
            Assert.AreEqual(RECTANGLE, _mockGraphics.GetDrawType());
        }

        // Set drawing shape name to circle test
        [TestMethod()]
        public void SetDrawingShapeNameToCircleTest()
        {

            _model.SetDrawingShapeName(CIRCLE);
            _model.SetDrawingMode();
            _model.ProcessPointerPressed(10, 20);
            _model.Draw(_mockGraphics);
            Assert.AreEqual(CIRCLE, _mockGraphics.GetDrawType());
        }

        // Process pointer pressed when pointer mode test
        [TestMethod()]
        public void ProcessPointerPressedWhenPointerModeTest()
        {
            _model.SetDrawingMode();
            _model.SetDrawingShapeName(LINE);
            _model.ProcessPointerPressed(10, 20);
            _model.ProcessPointerMoved(30, 50);
            _model.ProcessPointerReleased();

            _model.SetPointerMode();
            Assert.IsFalse(((IState)_modelPrivate.GetFieldOrProperty("_state")).IsPressed());

            _model.ProcessPointerPressed(20, 30);
            _model.ProcessPointerPressed(20, 30);
            Assert.IsTrue(((IState)_modelPrivate.GetFieldOrProperty("_state")).IsPressed());
        }

        // Process pointer pressed when drawing mode test
        [TestMethod()]
        public void ProcessPointerPressedWhenDrawingModeTest()
        {
            _model.SetDrawingMode();
            Assert.IsFalse(((IState)_modelPrivate.GetFieldOrProperty("_state")).IsPressed());

            _model.SetDrawingShapeName(LINE);
            _model.ProcessPointerPressed(10, 20);
            Assert.IsTrue(((IState)_modelPrivate.GetFieldOrProperty("_state")).IsPressed());
        }

        // Process pointer moved when pointer mode test
        [TestMethod()]
        public void ProcessPointerMovedWhenPointerModeTest()
        {
            _model.SetDrawingMode();
            _model.SetDrawingShapeName(LINE);
            _model.ProcessPointerPressed(10, 20);
            _model.ProcessPointerMoved(30, 50);
            _model.ProcessPointerReleased();

            _model.SetPointerMode();
            Assert.IsNull(((IState)_modelPrivate.GetFieldOrProperty("_state")).GetStartPoint());
            Assert.IsNull(((IState)_modelPrivate.GetFieldOrProperty("_state")).GetEndPoint());

            _model.ProcessPointerPressed(20, 30);
            Assert.AreEqual("(20, 30)", ((IState)_modelPrivate.GetFieldOrProperty("_state")).GetStartPoint().ToString());
            Assert.AreEqual("(20, 30)", ((IState)_modelPrivate.GetFieldOrProperty("_state")).GetEndPoint().ToString());

            _model.ProcessPointerPressed(20, 30);
            _model.ProcessPointerMoved(10, 20);
            Assert.AreEqual("(10, 20)", ((IState)_modelPrivate.GetFieldOrProperty("_state")).GetEndPoint().ToString());
        }

        // Process pointer moved when drawing mode test
        [TestMethod()]
        public void ProcessPointerMovedWhenDrawingModeTest()
        {
            _model.SetDrawingMode();
            Assert.IsNull(((IState)_modelPrivate.GetFieldOrProperty("_state")).GetStartPoint());
            Assert.IsNull(((IState)_modelPrivate.GetFieldOrProperty("_state")).GetEndPoint());

            _model.ProcessPointerPressed(20, 30);
            Assert.AreEqual("(20, 30)", ((IState)_modelPrivate.GetFieldOrProperty("_state")).GetStartPoint().ToString());
            Assert.AreEqual("(20, 30)", ((IState)_modelPrivate.GetFieldOrProperty("_state")).GetEndPoint().ToString());

            _model.ProcessPointerMoved(10, 40);
            Assert.AreEqual("(20, 30)", ((IState)_modelPrivate.GetFieldOrProperty("_state")).GetStartPoint().ToString());
            Assert.AreEqual("(10, 40)", ((IState)_modelPrivate.GetFieldOrProperty("_state")).GetEndPoint().ToString());
        }

        // Process pointer released when pointer mode test
        [TestMethod()]
        public void ProcessPointerReleasedWhenPointerModeTest()
        {
            _model.SetDrawingMode();
            _model.SetDrawingShapeName(LINE);
            _model.ProcessPointerPressed(10, 20);
            _model.ProcessPointerMoved(30, 50);
            _model.ProcessPointerReleased();

            _model.SetPointerMode();
            _model.ProcessPointerPressed(20, 30);
            _model.ProcessPointerPressed(20, 30);
            Assert.IsTrue(((IState)_modelPrivate.GetFieldOrProperty("_state")).IsPressed());
            _model.ProcessPointerReleased();
            Assert.IsFalse(((IState)_modelPrivate.GetFieldOrProperty("_state")).IsPressed());
        }

        // Process pointer released when drawing mode test
        [TestMethod()]
        public void ProcessPointerReleasedWhenDrawingModeTest()
        {
            _model.SetDrawingMode();
            _model.SetDrawingShapeName(LINE);
            _model.ProcessPointerPressed(10, 20);
            Assert.IsTrue(((IState)_modelPrivate.GetFieldOrProperty("_state")).IsPressed());

            _model.ProcessPointerMoved(30, 50);
            _model.ProcessPointerReleased();
            Assert.IsFalse(((IState)_modelPrivate.GetFieldOrProperty("_state")).IsPressed());
        }

        // Get canvas size test
        [TestMethod()]
        public void GetCanvasSizeTest()
        {
            _model.GetCanvasSize(1600, 900);
            Assert.AreEqual(1600, _modelPrivate.GetFieldOrProperty("_canvasWidth"));
            Assert.AreEqual(900, _modelPrivate.GetFieldOrProperty("_canvasHeight"));
        }

        // Is undo test
        [TestMethod()]
        public void IsUndoTest()
        {
            Assert.IsFalse(_model.IsUndo());
            _model.AddShape( _startPoint, _endPoint);
            Assert.IsTrue(_model.IsUndo());
        }

        // Undo test
        [TestMethod()]
        public void UndoTest()
        {
            Assert.IsFalse(_model.IsUndo());
            _model.AddShape( _startPoint, _endPoint);
            Assert.IsTrue(_model.IsUndo());
            _model.Undo();
            Assert.IsFalse(_model.IsUndo());
        }

        // Is redo test
        [TestMethod()]
        public void IsRedoTest()
        {
            Assert.IsFalse(_model.IsRedo());
            _model.AddShape( _startPoint, _endPoint);
            _model.Undo();
            Assert.IsTrue(_model.IsRedo());
            _model.AddShape( _startPoint, _endPoint);
            Assert.IsFalse(_model.IsRedo());
        }

        // Redo test
        [TestMethod()]
        public void Redo()
        {
            Assert.IsFalse(_model.IsRedo());
            _model.AddShape( _startPoint, _endPoint);
            _model.Undo();
            Assert.IsTrue(_model.IsRedo());
            _model.Redo();
            Assert.IsFalse(_model.IsRedo());
        }

        // Notify shape list changed observer test
        [TestMethod()]
        public void NotifyShapeListChangedTest()
        {
            bool isEventTrigger = false;

            _model._shapeListChanged += () => isEventTrigger = true;
            _model.NotifyShapeListChanged();

            Assert.IsTrue(isEventTrigger);
        }

        // Notify drawing observer test
        [TestMethod()]
        public void NotifyDrawingTest()
        {
            bool isEventTrigger = false;
            
            _model._drawing += () => isEventTrigger = true;
            _model.NotifyDrawing();

            Assert.IsTrue(isEventTrigger);
        }

        // Notify canvas size observer test
        [TestMethod()]
        public void NotifyCanvasSizeChangedTest()
        {
            bool isEventTrigger = false;

            _model._canvasSizeChanged += () => isEventTrigger = true;
            _model.NotifyCanvasSizeChanged();

            Assert.IsTrue(isEventTrigger);
        }
    }
}