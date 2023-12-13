namespace PowerPoint.Model
{
    public interface IState
    {
        // Update canvas size
        void UpdateCanvasSize(int canvasWidth, int canvasHeight);

        //  Handle mouse down
        void MouseDown(float pointX, float pointY);

        //  Handle mouse move
        void MouseMove(float pointX, float pointY);

        //  Handle mouse up
        void MouseUp();

        // Get _isPressed
        bool IsPressed();

        // Get _isCursorChange
        bool IsCursorChange();

        // Get start point
        CoordinatePoint GetStartPoint();

        // Get end point
        CoordinatePoint GetEndPoint();
    }
}
