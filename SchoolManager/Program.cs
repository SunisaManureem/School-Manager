using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolManager.Members;  // Correct namespace for members

namespace SchoolManager
{
    public class Program
    {
        static public List<Student> Students = new List<Student>();
        static public List<Student> NewStudents = new List<Student>();
        static public List<Teacher> Teachers = new List<Teacher>();
        static public Principal Principal = new Principal("John", "School Address", "123");
        static public Receptionist Receptionist = new Receptionist("Jane", "School Address", "124");

        public static SchoolMember AcceptAttributes()
        {
            // รับค่า phone เป็น string แทนที่จะเป็น int
            SchoolMember member = new SchoolMember(
                Helper.ConsoleHelper.AskQuestion("Enter name: "),
                Helper.ConsoleHelper.AskQuestion("Enter address: "),
                Helper.ConsoleHelper.AskQuestion("Enter phone number: ")  // รับเบอร์โทรศัพท์เป็น string
            );
            return member;
        }

        private static int acceptChoices()
        {
            return Helper.ConsoleHelper.AskQuestionInt("\n1. Add\n2. Display\n3. Pay\n4. Raise Complaint\n5. Student Performance\n6. Search Member\nPlease enter your choice: ");
        }

        private static int acceptMemberType()
        {
            return Helper.ConsoleHelper.AskQuestionInt("\nSelect member type:\n1. Principal\n2. Teacher\n3. Student\nEnter your choice: ");
        }

        private static void addData()
        {
            Receptionist = new Receptionist("Receptionist", "address", "123");
            Principal = new Principal("Principal", "address", "123");

            // สามารถลบการเพิ่มข้อมูลตัวอย่างออกได้
            // for (int i = 0; i < 10; i++)
            // {
            //     Students.Add(new Student(i.ToString(), i.ToString(), i.ToString(), i));
            //     Teachers.Add(new Teacher(i.ToString(), i.ToString(), i.ToString()));
            // }
        }

