using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_Windows_Forms__Last_
{
    public partial class Form2 : Form
    {

        private string _student;
        private string _title;
        private string _description;
        private Deadline _deadline;
        private Deadline _date;
        private string _deadlinetext;
        private bool _IsOutdue;


        public Form2()
        {
            InitializeComponent();
        }


        private void Form2_Load(object sender, EventArgs e)
        {

            this.textBoxStudent.Text = _student;
            this.textBoxTitle.Text = _title;
            this.richTextBoxDescription.Text = _description;
            this.dateTimePickerDeadline.Text = _deadlinetext;
            this.pictureBox1.Visible = _IsOutdue;

            //if (IsOutdated(_deadline, _date)) { this.pictureBox1.Visible = true; }
            //new DateTime(_deadline.Year, _deadline.Month, _deadline.Day);
        }


        public Form2(
            string student,
            string title,
            string description,
            string deadlinetext,
            bool IsOutdue /*,
            int yearDate, 
            int monthDate,
            int dayDate,
            int year, 
            int month,
            int day*/ )
        {
            InitializeComponent();

            this._student = student;
            this._title = title;
            this._description = description;
            this._deadlinetext = deadlinetext;
            this._IsOutdue = IsOutdue;
            /*this._date.Year = yearDate;
            this._date.Month = monthDate;
            this._date.Day = dayDate;
            this._deadline.Year = year;
            this._deadline.Month = month;
            this._deadline.Day = day;*/
        }

        private bool IsOutdated(Deadline deadline, Deadline date)
        {
            if (date.Year > deadline.Year) { return true; }
            else if (date.Month > deadline.Month) { return true; }
            else if (date.Day > deadline.Day) { return true; }
            else { return false; }

        }

        public string Student
        {
            get { return _student; }
            set { _student = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*
        public Deadline Deadline
        {
            get { return _deadline; }
            set { _deadline = value; }
        }

        public Deadline Date
        {
            get { return _date; }
            set { _date = value; }
        }
        */

    }
}
