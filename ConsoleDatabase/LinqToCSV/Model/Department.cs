using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToCSV.Model
{
    class Department
    {
        private int _deptNo;
        private string _deptName;
        private string _location;

        public int DeptNo { get => _deptNo; set => _deptNo = value; }
        public string DeptName { get => _deptName; set => _deptName = value; }
        public string Location { get => _location; set => _location = value; }
    }
}
