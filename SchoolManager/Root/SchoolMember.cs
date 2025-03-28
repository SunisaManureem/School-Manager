using System;

namespace SchoolManager
{
    public class SchoolMember
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; } // เปลี่ยนจาก int เป็น string

        // Constructor
        public SchoolMember(string name, string address, string phone)
        {
            Name = name;
            Address = address;
            Phone = phone;
        }

        public virtual void Display()
        {
            Console.WriteLine($"Name: {Name}, Address: {Address}, Phone: {Phone}");
        }
    }
}
