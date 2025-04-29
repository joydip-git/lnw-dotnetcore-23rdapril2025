using System.Threading.Tasks;

List<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 0];

List<Task<TaskResult>> tasks = new List<Task<TaskResult>>();
try
{
    numbers
        .ForEach(
        num =>
        {
            Task<TaskResult> numTask = Task<TaskResult>.Run<TaskResult>(() => IsEvenOrOdd(num));
            //new TaskFactory<bool>().StartNew(() => IsEvenOrOdd(num));
            //Task<bool> task = new Task<bool>(() => IsEvenOrOdd(num));
            tasks.Add(numTask);
        });

    tasks
        .ForEach(
            async (t) =>
            {

                //if (t.IsCompletedSuccessfully)
                //{
                //    Console.WriteLine($"Thread Id: {Environment.CurrentManagedThreadId}");
                //    Console.WriteLine($"{t.Result.Number} is {t.Result.IsEvenOrOdd}");
                //}
                var result = await t;
                Console.WriteLine($"Thread Id: {Environment.CurrentManagedThreadId} where the result => {result.Number} is {result.IsEvenOrOdd}");
            });
}
catch (OperationCanceledException ex)
{
    Console.WriteLine(ex.Message);
}
await Task.Delay(TimeSpan.FromSeconds(10));

static async Task<TaskResult> IsEvenOrOdd(int num)
{
    await Task.Delay(500);
    //Console.WriteLine($"Thread Id: {Environment.CurrentManagedThreadId}");
    return num % 2 == 0 ? new TaskResult(num, "Even") : new TaskResult(num, "Odd");
}

record TaskResult(int Number, string IsEvenOrOdd);