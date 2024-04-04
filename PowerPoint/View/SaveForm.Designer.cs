
namespace PowerPoint.View
{
    partial class SaveForm
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
            this._saveButton = new System.Windows.Forms.Button();
            this._saveLabel = new System.Windows.Forms.Label();
            this._cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _saveButton
            // 
            this._saveButton.Location = new System.Drawing.Point(20, 54);
            this._saveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(56, 18);
            this._saveButton.TabIndex = 0;
            this._saveButton.Text = "Save";
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this.ClickSaveButton);
            // 
            // _saveLabel
            // 
            this._saveLabel.AutoSize = true;
            this._saveLabel.Location = new System.Drawing.Point(44, 26);
            this._saveLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._saveLabel.Name = "_saveLabel";
            this._saveLabel.Size = new System.Drawing.Size(89, 12);
            this._saveLabel.TabIndex = 1;
            this._saveLabel.Text = "是否確定儲存？";
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(94, 54);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(56, 18);
            this._cancelButton.TabIndex = 2;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.ClickCancelButton);
            // 
            // SaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 89);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._saveLabel);
            this.Controls.Add(this._saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SaveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.Label _saveLabel;
        private System.Windows.Forms.Button _cancelButton;
    }
}