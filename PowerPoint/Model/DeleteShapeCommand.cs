using System.Collections.Generic;

namespace PowerPoint.Model
{
    public class DeleteShapeCommand : ICommand
    {
        // Variable
        private List<Shapes> _pageList;
        private CoordinatePoint _startPoint;
        private CoordinatePoint _endPoint;
        private PageIndex _currentPageIndex;
        private int _pageMemory;
        private int _index;
        private string _shapeType;

        public DeleteShapeCommand(List<Shapes> pageList, PageIndex currentPageIndex, int index)
        {
            _pageList = pageList;
            _currentPageIndex = currentPageIndex;
            _pageMemory = currentPageIndex.GetPageIndex();
            _index = index;
            _startPoint = _pageList[_pageMemory].GetShapeStartPoint(_index);
            _endPoint = _pageList[_pageMemory].GetShapeEndPoint(_index);
            _shapeType = _pageList[_pageMemory].GetShapeName(_index);
        }

        // Excute
        public void Execute()
        {
            _pageList[_pageMemory].DeleteShape(_index);
            _currentPageIndex.SetPageIndex(_pageMemory);
        }

        // Cancel excute
        public void CancelExecute()
        {
            _pageList[_pageMemory].SetDrawingShapeName(_shapeType);
            _pageList[_pageMemory].AddShape(_index, _startPoint, _endPoint);
            _currentPageIndex.SetPageIndex(_pageMemory);
        }
    }
}
