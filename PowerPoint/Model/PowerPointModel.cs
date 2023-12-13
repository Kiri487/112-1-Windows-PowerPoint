namespace PowerPoint.Model
{
    public class PowerPointModel
    {
        // EventHandler
        public event ShapeListChangedEventHandler _shapeListChanged;
        public delegate void ShapeListChangedEventHandler();
        public event DrawingEventHandler _drawing;
        public delegate void DrawingEventHandler();
        public event CanvasSizeChangedEventHandler _canvasSizeChanged;
        public delegate void CanvasSizeChangedEventHandler();

        // Variable
        Shapes _shapes = new Shapes();
        CommandManager _commandManager = new CommandManager();
        IState _state;
        private int _canvasWidth = (int)POINT_X_MAX;
        private int _canvasHeight = (int)POINT_Y_MAX;
        private float _rateX = 1;
        private float _rateY = 1;
        private string _mode;
        private string _drawingShapeType;
        const string POINTER_MODE = "Pointer";
        const string DRAWING_MODE = "Drawing";
        const float POINT_X_MAX = 3200;
        const float POINT_Y_MAX = 1800;

        public PowerPointModel()
        {
            _state = new PointerState(this, _canvasWidth, _canvasHeight);
            _mode = POINTER_MODE;
        }

        // Add new shape to the shapes list
        public void AddShape(string shapeType)
        {
            _commandManager.Execute(new AddCommand(_shapes, shapeType));
            NotifyShapeListChanged();
        }

        // Add new shape to the shapes list
        public void DrawShape(CoordinatePoint startPoint, CoordinatePoint endPoint)
        {
            _commandManager.Execute(new DrawCommand(_shapes, _drawingShapeType, startPoint, endPoint));
            NotifyShapeListChanged();
        }

        // Delete shape from the shapes list
        public void DeleteShape()
        {
            if (_shapes.IsSelect())
            {
                DeleteShape(GetSelectShapeIndex());
            }
        }

        // Delete shape from the shapes list
        public void DeleteShape(int index)
        {
            _commandManager.Execute(new DeleteCommand(_shapes, index));
            NotifyShapeListChanged();
        }

        // Get length of shapes list
        public int GetShapesListLength()
        {
            return _shapes.GetShapesListLength();
        }

        // Get data of shape (type, coordinate point) by index
        public string[] GetShapeData(int index)
        {
            return _shapes.GetShapeData(index, _rateX, _rateY);
        }

        // Draw shape
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            _shapes.Draw(graphics);
        }

        // Get mode
        public string GetMode()
        {
            return _mode;
        }

        // Set pointer mode
        public void SetPointerMode()
        {
            if (_mode != POINTER_MODE)
            {
                _state = new PointerState(this, _canvasWidth, _canvasHeight);
                _mode = POINTER_MODE;
            }
        }

        // Set drawing mode
        public void SetDrawingMode()
        {
            _state = new DrawingState(this, _canvasWidth, _canvasHeight);
            _mode = DRAWING_MODE;
            _shapes.CancelSelect();
            NotifyDrawing();
        }

        // Is cursor change
        public bool IsCursorChange()
        {
            return _state.IsCursorChange();
        }

        // Set drawing shape name
        public void SetDrawingShapeName(string shapeType)
        {
            _drawingShapeType = shapeType;
            _shapes.SetDrawingShapeName(_drawingShapeType);
        }

        // create drawing shape
        public void CreateDrawingShape(CoordinatePoint startPoint, CoordinatePoint endPoint)
        {
            _shapes.CreateDrawingShape(startPoint, endPoint);
        }

        // Delete drawing shape
        public void DeleteDrawingShape()
        {
            _shapes.DeleteDrawingShape();
        }

        // Is shape select
        public bool IsSelect(float pointX, float pointY)
        {
            return _shapes.IsSelect(pointX, pointY);
        }

        // Get select shape index
        public int GetSelectShapeIndex()
        {
            return _shapes.GetSelectShapeIndex();
        }

        // Moving shape
        public void MovingShape(float offsetX, float offsetY)
        {
            _shapes.Move(offsetX, offsetY);
        }

        // Move shape
        public void MoveShape(float offsetX, float offsetY)
        {
            _commandManager.Execute(new MoveCommand(_shapes, offsetX, offsetY));
        }

        // Is shape select
        public bool IsScale(float pointX, float pointY, float rateX, float rateY)
        {
            return _shapes.IsScale(pointX, pointY, rateX, rateY);
        }

        // Scaling shape
        public void ScalingShape(float offsetX, float offsetY)
        {
            _shapes.Scale(offsetX, offsetY);
        }

        // Scale shape
        public void ScaleShape(float offsetX, float offsetY)
        {
            _commandManager.Execute(new ScaleCommand(_shapes, offsetX, offsetY));
        }

        // Reset shape point
        public void ResetShapePoint()
        {
            _shapes.ResetPoint();
        }

        // Process pointer pressed
        public void ProcessPointerPressed(float pointX, float pointY)
        {
            _state.MouseDown(pointX, pointY);
        }

        // Process pointer moved
        public void ProcessPointerMoved(float pointX, float pointY)
        {
            _state.MouseMove(pointX, pointY);
            NotifyDrawing();
        }

        // Process pointer released
        public void ProcessPointerReleased()
        {
            _state.MouseUp();
            NotifyShapeListChanged();
        }

        // Get canvas size
        public void GetCanvasSize(int canvasWidth, int canvasHeight)
        {
            _canvasWidth = canvasWidth;
            _canvasHeight = canvasHeight;
            _rateX = POINT_X_MAX / (float)_canvasWidth;
            _rateY = POINT_Y_MAX / (float)_canvasHeight;
            _state.UpdateCanvasSize(_canvasWidth, _canvasHeight);
            NotifyCanvasSizeChanged();
        }

        // Is undo
        public bool IsUndo()
        {
            return _commandManager.IsUndo();
        }

        // Undo
        public void Undo()
        {
            _commandManager.Undo();
            NotifyShapeListChanged();
            NotifyDrawing();
        }

        // Is redo
        public bool IsRedo()
        {
            return _commandManager.IsRedo();
        }

        // Redo
        public void Redo()
        {
            _commandManager.Redo();
            NotifyShapeListChanged();
            NotifyDrawing();
        }

        // Notify shape list observer
        public void NotifyShapeListChanged()
        {
            if (_shapeListChanged != null)
                _shapeListChanged();
        }

        // Notify drawing observer
        public void NotifyDrawing()
        {
            if (_drawing != null)
                _drawing();
        }

        // Notify canvas size observer
        public void NotifyCanvasSizeChanged()
        {
            if (_canvasSizeChanged != null)
                _canvasSizeChanged();
        }
    }
}