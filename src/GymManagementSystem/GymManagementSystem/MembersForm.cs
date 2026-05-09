using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class MembersForm : Form
    {
        string connectionString = @"Data Source=X\SQLEXPRESS;Initial Catalog=GymDB;Integrated Security=True;TrustServerCertificate=True";
        private TextBox txtMemberID, txtFName, txtLName, txtAge, txtTrainerID, txtGoal;
        private DateTimePicker dtpJoinDate, dtpSessionTime;
        private DataGridView dgv;
        private ComboBox cmbCommands;
        private Button btnExecute, btnClear, btnPhones;

        public MembersForm()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Manage Members";
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
            title.Text = "Manage Members";
            title.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(0, 200, 160);
            title.Location = new Point(30, 18);
            title.AutoSize = true;
            topBar.Controls.Add(title);

            int leftX = 30, rightX = 440, y = 90, h = 45, lw = 120, iw = 200;

            this.Controls.Add(MakeLabel("Member ID", leftX, y));
            txtMemberID = MakeTextBox(leftX + lw + 5, y, iw); 
            this.Controls.Add(txtMemberID);

            this.Controls.Add(MakeLabel("First Name", leftX, y + h));
            txtFName = MakeTextBox(leftX + lw + 5, y + h, iw); 
            this.Controls.Add(txtFName);

            this.Controls.Add(MakeLabel("Last Name", leftX, y + h * 2));
            txtLName = MakeTextBox(leftX + lw + 5, y + h * 2, iw); 
            this.Controls.Add(txtLName);

            this.Controls.Add(MakeLabel("Age", leftX, y + h * 3));
            txtAge = MakeTextBox(leftX + lw + 5, y + h * 3, iw); 
            this.Controls.Add(txtAge);

            this.Controls.Add(MakeLabel("Join Date", leftX, y + h * 4));
            dtpJoinDate = new DateTimePicker();
            dtpJoinDate.Size = new Size(iw, 26);
            dtpJoinDate.Location = new Point(leftX + lw + 5, y + h * 4);
            dtpJoinDate.Format = DateTimePickerFormat.Short;
            this.Controls.Add(dtpJoinDate);

            this.Controls.Add(MakeLabel("Trainer ID", rightX, y));
            txtTrainerID = MakeTextBox(rightX + lw + 5, y, iw); 
            this.Controls.Add(txtTrainerID);

            this.Controls.Add(MakeLabel("Session Time", rightX, y + h));
            dtpSessionTime = new DateTimePicker();
            dtpSessionTime.Size = new Size(iw, 26);
            dtpSessionTime.Location = new Point(rightX + lw + 5, y + h);
            dtpSessionTime.Format = DateTimePickerFormat.Custom;
            dtpSessionTime.CustomFormat = "hh:mm tt";
            dtpSessionTime.ShowUpDown = true;
            this.Controls.Add(dtpSessionTime);

            this.Controls.Add(MakeLabel("Fitness Goal", rightX, y + h * 2));
            txtGoal = MakeTextBox(rightX + lw + 5, y + h * 2, iw); 
            this.Controls.Add(txtGoal);

            btnPhones = new Button();
            btnPhones.Text = "Manage Phones";
            btnPhones.Size = new Size(200, 40);
            btnPhones.Location = new Point(rightX, y + h * 3);
            btnPhones.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnPhones.FlatStyle = FlatStyle.Flat;
            btnPhones.BackColor = Color.FromArgb(0, 200, 160);
            btnPhones.ForeColor = Color.White;
            btnPhones.Click += btnPhones_Click;
            this.Controls.Add(btnPhones);

            Label lblCmd = new Label();
            lblCmd.Text = "Select Command:";
            lblCmd.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblCmd.ForeColor = Color.FromArgb(80, 80, 100);
            lblCmd.Location = new Point(30, 320);
            lblCmd.AutoSize = true;
            this.Controls.Add(lblCmd);

            cmbCommands = new ComboBox();
            cmbCommands.Items.AddRange(new string[] { "View All", "Search", "Add Member", "Update Member", "Delete Member" });
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
            lbl.Location = new Point(x, y); 
            lbl.AutoSize = true;
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
            txtMemberID.Text = ""; 
            txtFName.Text = ""; 
            txtLName.Text = "";
            txtAge.Text = ""; 
            txtTrainerID.Text = ""; 
            txtGoal.Text = "";
            dtpJoinDate.Value = DateTime.Now; 
            dtpSessionTime.Value = DateTime.Now;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) 
                return;

            DataGridViewRow row = dgv.Rows[e.RowIndex];
            txtMemberID.Text = row.Cells["Member_ID"].Value.ToString();
            txtFName.Text = row.Cells["F_Name"].Value.ToString();
            txtLName.Text = row.Cells["L_Name"].Value.ToString();
            txtAge.Text = row.Cells["Age"].Value.ToString();
            txtTrainerID.Text = row.Cells["Trainer_ID"].Value.ToString();
            txtGoal.Text = row.Cells["Goal"].Value.ToString();


            if (row.Cells["Join_Date"].Value != DBNull.Value)
                dtpJoinDate.Value = Convert.ToDateTime(row.Cells["Join_Date"].Value);

            if (row.Cells["Session_Time"].Value != DBNull.Value)
                dtpSessionTime.Value = Convert.ToDateTime(row.Cells["Session_Time"].Value);
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
                case "Add Member": 
                    AddMember(); 
                    break;
                case "Update Member": 
                    UpdateMember(); 
                    break;
                case "Delete Member": 
                    DeleteMember(); 
                    break;
            }
        }

        private void ViewAll()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Member", con);
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
                string q = "SELECT * FROM Member WHERE 1=1";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                if (txtMemberID.Text != "") { 
                    q += " AND Member_ID = @ID"; 
                    cmd.Parameters.AddWithValue("@ID", int.Parse(txtMemberID.Text)); 
                }
                if (txtFName.Text != "") { 
                    q += " AND F_Name LIKE @FN"; 
                    cmd.Parameters.AddWithValue("@FN", "%" + txtFName.Text + "%"); 
                }
                if (txtLName.Text != "") { 
                    q += " AND L_Name LIKE @LN"; 
                    cmd.Parameters.AddWithValue("@LN", "%" + txtLName.Text + "%");
                }
                if (txtAge.Text != ""){
                    q += " AND Age = @age";
                    cmd.Parameters.AddWithValue("@age", int.Parse(txtAge.Text));
                }
                if (txtTrainerID.Text != "") { 
                    q+= " AND Trainer_ID = @TID";
                    cmd.Parameters.AddWithValue("@TID", int.Parse(txtTrainerID.Text));
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

        private void AddMember()
        {
            if (txtFName.Text == "" || txtLName.Text == "" || txtAge.Text == "")
            { 
                MessageBox.Show("Fill at least the Name and Age."); 
                return; 
            }
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Member (F_Name, L_Name, Age, Join_Date, Trainer_ID, Session_Time, Goal) VALUES (@FN, @LN, @Age, @JD, @TID, @ST, @Goal)", con);
                //cmd.Parameters.AddWithValue("@ID", int.Parse(txtMemberID.Text));
                cmd.Parameters.AddWithValue("@FN", txtFName.Text);
                cmd.Parameters.AddWithValue("@LN", txtLName.Text);
                cmd.Parameters.AddWithValue("@Age", int.Parse(txtAge.Text));
                cmd.Parameters.AddWithValue("@JD", dtpJoinDate.Value);
                cmd.Parameters.AddWithValue("@TID", txtTrainerID.Text == "" ? (object)DBNull.Value : int.Parse(txtTrainerID.Text));

                if (!(txtTrainerID.Text == ""))
                {
                    SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM Trainer WHERE Trainer_ID = @CheckTID", con);
                    check.Parameters.AddWithValue("@CheckTID", int.Parse(txtTrainerID.Text));
                    SqlDataReader rdr = check.ExecuteReader();
                    rdr.Read();
                    int Exists = rdr.GetInt32(0);
                    rdr.Close();
                    if (Exists == 0)
                    {
                        MessageBox.Show("This Trainer ID does not exist. Please enter a valid Trainer ID or leave it blank.");
                        con.Close();
                        return;
                    }
                }

                cmd.Parameters.AddWithValue("@ST", dtpSessionTime.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@Goal", txtGoal.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Added.");
                ViewAll();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message); }
        }

        private void UpdateMember()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row from the table to update.");
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Member SET F_Name=@FN, L_Name=@LN, Age=@Age, Join_Date=@JD, Trainer_ID=@TID, Session_Time=@ST, Goal=@Goal WHERE Member_ID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(txtMemberID.Text));
                cmd.Parameters.AddWithValue("@FN", txtFName.Text);
                cmd.Parameters.AddWithValue("@LN", txtLName.Text);
                cmd.Parameters.AddWithValue("@Age", txtAge.Text == "" ? 0 : int.Parse(txtAge.Text));
                cmd.Parameters.AddWithValue("@JD", dtpJoinDate.Value);

                if (!(txtTrainerID.Text == ""))
                {
                    SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM Trainer WHERE Trainer_ID = @CheckTID", con);
                    check.Parameters.AddWithValue("@CheckTID", int.Parse(txtTrainerID.Text));
                    SqlDataReader rdr = check.ExecuteReader();
                    rdr.Read();
                    int Exists = rdr.GetInt32(0);
                    rdr.Close();
                    if (Exists == 0)
                    {
                        MessageBox.Show("This Trainer ID does not exist. Please enter a valid Trainer ID or leave it blank.");
                        con.Close();
                        return;
                    }
                }

                cmd.Parameters.AddWithValue("@TID", txtTrainerID.Text == "" ? (object)DBNull.Value : int.Parse(txtTrainerID.Text));
                cmd.Parameters.AddWithValue("@ST", dtpSessionTime.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@Goal", txtGoal.Text);
                
                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("Updated.");
                else 
                    MessageBox.Show("Not found.");

                con.Close();
                ViewAll();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message); }
        }

        private void DeleteMember()
        {
            if (txtMemberID.Text == "") { MessageBox.Show("Enter Member ID."); return; }
            if (MessageBox.Show("Delete this member and all related data?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes) 
                return;
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                int id = int.Parse(txtMemberID.Text);

                SqlCommand cmd1 = new SqlCommand("DELETE FROM Member_Phones WHERE Member_ID = @ID", con);
                cmd1.Parameters.AddWithValue("@ID", id); 
                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("DELETE FROM Practices WHERE Member_ID = @ID", con);
                cmd2.Parameters.AddWithValue("@ID", id); 
                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand("DELETE FROM Subscription WHERE Member_ID = @ID", con);
                cmd3.Parameters.AddWithValue("@ID", id); 
                cmd3.ExecuteNonQuery();

                SqlCommand cmd4 = new SqlCommand("DELETE FROM Member WHERE Member_ID = @ID", con);
                cmd4.Parameters.AddWithValue("@ID", id);
                
                if (cmd4.ExecuteNonQuery() > 0) 
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

        private void btnPhones_Click(object sender, EventArgs e)
        {
            if (txtMemberID.Text == "") { 
                MessageBox.Show("Enter Member ID first."); 
                return; 
            }
            new MemberPhonesForm(int.Parse(txtMemberID.Text)).Show();
        }
    }
}