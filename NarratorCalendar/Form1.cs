using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace NarratorCalendar
{
    public partial class Form1 : Form
    {

        #region Properties Matix
        

        private int appTime;

        public int AppTime
        {
            get { return appTime; }
            set { appTime = value; }
        }

        private string filePath = "data.xml";

        private List<List<Button>> matrix;

        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }
        private PlanData job;

        public PlanData Job
        {
            get { return job; }
            set { job = value; }
        }
        private List<string> dateOfWeek = new List<string>(){ "Monday", "Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday"};

        #endregion
        public Form1()
        {
            InitializeComponent();
            tmNotify.Start();

            appTime = 0;

            LoadMatrix();
            try
            {
                Job = DeserializeFromXML(filePath) as PlanData; // de hien thi job torng ngay duoc chon
            }
            catch {
                setDefaultJob();
            }
        }
        void setDefaultJob() 
        {
            Job = new PlanData();
            Job.Job = new List<PlanItem>();
            Job.Job.Add(new PlanItem()
            {
                Date = DateTime.Now,
                FromTime = new Point(4, 0),
                ToTime = new Point(7, 0),
                Job = "A demo job",
                Status = PlanItem.ListStatus[(int)EPlanItem.COMING]
            });
           
        }

        void LoadMatrix()
        {
            Matrix = new List<List<Button>>();
            Button OldBtn = new Button(){Width = 0, Height = 0, Location = new Point(-Cons.margin,0)};
            for (int i = 0; i < Cons.DayOfColumm; i++ )
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j < Cons.DayOfWeek; j++)
                {
                    Button btn = new Button(){Width =Cons.dateButtonWidth , Height = Cons.dateButtonHeight};
                    btn.Location = new Point(OldBtn.Location.X + OldBtn.Width + Cons.margin, OldBtn.Location.Y);
                    btn.Click+=btn_Click;


                    pnlMatrix.Controls.Add(btn);
                    //add danh sach button
                    Matrix[i].Add(btn);

                    OldBtn = btn;
                }
                OldBtn = new Button() { Width = 0, Height = 0, Location = new Point(-Cons.margin, OldBtn.Location.Y + Cons.dateButtonHeight) };
            }
            SetDefaultDate();
            
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty((sender as Button).Text)){
                return;
            }
            DayDetails detail = new DayDetails(new DateTime(dtpkDate.Value.Year, dtpkDate.Value.Month,Convert.ToInt32((sender as Button).Text)), Job); //(truyền vào ngày được chọn)
            detail.ShowDialog();
        }

        //tự tạo hàm các ngày của tháng
        int DayOfMonth(DateTime date) {
            switch (date.Month)
            { 
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    if (date.Year % 4 == 0 && date.Year % 100 != 0 || date.Year % 400 == 0)
                    {
                        return 29;
                    }
                    else {
                        return 28;
                    }
                    break;
                default:
                    return 30;
            }
        }
        void AddNumberIntoMatrixByDate(DateTime date) // xác định tháng nào của năm nào
        {
            ClearMatrix();
            DateTime useDate = new DateTime(/*truyền vào năm.tháng.ngày*/ date.Year, date.Month, 1);
            //ngày đó là thứ mấy trong tuần :

            //xác định theo hàng từ hàng đàu tiên nên bằng 0
            int line = 0;
            //in các số ngày ra:
            //bòng lặp xác định tháng có bao nhiêu ngày
            for (int i = 1; i <= DayOfMonth(date); i++)
            {
                //xác định theo cột 
                int column = dateOfWeek.IndexOf(useDate.DayOfWeek.ToString());// từ chuỗi xđ cột
                Button btn = Matrix[line][column];
                btn.Text = i.ToString();
                //đặt màu ho ngày hôm nay
                if (isEqualDate(useDate ,DateTime.Now))
                {
                    btn.BackColor = Color.Pink;
                }

                //đến cuối tuần thì line xuống dòng
                if (column >= 6)
                {
                    line++;
                }
                useDate = useDate.AddDays(1);
            }

        }

            //so sánh ngày
            bool isEqualDate(DateTime dateA, DateTime dateB)
            {
                return dateA.Year == dateB.Year && dateA.Month == dateB.Month && dateA.Day == dateB.Day;
            }




        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnFriday_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        void ClearMatrix()
        {
            for (int i = 0; i < Matrix.Count; i++ )
            {
                for (int j = 0; j < Matrix[i].Count;j++ )
                {
                    Button btn = Matrix[i][j];
                    btn.Text = "";
                    btn.BackColor = Color.WhiteSmoke;
                }
            }
        }

        void SetDefaultDate() {
            dtpkDate.Value = DateTime.Now;
        }
        private void dtpkDate_ValueChanged(object sender, EventArgs e)
        {
            AddNumberIntoMatrixByDate((sender as DateTimePicker).Value);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddMonths(1);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddMonths(-1);
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            SetDefaultDate();
        }


        //khi chuong tring dong
        private void SerializeToXML(object data, string filePath){

            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write); 
            XmlSerializer sr = new XmlSerializer(typeof(PlanData)); // lấy dữ liệu filePath lên thanh PlanData


            sr.Serialize(fs, data); //luu du lieu
            fs.Close();
        }

        //khi chuong trinh vua mo len nam trong form duoi LoadMatrix
        private object DeserializeFromXML(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try { 
                
            
                XmlSerializer sr = new XmlSerializer(typeof(PlanData));

                object result = sr.Deserialize(fs);
                fs.Close();
                return result; 
            }
            catch(Exception e)
            {
                fs.Close();
                throw new NotImplementedException();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SerializeToXML(Job, filePath);
        }

        private void tmNotify_Tick(object sender, EventArgs e)
        {
            if(!ckbNotify.Checked){
                return;
            }
            AppTime++;
            if(AppTime < Cons.notifyTime){
                return;
            }
            if(Job == null || Job.Job == null){
                return;
            }
            DateTime currentDate =  DateTime.Now;
            List<PlanItem> todayjobs = Job.Job.Where(p=>p.Date.Year == currentDate.Year && p.Date.Month == currentDate.Month && p.Date.Day == currentDate.Day).ToList(); // đi hết danh sách tìm nao thõa dk
            Notify.ShowBalloonTip(Cons.notifyTimeOut, "Lịch công việc",string.Format("Bạn có {0} sự kiện trong ngày hôm nay", todayjobs.Count), ToolTipIcon.Info);

            AppTime = 0;// nếu bằng time đó thì reset
        }

        private void nmNotify_ValueChanged(object sender, EventArgs e)
        {
            Cons.notifyTime = (int)nmNotify.Value;
        }

        private void ckbNotify_CheckedChanged(object sender, EventArgs e)
        {
            nmNotify.Enabled = ckbNotify.Checked;
        }
    }
}
