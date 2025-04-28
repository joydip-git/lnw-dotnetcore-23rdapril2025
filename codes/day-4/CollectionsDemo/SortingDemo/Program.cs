// See https://aka.ms/new-console-template for more information
using SortingDemo;

Console.WriteLine("Hello, World!");
List<Person> people =
    [
        new Person{ Id=2, Name="sunil"},
        new Person{ Id=1, Name="joydip"},
        new Person{ Id=3, Name="anil"},
    ];

//people[0] > people[1]
Console.WriteLine("1. sort by id\n2. sort by name");
Console.Write("\nenter choice: ");
int choice = int.Parse(Console.ReadLine() ?? "1");

//1. using CompareTo from IComparable implemented in Person
//this verson of Sort() expects IComparable interface is implemented in Person class
//people.Sort();

//2. using Compare from IComparer in PersonComparer class
//PersonComparer comparer = new PersonComparer(choice);
//people.Sort(comparer);
//comparer.GetType().GetInterface("IComparer");

//3. using Comparison<T> delegate
/*
Comparison<Person> compareLogic;
switch (choice)
{
    case 1:
        compareLogic = (x, y) => x.Id.CompareTo(y.Id);
        break;

    case 2:
        compareLogic = (x, y) => x.Name.CompareTo(y.Name);
        break;

    default:
        compareLogic = (x, y) => x.Id.CompareTo(y.Id);
        break;
}

people.Sort(compareLogic);
*/

/*
 * typeof(Person).GetInterface("IComparable").
for (int i = 0; i < people.Count; i++)
{
    for (int j = i + 1; j < people.Count; j++)
    {
        //with IComparable
        //if (people[i].CompareTo(people[j]) > 0)

        //with IComparer in separate class
        if(comparer.Compare(people[i],people[j]>0)

        //with operator overloading (> and<) in Person
        //if (people[i]>people[j])
        {
            Person temp = people[i];
            people[i] = people[j];
            people[j] = temp;
        }
    }
}
*/

//4. using OrderBy/OrderByDescending extension method which expects a Func<Person,TKey> type delegate with logic

IOrderedEnumerable<Person> result;
switch (choice)
{
    case 1:
        Func<Person, int> sortById = (person) => person.Id;
        result = people.OrderBy(sortById);
        break;

    case 2:
        Func<Person, string> sortByName = (person) => person.Name;
        result = people.OrderBy(sortByName);
        break;

    default:
        Func<Person, int> sortDefault = (person) => person.Id;
        result = people.OrderBy(sortDefault);
        break;
}

//foreach (var person in people)
foreach (var person in result)
{
    Console.WriteLine(person);
}


