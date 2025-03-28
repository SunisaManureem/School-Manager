using System;
using System.Collections.Generic;

namespace SchoolManager.Members
{
    public class Student : SchoolMember
    {
        public string StudentID { get; set; }
        public double Grade { get; set; }

        public Student(string name, string address, string phone, double grade, string studentID)
            : base(name, address, phone)
        {
            this.StudentID = studentID;
            this.Grade = grade;
        }

        // ฟังก์ชันเพื่อคำนวณค่าเฉลี่ยของเกรด
        public static double AverageGrade(List<Student> students)
        {
            if (students.Count == 0)
            {
                return 0; // ถ้าไม่มีนักเรียนใน List จะคืนค่า 0
            }

            double totalGrade = 0;
            foreach (var student in students)
            {
                totalGrade += student.Grade; // คำนวณเกรดรวม
            }
            return totalGrade / students.Count; // คำนวณค่าเฉลี่ย
        }

        public override void Display()
        {   
            Console.WriteLine($"Student {Name}, ID: {StudentID}, Grade: {Grade}");
        }

    }
}
