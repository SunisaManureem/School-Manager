using System;

namespace SchoolManager.Members
{
    public class Teacher : SchoolMember
    {
        public string Subject { get; set; }
        public double Salary { get; set; }

        public Teacher(string name, string address, string phone, string subject, double salary)
            : base(name, address, phone)
        {
            this.Subject = subject;
            this.Salary = salary;
        }

        public void Pay()
        {
            Console.WriteLine($"Paying teacher {Name} for teaching {Subject}. Salary: {Salary}");
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"This teacher teaches {Subject} with a salary of {Salary}");
        }
    }
}
