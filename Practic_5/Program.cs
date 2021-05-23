using System;
using System.Collections.Generic;
using System.Globalization;

namespace Practic_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Демин Вадим Дмитриевич", "20-11-2ИСиП", new DateTime(2002, 05, 06));
            Student student2 = new Student("Демин Вадим Дмитриевич", "20-11-2ИСиП", new DateTime(2002, 05, 06));
            Student student3 = new Student("Демин Вадим Дмитриевич", "20-11-2ИСиП", new DateTime(2002, 05, 06));
            Student.AddStudent(student);
            Student.AddStudent(student2);
            Student.AddStudent(student3);
            Student.EditStudent("Дёмин Вадим Дмитриевич", "20-11-2ИСиП", new DateTime(2002, 05, 06), 0);

            Student.OutputAllStudent();
            Student.OutputID(2);
            Student.OutputGrowth(2);
        }
    }

    class Student
    {
        private static List<Student> studentsList = new List<Student>();

        private static int id = 0;

        private string _FIO;
       
        private string _group;
        private DateTime _bornDate;
        private int idStudent = 0;

        public Student(string FIO, string group, DateTime bornDate)
        {
            _FIO = FIO;
            _group = group;
            _bornDate = bornDate;
            idStudent = id++;
        }

        public static void AddStudent(Student student)
        {
            studentsList.Add(student);
        }

        public static void EditStudent(string fio, string group, DateTime bornDate, int id)
        {
            for (int i = 0; i < studentsList.Count; i++)
            {
                if (i == id)
                {
                    studentsList[i].SetFIO(fio);
                    studentsList[i].SetGroup(group);
                    studentsList[i].SetBornDate(bornDate);
                }
            }
        }

        public static void RemoveStudent(int id)
        {
            foreach (Student student in studentsList)
            {
                if (student.GetId() == id)
                {
                    studentsList.Remove(student);
                }
            }
        }

        public static void OutputAllStudent()
        {
            int i = 1;
            foreach (Student student in studentsList)
            {
                Console.WriteLine($"{i++}. ФИО: {student.GetFIO()}");
            }
        }

        public static void OutputID(int id)
        {
            foreach (Student student in studentsList)
            {
                if (student.GetId() == id)
                {
                   Console.WriteLine($"ФИО: {student.GetFIO()}, Группа: {student.GetGroup()}, Дата рождения: {student.GetBornDate().ToString().Substring(0, 10)}, Id студента: {student.GetId()}");
                }
            }
        }

        public static void OutputGrowth(int id)
        {
            foreach (Student student in studentsList)
            {
                if (student.GetId() == id)
                {
                    var date = DateTime.Now;
                    var year = date.Year - student.GetBornDate().Year;
                    if (date.Month < student.GetBornDate().Month || (date.Month == student.GetBornDate().Month && date.Day < student.GetBornDate().Day))
                    {
                        year--;
                    }
                    Console.WriteLine($"Возрост студента: " + year);
                }
            }
        }

        public void SetFIO(string fio)
        {
            _FIO = fio;
        }

        public void SetGroup(string group)
        {
            _group = group;
        }

        public void SetBornDate(DateTime bornDate)
        {
            _bornDate = bornDate;
        }

        public DateTime GetBornDate()
        {
            return _bornDate;
        }

        public string GetGroup()
        {
            return _group;
        }

        public string GetFIO()
        {
            return _FIO;
        }


        public int GetId()
        { 
            return idStudent;
        }



    }
}
