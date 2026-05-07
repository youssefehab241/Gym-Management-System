using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class SportsForm : Form
    {
        string connectionString = @"Data Source=X\SQLEXPRESS;Initial Catalog=GymDB;Integrated Security=True;TrustServerCertificate=True";
        private TextBox txtSportID, txtSportName;
        private DataGridView dgv;
        private ComboBox cmbCommands;
        private Button btnExecute, btnClear;

        public SportsForm()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Manage Sports";
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
            title.Text = "Manage Sports";
            title.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(0, 200, 160);
            title.Location = new Point(30, 18);
            title.AutoSize = true;
            topBar.Controls.Add(title);

            int leftX = 30, y = 90, h = 45, lw = 100, iw = 200;

            this.Controls.Add(MakeLabel("Sport ID", leftX, y));
            txtSportID = MakeTextBox(leftX + lw + 5, y, iw); this.Controls.Add(txtSportID);

            this.Controls.Add(MakeLabel("Sport Name", leftX, y + h));
            txtSportName = MakeTextBox(leftX + lw + 5, y + h, iw); this.Controls.Add(txtSportName);

            Label lblCmd = new Label();
            lblCmd.Text = "Select Command:";
            lblCmd.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblCmd.ForeColor = Color.FromArgb(80, 80, 100);
            lblCmd.Location = new Point(30, 320);
            lblCmd.AutoSize = true;
            this.Controls.Add(lblCmd);

            cmbCommands = new ComboBox();
            cmbCommands.Items.AddRange(new string[] { "View All", "Search", "Add Sport", "Update Sport", "Delete Sport" });
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

        private void ClearFields() { txtSportID.Text = ""; txtSportName.Text = ""; }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgv.Rows[e.RowIndex];
            txtSportID.Text = row.Cells["Sport_ID"].Value.ToString();
            txtSportName.Text = row.Cells["Sport_Name"].Value.ToString();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (cmbCommands.SelectedItem == null) { MessageBox.Show("Select a command."); return; }
            switch (cmbCommands.SelectedItem.ToString())
            {
                case "View All": ViewAll(); break;
                case "Search": Search(); break;
                case "Add Sport": AddSport(); break;
                case "Update Sport": UpdateSport(); break;
                case "Delete Sport": DeleteSport(); break;
            }
        }

        private void ViewAll()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Sport", con);
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
                string q = "SELECT * FROM Sport WHERE 1=1";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                if (txtSportID.Text != "") { q += " AND Sport_ID = @ID"; cmd.Parameters.AddWithValue("@ID", int.Parse(txtSportID.Text)); }
                if (txtSportName.Text != "") { q += " AND Sport_Name LIKE @Name"; cmd.Parameters.AddWithValue("@Name", "%" + txtSportName.Text + "%"); }

                cmd.CommandText = q;
                DataTable t = new DataTable();
                t.Load(cmd.ExecuteReader());
                if (t.Rows.Count > 0) dgv.DataSource = t;
                else MessageBox.Show("Not found.");
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message); }
        }

        private void AddSport()
        {
            if (txtSportID.Text == "" || txtSportName.Text == "")
            { MessageBox.Show("Fill Sport ID and Sport Name."); return; }
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Sport (Sport_ID, Sport_Name) VALUES (@ID, @Name)", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(txtSportID.Text));
                cmd.Parameters.AddWithValue("@Name", txtSportName.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Sport added.");
                ViewAll();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message); }
        }

        private void UpdateSport()
        {
            if (txtSportID.Text == "" || txtSportName.Text == "")
            { MessageBox.Show("Fill Sport ID and Sport Name."); return; }
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Sport SET Sport_Name = @Name WHERE Sport_ID = @ID", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(txtSportID.Text));
                cmd.Parameters.AddWithValue("@Name", txtSportName.Text);
                if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Updated.");
                else MessageBox.Show("Not found.");
                con.Close();
                ViewAll();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message); }
        }

        private void DeleteSport()
        {
            if (txtSportID.Text == "") { MessageBox.Show("Enter Sport ID."); return; }
            if (MessageBox.Show("Delete this sport and all practice records?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                int id = int.Parse(txtSportID.Text);

                SqlCommand cmd1 = new SqlCommand("DELETE FROM Practices WHERE Sport_ID = @ID", con);
                cmd1.Parameters.AddWithValue("@ID", id); cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("DELETE FROM Sport WHERE Sport_ID = @ID", con);
                cmd2.Parameters.AddWithValue("@ID", id);
                if (cmd2.ExecuteNonQuery() > 0) MessageBox.Show("Deleted.");
                else MessageBox.Show("Not found.");
                con.Close();
                ViewAll();
            }
            catch (Exception ex) { MessageBox.Show("Error:\n" + ex.Message); }
        }

        private void btnClear_Click(object sender, EventArgs e) { ClearFields(); dgv.DataSource = null; }
    }
}