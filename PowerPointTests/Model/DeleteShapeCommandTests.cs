using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PowerPoint.Model.Tests
{
    [TestClass()]
    public class DeleteShapeCommandTests
    {
        DeleteShapeCommand _deleteCommand;
        List<Shapes> _pageList = new List<Shapes>();
        PageIndex _currentPageIndex = new PageIndex(0);
        const string LINE = "線";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _pageList.Add(new Shapes());
            _pageList[_currentPageIndex.GetPageIndex()].SetDrawingShapeName(LINE);
            _pageList[_currentPageIndex.GetPageIndex()].AddShape(new CoordinatePoint(10, 10), new CoordinatePoint(20, 20));
            _deleteCommand = new DeleteShapeCommand(_pageList, _currentPageIndex, 0);
        }

        // Execute test
        [TestMethod()]
        public void ExecuteTest()
        {
            _deleteCommand.Execute();
            Assert.AreEqual(0, _pageList[_currentPageIndex.GetPageIndex()].GetShapesListLength());
        }

        // Cancel execute test
        [TestMethod()]
        public void CancelExecuteTest()
        {
            _deleteCommand.Execute();
            _deleteCommand.CancelExecute();
            Assert.AreEqual(1, _pageList[_currentPageIndex.GetPageIndex()].GetShapesListLength());
        }
    }
}