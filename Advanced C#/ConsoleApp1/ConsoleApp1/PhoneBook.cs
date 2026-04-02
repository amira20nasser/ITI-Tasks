using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class PhoneBook
    {
        private Dictionary<string , int> _nameToPhone = new Dictionary<string , int>();
        private Dictionary<int , string> _phoneToName = new Dictionary<int , string>();

        public int this[string name]
        {
            get { 
                if (_nameToPhone.ContainsKey(name)) return _nameToPhone[name];
                throw new Exception("this name doesn't exist"); 
            }
            set
            {
                if (name.IsWhiteSpace() || name == null)
                {
                    throw new Exception("Invalid setting index to null or empty");
                }
                if (value <= 0)
                {
                    throw new Exception("phone number must be greater than zero");

                }
                if (_nameToPhone.ContainsKey(name)) 
                    Console.WriteLine("You Overwriting this contact");
                _nameToPhone[name] = value;
                _phoneToName[value] = name;
            }
        }

        public string this[int phone]
        {
            get
            {
                if (_phoneToName.ContainsKey(phone)) { return _phoneToName[phone]; }
                throw new Exception("This phone doesn't exist");
            }
            set
            {
                if (value.IsWhiteSpace() || value == null)
                {
                    throw new Exception("Invalid setting index to null or empty");
                }
                if (phone <= 0)
                {
                    throw new Exception("phone number must be greater than zero");

                }
                _phoneToName[phone] = value;
                _nameToPhone[value] = phone;
            }
        }
    }
}
