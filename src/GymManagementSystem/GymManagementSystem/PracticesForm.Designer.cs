using System.Windows.Forms;

namespace GymManagementSystem
{
    partial class PracticesForm : Form // غير الاسم حسب الفورم
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 680);
            this.Name = "PracticesForm"; // غير الاسم حسب الفورم
            this.ResumeLayout(false);
        }
    }
}