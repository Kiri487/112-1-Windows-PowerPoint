namespace PowerPoint.Model
{
    public class AddCommand : ICommand
    {
        // Variable
        private Shapes _shapes;
        CoordinatePoint _startPoint;
        CoordinatePoint _endPoint;
        private int _shapesListLength;
        private string _shapeType;
        private bool _isRedoing = false;

        public AddCommand(Shapes shapes, string shapeType)
        {
            _shapes = shapes;
            _shapeType = shapeType;
            _shapesListLength = _shapes.GetShapesListLength();
        }

        // Excute
        public void Execute()
        {
            if (_isRedoing)
            {
                _shapes.SetDrawingShapeName(_shapeType);
                _shapes.AddShape(_startPoint, _endPoint);
                _shapesListLength += 1;
            }
            else
            {
                _shapes.AddShape(_shapeType);
                _shapesListLength += 1;
                _startPoint = _shapes.GetShapeStartPoint(_shapesListLength - 1);
                _endPoint = _shapes.GetShapeEndPoint(_shapesListLength - 1);
                _isRedoing = true;
            }
            
        }

        // Cancel excute
        public void CancelExecute()
        {
            _shapes.DeleteShape(_shapesListLength - 1);
            _shapesListLength -= 1;
        }
    }
}
