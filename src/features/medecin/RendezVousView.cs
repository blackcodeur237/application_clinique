src\features\appointments\RendezVousView.cs
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyClinic_1._0.src.features.appointments
{
    public partial class RendezVousView : UserControl
    {
        private Panel topPanel;
        private DateTimePicker dpDate;
        private Button btnFilter;
        private Button btnNew;
        private DataGridView grid;

        public RendezVousView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(250, 250, 250);

            topPanel = new Panel();
            topPanel.Dock = DockStyle.Top;
            topPanel.Height = 48;
            topPanel.Padding = new Padding(8);
            topPanel.BackColor = Color.WhiteSmoke;
            this.Controls.Add(topPanel);

            dpDate = new DateTimePicker { Format = DateTimePickerFormat.Short, Width = 120, Left = 8 };
            btnFilter = new Button { Text = "Filtrer", Width = 80, Left = 136, BackColor = Color.FromArgb(33, 150, 243), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnNew = new Button { Text = "Nouveau RDV", Width = 120, Left = 228, BackColor = Color.Green, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };

            btnFilter.Click += (s, e) => MessageBox.Show($"Filtrer pour le {dpDate.Value:d}");
            btnNew.Click += (s, e) => MessageBox.Show("Créer un nouveau rendez?vous (à implémenter)");

            topPanel.Controls.Add(dpDate);
            topPanel.Controls.Add(btnFilter);
            topPanel.Controls.Add(btnNew);

            grid = new DataGridView();
            grid.Dock = DockStyle.Fill;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = Color.White;

            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Visible = false });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Date", HeaderText = "Date" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Heure", HeaderText = "Heure" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Patient", HeaderText = "Patient" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Praticien", HeaderText = "Praticien" });

            this.Controls.Add(grid);

            this.Load += RendezVousView_Load;

            this.ResumeLayout(false);
        }

        private void RendezVousView_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            // Données d'exemple — remplacer par chargement réel
            grid.Rows.Clear();
            grid.Rows.Add("1", "2026-05-06", "09:00", "Dupont Marie", "Dr. Durand");
            grid.Rows.Add("2", "2026-05-06", "10:30", "Martin Paul", "Dr. Lefevre");
            grid.Rows.Add("3", "2026-05-07", "14:00", "Nguyen Linh", "Dr. Durand");
        }
    }
}