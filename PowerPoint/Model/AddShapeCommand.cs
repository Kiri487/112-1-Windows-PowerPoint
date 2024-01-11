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

        public AddShapeCommand(List<Shapes> pageList, PageIndex currentPageIndex, string shapeType, CoordinatePoint startPoint, CoordinatePoint endPoint)
        {
            _pageList = pageList;
            _currentPageIndex = currentPageIndex;
            _pageMemory = currentPageIndex.GetPageIndex();
            _shapeType = shapeType;
            _startPoint = startPoint;
            _endPoint = endPoint;
            _shapesListLength = pageList[_pageMemory].GetShapesListLength();
        }

        // Excute
        public void Execute()
        {
            _pageList[_pageMemory].SetDrawingShapeName(_shapeType);
            _pageList[_pageMemory].AddShape(_startPoint, _endPoint);
            _shapesListLength += 1;
            _currentPageIndex.SetPageIndex(_pageMemory);
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
