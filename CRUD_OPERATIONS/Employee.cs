using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_OPERATIONS
{
    [Table("Employee_Table")]
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string father { get; set; }
        public string street { get; set; }
        public int age { get; set; }
        public bool gender { get; set; }
        public string passport_no { get; set; }
        public bool marital_status { get; set; }

        public DateTime? start_work { get; set; }
        public DateTime? end_work { get; set; }









    }
}
