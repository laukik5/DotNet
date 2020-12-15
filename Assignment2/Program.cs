using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties_Constructor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------------");
            GeneralManager gm = new GeneralManager("Gundaa", 41, 90000, "Instrumentation", "DairyMilk");
            Console.WriteLine(gm.Name);
            Console.WriteLine(gm.Empno);
            Console.WriteLine(gm.Deptno);
            Console.WriteLine(gm.Basic);
            Console.WriteLine(gm.Designation);
            Console.WriteLine(gm.Perks);
            Console.ReadLine();
            Console.WriteLine("--------------------------------------------");
        }
    }
    public abstract class Employee
    {

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                    Console.WriteLine("Enter Your Name");
                else
                    name = value;
            }
        }

        private int empno;
        public static int empnoCount = 0;
        public int Empno
        {
            get { return empno; }
        }

        private short deptno;
        public short Deptno
        {
            get { return deptno; }
            set
            {
                if (value == 0)
                    Console.WriteLine("Deptno cannot be zero");
                else
                    deptno = value;
            }
        }
        protected decimal basic;
        public abstract decimal Basic
        {
            get;
            set;
        }
        public Employee(String Name = "No-Name", short Deptno = 100,decimal Basic= 10000)
        {
            
            this.Name = Name;
            this.Deptno = Deptno;
            this.Basic = Basic;
        }

        public abstract decimal CalcNetSalary();
    }
    class Manager : Employee
    {
        private string designation;
        public string Designation
        {
            get { return designation; }
            set
            {
                if (value == null)
                    Console.WriteLine("Designation cannot be blank");
                else
                    designation = value;
            }
        }
        public override decimal Basic
        {
            get { return basic; }
            set
            {
                if (value > 100000 && value < 1000000)
                    Console.WriteLine("Salary is High");
                else
                    basic = value;
            }
        }
        public Manager(String Name = "No-Name", short Deptno = 100, decimal Basic = 10000, string Designation="Default") : base(Name, Deptno, Basic)
        {
          
            this.Designation = Designation;
        }

        public override decimal CalcNetSalary()
        {
            return 12 * basic;
        }



    }
    class GeneralManager : Manager
    {
        private string perks;
        public string Perks
        {
            get { return perks; }
            set
            {
                if (value == null)
                    Console.WriteLine("Perks cannot be blank");
                else
                    perks = value;
            }
        }
        public override decimal Basic
        {
            get { return basic; }
            set
            {
                if (value < 1000 && value < 10000)
                    Console.WriteLine("Salary is Low");
                else
                    basic = value;
            }
        }
        public GeneralManager(String Name = "No-Name", short Deptno = 100, decimal Basic = 10000, string Designation="Default", string Perks="Default") : base(Name, Deptno, Basic, Designation)
        {
            
            this.Perks = Perks;
        }
        public override decimal CalcNetSalary()
        {
            return (12 * basic) + 10000;
        }

    }
}
