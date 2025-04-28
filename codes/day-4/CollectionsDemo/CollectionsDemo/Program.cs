using System.Collections;
using LnW.DotNet.Collections.Generic;
using LnW.DotNet.Collections.Generic.Extensions;

Console.WriteLine("welcome to collections...");
/*
var anilPerson = new Person { Id = 1, Name = "anil" };
Console.WriteLine(anilPerson.Id);
Console.WriteLine(anilPerson.Name);
Person sunilPerson = new();
sunilPerson[1] = 2;
sunilPerson[2] = "sunil";
Console.WriteLine(sunilPerson["id"]);
Console.WriteLine(sunilPerson["name"]);
*/
//var list = new MyCollection<int>();
var list = new List<int>();
list.Add(1);
list.Add(5);
list.Add(2);
list.Add(4);
list.Add(3);



for (int i = 0; i < list.Count; i++)
{
    Console.WriteLine(list[i]);
}

Console.WriteLine($"count: {list.Count}");
Console.WriteLine($"Capacity: {list.Capacity}");

foreach (int item in list)
{
    Console.WriteLine(item);
}

Console.WriteLine("\nusing enumerator directly\n");
list.Sort();
IEnumerator<int> enumerator = list.GetEnumerator();

while (enumerator.MoveNext())
{
    Console.WriteLine(enumerator.Current);
}
Console.WriteLine("\nvalues from the array\n");
//var numbers = list.ToArray<int>();
var numbers = list.CopyToArray<int>();
foreach (var item in numbers)
{
    Console.WriteLine(item);
}

//list.OrderBy(x => x);
list.Clear();
list = null;

