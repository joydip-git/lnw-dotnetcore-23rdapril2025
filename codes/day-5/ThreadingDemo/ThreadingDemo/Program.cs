// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Net.Http.Json;

Console.WriteLine("Hello to Threads!");
Console.WriteLine($"In Main => Proccess Name: {Process.GetCurrentProcess().ProcessName} and Id: {Environment.ProcessId}");

Console.WriteLine($"In Main => Thread Id: {Environment.CurrentManagedThreadId}");

//GetBlogPosts();

//ThreadStart someWorkDel = new ThreadStart(DoSomeWork);
//Thread someWorkThrd = new Thread(someWorkDel);

//ParameterizedThreadStart someOtherWorkDel = DoSomeOtherWork;
//Thread someOtherWorkThrd = new(someOtherWorkDel);

//DoSomeWork();
//DoSomeOtherWork();

Thread someWorkThrd = new(DoSomeWork);
Thread someOtherWorkThrd = new(DoSomeOtherWork);

someOtherWorkThrd.Start("my data");
someOtherWorkThrd.Join();

someWorkThrd.Start();
someWorkThrd.Join();

Console.WriteLine("press enter to terminate...");
Console.ReadKey();


static void DoSomeWork()
{
    Console.WriteLine($"In DoSomeWork => Proccess Name: {Process.GetCurrentProcess().ProcessName} and Id: {Environment.ProcessId}");

    Console.WriteLine($"In DoSomeWork => Thread Id: {Environment.CurrentManagedThreadId}");
    Console.WriteLine("doing some work");
}

static void DoSomeOtherWork(object? data)
{
    Console.WriteLine($"In DoSomeOtherWork => Proccess Name: {Process.GetCurrentProcess().ProcessName} and Id: {Environment.ProcessId}");

    Console.WriteLine($"In DoSomeOtherWork => Thread Id: {Environment.CurrentManagedThreadId}");
    Console.WriteLine("doing some other work with the data " + data?.ToString());
}

static void GetBlogPosts()
{
    try
    {
        var client = new HttpClient();
        //client.GetFromJsonAsAsyncEnumerable();
    }
    catch (Exception)
    {
        throw;
    }
}
