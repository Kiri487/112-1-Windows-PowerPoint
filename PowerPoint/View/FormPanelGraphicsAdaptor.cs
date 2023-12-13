using System.Drawing;
using PowerPoint.Model;

namespace PowerPoint.View
{
    public class FormPanelGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;
        CoordinatePoint _upperLeftPoint;
        private float _width;
        private float _height;
        private float _rateX;
        private float _rateY;
        const float SELECT_POINT_SIZE = 10;
        const float HALF_SELECT_POINT_SIZE = SELECT_POINT_SIZE / 2;
        const float HALF = 0.5F;

        public FormPanelGraphicsAdaptor(Graphics graphics, float rateX, float rateY)
        {
            _graphics = graphics;
            _rateX = rateX;
            _rateY = rateY;
        }

        // Clear all
        public void ClearAll()
        {
        }

        // Draw line
        public void DrawLine(CoordinatePoint startPoint, CoordinatePoint endPoint)
        {
            _graphics.DrawLine(Pens.Black, startPoint.GetPointX() * _rateX, startPoint.GetPointY() * _rateY, endPoint.GetPointX() * _rateX, endPoint.GetPointY() * _rateY);
        }

        // Draw rectangle
        public void DrawRectangle(CoordinatePoint upperLeftPoint, float width, float height)
        {
            _upperLeftPoint = new CoordinatePoint(upperLeftPoint.GetPointX() * _rateX, upperLeftPoint.GetPointY() * _rateY);
            _width = width * _rateX;
            _height = height * _rateY;
            _graphics.DrawRectangle(Pens.Black, _upperLeftPoint.GetPointX(), _upperLeftPoint.GetPointY(), _width, _height);
        }

        // Draw circle
        public void DrawCircle(CoordinatePoint upperLeftPoint, float width, float height)
        {
            _upperLeftPoint = new CoordinatePoint(upperLeftPoint.GetPointX() * _rateX, upperLeftPoint.GetPointY() * _rateY);
            _width = width * _rateX;
            _height = height * _rateY;
            _graphics.DrawEllipse(Pens.Black, _upperLeftPoint.GetPointX(), _upperLeftPoint.GetPointY(), _width, _height);
        }

        // Draw select border
        public void DrawSelectBorder(CoordinatePoint upperLeftPoint, float width, float height)
        {
            _upperLeftPoint = new CoordinatePoint(upperLeftPoint.GetPointX() * _rateX, upperLeftPoint.GetPointY() * _rateY);
            _width = width * _rateX;
            _height = height * _rateY;

            _graphics.DrawRectangle(Pens.Gray, _upperLeftPoint.GetPointX(), _upperLeftPoint.GetPointY(), _width, _height);
            _graphics.DrawEllipse(Pens.Gray, _upperLeftPoint.GetPointX() - HALF_SELECT_POINT_SIZE, _upperLeftPoint.GetPointY() - HALF_SELECT_POINT_SIZE, SELECT_POINT_SIZE, SELECT_POINT_SIZE);
            _graphics.DrawEllipse(Pens.Gray, _upperLeftPoint.GetPointX() + _width - HALF_SELECT_POINT_SIZE, _upperLeftPoint.GetPointY() - HALF_SELECT_POINT_SIZE, SELECT_POINT_SIZE, SELECT_POINT_SIZE);
            _graphics.DrawEllipse(Pens.Gray, _upperLeftPoint.GetPointX() - HALF_SELECT_POINT_SIZE, _upperLeftPoint.GetPointY() + _height - HALF_SELECT_POINT_SIZE, SELECT_POINT_SIZE, SELECT_POINT_SIZE);
            _graphics.DrawEllipse(Pens.Gray, _upperLeftPoint.GetPointX() + _width - HALF_SELECT_POINT_SIZE, _upperLeftPoint.GetPointY() + _height - HALF_SELECT_POINT_SIZE, SELECT_POINT_SIZE, SELECT_POINT_SIZE);
            _graphics.DrawEllipse(Pens.Gray, _upperLeftPoint.GetPointX() + (HALF * _width) - HALF_SELECT_POINT_SIZE, _upperLeftPoint.GetPointY() - HALF_SELECT_POINT_SIZE, SELECT_POINT_SIZE, SELECT_POINT_SIZE);
            _graphics.DrawEllipse(Pens.Gray, _upperLeftPoint.GetPointX() - HALF_SELECT_POINT_SIZE, _upperLeftPoint.GetPointY() + (HALF * _height) - HALF_SELECT_POINT_SIZE, SELECT_POINT_SIZE, SELECT_POINT_SIZE);
            _graphics.DrawEllipse(Pens.Gray, _upperLeftPoint.GetPointX() + _width - HALF_SELECT_POINT_SIZE, _upperLeftPoint.GetPointY() + (HALF * _height) - HALF_SELECT_POINT_SIZE, SELECT_POINT_SIZE, SELECT_POINT_SIZE);
            _graphics.DrawEllipse(Pens.Gray, _upperLeftPoint.GetPointX() + (HALF * _width) - HALF_SELECT_POINT_SIZE, _upperLeftPoint.GetPointY() + _height - HALF_SELECT_POINT_SIZE, SELECT_POINT_SIZE, SELECT_POINT_SIZE);
        }
    }
}
