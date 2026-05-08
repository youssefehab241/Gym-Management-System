using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace GymManagementSystem
{
    public partial class TrainersForm : Form
    {
        string connectionString = @"Data Source=X\SQLEXPRESS;Initial Catalog=GymDB;Integrated Security=True;TrustServerCertificate=True";
        private TextBox txtTrainerID, txtFName, txtLName, txtSalary, txtExperience;
        private DateTimePicker dtpStartDate;
        private DataGridView dgv;
        private ComboBox cmbCommands;
        private Button btnExecute, btnClear;

        public TrainersForm()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Manage Trainers";
            this.Size = new Size(880, 680);
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
            title.Text = "Manage Trainers";
            title.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(0, 200, 160);
            title.Location = new Point(30, 18);
            title.AutoSize = true;
            topBar.Controls.Add(title);

            int leftX = 30, rightX = 440, y = 90, h = 45, lw = 120, iw = 200;

            this.Controls.Add(MakeLabel("Trainer ID", leftX, y));
            txtTrainerID = MakeTextBox(leftX + lw + 5, y, iw); 
            this.Controls.Add(txtTrainerID);

            this.Controls.Add(MakeLabel("First Name", leftX, y + h));
            txtFName = MakeTextBox(leftX + lw + 5, y + h, iw); 
            this.Controls.Add(txtFName);

            this.Controls.Add(MakeLabel("Last Name", leftX, y + h * 2));
            txtLName = MakeTextBox(leftX + lw + 5, y + h * 2, iw); 
            this.Controls.Add(txtLName);

            this.Controls.Add(MakeLabel("Start Date", leftX, y + h * 3));
            dtpStartDate = new DateTimePicker();
            dtpStartDate.Size = new Size(iw, 26);
            dtpStartDate.Location = new Point(leftX + lw + 5, y + h * 3);
            dtpStartDate.Format = DateTimePickerFormat.Short;
            this.Controls.Add(dtpStartDate);

            this.Controls.Add(MakeLabel("Salary", rightX, y));
            txtSalary = MakeTextBox(rightX + lw + 5, y, iw); 
            this.Controls.Add(txtSalary);

            this.Controls.Add(MakeLabel("Experience", rightX, y + h));
            txtExperience = MakeTextBox(rightX + lw + 5, y + h, iw); 
            this.Controls.Add(txtExperience);

            Label lblCmd = new Label();
            lblCmd.Text = "Select Command:";
            lblCmd.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblCmd.ForeColor = Color.FromArgb(80, 80, 100);
            lblCmd.Location = new Point(30, 320);
            lblCmd.AutoSize = true;
            this.Controls.Add(lblCmd);

            cmbCommands = new ComboBox();
            cmbCommands.Items.AddRange(new string[] { "View All", "Search", "Add Trainer", "Update Trainer", "Delete Trainer" });
            cmbCommands.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCommands.Font = new Font("Segoe UI", 12);
            cmbCommands.Location = new Point(180, 315);
            cmbCommands.Size = new Size(250, 30);
            this.Controls.Add(cmbCommands);

            btnExecute = new Button();
            btnExecute.Text = "Execute";
            btnExecute.Size = new Size(120, 40);
            btnExecute.Location = new Point(450, 310);
            btnExecute.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnExecute.FlatStyle = FlatStyle.Flat;
            btnExecute.BackColor = Color.FromArgb(35, 35, 55);
            btnExecute.ForeColor = Color.White;
            btnExecute.Click += btnExecute_Click;
            this.Controls.Add(btnExecute);

            btnClear = new Button();
            btnClear.Text = "Clear";
            btnClear.Size = new Size(120, 40);
            btnClear.Location = new Point(580, 310);
            btnClear.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.BackColor = Color.FromArgb(35, 35, 55);
            btnClear.ForeColor = Color.White;
            btnClear.Click += btnClear_Click;
            this.Controls.Add(btnClear);

            dgv = new DataGridView();
            dgv.Location = new Point(30, 380);
            dgv.Size = new Size(810, 245);
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 55);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
            dgv.CellClick += dgv_CellClick;
            this.Controls.Add(dgv);
        }

        private Label MakeLabel(string text, int x, int y)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.Font = new Font("Segoe UI", 10);
            lbl.ForeColor = Color.FromArgb(80, 80, 100);
            lbl.Location = new Point(x, y);
            lbl.AutoSize = true;
            return lbl;
        }

        private TextBox MakeTextBox(int x, int y, int width)
        {
            TextBox txt = new TextBox();
            txt.Size = new Size(width, 26);
            txt.Location = new Point(x, y);
            txt.Font = new Font("Segoe UI", 10);
            txt.BorderStyle = BorderStyle.FixedSingle;
            return txt;
        }

        private void ClearFields()
        {
            txtTrainerID.Text = ""; 
            txtFName.Text = ""; 
            txtLName.Text = "";
            txtSalary.Text = ""; 
            txtExperience.Text = "";
            dtpStartDate.Value = DateTime.Now;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgv.Rows[e.RowIndex];
            txtTrainerID.Text = row.Cells["Trainer_ID"].Value.ToString();
            txtFName.Text = row.Cells["F_Name"].Value.ToString();
            txtLName.Text = row.Cells["L_Name"].Value.ToString();
            txtSalary.Text = row.Cells["Salary"].Value.ToString();
            txtExperience.Text = row.Cells["Experience"].Value.ToString();

            if (row.Cells["Start_Date"].Value != DBNull.Value)
                dtpStartDate.Value = Convert.ToDateTime(row.Cells["Start_Date"].Value);

        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (cmbCommands.SelectedItem == null) { 
                MessageBox.Show("Select a command.");
                return; 
            }
            switch (cmbCommands.SelectedItem.ToString())
            {
                case "View All": 
                    ViewAll(); 
                    break;
                case "Search": 
                    Search(); 
                    break;
                case "Add Trainer": 
                    AddTrainer(); 
                    break;
                case "Update Trainer": 
                    UpdateTrainer(); 
                    break;
                case "Delete Trainer": 
                    DeleteTrainer(); 
                    break;
            }
        }

        private void ViewAll()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Trainer", con);
                DataTable t = new DataTable();
                t.Load(cmd.ExecuteReader());
                dgv.DataSource = t;
                con.Close();
                ClearFields();

                dgv.ClearSelection();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message); }
        }

        private void Search()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string q = "SELECT * FROM Trainer WHERE 1=1";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                if (txtTrainerID.Text != "") { 
                    q += " AND Trainer_ID = @ID"; 
                    cmd.Parameters.AddWithValue("@ID", int.Parse(txtTrainerID.Text)); 
                }
                if (txtFName.Text != "") { 
                    q += " AND F_Name LIKE @FN"; 
                    cmd.Parameters.AddWithValue("@FN", "%" + txtFName.Text + "%");
                }

                cmd.CommandText = q;
                DataTable t = new DataTable();
                t.Load(cmd.ExecuteReader());
                
                if (t.Rows.Count > 0) 
                    dgv.DataSource = t;
                else MessageBox.Show("Not found.");

                con.Close();

                dgv.ClearSelection();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message); }
        }

        private void AddTrainer()
        {
            if (txtTrainerID.Text == "" || txtFName.Text == "" || txtLName.Text == "")
            { 
                MessageBox.Show("Fill ID, First Name, and Last Name."); 
                return; 
            }
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                int newID = 0;
                if (string.IsNullOrWhiteSpace(txtTrainerID.Text))
                {
                    SqlCommand cmdMax = new SqlCommand("SELECT ISNULL(MAX(Trainer_ID), 0) + 1 FROM Trainer", con);
                    SqlDataReader rdr = cmdMax.ExecuteReader();
                    rdr.Read();
                    newID = rdr.GetInt32(0);
                }
                else
                    newID = int.Parse(txtTrainerID.Text);

                SqlCommand cmd = new SqlCommand("INSERT INTO Trainer (Trainer_ID, F_Name, L_Name, Salary, Experience, Start_Date) VALUES (@Trainer_ID, @F_Name, @L_Name, @Salary, @Experience, @Start_Date)", con);
                cmd.Parameters.AddWithValue("@Trainer_ID", newID);
                cmd.Parameters.AddWithValue("@F_Name", txtFName.Text);
                cmd.Parameters.AddWithValue("@L_Name", txtLName.Text);
                cmd.Parameters.AddWithValue("@Salary", string.IsNullOrWhiteSpace(txtSalary.Text) ? (object)DBNull.Value : decimal.Parse(txtSalary.Text));
                cmd.Parameters.AddWithValue("@Experience", string.IsNullOrWhiteSpace(txtExperience.Text) ? (object)DBNull.Value : int.Parse(txtExperience.Text));
                cmd.Parameters.AddWithValue("@Start_Date", dtpStartDate.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Trainer added successfully.");
                ViewAll();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message); }
        }

        private void UpdateTrainer()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a trainer from the table to update.");
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Trainer SET F_Name=@FName, L_Name=@LName, Salary=@Salary, Experience=@Experience WHERE Trainer_ID=@ID", con);

                cmd.Parameters.AddWithValue("@ID", int.Parse(txtTrainerID.Text));

                cmd.Parameters.AddWithValue("@FName", txtFName.Text == "" ? (object)DBNull.Value : txtFName.Text);
                cmd.Parameters.AddWithValue("@LName", txtLName.Text == "" ? (object)DBNull.Value : txtLName.Text);

                cmd.Parameters.AddWithValue("@Salary", txtSalary.Text == "" ? 0 : decimal.Parse(txtSalary.Text));
                cmd.Parameters.AddWithValue("@Experience", txtExperience.Text == "" ? 0 : int.Parse(txtExperience.Text));

                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("Trainer updated.");
                else
                    MessageBox.Show("Trainer ID not found.");

                con.Close();
                ViewAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message);
            }
        }


        private void DeleteTrainer()
        {
            if (txtTrainerID.Text == "") { 
                MessageBox.Show("Enter Trainer ID."); 
                return; 
            }

            if (MessageBox.Show("Delete?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes) 
                return;

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                int id = int.Parse(txtTrainerID.Text);

                SqlCommand cmd1 = new SqlCommand("UPDATE Member SET Trainer_ID = NULL WHERE Trainer_ID = @ID", con);
                cmd1.Parameters.AddWithValue("@ID", id); 
                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("DELETE FROM Trainer WHERE Trainer_ID = @ID", con);
                cmd2.Parameters.AddWithValue("@ID", id);
                
                if (cmd2.ExecuteNonQuery() > 0) 
                    MessageBox.Show("Deleted.");
                else 
                    MessageBox.Show("Not found.");

                con.Close();
                ViewAll();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message); }
        }

        private void btnClear_Click(object sender, EventArgs e) { 
            ClearFields(); 
            dgv.DataSource = null; 
        }
    }
}