namespace LINQ_Collections_Practice.Models
{
    public class Employee
    {
        public Employee() { }
        public Employee(int id, string name, string? departmentName, decimal salary)
        {
            Id = id;
            Name = name;
            DepartmentName = departmentName;
            Salary = salary;
        }

        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? DepartmentName { get; set; }
        public decimal Salary { get; set; }
    }
}
