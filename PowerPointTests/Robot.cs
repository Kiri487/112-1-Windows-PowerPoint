using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;
using System.Windows.Automation;
using System.Windows;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Windows.Input;
using System.Windows.Forms;
using OpenQA.Selenium.Interactions;

namespace PowerPointTests
{
    public class Robot
    {
        private WindowsDriver<WindowsElement> _driver;
        private Dictionary<string, string> _windowHandles;
        private string _root;
        private const string CONTROL_NOT_FOUND_EXCEPTION = "The specific control is not found!!";
        private const string WIN_APP_DRIVER_URI = "http://127.0.0.1:4723";
        private const string CHECKED = "1048724";
        const float RATE = (float)9 / (float)16;

        // constructor
        public Robot(string targetAppPath, string root)
        {
            this.Initialize(targetAppPath, root);
        }

        // initialize
        public void Initialize(string targetAppPath, string root)
        {
            _root = root;
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", targetAppPath);
            options.AddAdditionalCapability("deviceName", "WindowsPC");

            _driver = new WindowsDriver<WindowsElement>(new Uri(WIN_APP_DRIVER_URI), options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _windowHandles = new Dictionary<string, string>
            {
                { _root, _driver.CurrentWindowHandle }
            };
        }

        // clean up
        public void CleanUp()
        {
            SwitchTo(_root);
            _driver.CloseApp();
            _driver.Dispose();
        }

        // test
        public void SwitchTo(string formName)
        {
            if (_windowHandles.ContainsKey(formName))
            {
                _driver.SwitchTo().Window(_windowHandles[formName]);
            }
            else
            {
                foreach (var windowHandle in _driver.WindowHandles)
                {
                    _driver.SwitchTo().Window(windowHandle);
                    try
                    {
                        _driver.FindElementByAccessibilityId(formName);
                        _windowHandles.Add(formName, windowHandle);
                        return;
                    }
                    catch
                    {

                    }
                }
            }
        }

        // test
        public void Sleep(Double time)
        {
            Thread.Sleep(TimeSpan.FromSeconds(time));
        }

        // test
        public bool HasElements(string name)
        {
            try
            {
                _driver.FindElementByName(name);
                return true;
            } 
            catch (WebDriverException)
            {
                return false;
            }
        }

        // test
        public void ClickButtonWithName(string name)
        {
            _driver.FindElementByName(name).Click();
        }

        // test
        public void ClickButtonWithId(string name)
        {
            _driver.FindElementByAccessibilityId(name).Click();
        }

        // test
        public void ClickTabControl(string name)
        {
            var elements = _driver.FindElementsByName(name);
            foreach (var element in elements)
            {
                if ("ControlType.TabItem" == element.TagName)
                    element.Click();
            }
        }

        // test
        public void ClickOnElementWithId(string name, int x, int y)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(name);

            Actions actions = new Actions(_driver);
            actions.MoveToElement(element, x + 2, y + 2)
                   .Click()
                   .Perform();
        }

        // Generate number
        public int[] GenerateNumber(string name)
        {
            WindowsElement canva = _driver.FindElementByAccessibilityId(name);
            Random random = new Random();

            int startX = random.Next(0, canva.Size.Width / 2);
            int startY = random.Next(0, canva.Size.Height / 2);
            int endX = random.Next(startX, canva.Size.Width);
            int endY = random.Next(startY, canva.Size.Height);

            return new[] { startX, startY, endX, endY };
        }

        // Enter number
        public void EnterNumber(string name, string text)
        {
            WindowsElement textBox = _driver.FindElementByAccessibilityId(name);
            textBox.Click();

            foreach (char digit in text)
            {
                switch (digit)
                {
                    case '0':
                        textBox.SendKeys(OpenQA.Selenium.Keys.NumberPad0);
                        break;
                    case '1':
                        textBox.SendKeys(OpenQA.Selenium.Keys.NumberPad1);
                        break;
                    case '2':
                        textBox.SendKeys(OpenQA.Selenium.Keys.NumberPad2);
                        break;
                    case '3':
                        textBox.SendKeys(OpenQA.Selenium.Keys.NumberPad3);
                        break;
                    case '4':
                        textBox.SendKeys(OpenQA.Selenium.Keys.NumberPad4);
                        break;
                    case '5':
                        textBox.SendKeys(OpenQA.Selenium.Keys.NumberPad5);
                        break;
                    case '6':
                        textBox.SendKeys(OpenQA.Selenium.Keys.NumberPad6);
                        break;
                    case '7':
                        textBox.SendKeys(OpenQA.Selenium.Keys.NumberPad7);
                        break;
                    case '8':
                        textBox.SendKeys(OpenQA.Selenium.Keys.NumberPad8);
                        break;
                    case '9':
                        textBox.SendKeys(OpenQA.Selenium.Keys.NumberPad9);
                        break;
                }
            }
        }

