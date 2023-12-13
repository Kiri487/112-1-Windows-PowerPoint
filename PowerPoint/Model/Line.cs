using System;

namespace PowerPoint.Model
{
    public class Line : Shape
    {
        // Variable
        private CoordinatePoint _startPoint;
        private CoordinatePoint _endPoint;
        private CoordinatePoint _upperLeftPoint;
        private CoordinatePoint _lowerRightPoint;
        private float _width;
        private float _height;
        private string _direction;
        private string _slope;
        const string LINE = "線";
        const string LEFT_TO_RIGHT = "left to right";
        const string RIGHT_TO_LEFT = "right to left";
        const string UP = "up";
        const string DOWN = "down";

        public Line(CoordinatePoint startPoint, CoordinatePoint endPoint)
        {
            SetPoint(startPoint, endPoint);
        }

        // Set point
        public override void SetPoint(CoordinatePoint startPoint, CoordinatePoint endPoint)
        {
            _startPoint = startPoint;
            _endPoint = endPoint;
            _upperLeftPoint = new CoordinatePoint(Math.Min(startPoint.GetPointX(), endPoint.GetPointX()), Math.Min(startPoint.GetPointY(), endPoint.GetPointY()));
            _lowerRightPoint = new CoordinatePoint(Math.Max(startPoint.GetPointX(), endPoint.GetPointX()), Math.Max(startPoint.GetPointY(), endPoint.GetPointY()));
            _width = _upperLeftPoint.CalculateOffsetX(_lowerRightPoint);
            _height = _upperLeftPoint.CalculateOffsetY(_lowerRightPoint);

            SetType();
        }

        // Get info of shape (coordinate point)
        public override string GetInfo(float rateX, float rateY)
        {
            return _startPoint.GetShapeInfo(_endPoint, rateX, rateY);
        }

        // Get name of shape (type)
        public override string GetName()
        {
            return LINE;
        }

        // Get upper left point
        public override CoordinatePoint GetUpperLeftPoint()
        {
            return _upperLeftPoint;
        }

        // Get lower right point
        public override CoordinatePoint GetLowerRightPoint()
        {
            return _lowerRightPoint;
        }

        // Get start point
        public override CoordinatePoint GetStartPoint()
        {
            return _startPoint;
        }

        // Get end point
        public override CoordinatePoint GetEndPoint()
        {
            return _endPoint;
        }

        // Draw shape
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(_startPoint, _endPoint);
        }

        // Select shape
        public override void Select(IGraphics graphics)
        {
            if (_width < 0 && _height < 0)
                graphics.DrawSelectBorder(_lowerRightPoint, -_width, -_height);
            else if (_width > 0 && _height < 0)
                graphics.DrawSelectBorder(new CoordinatePoint(_upperLeftPoint.GetPointX(), _lowerRightPoint.GetPointY()), _width, -_height);
            else if (_width < 0 && _height > 0)
                graphics.DrawSelectBorder(new CoordinatePoint(_lowerRightPoint.GetPointX(), _upperLeftPoint.GetPointY()), -_width, _height);
            else
                graphics.DrawSelectBorder(_upperLeftPoint, _width, _height);
        }

        // Move shape
        public override void Move(float offsetX, float offsetY)
        {
            _upperLeftPoint.MovePoint(offsetX, offsetY);
            _lowerRightPoint.MovePoint(offsetX, offsetY);
            _startPoint.MovePoint(offsetX, offsetY);
            _endPoint.MovePoint(offsetX, offsetY);
        }

        // Scaling  shape
        public override void Scale(float offsetX, float offsetY)
        {
            if (_slope == DOWN)
                ScaleWhenSlopeIsDown(offsetX, offsetY);
            else // _slope == UP
                ScaleWhenSlopeIsUp(offsetX, offsetY);

            _lowerRightPoint.MovePoint(offsetX, offsetY);
            _width = _upperLeftPoint.CalculateOffsetX(_lowerRightPoint);
            _height = _upperLeftPoint.CalculateOffsetY(_lowerRightPoint);
        }

        // Scale when slope is down
        private void ScaleWhenSlopeIsDown(float offsetX, float offsetY)
        {
            if (_direction == LEFT_TO_RIGHT)
                _endPoint.MovePoint(offsetX, offsetY);
            else // _direction == RIGHT_TO_LEFT
                _startPoint.MovePoint(offsetX, offsetY);
        }

        // Scale when slope is up
        private void ScaleWhenSlopeIsUp(float offsetX, float offsetY)
        {
            if (_direction == LEFT_TO_RIGHT)
            {
                _startPoint.MovePoint(0, offsetY);
                _endPoint.MovePoint(offsetX, 0);
            }
            else // _direction == RIGHT_TO_LEFT
            {
                _startPoint.MovePoint(offsetX, 0);
                _endPoint.MovePoint(0, offsetY);
            }
        }

        // Reset point
        public override void ResetPoint()
        {
            _upperLeftPoint.SetPoint(Math.Min(_startPoint.GetPointX(), _endPoint.GetPointX()), Math.Min(_startPoint.GetPointY(), _endPoint.GetPointY()));
            _lowerRightPoint.SetPoint(Math.Max(_startPoint.GetPointX(), _endPoint.GetPointX()), Math.Max(_startPoint.GetPointY(), _endPoint.GetPointY()));
            _width = _upperLeftPoint.CalculateOffsetX(_lowerRightPoint);
            _height = _upperLeftPoint.CalculateOffsetY(_lowerRightPoint);

            SetType();
        }

        // Set line Type (direction, slope)
        private void SetType()
        {
            _direction = (_startPoint.CalculateOffsetX(_endPoint) > 0) ? LEFT_TO_RIGHT : RIGHT_TO_LEFT;
            if (_direction == LEFT_TO_RIGHT)
                _slope = (_startPoint.CalculateOffsetY(_endPoint) > 0) ? DOWN : UP;
            else // _direction == RIGHT_TO_LEFT
                _slope = (_endPoint.CalculateOffsetY(_startPoint) > 0) ? DOWN : UP;
        }
    }
}