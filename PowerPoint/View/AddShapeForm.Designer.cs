
namespace PowerPoint.View
{
    partial class AddShapeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._upperLeftPointXLabel = new System.Windows.Forms.Label();
            this._upperLeftPointXTextBox = new System.Windows.Forms.TextBox();
            this._upperLeftPointYTextBox = new System.Windows.Forms.TextBox();
            this._upperLeftPointYLabel = new System.Windows.Forms.Label();
            this._lowerRightPointXTextBox = new System.Windows.Forms.TextBox();
            this._lowerRightPointXLabel = new System.Windows.Forms.Label();
            this._lowerRightPointYTextBox = new System.Windows.Forms.TextBox();
            this._lowerRightPointYLabel = new System.Windows.Forms.Label();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _upperLeftPointXLabel
            // 
            this._upperLeftPointXLabel.AutoSize = true;
            this._upperLeftPointXLabel.Location = new System.Drawing.Point(26, 24);
            this._upperLeftPointXLabel.Name = "_upperLeftPointXLabel";
            this._upperLeftPointXLabel.Size = new System.Drawing.Size(79, 12);
            this._upperLeftPointXLabel.TabIndex = 0;
            this._upperLeftPointXLabel.Text = "左上角 X 座標";
            // 
            // _upperLeftPointXTextBox
            // 
            this._upperLeftPointXTextBox.Location = new System.Drawing.Point(28, 51);
            this._upperLeftPointXTextBox.Name = "_upperLeftPointXTextBox";
            this._upperLeftPointXTextBox.Size = new System.Drawing.Size(77, 22);
            this._upperLeftPointXTextBox.TabIndex = 1;
            this._upperLeftPointXTextBox.TextChanged += new System.EventHandler(this.CheckTextChanged);
            // 
            // _upperLeftPointYTextBox
            // 
            this._upperLeftPointYTextBox.Location = new System.Drawing.Point(156, 51);
            this._upperLeftPointYTextBox.Name = "_upperLeftPointYTextBox";
            this._upperLeftPointYTextBox.Size = new System.Drawing.Size(77, 22);
            this._upperLeftPointYTextBox.TabIndex = 3;
            this._upperLeftPointYTextBox.TextChanged += new System.EventHandler(this.CheckTextChanged);
            // 
            // _upperLeftPointYLabel
            // 
            this._upperLeftPointYLabel.AutoSize = true;
            this._upperLeftPointYLabel.Location = new System.Drawing.Point(154, 24);
            this._upperLeftPointYLabel.Name = "_upperLeftPointYLabel";
            this._upperLeftPointYLabel.Size = new System.Drawing.Size(79, 12);
            this._upperLeftPointYLabel.TabIndex = 2;
            this._upperLeftPointYLabel.Text = "左上角 Y 座標";
            // 
            // _lowerRightPointXTextBox
            // 
            this._lowerRightPointXTextBox.Location = new System.Drawing.Point(28, 131);
            this._lowerRightPointXTextBox.Name = "_lowerRightPointXTextBox";
            this._lowerRightPointXTextBox.Size = new System.Drawing.Size(77, 22);
            this._lowerRightPointXTextBox.TabIndex = 5;
            this._lowerRightPointXTextBox.TextChanged += new System.EventHandler(this.CheckTextChanged);
            // 
            // _lowerRightPointXLabel
            // 
            this._lowerRightPointXLabel.AutoSize = true;
            this._lowerRightPointXLabel.Location = new System.Drawing.Point(26, 104);
            this._lowerRightPointXLabel.Name = "_lowerRightPointXLabel";
            this._lowerRightPointXLabel.Size = new System.Drawing.Size(79, 12);
            this._lowerRightPointXLabel.TabIndex = 4;
            this._lowerRightPointXLabel.Text = "右下角 X 座標";
            // 
            // _lowerRightPointYTextBox
            // 
            this._lowerRightPointYTextBox.Location = new System.Drawing.Point(156, 131);
            this._lowerRightPointYTextBox.Name = "_lowerRightPointYTextBox";
            this._lowerRightPointYTextBox.Size = new System.Drawing.Size(77, 22);
            this._lowerRightPointYTextBox.TabIndex = 7;
            this._lowerRightPointYTextBox.TextChanged += new System.EventHandler(this.CheckTextChanged);
            // 
            // _lowerRightPointYLabel
            // 
            this._lowerRightPointYLabel.AutoSize = true;
            this._lowerRightPointYLabel.Location = new System.Drawing.Point(154, 104);
            this._lowerRightPointYLabel.Name = "_lowerRightPointYLabel";
            this._lowerRightPointYLabel.Size = new System.Drawing.Size(79, 12);
            this._lowerRightPointYLabel.TabIndex = 6;
            this._lowerRightPointYLabel.Text = "右下角 Y 座標";
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(28, 184);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 8;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this.ClickOkButton);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(156, 184);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 9;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.ClickCancelButton);
            // 
            // AddShapeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 225);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._lowerRightPointYTextBox);
            this.Controls.Add(this._lowerRightPointYLabel);
            this.Controls.Add(this._lowerRightPointXTextBox);
            this.Controls.Add(this._lowerRightPointXLabel);
            this.Controls.Add(this._upperLeftPointYTextBox);
            this.Controls.Add(this._upperLeftPointYLabel);
            this.Controls.Add(this._upperLeftPointXTextBox);
            this.Controls.Add(this._upperLeftPointXLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddShapeForm";
            this.Text = "輸入座標新增圖形";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _upperLeftPointXLabel;
        private System.Windows.Forms.TextBox _upperLeftPointXTextBox;
        private System.Windows.Forms.TextBox _upperLeftPointYTextBox;
        private System.Windows.Forms.Label _upperLeftPointYLabel;
        private System.Windows.Forms.TextBox _lowerRightPointXTextBox;
        private System.Windows.Forms.Label _lowerRightPointXLabel;
        private System.Windows.Forms.TextBox _lowerRightPointYTextBox;
        private System.Windows.Forms.Label _lowerRightPointYLabel;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
    }
}