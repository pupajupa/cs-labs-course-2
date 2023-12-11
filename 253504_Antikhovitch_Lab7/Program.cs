using Calculations;

public static class Program
{
    public static void Main(string[] args)
    {
        IntegralCalculation calculator1 = new();
        IntegralCalculation calculator2 = new();

        Thread thread1 = new Thread(calculator1.CalculateIntegral);
        thread1.Priority = ThreadPriority.Lowest;
        thread1.Name = "Integral Calculator номер 1";

        calculator1.CalculationCompleted += (sender, result) =>
        {
            Console.WriteLine($"----------------------Поток {thread1.Name} завершен с результатом: {result}--------------------------");
        };

        calculator1.ProgressChanged += (sender, progress) =>
        {
            Console.WriteLine($"Поток {thread1.Name}: [=========> {progress} %]");
        };


        Thread thread2 = new Thread(calculator2.CalculateIntegral);
        thread2.Priority = ThreadPriority.Highest;
        thread2.Name = "Integral Calculator номер 2";

        calculator2.CalculationCompleted += (sender, result) =>
        {
            Console.WriteLine($"----------------------Поток {thread2.Name} завершен с результатом: {result}--------------------------");
        };

        calculator2.ProgressChanged += (sender, progress) =>
        {
            Console.WriteLine($"Поток {thread2.Name}: [=========> {progress} %]");
        };


        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();



        IntegralCalculation calculator = new IntegralCalculation(2, 5);

        Thread[] threads = new Thread[5];

        for (int i = 0; i < threads.Length; i++)
        {
            threads[i] = new Thread(calculator.CalculateIntegral);
            threads[i].Name = $"Поток №{i + 1}";
            threads[i].Start();
        }

        for (int i = 0; i < threads.Length; i++)
        {
            threads[i].Join();
        }
    }
}