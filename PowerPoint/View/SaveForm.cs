using PowerPoint.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPoint.View
{
    public partial class SaveForm : Form
    {
        private PowerPointModel _model;
        public SaveForm(PowerPointModel model)
        {
            _model = model;
            InitializeComponent();
        }

        // "Save" button click event
        private void ClickSaveButton(object sender, EventArgs e)
        {
            _model.Save();
        }

        // "Cancel" button click event
        private void ClickCancelButton(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
