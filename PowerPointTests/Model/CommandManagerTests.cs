using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PowerPoint.Model.Tests
{
    [TestClass()]
    public class CommandManagerTests
    {
        CommandManager _commandManager;
        PrivateObject _commandManagerPrivate;
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
            _commandManager = new CommandManager();
            _commandManagerPrivate = new PrivateObject(_commandManager);
        }

        // Execute test
        [TestMethod()]
        public void ExecuteTest()
        {
            _commandManager.Execute(new AddPageCommand(_pageList, _currentPageIndex, 0));
            Assert.AreEqual(1, ((Stack<ICommand>)_commandManagerPrivate.GetFieldOrProperty("_undoStack")).Count);

            _commandManager.Execute(new DeletePageCommand(_pageList, _currentPageIndex));
            Assert.AreEqual(2, ((Stack<ICommand>)_commandManagerPrivate.GetFieldOrProperty("_undoStack")).Count);
            Assert.AreEqual(0, ((Stack<ICommand>)_commandManagerPrivate.GetFieldOrProperty("_redoStack")).Count);
        }

        // Undo test
        [TestMethod()]
        public void UndoTest()
        {
            Assert.IsFalse(_commandManager.IsUndo());
            _commandManager.Undo();
            Assert.IsFalse(_commandManager.IsUndo());
            _commandManager.Execute(new AddShapeCommand(_pageList, _currentPageIndex, LINE, _startPoint, _endPoint));
            _commandManager.Execute(new DeleteShapeCommand(_pageList, _currentPageIndex, 0));
            Assert.AreEqual(2, ((Stack<ICommand>)_commandManagerPrivate.GetFieldOrProperty("_undoStack")).Count);
            _commandManager.Undo();
            Assert.AreEqual(1, ((Stack<ICommand>)_commandManagerPrivate.GetFieldOrProperty("_undoStack")).Count);
            Assert.AreEqual(1, ((Stack<ICommand>)_commandManagerPrivate.GetFieldOrProperty("_redoStack")).Count);
            _commandManager.Undo();
            Assert.AreEqual(0, ((Stack<ICommand>)_commandManagerPrivate.GetFieldOrProperty("_undoStack")).Count);
            Assert.AreEqual(2, ((Stack<ICommand>)_commandManagerPrivate.GetFieldOrProperty("_redoStack")).Count);
        }

        // Redo test
        [TestMethod()]
        public void RedoTest()
        {
            _commandManager.Execute(new AddShapeCommand(_pageList, _currentPageIndex, LINE, _startPoint, _endPoint));
            _commandManager.Execute(new DeleteShapeCommand(_pageList, _currentPageIndex, 0));
            _commandManager.Undo();
            _commandManager.Undo();
            _commandManager.Redo();
            Assert.AreEqual(1, ((Stack<ICommand>)_commandManagerPrivate.GetFieldOrProperty("_undoStack")).Count);
            Assert.AreEqual(1, ((Stack<ICommand>)_commandManagerPrivate.GetFieldOrProperty("_redoStack")).Count);
            _commandManager.Redo();
            Assert.AreEqual(2, ((Stack<ICommand>)_commandManagerPrivate.GetFieldOrProperty("_undoStack")).Count);
            Assert.AreEqual(0, ((Stack<ICommand>)_commandManagerPrivate.GetFieldOrProperty("_redoStack")).Count);

        }

        // Clear undo and Undo test
        [TestMethod()]
        public void ClearTest()
        {
            _commandManager.Execute(new AddShapeCommand(_pageList, _currentPageIndex, LINE, _startPoint, _endPoint));
            _commandManager.Execute(new AddShapeCommand(_pageList, _currentPageIndex, LINE, _startPoint, _endPoint));
            _commandManager.Undo();
            _commandManager.Clear();
            Assert.IsFalse(_commandManager.IsUndo());
            Assert.IsFalse(_commandManager.IsRedo());
        }

        // Is undo test
        [TestMethod()]
        public void IsUndoTest()
        {
            Assert.IsFalse(_commandManager.IsUndo());
            _commandManager.Execute(new AddShapeCommand(_pageList, _currentPageIndex, LINE, _startPoint, _endPoint));
            Assert.IsTrue(_commandManager.IsUndo());
            _commandManager.Undo();
            Assert.IsFalse(_commandManager.IsUndo());
        }

        // // Is redo test
        [TestMethod()]
        public void IsRedoTest()
        {
            Assert.IsFalse(_commandManager.IsRedo());
            _commandManager.Execute(new AddShapeCommand(_pageList, _currentPageIndex, LINE, _startPoint, _endPoint));
            _commandManager.Undo();
            Assert.IsTrue(_commandManager.IsRedo());
            _commandManager.Redo();
            _commandManager.Execute(new DeleteShapeCommand(_pageList, _currentPageIndex, 0));
            Assert.IsFalse(_commandManager.IsRedo());
        }
    }
}