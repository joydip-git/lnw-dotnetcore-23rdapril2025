List<int> numbers = [0, 3, 1, 5, 4, 6, 2, 9, 7, 8];

//1. Method Query Syntax
//delayed execution
var values = numbers
    .Where(num => num % 2 == 0)
    .OrderBy(num => num)
    .Take(2);

values
    .ToList()
    .ForEach(num => Console.WriteLine(num));

//2. Query Operator Syntax
//num => range variable
//query => implcitly typed local variable

//delayed execution
//var query = from num in numbers
//            where num % 2 == 0
//            orderby num ascending
//            select num;

//query
//    .Take(2)
//    .ToList()
//    .ForEach(num => Console.WriteLine(num));

//immediate execution
(from num in numbers
 where num % 2 == 0
 orderby num ascending
 select num
 )
 .Take(2)
 .ToList();


