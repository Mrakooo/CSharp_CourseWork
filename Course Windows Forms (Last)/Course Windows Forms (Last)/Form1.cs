using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Course_Windows_Forms__Last_
{
    

    public partial class Form1 : Form
    {


        private Dictionary<int, Student> DictStudent;
        private Dictionary<int, Teacher> DictTeacher;
        private Deadline Date;

        public Form1()
        {
            InitializeComponent();
        }

        


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.tabPage1.Text = "General information";
            this.tabPage2.Text = "Create new Student";
            this.tabPage3.Text = "Stats";
            this.tabPage5.Text = "Create new Teacher";


            string email = "mrandoksss1@gmail.com";
            Address add = new Address("Ukraine", "Kherson", "Patona", 25);
            Deadline deadline = new Deadline(17, 05, 2023);
            CourseWork coursewk = new CourseWork("Development of software engineering", 
                "About development of software engineering", deadline);

            Student student_1 = new Student(
                "Andrey", 
                "Marchenko", 
                18, add,
                Gender.Male,
                Nation.Ukrainian,
                email, 241,
                ProgrammingLanguage.CSharp,
                coursewk);

            Student student_2 = new Student(
                "Poul",
                "Devis", 
                19,
                new Address("Poland", "Warsaw", "Street", 12),
                Gender.Male,
                Nation.Polish, 
                email, 241,
                ProgrammingLanguage.CSharp,
                coursewk);

            Teacher teacher_1 = new Teacher(
                "Kate",
                "Smith",
                25,
                new Address(
                    "Canada",
                    "Toronto",
                    "Good St.",
                    3),
                Gender.Female,
                Nation.Canadian,
                email, 241);

            DictStudent = new Dictionary<int, Student>();
            DictTeacher = new Dictionary<int, Teacher>();

            AddToDict(DictStudent, student_1);
            AddToDict(DictStudent, student_2);

            AddToDict(DictTeacher, teacher_1);


            InitialTrackBar();
            InitialTrackBarTeacher();
            //InitialTreeView();

            InitialGridView(DictStudent);

            
        }


        private void InitialGridView( Dictionary<int, Student> Dict)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name");
            table.Columns.Add("Surname");
            table.Columns.Add("Age");
            table.Columns.Add("Address");
            table.Columns.Add("Gender");
            table.Columns.Add("Nation");
            table.Columns.Add("Email");
            table.Columns.Add("Group");
            table.Columns.Add("Prog. Lang.");
            table.Columns.Add("Course work");

            for (int i = 0; i < Dict.Count; i++)
            {
                DataRow DRow = table.NewRow();
                DRow[0] = Dict[i].Name;
                DRow[1] = Dict[i].Surname;
                DRow[2] = Dict[i].Age;
                DRow[3] = Dict[i].GetAddress.PrtAddressInfo();
                DRow[4] = Dict[i].GetGender;
                DRow[5] = Dict[i].GetNation;
                DRow[6] = Dict[i].Email;
                DRow[7] = Dict[i].Group;
                DRow[8] = Dict[i].GetProgLang;
                DRow[9] = Dict[i].GetCourseWork.Name + " \n" + Dict[i].GetCourseWork.Deadline.PrtInLine();
                table.Rows.Add(DRow);


            }

            this.dataGridView1.DataSource = table;

        }

        private void CreateStudent()
        {
            try
            {
                int ammount = 10;
                
                string name, surname, country, city, street, email, title, description;
                int age, house, group, day, month, year;
               
                
                name = this.textBoxName.Text;

                surname = this.textBoxSurname.Text;

                age = this.trackBarAge.Value;

                country = this.textBoxCountry.Text;

                city = this.textBoxCity.Text;

                street = this.textBoxStreet.Text;

                house = int.Parse(this.textBoxHouse.Text);

                email = this.textBoxEmail.Text;

                group = int.Parse(this.textBoxGroup.Text);

                title = this.textBoxTitle.Text;

                description = this.richTextBoxDescription.Text;

                day = this.dateTimePickerDeadline.Value.Day;
                month = this.dateTimePickerDeadline.Value.Month;
                year = this.dateTimePickerDeadline.Value.Year;

                Gender gender;
                if (this.radioButtonMale.Checked)
                {
                    gender = Gender.Male;
                }
                else { gender = Gender.Female; }

                Nation nation;
                string check = this.comboBoxNation.SelectedItem.ToString();
                switch (check) //Ukrainian, Polish, German, Canadian
                {
                    case "Ukrainian":
                        nation = Nation.Ukrainian;
                        break;
                    case "Polish":
                        nation = Nation.Polish;
                        break;
                    case "German":
                        nation = Nation.German;
                        break;
                    case "Canadian":
                        nation = Nation.Canadian;
                        break;
                    default: 
                        nation = Nation.Ukrainian;
                        break;
                }

                ProgrammingLanguage progLang;
                string check2 = this.comboBoxProgLang.SelectedItem.ToString();
                switch (check2) //CSharp, Cpp, Python, JS
                {
                    case "CSharp":
                        progLang = ProgrammingLanguage.CSharp;
                        break;
                    case "Cpp":
                        progLang = ProgrammingLanguage.Cpp;
                        break;
                    case "Python":
                        progLang = ProgrammingLanguage.Python;
                        break;
                    case "JS":
                        progLang = ProgrammingLanguage.JS;
                        break;
                    default:
                        progLang = ProgrammingLanguage.CSharp;
                        break;
                }
               
                /*if (check2 == "CSharp") { progLang = ProgrammingLanguage.CSharp; }
                else if(check2 == "Cpp") { progLang = ProgrammingLanguage.Cpp; }
                else if(check2 == "Python") { progLang = ProgrammingLanguage.Python; }
                else { progLang = ProgrammingLanguage.JS; }*/

                Student newStudent = new Student(
                    name,
                    surname,
                    age,
                    new Address(
                        country,
                        city,
                        street,
                        house),
                    gender,
                    nation,
                    email,
                    group, 
                    progLang, 
                    new CourseWork(
                        title, 
                        description,
                        new Deadline(
                            day,
                            month,
                            year)));

                AddToDict(DictStudent, newStudent);

                //this.richTextBox1.Text += "Add new object " + newStudent.PrtInLine() + "\n";
                this.richTextBox2.Text += "Add new object " + newStudent.PrtInLine() + "\n";


                InitialGridView(DictStudent);
                //InitialTreeView();
                
                InitialProgressBar(ammount);
            }
            catch (Exception ex)
            {
                //this.richTextBox1.Clear();
                //this.richTextBox1.Text = "Error: " + ex.Message + " " + ex.Source;
                MessageBox.Show("Error: " + ex.Message + " " + ex.Source);
            }
        }

        private void InitialTrackBar()
        {
            this.trackBarAge.Maximum = 110;
            this.trackBarAge.Minimum = 16;
            this.trackBarAge.Value = 16;
        }


        private void InitialTreeView()
        {
            this.treeView1.Nodes.Clear();
            this.treeView1.Nodes.Add("Teachers");

            for (int i = 0; i < DictTeacher.Count; i++)
            {
                this.treeView1.Nodes[0].Nodes.Add(DictTeacher[i].Name + " " + DictTeacher[i].Surname);
                for (int j = 0; j < DictTeacher[i].DictStudents.Count; j++)
                {

                    this.treeView1.Nodes[0].Nodes[i].Nodes.Add(DictTeacher[i].DictStudents[j].Name + " " + DictTeacher[i].DictStudents[j].Surname);
                    
                    this.treeView1.Nodes[0].Nodes[i].Nodes[j].Nodes.Add(DictTeacher[i].DictStudents[j].GetCourseWork.Name);
                    this.treeView1.Nodes[0].Nodes[i].Nodes[j].Nodes[0].Tag = DictTeacher[i].DictStudents[j].Name + " " + DictTeacher[i].DictStudents[j].Surname;

                    if (IsOutdated(DictTeacher[i].DictStudents[j].GetCourseWork.Deadline, Date)){
                        this.treeView1.Nodes[0].Nodes[i].Nodes[j].BackColor = Color.Coral;
                        DictTeacher[i].DictStudents[j].GetCourseWork.IsOutdue = true;
                    }
                }
            }

            this.treeView1.Nodes.Add("Students without teacher");
            int index = 0;
            for(int i = 0; i < DictStudent.Count; i++)
            {
                
                if (DictStudent[i].IsInTheGroup == false)
                {
                    this.treeView1.Nodes[1].Nodes.Add(DictStudent[i].Name + " " + DictStudent[i].Surname);
                    this.treeView1.Nodes[1].Nodes[index].Tag = "Student";
                    this.treeView1.Nodes[1].Nodes[index].Nodes.Add(DictStudent[i].GetCourseWork.Name);
                    this.treeView1.Nodes[1].Nodes[index].Nodes[0].Tag = DictStudent[i].Name + " " + DictStudent[i].Surname;

                    if (IsOutdated(DictStudent[i].GetCourseWork.Deadline, Date))
                    {
                        this.treeView1.Nodes[1].Nodes[index].BackColor = Color.Coral;
                        DictStudent[i].GetCourseWork.IsOutdue = true;
                    }
                    index++;
                }
               
            }

        }

        private void InitialProgressBar(int ammount)
        {

            this.progressBar1.Value += ammount;

            if (this.progressBar1.Value >= 100) {
                this.buttonOk.Enabled = false;
            }


        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            CreateStudent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.textBoxName.Clear();
            this.textBoxSurname.Clear();
            this.textBoxCountry.Clear();
            this.textBoxCity.Clear();
            this.textBoxStreet.Clear();
            this.textBoxHouse.Clear();
            this.trackBarAge.Value = 16;
            this.labelAgeValue.Text = "0";
            this.radioButtonMale.Checked = false;
            this.radioButtonFemale.Checked = false;
            this.comboBoxNation.ResetText();
            this.comboBoxNation.Text = "Nation";
            this.comboBoxProgLang.ResetText();
            this.comboBoxProgLang.Text = "Programming language";
            this.textBoxTitle.Clear();
            this.richTextBoxDescription.Clear();
            this.dateTimePickerDeadline.ResetText();
            this.textBoxGroup.Clear();

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trackBarAge_Scroll(object sender, EventArgs e)
        {
            
            this.labelAgeValue.Text = this.trackBarAge.Value.ToString();
        }

        private void textBoxGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }



        private void CreateTeacher()
        {
            try
            {
                int ammount = 10;

                string name, surname, country, city, street, email;
                int age, house, group;


                name = this.textBoxNameT.Text;

                surname = this.textBoxSurnameT.Text;

                age = this.trackBarAgeT.Value;

                country = this.textBoxCountryT.Text;

                city = this.textBoxCityT.Text;

                street = this.textBoxStreetT.Text;

                house = int.Parse(this.textBoxHouseT.Text);

                email = this.textBoxEmailT.Text;

                group = int.Parse(this.textBoxGroupT.Text);

                Gender gender;
                if (this.radioButtonMaleT.Checked)
                {
                    gender = Gender.Male;
                }
                else { gender = Gender.Female; }

                Nation nation;
                string check = this.comboBoxNationT.SelectedItem.ToString();
                switch (check) //Ukrainian, Polish, German, Canadian
                {
                    case "Ukrainian":
                        nation = Nation.Ukrainian;
                        break;
                    case "Polish":
                        nation = Nation.Polish;
                        break;
                    case "German":
                        nation = Nation.German;
                        break;
                    case "Canadian":
                        nation = Nation.Canadian;
                        break;
                    default:
                        nation = Nation.Ukrainian;
                        break;
                }


                Teacher newTeacher = new Teacher(
                    name,  
                    surname,  
                    age, 
                    new Address(
                        country,
                        city,
                        street,
                        house), 
                    gender, 
                    nation, 
                    email, 
                    group);

                
                AddToDict(DictTeacher, newTeacher);

                this.richTextBox4.Text += "Add new object " + newTeacher.PrtInLine() + "\n";


                //InitialTreeView();

                InitialProgressBarTeacher(ammount);
                
            }
            catch (Exception ex)
            {
                //this.richTextBox1.Clear();
                //this.richTextBox1.Text = "Error: " + ex.Message + " " + ex.Source;
                MessageBox.Show("Error: " + ex.Message + " " + ex.Source);
            }
        }

        private void InitialTrackBarTeacher()
        {
            this.trackBarAgeT.Maximum = 110;
            this.trackBarAgeT.Minimum = 18;
            this.trackBarAgeT.Value = 18;
        }

        private void InitialProgressBarTeacher(int ammount)
        {

            this.progressBar2.Value += ammount;

            if (this.progressBar2.Value >= 100)
            {
                this.buttonOKT.Enabled = false;
            }


        }

        private void textBoxHouse_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxGroupT_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxHouseT_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void trackBarAgeT_Scroll(object sender, EventArgs e)
        {
            this.labelAgeValueT.Text = this.trackBarAgeT.Value.ToString();
        }

        private void buttonOKT_Click(object sender, EventArgs e)
        {
            CreateTeacher();
        }

        private void buttonExitT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCancelT_Click(object sender, EventArgs e)
        {
            this.textBoxNameT.Clear();
            this.textBoxSurnameT.Clear();
            this.textBoxCountryT.Clear();
            this.textBoxCityT.Clear();
            this.textBoxStreetT.Clear();
            this.textBoxHouseT.Clear();
            this.trackBarAgeT.Value = 18;
            this.labelAgeValueT.Text = "0";
            this.radioButtonMaleT.Checked = false;
            this.radioButtonFemaleT.Checked = false;
            this.comboBoxNationT.ResetText();
            this.comboBoxNationT.Text = "Nation";
            this.textBoxGroupT.Clear();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Date = new Deadline(
                this.dateTimePickerDate.Value.Day,
                this.dateTimePickerDate.Value.Month,
                this.dateTimePickerDate.Value.Year);

            AddStudentsToTeachersList();
            InitialTreeView();
            
            
        }

        private void AddStudentsToTeachersList()
        {
            for (int i = 0; i < DictTeacher.Count; i++)
            {
                DictTeacher[i].ClearStudentList();

                for (int j = 0; j < DictStudent.Count; j++)
                {
                    if (DictTeacher[i].Group == DictStudent[j].Group)
                    {
                        DictTeacher[i].AddStudentToList(DictStudent[j]);
                        DictStudent[j].IsInTheGroup = true;
                    }
                }
            }
        }

        private bool IsOutdated(Deadline deadline, Deadline date)
        {
            if ( date.Year > deadline.Year) { return true; }
            else if ( date.Month > deadline.Month && date.Year == deadline.Year) { return true; }
            else if ( date.Day > deadline.Day && date.Month == deadline.Month) { return true; }
            else { return false; }

        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //this.labelTry.Text = "Vse OK";
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //this.labelTry.Text = this.treeView1.SelectedNode.Tag.ToString();

            if (this.treeView1.SelectedNode.Tag != null)
            {
                string form2_student = this.treeView1.SelectedNode.Tag.ToString();
                string checkStud, form2_title, form2_description, deadlinetext;
                int form2_yearDate, form2_monthDate, form2_dayDate, form2_year, form2_month, form2_day;
                bool IsOutdue = false;

                form2_yearDate = Date.Year;
                form2_monthDate = Date.Month;
                form2_dayDate = Date.Day;

                form2_year = Date.Year;
                form2_month = Date.Month;
                form2_day = Date.Day;

                form2_title = "Not found";
                form2_description = "Not found";
                deadlinetext = form2_day.ToString() + "." + form2_month.ToString() + "." + form2_year.ToString();

                for (int i = 0; i < DictStudent.Count; i++)
                {
                    checkStud = DictStudent[i].Name + " " + DictStudent[i].Surname;

                    if (form2_student == checkStud)
                    {
                        form2_title = DictStudent[i].GetCourseWork.Name;
                        form2_description = DictStudent[i].GetCourseWork.Description;
                        form2_year = DictStudent[i].GetCourseWork.Deadline.Year;
                        form2_month = DictStudent[i].GetCourseWork.Deadline.Month;
                        form2_day = DictStudent[i].GetCourseWork.Deadline.Day;
                        deadlinetext = form2_day.ToString() + "." + form2_month.ToString() + "." + form2_year.ToString();
                        IsOutdue = DictStudent[i].GetCourseWork.IsOutdue;

                        break;
                    }

                }

                Form2 form2 = new Form2(
                    form2_student,
                    form2_title,
                    form2_description,
                    deadlinetext,
                    IsOutdue /*,
                form2_yearDate,
                form2_monthDate, 
                form2_dayDate,
                form2_year,
                form2_month,
                form2_day */);



                form2.ShowDialog();
            }
            
        }

        private void AddToDict(Dictionary<int, Student> DictStudent, Student student)
        {
            int key = DictStudent.Count();
            DictStudent.Add(key, student);
        }

        private void AddToDict(Dictionary<int, Teacher> DictTeacher, Teacher teacher)
        {
            int key = DictTeacher.Count();
            DictTeacher.Add(key, teacher);
        }

        private void buttonWrSt_Click(object sender, EventArgs e)
        {
            WriteTxt("Student");
        }

        private void WriteTxt(string choose) // choose = Student/Teacher
        {
            string result = "";

            try
            {

                if (choose == "Student") {
                    StreamWriter sw = new StreamWriter("C:\\Users\\AND\\source\\repos\\Course Windows Forms (Last)\\Course Windows Forms (Last)\\StudentList.txt");

                    for (int i = 0; i < DictStudent.Count; i++)
                    {
                        result += DictStudent[i].PrtInLine();

                        result += "\n \n";
                    }

                    sw.WriteLine(result);

                    sw.Close();
                }
                else {
                    StreamWriter sw = new StreamWriter("C:\\Users\\AND\\source\\repos\\Course Windows Forms (Last)\\Course Windows Forms (Last)\\TeacherList.txt");

                    for (int i = 0; i < DictTeacher.Count; i++)
                    {
                        result += DictTeacher[i].PrtInLine();

                        result += "\n \n";
                    }

                    sw.WriteLine(result);

                    sw.Close();
                }


            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
            }
            finally
            {
                MessageBox.Show("Executing finally block.");
            }


        }

        private void buttonWrTch_Click(object sender, EventArgs e)
        {
            WriteTxt("Teacher");
        }

        private void buttonRdSt_Click(object sender, EventArgs e)
        {
            ReadTxt("Student");
        }

        private void buttonRdTch_Click(object sender, EventArgs e)
        {
            ReadTxt("Teacher");
        }

        private void ReadTxt(string choose) // choose = Student/Teacher
        {
            string line = "";
            string result = "";

            try
            {
                if (choose == "Student")
                {
                    StreamReader sr = new StreamReader("C:\\Users\\AND\\source\\repos\\Course Windows Forms (Last)\\Course Windows Forms (Last)\\StudentList.txt");

                    while (line != null)
                    {
                        
                        line = sr.ReadLine();
                        result += line + " \n";


                    }
                    sr.Close();

                    this.richTextBoxList.Text = result;
                }
                else
                {
                    StreamReader sr = new StreamReader("C:\\Users\\AND\\source\\repos\\Course Windows Forms (Last)\\Course Windows Forms (Last)\\TeacherList.txt");

                    while (line != null)
                    {

                        line = sr.ReadLine();
                        result += line + " \n";

                    }
                    sr.Close();

                    this.richTextBoxList.Text = result;

                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
            }
            finally
            {
                MessageBox.Show("Executing finally block.");
            }
        }

        private void buttonWriteJSSt_Click(object sender, EventArgs e)
        {

        }
    }
}
