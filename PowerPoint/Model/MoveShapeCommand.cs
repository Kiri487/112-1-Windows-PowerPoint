using System.Collections.Generic;

namespace PowerPoint.Model
{
    public class MoveShapeCommand : ICommand
    {
        // Variable
        private List<Shapes> _pageList;
        private CoordinatePoint _originalStartPoint;
        private CoordinatePoint _originalEndPoint;
        private PageIndex _currentPageIndex;
        private int _pageMemory;
        private int _shapeIndex;
        private float _offsetX;
        private float _offsetY;
        private bool _isAlreadySelect;

        public MoveShapeCommand(List<Shapes> pageList, PageIndex currentPageIndex, float offsetX, float offsetY)
        {
            _pageList = pageList;
            _currentPageIndex = currentPageIndex;
            _pageMemory = currentPageIndex.GetPageIndex();
            _shapeIndex = _pageList[_pageMemory].GetSelectShapeIndex();
            _offsetX = offsetX;
            _offsetY = offsetY;
            _originalStartPoint = new CoordinatePoint(_pageList[_pageMemory].GetShapeStartPoint(_shapeIndex).GetPointX(), _pageList[_pageMemory].GetShapeStartPoint(_shapeIndex).GetPointY());
            _originalEndPoint = new CoordinatePoint(_pageList[_pageMemory].GetShapeEndPoint(_shapeIndex).GetPointX(), _pageList[_pageMemory].GetShapeEndPoint(_shapeIndex).GetPointY());
        }

        // Excute
        public void Execute()
        {
            _isAlreadySelect = IsAlreadySelect();
            _pageList[_pageMemory].SetSelectShape(_shapeIndex);
            _pageList[_pageMemory].Move(_offsetX, _offsetY);
            _currentPageIndex.SetPageIndex(_pageMemory);

            if (!_isAlreadySelect)
                _pageList[_pageMemory].CancelSelect();
        }

        // Cancel excute
        public void CancelExecute()
        {
            _pageList[_pageMemory].SetPoint(_shapeIndex, new CoordinatePoint(_originalStartPoint.GetPointX(), _originalStartPoint.GetPointY()), new CoordinatePoint(_originalEndPoint.GetPointX(), _originalEndPoint.GetPointY()));
            _currentPageIndex.SetPageIndex(_pageMemory);
        }

        // Is already select
        private bool IsAlreadySelect()
        {
            return _pageList[_pageMemory].IsSelect();
        }
    }
}
