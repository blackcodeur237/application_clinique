src\features\dashboard\DashboardView.cs
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyClinic_1._0.src.features.dashboard
{
    public partial class DashboardView : UserControl
    {
        private TableLayoutPanel layout;
        private Panel cardPatients;
        private Panel cardAppointments;
        private Panel cardToday;
        private Label lblPatientsCount;
        private Label lblAppointmentsCount;
        private Label lblTodayCount;

        public DashboardView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(245, 245, 245);

            layout = new TableLayoutPanel();
            layout.Dock = DockStyle.Fill;
            layout.ColumnCount = 3;
            layout.RowCount = 1;
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            layout.Padding = new Padding(20);
            this.Controls.Add(layout);

            // Card factory
            cardPatients = CreateCard("Patients", out lblPatientsCount);
            cardAppointments = CreateCard("Rendez?vous", out lblAppointmentsCount);
            cardToday = CreateCard("Aujourd'hui", out lblTodayCount);

            layout.Controls.Add(cardPatients, 0, 0);
            layout.Controls.Add(cardAppointments, 1, 0);
            layout.Controls.Add(cardToday, 2, 0);

            this.Load += DashboardView_Load;

            this.ResumeLayout(false);
        }

        private Panel CreateCard(string title, out Label lblCount)
        {
            var panel = new Panel();
            panel.Margin = new Padding(10);
            panel.BackColor = Color.White;
            panel.Padding = new Padding(12);
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Dock = DockStyle.Fill;

            var lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblTitle.ForeColor = Color.DimGray;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(12, 12);

            lblCount = new Label();
            lblCount.Text = "0";
            lblCount.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblCount.ForeColor = Color.FromArgb(33, 150, 243);
            lblCount.AutoSize = false;
            lblCount.TextAlign = ContentAlignment.MiddleLeft;
            lblCount.Dock = DockStyle.Bottom;
            lblCount.Height = 60;

            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblCount);

            return panel;
        }

        private void DashboardView_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            // Chargement d'exemple — remplacer par appels réels
            lblPatientsCount.Text = "128";
            lblAppointmentsCount.Text = "34";
            lblTodayCount.Text = "7";
        }
    }
}