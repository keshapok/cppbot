using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFBot
{
    public partial class MainForm : Form
    {
        public static MainForm Instance { get; private set; }

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
            KeyboardHook.Start();

            while (true)
            {
                await Task.Delay(10);
            }
        }

        public void ToggleBot()
        {
            _botActive = !_botActive;
            Console.WriteLine($"[F10] Бот: {_botActive}");
        }
    }
}
