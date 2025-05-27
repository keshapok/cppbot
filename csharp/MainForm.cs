using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFBot
{
    public partial class MainForm : Form
    {
        // Полностью безопасный nullable Singleton
        public static MainForm? Instance { get; private set; }

        public bool BotActive { get; private set; } = false;

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
                await Task.Delay(10);
            }
        }

        public void ToggleBot()
        {
            BotActive = !BotActive;
            Console.WriteLine($"[F10] Бот: {(BotActive ? "Активен" : "Неактивен")}");
        }
    }
}
