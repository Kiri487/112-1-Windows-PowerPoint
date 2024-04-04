using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Model.Tests
{
    [TestClass()]
    public class PageIndexTests
    {  
        PageIndex _pageIndex;
        private int _index = 0;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _pageIndex = new PageIndex(_index);
        }

        [TestMethod()]
        public void SetPageIndexTest()
        {
            _index = 4;
            _pageIndex.SetPageIndex(_index);
            Assert.AreEqual(_index, _pageIndex.GetPageIndex());
        }

        [TestMethod()]
        public void GetPageIndexTest()
        {
            _index = 4;
            _pageIndex.SetPageIndex(_index);
            Assert.AreEqual(_index, _pageIndex.GetPageIndex());
        }

        [TestMethod()]
        public void AddPageIndexTest()
        {
            _index = 4;
            _pageIndex.SetPageIndex(_index);
            _pageIndex.AddPageIndex();
            Assert.AreEqual(_index + 1, _pageIndex.GetPageIndex());
        }

        [TestMethod()]
        public void SubtractPageIndexTest()
        {
            _index = 4;
            _pageIndex.SetPageIndex(_index);
            _pageIndex.SubtractPageIndex();
            Assert.AreEqual(_index - 1, _pageIndex.GetPageIndex());
        }
    }
}