using System;

namespace PowerPoint.Model
{
    public class ShapeFactory
    {
        public ShapeFactory()
        {
        }

        // Variable
        const int POINT_X_MIN = 0;
        const int POINT_X_MAX = 3200;
        const int POINT_Y_MIN = 0;
        const int POINT_Y_MAX = 1800;
        const string LINE = "線";
        const string RECTANGLE = "矩形";
        CoordinatePoint _upperLeftPoint;
        CoordinatePoint _lowerRightPoint;

        // Create specified shape
        public Shape CreateShape(string shapeType)
        {
            Random random = new Random();
            _upperLeftPoint = new CoordinatePoint(random.Next(POINT_X_MIN, POINT_X_MAX), random.Next(POINT_Y_MIN, POINT_Y_MAX));
            _lowerRightPoint = new CoordinatePoint(random.Next((int)_upperLeftPoint.GetPointX(), POINT_X_MAX), random.Next((int)_upperLeftPoint.GetPointY(), POINT_Y_MAX));

            if (shapeType == LINE)
            {
                _lowerRightPoint.SetPoint(random.Next(POINT_X_MIN, POINT_X_MAX), random.Next(POINT_Y_MIN, POINT_Y_MAX));
                return new Line(_upperLeftPoint, _lowerRightPoint);
            }
            else if (shapeType == RECTANGLE)
                return new Rectangle(_upperLeftPoint, _lowerRightPoint);
            else
                return new Circle(_upperLeftPoint, _lowerRightPoint);
        }

        // Create specified shape with start point and end point
        public Shape CreateShape(string shapeType, CoordinatePoint startPoint, CoordinatePoint endPoint)
        {
            _upperLeftPoint = new CoordinatePoint(Math.Min(startPoint.GetPointX(), endPoint.GetPointX()), Math.Min(startPoint.GetPointY(), endPoint.GetPointY()));
            _lowerRightPoint = new CoordinatePoint(Math.Max(startPoint.GetPointX(), endPoint.GetPointX()), Math.Max(startPoint.GetPointY(), endPoint.GetPointY()));

            if (shapeType == LINE)
                return new Line(startPoint, endPoint);
            else if (shapeType == RECTANGLE)
                return new Rectangle(_upperLeftPoint, _lowerRightPoint);
            else
                return new Circle(_upperLeftPoint, _lowerRightPoint);
        }
    }
}