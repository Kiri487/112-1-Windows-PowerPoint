using PowerPoint.Model;
using PowerPoint.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class PowerPointForm : Form
    {
        private PowerPointModel _model;
        private PowerPointPresentationModel _presentationModel;
        List<Button> _slideButtonList = new List<Button>();
        private int _currentPageIndex = 0;
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
            _slideButtonList.Add(_slideButton1);

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
            _model._currentPageChanged += UpdateCanvas;
            _model._currentPageChanged += UpdateShapeDataGridView;
            _model._currentPageChanged += UpdateCurrentPageIndex;
            _model._pageListChanged += UpdateUndoAndRedo;
            _model._pageListChanged += UpdateSlideButtonList;
            _canvas.Paint += HandleCanvasPaint;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.MouseUp += HandleCanvasReleased;
            _slideButtonList[0].Paint += HandleSlideButtonPaint;
            _slideButtonList[0].LostFocus += HandleSlideButtonFocus;

            // Control size initialization
            ResizeSlideButton();
            ResizeCanvas();
            ResizeShapeDataGridView();
        }

        // On show
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            _chooseShapeComboBox.SelectedIndex = 0;
            _splitContainer2.SplitterDistance = _splitContainer2.Width - 300;
            _slideButtonList[0].Focus();
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
            Form addShapeForm = new AddShapeForm(_model, _canvas.Width, _canvas.Height);
            addShapeForm.ShowDialog();
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

        // "SAVE" button click event
        private void ClickSaveButton(object sender, EventArgs e)
        {
            Form saveForm = new SaveForm(_model);
            saveForm.ShowDialog();
        }

        // "LOAD" button click event
        private void ClickLoadButton(object sender, EventArgs e)
        {
            Form loadForm = new LoadForm(_model);
            loadForm.ShowDialog();
        }

        // "Add New Page" button click event
        private void ClickAddNewPageButton(object sender, EventArgs e)
        {
            _presentationModel.ClickAddNewPageButton(_currentPageIndex);
        }

        // Slide button click event
        private void ClickSlideButton(object sender, EventArgs e)
        {
            int buttonIndex = _slideButtonList.IndexOf((Button)sender);
            _presentationModel.ClickSlideButton(buttonIndex);
        }

        // Handle key down event
        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            _presentationModel.HandleKeyDown(e.KeyCode);
        }

        // Combo box drop down Close event
        private void CloseComboBoxDropDown(object sender, EventArgs e)
        {
            _currentPageIndex = _model.GetCurrentPageIndex();
            _slideButtonList[_currentPageIndex].Focus();
        }

        // Paint
        public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.Draw(new FormPanelGraphicsAdaptor(e.Graphics, (float)_canvas.Width / POINT_X_MAX, (float)_canvas.Height / POINT_Y_MAX));
        }

        // Paint on slide button
        public void HandleSlideButtonPaint(object sender, PaintEventArgs e)
        {
            int buttonIndex = _slideButtonList.IndexOf((Button)sender);
            _presentationModel.DrawSlideButton(buttonIndex, new FormSlideButtonGraphicsAdaptor(e.Graphics, (float)_slideButton1.Width / POINT_X_MAX, (float)_slideButton1.Height / POINT_Y_MAX));
        }

        // Focus on slide button
        public void HandleSlideButtonFocus(object sender, EventArgs e)
        {
            int buttonIndex = _slideButtonList.IndexOf((Button)sender);
            if (buttonIndex == _currentPageIndex && _chooseShapeComboBox.Focused == false)
                ((Button)sender).Focus();
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
            _slideButtonList[_currentPageIndex].Invalidate(true);
            this.Invalidate(true);
        }

        // Update slide button
        private void UpdateSlideButtonList()
        {
            while (_slideButtonList.Count() < _model.GetPageLength())
            {
                _slideButtonList.Add(CreateNewSlideButton(_slideButtonList[_currentPageIndex].Top, _slideButtonList[_currentPageIndex].Width, _slideButtonList[_currentPageIndex].Height));
                ResizeSlideButton();
                this.Invalidate(true);
            }
            while (_slideButtonList.Count() > _model.GetPageLength())
            {
                Button deleteButton = _slideButtonList[_slideButtonList.Count() - 1];
                this.Controls.Remove(deleteButton);
                deleteButton.Dispose();
                _slideButtonList.RemoveAt(_slideButtonList.Count() - 1);
                ResizeSlideButton();
                this.Invalidate(true);
            }
        }

        // Update current page index
        private void UpdateCurrentPageIndex()
        {
            _currentPageIndex = _model.GetCurrentPageIndex();
            _slideButtonList[_currentPageIndex].Focus();
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
            _canvas.Width = _presentationModel.CalculateControlWidth(_splitContainer2.Panel1.Width, _splitContainer2.Panel1.Height, 0);
            _canvas.Height = _presentationModel.CalculateControlHeight(_canvas.Width);
            _canvas.Top = _presentationModel.CalculateControlTop(_splitContainer2.Panel1.Height, _canvas.Height);
            _canvas.Left = _presentationModel.CalculateControlLeft(_splitContainer2.Panel1.Width, _canvas.Width);
            _model.GetCanvasSize(_canvas.Width, _canvas.Height);
        }

        // Resize slide button
        private void ResizeSlideButton()
        {

            _slideButtonList[0].Width = _presentationModel.CalculateSlideButtonWidth(_splitContainer1.Panel1.Width, MARGIN);
            _slideButtonList[0].Height = _presentationModel.CalculateControlHeight(_slideButtonList[0].Width);
            for (int i = 1; i < _slideButtonList.Count(); i++)
            {
                _slideButtonList[i].Width = _presentationModel.CalculateSlideButtonWidth(_splitContainer1.Panel1.Width, MARGIN);
                _slideButtonList[i].Height = _presentationModel.CalculateControlHeight(_slideButtonList[i].Width);
                _slideButtonList[i].Top = _presentationModel.CalculateSlideButtonTop(_slideButtonList[i - 1].Top, _slideButtonList[i - 1].Height, MARGIN);
                _slideButtonList[i].Text = _presentationModel.SetSlideButtonText(i);
            }
        }

        // Resize shape data grid view
        private void ResizeShapeDataGridView()
        {
            _shapeDataGridView.Width = _presentationModel.CalculateDataGridViewWidth(_splitContainer2.Panel2.Width, MARGIN);
            _shapeDataGridView.Height = _presentationModel.CalculateDataGridViewHeight(_splitContainer2.Panel2.Height, _shapeDataGridView.Top, MARGIN);
        }

        // Create new slide button
        private Button CreateNewSlideButton(int previousSlideButtonTop, int previousSlideButtonWidth, int previousSlideButtonHeight)
        {
            Button slideButton = new Button();
            slideButton.BackColor = SystemColors.ControlLightLight;
            slideButton.ForeColor = SystemColors.ControlLightLight;
            slideButton.Location = new Point(8, previousSlideButtonTop + previousSlideButtonHeight + MARGIN);
            slideButton.Size = new Size(previousSlideButtonWidth, previousSlideButtonHeight);
            slideButton.TabIndex = 4;
            slideButton.UseVisualStyleBackColor = false;

            slideButton.Paint += HandleSlideButtonPaint;
            slideButton.LostFocus += HandleSlideButtonFocus;
            slideButton.Click += new EventHandler(this.ClickSlideButton);
            this._splitContainer1.Panel1.Controls.Add(slideButton);

            return slideButton;
        }
    }
}