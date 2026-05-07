using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class MainForm : Form
    {
        string connectionString = @"Data Source=X\SQLEXPRESS;Initial Catalog=GymDB;Integrated Security=True;TrustServerCertificate=True";

        public MainForm()
        {
            InitializeComponent();
            SetupUI();
            LoadStats();
        }

        private void SetupUI()
        {
            this.Text = "Gym Management System";
            this.Size = new Size(700, 680);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(245, 245, 250);

            Panel topBar = new Panel();
            topBar.Dock = DockStyle.Top;
            topBar.Height = 90;
            topBar.BackColor = Color.FromArgb(35, 35, 55);
            this.Controls.Add(topBar);

            Label title = new Label();
            title.Text = "Gym Management System";
            title.Font = new Font("Segoe UI", 25, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(0, 200, 160);
            title.Location = new Point(30, 25);
            title.AutoSize = true;
            topBar.Controls.Add(title);

            // Stats Cards
            int cardW = 140, cardH = 60, cardY = 110, gap = 15, startX = 35;
            
            Panel card1 = MakeStatCard("Members", startX, cardY, cardW, cardH, out Label lblMembers);
            Panel card2 = MakeStatCard("Trainers", startX + (cardW + gap), cardY, cardW, cardH, out Label lblTrainers);
            Panel card3 = MakeStatCard("Subscriptions", startX + (cardW + gap) * 2, cardY, cardW, cardH, out Label lblSubs);
            Panel card4 = MakeStatCard("Machines", startX + (cardW + gap) * 3, cardY, cardW, cardH, out Label lblMachines);

            this.Controls.Add(card1); this.Controls.Add(card2); this.Controls.Add(card3); this.Controls.Add(card4);

            // Navigation Buttons
            int startY = 210;
            int step = 68;

            Button btnMembers = MakeButton("Manage Members", startY);
            Button btnTrainers = MakeButton("Manage Trainers", startY + step);
            Button btnSubscriptions = MakeButton("Manage Subscriptions", startY + step * 2);
            Button btnMachines = MakeButton("Manage Machines", startY + step * 3);
            Button btnSports = MakeButton("Manage Sports", startY + step * 4);
            Button btnEmployees = MakeButton("Manage Employees", startY + step * 5);

            btnMembers.Click += (s, e) => new MembersForm().Show();
            btnTrainers.Click += (s, e) => new TrainersForm().Show();
            btnSubscriptions.Click += (s, e) => new SubscriptionsForm().Show();
            btnMachines.Click += (s, e) => new MachinesForm().Show();
            btnSports.Click += (s, e) => new SportsForm().Show();
            btnEmployees.Click += (s, e) => new EmployeesForm().Show();

            this.Controls.Add(btnMembers);
            this.Controls.Add(btnTrainers);
            this.Controls.Add(btnSubscriptions);
            this.Controls.Add(btnMachines);
            this.Controls.Add(btnSports);
            this.Controls.Add(btnEmployees);
        }

        private Panel MakeStatCard(string title, int x, int y, int w, int h, out Label valueLabel)
        {
            Panel card = new Panel();
            card.Size = new Size(w, h);
            card.Location = new Point(x, y);
            card.BackColor = Color.White;

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 9);
            lblTitle.ForeColor = Color.FromArgb(140, 140, 160);
            lblTitle.Location = new Point(10, 8);
            lblTitle.AutoSize = true;
            card.Controls.Add(lblTitle);

            valueLabel = new Label();
            valueLabel.Text = "0";
            valueLabel.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            valueLabel.ForeColor = Color.FromArgb(35, 35, 55);
            valueLabel.Location = new Point(10, 25);
            valueLabel.AutoSize = true;
            valueLabel.Name = "lbl" + title.Replace(" ", "");
            card.Controls.Add(valueLabel);

            return card;
        }

        private void LoadStats()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    GetCount(con, "SELECT COUNT(*) FROM Member", "lblMembers");
                    GetCount(con, "SELECT COUNT(*) FROM Trainer", "lblTrainers");
                    GetCount(con, "SELECT COUNT(*) FROM Subscription", "lblSubscriptions");
                    GetCount(con, "SELECT COUNT(*) FROM Machine", "lblMachines");
                }
            }
            catch { }
        }

        private void GetCount(SqlConnection con, string query, string controlName)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            int count = (int)cmd.ExecuteScalar();
            foreach (Control c in this.Controls)
            {
                if (c is Panel panel)
                    foreach (Control inner in panel.Controls)
                        if (inner.Name == controlName) inner.Text = count.ToString();
            }
        }

        private Button MakeButton(string text, int top)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Size = new Size(460, 56);
            btn.Location = new Point(120, top);
            btn.Font = new Font("Segoe UI", 13);
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.White;
            btn.ForeColor = Color.FromArgb(40, 40, 60);
            btn.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 210);
            btn.Cursor = Cursors.Hand;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(20, 0, 0, 0);
            btn.MouseEnter += (s, e) => { btn.BackColor = Color.FromArgb(35, 35, 55); btn.ForeColor = Color.FromArgb(0, 200, 160); btn.FlatAppearance.BorderColor = Color.FromArgb(35, 35, 55); };
            btn.MouseLeave += (s, e) => { btn.BackColor = Color.White; btn.ForeColor = Color.FromArgb(40, 40, 60); btn.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 210); };
            return btn;
        }
    }
}