using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NarratorCalendar
{
    public partial class DayDetails : Form
    {
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        private PlanData job;

        public PlanData Job
        {
            get { return job; }
            set { job = value; }
        }


        FlowLayoutPanel fPanel = new FlowLayoutPanel();
        public DayDetails(DateTime date, PlanData job)
        {
            InitializeComponent();
            this.Date = date;
            this.Job = job;

           
            fPanel.Width = pnlEvent.Width; // set lai chieu dai va rong cua cong  viec
            fPanel.Height = pnlEvent.Height;

            pnlEvent.Controls.Add(fPanel);

            

            dtpkDate.Value = Date;
        }

       

        void ShowJobByDate(DateTime date){
            fPanel.Controls.Clear();
            if (job != null && Job.Job != null)
            {
                List<PlanItem> todayJob = GetJobByDay(date); //lay gẹtobbydate
                for (int i = 0; i < todayJob.Count; i++)
                {
                   AddJob(todayJob[i]);
                    
                }
            }
        }
        void AddJob(PlanItem job) 
        {
            AJob aJob = new AJob(job);
                    aJob.Edited += aJob_Edited;
                    aJob.Deleted +=aJob_Deleted;
            fPanel.Controls.Add(aJob);
        }
        private void aJob_Deleted(object sender, EventArgs e)
        {
            AJob uc = sender as AJob;
            PlanItem job = uc.Job;
            fPanel.Controls.Remove(uc);
            Job.Job.Remove(job);
        }

        private void aJob_Edited(object sender, EventArgs e)
        {
            
        }

        List<PlanItem> GetJobByDay(DateTime date) 
        {
            return Job.Job.Where(p=>p.Date.Year== date.Year && p.Date.Month == date.Month && p.Date.Day == date.Day).ToList();
       
        }

        private void dtpkDate_ValueChanged(object sender, EventArgs e)
        {
            ShowJobByDate((sender as DateTimePicker).Value);
        }

        private void DayDetails_Load(object sender, EventArgs e)
        {

        }

        private void btnNextday_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddDays(1);
        }

        private void btnPreviousday_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddDays(-1);
        }

        private void mnsNote_Click(object sender, EventArgs e)
        {
            PlanItem item = new PlanItem() { Date  = dtpkDate.Value };
            Job.Job.Add(item);
            AddJob(item);
        }
        private void mnsItem_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = DateTime.Now;
        }
    }
}
