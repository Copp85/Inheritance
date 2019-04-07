using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_1
{
    public class Nurse : Employee
    {
        public int Grade { get; set; }
        public string Specialism { get; set; }

        public Nurse(string name, string address, string phone, int grade, string specialism)
            : base (name, address, phone)
        {
            Grade = grade;
            Specialism = specialism;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("\nSpecialism {0}\nGrade {1}\n", Specialism, Grade);
        }

        public override string FileFormat()
        {
            return string.Format("{0},{1},{2},{3},{4}", Name, Address, PhoneNumber, Specialism, Grade);
        }

        public override decimal GetMonthlySalary()
        {
            return Salary / 12m;
        }
    }
}
