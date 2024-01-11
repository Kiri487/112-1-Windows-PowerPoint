using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Model
{  
    public class PageIndex
    {
        private int _pageIndex = 0;

        public PageIndex(int index)
        {
            _pageIndex = index;
        }

        // Set page index
        public void SetPageIndex(int index)
        {
            _pageIndex = index;
        }

        // Get page index
        public int GetPageIndex()
        {
            return _pageIndex;
        }

        // pageIndex++
        public void AddPageIndex()
        {
            _pageIndex++;
        }

        // pageIndex--
        public void SubtractPageIndex()
        {
            _pageIndex--;
        }
    }
}
