using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work6
{
    internal class Program
    {
        static void DirectoryWrite(string path)
        {
            using (StreamWriter dirEmployees = new StreamWriter(path, true, Encoding.Default))
            {
                string dir = string.Empty;
                Console.Write("Номер записи: ");
                dir += $"{Int16.Parse(Console.ReadLine())}" + "#";

                DateTime time = DateTime.Now;
                Console.WriteLine($"Время записи: {time}");
                dir += $"{time}" + "#";

                Console.Write("Ф.И.О. сотрудника: ");
                dir += $"{Console.ReadLine()}" + "#";

                Console.Write("Дата рождения сотрудника: ");
                DateTime birthdate = Convert.ToDateTime(Console.ReadLine());
                dir += $"{birthdate}" + "#";

                int age = time.Year - birthdate.Year;
                Console.Write($"Возраст сотрудника: {age} ");
                dir += $"{age}" + "#";

                Console.Write("\nРост сотрудника: ");
                dir += $"{Int16.Parse(Console.ReadLine())}" + "#";

                Console.Write("Место рождения сотрудника: ");
                dir += $"{Console.ReadLine()}" + "#";
                dirEmployees.WriteLine(dir);
            }
        }
        static void DirectoryRead(string path)
        {
            using (StreamReader rEmp = new StreamReader(path, Encoding.Default))
            {
                string line;
                string[] parts = { };
                Console.Write($"{"№",3}{"Время записи",20}{"Ф.И.О. сотрудника",25}{"Дата рождения сотрудника",35}{"Возраст сотрудника",25}{"Рост сотрудника",25}{"Место рождения сотрудника",35}");

                while ((line = rEmp.ReadLine()) != null)
                {
                    parts = line.Split('#');
                    Console.WriteLine($"\n{parts[0],3}{parts[1],23}{parts[2],19}{parts[3],35}{parts[4],22}{parts[5],26}{parts[6],35}");
                }
            }
        }
        static string GetFile()
        {
            string path = @"C:\Work6\Directory.txt";

            FileStream fileStream = null;

            if (!File.Exists(path))
            {
                fileStream = File.Open(path, FileMode.OpenOrCreate);
            }
            return path;
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Выберите вариант:");

            while (true)
            {
                Console.WriteLine("\n1. Добавить данные нового сотрудника");
                Console.WriteLine("2. Просмотреть данные всех сотрудников");
                Console.WriteLine("Нажмите любую кнопку, чтобы выйти");

                char numsel = Convert.ToChar(Console.ReadLine());
                switch (numsel)
                {
                    case '1': DirectoryWrite(GetFile()); continue;
                    case '2': DirectoryRead(GetFile()); continue;
                    default: break;
                }
                break;
            }
        }
    }
}