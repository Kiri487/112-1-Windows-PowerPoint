using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerPoint.Model.Tests
{
    [TestClass()]
    public class CoordinatePointTests
    {
        CoordinatePoint _coordinatePoint;
        PrivateObject _coordinatePointPrivate;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _coordinatePoint = new CoordinatePoint(0, 0);
            _coordinatePointPrivate = new PrivateObject(_coordinatePoint);
        }

        // Set point test when both positive
        [TestMethod()]
        public void SetPointWhenBothPositiveTest()
        {
            _coordinatePoint.SetPoint(100, 300);

            Assert.AreEqual((float)100, _coordinatePointPrivate.GetFieldOrProperty("_pointX"));
            Assert.AreEqual((float)300, _coordinatePointPrivate.GetFieldOrProperty("_pointY"));
        }

        // Set point test when both negative
        [TestMethod()]
        public void SetPointWhenBothNegativeTest()
        {
            _coordinatePoint.SetPoint(-100, -300);

            Assert.AreEqual((float)-100, _coordinatePointPrivate.GetFieldOrProperty("_pointX"));
            Assert.AreEqual((float)-300, _coordinatePointPrivate.GetFieldOrProperty("_pointY"));
        }

        // Set point test when X is positive and Y is negative
        [TestMethod()]
        public void SetPointWhenPositiveXNegativeYTest()
        {
            _coordinatePoint.SetPoint(100, -300);

            Assert.AreEqual((float)100, _coordinatePointPrivate.GetFieldOrProperty("_pointX"));
            Assert.AreEqual((float)-300, _coordinatePointPrivate.GetFieldOrProperty("_pointY"));
        }

        // Set point test when Y is positive and X is negative
        [TestMethod()]
        public void SetPointWhenPositiveYNegativeXTest()
        {
            _coordinatePoint.SetPoint(-100, 300);

            Assert.AreEqual((float)-100, _coordinatePointPrivate.GetFieldOrProperty("_pointX"));
            Assert.AreEqual((float)300, _coordinatePointPrivate.GetFieldOrProperty("_pointY"));
        }

        // Get point X test
        [TestMethod()]
        public void GetPointXTest()
        {
            Assert.AreEqual(_coordinatePointPrivate.GetFieldOrProperty("_pointX"), _coordinatePoint.GetPointX());
        }

        // Get point Y test
        [TestMethod()]
        public void GetPointYTest()
        {
            Assert.AreEqual(_coordinatePointPrivate.GetFieldOrProperty("_pointY"), _coordinatePoint.GetPointY());
        }

        // To string test
        [TestMethod()]
        public void ToStringTest()
        {
            _coordinatePoint.SetPoint(100, 300);
            Assert.AreEqual("(100, 300)", _coordinatePoint.ToString());
        }

        // Move point test when both positive
        [TestMethod()]
        public void MovePointWhenBothPositiveTest()
        {
            float pointX = (float)_coordinatePointPrivate.GetFieldOrProperty("_pointX");
            float pointY = (float)_coordinatePointPrivate.GetFieldOrProperty("_pointY");

            _coordinatePoint.MovePoint(10, 30);
            Assert.AreEqual(pointX + (float)10, _coordinatePointPrivate.GetFieldOrProperty("_pointX"));
            Assert.AreEqual(pointY + (float)30, _coordinatePointPrivate.GetFieldOrProperty("_pointY"));
        }

        // Move point test when both negative
        [TestMethod()]
        public void MovePointWhenBothNegativeTest()
        {
            float pointX = (float)_coordinatePointPrivate.GetFieldOrProperty("_pointX");
            float pointY = (float)_coordinatePointPrivate.GetFieldOrProperty("_pointY");

            _coordinatePoint.MovePoint(-10, -30);
            Assert.AreEqual(pointX - (float)10, _coordinatePointPrivate.GetFieldOrProperty("_pointX"));
            Assert.AreEqual(pointY - (float)30, _coordinatePointPrivate.GetFieldOrProperty("_pointY"));
        }

        // Move point test when X is positive and Y is negative
        [TestMethod()]
        public void MovePointWhenPositiveXNegativeYTest()
        {
            float pointX = (float)_coordinatePointPrivate.GetFieldOrProperty("_pointX");
            float pointY = (float)_coordinatePointPrivate.GetFieldOrProperty("_pointY");

            _coordinatePoint.MovePoint(10, -30);
            Assert.AreEqual(pointX + (float)10, _coordinatePointPrivate.GetFieldOrProperty("_pointX"));
            Assert.AreEqual(pointY - (float)30, _coordinatePointPrivate.GetFieldOrProperty("_pointY"));
        }

        // Move point test when Y is positive and X is negative
        [TestMethod()]
        public void MovePointWhenPositiveYNegativeXTest()
        {
            float pointX = (float)_coordinatePointPrivate.GetFieldOrProperty("_pointX");
            float pointY = (float)_coordinatePointPrivate.GetFieldOrProperty("_pointY");

            _coordinatePoint.MovePoint(-10, 30);
            Assert.AreEqual(pointX - (float)10, _coordinatePointPrivate.GetFieldOrProperty("_pointX"));
            Assert.AreEqual(pointY + (float)30, _coordinatePointPrivate.GetFieldOrProperty("_pointY"));
        }

        // Calculate offset X test when positive
        [TestMethod()]
        public void CalculateOffsetXWhenPositiveTest()
        {
            CoordinatePoint point = new CoordinatePoint(10, 10);

            Assert.AreEqual(10 - (float)_coordinatePointPrivate.GetFieldOrProperty("_pointX"), _coordinatePoint.CalculateOffsetX(point));
        }

        // Calculate offset X test when negative
        [TestMethod()]
        public void CalculateOffsetXWhenNegativeTest()
        {
            CoordinatePoint point = new CoordinatePoint(-10, 10);

            Assert.AreEqual((-10) - (float)_coordinatePointPrivate.GetFieldOrProperty("_pointX"), _coordinatePoint.CalculateOffsetX(point));
        }

        // Calculate offset Y test when positive
        [TestMethod()]
        public void CalculateOffsetYWhenPositiveTest()
        {
            CoordinatePoint point = new CoordinatePoint(10, 10);

            Assert.AreEqual(10 - (float)_coordinatePointPrivate.GetFieldOrProperty("_pointY"), _coordinatePoint.CalculateOffsetY(point));
        }

        // Calculate offset Y test when negative
        [TestMethod()]
        public void CalculateOffsetYWhenNegativeTest()
        {
            CoordinatePoint point = new CoordinatePoint(10, -10);

            Assert.AreEqual((-10) - (float)_coordinatePointPrivate.GetFieldOrProperty("_pointY"), _coordinatePoint.CalculateOffsetY(point));
        }

        // Scale point test
        [TestMethod()]
        public void ScalePointTest()
        {
            float pointX = (float)_coordinatePointPrivate.GetFieldOrProperty("_pointX");
            float pointY = (float)_coordinatePointPrivate.GetFieldOrProperty("_pointY");
            float rateX = 2;
            float rateY = (float)1.5;
            _coordinatePoint.Scale(rateX, rateY);

            Assert.AreEqual(pointX * rateX, (float)_coordinatePointPrivate.GetFieldOrProperty("_pointX"));
            Assert.AreEqual(pointY * rateY, (float)_coordinatePointPrivate.GetFieldOrProperty("_pointY"));
        }

        // Get shape info test
        [TestMethod()]
        public void GetShapeInfoTest()
        {
            CoordinatePoint point = new CoordinatePoint(10, -10);
            Assert.AreEqual("(0, 0), (10, -10)", _coordinatePoint.GetShapeInfo(point, 1, 1));
        }
    }
}