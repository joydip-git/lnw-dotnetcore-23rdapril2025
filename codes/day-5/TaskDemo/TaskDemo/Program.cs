using System.Text.Json;

Task someWorkTask = Task.Run(() => DoSomeWork());
//await someWorkTask;

Task someOtherWorkTask = Task.Run(() => DoSomeOtherWork());
await someOtherWorkTask;

await Task.Delay(TimeSpan.FromSeconds(3));

static async Task DoSomeOtherWork()
{
    Console.WriteLine($"DoSomeOtherWork in Thread Id: {Environment.CurrentManagedThreadId}");
    //await Task.Delay(TimeSpan.FromMilliseconds(200));
}
static async Task DoSomeWork()
{
    Console.WriteLine($"DoSomeWork in Thread Id: {Environment.CurrentManagedThreadId}");
    await Task.Delay(TimeSpan.FromMilliseconds(2000));    
}
