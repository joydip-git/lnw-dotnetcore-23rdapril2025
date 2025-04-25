List<int> numbers = [0, 3, 2, 7, 4, 1, 5, 9, 8, 6];
List<string> names = ["anil", "sunil", "joy", "amit"];


//LogicInvoker<int> evenLogic = new(new Logic().IsEven);
//var result = Filter<int>(numbers, evenLogic);

//LogicInvoker<int> oddLogic = new(Logic.IsOdd);
//var result = Filter<int>(numbers, oddLogic);

//LogicInvoker<string> nameWitha = new(Logic.NameContainsA);
//LogicInvoker<string, bool> nameWitha = new(Logic.NameContainsA);
//var result = Filter<string>(names, nameWitha);

//anonymous (in-line) method: a method without a name, which will be written and will be referred immediately then and there by a delegate

//1. traditional style
//LogicInvoker<string> nameStartsWithA = delegate (string name)
//    {
//        return name[0] == 'a';
//    };


//2. Lambda expression: a expression style to write anonymous method (3.0 -2007)
//type inference
LogicInvoker<string> nameStartsWithA = (name) => name[0] == 'a';

LogicInvoker<int> greaterThanDel = delegate (int num) { return num > 5; };

var result = Filter<string>(names, nameStartsWithA);
foreach (var item in result)
{
    Console.WriteLine(item);
}

//static List<T> Filter<T, TResult>(List<T> input, LogicInvoker<T, TResult> invoker)
static IEnumerable<T> Filter<T>(IEnumerable<T> input, LogicInvoker<T> invoker)
{
    List<T> output = [];
    foreach (var item in input)
    {
        //if (typeof(TResult)==typeof(bool))
        if (invoker(item))
            output.Add(item);
    }
    return output;
}

class Logic
{
    public bool IsEven(int x) => x % 2 == 0 ? true : false;

    public static bool IsOdd(int x) => x % 2 != 0;

    public static bool NameContainsA(string name) => name.Contains('a');

    //public static bool NameStartsWithA(string name) => name[0] == 'a';
}

//delegate bool LogicInvoker(int a);
delegate bool LogicInvoker<in T>(T a);
//delegate bool Predicate<in T>(T a);
delegate TResult LogicInvoker<in T, out TResult>(T a);


//delegate TResult Func<out TResult>();
//delegate TResult Func<in T,out TResult>(T a);
//....
//delegate TResult Func<in T1,...,in T16,out TResult>(T1 a,.....,T16 x);
