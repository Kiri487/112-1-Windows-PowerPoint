namespace PowerPoint
{
    partial class PowerPointForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PowerPointForm));
            this._shapeDataGridView = new System.Windows.Forms.DataGridView();
            this._deleteShapeColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this._shapeTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._shapeDataColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._chooseShapeComboBox = new System.Windows.Forms.ComboBox();
            this._addShapeButton = new System.Windows.Forms.Button();
            this._shapeDataGroupBox = new System.Windows.Forms.GroupBox();
            this._slideButton1 = new System.Windows.Forms.Button();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._instructionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._shapeToolStrip = new System.Windows.Forms.ToolStrip();
            this._lineButton = new PowerPoint.DataBindingsToolStripButton();
            this._rectangleButton = new PowerPoint.DataBindingsToolStripButton();
            this._circleButton = new PowerPoint.DataBindingsToolStripButton();
            this._arrowButton = new PowerPoint.DataBindingsToolStripButton();
            this._undoButton = new PowerPoint.DataBindingsToolStripButton();
            this._redoButton = new PowerPoint.DataBindingsToolStripButton();
            this._addNewPageButton = new PowerPoint.DataBindingsToolStripButton();
            this._splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._splitContainer2 = new System.Windows.Forms.SplitContainer();
            this._canvas = new PowerPoint.DoubleBufferedPanel();
            this._saveButton = new PowerPoint.DataBindingsToolStripButton();
            this._loadButton = new PowerPoint.DataBindingsToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this._shapeDataGridView)).BeginInit();
            this._shapeDataGroupBox.SuspendLayout();
            this._menuStrip.SuspendLayout();
            this._shapeToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).BeginInit();
            this._splitContainer1.Panel1.SuspendLayout();
            this._splitContainer1.Panel2.SuspendLayout();
            this._splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer2)).BeginInit();
            this._splitContainer2.Panel1.SuspendLayout();
            this._splitContainer2.Panel2.SuspendLayout();
            this._splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _shapeDataGridView
            // 
            this._shapeDataGridView.AllowUserToAddRows = false;
            this._shapeDataGridView.AllowUserToDeleteRows = false;
            this._shapeDataGridView.AllowUserToResizeColumns = false;
            this._shapeDataGridView.AllowUserToResizeRows = false;
            this._shapeDataGridView.ColumnHeadersHeight = 30;
            this._shapeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this._shapeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._deleteShapeColumn,
            this._shapeTypeColumn,
            this._shapeDataColumn});
            this._shapeDataGridView.Cursor = System.Windows.Forms.Cursors.Default;
            this._shapeDataGridView.Location = new System.Drawing.Point(11, 91);
            this._shapeDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._shapeDataGridView.Name = "_shapeDataGridView";
            this._shapeDataGridView.ReadOnly = true;
            this._shapeDataGridView.RowHeadersVisible = false;
            this._shapeDataGridView.RowHeadersWidth = 40;
            this._shapeDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this._shapeDataGridView.RowTemplate.Height = 27;
            this._shapeDataGridView.Size = new System.Drawing.Size(400, 375);
            this._shapeDataGridView.TabIndex = 0;
            this._shapeDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickShapeDataGridViewDeleteButton);
            // 
            // _deleteShapeColumn
            // 
            this._deleteShapeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this._deleteShapeColumn.HeaderText = "刪除";
            this._deleteShapeColumn.MinimumWidth = 60;
            this._deleteShapeColumn.Name = "_deleteShapeColumn";
            this._deleteShapeColumn.ReadOnly = true;
            this._deleteShapeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._deleteShapeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._deleteShapeColumn.Text = "刪除";
            this._deleteShapeColumn.ToolTipText = "刪除";
            this._deleteShapeColumn.UseColumnTextForButtonValue = true;
            this._deleteShapeColumn.Width = 60;
            // 
            // _shapeTypeColumn
            // 
            this._shapeTypeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this._shapeTypeColumn.HeaderText = "形狀";
            this._shapeTypeColumn.MinimumWidth = 60;
            this._shapeTypeColumn.Name = "_shapeTypeColumn";
            this._shapeTypeColumn.ReadOnly = true;
            this._shapeTypeColumn.Width = 60;
            // 
            // _shapeDataColumn
            // 
            this._shapeDataColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._shapeDataColumn.HeaderText = "資訊";
            this._shapeDataColumn.MinimumWidth = 100;
            this._shapeDataColumn.Name = "_shapeDataColumn";
            this._shapeDataColumn.ReadOnly = true;
            // 
            // _chooseShapeComboBox
            // 
            this._chooseShapeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._chooseShapeComboBox.FormattingEnabled = true;
            this._chooseShapeComboBox.Items.AddRange(new object[] {
            "線",
            "矩形",
            "橢圓"});
            this._chooseShapeComboBox.Location = new System.Drawing.Point(105, 42);
            this._chooseShapeComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._chooseShapeComboBox.Name = "_chooseShapeComboBox";
            this._chooseShapeComboBox.Size = new System.Drawing.Size(197, 25);
            this._chooseShapeComboBox.TabIndex = 1;
            this._chooseShapeComboBox.DropDownClosed += new System.EventHandler(this.CloseComboBoxDropDown);
            // 
            // _addShapeButton
            // 
            this._addShapeButton.Location = new System.Drawing.Point(11, 29);
            this._addShapeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._addShapeButton.Name = "_addShapeButton";
            this._addShapeButton.Size = new System.Drawing.Size(73, 56);
            this._addShapeButton.TabIndex = 1;
            this._addShapeButton.Text = "新增";
            this._addShapeButton.UseVisualStyleBackColor = true;
            this._addShapeButton.Click += new System.EventHandler(this.ClickAddShapeButton);
            // 
            // _shapeDataGroupBox
            // 
            this._shapeDataGroupBox.Controls.Add(this._addShapeButton);
            this._shapeDataGroupBox.Controls.Add(this._shapeDataGridView);
            this._shapeDataGroupBox.Controls.Add(this._chooseShapeComboBox);
            this._shapeDataGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._shapeDataGroupBox.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._shapeDataGroupBox.Location = new System.Drawing.Point(0, 0);
            this._shapeDataGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._shapeDataGroupBox.Name = "_shapeDataGroupBox";
            this._shapeDataGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._shapeDataGroupBox.Size = new System.Drawing.Size(320, 633);
            this._shapeDataGroupBox.TabIndex = 0;
            this._shapeDataGroupBox.TabStop = false;
            this._shapeDataGroupBox.Text = "資料顯示";
            // 
            // _slideButton1
            // 
            this._slideButton1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._slideButton1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this._slideButton1.Location = new System.Drawing.Point(11, 10);
            this._slideButton1.Margin = new System.Windows.Forms.Padding(4);
            this._slideButton1.Name = "_slideButton1";
            this._slideButton1.Size = new System.Drawing.Size(213, 112);
            this._slideButton1.TabIndex = 4;
            this._slideButton1.Text = "page1";
            this._slideButton1.UseVisualStyleBackColor = false;
            this._slideButton1.Click += new System.EventHandler(this.ClickSlideButton);
            // 
            // _menuStrip
            // 
            this._menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._instructionToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this._menuStrip.Size = new System.Drawing.Size(1284, 24);
            this._menuStrip.TabIndex = 6;
            this._menuStrip.Text = "menuStrip1";
            // 
            // _instructionToolStripMenuItem
            // 
            this._instructionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem});
            this._instructionToolStripMenuItem.Name = "_instructionToolStripMenuItem";
            this._instructionToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this._instructionToolStripMenuItem.Text = "說明";
            // 
            // _aboutToolStripMenuItem
            // 
            this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
            this._aboutToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this._aboutToolStripMenuItem.Text = "關於";
            // 
            // _shapeToolStrip
            // 
            this._shapeToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._shapeToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lineButton,
            this._rectangleButton,
            this._circleButton,
            this._arrowButton,
            this._undoButton,
            this._redoButton,
            this._addNewPageButton,
            this._saveButton,
            this._loadButton});
            this._shapeToolStrip.Location = new System.Drawing.Point(0, 24);
            this._shapeToolStrip.Name = "_shapeToolStrip";
            this._shapeToolStrip.Size = new System.Drawing.Size(1284, 27);
            this._shapeToolStrip.TabIndex = 7;
            this._shapeToolStrip.Text = "toolStrip1";
            // 
            // _lineButton
            // 
            this._lineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._lineButton.Image = ((System.Drawing.Image)(resources.GetObject("_lineButton.Image")));
            this._lineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._lineButton.Name = "_lineButton";
            this._lineButton.Size = new System.Drawing.Size(24, 24);
            this._lineButton.Text = "畫線";
            this._lineButton.Click += new System.EventHandler(this.ClickLineButton);
            // 
            // _rectangleButton
            // 
            this._rectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._rectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("_rectangleButton.Image")));
            this._rectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._rectangleButton.Name = "_rectangleButton";
            this._rectangleButton.Size = new System.Drawing.Size(24, 24);
            this._rectangleButton.Text = "畫矩形";
            this._rectangleButton.Click += new System.EventHandler(this.ClickRectangleButton);
            // 
            // _circleButton
            // 
            this._circleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._circleButton.Image = ((System.Drawing.Image)(resources.GetObject("_circleButton.Image")));
            this._circleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._circleButton.Name = "_circleButton";
            this._circleButton.Size = new System.Drawing.Size(24, 24);
            this._circleButton.Text = "畫圓";
            this._circleButton.Click += new System.EventHandler(this.ClickCircleButton);
            // 
            // _arrowButton
            // 
            this._arrowButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._arrowButton.Image = ((System.Drawing.Image)(resources.GetObject("_arrowButton.Image")));
            this._arrowButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._arrowButton.Name = "_arrowButton";
            this._arrowButton.Size = new System.Drawing.Size(24, 24);
            this._arrowButton.Text = "箭頭";
            this._arrowButton.Click += new System.EventHandler(this.ClickArrowButton);
            // 
            // _undoButton
            // 
            this._undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._undoButton.Image = ((System.Drawing.Image)(resources.GetObject("_undoButton.Image")));
            this._undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._undoButton.Name = "_undoButton";
            this._undoButton.Size = new System.Drawing.Size(24, 24);
            this._undoButton.Text = "Undo";
            this._undoButton.Click += new System.EventHandler(this.ClickUndoButton);
            // 
            // _redoButton
            // 
            this._redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._redoButton.Image = ((System.Drawing.Image)(resources.GetObject("_redoButton.Image")));
            this._redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._redoButton.Name = "_redoButton";
            this._redoButton.Size = new System.Drawing.Size(24, 24);
            this._redoButton.Text = "Redo";
            this._redoButton.Click += new System.EventHandler(this.ClickRedoButton);
            // 
            // _addNewPageButton
            // 
            this._addNewPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._addNewPageButton.Image = ((System.Drawing.Image)(resources.GetObject("_addNewPageButton.Image")));
            this._addNewPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._addNewPageButton.Name = "_addNewPageButton";
            this._addNewPageButton.Size = new System.Drawing.Size(24, 24);
            this._addNewPageButton.Text = "新增頁面";
            this._addNewPageButton.Click += new System.EventHandler(this.ClickAddNewPageButton);
            // 
            // _splitContainer1
            // 
            this._splitContainer1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this._splitContainer1.CausesValidation = false;
            this._splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._splitContainer1.Location = new System.Drawing.Point(0, 51);
            this._splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._splitContainer1.Name = "_splitContainer1";
            // 
            // _splitContainer1.Panel1
            // 
            this._splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this._splitContainer1.Panel1.Controls.Add(this._slideButton1);
            // 
            // _splitContainer1.Panel2
            // 
            this._splitContainer1.Panel2.Controls.Add(this._splitContainer2);
            this._splitContainer1.Size = new System.Drawing.Size(1284, 650);
            this._splitContainer1.SplitterDistance = 163;
            this._splitContainer1.TabIndex = 9;
            this._splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.HandleSplit1Move);
            // 
            // _splitContainer2
            // 
            this._splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._splitContainer2.Location = new System.Drawing.Point(0, 0);
            this._splitContainer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._splitContainer2.Name = "_splitContainer2";
            // 
            // _splitContainer2.Panel1
            // 
            this._splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this._splitContainer2.Panel1.Controls.Add(this._canvas);
            // 
            // _splitContainer2.Panel2
            // 
            this._splitContainer2.Panel2.AutoScroll = true;
            this._splitContainer2.Panel2.AutoScrollMinSize = new System.Drawing.Size(320, 0);
            this._splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this._splitContainer2.Panel2.Controls.Add(this._shapeDataGroupBox);
            this._splitContainer2.Panel2MinSize = 300;
            this._splitContainer2.Size = new System.Drawing.Size(1117, 650);
            this._splitContainer2.SplitterDistance = 807;
            this._splitContainer2.SplitterWidth = 7;
            this._splitContainer2.TabIndex = 0;
            this._splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.HandleSplit2Move);
            // 
            // _canvas
            // 
            this._canvas.BackColor = System.Drawing.SystemColors.Window;
            this._canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._canvas.Location = new System.Drawing.Point(11, 62);
            this._canvas.Margin = new System.Windows.Forms.Padding(0);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(1066, 562);
            this._canvas.TabIndex = 8;
            // 
            // _saveButton
            // 
            this._saveButton.BackColor = System.Drawing.SystemColors.Control;
            this._saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._saveButton.Image = ((System.Drawing.Image)(resources.GetObject("_saveButton.Image")));
            this._saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(41, 24);
            this._saveButton.Text = "SAVE";
            this._saveButton.Click += new System.EventHandler(this.ClickSaveButton);
            // 
            // _loadButton
            // 
            this._loadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._loadButton.Image = ((System.Drawing.Image)(resources.GetObject("_loadButton.Image")));
            this._loadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._loadButton.Name = "_loadButton";
            this._loadButton.Size = new System.Drawing.Size(44, 24);
            this._loadButton.Text = "LOAD";
            this._loadButton.Click += new System.EventHandler(this.ClickLoadButton);
            // 
            // PowerPointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 701);
            this.Controls.Add(this._splitContainer1);
            this.Controls.Add(this._shapeToolStrip);
            this.Controls.Add(this._menuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this._menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PowerPointForm";
            this.Text = "PowerPoint";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HandleKeyDown);
            this.Resize += new System.EventHandler(this.HandleWindowsResize);
            ((System.ComponentModel.ISupportInitialize)(this._shapeDataGridView)).EndInit();
            this._shapeDataGroupBox.ResumeLayout(false);
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this._shapeToolStrip.ResumeLayout(false);
            this._shapeToolStrip.PerformLayout();
            this._splitContainer1.Panel1.ResumeLayout(false);
            this._splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).EndInit();
            this._splitContainer1.ResumeLayout(false);
            this._splitContainer2.Panel1.ResumeLayout(false);
            this._splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer2)).EndInit();
            this._splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _shapeDataGridView;
        private System.Windows.Forms.ComboBox _chooseShapeComboBox;
        private System.Windows.Forms.Button _addShapeButton;
        private System.Windows.Forms.GroupBox _shapeDataGroupBox;
        private System.Windows.Forms.Button _slideButton1;
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _instructionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutToolStripMenuItem;
        private System.Windows.Forms.DataGridViewButtonColumn _deleteShapeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shapeTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shapeDataColumn;
        private System.Windows.Forms.ToolStrip _shapeToolStrip;
        private DoubleBufferedPanel _canvas;
        private DataBindingsToolStripButton _lineButton;
        private DataBindingsToolStripButton _rectangleButton;
        private DataBindingsToolStripButton _circleButton;
        private DataBindingsToolStripButton _arrowButton;
        private System.Windows.Forms.SplitContainer _splitContainer1;
        private System.Windows.Forms.SplitContainer _splitContainer2;
        private DataBindingsToolStripButton _undoButton;
        private DataBindingsToolStripButton _redoButton;
        private DataBindingsToolStripButton _addNewPageButton;
        private DataBindingsToolStripButton _saveButton;
        private DataBindingsToolStripButton _loadButton;
    }
}