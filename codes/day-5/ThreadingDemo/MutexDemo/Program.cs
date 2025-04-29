// See https://aka.ms/new-console-template for more information
User user = new();
Thread increaseThrd = new(user.Increase);
Thread decreaseThrd = new(user.Decrease);

increaseThrd.Start(5);
decreaseThrd.Start(5);

class SharedResource
{
    public static int SharedData = 0;
    public static Mutex SharedLock = new();
}

class User
{
    //private SharedResource SharedResource = new();

    public void Increase(object? count)
    {
        SharedResource.SharedLock.WaitOne();

        if (count != null)
        {
            for (int i = 0; i < (int)count; i++)
            {
                Console.WriteLine($"In Increase: {++SharedResource.SharedData}");
            }
        }
        SharedResource.SharedLock.ReleaseMutex();
    }
    public void Decrease(object? count)
    {
        SharedResource.SharedLock.WaitOne();
        if (count != null)
        {
            for (int i = 0; i < (int)count; i++)
            {
                Console.WriteLine($"In Decrease: {--SharedResource.SharedData}");
            }
        }
        SharedResource.SharedLock.ReleaseMutex();
    }
}
