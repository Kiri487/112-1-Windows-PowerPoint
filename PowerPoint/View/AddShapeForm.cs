using PowerPoint.Model;
using System;
using System.Windows.Forms;

namespace PowerPoint.View
{
    public partial class AddShapeForm : Form
    {
        private PowerPointModel _model;
        private float _rateX = 1;
        private float _rateY = 1;
        float _upperLeftPointX;
        float _upperLeftPointY;
        float _lowerRightPointX;
        float _lowerRightPointY;
        const float POINT_X_MAX = 3200;
        const float POINT_Y_MAX = 1800;

        public AddShapeForm(PowerPointModel model, int canvasWidth, int canvasHeight)
        {
            _model = model;
            _rateX = POINT_X_MAX / (float)canvasWidth;
            _rateY = POINT_Y_MAX / (float)canvasHeight; 
            InitializeComponent();
            _okButton.Enabled = false;
        }

        // "OK" button click event
        private void ClickOkButton(object sender, System.EventArgs e)
        {
            CoordinatePoint upperLeftPoint = new CoordinatePoint(_upperLeftPointX, _upperLeftPointY);
            CoordinatePoint lowerRightPoint = new CoordinatePoint(_lowerRightPointX, _lowerRightPointY);
            _model.AddShape(upperLeftPoint, lowerRightPoint);
            this.Close();
        }

        // "Cancel" button click event
        private void ClickCancelButton(object sender, System.EventArgs e)
        {
            this.Close();
        }

        // Check text of TextBox changed
        private void CheckTextChanged(object sender, EventArgs e)
        {
            _okButton.Enabled = IsOkButtonEnable(_upperLeftPointXTextBox.Text, _upperLeftPointYTextBox.Text, _lowerRightPointXTextBox.Text, _lowerRightPointYTextBox.Text);
        }

        // Is OK button enable
        private bool IsOkButtonEnable(string upperLeftPointXText, string upperLeftPointYText, string lowerRightPointXText, string lowerRightPointYText)
        {
            if (!(float.TryParse(upperLeftPointXText, out _upperLeftPointX)) || !(float.TryParse(upperLeftPointYText, out _upperLeftPointY)) || !(float.TryParse(lowerRightPointXText, out _lowerRightPointX)) || !(float.TryParse(lowerRightPointYText, out _lowerRightPointY)))
                return false;

            _upperLeftPointX *= _rateX;
            _upperLeftPointY *= _rateY;
            _lowerRightPointX *= _rateX;
            _lowerRightPointY *= _rateY;

            if (_upperLeftPointX <= _lowerRightPointX && _upperLeftPointY <= _lowerRightPointY)
            {
                if (_upperLeftPointX >= 0 && _upperLeftPointX <= POINT_X_MAX && _lowerRightPointX >= 0 && _lowerRightPointX <= POINT_X_MAX)
                {
                    if (_upperLeftPointY >= 0 && _upperLeftPointY <= POINT_Y_MAX && _lowerRightPointY >= 0 && _lowerRightPointY <= POINT_Y_MAX)
                        return true;
                }
            }
            return false;
        }
    }
}
