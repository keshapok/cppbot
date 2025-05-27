using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFBot
{
    public partial class MainForm : Form
    {
        private static MainForm? Instance;
        private bool _botActive = false;

        public MainForm()
        {
            Instance = this;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Width = 400;
            Height = 200;
            Text = "RF Bot";
        }

        public async Task RunAsync()
        {
            while (true)
            {
                // Тут будет логика бота
                await Task.Delay(10);
            }
        }
    }
}
