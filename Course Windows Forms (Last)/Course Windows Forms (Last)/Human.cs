using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Windows_Forms__Last_
{

    enum Gender { Male, Female};
    enum Nation { Ukrainian, Polish, German, Canadian}

    class Human
    {
        private string _name;
        private string _surname;
        private int _age;
        private Address _address;
        private Gender _gender;
        private Nation _nation;
        private string _email;

        public Human(string name, string surname, int age, Address address, Gender gender, Nation nation, string email)
        {
            this._name = name;
            this._surname = surname;
            this._age = age;
            this._address = address;
            this._gender = gender;
            this._nation = nation;
            this._email = email;
        }



        public string Name
        {
            get { return _name; }
            set { _name = value; }

        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public Address GetAddress
        {
            get { return _address; }
            set { _address = value; }
        }

        public Gender GetGender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public Nation GetNation
        {
            get { return _nation; }
            set { _nation = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }



        public string PrtInLine()
        {
            string result = "Name: " + _name + "\n" + "Surname: " + _surname + "\n" + "Age: " + _age + "\n" + _address.PrtAddressInfo() + "\n" + _gender + "\n" + _nation + "\n" + _email;
            return result;
        }
    }
}
