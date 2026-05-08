using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class LoginForm : Form
    {
        string connectionString = @"Data Source=X\SQLEXPRESS;Initial Catalog=GymDB;Integrated Security=True;TrustServerCertificate=True";

        private TextBox txtEmployeeID;
        private TextBox txtPassword;
        private Button btnLogin;

        public LoginForm()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Gym Login";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(245, 245, 250);

            // Top bar
            Panel topBar = new Panel();
            topBar.Dock = DockStyle.Top;
            topBar.Height = 70;
            topBar.BackColor = Color.FromArgb(35, 35, 55);
            this.Controls.Add(topBar);

            Label title = new Label();
            title.Text = "Employee Login";
            title.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(0, 200, 160);
            title.Location = new Point(30, 18);
            title.AutoSize = true;
            topBar.Controls.Add(title);

            // Employee ID
            Label lblID = new Label();
            lblID.Text = "Employee ID";
            lblID.Font = new Font("Segoe UI", 10);
            lblID.ForeColor = Color.FromArgb(80, 80, 100);
            lblID.Location = new Point(50, 100);
            lblID.AutoSize = true;
            this.Controls.Add(lblID);

            txtEmployeeID = new TextBox();
            txtEmployeeID.Size = new Size(180, 26);
            txtEmployeeID.Location = new Point(170, 97);
            txtEmployeeID.Font = new Font("Segoe UI", 10);
            txtEmployeeID.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(txtEmployeeID);

            // Password
            Label lblPass = new Label();
            lblPass.Text = "Password";
            lblPass.Font = new Font("Segoe UI", 10);
            lblPass.ForeColor = Color.FromArgb(80, 80, 100);
            lblPass.Location = new Point(50, 145);
            lblPass.AutoSize = true;
            this.Controls.Add(lblPass);

            txtPassword = new TextBox();
            txtPassword.Size = new Size(180, 26);
            txtPassword.Location = new Point(170, 142);
            txtPassword.Font = new Font("Segoe UI", 10);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.UseSystemPasswordChar = true;
            this.Controls.Add(txtPassword);

            // Login Button
            btnLogin = new Button();
            btnLogin.Text = "Login";
            btnLogin.Size = new Size(180, 40);
            btnLogin.Location = new Point(170, 190);
            btnLogin.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.BackColor = Color.FromArgb(35, 35, 55);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 210);
            btnLogin.Click += btnLogin_Click;
            this.Controls.Add(btnLogin);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmployeeID.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Enter ID and Password.");
                return;
            }

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Employee WHERE Employee_ID = @ID AND Password = @Pass", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(txtEmployeeID.Text));
                cmd.Parameters.AddWithValue("@Pass", txtPassword.Text);
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                int count = rdr.GetInt32(0);
                rdr.Close();

                con.Close();

                if (count > 0)
                {
                    MainForm main = new MainForm();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid ID or Password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message);
            }
        }
    }
}