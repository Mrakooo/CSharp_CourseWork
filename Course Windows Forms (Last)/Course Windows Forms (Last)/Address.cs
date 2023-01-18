using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Windows_Forms__Last_
{
    class Address
    {
        private string _country;
        private string _city;
        private string _street;
        private int _house;


        public Address(string country, string city, string street, int house)
        {
            this._country = country;
            this._city = city;
            this._street = street;
            this._house = house;
        }

        public string PrtAddressInfo()
        {
            string result = _country + " " + _city + " " + _street + " " + _house;
            return result;
        }
    }
}
