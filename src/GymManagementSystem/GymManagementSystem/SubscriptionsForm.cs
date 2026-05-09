using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class SubscriptionsForm : Form
    {
        string connectionString = @"Data Source=X\SQLEXPRESS;Initial Catalog=GymDB;Integrated Security=True;TrustServerCertificate=True";
        private TextBox txtSubID, txtCost, txtEmployeeID, txtMemberID;
        private DateTimePicker dtpStartDate, dtpEndDate;
        private DataGridView dgv;
        private ComboBox cmbCommands;
        private Button btnExecute, btnClear;

        public SubscriptionsForm()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Manage Subscriptions";
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
            title.Text = "Manage Subscriptions";
            title.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(0, 200, 160);
            title.Location = new Point(30, 18);
            title.AutoSize = true;
            topBar.Controls.Add(title);

            int leftX = 30, rightX = 440, y = 90, h = 45, lw = 120, iw = 200;

            this.Controls.Add(MakeLabel("Subscription ID", leftX, y));
            txtSubID = MakeTextBox(leftX + lw + 5, y, iw); 
            this.Controls.Add(txtSubID);

            this.Controls.Add(MakeLabel("Cost", leftX, y + h));
            txtCost = MakeTextBox(leftX + lw + 5, y + h, iw); 
            this.Controls.Add(txtCost);

            this.Controls.Add(MakeLabel("Start Date", leftX, y + h * 2));
            dtpStartDate = new DateTimePicker();
            dtpStartDate.Size = new Size(iw, 26);
            dtpStartDate.Location = new Point(leftX + lw + 5, y + h * 2);
            dtpStartDate.Format = DateTimePickerFormat.Short;
            this.Controls.Add(dtpStartDate);

            this.Controls.Add(MakeLabel("End Date", leftX, y + h * 3));
            dtpEndDate = new DateTimePicker();
            dtpEndDate.Size = new Size(iw, 26);
            dtpEndDate.Location = new Point(leftX + lw + 5, y + h * 3);
            dtpEndDate.Format = DateTimePickerFormat.Short;
            this.Controls.Add(dtpEndDate);

            this.Controls.Add(MakeLabel("Employee ID", rightX, y));
            txtEmployeeID = MakeTextBox(rightX + lw + 5, y, iw); 
            this.Controls.Add(txtEmployeeID);

            this.Controls.Add(MakeLabel("Member ID", rightX, y + h));
            txtMemberID = MakeTextBox(rightX + lw + 5, y + h, iw); 
            this.Controls.Add(txtMemberID);

            Label lblCmd = new Label();
            lblCmd.Text = "Select Command:";
            lblCmd.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblCmd.ForeColor = Color.FromArgb(80, 80, 100);
            lblCmd.Location = new Point(30, 320);
            lblCmd.AutoSize = true;
            this.Controls.Add(lblCmd);

            cmbCommands = new ComboBox();
            cmbCommands.Items.AddRange(new string[] { "View All", "Search", "Add Subscription", "Update Subscription", "Delete Subscription" });
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
            txt.Size = new Size(w, 26); txt.Location = new Point(x, y);
            txt.Font = new Font("Segoe UI", 10); txt.BorderStyle = BorderStyle.FixedSingle;
            return txt;
        }

        private void ClearFields()
        {
            txtSubID.Text = ""; 
            txtCost.Text = "";
            txtEmployeeID.Text = "";
            txtMemberID.Text = "";
            dtpStartDate.Value = DateTime.Now; 
            dtpEndDate.Value = DateTime.Now;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgv.Rows[e.RowIndex];
            txtSubID.Text = row.Cells["Subscription_ID"].Value.ToString();
            txtCost.Text = row.Cells["Cost"].Value.ToString();
            txtEmployeeID.Text = row.Cells["Employee_ID"].Value.ToString();
            txtMemberID.Text = row.Cells["Member_ID"].Value.ToString();

            if (row.Cells["Start_Date"].Value != DBNull.Value)
                dtpStartDate.Value = Convert.ToDateTime(row.Cells["Start_Date"].Value);

            if (row.Cells["End_Date"].Value != DBNull.Value)
                dtpEndDate.Value = Convert.ToDateTime(row.Cells["End_Date"].Value);
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
                case "Add Subscription": 
                    AddSub(); 
                    break;
                case "Update Subscription": 
                    UpdateSub(); 
                    break;
                case "Delete Subscription": 
                    DeleteSub(); 
                    break;
            }
        }

        private void ViewAll()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Subscription", con);
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
                string q = "SELECT * FROM Subscription WHERE 1=1";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                if (txtSubID.Text != "") { 
                    q += " AND Subscription_ID = @ID"; 
                    cmd.Parameters.AddWithValue("@ID", int.Parse(txtSubID.Text)); 
                }
                if (txtMemberID.Text != "") { 
                    q += " AND Member_ID = @MID"; 
                    cmd.Parameters.AddWithValue("@MID", int.Parse(txtMemberID.Text));
                }
                if (txtEmployeeID.Text != "") { 
                    q += " AND Employee_ID = @EID"; 
                    cmd.Parameters.AddWithValue("@EID", int.Parse(txtEmployeeID.Text)); 
                }
                if (txtCost.Text != ""){
                    q += " AND Cost = @cost";
                    cmd.Parameters.AddWithValue("@cost", decimal.Parse(txtCost.Text));
                }

                cmd.CommandText = q;
                DataTable t = new DataTable();
                t.Load(cmd.ExecuteReader());
                
                if (t.Rows.Count > 0) 
                    dgv.DataSource = t;
                else 
                    MessageBox.Show("Not found.");

                con.Close();

                dgv.ClearSelection();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message); }
        }

        private void AddSub()
        {
            if (txtSubID.Text == "" || txtEmployeeID.Text == "")
            { 
                MessageBox.Show("Fill Subscription ID and Employee ID."); 
                return; 
            }
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Subscription (Subscription_ID, Cost, Start_Date, End_Date, Employee_ID, Member_ID) VALUES (@ID, @Cost, @SD, @ED, @EID, @MID)", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(txtSubID.Text));
                cmd.Parameters.AddWithValue("@Cost", txtCost.Text == "" ? 0 : decimal.Parse(txtCost.Text));
                cmd.Parameters.AddWithValue("@SD", dtpStartDate.Value);
                cmd.Parameters.AddWithValue("@ED", dtpEndDate.Value);
                cmd.Parameters.AddWithValue("@EID", int.Parse(txtEmployeeID.Text));
                cmd.Parameters.AddWithValue("@MID", txtMemberID.Text == "" ? (object)DBNull.Value : int.Parse(txtMemberID.Text));

                if (!(txtEmployeeID.Text == ""))
                {
                    SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM Employee WHERE Employee_ID = @CheckEID", con);
                    check.Parameters.AddWithValue("@CheckEID", int.Parse(txtEmployeeID.Text));
                    SqlDataReader rdr = check.ExecuteReader();
                    rdr.Read();
                    int Exists = rdr.GetInt32(0);
                    rdr.Close();
                    if (Exists == 0)
                    {
                        MessageBox.Show("This Employee ID does not exist. Please enter a valid Employee ID or leave it blank.");
                        con.Close();
                        return;
                    }
                }
                if (!(txtMemberID.Text == ""))
                {
                    SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM Member WHERE Member_ID = @CheckMID", con);
                    check.Parameters.AddWithValue("@CheckMID", int.Parse(txtMemberID.Text));
                    SqlDataReader rdr = check.ExecuteReader();
                    rdr.Read();
                    int Exists = rdr.GetInt32(0);
                    rdr.Close();
                    if (Exists == 0)
                    {
                        MessageBox.Show("This Member ID does not exist. Please enter a valid Member ID or leave it blank.");
                        con.Close();
                        return;
                    }
                }

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Added.");
                ViewAll();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message); }
        }

        private void UpdateSub()
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

                SqlCommand cmd = new SqlCommand("UPDATE Subscription SET Cost=@Cost, Start_Date=@SD, End_Date=@ED, Employee_ID=@EID, Member_ID=@MID WHERE Subscription_ID=@ID", con);

                cmd.Parameters.AddWithValue("@ID", int.Parse(txtSubID.Text));
                cmd.Parameters.AddWithValue("@Cost", txtCost.Text == "" ? 0 : decimal.Parse(txtCost.Text));
                cmd.Parameters.AddWithValue("@SD", dtpStartDate.Value);
                cmd.Parameters.AddWithValue("@ED", dtpEndDate.Value);
                cmd.Parameters.AddWithValue("@EID", txtEmployeeID.Text == "" ? (object)DBNull.Value : int.Parse(txtEmployeeID.Text));
                cmd.Parameters.AddWithValue("@MID", txtMemberID.Text == "" ? (object)DBNull.Value : int.Parse(txtMemberID.Text));

                if (!(txtEmployeeID.Text == ""))
                {
                    SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM Employee WHERE Employee_ID = @CheckEID", con);
                    check.Parameters.AddWithValue("@CheckEID", int.Parse(txtEmployeeID.Text));
                    SqlDataReader rdr = check.ExecuteReader();
                    rdr.Read();
                    int Exists = rdr.GetInt32(0);
                    rdr.Close();
                    if (Exists == 0)
                    {
                        MessageBox.Show("This Employee ID does not exist. Please enter a valid Employee ID or leave it blank.");
                        con.Close();
                        return;
                    }
                }
                if (!(txtMemberID.Text == ""))
                {
                    SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM Member WHERE Member_ID = @CheckMID", con);
                    check.Parameters.AddWithValue("@CheckMID", int.Parse(txtMemberID.Text));
                    SqlDataReader rdr = check.ExecuteReader();
                    rdr.Read();
                    int Exists = rdr.GetInt32(0);
                    rdr.Close();
                    if (Exists == 0)
                    {
                        MessageBox.Show("This Member ID does not exist. Please enter a valid Member ID or leave it blank.");
                        con.Close();
                        return;
                    }
                }
                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("Updated.");
                else
                    MessageBox.Show("Not found.");

                con.Close();
                ViewAll();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message); }
        }

        private void DeleteSub()
        {
            if (txtSubID.Text == "") { 
                MessageBox.Show("Enter Subscription ID."); 
                return; 
            }
            if (MessageBox.Show("Delete?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes) 
                return;
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Subscription WHERE Subscription_ID = @ID", con);
                
                cmd.Parameters.AddWithValue("@ID", int.Parse(txtSubID.Text));
                
                if (cmd.ExecuteNonQuery() > 0) 
                    MessageBox.Show("Deleted.");
                else 
                    MessageBox.Show("Not found.");

                con.Close();
                ViewAll();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message); }
        }

        private void btnClear_Click(object sender, EventArgs e) 
        { 
            ClearFields(); 
            dgv.DataSource = null; 
        }
    }
}