using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PowerPoint.Model.Tests
{
    [TestClass()]
    public class AddShapeCommandTests
    {
        AddShapeCommand _addShapeCommand;
        PrivateObject _addShapeCommandPrivate;
        List<Shapes> _pageList = new List<Shapes>();
        PageIndex _currentPageIndex = new PageIndex(0);
        CoordinatePoint _startPoint = new CoordinatePoint(10, 20);
        CoordinatePoint _endPoint = new CoordinatePoint(30, 50);
        const string LINE = "線";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _pageList.Add(new Shapes());
            _addShapeCommand = new AddShapeCommand(_pageList, _currentPageIndex, LINE, _startPoint, _endPoint);
            _addShapeCommandPrivate = new PrivateObject(_addShapeCommand);
        }

        // Execute test
        [TestMethod()]
        public void ExecuteTest()
        {
            _addShapeCommand.Execute();
            Assert.AreEqual(1, _addShapeCommandPrivate.GetFieldOrProperty("_shapesListLength"));
            Assert.AreEqual(LINE, _addShapeCommandPrivate.GetFieldOrProperty("_shapeType"));
            Assert.AreEqual(_startPoint, (CoordinatePoint)_addShapeCommandPrivate.GetFieldOrProperty("_startPoint"));
            Assert.AreEqual(_endPoint, (CoordinatePoint)_addShapeCommandPrivate.GetFieldOrProperty("_endPoint"));
        }

        // Cancel execute test
        [TestMethod()]
        public void CancelExecuteTest()
        {
            _addShapeCommand.Execute();
            _addShapeCommand.CancelExecute();
            Assert.AreEqual(0, _addShapeCommandPrivate.GetFieldOrProperty("_shapesListLength"));
        }
    }
}