using PowerPoint.Model;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PowerPoint.View
{
    public class PowerPointPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private PowerPointModel _model;
        public PowerPointPresentationModel(PowerPointModel model)
        {
            _model = model;
        }

        // Variable
        private bool _isLineButtonChecked = false;
        private bool _isRectangleButtonChecked = false;
        private bool _isCircleButtonChecked = false;
        private bool _isArrowButtonChecked = true;
        private bool _isPageCanDelete = false;
        private string _shapeDataGridViewColumnName;
        const string LINE = "線";
        const string RECTANGLE = "矩形";
        const string CIRCLE = "橢圓";
        const string PAGE = "page";
        const string GET_CURSOR_TYPE = "GetCursorType";
        const string DELETE_SHAPE_COLUMN = "_deleteShapeColumn";
        const string IS_LINE_BUTTON_CHECKED = "IsLineButtonChecked";
        const string IS_RECTANGLE_BUTTON_CHECKED = "IsRectangleButtonChecked";
        const string IS_CIRCLE_BUTTON_CHECKED = "IsCircleButtonChecked";
        const string IS_ARROW_BUTTON_CHECKED = "IsArrowButtonChecked";
        const string POINTER_MODE = "Pointer";
        const string DRAWING_MODE = "Drawing";
        const float CANVAS_RATE = (float)9 / (float)16;
        const float HALF = (float)0.5;
        Cursor _cursorType = Cursors.Arrow;
        Keys _keyCode;

        // Get cursor type
        public Cursor GetCursorType
        {
            get
            {
                return _cursorType;
            }
        }

        // is line button checked
        public bool IsLineButtonChecked
        {
            get
            {
                return _isLineButtonChecked;
            }
        }

        // is rectangle button checked
        public bool IsRectangleButtonChecked
        {
            get
            {
                return _isRectangleButtonChecked;
            }
        }

        // is circle button checked
        public bool IsCircleButtonChecked
        {
            get
            {
                return _isCircleButtonChecked;
            }
        }

        // is arrow button checked
        public bool IsArrowButtonChecked
        {
            get
            {
                return _isArrowButtonChecked;
            }
        }

        // "Add" button click event
        public void ClickAddShapeButton(string shapeType)
        {
            _isPageCanDelete = false;
            _model.SetDrawingShapeName(shapeType);
            SetPointerMode();
        }

        // "Delete" button of shape data grid view click event
        public void ClickShapeDataGridViewDeleteButton(string columnName, int rowIndex)
        {
            _isPageCanDelete = false;
            _shapeDataGridViewColumnName = columnName;
            if (_shapeDataGridViewColumnName == DELETE_SHAPE_COLUMN && rowIndex >= 0)
                _model.DeleteShape(rowIndex);
        }

        // Click line button
        public void ClickLineButton()
        {
            _isPageCanDelete = false;
            _isLineButtonChecked = !_isLineButtonChecked;
            _isRectangleButtonChecked = false;
            _isCircleButtonChecked = false;
            Notify(IS_LINE_BUTTON_CHECKED);
            Notify(IS_RECTANGLE_BUTTON_CHECKED);
            Notify(IS_CIRCLE_BUTTON_CHECKED);

            if (_isLineButtonChecked)
            {
                SetDrawingMode();
                _model.SetDrawingShapeName(LINE);
            }
            else
                SetPointerMode();
        }

        // Click rectangle button
        public void ClickRectangleButton()
        {
            _isPageCanDelete = false;
            _isLineButtonChecked = false;
            _isRectangleButtonChecked = !_isRectangleButtonChecked;
            _isCircleButtonChecked = false;
            Notify(IS_LINE_BUTTON_CHECKED);
            Notify(IS_RECTANGLE_BUTTON_CHECKED);
            Notify(IS_CIRCLE_BUTTON_CHECKED);

            if (_isRectangleButtonChecked)
            {
                SetDrawingMode();
                _model.SetDrawingShapeName(RECTANGLE);
            }
            else
                SetPointerMode();
        }

        // Click circle button
        public void ClickCircleButton()
        {
            _isPageCanDelete = false;
            _isLineButtonChecked = false;
            _isRectangleButtonChecked = false;
            _isCircleButtonChecked = !_isCircleButtonChecked;
            Notify(IS_LINE_BUTTON_CHECKED);
            Notify(IS_RECTANGLE_BUTTON_CHECKED);
            Notify(IS_CIRCLE_BUTTON_CHECKED);

            if (_isCircleButtonChecked)
            {
                SetDrawingMode();
                _model.SetDrawingShapeName(CIRCLE);
            }
            else
                SetPointerMode();
        }

        // Click add new page button
        public void ClickAddNewPageButton(int currentPageIndex)
        {
            _isPageCanDelete = false;
            _model.AddPage(currentPageIndex);
            SetPointerMode();
        }

        // Click slide button
        public void ClickSlideButton(int buttonIndex)
        {
            _model.SetCurrentPageIndex(buttonIndex);
            _model.CancelSelect();
            _isPageCanDelete = true;
            SetPointerMode();
        }

        // Handle key down event
        public void HandleKeyDown(Keys keyCode)
        {
            _keyCode = keyCode;
            if (_keyCode == Keys.Delete)
            {
                _model.DeleteShape();
                if (_isPageCanDelete)
                    _model.DeletePage();
            }      
        }

        // Set pointer mode
        public void SetPointerMode()
        {
            _isLineButtonChecked = false;
            _isRectangleButtonChecked = false;
            _isCircleButtonChecked = false;
            _isArrowButtonChecked = true;
            Notify(IS_LINE_BUTTON_CHECKED);
            Notify(IS_RECTANGLE_BUTTON_CHECKED);
            Notify(IS_CIRCLE_BUTTON_CHECKED);
            Notify(IS_ARROW_BUTTON_CHECKED);
            _model.SetPointerMode();
        }

        // Set drawing mode
        public void SetDrawingMode()
        {
            _isArrowButtonChecked = false;
            Notify(IS_ARROW_BUTTON_CHECKED);
            _model.SetDrawingMode();
        }

        // Set cursor type
        public void SetCursorType(string mode, bool isChange)
        {
            if (mode == POINTER_MODE)
                _cursorType = isChange ? Cursors.SizeNWSE : Cursors.Arrow;
            else // mode == DRAWING_MODE
                _cursorType = Cursors.Cross;
            Notify(GET_CURSOR_TYPE);
        }

        // Draw
        public void Draw(IGraphics graphics)
        {
            _model.Draw(graphics);
        }

        // Draw slide button
        public void DrawSlideButton(int pageIndex, IGraphics graphics)
        {
            _model.Draw(pageIndex, graphics);
        }

        // Process pointer pressed
        public void ProcessPointerPressed(int pointX, int pointY)
        {
            _model.ProcessPointerPressed(pointX, pointY);
        }

        // Process pointer moved
        public void ProcessPointerMoved(int pointX, int pointY)
        {
            _model.ProcessPointerMoved(pointX, pointY);
            SetCursorType(_model.GetMode(), _model.IsCursorChange());
        }

        // Process pointer released
        public void ProcessPointerReleased()
        {
            _isPageCanDelete = false;
            _model.ProcessPointerReleased();
        }

        // Undo
        public void Undo()
        {
            _isPageCanDelete = false;
            _model.Undo();
            SetPointerMode();
        }

        // Redo
        public void Redo()
        {
            _isPageCanDelete = false;
            _model.Redo();
            SetPointerMode();
        }

        // Calculate control width
        public int CalculateControlWidth(int containerWidth, int containerHeight, int margin)
        {
            if (containerHeight < containerWidth * CANVAS_RATE)
            {
                return (int)((float)(containerHeight - margin) / CANVAS_RATE);
            }
            else
                return containerWidth - margin;
        }

        // Calculate control width
        public int CalculateControlHeight(int controlWidth)
        {
            return (int)(controlWidth * CANVAS_RATE);
        }

        // Calculate control top
        public int CalculateControlTop(int containerHeight, int controlHeight)
        {
            return (int)((containerHeight - controlHeight) * HALF);
        }

        // Calculate control left
        public int CalculateControlLeft(int containerWidth, int controlWidth)
        {
            return (int)((containerWidth - controlWidth) * HALF);
        }

        // Calculate slide button width
        public int CalculateSlideButtonWidth(int containerWidth, int margin)
        {
            return containerWidth - margin;
        }

        // Calculate slide button top
        public int CalculateSlideButtonTop(int slideButtonTop, int slideButtonHeight, int margin)
        {
            return slideButtonTop + slideButtonHeight + margin;
        }

        // Calculate data grid view width
        public int CalculateDataGridViewWidth(int containerWidth, int margin)
        {
            return containerWidth - margin;
        }

        // Calculate data grid view height
        public int CalculateDataGridViewHeight(int containerHeight, int controlTop, int margin)
        {
            return containerHeight - controlTop - margin;
        }

        // Set slide button text
        public string SetSlideButtonText(int index)
        {
            return PAGE + (index + 1);
        }

        // Data Binding notify
        public void Notify(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}