namespace GymManagementSystem
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSports = new System.Windows.Forms.Button();
            this.btnMachines = new System.Windows.Forms.Button();
            this.btnSubscriptions = new System.Windows.Forms.Button();
            this.btnTrainers = new System.Windows.Forms.Button();
            this.btnMembers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(258, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gym Management System";
            // 
            // btnSports
            // 
            this.btnSports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSports.Location = new System.Drawing.Point(370, 386);
            this.btnSports.Name = "btnSports";
            this.btnSports.Size = new System.Drawing.Size(205, 39);
            this.btnSports.TabIndex = 1;
            this.btnSports.Text = "Manage Sports";
            this.btnSports.UseVisualStyleBackColor = true;
            this.btnSports.Click += new System.EventHandler(this.btnSports_Click);
            // 
            // btnMachines
            // 
            this.btnMachines.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMachines.Location = new System.Drawing.Point(643, 420);
            this.btnMachines.Name = "btnMachines";
            this.btnMachines.Size = new System.Drawing.Size(215, 40);
            this.btnMachines.TabIndex = 2;
            this.btnMachines.Text = "Manage Machines\n";
            this.btnMachines.UseVisualStyleBackColor = true;
            this.btnMachines.Click += new System.EventHandler(this.btnMachines_Click);
            // 
            // btnSubscriptions
            // 
            this.btnSubscriptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubscriptions.Location = new System.Drawing.Point(89, 420);
            this.btnSubscriptions.Name = "btnSubscriptions";
            this.btnSubscriptions.Size = new System.Drawing.Size(231, 40);
            this.btnSubscriptions.TabIndex = 3;
            this.btnSubscriptions.Text = "Manage Subscriptions\n";
            this.btnSubscriptions.UseVisualStyleBackColor = true;
            this.btnSubscriptions.Click += new System.EventHandler(this.btnSubscriptions_Click);
            // 
            // btnTrainers
            // 
            this.btnTrainers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrainers.Location = new System.Drawing.Point(643, 332);
            this.btnTrainers.Name = "btnTrainers";
            this.btnTrainers.Size = new System.Drawing.Size(215, 39);
            this.btnTrainers.TabIndex = 4;
            this.btnTrainers.Text = "Manage Trainers\n";
            this.btnTrainers.UseVisualStyleBackColor = true;
            this.btnTrainers.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnMembers
            // 
            this.btnMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMembers.Location = new System.Drawing.Point(89, 332);
            this.btnMembers.Name = "btnMembers";
            this.btnMembers.Size = new System.Drawing.Size(231, 39);
            this.btnMembers.TabIndex = 5;
            this.btnMembers.Text = "Manage Members\n";
            this.btnMembers.UseVisualStyleBackColor = true;
            this.btnMembers.Click += new System.EventHandler(this.btnMembers_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(882, 503);
            this.Controls.Add(this.btnMembers);
            this.Controls.Add(this.btnTrainers);
            this.Controls.Add(this.btnSubscriptions);
            this.Controls.Add(this.btnMachines);
            this.Controls.Add(this.btnSports);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Gym Management System";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSports;
        private System.Windows.Forms.Button btnMachines;
        private System.Windows.Forms.Button btnSubscriptions;
        private System.Windows.Forms.Button btnTrainers;
        private System.Windows.Forms.Button btnMembers;
    }
}

