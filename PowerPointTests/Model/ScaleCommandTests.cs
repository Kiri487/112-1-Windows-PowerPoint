using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PowerPoint.Model.Tests
{
    [TestClass()]
    public class ScaleCommandTests
    {
        ScaleCommand _scaleCommand;
        List<Shapes> _pageList = new List<Shapes>();
        PageIndex _currentPageIndex = new PageIndex(0);
        CoordinatePoint _startPoint = new CoordinatePoint(10, 20);
        CoordinatePoint _endPoint = new CoordinatePoint(30, 50);
        CoordinatePoint _scaledEndPoint = new CoordinatePoint(30 + OFFSET_X, 50 + OFFSET_Y);
        const float OFFSET_X = -30;
        const float OFFSET_Y = -40;
        const string LINE = "線";
        const string RECTANGLE = "矩形";
        const string CIRCLE = "橢圓";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _pageList.Add(new Shapes());
        }

        // Line execute test
        [TestMethod()]
        public void LineExecuteTest()
        {
            _pageList[_currentPageIndex.GetPageIndex()].SetDrawingShapeName(LINE);
            _pageList[_currentPageIndex.GetPageIndex()].AddShape(_startPoint, _endPoint);
            _scaleCommand = new ScaleCommand(_pageList, _currentPageIndex, OFFSET_X, OFFSET_Y);

            Assert.IsFalse(_pageList[_currentPageIndex.GetPageIndex()].IsSelect());
            _scaleCommand.Execute();
            Assert.AreEqual(_scaledEndPoint.ToString(), _pageList[_currentPageIndex.GetPageIndex()].GetShapeEndPoint(0).ToString());
            Assert.IsFalse(_pageList[_currentPageIndex.GetPageIndex()].IsSelect());
        }

        // Rectangle execute test
        [TestMethod()]
        public void RectangleExecuteTest()
        {
            _pageList[_currentPageIndex.GetPageIndex()].SetDrawingShapeName(RECTANGLE);
            _pageList[_currentPageIndex.GetPageIndex()].AddShape(_startPoint, _endPoint);
            _scaleCommand = new ScaleCommand(_pageList, _currentPageIndex, OFFSET_X, OFFSET_Y);

            Assert.IsFalse(_pageList[_currentPageIndex.GetPageIndex()].IsSelect());
            _scaleCommand.Execute();
            Assert.AreEqual(_scaledEndPoint.ToString(), _pageList[_currentPageIndex.GetPageIndex()].GetShapeEndPoint(0).ToString());
            Assert.IsFalse(_pageList[_currentPageIndex.GetPageIndex()].IsSelect());
        }

        // Circle execute test
        [TestMethod()]
        public void CircleExecuteTest()
        {
            _pageList[_currentPageIndex.GetPageIndex()].SetDrawingShapeName(CIRCLE);
            _pageList[_currentPageIndex.GetPageIndex()].AddShape(_startPoint, _endPoint);
            _scaleCommand = new ScaleCommand(_pageList, _currentPageIndex, OFFSET_X, OFFSET_Y);

            Assert.IsFalse(_pageList[_currentPageIndex.GetPageIndex()].IsSelect());
            _scaleCommand.Execute();
            Assert.AreEqual(_scaledEndPoint.ToString(), _pageList[_currentPageIndex.GetPageIndex()].GetShapeEndPoint(0).ToString());
            Assert.IsFalse(_pageList[_currentPageIndex.GetPageIndex()].IsSelect());
        }

        // Line execute test (already select)
        [TestMethod()]
        public void LineAlreadySelectExecuteTest()
        {
            _pageList[_currentPageIndex.GetPageIndex()].SetDrawingShapeName(LINE);
            _pageList[_currentPageIndex.GetPageIndex()].AddShape(_startPoint, _endPoint);
            _scaleCommand = new ScaleCommand(_pageList, _currentPageIndex, OFFSET_X, OFFSET_Y);

            _pageList[_currentPageIndex.GetPageIndex()].SetSelectShape(0);
            _scaleCommand.Execute();
            Assert.AreEqual(_scaledEndPoint.ToString(), _pageList[_currentPageIndex.GetPageIndex()].GetShapeEndPoint(0).ToString());
            Assert.IsTrue(_pageList[_currentPageIndex.GetPageIndex()].IsSelect());
        }

        // Rectangle execute test (already select)
        [TestMethod()]
        public void RectangleAlreadySelectExecuteTest()
        {
            _pageList[_currentPageIndex.GetPageIndex()].SetDrawingShapeName(RECTANGLE);
            _pageList[_currentPageIndex.GetPageIndex()].AddShape(_startPoint, _endPoint);
            _scaleCommand = new ScaleCommand(_pageList, _currentPageIndex, OFFSET_X, OFFSET_Y);

            _pageList[_currentPageIndex.GetPageIndex()].SetSelectShape(0);
            _scaleCommand.Execute();
            Assert.AreEqual(_scaledEndPoint.ToString(), _pageList[_currentPageIndex.GetPageIndex()].GetShapeEndPoint(0).ToString());
            Assert.IsTrue(_pageList[_currentPageIndex.GetPageIndex()].IsSelect());
        }

        // Circle execute test (already select)
        [TestMethod()]
        public void CircleAlreadySelectExecuteTest()
        {
            _pageList[_currentPageIndex.GetPageIndex()].SetDrawingShapeName(CIRCLE);
            _pageList[_currentPageIndex.GetPageIndex()].AddShape(_startPoint, _endPoint);
            _scaleCommand = new ScaleCommand(_pageList, _currentPageIndex, OFFSET_X, OFFSET_Y);

            _pageList[_currentPageIndex.GetPageIndex()].SetSelectShape(0);
            _scaleCommand.Execute();
            Assert.AreEqual(_scaledEndPoint.ToString(), _pageList[_currentPageIndex.GetPageIndex()].GetShapeEndPoint(0).ToString());
            Assert.IsTrue(_pageList[_currentPageIndex.GetPageIndex()].IsSelect());
        }

        // Line cancel execute test
        [TestMethod()]
        public void LineCancelExecuteTest()
        {
            _pageList[_currentPageIndex.GetPageIndex()].SetDrawingShapeName(LINE);
            _pageList[_currentPageIndex.GetPageIndex()].AddShape(_startPoint, _endPoint);
            _scaleCommand = new ScaleCommand(_pageList, _currentPageIndex, OFFSET_X, OFFSET_Y);

            _scaleCommand.Execute();
            _scaleCommand.CancelExecute();
            Assert.AreEqual("(10, 20)", _pageList[_currentPageIndex.GetPageIndex()].GetShapeStartPoint(0).ToString());
            Assert.AreEqual("(30, 50)", _pageList[_currentPageIndex.GetPageIndex()].GetShapeEndPoint(0).ToString());
        }

        // Rectangle cancel execute test
        [TestMethod()]
        public void RectangleCancelExecuteTest()
        {
            _pageList[_currentPageIndex.GetPageIndex()].SetDrawingShapeName(RECTANGLE);
            _pageList[_currentPageIndex.GetPageIndex()].AddShape(_startPoint, _endPoint);
            _scaleCommand = new ScaleCommand(_pageList, _currentPageIndex, OFFSET_X, OFFSET_Y);

            _scaleCommand.Execute();
            _scaleCommand.CancelExecute();
            Assert.AreEqual("(10, 20)", _pageList[_currentPageIndex.GetPageIndex()].GetShapeStartPoint(0).ToString());
            Assert.AreEqual("(30, 50)", _pageList[_currentPageIndex.GetPageIndex()].GetShapeEndPoint(0).ToString());
        }

        // Circle cancel execute test
        [TestMethod()]
        public void CircleCancelExecuteTest()
        {
            _pageList[_currentPageIndex.GetPageIndex()].SetDrawingShapeName(CIRCLE);
            _pageList[_currentPageIndex.GetPageIndex()].AddShape(_startPoint, _endPoint);
            _scaleCommand = new ScaleCommand(_pageList, _currentPageIndex, OFFSET_X, OFFSET_Y);

            _scaleCommand.Execute();
            _scaleCommand.CancelExecute();
            Assert.AreEqual("(10, 20)", _pageList[_currentPageIndex.GetPageIndex()].GetShapeStartPoint(0).ToString());
            Assert.AreEqual("(30, 50)", _pageList[_currentPageIndex.GetPageIndex()].GetShapeEndPoint(0).ToString());
        }
    }
}