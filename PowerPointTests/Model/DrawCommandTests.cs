using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerPoint.Model.Tests
{
    [TestClass()]
    public class DrawCommandTests
    {
        DrawCommand _drawCommand;
        PrivateObject _drawCommandPrivate;
        Shapes _shapes = new Shapes();
        CoordinatePoint _startPoint = new CoordinatePoint(10, 20);
        CoordinatePoint _endPoint = new CoordinatePoint(30, 50);
        const string LINE = "線";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        { 
            _drawCommand = new DrawCommand(_shapes, LINE, _startPoint, _endPoint);
            _drawCommandPrivate = new PrivateObject(_drawCommand);
        }

        // Execute test
        [TestMethod()]
        public void ExecuteTest()
        {
            _drawCommand.Execute();
            Assert.AreEqual(1, _drawCommandPrivate.GetFieldOrProperty("_shapesListLength"));
            Assert.AreEqual(LINE, _drawCommandPrivate.GetFieldOrProperty("_shapeType"));
            Assert.AreEqual(_startPoint, (CoordinatePoint)_drawCommandPrivate.GetFieldOrProperty("_startPoint"));
            Assert.AreEqual(_endPoint, (CoordinatePoint)_drawCommandPrivate.GetFieldOrProperty("_endPoint"));
        }

        // Cancel execute test
        [TestMethod()]
        public void CancelExecuteTest()
        {
            _drawCommand.Execute();
            _drawCommand.CancelExecute();
            Assert.AreEqual(0, _drawCommandPrivate.GetFieldOrProperty("_shapesListLength"));
        }
    }
}