using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerPoint.Model.Tests
{
    [TestClass()]
    public class AddCommandTests
    {
        AddCommand _addCommand;
        PrivateObject _addCommandPrivate;
        Shapes _shapes = new Shapes();
        const string LINE = "線";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _addCommand = new AddCommand(_shapes, LINE);
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