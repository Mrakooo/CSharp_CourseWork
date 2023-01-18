using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Windows_Forms__Last_
{
    class Teacher : Human
    {
        private int _group;
        private Dictionary<int, Student> DictStudent;
        


        public Teacher(string name,
            string surname,
            int age,
            Address address,
            Gender gender,
            Nation nation,
            string email,
            int group) : base(name,
                surname,
                age,
                address,
                gender,
                nation,
                email)
        {
            this._group = group;
            DictStudent = new Dictionary<int, Student>();
        }

        public void ClearStudentList()
        {
            DictStudent.Clear();
        }

        public void AddStudentToList(Student student)
        {
            int key = DictStudent.Count();
            DictStudent.Add(key, student);

        }

        public string PrtInLine()
        {
            string result = base.PrtInLine() + "\n" + _group  + "\n";
            return result;
        }


        public int Group
        {
            get { return _group; }
            set { _group = value; }
        }

        public Dictionary<int, Student> DictStudents
        {
            get { return DictStudent; }
            set { DictStudent = value; }
        }


    }
}
