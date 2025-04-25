List<string> names = ["Anil", "Sunil", "Joydip", "Amit", "Jeevan",];

IEnumerable<IGrouping<char, string>> query;
query = from name in names
        orderby name
        group name by name[0];

//names.OrderBy(name=>name).GroupBy(name => name[0]);
foreach (IGrouping<char, string> group in query)
{
    Console.WriteLine($"Grouped by:{group.Key}");
    foreach (string name in group)
    {
        Console.WriteLine(name);
    }
    Console.WriteLine("\n");
}

var groupQuery = from name in names
                 group name by name[0] into g
                 from n in g
                 orderby n
                 select new { g.Key, Value = n };
foreach (var item in groupQuery)
{
    Console.WriteLine(item.Key + ":" + item.Value);
}


