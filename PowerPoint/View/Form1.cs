using PowerPoint.Model;
using PowerPoint.View;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class PowerPointForm : Form
    {
        private PowerPointModel _model;
        private PowerPointPresentationModel _presentationModel;
        const string CURSOR = "Cursor";
        const string CHECKED = "Checked";
        const float POINT_X_MAX = 3200;
        const float POINT_Y_MAX = 1800;
        const int MARGIN = 16;

        public PowerPointForm(PowerPointModel model, PowerPointPresentationModel presentationModel)
        {
            _model = model;
            _presentationModel = presentationModel;
            InitializeComponent();
            Select();
            UpdateUndoAndRedo();

            // Data Binding
            _canvas.DataBindings.Add(CURSOR, _presentationModel, "GetCursorType");
            _lineButton.DataBindings.Add(CHECKED, _presentationModel, "IsLineButtonChecked");
            _rectangleButton.DataBindings.Add(CHECKED, _presentationModel, "IsRectangleButtonChecked");
            _circleButton.DataBindings.Add(CHECKED, _presentationModel, "IsCircleButtonChecked");
            _arrowButton.DataBindings.Add(CHECKED, _presentationModel, "IsArrowButtonChecked");

            // Event Handler
            _model._shapeListChanged += UpdateUndoAndRedo;
            _model._shapeListChanged += UpdateShapeDataGridView;
            _model._shapeListChanged += UpdateCanvas;
            _model._shapeListChanged += UpdateSlideButton;
            _model._drawing += UpdateCanvas;
            _model._drawing += UpdateSlideButton;
            _model._canvasSizeChanged += UpdateCanvas;
            _model._canvasSizeChanged += UpdateShapeDataGridView;
            _canvas.Paint += HandleCanvasPaint;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.MouseUp += HandleCanvasReleased;
            _slideButton1.Paint += HandleSlideButtonPaint;

            // Control size initialization
            ResizeSlideButton();
            ResizeCanvas();
            ResizeShapeDataGridView();
        }

        // Dispaly data of shape data grid view
        private void DisplayShapeData(int shapesListLength)
        {
            _shapeDataGridView.Rows.Clear();
            for (int i = 0; i < shapesListLength; i++)
            {
                _shapeDataGridView.Rows.Add(_model.GetShapeData(i));
            }
            _shapeDataGridView.ClearSelection();
        }

        // "Add" button click event
        private void ClickAddShapeButton(object sender, EventArgs e)
        {
            _presentationModel.ClickAddShapeButton(_chooseShapeComboBox.Text);
        }

        // "Delete" button of shape data grid view click event
        private void ClickShapeDataGridViewDeleteButton(object sender, DataGridViewCellEventArgs e)
        {
            _presentationModel.ClickShapeDataGridViewDeleteButton(_shapeDataGridView.Columns[e.ColumnIndex].Name, e.RowIndex);
        }

        // "Line" button click event
        private void ClickLineButton(object sender, EventArgs e)
        {
            _presentationModel.ClickLineButton();
        }

        // "Rectangle" button click event
        private void ClickRectangleButton(object sender, EventArgs e)
        {
            _presentationModel.ClickRectangleButton();
        }

        // "Circle" button click event
        private void ClickCircleButton(object sender, EventArgs e)
        {
            _presentationModel.ClickCircleButton();
        }

        // "Arrow" button click event
        private void ClickArrowButton(object sender, EventArgs e)
        {
            _presentationModel.SetPointerMode();
        }

        // "Undo" button click event
        private void ClickUndoButton(object sender, EventArgs e)
        {
            _presentationModel.Undo();
        }

        // "Redo" button click event
        private void ClickRedoButton(object sender, EventArgs e)
        {
            _presentationModel.Redo();
        }

        // Handle key down event
        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            _presentationModel.HandleKeyDown(e.KeyCode);
        }

        // Paint
        public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.Draw(new FormPanelGraphicsAdaptor(e.Graphics, (float)_canvas.Width / POINT_X_MAX, (float)_canvas.Height / POINT_Y_MAX));
        }

        // Paint on slide button
        public void HandleSlideButtonPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.Draw(new FormSlideButtonGraphicsAdaptor(e.Graphics, (float)_slideButton1.Width / POINT_X_MAX, (float)_slideButton1.Height / POINT_Y_MAX));
        }

        // Handle canvas pressed
        public void HandleCanvasPressed(object sender, MouseEventArgs e)
        {
            _presentationModel.ProcessPointerPressed(e.X, e.Y);
        }

        // Handle canvas moved
        public void HandleCanvasMoved(object sender, MouseEventArgs e)
        {
            _presentationModel.ProcessPointerMoved(e.X, e.Y);
        }

        // Handle canvas released
        public void HandleCanvasReleased(object sender, MouseEventArgs e)
        {
            _presentationModel.ProcessPointerReleased();
            _presentationModel.SetPointerMode();
        }

        // Update undo and redo
        private void UpdateUndoAndRedo()
        {
            _undoButton.Enabled = _model.IsUndo();
            _redoButton.Enabled = _model.IsRedo();
        }

        // Update canvas
        private void UpdateCanvas()
        {
            _canvas.Invalidate(true);
        }

        // Update slide button
        private void UpdateSlideButton()
        {
            _slideButton1.Invalidate(true);
        }

        // Update shape data grid view
        private void UpdateShapeDataGridView()
        {
            DisplayShapeData(_model.GetShapesListLength());
        }

        // Handle windows resize
        private void HandleWindowsResize(object sender, EventArgs e)
        {
            ResizeCanvas();
            ResizeShapeDataGridView();
        }

        // Handle split1 move
        private void HandleSplit1Move(object sender, SplitterEventArgs e)
        {
            ResizeSlideButton();
            ResizeCanvas();
        }

        // Handle split2 move
        private void HandleSplit2Move(object sender, SplitterEventArgs e)
        {
            ResizeCanvas();
            ResizeShapeDataGridView();
        }

        // Resize canvas
        private void ResizeCanvas()
        {
            _canvas.Width = _presentationModel.CalculateControlWidth(_splitContainer2.Panel1.Width, MARGIN);
            _canvas.Height = _presentationModel.CalculateControlHeight(_canvas.Width);
            _canvas.Top = _presentationModel.CalculateControlTop(_splitContainer2.Panel1.Height, _canvas.Height);
            _model.GetCanvasSize(_canvas.Width, _canvas.Height);
        }

        // Resize slide button
        private void ResizeSlideButton()
        {
            _slideButton1.Width = _presentationModel.CalculateControlWidth(_splitContainer1.Panel1.Width, MARGIN);
            _slideButton1.Height = _presentationModel.CalculateControlHeight(_slideButton1.Width);
        }

        // Resize shape data grid view
        private void ResizeShapeDataGridView()
        {
            _shapeDataGridView.Width = _presentationModel.CalculateControlWidth(_splitContainer2.Panel2.Width, MARGIN);
            _shapeDataGridView.Height = _presentationModel.CalculateDataGridViewHeight(_splitContainer2.Panel2.Height, _shapeDataGridView.Top, MARGIN);
        }
    }
}