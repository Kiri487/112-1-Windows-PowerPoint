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
    public partial class LoadForm : Form
    {
        private PowerPointModel _model;
        public LoadForm(PowerPointModel model)
        {
            _model = model;
            InitializeComponent();
        }

        // "Load" button click event
        private void ClickLoadButton(object sender, EventArgs e)
        {
            _model.Load();
        }

        // "Cancel" button click event
        private void ClickCancelButton(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
