using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PowerPoint.Model.Tests
{
    [TestClass()]
    public class AddShapeCommandTests
    {
        AddShapeCommand _addCommand;
        PrivateObject _addCommandPrivate;
        List<Shapes> _pageList = new List<Shapes>();
        PageIndex _currentPageIndex = new PageIndex(0);
        const string LINE = "線";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _addCommand = new AddShapeCommand(_pageList, _currentPageIndex, LINE);
            _addCommandPrivate = new PrivateObject(_addCommand);
        }

        // Execute test
        [TestMethod()]
        public void ExecuteTest()
        {
            _addCommand.Execute();
            Assert.AreEqual(1, _addCommandPrivate.GetFieldOrProperty("_shapesListLength"));
        }

        // Execute is redoing test
        [TestMethod()]
        public void ExecuteIsRedoingTest()
        {
            Assert.IsFalse((bool)_addCommandPrivate.GetFieldOrProperty("_isRedoing"));
            _addCommand.Execute();
            _addCommand.CancelExecute();
            _addCommand.Execute();
            Assert.IsTrue((bool)_addCommandPrivate.GetFieldOrProperty("_isRedoing"));
            Assert.AreEqual(1, _addCommandPrivate.GetFieldOrProperty("_shapesListLength"));
        }

        // Cancel execute test
        [TestMethod()]
        public void CancelExecuteTest()
        {
            _addCommand.Execute();
            _addCommand.CancelExecute();
            Assert.AreEqual(0, _addCommandPrivate.GetFieldOrProperty("_shapesListLength"));
        }
    }
}