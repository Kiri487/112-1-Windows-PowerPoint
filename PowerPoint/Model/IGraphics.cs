namespace PowerPoint.Model
{
    public interface IGraphics
    {
        // Clear all
        void ClearAll();
        // Draw line
        void DrawLine(CoordinatePoint startPoint, CoordinatePoint endPoint);
        // Draw rectangle
        void DrawRectangle(CoordinatePoint upperLeftPoint, float width, float height);
        // Draw circle
        void DrawCircle(CoordinatePoint upperLeftPoint, float width, float height);
        // Draw select border
        void DrawSelectBorder(CoordinatePoint upperLeftPoint, float width, float height);
    }
}
