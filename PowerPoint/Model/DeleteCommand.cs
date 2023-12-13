namespace PowerPoint.Model
{
    public class DeleteCommand : ICommand
    {
        // Variable
        private Shapes _shapes;
        CoordinatePoint _startPoint;
        CoordinatePoint _endPoint;
        private int _index;
        private string _shapeType;

        public DeleteCommand(Shapes shapes, int index)
        {
            _shapes = shapes;
            _index = index;
            _startPoint = _shapes.GetShapeStartPoint(_index);
            _endPoint = _shapes.GetShapeEndPoint(_index);
            _shapeType = _shapes.GetShapeName(_index);
        }

        // Excute
        public void Execute()
        {
            _shapes.DeleteShape(_index);
        }

        // Cancel excute
        public void CancelExecute()
        {
            _shapes.SetDrawingShapeName(_shapeType);
            _shapes.AddShape(_index, _startPoint, _endPoint);
        }
    }
}
