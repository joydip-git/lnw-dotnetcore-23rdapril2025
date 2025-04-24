// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
//null check
string? str = null;
//null propagation
str?.ToLower();

class Person
{
    //private readonly int id;
    //private string? name;
    public Person() { }
    public Person(int id, string name)
    {
        //this.id = id;
        //this.name = name;
        this.Id = id;
        this.Name = name;
    }
    //private string <>_NameField;

    //property setter
    //public string Name
    //{
    //    get;
    //    protected set;
    //} = string.Empty;
    //public string? Name
    //{
    //    get;
    //    set;
    //}
    //public required string Name
    //{
    //    get;
    //    set;
    //}
    public string Name
    {
        get;
        set;
    } = string.Empty;

    //private int <>_IdField;
    //public int Id { get=><>_IdField; }

    //public int Id { get => id; }
    //public int Id => id;

    public int Id { protected set; get; }

}
