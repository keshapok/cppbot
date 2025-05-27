using System.Windows.Forms;
using RFBot;

namespace RFBot
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var botForm = new MainForm();
            Application.Run(botForm);
        }
    }
}
