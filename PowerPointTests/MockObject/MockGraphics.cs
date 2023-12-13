using PowerPoint.Model;
using System.Drawing;

namespace PowerPointTests.MockObject
{
    public class MockGraphics : IGraphics
    {
        CoordinatePoint _startPoint;
        CoordinatePoint _endPoint;
        CoordinatePoint _upperLeftPoint;
        bool _isSuccessful;
        float _width;
        float _height;
        string _drawType;
        const string LINE = "線";
        const string RECTANGLE = "矩形";
        const string CIRCLE = "橢圓";
        const string SELECT_BORDER = "SelectBorder";

        public MockGraphics()
        {
            _isSuccessful = false;
        }

        // Clear all
        public void ClearAll()
        {
            _isSuccessful = true;
        }

        // Draw line
        public void DrawLine(CoordinatePoint startPoint, CoordinatePoint endPoint)
        {
            _startPoint = startPoint;
            _endPoint = endPoint;
            _drawType = LINE;
            _isSuccessful = true;
        }

        // Draw rectangle
        public void DrawRectangle(CoordinatePoint upperLeftPoint, float width, float height)
        {
            _upperLeftPoint = upperLeftPoint;
            _width = width;
            _height = height;
            _drawType = RECTANGLE;
            _isSuccessful = true;
        }

        // Draw circle
        public void DrawCircle(CoordinatePoint upperLeftPoint, float width, float height)
        {
            _upperLeftPoint = upperLeftPoint;
            _width = width;
            _height = height;
            _drawType = CIRCLE;
            _isSuccessful = true;
        }

        // Draw select border
        public void DrawSelectBorder(CoordinatePoint upperLeftPoint, float width, float height)
        {
            _upperLeftPoint = upperLeftPoint;
            _width = width;
            _height = height;
            _drawType = SELECT_BORDER;
            _isSuccessful = true;
        }

        // Get _isSuccessful
        public bool IsSuccessful()
        {
            return _isSuccessful;
        }

        // Get _drawType
        public string GetDrawType()
        {
            return _drawType;
        }
    }
}
