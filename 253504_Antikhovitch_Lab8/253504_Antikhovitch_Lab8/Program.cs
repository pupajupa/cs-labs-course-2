using System.Diagnostics;
using StreamServiceLib;
public class Program
{
    private static Progress<string> progress = new();
    private static Random random = new();

    static async Task Main(string[] args)
    {
        Stopwatch stopwatch = new();
        stopwatch.Start();
        progress.ProgressChanged += (_, eArgs) =>
        {
            Console.WriteLine(eArgs);
        };

        Picture[] pictureDealership = new Picture[1000];
        for (int i = 0; i < 1000; i++)
        {
            pictureDealership[i] = new Picture()
            {
                ID = i,
                Title = $"Artwork {i}",
                Artist = $"Artist {random.Next(1, 5)}"
            };
        }

        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} has started its work");
        StreamService<Picture> streamService = new();

        using (MemoryStream memoryStream = new())
        {
            string filename = "pictureDealership";

            var task1 = streamService.WriteToStreamAsync(memoryStream, pictureDealership, progress);
            await Task.Delay(200);
            var task2 = streamService.CopyFromStreamAsync(memoryStream, filename, progress);

            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}. Methods 1 and 2 are working.");
            Task.WaitAll(task2, task1);

            var result = await streamService.GetStatisticsAsync(filename, obj => obj.Artist == "Artist 1");
            Console.WriteLine("Waiting for completion of calculations...");
            //await task3;
            Console.WriteLine($"Number of artwork master 'Artist 1': {result}");
        }
        stopwatch.Stop();
        TimeSpan ts = stopwatch.Elapsed;
        string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
        Console.WriteLine($"\nElapsed time {elapsedTime}");
    }
}