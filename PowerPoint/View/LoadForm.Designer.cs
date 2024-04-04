
namespace PowerPoint.View
{
    partial class LoadForm
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
            this._cancelButton = new System.Windows.Forms.Button();
            this._loadLabel = new System.Windows.Forms.Label();
            this._loadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(94, 54);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(56, 18);
            this._cancelButton.TabIndex = 5;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.ClickCancelButton);
            // 
            // _loadLabel
            // 
            this._loadLabel.AutoSize = true;
            this._loadLabel.Location = new System.Drawing.Point(44, 26);
            this._loadLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._loadLabel.Name = "_loadLabel";
            this._loadLabel.Size = new System.Drawing.Size(89, 12);
            this._loadLabel.TabIndex = 4;
            this._loadLabel.Text = "是否確定載入？";
            // 
            // _loadButton
            // 
            this._loadButton.Location = new System.Drawing.Point(20, 54);
            this._loadButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._loadButton.Name = "_loadButton";
            this._loadButton.Size = new System.Drawing.Size(56, 18);
            this._loadButton.TabIndex = 3;
            this._loadButton.Text = "Load";
            this._loadButton.UseVisualStyleBackColor = true;
            this._loadButton.Click += new System.EventHandler(this.ClickLoadButton);
            // 
            // LoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 89);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._loadLabel);
            this.Controls.Add(this._loadButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "LoadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label _loadLabel;
        private System.Windows.Forms.Button _loadButton;
    }
}