using System.Reflection;
using TypesDemo;

Console.WriteLine("Hello, World!");

Person.Print();
//var reference = new WeakReference<Person>(new Person());
Instantiate();
static void Instantiate()
{
    //anilPerson is a reference variable storing reference of an object of Person class
    //Person anilPerson = new Person () { Name = "anil", Id = 1 };
    //Console.WriteLine(anilPerson.Name);

    //personType is a reference variable storing reference of an object of Type class which is storing metadata of Person class it self

    //Type personType = anilPerson.GetType();
    Type personType = typeof(Person);
    //object? personObj = Activator.CreateInstance(personType);

    ConstructorInfo? paramCtorInfo = personType.GetConstructor(new Type[] { typeof(int), typeof(string) });

    object? personObj = paramCtorInfo?.Invoke(new object[] { 100, "Anil" });

    PropertyInfo? namePropInfo = personType.GetProperty("Name");
    //namePropInfo?.SetValue(personObj, "Anil");

    PropertyInfo? idPropInfo = personType.GetProperty("Id");
    //idPropInfo?.SetValue(personObj, 100);

    Console.WriteLine(namePropInfo?.GetValue(personObj));
    Console.WriteLine(idPropInfo?.GetValue(personObj));
}



