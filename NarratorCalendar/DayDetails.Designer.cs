namespace NarratorCalendar
{
    partial class DayDetails
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnPreviousday = new System.Windows.Forms.Button();
            this.btnNextday = new System.Windows.Forms.Button();
            this.dtpkDate = new System.Windows.Forms.DateTimePicker();
            this.pnlEvent = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnsNote = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.pnlEvent);
            this.panel1.Location = new System.Drawing.Point(12, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 347);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnPreviousday);
            this.panel3.Controls.Add(this.btnNextday);
            this.panel3.Controls.Add(this.dtpkDate);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(730, 27);
            this.panel3.TabIndex = 1;
            // 
            // btnPreviousday
            // 
            this.btnPreviousday.AutoSize = true;
            this.btnPreviousday.Location = new System.Drawing.Point(3, 3);
            this.btnPreviousday.Name = "btnPreviousday";
            this.btnPreviousday.Size = new System.Drawing.Size(60, 23);
            this.btnPreviousday.TabIndex = 3;
            this.btnPreviousday.Text = "Hôm qua";
            this.btnPreviousday.UseVisualStyleBackColor = true;
            this.btnPreviousday.Click += new System.EventHandler(this.btnPreviousday_Click);
            // 
            // btnNextday
            // 
            this.btnNextday.AutoSize = true;
            this.btnNextday.Location = new System.Drawing.Point(666, 1);
            this.btnNextday.Name = "btnNextday";
            this.btnNextday.Size = new System.Drawing.Size(61, 23);
            this.btnNextday.TabIndex = 2;
            this.btnNextday.Text = "Ngày mai";
            this.btnNextday.UseVisualStyleBackColor = true;
            this.btnNextday.Click += new System.EventHandler(this.btnNextday_Click);
            // 
            // dtpkDate
            // 
            this.dtpkDate.Location = new System.Drawing.Point(223, 4);
            this.dtpkDate.Name = "dtpkDate";
            this.dtpkDate.Size = new System.Drawing.Size(209, 20);
            this.dtpkDate.TabIndex = 1;
            this.dtpkDate.ValueChanged += new System.EventHandler(this.dtpkDate_ValueChanged);
            // 
            // pnlEvent
            // 
            this.pnlEvent.Location = new System.Drawing.Point(3, 36);
            this.pnlEvent.Name = "pnlEvent";
            this.pnlEvent.Size = new System.Drawing.Size(727, 308);
            this.pnlEvent.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsNote,
            this.mnsItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(760, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnsNote
            // 
            this.mnsNote.Name = "mnsNote";
            this.mnsNote.Size = new System.Drawing.Size(74, 20);
            this.mnsNote.Text = "Thêm việc";
            this.mnsNote.Click += new System.EventHandler(this.mnsNote_Click);
            // 
            // mnsItem
            // 
            this.mnsItem.Name = "mnsItem";
            this.mnsItem.Size = new System.Drawing.Size(68, 20);
            this.mnsItem.Text = "Hôm nay";
            this.mnsItem.Click += new System.EventHandler(this.mnsItem_Click);
            // 
            // DayDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 384);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DayDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết";
            this.Load += new System.EventHandler(this.DayDetails_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dtpkDate;
        private System.Windows.Forms.Panel pnlEvent;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnsNote;
        private System.Windows.Forms.ToolStripMenuItem mnsItem;
        private System.Windows.Forms.Button btnPreviousday;
        private System.Windows.Forms.Button btnNextday;
    }
}