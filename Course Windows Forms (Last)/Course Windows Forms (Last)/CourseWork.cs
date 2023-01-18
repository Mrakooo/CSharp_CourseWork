using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Windows_Forms__Last_
{
    class CourseWork
    {
        private string _name;
        private string _description;
        private Deadline _deadline;
        private bool _IsOutdue;

        public CourseWork(string name, string description, Deadline deadline)
        {
            this._name = name;
            this._description = description;
            this._deadline = deadline;
        }

        public string PrtInLine()
        {
            string result = _name + "\n" + _description;
            return result;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public Deadline Deadline
        {
            get { return _deadline; }
            set { _deadline = value; }
        }

        public bool IsOutdue
        {
            get { return _IsOutdue; }
            set { _IsOutdue = value; }
        }
    }
}
