using System;

namespace PowerPoint.Model
{
    public class Rectangle : Shape
    {
        // Variable
        private CoordinatePoint _upperLeftPoint;
        private CoordinatePoint _lowerRightPoint;
        private float _width;
        private float _height; 
        const string RECTANGLE = "矩形";

        public Rectangle(CoordinatePoint upperLeftPoint, CoordinatePoint lowerRightPoint)
        {
            SetPoint(upperLeftPoint, lowerRightPoint);
        }

        // Set point
        public override void SetPoint(CoordinatePoint startPoint, CoordinatePoint endPoint)
        {
            _upperLeftPoint = startPoint;
            _lowerRightPoint = endPoint;
            _width = _upperLeftPoint.CalculateOffsetX(_lowerRightPoint);
            _height = _upperLeftPoint.CalculateOffsetY(_lowerRightPoint);
        }

        // Get info of shape (coordinate point)
        public override string GetInfo(float rateX, float rateY)
        {
            return _upperLeftPoint.GetShapeInfo(_lowerRightPoint, rateX, rateY);
        }

        // Get name of shape (type)
        public override string GetName()
        {
            return RECTANGLE;
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
            return _upperLeftPoint;
        }

        // Get end point
        public override CoordinatePoint GetEndPoint()
        {
            return _lowerRightPoint;
        }

        // Draw shape
        public override void Draw(IGraphics graphics)
        {
            if (_width < 0 && _height < 0)
                graphics.DrawRectangle(_lowerRightPoint, -_width, -_height);
            else if (_width < 0 && _height > 0)
                graphics.DrawRectangle(new CoordinatePoint(_lowerRightPoint.GetPointX(), _upperLeftPoint.GetPointY()), -_width, _height);
            else if (_width > 0 && _height < 0)
                graphics.DrawRectangle(new CoordinatePoint(_upperLeftPoint.GetPointX(), _lowerRightPoint.GetPointY()), _width, -_height);
            else
                graphics.DrawRectangle(_upperLeftPoint, _width, _height);
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
        }

        // Scale  shape
        public override void Scale(float offsetX, float offsetY)
        {
            _lowerRightPoint.MovePoint(offsetX, offsetY);
            _width = _upperLeftPoint.CalculateOffsetX(_lowerRightPoint);
            _height = _upperLeftPoint.CalculateOffsetY(_lowerRightPoint);
        }

        // Reset point
        public override void ResetPoint()
        {
            float smallX = Math.Min(_upperLeftPoint.GetPointX(), _lowerRightPoint.GetPointX());
            float bigX = Math.Max(_upperLeftPoint.GetPointX(), _lowerRightPoint.GetPointX());
            float smallY = Math.Min(_upperLeftPoint.GetPointY(), _lowerRightPoint.GetPointY());
            float bigY = Math.Max(_upperLeftPoint.GetPointY(), _lowerRightPoint.GetPointY());

            _upperLeftPoint.SetPoint(smallX, smallY);
            _lowerRightPoint.SetPoint(bigX, bigY);
            _width = _upperLeftPoint.CalculateOffsetX(_lowerRightPoint);
            _height = _upperLeftPoint.CalculateOffsetY(_lowerRightPoint);
        }
    }
}