        // choose shape
        public void ChooseShape(string name, string shape){
            _driver.FindElementByAccessibilityId(name).Click();
            _driver.FindElementByName(shape).Click();
        }


        // Press "delete"
        public void PressDelete()
        {
            
            Actions actions = new Actions(_driver);
            actions.SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
        }

        // test
        public void CloseWindow()
        {
            SendKeys.SendWait("%{F4}");
        }

        // test
        public void CloseMessageBox()
        {
            _driver.FindElementByName("確定").Click();
        }

        // test
        public void ClickDataGridViewCellBy(string name, int rowIndex, string columnName)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            _driver.FindElementByName($"{columnName} 資料列 {rowIndex}").Click();
        }

        // Assert enable
        public void AssertEnable(string name, bool state)
        {
            WindowsElement element = _driver.FindElementByName(name);
            Assert.AreEqual(state, element.Enabled);
        }

        // Assert focus
        public void AssertFocus(string name, bool state)
        {
            WindowsElement element = _driver.FindElementByName(name);
            Assert.AreEqual(state.ToString(), element.GetAttribute("HasKeyboardFocus"));
        }

        // Assert tool strip button checked
        public void AssertToolStripButtonChecked(string name)
        {
            WindowsElement element = _driver.FindElementByName(name);
            Assert.AreEqual(CHECKED, element.GetAttribute("LegacyState"));
        }

        // Assert text
        public void AssertText(string name, string text)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(name);
            Assert.AreEqual(text, element.Text);
        }

        // Assert dataGridView row data by
        public void AssertDataGridViewRowDataBy(string name, int rowIndex, string[] data)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            var rowDatas = dataGridView.FindElementByName($"資料列 {rowIndex}").FindElementsByXPath("//*");

            // FindElementsByXPath("//*") 會把 "row" node 也抓出來，因此 i 要從 1 開始以跳過 "row" node
            for (int i = 1; i < rowDatas.Count; i++)
            {
                Assert.AreEqual(data[i - 1], rowDatas[i].Text.Replace("(null)", ""));
            }
        }

        // Assert dataGridView row count by
        public void AssertDataGridViewRowCountBy(string name, int count)
        {
            AutomationElement root = AutomationElement.RootElement;
            PropertyCondition condition = new PropertyCondition(AutomationElement.AutomationIdProperty, name);
            AutomationElement dataGridView = root.FindFirst(TreeScope.Descendants, condition);

            AutomationElementCollection rows = dataGridView.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.DataItem));
            int rowCount = rows.Count;
            Assert.AreEqual(count, rowCount);
        }

        // Assert panel children count
        public void AssertPanelChildrenCount(string name, int childrenIndex, int count)
        {
            AutomationElement root = AutomationElement.RootElement;
            PropertyCondition condition = new PropertyCondition(AutomationElement.AutomationIdProperty, name);
            AutomationElement splitContainer = root.FindFirst(TreeScope.Descendants, condition);

            AutomationElementCollection children = splitContainer.FindAll(TreeScope.Children, Condition.TrueCondition);
            if (children.Count > 0)
            {
                AutomationElementCollection grandchildren = children[childrenIndex].FindAll(TreeScope.Children, Condition.TrueCondition);
                int childrenCount = grandchildren.Count;
                Assert.AreEqual(count, childrenCount);
            }
        }

        // Assert 16:9 (with Id)
        public void Assert16To9WithId(string name)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(name);
            int height = element.Size.Height;
            int width = element.Size.Width;

            Assert.AreEqual(height, (int)(width * RATE));
        }

        // Assert 16:9 (with name)
        public void Assert16To9WithName(string name)
        {
            WindowsElement element = _driver.FindElementByName(name);
            int height = element.Size.Height;
            int width = element.Size.Width;

            Assert.AreEqual(height, (int)(width * RATE));
        }

        // Drag on element
        public void DragOnElement(string name, int startX, int startY, int offsetX, int offsetY)
        {

            WindowsElement element = _driver.FindElementByAccessibilityId(name);

            Actions actions = new Actions(_driver);
            actions.MoveToElement(element, startX + 2, startY + 2)
                   .ClickAndHold()
                   .MoveByOffset(offsetX, offsetY)
                   .Release()
                   .Perform();
        }

        // Rize windows
        public void RizeWindows(int offsetX, int offsetY)
        {
            WindowsElement form = _driver.FindElementByAccessibilityId("PowerPointForm");

            int startX = form.Size.Width - 5;
            int startY = form.Size.Height;

            Actions actions = new Actions(_driver);
            actions.MoveToElement(form, startX, startY)
                   .ClickAndHold()
                   .MoveByOffset(offsetX, offsetY)
                   .Release()
                   .Perform();
        }
    }
}
