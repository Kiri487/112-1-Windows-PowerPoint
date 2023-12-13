namespace PowerPoint.Model
{
    public class DrawCommand : ICommand
    {
        // Variable
        private Shapes _shapes;
        CoordinatePoint _startPoint;
        CoordinatePoint _endPoint;
        private int _shapesListLength;
        private string _shapeType;

        public DrawCommand(Shapes shapes, string shapeType, CoordinatePoint startPoint, CoordinatePoint endPoint)
        {
            _shapes = shapes;
            _shapeType = shapeType;
            _startPoint = startPoint;
            _endPoint = endPoint;
            _shapesListLength = _shapes.GetShapesListLength();
        }

        // Excute
        public void Execute()
        {
            _shapes.SetDrawingShapeName(_shapeType);
            _shapes.AddShape(_startPoint, _endPoint);
            _shapesListLength += 1;
        }

        // Cancel excute
        public void CancelExecute()
        {
            _shapes.DeleteShape(_shapesListLength - 1);
            _shapesListLength -= 1;
        }
    }
}
