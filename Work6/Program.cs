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
        static void DirectoryWrite()
        {
            using (StreamWriter dirEmployees = new StreamWriter("Directory.txt", true , Encoding.Default))
            {
                string dir = string.Empty;
                Console.Write("Номер записи: ");
                dir += $"{Console.ReadLine()}" + "#";

                DateTime time = DateTime.Now;
                Console.WriteLine($"Время записи: {time}");
                dir += $"{time}" + "#";

                Console.Write("Ф.И.О. сотрудника: ");
                dir += $"{Console.ReadLine()}" + "#";

                Console.Write("Дата рождения сотрудника: ");
                DateTime birthdate = Convert.ToDateTime(Console.ReadLine());
                dir += $"{birthdate}" + "#";

                Console.Write("Возраст сотрудника: ");
                var age = time.Year - birthdate.Year;
                Console.Write(age);
                dir += $"{age}" + "#";

                Console.Write("\nРост сотрудника: ");
                dir += $"{Console.ReadLine()}" + "#";

                Console.Write("Место рождения сотрудника: ");
                dir += $"{Console.ReadLine()}" + "#";
                dirEmployees.WriteLine(dir);


            }
        }
        static void DirectoryRead()
        {
            using (StreamReader rEmp = new StreamReader("Directory.txt", Encoding.Default))
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
        static void Main(string[] args)
        {

            Console.WriteLine("Выберите вариант:");
            Console.WriteLine("1. Добавить данные нового сотрудника");
            Console.WriteLine("2. Просмотреть данные всех сотрудников");
            if ('1' == char.ToUpper(Console.ReadKey().KeyChar))
            {
                DirectoryWrite();
            }
            else 
            {
                DirectoryRead();
            }
            Console.ReadKey();



        }
    }
}
