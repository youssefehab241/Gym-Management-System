namespace GymManagementSystem
{
    partial class MembersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvMembers = new System.Windows.Forms.DataGridView();
            this.btnViewMembers = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMemberID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtTrainerID = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.txtJoinDate = new System.Windows.Forms.TextBox();
            this.txtSessionTime = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtSubscriptionID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtGoal = new System.Windows.Forms.TextBox();
            this.btnAddMember = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitle.Location = new System.Drawing.Point(349, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(304, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Manage Members";
            // 
            // dgvMembers
            // 
            this.dgvMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembers.Location = new System.Drawing.Point(12, 306);
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.RowHeadersWidth = 51;
            this.dgvMembers.RowTemplate.Height = 24;
            this.dgvMembers.Size = new System.Drawing.Size(958, 250);
            this.dgvMembers.TabIndex = 1;
            // 
            // btnViewMembers
            // 
            this.btnViewMembers.Location = new System.Drawing.Point(50, 260);
            this.btnViewMembers.Name = "btnViewMembers";
            this.btnViewMembers.Size = new System.Drawing.Size(150, 40);
            this.btnViewMembers.TabIndex = 3;
            this.btnViewMembers.Text = "View Members";
            this.btnViewMembers.UseVisualStyleBackColor = true;
            this.btnViewMembers.Click += new System.EventHandler(this.btnViewMembers_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Member ID:";
            // 
            // txtMemberID
            // 
            this.txtMemberID.Location = new System.Drawing.Point(143, 75);
            this.txtMemberID.Name = "txtMemberID";
            this.txtMemberID.Size = new System.Drawing.Size(84, 22);
            this.txtMemberID.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Age:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(268, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Join Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(268, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Session:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Trainer ID:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(268, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "First Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(496, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Last Name:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(496, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 16);
            this.label9.TabIndex = 13;
            this.label9.Text = "Subscription ID:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(143, 110);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(84, 22);
            this.txtAge.TabIndex = 14;
            // 
            // txtTrainerID
            // 
            this.txtTrainerID.Location = new System.Drawing.Point(143, 148);
            this.txtTrainerID.Name = "txtTrainerID";
            this.txtTrainerID.Size = new System.Drawing.Size(84, 22);
            this.txtTrainerID.TabIndex = 15;
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(349, 75);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(100, 22);
            this.txtFName.TabIndex = 16;
            // 
            // txtJoinDate
            // 
            this.txtJoinDate.Location = new System.Drawing.Point(349, 111);
            this.txtJoinDate.Name = "txtJoinDate";
            this.txtJoinDate.Size = new System.Drawing.Size(100, 22);
            this.txtJoinDate.TabIndex = 17;
            // 
            // txtSessionTime
            // 
            this.txtSessionTime.Location = new System.Drawing.Point(349, 147);
            this.txtSessionTime.Name = "txtSessionTime";
            this.txtSessionTime.Size = new System.Drawing.Size(100, 22);
            this.txtSessionTime.TabIndex = 18;
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(607, 72);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(102, 22);
            this.txtLName.TabIndex = 19;
            // 
            // txtSubscriptionID
            // 
            this.txtSubscriptionID.Location = new System.Drawing.Point(607, 109);
            this.txtSubscriptionID.Name = "txtSubscriptionID";
            this.txtSubscriptionID.Size = new System.Drawing.Size(100, 22);
            this.txtSubscriptionID.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(499, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "Goal:";
            // 
            // txtGoal
            // 
            this.txtGoal.Location = new System.Drawing.Point(607, 148);
            this.txtGoal.Name = "txtGoal";
            this.txtGoal.Size = new System.Drawing.Size(100, 22);
            this.txtGoal.TabIndex = 22;
            // 
            // btnAddMember
            // 
            this.btnAddMember.Location = new System.Drawing.Point(227, 260);
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.Size = new System.Drawing.Size(124, 39);
            this.btnAddMember.TabIndex = 23;
            this.btnAddMember.Text = "Add Member";
            this.btnAddMember.UseVisualStyleBackColor = true;
            this.btnAddMember.Click += new System.EventHandler(this.btnAddMember_Click);
            // 
            // MembersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.btnAddMember);
            this.Controls.Add(this.txtGoal);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSubscriptionID);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.txtSessionTime);
            this.Controls.Add(this.txtJoinDate);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.txtTrainerID);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMemberID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnViewMembers);
            this.Controls.Add(this.dgvMembers);
            this.Controls.Add(this.lblTitle);
            this.Name = "MembersForm";
            this.Text = "Manage Members";
            this.Load += new System.EventHandler(this.MembersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvMembers;
        private System.Windows.Forms.Button btnViewMembers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMemberID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtTrainerID;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.TextBox txtJoinDate;
        private System.Windows.Forms.TextBox txtSessionTime;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtSubscriptionID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtGoal;
        private System.Windows.Forms.Button btnAddMember;
    }
}