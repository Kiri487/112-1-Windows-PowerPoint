using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PowerPoint.Model.Tests
{
    [TestClass()]
    public class DeletePageCommandTests
    {
        DeletePageCommand _deletePageCommand;
        List<Shapes> _pageList = new List<Shapes>();
        PageIndex _currentPageIndex = new PageIndex(0);

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _pageList.Add(new Shapes());
            _pageList.Add(new Shapes());
            _currentPageIndex = new PageIndex(1);
            _deletePageCommand = new DeletePageCommand(_pageList, _currentPageIndex);
        }

        // Execute test
        [TestMethod()]
        public void ExecuteTest()
        {
            _deletePageCommand.Execute();
            Assert.AreEqual(0, _currentPageIndex.GetPageIndex());
        }

        // Execute with 0 page test
        [TestMethod()]
        public void ExecuteWith0PageTest()
        {
            _pageList.Clear();
            _currentPageIndex.SetPageIndex(0);
            _pageList.Add(new Shapes());
            DeletePageCommand deletePageCommand = new DeletePageCommand(_pageList, _currentPageIndex);
            deletePageCommand.Execute();
            Assert.AreEqual(0, _currentPageIndex.GetPageIndex());
        }

        // Cancel execute test
        [TestMethod()]
        public void CancelExecuteTest()
        {
            
            _deletePageCommand.Execute();
            _deletePageCommand.CancelExecute();
            Assert.AreEqual(1, _currentPageIndex.GetPageIndex());
        }
    }
}