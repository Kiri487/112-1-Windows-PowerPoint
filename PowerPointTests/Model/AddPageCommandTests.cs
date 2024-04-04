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
    public class AddPageCommandTests
    {
        AddPageCommand _addPageCommand;
        List<Shapes> _pageList = new List<Shapes>();
        PageIndex _currentPageIndex = new PageIndex(0);
        private int _previousPageIndex = 0;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _pageList.Add(new Shapes());
            _addPageCommand = new AddPageCommand(_pageList, _currentPageIndex, _previousPageIndex);
        }

        // Execute test
        [TestMethod()]
        public void ExecuteTest()
        {
            _addPageCommand.Execute();
            Assert.AreEqual(1, _currentPageIndex.GetPageIndex());
        }

        // Cancel execute test
        [TestMethod()]
        public void CancelExecuteTest()
        {
            _addPageCommand.Execute();
            _addPageCommand.CancelExecute();
            Assert.AreEqual(0, _currentPageIndex.GetPageIndex());
        }

        // Cancel execute with 3 page test
        [TestMethod()]
        public void CancelExecuteWith3PageTest()
        {
            _pageList.Clear();
            _currentPageIndex.SetPageIndex(0);
            _pageList.Add(new Shapes());
            _currentPageIndex.SetPageIndex(1);
            _pageList.Add(new Shapes());
            _currentPageIndex.SetPageIndex(2);
            _pageList.Add(new Shapes());
            AddPageCommand addPageCommand = new AddPageCommand(_pageList, _currentPageIndex, 2);
            addPageCommand.Execute();
            addPageCommand.CancelExecute();
            Assert.AreEqual(2, _currentPageIndex.GetPageIndex());
        }
    }
}