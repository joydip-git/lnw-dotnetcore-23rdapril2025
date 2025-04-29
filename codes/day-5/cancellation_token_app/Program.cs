using System.Net.Http.Json;
using System.Text.Json;

CancellationTokenSource cts = new();
CancellationToken token = cts.Token;

try
{
    await Task.Run(() => PrintCounter(token), token);
}
catch (OperationCanceledException ex)
{
    Console.WriteLine($"{ex.Message}");
}

static async Task PrintCounter(CancellationToken ct)
{
    int counter = 0;
    while (true)
    {
        if (ct.IsCancellationRequested)
        {
            Console.WriteLine($"Cancellation Request Received...");
            ct.ThrowIfCancellationRequested();
        }
        Console.WriteLine($"Counter Value: {counter}");
        counter++;

        await Task.Delay(1000);
    }
}