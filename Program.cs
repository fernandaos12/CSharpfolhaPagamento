using System;
using System.Globalization;
using folhaPagamento.Entities;
using folhaPagamento.Entities.Enums;

namespace folhaPagamento
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Department Name: ");
            string dptName = Console.ReadLine();
            Console.WriteLine("Enter Work Date: " );
            Console.WriteLine("Name :" );
            string name = Console.ReadLine();
            Console.WriteLine("Level(Junior/MidLevel/Senior) :");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.WriteLine("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Departament dept = new Departament(dptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.WriteLine("How many contracts for this worker?");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data; ");
                Console.WriteLine("Date(DD,MM,YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Value per hour; ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.WriteLine("Duration(hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);

                worker.AddContract(contract);   
            }

            Console.WriteLine("");
            Console.WriteLine("Enter month and year to calculate income(MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Departament.Name);
            Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year, month));

        }
    }
}
