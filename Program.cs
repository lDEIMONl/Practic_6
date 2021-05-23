using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentLib;

namespace Practic_5
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (true)
            {
                int choiceNumber = 0;
                Console.WriteLine("1. Вся информацию о студентах.\n" +
                    "2. Список студентов по инициалам\n" +
                    "3. Список студентов старше 18\n" +
                    "4. Список студентов младше 18\n" +
                    "5. Добавить студента\n" +
                    "6. Удалить студента\n" +
                    "7. Изменить студента\n" +
                    "8. Поиск студентов\n" +
                    "9. Выход");
                while (true)
                {
                    Console.Write("\nВыберите номер: ");
                    choiceNumber = int.Parse(Console.ReadLine());
                    if (choiceNumber > 10 || choiceNumber < 1)
                    {
                        Console.WriteLine("Нет такого номера!!!");
                    }
                    else
                    {
                        break;
                    }
                }
                switch (choiceNumber)
                {
                    case (1):
                        if (Student.studentsList.Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Нет студентов\n");
                        }
                        else 
                        {
                            Console.Clear();
                            foreach (Student student in Student.studentsList)
                            {
                                Student.OutputID(student.idStudent);
                            }
                            Console.WriteLine();
                        }
                        break;
                    case (2):
                        if (Student.studentsList.Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Нет студентов\n");
                        }
                        else
                        {
                            Console.Clear();
                            Student.OutputAllStudent();
                            Console.WriteLine();
                        }
                        break;
                    case (3):
                        if (Student.studentsList.Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Нет студентов\n");
                        }
                        else
                        {
                            Console.Clear();
                            foreach (Student student in Student.studentsList)
                            {
                                if (student.GrowthStudent(student.idStudent) >= 18)
                                {
                                    Student.OutputID(student.idStudent);
                                }
                            }
                            Console.WriteLine();
                        }
                        break;
                    case (4):
                        if (Student.studentsList.Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Нет студентов\n");
                        }
                        else
                        {
                            Console.Clear();
                            foreach (Student student in Student.studentsList)
                            {
                                if (student.GrowthStudent(student.idStudent) <= 18)
                                {
                                    Student.OutputID(student.idStudent);
                                }
                            }
                            Console.WriteLine();
                        }
                        break;
                    case (5):
                        Console.WriteLine("Добавить студента\n");
                        Console.Write("Введите ФИО студента: ");
                        string fio = Console.ReadLine().Trim();
                        Console.Write("Введеите группу студента: ");
                        string group = Console.ReadLine().Trim();
                        Console.WriteLine("Дата рождения: ");
                        Console.Write("Введите день: ");
                        string day = Console.ReadLine();
                        Console.Write("Введите месяц: ");
                        string month = Console.ReadLine();
                        Console.Write("Введите год: ");
                        string year = Console.ReadLine();
                        Student stud = new Student(fio, group, new DateTime(int.Parse(year), int.Parse(month), int.Parse(day)));
                        Student.AddStudent(stud);
                        Console.Clear();
                        Console.WriteLine("Студент добавлен\n");
                        break;
                    case (6):
                        Console.WriteLine("Удаление студента");
                        Console.Write("Введеите id для удаления: ");
                        int idRemove = int.Parse(Console.ReadLine());
                        Student.RemoveStudent(idRemove);
                        Console.Clear();
                        Console.WriteLine("Студент удалён\n");
                        break;
                    case (7):
                        Console.WriteLine("Редактирование студента");
                        if (Student.studentsList.Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Нет студентов\n");
                        }
                        else
                        {
                            Console.Write("Введете id для изменнения студента: ");
                            int idEdit = int.Parse(Console.ReadLine());
                            Console.Write("Введите ФИО студента: ");
                            string fioEdit = Console.ReadLine().Trim();
                            Console.Write("Введеите группу студента: ");
                            string groupEdit = Console.ReadLine().Trim();
                            Console.WriteLine("Дата рождения: ");
                            Console.Write("Введите день: ");
                            string dayEdit = Console.ReadLine();
                            Console.Write("Введите месяц: ");
                            string monthEdit = Console.ReadLine();
                            Console.Write("Введите год: ");
                            string yearEdit = Console.ReadLine();
                            Student.EditStudent(fioEdit, groupEdit, new DateTime(int.Parse(yearEdit), int.Parse(monthEdit), int.Parse(dayEdit)), idEdit);
                            Console.Clear();
                            Console.WriteLine("Студент изменён\n");
                        }
                        break;
                    case (8):
                        if (Student.studentsList.Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Нет студентов\n");
                        }
                        else
                        {
                            Console.WriteLine("Поиск студента: ");
                            Console.Write("Введите id студента: ");
                            int idStudent = int.Parse(Console.ReadLine());
                            Console.Clear();
                            Student.OutputID(idStudent);
                            Console.WriteLine();
                        }
                        break;
                    case (9):
                        Console.WriteLine("Выход");
                        exit = true;
                        break;
                }

                if (exit == true)
                {
                    break;
                }
            }
        }
    }
}
