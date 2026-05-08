using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class EmployeesForm : Form
    {
        string connectionString = @"Data Source=X\SQLEXPRESS;Initial Catalog=GymDB;Integrated Security=True;TrustServerCertificate=True";
        private TextBox txtEmpID, txtFName, txtLName, txtJobTitle, txtSalary, txtPassword;
        private DataGridView dgv;
        private ComboBox cmbCommands;
        private Button btnExecute, btnClear;

        public EmployeesForm()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Manage Employees";
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
            title.Text = "Manage Employees";
            title.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(0, 200, 160);
            title.Location = new Point(30, 18);
            title.AutoSize = true;
            topBar.Controls.Add(title);

            int leftX = 30, rightX = 440, y = 90, h = 45, lw = 120, iw = 200;

            this.Controls.Add(MakeLabel("Employee ID", leftX, y));
            txtEmpID = MakeTextBox(leftX + lw + 5, y, iw); 
            this.Controls.Add(txtEmpID);

            this.Controls.Add(MakeLabel("First Name", leftX, y + h));
            txtFName = MakeTextBox(leftX + lw + 5, y + h, iw);
            this.Controls.Add(txtFName);

            this.Controls.Add(MakeLabel("Last Name", leftX, y + h * 2));
            txtLName = MakeTextBox(leftX + lw + 5, y + h * 2, iw);
            this.Controls.Add(txtLName);

            this.Controls.Add(MakeLabel("Job Title", leftX, y + h * 3));
            txtJobTitle = MakeTextBox(leftX + lw + 5, y + h * 3, iw); 
            this.Controls.Add(txtJobTitle);

            this.Controls.Add(MakeLabel("Salary", rightX, y));
            txtSalary = MakeTextBox(rightX + lw + 5, y, iw); 
            this.Controls.Add(txtSalary);

            this.Controls.Add(MakeLabel("Password", rightX, y + h));
            txtPassword = MakeTextBox(rightX + lw + 5, y + h, iw); 
            this.Controls.Add(txtPassword);

            Label lblCmd = new Label();
            lblCmd.Text = "Select Command:";
            lblCmd.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblCmd.ForeColor = Color.FromArgb(80, 80, 100);
            lblCmd.Location = new Point(30, 320);
            lblCmd.AutoSize = true;
            this.Controls.Add(lblCmd);

            cmbCommands = new ComboBox();
            cmbCommands.Items.AddRange(new string[] { "View All", "Search", "Add Employee", "Update Employee", "Delete Employee" });
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
            lbl.Text = text; lbl.Font = new Font("Segoe UI", 10);
            lbl.ForeColor = Color.FromArgb(80, 80, 100);
            lbl.Location = new Point(x, y); lbl.AutoSize = true;
            return lbl;
        }

        private TextBox MakeTextBox(int x, int y, int w)
        {
            TextBox txt = new TextBox();
            txt.Size = new Size(w, 26); 
            txt.Location = new Point(x, y);
            txt.Font = new Font("Segoe UI", 10);
            txt.BorderStyle = BorderStyle.FixedSingle;

            return txt;
        }

        private void ClearFields()
        {
            txtEmpID.Text = ""; 
            txtFName.Text = ""; 
            txtLName.Text = "";
            txtJobTitle.Text = "";
            txtSalary.Text = ""; 
            txtPassword.Text = "";
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgv.Rows[e.RowIndex];
            txtEmpID.Text = row.Cells["Employee_ID"].Value.ToString();
            txtFName.Text = row.Cells["F_Name"].Value.ToString();
            txtLName.Text = row.Cells["L_Name"].Value.ToString();
            txtJobTitle.Text = row.Cells["Job_Title"].Value.ToString();
            txtSalary.Text = row.Cells["Salary"].Value.ToString();
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
                case "Add Employee": 
                    Add(); 
                    break;
                case "Update Employee": 
                    Update();
                    break;
                case "Delete Employee":
                    Delete(); 
                    break;
            }
        }

        private void ViewAll()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Employee_ID, F_Name, L_Name, Job_Title, Salary FROM Employee", con);
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
                string q = "SELECT Employee_ID, F_Name, L_Name, Job_Title, Salary FROM Employee WHERE 1=1";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                if (txtEmpID.Text != "") { 
                    q += " AND Employee_ID = @ID"; 
                    cmd.Parameters.AddWithValue("@ID", int.Parse(txtEmpID.Text));
                }
                if (txtJobTitle.Text != "") { 
                    q += " AND Job_Title LIKE @Job"; 
                    cmd.Parameters.AddWithValue("@Job", "%" + txtJobTitle.Text + "%");
                }

                cmd.CommandText = q;
                DataTable t = new DataTable();
                t.Load(cmd.ExecuteReader());
                if (t.Rows.Count > 0) dgv.DataSource = t;
                else MessageBox.Show("Not found.");
                con.Close();
                dgv.ClearSelection();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message); }
        }

        private void Add()
        {
            if (txtEmpID.Text == "" || txtFName.Text == "" || txtLName.Text == "")
            { 
                MessageBox.Show("Fill ID, First Name, and Last Name.");
                return; 
            }
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Employee (Employee_ID, F_Name, L_Name, Job_Title, Salary, Password) VALUES (@ID, @FN, @LN, @Job, @Sal, @Pass)", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(txtEmpID.Text));
                cmd.Parameters.AddWithValue("@FN", txtFName.Text);
                cmd.Parameters.AddWithValue("@LN", txtLName.Text);
                cmd.Parameters.AddWithValue("@Job", txtJobTitle.Text);
                cmd.Parameters.AddWithValue("@Sal", txtSalary.Text == "" ? 0 : decimal.Parse(txtSalary.Text));
                cmd.Parameters.AddWithValue("@Pass", txtPassword.Text == "" ? "1234" : txtPassword.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Added.");
                ViewAll();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message); }
        }

        private void Update()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a subscription from the table to update.");
                return;
            }

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Employee SET F_Name=@FN, L_Name=@LN, Job_Title=@Job, Salary=@Sal WHERE Employee_ID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(txtEmpID.Text));
                cmd.Parameters.AddWithValue("@FN", txtFName.Text);
                cmd.Parameters.AddWithValue("@LN", txtLName.Text);
                cmd.Parameters.AddWithValue("@Job", txtJobTitle.Text);
                cmd.Parameters.AddWithValue("@Sal", txtSalary.Text == "" ? 0 : decimal.Parse(txtSalary.Text));
                
                if (cmd.ExecuteNonQuery() > 0) 
                    MessageBox.Show("Updated.");
                else 
                    MessageBox.Show("Not found.");
                
                con.Close();
                ViewAll();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message); }
        }

        private void Delete()
        {
            if (txtEmpID.Text == "") { 
                MessageBox.Show("Enter Employee ID."); 
                return;
            }

            if (MessageBox.Show("Delete?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes) 
                return;

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                int id = int.Parse(txtEmpID.Text);

                SqlCommand cmd1 = new SqlCommand("UPDATE Subscription SET Employee_ID = NULL WHERE Employee_ID = @ID", con);
                cmd1.Parameters.AddWithValue("@ID", id); cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("UPDATE Machine SET Employee_ID = NULL WHERE Employee_ID = @ID", con);
                cmd2.Parameters.AddWithValue("@ID", id); cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand("DELETE FROM Employee WHERE Employee_ID = @ID", con);
                cmd3.Parameters.AddWithValue("@ID", id);
               
                if (cmd3.ExecuteNonQuery() > 0) 
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