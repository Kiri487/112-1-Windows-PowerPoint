using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerPoint.Model.Tests
{
    [TestClass()]
    public class DeleteCommandTests
    {
        DeleteCommand _deleteCommand;
        Shapes _shapes = new Shapes();
        const string LINE = "線";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _shapes.AddShape(LINE);
            _deleteCommand = new DeleteCommand(_shapes, 0);
        }

        // Execute test
        [TestMethod()]
        public void ExecuteTest()
        {
            _deleteCommand.Execute();
            Assert.AreEqual(0, _shapes.GetShapesListLength());
        }

        // Cancel execute test
        [TestMethod()]
        public void CancelExecuteTest()
        {
            _deleteCommand.Execute();
            _deleteCommand.CancelExecute();
            Assert.AreEqual(1, _shapes.GetShapesListLength());
        }
    }
}