using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class SinhVien
    {
        private String _id;
        private String _Name;
        private String _sex;
        private DateTime _dateOfbirth;
        private String _address;
        private String _phonenumber;

        public SinhVien()
        {
        }

        public SinhVien(string id, string name, string sex, DateTime dateOfbirth, string address, string phonenumber)
        {
            _id = id;
            _Name = name;
            _sex = sex;
            _dateOfbirth = dateOfbirth;
            _address = address;
            _phonenumber = phonenumber;
        }

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string Sex { get => _sex; set => _sex = value; }
        public DateTime DateOfbirth { get => _dateOfbirth; set => _dateOfbirth = value; }
        public string Address { get => _address; set => _address = value; }
        public string Phonenumber { get => _phonenumber; set => _phonenumber = value; }
    }
}
