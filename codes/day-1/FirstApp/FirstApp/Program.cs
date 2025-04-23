using System.Diagnostics;

Console.WriteLine("hello...");

Console.WriteLine(Process.GetCurrentProcess().ProcessName);
Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

Console.WriteLine("\nLoaded assemblies....\n");
AppDomain.CurrentDomain.GetAssemblies().ToList().ForEach(assembly => Console.WriteLine(assembly.FullName));

Console.WriteLine("press any key to terminate...");
Console.ReadKey();


