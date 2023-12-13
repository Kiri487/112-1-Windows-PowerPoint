namespace PowerPoint.Model
{
    public abstract class Shape
    {
        // Set point
        public abstract void SetPoint(CoordinatePoint startPoint, CoordinatePoint endPoint);

        // Get info of shape (coordinate point)
        public abstract string GetInfo(float rateX, float rateY);

        // Get name of shape (type)
        public abstract string GetName();

        // Get upper left point
        public abstract CoordinatePoint GetUpperLeftPoint();

        // Get lower right point
        public abstract CoordinatePoint GetLowerRightPoint();

        // Get start point
        public abstract CoordinatePoint GetStartPoint();

        // Get end point
        public abstract CoordinatePoint GetEndPoint();

        // Draw shape
        public abstract void Draw(IGraphics graphics);

        // Select shape
        public abstract void Select(IGraphics graphics);

        // Move shape
        public abstract void Move(float offsetX, float offsetY);

        // Scale  shape
        public abstract void Scale(float offsetX, float offsetY);

        // Reset point
        public abstract void ResetPoint();
    }
}