using PowerPoint.Model;
using System;
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
            Task.Run(() =>
            {
                _model.Upload();
            });
            this.Close();
        }

        // "Cancel" button click event
        private void ClickCancelButton(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
