using System.Drawing;
using PowerPoint.Model;

namespace PowerPoint.View
{
    public class FormSlideButtonGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;
        private float _rateX;
        private float _rateY;

        public FormSlideButtonGraphicsAdaptor(Graphics graphics, float rateX, float rateY)
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
            _graphics.DrawRectangle(Pens.Black, upperLeftPoint.GetPointX() * _rateX, upperLeftPoint.GetPointY() * _rateY, width * _rateX, height * _rateY);
        }

        // Draw circle
        public void DrawCircle(CoordinatePoint upperLeftPoint, float width, float height)
        {
            _graphics.DrawEllipse(Pens.Black, upperLeftPoint.GetPointX() * _rateX, upperLeftPoint.GetPointY() * _rateX, width * _rateY, height * _rateY);
        }

        // Draw select border
        public void DrawSelectBorder(CoordinatePoint upperLeftPoint, float width, float height)
        {
        }
    }
}
