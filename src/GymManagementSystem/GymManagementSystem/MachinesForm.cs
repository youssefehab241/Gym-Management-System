using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class MachinesForm : Form
    {
        string connectionString = @"Data Source=X\SQLEXPRESS;Initial Catalog=GymDB;Integrated Security=True;TrustServerCertificate=True";
        private TextBox txtMachineID, txtMachineName, txtUsage, txtEmployeeID;
        private DateTimePicker dtpPurchaseDate;
        private DataGridView dgv;
        private ComboBox cmbCommands;
        private Button btnExecute, btnClear, btnMaintenance;

        public MachinesForm()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Manage Machines";
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
            title.Text = "Manage Machines";
            title.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(0, 200, 160);
            title.Location = new Point(30, 18);
            title.AutoSize = true;
            topBar.Controls.Add(title);

            int leftX = 30, rightX = 440, y = 90, h = 45, lw = 120, iw = 200;

            this.Controls.Add(MakeLabel("Machine ID", leftX, y));
            txtMachineID = MakeTextBox(leftX + lw + 5, y, iw); this.Controls.Add(txtMachineID);

            this.Controls.Add(MakeLabel("Machine Name", leftX, y + h));
            txtMachineName = MakeTextBox(leftX + lw + 5, y + h, iw); this.Controls.Add(txtMachineName);

            this.Controls.Add(MakeLabel("Usage", leftX, y + h * 2));
            txtUsage = MakeTextBox(leftX + lw + 5, y + h * 2, iw); this.Controls.Add(txtUsage);

            this.Controls.Add(MakeLabel("Purchase Date", leftX, y + h * 3));
            dtpPurchaseDate = new DateTimePicker();
            dtpPurchaseDate.Size = new Size(iw, 26);
            dtpPurchaseDate.Location = new Point(leftX + lw + 5, y + h * 3);
            dtpPurchaseDate.Format = DateTimePickerFormat.Short;
            this.Controls.Add(dtpPurchaseDate);

            this.Controls.Add(MakeLabel("Employee ID", rightX, y));
            txtEmployeeID = MakeTextBox(rightX + lw + 5, y, iw); this.Controls.Add(txtEmployeeID);

            btnMaintenance = new Button();
            btnMaintenance.Text = "View Maintenance";
            btnMaintenance.Size = new Size(200, 40);
            btnMaintenance.Location = new Point(rightX, y + h * 2);
            btnMaintenance.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnMaintenance.FlatStyle = FlatStyle.Flat;
            btnMaintenance.BackColor = Color.FromArgb(0, 200, 160);
            btnMaintenance.ForeColor = Color.White;
            btnMaintenance.Click += btnMaintenance_Click;
            this.Controls.Add(btnMaintenance);

            Label lblCmd = new Label();
            lblCmd.Text = "Select Command:";
            lblCmd.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblCmd.ForeColor = Color.FromArgb(80, 80, 100);
            lblCmd.Location = new Point(30, 320);
            lblCmd.AutoSize = true;
            this.Controls.Add(lblCmd);

            cmbCommands = new ComboBox();
            cmbCommands.Items.AddRange(new string[] { "View All", "Search", "Add Machine", "Update Machine", "Delete Machine" });
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
            txtMachineID.Text = ""; txtMachineName.Text = "";
            txtUsage.Text = ""; txtEmployeeID.Text = "";
            dtpPurchaseDate.Value = DateTime.Now;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgv.Rows[e.RowIndex];
            txtMachineID.Text = row.Cells["Machine_ID"].Value.ToString();
            txtMachineName.Text = row.Cells["Machine_Name"].Value.ToString();
            txtUsage.Text = row.Cells["Usage"].Value.ToString();
            txtEmployeeID.Text = row.Cells["Employee_ID"].Value.ToString();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (cmbCommands.SelectedItem == null) { MessageBox.Show("Select a command."); return; }
            switch (cmbCommands.SelectedItem.ToString())
            {
                case "View All": ViewAll(); break;
                case "Search": Search(); break;
                case "Add Machine": AddMachine(); break;
                case "Update Machine": UpdateMachine(); break;
                case "Delete Machine": DeleteMachine(); break;
            }
        }

        private void ViewAll()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Machine", con);
                DataTable t = new DataTable();
                t.Load(cmd.ExecuteReader());
                dgv.DataSource = t;
                con.Close();
                ClearFields();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message); }
        }

        private void Search()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string q = "SELECT * FROM Machine WHERE 1=1";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                if (txtMachineID.Text != "") { q += " AND Machine_ID = @ID"; cmd.Parameters.AddWithValue("@ID", int.Parse(txtMachineID.Text)); }
                if (txtMachineName.Text != "") { q += " AND Machine_Name LIKE @Name"; cmd.Parameters.AddWithValue("@Name", "%" + txtMachineName.Text + "%"); }

                cmd.CommandText = q;
                DataTable t = new DataTable();
                t.Load(cmd.ExecuteReader());
                if (t.Rows.Count > 0) dgv.DataSource = t;
                else MessageBox.Show("Not found.");
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message); }
        }

        private void AddMachine()
        {
            if (txtMachineID.Text == "" || txtMachineName.Text == "")
            { MessageBox.Show("Fill ID and Machine Name."); return; }
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Machine (Machine_ID, Machine_Name, Usage, Purchase_Date, Employee_ID) VALUES (@ID, @Name, @Usage, @PD, @EID)", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(txtMachineID.Text));
                cmd.Parameters.AddWithValue("@Name", txtMachineName.Text);
                cmd.Parameters.AddWithValue("@Usage", txtUsage.Text);
                cmd.Parameters.AddWithValue("@PD", dtpPurchaseDate.Value);
                cmd.Parameters.AddWithValue("@EID", txtEmployeeID.Text == "" ? (object)DBNull.Value : int.Parse(txtEmployeeID.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Added.");
                ViewAll();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message); }
        }

        private void UpdateMachine()
        {
            if (txtMachineID.Text == "") { MessageBox.Show("Enter Machine ID."); return; }
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Machine SET Machine_Name=@Name, Usage=@Usage, Purchase_Date=@PD, Employee_ID=@EID WHERE Machine_ID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(txtMachineID.Text));
                cmd.Parameters.AddWithValue("@Name", txtMachineName.Text);
                cmd.Parameters.AddWithValue("@Usage", txtUsage.Text);
                cmd.Parameters.AddWithValue("@PD", dtpPurchaseDate.Value);
                cmd.Parameters.AddWithValue("@EID", txtEmployeeID.Text == "" ? (object)DBNull.Value : int.Parse(txtEmployeeID.Text));
                if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Updated.");
                else MessageBox.Show("Not found.");
                con.Close();
                ViewAll();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message); }
        }

        private void DeleteMachine()
        {
            if (txtMachineID.Text == "") { MessageBox.Show("Enter Machine ID."); return; }
            if (MessageBox.Show("Delete?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                int id = int.Parse(txtMachineID.Text);

                SqlCommand cmd1 = new SqlCommand("DELETE FROM Maintenance WHERE Machine_ID = @ID", con);
                cmd1.Parameters.AddWithValue("@ID", id); cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("DELETE FROM Machine WHERE Machine_ID = @ID", con);
                cmd2.Parameters.AddWithValue("@ID", id);
                if (cmd2.ExecuteNonQuery() > 0) MessageBox.Show("Deleted.");
                else MessageBox.Show("Not found.");
                con.Close();
                ViewAll();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message); }
        }

        private void btnClear_Click(object sender, EventArgs e) { ClearFields(); dgv.DataSource = null; }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            if (txtMachineID.Text == "") { MessageBox.Show("Enter Machine ID first."); return; }
            new MaintenanceForm(int.Parse(txtMachineID.Text)).Show();
        }
    }
}