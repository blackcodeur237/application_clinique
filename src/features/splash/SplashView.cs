using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyClinic_1._0.src.features.splash
{
    public partial class SplashView : Form
    {
        private Timer _timer;
        private ProgressBar progressBar;
        private Label lblAppName;
        private Panel bottomPanel;

        public int DisplaySeconds { get; set; } = 2;

        public SplashView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form
            this.ClientSize = new Size(480, 280);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // App name label (docké en haut)
            lblAppName = new Label();
            lblAppName.Text = "MyClinic";
            lblAppName.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblAppName.AutoSize = false;
            lblAppName.Height = 80;
            lblAppName.Dock = DockStyle.Top;
            lblAppName.ForeColor = Color.FromArgb(33, 150, 243);
            lblAppName.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblAppName);

            // Panel du bas pour contenir la progress bar (permet marges sans utiliser ClientSize)
            bottomPanel = new Panel();
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Height = 60;
            bottomPanel.Padding = new Padding(40, 10, 40, 10);
            bottomPanel.BackColor = Color.Transparent;
            this.Controls.Add(bottomPanel);

            // Progress bar (remplira le panel avec padding)
            progressBar = new ProgressBar();
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Dock = DockStyle.Fill;
            progressBar.Value = 0;
            bottomPanel.Controls.Add(progressBar);

            // Timer (créé mais démarré dans Load)
            _timer = new Timer();
            _timer.Interval = 100; // 100ms tick for smooth progress
            _timer.Tick += Timer_Tick;

            this.Load += SplashView_Load;

            this.ResumeLayout(false);
        }

        private void SplashView_Load(object sender, EventArgs e)
        {
            // Ne pas lancer de logique design-time dans le concepteur
            if (this.DesignMode) return;

            progressBar.Value = 0;
            _timer.Start();
        }

        private int _ticks = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            _ticks++;
            var totalTicks = (DisplaySeconds * 1000) / _timer.Interval;
            var pct = Math.Min(100, (int)((_ticks / (double)totalTicks) * 100));
            progressBar.Value = pct;

            if (pct >= 100)
            {
                _timer.Stop();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}