using System.Collections.Generic;

namespace PowerPoint.Model
{
    public class AddShapeCommand : ICommand
    {
        // Variable
        private List<Shapes> _pageList;
        private CoordinatePoint _startPoint;
        private CoordinatePoint _endPoint;
        private PageIndex _currentPageIndex;
        private int _shapesListLength;
        private int _pageMemory;
        private string _shapeType;
        private bool _isRedoing = false;

        public AddShapeCommand(List<Shapes> pageList, PageIndex currentPageIndex, string shapeType)
        {
            _pageList = pageList;
            _currentPageIndex = currentPageIndex;
            _pageMemory = currentPageIndex.GetPageIndex();
            _shapeType = shapeType;
            _shapesListLength = _pageList[_pageMemory].GetShapesListLength();
        }

        // Excute
        public void Execute()
        {
            if (_isRedoing)
            {
                _pageList[_pageMemory].SetDrawingShapeName(_shapeType);
                _pageList[_pageMemory].AddShape(_startPoint, _endPoint);
                _shapesListLength += 1;
                _currentPageIndex.SetPageIndex(_pageMemory);
            }
            else
            {
                _pageList[_pageMemory].AddShape(_shapeType);
                _shapesListLength += 1;
                _startPoint = _pageList[_pageMemory].GetShapeStartPoint(_shapesListLength - 1);
                _endPoint = _pageList[_pageMemory].GetShapeEndPoint(_shapesListLength - 1);
                _isRedoing = true;
            }
            
        }

        // Cancel excute
        public void CancelExecute()
        {
            _pageList[_pageMemory].DeleteShape(_shapesListLength - 1);
            _shapesListLength -= 1;
            _currentPageIndex.SetPageIndex(_pageMemory);
        }
    }
}
