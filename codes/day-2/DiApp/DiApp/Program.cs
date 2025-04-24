// See https://aka.ms/new-console-template for more information

using System.Reflection;

var regiestry = new Registry();
var container = regiestry
    .Register<IRepository, Repository>()
    .Register<IService, Service>()
    .BuildContainer();

IRepository? repo = container.CreateAndGetObject<IRepository, Repository>();
Console.WriteLine(repo?.GetData());

class Container //Service
{
    private readonly Registry _registry;
    public Container(Registry registry) => _registry = registry;
    public TInterface? CreateAndGetObject<TInterface, TClass>()
    {
        if (_registry.Types.ContainsKey(typeof(TInterface)))
        {
            var set = _registry.Types[typeof(TInterface)];
            Type implInfo = set.Where(x => x.Name == typeof(TClass).Name).First();
            return (TInterface?)Activator.CreateInstance(implInfo);
        }
        else
            return default(TInterface?);
    }
}
class Registry
{
    private Dictionary<Type, HashSet<Type>> types = [];
    public Dictionary<Type, HashSet<Type>> Types => types;
    private static Container? container;

    public Registry Register<TInterface, TImplementation>()
    {
        Type typeInterface = typeof(TInterface);
        Type typeImpl = typeof(TImplementation);
        //typeImpl
        //    .GetInterfaces()
        //    .ToList()
        //    .ForEach(x => Console.WriteLine(x.Name));
        Type? interfaceType = typeImpl
            .GetInterface(typeInterface.Name);

        if (interfaceType == typeInterface)
        {
            if (types.ContainsKey(typeInterface))
            {
                types[typeInterface].Add(typeImpl);
            }
            else
            {
                HashSet<Type> impls = new HashSet<Type>();
                impls.Add(typeImpl);
                types.Add(typeInterface, impls);
            }
        }
        else
            throw new Exception($"{typeImpl.Name} does not implement {typeInterface.Name}");
        return this;
    }
    public Container BuildContainer()
    {
        if (container == null)
            container = new Container(this);

        return container;
    }
}
interface IRepository
{
    string GetData();
}
class Repository : IRepository
{
    public string GetData() => "data";
}

interface IService
{
    bool Operate();
}
class Service : IService
{
    public bool Operate()
    {
        return true;
    }
}