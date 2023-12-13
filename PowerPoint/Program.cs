using PowerPoint.Model;
using PowerPoint.View;
using System;
using System.Windows.Forms;

namespace PowerPoint
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PowerPointModel model = new PowerPointModel();
            PowerPointPresentationModel presentationModel = new PowerPointPresentationModel(model);
            Application.Run(new PowerPointForm(model, presentationModel));
        }
    }
}