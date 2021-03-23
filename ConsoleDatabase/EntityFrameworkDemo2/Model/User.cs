using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo2.Model
{
    class User
    {
        private int _id;
        private string _name;
        private string _hobby;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Hobby { get => _hobby; set => _hobby = value; }
    }
}
