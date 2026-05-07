using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class PracticesForm : Form
    {
        string connectionString = @"Data Source=X\SQLEXPRESS;Initial Catalog=GymDB;Integrated Security=True;TrustServerCertificate=True";
        private ComboBox cmbMemberID, cmbSportID;
        private TextBox txtSkillLevel;
        private DataGridView dgv;

        public PracticesForm()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Member Practices";
            this.Size = new Size(700, 550);
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
            title.Text = "Member Practices";
            title.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(0, 200, 160);
            title.Location = new Point(30, 18);
            title.AutoSize = true;
            topBar.Controls.Add(title);

            this.Controls.Add(MakeLabel("Member ID", 30, 100));
            cmbMemberID = new ComboBox();
            cmbMemberID.Size = new Size(200, 26);
            cmbMemberID.Location = new Point(150, 97);
            cmbMemberID.Font = new Font("Segoe UI", 10);
            cmbMemberID.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(cmbMemberID);

            this.Controls.Add(MakeLabel("Sport ID", 30, 145));
            cmbSportID = new ComboBox();
            cmbSportID.Size = new Size(200, 26);
            cmbSportID.Location = new Point(150, 142);
            cmbSportID.Font = new Font("Segoe UI", 10);
            cmbSportID.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(cmbSportID);

            this.Controls.Add(MakeLabel("Skill Level", 30, 190));
            txtSkillLevel = MakeTextBox(150, 187, 200);
            this.Controls.Add(txtSkillLevel);

            Button btnAssign = new Button();
            btnAssign.Text = "Assign";
            btnAssign.Size = new Size(120, 35);
            btnAssign.Location = new Point(30, 230);
            btnAssign.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAssign.FlatStyle = FlatStyle.Flat;
            btnAssign.BackColor = Color.FromArgb(35, 35, 55);
            btnAssign.ForeColor = Color.White;
            btnAssign.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 210);
            btnAssign.Click += btnAssign_Click;
            this.Controls.Add(btnAssign);

            Button btnRemove = new Button();
            btnRemove.Text = "Remove Selected";
            btnRemove.Size = new Size(150, 35);
            btnRemove.Location = new Point(160, 230);
            btnRemove.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.BackColor = Color.FromArgb(35, 35, 55);
            btnRemove.ForeColor = Color.White;
            btnRemove.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 210);
            btnRemove.Click += btnRemove_Click;
            this.Controls.Add(btnRemove);

            dgv = new DataGridView();
            dgv.Location = new Point(30, 290);
            dgv.Size = new Size(630, 210);
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

            LoadDropdowns();
            LoadData();
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

        private void LoadDropdowns()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                // Load Member IDs
                SqlCommand cmd1 = new SqlCommand("SELECT Member_ID FROM Member", con);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                DataTable t1 = new DataTable();
                t1.Load(reader1);
                reader1.Close();
                cmbMemberID.DataSource = t1;
                cmbMemberID.DisplayMember = "Member_ID";
                cmbMemberID.ValueMember = "Member_ID";

                // Load Sport IDs and Names
                SqlCommand cmd2 = new SqlCommand("SELECT Sport_ID, Sport_Name FROM Sport", con);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                DataTable t2 = new DataTable();
                t2.Load(reader2);
                reader2.Close();
                cmbSportID.DataSource = t2;
                cmbSportID.DisplayMember = "Sport_Name";
                cmbSportID.ValueMember = "Sport_ID";

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dropdowns:\n" + ex.Message);
            }
        }

        private void LoadData()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT p.Member_ID, m.F_Name + ' ' + m.L_Name AS Member, p.Sport_ID, s.Sport_Name, p.Skill_Level FROM Practices p JOIN Member m ON p.Member_ID = m.Member_ID JOIN Sport s ON p.Sport_ID = s.Sport_ID", con);
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

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (cmbMemberID.SelectedValue == null || cmbSportID.SelectedValue == null || string.IsNullOrWhiteSpace(txtSkillLevel.Text))
            {
                MessageBox.Show("Fill all fields.");
                return;
            }

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Practices VALUES (@MemID, @SportID, @Skill)", con);
                cmd.Parameters.AddWithValue("@MemID", int.Parse(cmbMemberID.SelectedValue.ToString()));
                cmd.Parameters.AddWithValue("@SportID", int.Parse(cmbSportID.SelectedValue.ToString()));
                cmd.Parameters.AddWithValue("@Skill", txtSkillLevel.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Assigned.");
                txtSkillLevel.Text = "";
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row.");
                return;
            }

            try
            {
                int memId = int.Parse(dgv.SelectedRows[0].Cells["Member_ID"].Value.ToString());
                int sportId = int.Parse(dgv.SelectedRows[0].Cells["Sport_ID"].Value.ToString());

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Practices WHERE Member_ID = @MemID AND Sport_ID = @SportID", con);
                cmd.Parameters.AddWithValue("@MemID", memId);
                cmd.Parameters.AddWithValue("@SportID", sportId);
                cmd.ExecuteNonQuery();
                con.Close();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message);
            }
        }
    }
}