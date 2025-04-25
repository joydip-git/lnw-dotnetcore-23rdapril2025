using LINQ_Collections_Practice.Models;
using System.Net.NetworkInformation;
using static LINQ_Collections_Practice.Utility.UiUtility;


char toContinue = 'n';
do
{
    //1. display the menu
    PrintMenu();

    //2. ask user for choice
    int choice = GetChoice();

    //3. get the data source
    IEnumerable<Employee> employees = CreateStorage();

    var avg = employees.Average(e => e.Salary);
    var max = employees.Max(e => e.Salary);
    var min = employees.Min(e => e.Salary);

    //anonymous type
    var statistics = new { Maximum = max, Minimum = min, Average = avg };

    var other = new { Max =statistics.Maximum, statistics.Minimum, statistics.Average };
    
    //statistics.Maximum = 1000;

    //4. get the data sorted
    IEnumerable<Employee> sortedEmployees = SortEmployees(choice, employees);

    //5. get the data filtered
    IEnumerable<Employee> filteredEmployees = FilterEmployees(11000, sortedEmployees);

    //6. print the data
    PrintEmployees(filteredEmployees);

    //7. decide to continue or not
    DecideToContinue(ref toContinue);

} while (toContinue != 'n');

