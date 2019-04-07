using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_1
{
    public enum PositionType { Junior, Senior, Student }

    public class Doctor : Employee
    {
        public PositionType Position { get; set; }

        public Doctor(string name, string address, string phone, PositionType position)
            : base(name, address, phone)
        {
            Position = position;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("\nPosition {0} \n", Position);
        }

        public override string FileFormat()
        {
            return string.Format("{0},{1},{2},{3}", Name, Address, PhoneNumber, Position);
        }

        public override decimal GetMonthlySalary()
        {
            return (Salary / 12m) + 1000m;
        }
    }
}
