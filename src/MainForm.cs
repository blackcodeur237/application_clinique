using System;
using System.Drawing;
using System.Windows.Forms;
using MyClinic_1._0.src.features.login;

namespace MyClinic_1._0.src
{
    public class MainForm : Form
    {
        private MenuStrip menu;
        private ToolStripMenuItem fileMenu;
        private Panel contentPanel;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Text = "MyClinic";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1000, 680);

            menu = new MenuStrip();
            fileMenu = new ToolStripMenuItem("Fichier");
            menu.Items.Add(fileMenu);
            this.MainMenuStrip = menu;
            this.Controls.Add(menu);

            contentPanel = new Panel { Dock = DockStyle.Fill, Location = new Point(0, menu.Height), BackColor = Color.FromArgb(245, 245, 245) };
            this.Controls.Add(contentPanel);

            this.Load += MainForm_Load;
            contentPanel.Resize += ContentPanel_Resize;
            this.ResumeLayout();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Affiche la vue de login au démarrage
            var login = new LoginView();
            login.LoginRequested += Login_LoginRequested;
            SetContent(login);
        }

        private void ContentPanel_Resize(object sender, EventArgs e)
        {
            // recaler le contrôle centré lors du redimensionnement
            if (contentPanel.Controls.Count == 0) return;
            var view = contentPanel.Controls[0];
            view.Location = new Point(Math.Max(0, (contentPanel.ClientSize.Width - view.Width) / 2),
                                      Math.Max(0, (contentPanel.ClientSize.Height - view.Height) / 2));
        }

        public void SetContent(Control view)
        {
            contentPanel.Controls.Clear();
            view.Dock = DockStyle.None;
            contentPanel.Controls.Add(view);
            // centrer
            view.Location = new Point(Math.Max(0, (contentPanel.ClientSize.Width - view.Width) / 2),
                                      Math.Max(0, (contentPanel.ClientSize.Height - view.Height) / 2));
        }

        private void Login_LoginRequested(string user, string password)
        {
            // Remplacer par appel réel à AuthService
            MessageBox.Show($"Tentative de connexion: {user}", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}