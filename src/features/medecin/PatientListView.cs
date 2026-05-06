src\features\patients\PatientListView.cs
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyClinic_1._0.src.features.patients
{
    public partial class PatientListView : UserControl
    {
        private Panel topPanel;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private DataGridView grid;

        public PatientListView()
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

            btnAdd = new Button { Text = "Ajouter", Width = 100, Left = 8, BackColor = Color.FromArgb(33, 150, 243), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnEdit = new Button { Text = "Modifier", Width = 100, Left = 116, BackColor = Color.Gray, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnDelete = new Button { Text = "Supprimer", Width = 100, Left = 224, BackColor = Color.DarkRed, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };

            btnAdd.Click += (s, e) => MessageBox.Show("Ajouter patient (à implémenter)");
            btnEdit.Click += (s, e) => MessageBox.Show("Modifier patient (à implémenter)");
            btnDelete.Click += (s, e) => MessageBox.Show("Supprimer patient (à implémenter)");

            topPanel.Controls.Add(btnAdd);
            topPanel.Controls.Add(btnEdit);
            topPanel.Controls.Add(btnDelete);

            grid = new DataGridView();
            grid.Dock = DockStyle.Fill;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = Color.White;

            // Colonnes
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Visible = false });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "LastName", HeaderText = "Nom" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "FirstName", HeaderText = "Prénom" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "BirthDate", HeaderText = "Date de naissance" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Phone", HeaderText = "Téléphone" });

            this.Controls.Add(grid);

            this.Load += PatientListView_Load;

            this.ResumeLayout(false);
        }

        private void PatientListView_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            // Données d'exemple — remplacer par chargement réel
            grid.Rows.Clear();
            grid.Rows.Add("1", "Dupont", "Marie", "1985-02-14", "06 12 34 56 78");
            grid.Rows.Add("2", "Martin", "Paul", "1990-06-03", "06 98 76 54 32");
            grid.Rows.Add("3", "Nguyen", "Linh", "1978-11-22", "06 45 67 89 01");
        }
    }
}