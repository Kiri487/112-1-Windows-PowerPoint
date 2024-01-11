using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Model
{
    class DeletePageCommand : ICommand
    {
        // Variable
        private List<Shapes> _pageList;
        private PageIndex _currentPageIndex;
        private Shapes _shapesMemory;
        private int _pageMemory;

        public DeletePageCommand(List<Shapes> pageList, PageIndex currentPageIndex)
        {
            _pageList = pageList;
            _currentPageIndex = currentPageIndex;
            _shapesMemory = _pageList[currentPageIndex.GetPageIndex()];
            _pageMemory = _currentPageIndex.GetPageIndex();
        }

        // Excute
        public void Execute()
        {
            int deletePageIndex = GetDeletePageIndex();
            _pageList.RemoveAt(deletePageIndex);
            if (deletePageIndex > 0)
                _currentPageIndex.SubtractPageIndex();
        }

        // Cancel excute
        public void CancelExecute()
        {
            _pageList.Insert(_pageMemory, _shapesMemory);
            _currentPageIndex.SetPageIndex(_pageMemory);
        }

        // Get delete page index
        private int GetDeletePageIndex()
        {
            return _currentPageIndex.GetPageIndex();
        }
    }
}
