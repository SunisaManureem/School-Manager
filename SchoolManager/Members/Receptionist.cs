using System;

namespace SchoolManager.Members
{
    public class Receptionist : SchoolMember
    {
        // Constructor that passes parameters to the base class (SchoolMember)
        public Receptionist(string name, string address, string phone) : base(name, address, phone)
        {
        }

        // Method to simulate payment for the receptionist
        public void Pay()
        {
            Console.WriteLine($"Paying receptionist {Name}");
        }

        // Method to handle complaints
        public void HandleComplaint()
        {
            string complaint = Helper.ConsoleHelper.AskQuestion("Please enter your complaint: ");
            Console.WriteLine($"Complaint received: {complaint}");
        }

        // Override Display method
        public override void Display()
        {
            base.Display();
            Console.WriteLine("This is a receptionist.");
        }
    }
}
