using System;
using System.Windows.Forms;

namespace BaiPiaoOcrOnnxCs
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormOcr());
        }
    }
}
