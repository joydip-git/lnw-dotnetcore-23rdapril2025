using LINQ_Collections_Practice.Models;

namespace LINQ_Collections_Practice.Utility
{
    public static class UiUtility
    {
        public static void PrintMenu()
        {
            Console.WriteLine("1. Sort By Id\n2. Sort By Name\n3. Sort By Department\n4. Sort By Salary");
        }

        public static int GetChoice()
        {
            Console.Write("\nEnter Choice[1/2/3/4]: ");
            return int.Parse(Console.ReadLine() ?? "1");
        }

        public static IEnumerable<Employee> CreateStorage()
        {
            List<Employee> list = new List<Employee>
            {
new Employee{Id=2, Name="Sunil", DepartmentName="HR", Salary=10000 }
            };
            List<Employee> employees =
                [
                    new Employee{Id=2, Name="Sunil", DepartmentName="HR", Salary=10000 },
            new Employee{Id=1, Name="Joydip", DepartmentName="SINGO", Salary=30000 },
            new Employee{Id=3, Name="Anil", DepartmentName="DYNAMICS", Salary=20000 }
                ];
            return employees;
        }

        public static IEnumerable<Employee> SortEmployees(int choice, IEnumerable<Employee> employees)
        {
            /*
            IEnumerable<Employee> result;
            switch (choice)
            {
                case 1:
                    //Func<Employee, int> sortDel = e => e.Id;
                    result = employees.OrderBy(e => e.Id);
                    break;
                default:
                    result = employees.OrderBy(e => e.Id);
                    break;
            }
            return result;
            */
            IEnumerable<Employee> result = choice switch
            {
                1 => employees.OrderBy(e => e.Id),
                2 => employees.OrderBy(e => e.Name),
                3 => employees.OrderBy(e => e.DepartmentName),
                4 => employees.OrderBy(e => e.Salary),
                _ => employees.OrderBy(e => e.Id)
            };
            return result;
        }

        public static IEnumerable<Employee> FilterEmployees(decimal salary, IEnumerable<Employee> employees)
        {
            return employees.Where(e => e.Salary > salary);
        }

        public static void DecideToContinue(ref char decision)
        {
            Console.Write("\nEnter n/N to discontinue: ");
            decision = char.Parse(Console.ReadLine() ?? "n");
            if (char.IsUpper(decision))
                decision = char.ToLower(decision);
        }

        public static void PrintEmployees(IEnumerable<Employee> filteredEmployees)
        {
            filteredEmployees
                .ToList<Employee>()
                .ForEach(e => Console.WriteLine(e.Name));
        }
    }
}
