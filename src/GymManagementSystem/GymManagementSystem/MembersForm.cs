using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace GymManagementSystem
{
    public partial class MembersForm : Form
    {
        string connectionString =@"Data Source=localhost;Initial Catalog=GymDB;Integrated Security=True;TrustServerCertificate=True";
        public MembersForm()
        {
            InitializeComponent();
        }

        private void MembersForm_Load(object sender, EventArgs e)
        {

        }

        private void btnViewMembers_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Member";

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);

                DataTable table = new DataTable();

                adapter.Fill(table);

                dgvMembers.DataSource = table;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(txtMemberID.Text) ||
                string.IsNullOrWhiteSpace(txtFName.Text) ||
                string.IsNullOrWhiteSpace(txtLName.Text) ||
                string.IsNullOrWhiteSpace(txtAge.Text) ||
                string.IsNullOrWhiteSpace(txtJoinDate.Text))
            {
                MessageBox.Show("Please fill Member ID, First Name, Last Name, Age, and Join Date.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Member
                         (Member_ID, F_Name, L_Name, Age, Join_Date, Subscription_ID, Trainer_ID, Session_Time, Goal)
                         VALUES
                         (@Member_ID, @F_Name, @L_Name, @Age, @Join_Date, @Subscription_ID, @Trainer_ID, @Session_Time, @Goal)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Member_ID", int.Parse(txtMemberID.Text));
                    cmd.Parameters.AddWithValue("@F_Name", txtFName.Text);
                    cmd.Parameters.AddWithValue("@L_Name", txtLName.Text);
                    cmd.Parameters.AddWithValue("@Age", int.Parse(txtAge.Text));
                    cmd.Parameters.AddWithValue("@Join_Date", DateTime.Parse(txtJoinDate.Text));

                    if (string.IsNullOrWhiteSpace(txtSubscriptionID.Text))
                        cmd.Parameters.AddWithValue("@Subscription_ID", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@Subscription_ID", int.Parse(txtSubscriptionID.Text));

                    if (string.IsNullOrWhiteSpace(txtTrainerID.Text))
                        cmd.Parameters.AddWithValue("@Trainer_ID", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@Trainer_ID", int.Parse(txtTrainerID.Text));

                    cmd.Parameters.AddWithValue("@Session_Time", txtSessionTime.Text);
                    cmd.Parameters.AddWithValue("@Goal", txtGoal.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Member added successfully");

                    // Refresh table after insert
                    btnViewMembers_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding member:\n" + ex.Message);
            }
        }
    }
}
