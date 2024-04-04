using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointTests
{
    [TestClass()]
    public class UITest
    {
        private Robot _robot;
        private int _startX;
        private int _startY;
        private int _offsetX;
        private int _offsetY;
        private int _endX;
        private int _endY;
        private string targetAppPath;
        private const string MENU_FORM = "MenuForm";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            var projectName = "PowerPoint";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "PowerPoint.exe");
            _robot = new Robot(targetAppPath, MENU_FORM);
        }

        // Closes the launched program
        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        /// <summary>
        /// Shapes operations test
        /// </summary>
        // Click line button test
        [TestMethod]
        public void ClickLineButtonTest()
        {
            _robot.ClickButtonWithName("畫線");
            _robot.AssertToolStripButtonChecked("畫線");
        }

        // Draw line test
        [TestMethod]
        public void DrawLineTest()
        {
            _startX = 10;
            _startY = 100;
            _offsetX = 40;
            _offsetY = 40;

            ClickLineButtonTest();
            
            _robot.DragOnElement("_canvas", _startX, _startY, _offsetX, _offsetY);
            string[] data = {"刪除", "線", "(" + _startX + ", " + _startY + "), (" + (_startX + _offsetX) + ", " + (_startY + _offsetY) + ")" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);
        }

        // Move line test
        [TestMethod]
        public void MoveLineTest()
        {
            DrawLineTest();
            _robot.ClickOnElementWithId("_canvas", _startX, _startY);

            int offsetX = 50;
            int offsetY = 60;

            _robot.DragOnElement("_canvas", _startX, _startY, offsetX, offsetY);

            string[] data = { "刪除", "線", "(" + (_startX + offsetX) + ", " + (_startY + offsetY) + "), (" + (_startX + _offsetX + offsetX) + ", " + (_startY + _offsetY + offsetY) + ")" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);
        }

        // Scale line test
        [TestMethod]
        public void ScaleLineTest()
        {
            DrawLineTest();
            _robot.ClickOnElementWithId("_canvas", _startX, _startY);

            _endX = _startX + _offsetX;
            _endY = _startY + _offsetY;
            int offsetX = 50;
            int offsetY = 80;

            _robot.DragOnElement("_canvas", _endX, _endY, offsetX, offsetY);

            string[] data = { "刪除", "線", "(" + _startX + ", " + _startY + "), (" + (_endX + offsetX) + ", " + (_endY + offsetY) + ")" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);
        }

        // Click rectangle button test
        [TestMethod]
        public void ClickRectangleButtonTest()
        {
            _robot.ClickButtonWithName("畫矩形");
            _robot.AssertToolStripButtonChecked("畫矩形");
        }

        // Draw rectangle test
        [TestMethod]
        public void DrawRectangleTest()
        {
            _startX = 73;
            _startY = 61;
            _offsetX = 30;
            _offsetY = 10;

            ClickRectangleButtonTest();
            
            _robot.DragOnElement("_canvas", _startX, _startY, _offsetX, _offsetY);
            string[] data = { "刪除", "矩形", "(" + _startX + ", " + _startY + "), (" + (_startX + _offsetX) + ", " + (_startY + _offsetY) + ")" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);
        }

        // Move rectangle test
        [TestMethod]
        public void MoveRectangleTest()
        {
            DrawRectangleTest();
            _robot.ClickOnElementWithId("_canvas", _startX, _startY);

            int offsetX = 50;
            int offsetY = 5;

            _robot.DragOnElement("_canvas", _startX, _startY, offsetX, offsetY);

            string[] data = { "刪除", "矩形", "(" + (_startX + offsetX) + ", " + (_startY + offsetY) + "), (" + (_startX + _offsetX + offsetX) + ", " + (_startY + _offsetY + offsetY) + ")" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);
        }

        // Scale rectangle test
        [TestMethod]
        public void ScaleRectangleTest()
        {
            DrawRectangleTest();
            _robot.ClickOnElementWithId("_canvas", _startX, _startY);

            _endX = _startX + _offsetX;
            _endY = _startY + _offsetY;
            int offsetX = 50;
            int offsetY = 80;

            _robot.DragOnElement("_canvas", _endX, _endY, offsetX, offsetY);

            string[] data = { "刪除", "矩形", "(" + _startX + ", " + _startY + "), (" + (_endX + offsetX) + ", " + (_endY + offsetY) + ")" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);
        }

        // Click circle button test
        [TestMethod]
        public void ClickCircleButtonTest()
        {
            _robot.ClickButtonWithName("畫圓");
            _robot.AssertToolStripButtonChecked("畫圓");
        }

        // Draw circle test
        [TestMethod]
        public void DrawCircleTest()
        {
            _startX = 60;
            _startY = 20;
            _offsetX = 110;
            _offsetY = 110;
            string[] data = { "刪除", "橢圓", "(" + _startX + ", " + _startY + "), (" + (_startX + _offsetX) + ", " + (_startY + _offsetY) + ")" };

            ClickCircleButtonTest();
            _robot.DragOnElement("_canvas", _startX, _startY, _offsetX, _offsetY);
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);
        }

        // Move circle test
        [TestMethod]
        public void MoveCircleTest()
        {
            DrawCircleTest();
            _robot.ClickOnElementWithId("_canvas", _startX, _startY);

            int offsetX = 0;
            int offsetY = 100;

            _robot.DragOnElement("_canvas", _startX, _startY, offsetX, offsetY);

            string[] data = { "刪除", "橢圓", "(" + (_startX + offsetX) + ", " + (_startY + offsetY) + "), (" + (_startX + _offsetX + offsetX) + ", " + (_startY + _offsetY + offsetY) + ")" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);
        }

        // Scale circle test
        [TestMethod]
        public void ScaleCircleTest()
        {
            DrawCircleTest();
            _robot.ClickOnElementWithId("_canvas", _startX, _startY);

            _endX = _startX + _offsetX;
            _endY = _startY + _offsetY;
            int offsetX = 50;
            int offsetY = 80;

            _robot.DragOnElement("_canvas", _endX, _endY, offsetX, offsetY);

            string[] data = { "刪除", "橢圓", "(" + _startX + ", " + _startY + "), (" + (_endX + offsetX) + ", " + (_endY + offsetY) + ")" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);
        }

        /// <summary>
        /// Undo and redo test
        /// </summary>
        // Draw line undo and redo test
        [TestMethod]
        public void DrawLineUndoAndRedoTest()
        {
            DrawLineTest();
            _robot.ClickButtonWithName("Undo");
            _robot.AssertDataGridViewRowCountBy("_shapeDataGridView", 0);

            _robot.ClickButtonWithName("Redo");
            string[] data = { "刪除", "線", "(" + _startX + ", " + _startY + "), (" + (_startX + _offsetX) + ", " + (_startY + _offsetY) + ")" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);
        }

        // Draw rectangle undo and redo test
        [TestMethod]
        public void DrawRectangleUndoAndRedoTest()
        {
            DrawRectangleTest();
            _robot.ClickButtonWithName("Undo");
            _robot.AssertDataGridViewRowCountBy("_shapeDataGridView", 0);

            _robot.ClickButtonWithName("Redo");
            string[] data = { "刪除", "矩形", "(" + _startX + ", " + _startY + "), (" + (_startX + _offsetX) + ", " + (_startY + _offsetY) + ")" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);
        }
        
        // Draw circle undo and redo test
        [TestMethod]
        public void DrawCircleUndoAndRedoTest()
        {
            DrawCircleTest();
            _robot.ClickButtonWithName("Undo");
            _robot.AssertDataGridViewRowCountBy("_shapeDataGridView", 0);

            _robot.ClickButtonWithName("Redo");
            string[] data = { "刪除", "橢圓", "(" + _startX + ", " + _startY + "), (" + (_startX + _offsetX) + ", " + (_startY + _offsetY) + ")" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);
        }

        // Move line undo and redo test
        [TestMethod]
        public void MoveLineUndoAndRedoTest()
        {
            MoveLineTest();
            _robot.ClickButtonWithName("Undo");
            _robot.AssertDataGridViewRowCountBy("_shapeDataGridView", 0);

            int offsetX = 50;
            int offsetY = 60;

            _robot.ClickButtonWithName("Redo");
            string[] data = { "刪除", "線", "(" + (_startX + offsetX) + ", " + (_startY + offsetY) + "), (" + (_startX + _offsetX + offsetX) + ", " + (_startY + _offsetY + offsetY) + ")" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);
        }

        // Move rectangle undo and redo test
        [TestMethod]
        public void MoveRectangleUndoAndRedoTest()
        {
            MoveRectangleTest();
            _robot.ClickButtonWithName("Undo");
            _robot.AssertDataGridViewRowCountBy("_shapeDataGridView", 0);

            int offsetX = 50;
            int offsetY = 5;

            _robot.ClickButtonWithName("Redo");
            string[] data = { "刪除", "矩形", "(" + (_startX + offsetX) + ", " + (_startY + offsetY) + "), (" + (_startX + _offsetX + offsetX) + ", " + (_startY + _offsetY + offsetY) + ")" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);
        }

        // Move circle undo and redo test
        [TestMethod]
        public void MoveCircleUndoAndRedoTest()
        {
            MoveCircleTest();
            _robot.ClickButtonWithName("Undo");
            _robot.AssertDataGridViewRowCountBy("_shapeDataGridView", 0);

            int offsetX = 0;
            int offsetY = 100;

            _robot.ClickButtonWithName("Redo");
            string[] data = { "刪除", "橢圓", "(" + (_startX + offsetX) + ", " + (_startY + offsetY) + "), (" + (_startX + _offsetX + offsetX) + ", " + (_startY + _offsetY + offsetY) + ")" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);
        }

        // Scale line undo and redo test
        [TestMethod]
        public void ScaleLineUndoAndRedoTest()
        {
            ScaleLineTest();
            _robot.ClickButtonWithName("Undo");
            _robot.AssertDataGridViewRowCountBy("_shapeDataGridView", 0);

            _endX = _startX + _offsetX;
            _endY = _startY + _offsetY;
            int offsetX = 50;
            int offsetY = 80;

            _robot.ClickButtonWithName("Redo");
            string[] data = { "刪除", "線", "(" + _startX + ", " + _startY + "), (" + (_endX + offsetX) + ", " + (_endY + offsetY) + ")" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);
        }

        // Scale rectangle undo and redo test
        [TestMethod]
        public void ScaleRectangleUndoAndRedoTest()
        {
            ScaleRectangleTest();
            _robot.ClickButtonWithName("Undo");
            _robot.AssertDataGridViewRowCountBy("_shapeDataGridView", 0);

            _endX = _startX + _offsetX;
            _endY = _startY + _offsetY;
            int offsetX = 50;
            int offsetY = 80;

            _robot.ClickButtonWithName("Redo");
            string[] data = { "刪除", "矩形", "(" + _startX + ", " + _startY + "), (" + (_endX + offsetX) + ", " + (_endY + offsetY) + ")" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);
        }

        // Scale circle undo and redo test
        [TestMethod]
        public void ScaleCircleUndoAndRedoTest()
        {
            ScaleCircleTest();
            _robot.ClickButtonWithName("Undo");
            _robot.AssertDataGridViewRowCountBy("_shapeDataGridView", 0);

            _endX = _startX + _offsetX;
            _endY = _startY + _offsetY;
            int offsetX = 50;
            int offsetY = 80;

            _robot.ClickButtonWithName("Redo");
            string[] data = { "刪除", "橢圓", "(" + _startX + ", " + _startY + "), (" + (_endX + offsetX) + ", " + (_endY + offsetY) + ")" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);
        }

        // dataGridView add line undo and redo test
        [TestMethod]
        public void DataGridViewAddLineUndoAndRedoTest()
        {
            DataGridViewAddLineTest();
            _robot.ClickButtonWithName("Undo");
            _robot.ClickButtonWithName("Redo");
            string[] data = { "刪除", "線", "(" + _startX + ", " + _startY + "), (" + _endX + ", " + _endY + ")" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);
        }

        // dataGridView add rectangle undo and redo test
        [TestMethod]
        public void DataGridViewAddRectangleUndoAndRedoTest()
        {
            DataGridViewAddRectangleTest();
            _robot.ClickButtonWithName("Undo");
            _robot.ClickButtonWithName("Redo");
            string[] data = { "刪除", "矩形", "(" + _startX + ", " + _startY + "), (" + _endX + ", " + _endY + ")" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);
        }

        // dataGridView add circle undo and redo test
        [TestMethod]
        public void DataGridViewAddCircleUndoAndRedoTest()
        {
            DataGridViewAddCircleTest();
            _robot.ClickButtonWithName("Undo");
            _robot.ClickButtonWithName("Redo");
            string[] data = { "刪除", "橢圓", "(" + _startX + ", " + _startY + "), (" + _endX + ", " + _endY + ")" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);
        }

        /// <summary>
        /// dataGridView test
        /// </summary>
        // dataGridView add line test
        [TestMethod]
        public void DataGridViewAddLineTest()
        {
            int[] points = _robot.GenerateNumber("_canvas");
            _startX = points[0];
            _startY = points[1];
            _endX = points[2];
            _endY = points[3];

            _robot.ChooseShape("_chooseShapeComboBox", "線");
            _robot.ClickButtonWithName("新增");
            _robot.EnterNumber("_upperLeftPointXTextBox", _startX.ToString());
            _robot.EnterNumber("_upperLeftPointYTextBox", _startY.ToString());
            _robot.EnterNumber("_lowerRightPointXTextBox", _endX.ToString());
            _robot.EnterNumber("_lowerRightPointYTextBox", _endY.ToString());
            _robot.ClickButtonWithName("OK");

            string[] data = { "刪除", "線", "(" + _startX + ", " + _startY + "), (" + _endX + ", " + _endY + ")" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);
        }

        // dataGridView delete line test
        [TestMethod]
        public void DataGridViewDeleteLineTest()
        {
            DataGridViewAddLineTest();
            _robot.ClickDataGridViewCellBy("_shapeDataGridView", 0, "刪除");
            _robot.AssertDataGridViewRowCountBy("_shapeDataGridView", 0);
        }

        // dataGridView add rectangle test
        [TestMethod]
        public void DataGridViewAddRectangleTest()
        {
            int[] points = _robot.GenerateNumber("_canvas");
            _startX = points[0];
            _startY = points[1];
            _endX = points[2];
            _endY = points[3];

            _robot.ChooseShape("_chooseShapeComboBox", "矩形");
            _robot.ClickButtonWithName("新增");
            _robot.EnterNumber("_upperLeftPointXTextBox", _startX.ToString());
            _robot.EnterNumber("_upperLeftPointYTextBox", _startY.ToString());
            _robot.EnterNumber("_lowerRightPointXTextBox", _endX.ToString());
            _robot.EnterNumber("_lowerRightPointYTextBox", _endY.ToString());
            _robot.ClickButtonWithName("OK");

            string[] data = { "刪除", "矩形", "(" + _startX + ", " + _startY + "), (" + _endX + ", " + _endY + ")" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);
        }

        // dataGridView delete rectangle test
        [TestMethod]
        public void DataGridViewDeleteRectangleTest()
        {
            DataGridViewAddRectangleTest();
            _robot.ClickDataGridViewCellBy("_shapeDataGridView", 0, "刪除");
            _robot.AssertDataGridViewRowCountBy("_shapeDataGridView", 0);
        }

        // dataGridView add circle test
        [TestMethod]
        public void DataGridViewAddCircleTest()
        {
            int[] points = _robot.GenerateNumber("_canvas");
            _startX = points[0];
            _startY = points[1];
            _endX = points[2];
            _endY = points[3];

            _robot.ChooseShape("_chooseShapeComboBox", "橢圓");
            _robot.ClickButtonWithName("新增");
            _robot.EnterNumber("_upperLeftPointXTextBox", _startX.ToString());
            _robot.EnterNumber("_upperLeftPointYTextBox", _startY.ToString());
            _robot.EnterNumber("_lowerRightPointXTextBox", _endX.ToString());
            _robot.EnterNumber("_lowerRightPointYTextBox", _endY.ToString());
            _robot.ClickButtonWithName("OK");

            string[] data = { "刪除", "橢圓", "(" + _startX + ", " + _startY + "), (" + _endX + ", " + _endY + ")" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);
        }

        // dataGridView delete circle test
        [TestMethod]
        public void DataGridViewDeleteCircleTest()
        {
            DataGridViewAddCircleTest();
            _robot.ClickDataGridViewCellBy("_shapeDataGridView", 0, "刪除");
            _robot.AssertDataGridViewRowCountBy("_shapeDataGridView", 0);
        }

        /// <summary>
        /// Pages test
        /// </summary>
        [TestMethod]
        public void ClickAddPageButtonTest()
        {
            _robot.ClickButtonWithName("新增頁面");
            _robot.AssertPanelChildrenCount("_splitContainer1", 0, 2);
        }

        // Delete slide button test
        [TestMethod]
        public void DeleteSlideButtonTest()
        {
            ClickAddPageButtonTest();
            _robot.ClickButtonWithName("page1");
            _robot.PressDelete();
            _robot.AssertPanelChildrenCount("_splitContainer1", 0, 1);
        }

        // Add slide button test
        [TestMethod]
        public void AddSlideButtonTest()
        {
            ClickAddPageButtonTest();
            _robot.AssertFocus("page2", true);
        }

        // Click slide button 1 test
        [TestMethod]
        public void ClickSlideButton1Test()
        {
            AddSlideButtonTest();

            _robot.ClickButtonWithName("page1");
            _robot.AssertFocus("page1", true);
        }

        // Click slide button 2 test
        [TestMethod]
        public void ClickSlideButton2Test()
        {
            ClickSlideButton1Test();

            _robot.ClickButtonWithName("page2");
            _robot.AssertFocus("page2", true);
        }

        // Rize windows test
        [TestMethod]
        public void RizeWindowsTest()
        {
            _robot.DragOnElement("PowerPointForm", 80, 8, 0, -60);
            _robot.RizeWindows(40, 40);
            _robot.Assert16To9WithId("_canvas");
            _robot.Assert16To9WithName("page1");
        }

        /// <summary>
        /// Integration Test
        /// </summary>
        // Integration Test
        [TestMethod]
        public void IntegrationTest()
        {
            ClickCircleButtonTest();
            _robot.DragOnElement("_canvas", 60, 21, 170, 131);
            ClickCircleButtonTest();
            _robot.DragOnElement("_canvas", 60, 21, 170, 131);
            _robot.ClickOnElementWithId("_canvas", 70, 30);
            _robot.DragOnElement("_canvas", 70, 30, 0, 100);
            ClickRectangleButtonTest();
            _robot.DragOnElement("_canvas", 73, 61, 30, 10);
            ClickRectangleButtonTest();
            _robot.DragOnElement("_canvas", 73, 61, 30, 10);
            _robot.ClickOnElementWithId("_canvas", 80, 65);
            _robot.DragOnElement("_canvas", 80, 65, 80, 0);
            ClickLineButtonTest();
            _robot.DragOnElement("_canvas", 12, 104, 45, 44);
            ClickLineButtonTest();
            _robot.DragOnElement("_canvas", 230, 126, 50, -80);
            ClickAddPageButtonTest();
            ClickLineButtonTest();
            _robot.DragOnElement("_canvas", 19, 201, 65, -104);
            ClickLineButtonTest();
            _robot.DragOnElement("_canvas", 84, 104, 126, 163);
            ClickLineButtonTest();
            _robot.DragOnElement("_canvas", 187, 222, 68, -80);
            _robot.ChooseShape("_chooseShapeComboBox", "線");
            _robot.ClickButtonWithName("新增");
            _robot.EnterNumber("_upperLeftPointXTextBox", "261");
            _robot.EnterNumber("_upperLeftPointYTextBox", "145");
            _robot.EnterNumber("_lowerRightPointXTextBox", "444");
            _robot.EnterNumber("_lowerRightPointYTextBox", "265");
            _robot.ClickButtonWithName("OK");
            ClickCircleButtonTest();
            _robot.DragOnElement("_canvas", 314, 14, 85, 87);
            _robot.ClickOnElementWithId("_canvas", 316, 90);
            _robot.DragOnElement("_canvas", 328, 172, 30, 30);
            _robot.ChooseShape("_chooseShapeComboBox", "矩形");
            _robot.ClickButtonWithName("新增");
            _robot.EnterNumber("_upperLeftPointXTextBox", "168");
            _robot.EnterNumber("_upperLeftPointYTextBox", "35");
            _robot.EnterNumber("_lowerRightPointXTextBox", "289");
            _robot.EnterNumber("_lowerRightPointYTextBox", "56");
            _robot.ClickButtonWithName("OK");
            _robot.ChooseShape("_chooseShapeComboBox", "矩形");
            _robot.ClickButtonWithName("新增");
            _robot.EnterNumber("_upperLeftPointXTextBox", "117");
            _robot.EnterNumber("_upperLeftPointYTextBox", "57");
            _robot.EnterNumber("_lowerRightPointXTextBox", "231");
            _robot.EnterNumber("_lowerRightPointYTextBox", "89");
            _robot.ClickButtonWithName("OK");
            _robot.ClickButtonWithName("Undo");
            _robot.ClickButtonWithName("Redo");
            ClickSlideButton1Test();
            RizeWindowsTest();
        }
    }
}
