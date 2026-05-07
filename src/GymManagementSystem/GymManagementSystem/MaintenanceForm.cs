using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class MaintenanceForm : Form
    {
        string connectionString = @"Data Source=X\SQLEXPRESS;Initial Catalog=GymDB;Integrated Security=True;TrustServerCertificate=True";
        private int machineID;
        private TextBox txtCost;
        private DateTimePicker dtpStart, dtpEnd;
        private DataGridView dgv;
        private Label lblInfo;

        public MaintenanceForm(int machineId)
        {
            InitializeComponent();
            machineID = machineId;
            SetupUI();
            LoadData();
        }

        private void SetupUI()
        {
            this.Text = "Machine Maintenance";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(245, 245, 250);

            Panel topBar = new Panel();
            topBar.Dock = DockStyle.Top;
            topBar.Height = 70;
            topBar.BackColor = Color.FromArgb(35, 35, 55);
            this.Controls.Add(topBar);

            Label title = new Label();
            title.Text = "Maintenance Records";
            title.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(0, 200, 160);
            title.Location = new Point(30, 18);
            title.AutoSize = true;
            topBar.Controls.Add(title);

            lblInfo = new Label();
            lblInfo.Text = "Machine ID: " + machineID;
            lblInfo.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblInfo.ForeColor = Color.FromArgb(80, 80, 100);
            lblInfo.Location = new Point(30, 85);
            lblInfo.AutoSize = true;
            this.Controls.Add(lblInfo);

            // Start Date
            Label lblStart = new Label();
            lblStart.Text = "Start Date";
            lblStart.Font = new Font("Segoe UI", 10);
            lblStart.ForeColor = Color.FromArgb(80, 80, 100);
            lblStart.Location = new Point(30, 120);
            lblStart.AutoSize = true;
            this.Controls.Add(lblStart);

            dtpStart = new DateTimePicker();
            dtpStart.Size = new Size(200, 26);
            dtpStart.Location = new Point(150, 117);
            dtpStart.Format = DateTimePickerFormat.Short;
            this.Controls.Add(dtpStart);

            // End Date
            Label lblEnd = new Label();
            lblEnd.Text = "End Date";
            lblEnd.Font = new Font("Segoe UI", 10);
            lblEnd.ForeColor = Color.FromArgb(80, 80, 100);
            lblEnd.Location = new Point(30, 165);
            lblEnd.AutoSize = true;
            this.Controls.Add(lblEnd);

            dtpEnd = new DateTimePicker();
            dtpEnd.Size = new Size(200, 26);
            dtpEnd.Location = new Point(150, 162);
            dtpEnd.Format = DateTimePickerFormat.Short;
            this.Controls.Add(dtpEnd);

            // Cost
            Label lblCost = new Label();
            lblCost.Text = "Cost";
            lblCost.Font = new Font("Segoe UI", 10);
            lblCost.ForeColor = Color.FromArgb(80, 80, 100);
            lblCost.Location = new Point(30, 210);
            lblCost.AutoSize = true;
            this.Controls.Add(lblCost);

            txtCost = new TextBox();
            txtCost.Size = new Size(200, 26);
            txtCost.Location = new Point(150, 207);
            txtCost.Font = new Font("Segoe UI", 10);
            txtCost.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(txtCost);

            // Add Button
            Button btnAdd = new Button();
            btnAdd.Text = "Add Record";
            btnAdd.Size = new Size(140, 35);
            btnAdd.Location = new Point(30, 250);
            btnAdd.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.BackColor = Color.FromArgb(35, 35, 55);
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 210);
            btnAdd.Click += btnAdd_Click;
            this.Controls.Add(btnAdd);

            // DataGridView
            dgv = new DataGridView();
            dgv.Location = new Point(30, 300);
            dgv.Size = new Size(530, 150);
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 55);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
            this.Controls.Add(dgv);
        }

        private void LoadData()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Maintenance WHERE Machine_ID = @ID", con);
                cmd.Parameters.AddWithValue("@ID", machineID);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable t = new DataTable();
                t.Load(reader);
                dgv.DataSource = t;
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCost.Text))
            {
                MessageBox.Show("Enter cost.");
                return;
            }

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Maintenance VALUES (@ID, @Start, @End, @Cost)", con);
                cmd.Parameters.AddWithValue("@ID", machineID);
                cmd.Parameters.AddWithValue("@Start", dtpStart.Value);
                cmd.Parameters.AddWithValue("@End", dtpEnd.Value);
                cmd.Parameters.AddWithValue("@Cost", decimal.Parse(txtCost.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Added.");
                txtCost.Text = "";
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message);
            }
        }
    }
}