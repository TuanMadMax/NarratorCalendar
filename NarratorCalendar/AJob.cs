using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NarratorCalendar
{
    public partial class AJob : UserControl
    {

        private PlanItem job;
        private DayDetails dayDetails;

        public PlanItem Job
        {
            get { return job; }
            set { job = value; }
        }
        //event sửa
        private event EventHandler edited;
        public event EventHandler Edited
        {
            add {edited += value;}
            remove { edited -= value; }
        }
        //event xóa
        private event EventHandler deleted;
        public event EventHandler Deleted
        {
            add { deleted += value; }
            remove { deleted -= value; }
        }

        public AJob(PlanItem job )// truyền vào đúng công việc
        {
            
            InitializeComponent();
            cbStatus.DataSource = PlanItem.ListStatus; //thí showinfo mới có thể hiển thị được
            this.Job = job;
            ShowInfo();
        }

        public AJob(DayDetails dayDetails)
        {
            // TODO: Complete member initialization
            this.dayDetails = dayDetails;
        }

        void ShowInfo(){
            txbJob.Text = Job.Job;
            nmFromHours.Value = Job.FromTime.X;
            nmFromMinute.Value = Job.FromTime.Y;
            nmToHours.Value = Job.ToTime.X;
            nmToMinute.Value = Job.ToTime.Y;
            cbStatus.SelectedIndex = PlanItem.ListStatus.IndexOf(Job.Status);
            ckbDone.Checked = PlanItem.ListStatus.IndexOf(Job.Status) == (int)EPlanItem.DONE ? true : false;

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        { 
            Job.Job = txbJob.Text;
            Job.FromTime = new Point((int)nmFromHours.Value, (int)nmFromMinute.Value); 
            Job.ToTime = new Point((int)nmToHours.Value, (int)nmToMinute.Value);
            Job.Status = cbStatus.SelectedItem.ToString();

            if(edited != null ){
                edited(this, new EventArgs()); // truyen con len cha
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(deleted != null ){
                deleted(this, new EventArgs());  // truyen con len cha
            }
        }

        private void ckbDone_CheckedChanged(object sender, EventArgs e)
        {
            cbStatus.SelectedIndex = ckbDone.Checked ? (int)EPlanItem.DONE : (int)EPlanItem.DOING;
        }

        private void nmToMinute_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
