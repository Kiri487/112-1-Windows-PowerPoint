using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint.Model;
using PowerPointTests.MockObject;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PowerPoint.View.Tests
{
    [TestClass()]
    public class PowerPointPresentationModelTests
    {
        PowerPointModel _model;
        PowerPointPresentationModel _presentationModel;
        PrivateObject _presentationModelPrivate;
        MockGraphics _mockGraphics;
        const string LINE = "線";
        const string RECTANGLE = "矩形";
        const string CIRCLE = "橢圓";
        const string POINTER_MODE = "Pointer";
        const string DRAWING_MODE = "Drawing";
        const float CANVAS_RATE = (float)9 / (float)16;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _model = new PowerPointModel();
            _presentationModel = new PowerPointPresentationModel(_model);
            _presentationModelPrivate = new PrivateObject(_presentationModel);
            _mockGraphics = new MockGraphics();

            // shapes for test
            _model.SetDrawingMode();
            _model.SetDrawingShapeName(LINE);
            _model.ProcessPointerPressed(10, 20);
            _model.ProcessPointerMoved(30, 50);
            _model.ProcessPointerReleased();
        }

        // Set cursor type test
        [TestMethod()]
        public void SetCursorTypeTest()
        {
            _presentationModel.SetCursorType(POINTER_MODE, false);
            Assert.AreEqual(Cursors.Arrow, _presentationModel.GetCursorType);
            _presentationModel.SetCursorType(POINTER_MODE, true);
            Assert.AreEqual(Cursors.SizeNWSE, _presentationModel.GetCursorType);

            _presentationModel.SetCursorType(DRAWING_MODE, false);
            Assert.AreEqual(Cursors.Cross, _presentationModel.GetCursorType);
            _presentationModel.SetCursorType(DRAWING_MODE, true);
            Assert.AreEqual(Cursors.Cross, _presentationModel.GetCursorType);
        }

        // Get is line button checked test
        [TestMethod()]
        public void IsLineButtonCheckedTest()
        {
            _presentationModel.ClickLineButton();
            Assert.IsTrue(_presentationModel.IsLineButtonChecked);

            _presentationModel.ClickLineButton();
            Assert.IsFalse(_presentationModel.IsLineButtonChecked);
        }

        // Get is rectangle button checked test
        [TestMethod()]
        public void IsRectangleButtonCheckedTest()
        {
            _presentationModel.ClickRectangleButton();
            Assert.IsTrue(_presentationModel.IsRectangleButtonChecked);

            _presentationModel.ClickRectangleButton();
            Assert.IsFalse(_presentationModel.IsRectangleButtonChecked);
        }

        // Get is circle button checked test
        [TestMethod()]
        public void IsCircleButtonCheckedTest()
        {
            _presentationModel.ClickCircleButton();
            Assert.IsTrue(_presentationModel.IsCircleButtonChecked);

            _presentationModel.ClickCircleButton();
            Assert.IsFalse(_presentationModel.IsCircleButtonChecked);
        }

        // Get is arrow button checked test
        [TestMethod()]
        public void IsArrowButtonCheckedTest()
        {
            _presentationModel.ClickLineButton();
            Assert.IsFalse(_presentationModel.IsArrowButtonChecked);

            _presentationModel.ClickLineButton();
            Assert.IsTrue(_presentationModel.IsArrowButtonChecked);
        }

        // "Add" button click event test
        [TestMethod()]
        public void ClickAddShapeButtonTest()
        {
            _presentationModel.SetDrawingMode();
            _presentationModel.ClickAddShapeButton(LINE);
            Assert.IsFalse((bool)_presentationModelPrivate.GetFieldOrProperty("_isLineButtonChecked"));
            Assert.IsFalse((bool)_presentationModelPrivate.GetFieldOrProperty("_isRectangleButtonChecked"));
            Assert.IsFalse((bool)_presentationModelPrivate.GetFieldOrProperty("_isCircleButtonChecked"));
            Assert.IsTrue((bool)_presentationModelPrivate.GetFieldOrProperty("_isArrowButtonChecked"));
            Assert.AreEqual(Cursors.Arrow, _presentationModel.GetCursorType);

            _presentationModel.SetDrawingMode();
            _presentationModel.ClickAddShapeButton(RECTANGLE);
            Assert.IsFalse((bool)_presentationModelPrivate.GetFieldOrProperty("_isLineButtonChecked"));
            Assert.IsFalse((bool)_presentationModelPrivate.GetFieldOrProperty("_isRectangleButtonChecked"));
            Assert.IsFalse((bool)_presentationModelPrivate.GetFieldOrProperty("_isCircleButtonChecked"));
            Assert.IsTrue((bool)_presentationModelPrivate.GetFieldOrProperty("_isArrowButtonChecked"));
            Assert.AreEqual(Cursors.Arrow, _presentationModel.GetCursorType);

            _presentationModel.SetDrawingMode();
            _presentationModel.ClickAddShapeButton(CIRCLE);
            Assert.IsFalse((bool)_presentationModelPrivate.GetFieldOrProperty("_isLineButtonChecked"));
            Assert.IsFalse((bool)_presentationModelPrivate.GetFieldOrProperty("_isRectangleButtonChecked"));
            Assert.IsFalse((bool)_presentationModelPrivate.GetFieldOrProperty("_isCircleButtonChecked"));
            Assert.IsTrue((bool)_presentationModelPrivate.GetFieldOrProperty("_isArrowButtonChecked"));
            Assert.AreEqual(Cursors.Arrow, _presentationModel.GetCursorType);
        }

        // "Delete" button of shape data grid view click event test
        [TestMethod()]
        public void ClickShapeDataGridViewDeleteButtonTest()
        {
            _presentationModel.ClickShapeDataGridViewDeleteButton("", -1);
            Assert.AreNotEqual("_deleteShapeColumn", _presentationModelPrivate.GetFieldOrProperty("_shapeDataGridViewColumnName"));

            _presentationModel.ClickShapeDataGridViewDeleteButton("_deleteShapeColumn", 0);
            Assert.AreEqual("_deleteShapeColumn", _presentationModelPrivate.GetFieldOrProperty("_shapeDataGridViewColumnName"));
        }

        // Click line button once test
        [TestMethod()]
        public void ClickLineButtonOnceTest()
        {
            _presentationModel.ClickLineButton();

            Assert.IsTrue(_presentationModel.IsLineButtonChecked);
            Assert.IsFalse(_presentationModel.IsRectangleButtonChecked);
            Assert.IsFalse(_presentationModel.IsCircleButtonChecked);
            Assert.IsFalse(_presentationModel.IsArrowButtonChecked);
        }

        // Click line button twice test
        [TestMethod()]
        public void ClickLineButtonTwiceTest()
        {
            _presentationModel.ClickLineButton();
            _presentationModel.ClickLineButton();

            Assert.IsFalse(_presentationModel.IsLineButtonChecked);
            Assert.IsFalse(_presentationModel.IsRectangleButtonChecked);
            Assert.IsFalse(_presentationModel.IsCircleButtonChecked);
            Assert.IsTrue(_presentationModel.IsArrowButtonChecked);
        }

        // Click rectangle button once test
        [TestMethod()]
        public void ClickRectangleButtonOnceTest()
        {
            _presentationModel.ClickRectangleButton();

            Assert.IsFalse(_presentationModel.IsLineButtonChecked);
            Assert.IsTrue(_presentationModel.IsRectangleButtonChecked);
            Assert.IsFalse(_presentationModel.IsCircleButtonChecked);
            Assert.IsFalse(_presentationModel.IsArrowButtonChecked);
        }

        // Click rectangle button twice test
        [TestMethod()]
        public void ClickRectangleButtonTwiceTest()
        {
            _presentationModel.ClickRectangleButton();
            _presentationModel.ClickRectangleButton();

            Assert.IsFalse(_presentationModel.IsLineButtonChecked);
            Assert.IsFalse(_presentationModel.IsRectangleButtonChecked);
            Assert.IsFalse(_presentationModel.IsCircleButtonChecked);
            Assert.IsTrue(_presentationModel.IsArrowButtonChecked);
        }

        // Click circle button once test
        [TestMethod()]
        public void ClickCircleButtonOnceTest()
        {
            _presentationModel.ClickCircleButton();

            Assert.IsFalse(_presentationModel.IsLineButtonChecked);
            Assert.IsFalse(_presentationModel.IsRectangleButtonChecked);
            Assert.IsTrue(_presentationModel.IsCircleButtonChecked);
            Assert.IsFalse(_presentationModel.IsArrowButtonChecked);
        }

        // Click circle button twice test
        [TestMethod()]
        public void ClickCircleButtonTwiceTest()
        {
            _presentationModel.ClickCircleButton();
            _presentationModel.ClickCircleButton();

            Assert.IsFalse(_presentationModel.IsLineButtonChecked);
            Assert.IsFalse(_presentationModel.IsRectangleButtonChecked);
            Assert.IsFalse(_presentationModel.IsCircleButtonChecked);
            Assert.IsTrue(_presentationModel.IsArrowButtonChecked);
        }

        // Handle "delete" key down event test
        [TestMethod()]
        public void HandleDeleteKeyDownTest()
        {
            _presentationModel.HandleKeyDown(Keys.Enter);
            Assert.AreNotEqual(Keys.Delete, (Keys)_presentationModelPrivate.GetFieldOrProperty("_keyCode"));

            _presentationModel.HandleKeyDown(Keys.Delete);
            Assert.AreEqual(Keys.Delete, (Keys)_presentationModelPrivate.GetFieldOrProperty("_keyCode"));
        }

        // Set pointer mode test
        [TestMethod()]
        public void SetPointerModeTest()
        {
            _presentationModel.SetPointerMode();
            Assert.IsFalse((bool)_presentationModelPrivate.GetFieldOrProperty("_isLineButtonChecked"));
            Assert.IsFalse((bool)_presentationModelPrivate.GetFieldOrProperty("_isRectangleButtonChecked"));
            Assert.IsFalse((bool)_presentationModelPrivate.GetFieldOrProperty("_isCircleButtonChecked"));
            Assert.IsTrue((bool)_presentationModelPrivate.GetFieldOrProperty("_isArrowButtonChecked"));
            Assert.AreEqual(Cursors.Arrow, _presentationModel.GetCursorType);
        }

        // Set drawing mode test
        [TestMethod()]
        public void SetDrawingModeTest()
        {
            _presentationModel.SetDrawingMode();
            Assert.IsFalse((bool)_presentationModelPrivate.GetFieldOrProperty("_isArrowButtonChecked"));
        }
        
        // Draw test
        [TestMethod()]
        public void DrawCanvasTest()
        {
            _presentationModel.Draw(_mockGraphics);
            Assert.IsTrue(_mockGraphics.IsSuccessful());
        }

        // Process pointer pressed
        [TestMethod()]
        public void ProcessPointerPressedTest()
        {
            _presentationModel.SetPointerMode();
            _presentationModel.ProcessPointerPressed(20, 30);
            _presentationModel.ProcessPointerMoved(31, 51);
            Assert.AreEqual(Cursors.SizeNWSE, _presentationModel.GetCursorType);
        }

        // Process pointer moved
        [TestMethod()]
        public void ProcessPointerMovedTest()
        {
            _presentationModel.SetPointerMode();
            _presentationModel.ProcessPointerMoved(10, 20);
            Assert.AreEqual(Cursors.Arrow, _presentationModel.GetCursorType);
            _presentationModel.SetDrawingMode();
            _presentationModel.ProcessPointerMoved(10, 20);
            Assert.AreEqual(Cursors.Cross, _presentationModel.GetCursorType);
        }

        // Process pointer released
        [TestMethod()]
        public void ProcessPointerReleasedWhenPointerModeTest()
        {
            _presentationModel.SetDrawingMode();
            _presentationModel.ProcessPointerReleased();
            Assert.AreEqual(Cursors.Arrow, _presentationModel.GetCursorType);
        }

        // Undo test
        [TestMethod()]
        public void UndoTest()
        {
            _presentationModel.SetDrawingMode();
            _presentationModel.Undo();
            Assert.IsFalse((bool)_presentationModelPrivate.GetFieldOrProperty("_isLineButtonChecked"));
            Assert.IsFalse((bool)_presentationModelPrivate.GetFieldOrProperty("_isRectangleButtonChecked"));
            Assert.IsFalse((bool)_presentationModelPrivate.GetFieldOrProperty("_isCircleButtonChecked"));
            Assert.IsTrue((bool)_presentationModelPrivate.GetFieldOrProperty("_isArrowButtonChecked"));
            Assert.AreEqual(Cursors.Arrow, _presentationModel.GetCursorType);
        }

        // Redo test
        [TestMethod()]
        public void RedoTest()
        {
            _presentationModel.SetDrawingMode();
            _presentationModel.Redo();
            Assert.IsFalse((bool)_presentationModelPrivate.GetFieldOrProperty("_isLineButtonChecked"));
            Assert.IsFalse((bool)_presentationModelPrivate.GetFieldOrProperty("_isRectangleButtonChecked"));
            Assert.IsFalse((bool)_presentationModelPrivate.GetFieldOrProperty("_isCircleButtonChecked"));
            Assert.IsTrue((bool)_presentationModelPrivate.GetFieldOrProperty("_isArrowButtonChecked"));
            Assert.AreEqual(Cursors.Arrow, _presentationModel.GetCursorType);
        }

        // Calculate control width test
        [TestMethod()]
        public void CalculateControlWidthTest()
        {
            Assert.AreEqual(5, _presentationModel.CalculateControlWidth(10, 5));
        }

        // Calculate control width test
        [TestMethod()]
        public void CalculateControlHeightTest()
        {
            Assert.AreEqual(9, _presentationModel.CalculateControlHeight(16));
        }

        // Calculate control top test
        [TestMethod()]
        public void CalculateControlTopTest()
        {
            Assert.AreEqual(5, _presentationModel.CalculateControlTop(20, 10));
        }

        // Calculate data grid view height test
        [TestMethod()]
        public void CalculateDataGridViewHeight()
        {
            Assert.AreEqual(10, _presentationModel.CalculateDataGridViewHeight(40, 20, 10));
        }

        // Data Binding notify test
        [TestMethod()]
        public void NotifyTest()
        {
            bool isEventTrigger = false;
            _presentationModel.PropertyChanged += (sender, args) => isEventTrigger = true;
            _presentationModel.Notify("EventHandlerTest");

            Assert.IsTrue(isEventTrigger);
        }
    }
}