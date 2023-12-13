namespace PowerPoint.Model
{
    public class PointerState : IState
    {
        // Variable
        bool _isPressed = false;
        bool _isSelect = false;
        bool _isScale = false;
        bool _isCursorChange = false;
        int _canvasWidth;
        int _canvasHeight;
        float _rateX;
        float _rateY;
        float _pointX;
        float _pointY;
        float _offsetX;
        float _offsetY;
        CoordinatePoint _startPoint;
        CoordinatePoint _transitionPoint;
        CoordinatePoint _endPoint;
        PowerPointModel _model;
        const float POINT_X_MIN = 0;
        const float POINT_X_MAX = 3200;
        const float POINT_Y_MIN = 0;
        const float POINT_Y_MAX = 1800;

        public PointerState(PowerPointModel model, int canvasWidth, int canvasHeight)
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

            if (_isSelect)
            {
                _isPressed = true;
                _isScale = IsScale(_pointX, _pointY);
            }
            if (_pointX > POINT_X_MIN && _pointY > POINT_Y_MIN)
            {
                _startPoint = new CoordinatePoint(_pointX, _pointY);
                _transitionPoint = new CoordinatePoint(_pointX, _pointY);
                _endPoint = new CoordinatePoint(_pointX, _pointY);
                if (!_isScale)
                    _isSelect = _model.IsSelect(_pointX, _pointY);
            }
        }

        //  Handle mouse move
        public void MouseMove(float pointX, float pointY)
        {
            _pointX = pointX * _rateX;
            _pointY = pointY * _rateY;
            _isCursorChange = IsScale(_pointX, _pointY);

            if (_isScale)
            {
                _endPoint.SetPoint(_pointX, _pointY);
                _model.ScalingShape(_transitionPoint.CalculateOffsetX(_endPoint), _transitionPoint.CalculateOffsetY(_endPoint));
                _transitionPoint.SetPoint(_pointX, _pointY);
            }
            else if (_isPressed && _isSelect)
            {
                _endPoint.SetPoint(_pointX, _pointY);
                _model.MovingShape(_transitionPoint.CalculateOffsetX(_endPoint), _transitionPoint.CalculateOffsetY(_endPoint));
                _transitionPoint.SetPoint(_pointX, _pointY);
            }
        }

        //  Handle mouse up
        public void MouseUp()
        {
            if (_isPressed)
            {
                CalculateOffset();
                if (_isScale)
                {
                    _model.ScalingShape(-_offsetX, -_offsetY);
                    _model.ScaleShape(_offsetX, _offsetY);
                }
                else if (_offsetX != 0 || _offsetY != 0)
                {
                    _model.MovingShape(-_offsetX, -_offsetY);
                    _model.MoveShape(_offsetX, _offsetY);
                }
                _model.ResetShapePoint();
                _isPressed = false;
                _isScale = false;
            }
        }

        // Calculate offset
        private void CalculateOffset()
        {
            _offsetX = _startPoint.CalculateOffsetX(_endPoint);
            _offsetY = _startPoint.CalculateOffsetY(_endPoint);
        }

        // Get _isPressed
        public bool IsPressed()
        {
            return _isPressed;
        }

        //  Get _isScale
        public bool IsScale()
        {
            return _isScale;
        }

        //  Is scale
        private bool IsScale(float pointX, float pointY)
        {
            return _model.IsScale(pointX, pointY, _rateX, _rateY);
        }

        // Get _isCursorChange
        public bool IsCursorChange()
        {
            return _isCursorChange;
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
