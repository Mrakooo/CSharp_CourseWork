using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Windows_Forms__Last_
{

    enum ProgrammingLanguage {CSharp, Cpp, Python, JS};

    class Student : Human
    {
        private int _group;
        private ProgrammingLanguage _progLang;
        private CourseWork _courseWork;
        private bool _IsInTheGroup = false;

        public Student(string name,
            string surname, 
            int age,
            Address address,
            Gender gender,
            Nation nation, 
            string email, 
            int group,
            ProgrammingLanguage progLang,
            CourseWork courseWork) : base(name,
                surname, 
                age,
                address,
                gender,
                nation, 
                email)
        {
            this._group = group;
            this._progLang = progLang;
            this._courseWork = courseWork;
        }

        public string PrtInLine()
        {
            string result = base.PrtInLine() + "\n" + _group + "\n"
                + _progLang + "\n" + _courseWork.Name + "\n" 
                + _courseWork.Description + "\n" 
                + _courseWork.Deadline.Day + "." + _courseWork.Deadline.Month + "." + _courseWork.Deadline.Year;
            return result;
        }


        public int Group
        {
            get { return _group; }
            set { _group = value; }
        }

        public ProgrammingLanguage GetProgLang
        {
            get { return _progLang; }
            set { _progLang = value; }
        }

        public CourseWork GetCourseWork
        {
            get { return _courseWork; }
            set { _courseWork = value; }
        }

        public bool IsInTheGroup
        {
            get { return _IsInTheGroup; }
            set { _IsInTheGroup = value; }

        }

    }
}
