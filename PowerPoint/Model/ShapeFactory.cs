using System;

namespace PowerPoint.Model
{
    public class ShapeFactory
    {
        public ShapeFactory()
        {
        }

        // Variable
        const string LINE = "線";
        const string RECTANGLE = "矩形";
        CoordinatePoint _upperLeftPoint;
        CoordinatePoint _lowerRightPoint;

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