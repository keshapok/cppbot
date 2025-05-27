using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;

namespace RFBot
{
    public partial class MainForm : Form
    {
        private bool _botActive = false;
        private readonly Rectangle _gameRect = Screen.PrimaryScreen.Bounds;

        public MainForm()
        {
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
                byte[] frame = ScreenCapture.Capture(_gameRect.Width, _gameRect.Height);
                int[] results = new int[20]; // x, y, w, h × 5 мобов

                int mobCount = MobDetectorInterop.DetectMobs(frame, _gameRect.Width, _gameRect.Height, results, results.Length);

                if (_botActive && mobCount > 0)
                    AttackMob(results[0], results[1]);

                await Task.Delay(10); // ~100 FPS
            }
        }

        private void AttackMob(int x, int y)
        {
            Win32.SetCursorPos(x + _gameRect.X + 10, y + _gameRect.Y + 10);
            Win32.PressKey(Win32.VirtualKeyCodes.VK_SPACE);
        }
    }
}
