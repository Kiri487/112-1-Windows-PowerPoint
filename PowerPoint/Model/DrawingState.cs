namespace PowerPoint.Model
{
    public class DrawingState : IState
    {
        // Variable
        bool _isPressed = false;
        int _canvasWidth;
        int _canvasHeight;
        float _rateX;
        float _rateY;
        float _pointX;
        float _pointY;
        CoordinatePoint _startPoint;
        CoordinatePoint _endPoint;
        PowerPointModel _model;
        const float POINT_X_MIN = 0;
        const float POINT_X_MAX = 3200;
        const float POINT_Y_MIN = 0;
        const float POINT_Y_MAX = 1800;

        public DrawingState(PowerPointModel model, int canvasWidth, int canvasHeight)
        {
            _model = model;
            UpdateCanvasSize(canvasWidth, canvasHeight);
        }

        // Update canvas size
        public void UpdateCanvasSize(int canvasWidth, int canvasHeight)
        {
            _canvasWidth = canvasWidth;
            _canvasHeight = canvasHeight;
            _rateX = POINT_X_MAX / (float)_canvasWidth;
            _rateY = POINT_Y_MAX / (float)_canvasHeight;
        }

        //  Handle mouse down
        public void MouseDown(float pointX, float pointY)
        {
            _pointX = pointX * _rateX;
            _pointY = pointY * _rateY;

            if (_pointX > POINT_X_MIN && _pointY > POINT_Y_MIN)
            {
                _startPoint = new CoordinatePoint(_pointX, _pointY);
                _endPoint = new CoordinatePoint(_pointX, _pointY);
                _isPressed = true;
                _model.CreateDrawingShape(_startPoint, _endPoint);
            }
        }

        //  Handle mouse move
        public void MouseMove(float pointX, float pointY)
        {
            _pointX = pointX * _rateX;
            _pointY = pointY * _rateY;

            if (_isPressed)
            {
                _endPoint.SetPoint(_pointX, _pointY);
                _model.CreateDrawingShape(_startPoint, _endPoint);
            }
        }

        //  Handle mouse up
        public void MouseUp()
        {
            if (_isPressed)
            {
                _isPressed = false;
                _model.AddShape(_startPoint, _endPoint);
                _model.DeleteDrawingShape();
            }
        }

        // Get _isPressed
        public bool IsPressed()
        {
            return _isPressed;
        }

        // Is cursor change
        public bool IsCursorChange()
        {
            return true;
        }

        // Get start point
        public CoordinatePoint GetStartPoint()
        {
            return _startPoint;
        }

        // Get end point
        public CoordinatePoint GetEndPoint()
        {
            return _endPoint;
        }
    }
}
