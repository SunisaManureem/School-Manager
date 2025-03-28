using System;

namespace SchoolManager.Members
{
    public class Principal : SchoolMember
    {
        public Principal(string name, string address, string phone) 
            : base(name, address, phone) { }

        public void ManageSchool()
        {
            Console.WriteLine($"{Name} is managing the school.");
        }
    }
}
