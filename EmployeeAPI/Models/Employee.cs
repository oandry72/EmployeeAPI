using System;
namespace EmployeeAPI.Models
{
    public class Employee
    {
        public long emp_no { get; set; }
        public DateTime birth_date { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public char gender { get; set; }
        public DateTime hire_date { get; set; }
    }
}
