List<int> numbers = [0, 3, 2, 7, 4, 1, 5, 9, 8, 6];
List<string> names = ["anil", "sunil", "joy", "amit"];

//Predicate<int> evenDel = new Logic().IsEven;
//Predicate<int> oddDel = Logic.IsOdd;
//Predicate<string> nameHasA = Logic.NameContainsA;

Func<int,bool> evenDel = new Logic().IsEven;
IEnumerable<int> evenList = numbers.Where(evenDel);

//Func<int,int> sortDel = 
//evenList.OrderBy()

//Language Integrated Query

class Logic
{
    public bool IsEven(int x) => x % 2 == 0 ? true : false;
    public static bool IsOdd(int x) => x % 2 != 0;

    public static bool NameContainsA(string name) => name.Contains('a');
}
