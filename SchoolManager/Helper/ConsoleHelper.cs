using System;

namespace SchoolManager.Helper
{
    public static class ConsoleHelper
    {
        // ฟังก์ชันเพื่อถามคำถามและรับคำตอบเป็น string
        public static string AskQuestion(string question)
        {
            System.Console.Write(question);
            return System.Console.ReadLine();
        }

        // ฟังก์ชันเพื่อถามคำถามและรับคำตอบเป็น int
        public static int AskQuestionInt(string question)
        {
            System.Console.Write(question);
            return int.Parse(System.Console.ReadLine());
        }

        // ฟังก์ชันใหม่เพื่อถามคำถามและรับคำตอบเป็น double
        public static double AskQuestionDouble(string question)
        {
            System.Console.Write(question);
            return double.Parse(System.Console.ReadLine());
        }
    }
}