        public static void Add()
        {
            int memberType = acceptMemberType();
            switch (memberType)
            {
                case 1:
                    addPrincipal();  // เพิ่มการเพิ่ม Principal
                    break;
                case 2:
                    addTeacher();
                    break;
                case 3:
                    addStudent();
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }

        private static void addPrincipal()
        {
            // รับข้อมูลพื้นฐานของ Principal จากฟังก์ชัน AcceptAttributes
            SchoolMember member = AcceptAttributes();

            // สร้าง Principal ใหม่
            Principal newPrincipal = new Principal(member.Name, member.Address, member.Phone);

            // กำหนดให้ Principal ใหม่เป็นค่า Principal ที่ใช้งาน
            Principal = newPrincipal;
            Console.WriteLine("Principal added successfully.");
        }

        private static void addTeacher()
        {
            // รับข้อมูลพื้นฐานของครูจากฟังก์ชัน AcceptAttributes
            SchoolMember member = AcceptAttributes();

            // ให้ผู้ใช้กรอกวิชาที่ครูสอน
            string subject = Helper.ConsoleHelper.AskQuestion("Enter subject taught by the teacher: ");

            // รับเงินเดือนของครู
            double salary = Helper.ConsoleHelper.AskQuestionDouble("Enter salary for the teacher: ");

            // สร้างครูใหม่พร้อมวิชาที่สอนและเงินเดือน
            Teacher newTeacher = new Teacher(member.Name, member.Address, member.Phone, subject, salary);

            // เพิ่มครูใหม่ไปยัง List ของครู
            Teachers.Add(newTeacher);
            Console.WriteLine("Teacher added successfully.");
        }

        private static void addStudent()
        {
            // รับข้อมูลพื้นฐานของนักเรียนจากฟังก์ชัน AcceptAttributes
            SchoolMember member = AcceptAttributes();

            // ให้ผู้ใช้กรอก Student ID
            string studentID = Helper.ConsoleHelper.AskQuestion("Enter student ID: ");  // กรอกรหัสนักเรียน

            // กรอกเกรด (ต้องตรวจสอบว่าเกรดที่กรอกไม่เป็น 0 หรือค่าว่าง)
            double grade = Helper.ConsoleHelper.AskQuestionDouble("Enter grade: "); // เปลี่ยนเป็น AskQuestionDouble()
            while (grade <= 0) 
            {
                Console.WriteLine("Grade must be greater than 0. Please enter again.");
                grade = Helper.ConsoleHelper.AskQuestionDouble("Enter grade: "); // เปลี่ยนเป็น AskQuestionDouble()
            }

            // สร้างนักเรียนใหม่พร้อมเกรดและรหัสนักเรียน
            Student newStudent = new Student(member.Name, member.Address, member.Phone, grade, studentID);

            // เพิ่มนักเรียนใหม่ไปยัง List ของนักเรียน
            Students.Add(newStudent);
            NewStudents.Add(newStudent);

            Console.WriteLine("Student added successfully.");
        }

        public static void display()
        {
            int displayChoice = Helper.ConsoleHelper.AskQuestionInt("\nSelect what you want to display:\n1. Students\n2. Teachers\n3. Principal\nEnter your choice: ");
    
            switch (displayChoice)
            {
                case 1:
                    // แสดงข้อมูลนักเรียน
                    Console.WriteLine("\nThe students added manually are:");
                    foreach (Student student in NewStudents)
                        student.Display();
                    break;

                case 2:
                    // แสดงข้อมูลครู
                    Console.WriteLine("\nThe teachers added manually are:");
                    foreach (Teacher teacher in Teachers)
                        teacher.Display();  // เพิ่มการแสดงข้อมูลของครูพร้อมวิชาที่สอนและเงินเดือน
                    break;

                case 3:
                    // แสดงข้อมูล Principal
                    Console.WriteLine("\nThe principal is:");
                    Principal.Display();
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        public static void Pay()
        {
            Console.WriteLine("\nPayments in progress...");
            foreach (Teacher teacher in Teachers)
            {
                teacher.Pay(); // Call the Pay method for teachers
            }
            Receptionist.Pay(); // Call the Pay method for receptionist
            Console.WriteLine("Payments completed.");
        }

        public static void RaiseComplaint()
        {
            Receptionist.HandleComplaint(); // Handle complaints through receptionist
        }

        private static async Task showPerformance()
        {
            double average = await Task.Run(() => Student.AverageGrade(Students));
            Console.WriteLine($"The student average performance is: {average}");
        }

        // ฟังก์ชันค้นหาสมาชิก
        public static void SearchMember()
        {
            string searchTerm = Helper.ConsoleHelper.AskQuestion("Enter name or ID to search: ");
            
            // ค้นหานักเรียนตามชื่อหรือรหัสนักเรียน
            var foundStudents = Students.FindAll(s => s.Name.Contains(searchTerm) || s.StudentID.Contains(searchTerm));
            
            // ค้นหาครูตามชื่อ
            var foundTeachers = Teachers.FindAll(t => t.Name.Contains(searchTerm));
            
            // ค้นหาผู้อำนวยการตามชื่อ
            var foundPrincipal = Principal.Name.Contains(searchTerm) ? new List<Principal> { Principal } : new List<Principal>();

            // แสดงผลการค้นหาผู้อำนวยการ
            if (foundPrincipal.Count > 0)
            {
                Console.WriteLine("\nFound Principal:");
                foreach (var principal in foundPrincipal)
                {
                    principal.Display();
                }
            }

            // แสดงผลการค้นหาครู
            if (foundTeachers.Count > 0)
            {
                Console.WriteLine("\nFound Teachers:");
                foreach (var teacher in foundTeachers)
                {
                    teacher.Display();
                }
            }

            // แสดงผลการค้นหานักเรียน
            if (foundStudents.Count > 0)
            {
                Console.WriteLine("\nFound Students:");
                foreach (var student in foundStudents)
                {
                    student.Display();
                }
            }
            else
            {
                // ถ้าไม่พบสมาชิกใด ๆ
                Console.WriteLine("No members found.");
            }
        }

        public static async Task Main(string[] args)
        {
            addData(); // Adding initial data

            Console.WriteLine("-------------- Welcome ---------------\n");

            bool flag = true;
            while (flag)
            {
                int choice = acceptChoices();
                switch (choice)
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        display();
                        break;
                    case 3:
                        Pay();
                        break;
                    case 4:
                        RaiseComplaint();
                        break;
                    case 5:
                        await showPerformance();
                        break;
                    case 6:
                        SearchMember();  // เรียกใช้ฟังก์ชันค้นหาสมาชิก
                        break;
                    default:
                        flag = false;
                        break;
                }
            }

            Console.WriteLine("\n-------------- Bye --------------");
        }
    }
}
