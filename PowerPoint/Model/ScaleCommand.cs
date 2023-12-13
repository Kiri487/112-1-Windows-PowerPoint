using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Model
{
    public class ScaleCommand : ICommand
    {
        // Variable
        private Shapes _shapes;
        private CoordinatePoint _originalStartPoint;
        private CoordinatePoint _originalEndPoint;
        private int _shapeIndex;
        private float _offsetX;
        private float _offsetY;
        private bool _isAlreadySelect;

        public ScaleCommand(Shapes shapes, float offsetX, float offsetY)
        {
            _shapes = shapes;
            _shapeIndex = _shapes.GetSelectShapeIndex();
            _offsetX = offsetX;
            _offsetY = offsetY;
            _originalStartPoint = new CoordinatePoint(_shapes.GetShapeStartPoint(_shapeIndex).GetPointX(), _shapes.GetShapeStartPoint(_shapeIndex).GetPointY());
            _originalEndPoint = new CoordinatePoint(_shapes.GetShapeEndPoint(_shapeIndex).GetPointX(), _shapes.GetShapeEndPoint(_shapeIndex).GetPointY());
        }

        // Excute
        public void Execute()
        {
            _isAlreadySelect = IsAlreadySelect();
            _shapes.SetSelectShape(_shapeIndex);
            _shapes.Scale(_offsetX, _offsetY);

            if (!_isAlreadySelect)
                _shapes.CancelSelect();
        }

        // Cancel excute
        public void CancelExecute()
        {
            _shapes.SetPoint(_shapeIndex, _originalStartPoint, _originalEndPoint);
        }

        // Is already select
        private bool IsAlreadySelect()
        {
            return _shapes.IsSelect();
        }
    }
}
