using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class MemberPhonesForm : Form
    {
        string connectionString = @"Data Source=X\SQLEXPRESS;Initial Catalog=GymDB;Integrated Security=True;TrustServerCertificate=True";
        private int memberID;
        private TextBox txtPhone;
        private DataGridView dgv;
        private Label lblInfo;

        public MemberPhonesForm(int memberId)
        {
            InitializeComponent();
            memberID = memberId;
            SetupUI();
            LoadPhones();
        }

        private void SetupUI()
        {
            this.Text = "Member Phones";
            this.Size = new Size(500, 450);
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
            title.Text = "Manage Phones";
            title.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(0, 200, 160);
            title.Location = new Point(30, 18);
            title.AutoSize = true;
            topBar.Controls.Add(title);

            lblInfo = new Label();
            lblInfo.Text = "Member ID: " + memberID;
            lblInfo.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblInfo.ForeColor = Color.FromArgb(80, 80, 100);
            lblInfo.Location = new Point(30, 85);
            lblInfo.AutoSize = true;
            this.Controls.Add(lblInfo);

            Label lblPhone = new Label();
            lblPhone.Text = "Phone Number";
            lblPhone.Font = new Font("Segoe UI", 10);
            lblPhone.ForeColor = Color.FromArgb(80, 80, 100);
            lblPhone.Location = new Point(30, 120);
            lblPhone.AutoSize = true;
            this.Controls.Add(lblPhone);

            txtPhone = new TextBox();
            txtPhone.Size = new Size(200, 26);
            txtPhone.Location = new Point(150, 117);
            txtPhone.Font = new Font("Segoe UI", 10);
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(txtPhone);

            Button btnAdd = new Button();
            btnAdd.Text = "Add Phone";
            btnAdd.Size = new Size(120, 35);
            btnAdd.Location = new Point(30, 160);
            btnAdd.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.BackColor = Color.FromArgb(35, 35, 55);
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 210);
            btnAdd.Click += btnAdd_Click;
            this.Controls.Add(btnAdd);

            Button btnDelete = new Button();
            btnDelete.Text = "Delete Selected";
            btnDelete.Size = new Size(140, 35);
            btnDelete.Location = new Point(160, 160);
            btnDelete.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.BackColor = Color.FromArgb(35, 35, 55);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 210);
            btnDelete.Click += btnDelete_Click;
            this.Controls.Add(btnDelete);

            dgv = new DataGridView();
            dgv.Location = new Point(30, 210);
            dgv.Size = new Size(430, 170);
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

        private void LoadPhones()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Member_Phones WHERE Member_ID = @ID", con);
                cmd.Parameters.AddWithValue("@ID", memberID);
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
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Enter phone number.");
                return;
            }

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Member_Phones VALUES (@ID, @Phone)", con);
                cmd.Parameters.AddWithValue("@ID", memberID);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Added.");
                txtPhone.Text = "";
                LoadPhones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row.");
                return;
            }

            try
            {
                string phone = dgv.SelectedRows[0].Cells["Phone_Number"].Value.ToString();
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Member_Phones WHERE Member_ID = @ID AND Phone_Number = @Phone", con);
                cmd.Parameters.AddWithValue("@ID", memberID);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.ExecuteNonQuery();
                con.Close();
                LoadPhones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message);
            }
        }
    }
}