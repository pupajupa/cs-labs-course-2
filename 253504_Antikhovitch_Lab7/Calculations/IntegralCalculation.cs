using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations
{
    public class IntegralCalculation
    {
        private static Semaphore semaphore;
        private int runningThreads = 0;

        private double a = 0;
        private double b = 1;
        private double step = 0.0001;

        public event EventHandler<double> CalculationCompleted;
        public event EventHandler<double> ProgressChanged;

        public IntegralCalculation()
        {
            runningThreads++;
        }
        public IntegralCalculation(int initial, int maxThreads)
        {
            semaphore = new Semaphore(initial, maxThreads);
            runningThreads = maxThreads;
        }
        public void CalculateIntegral()
        {
            if (runningThreads > 1)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} ждет очередь");

                semaphore.WaitOne();

                Console.WriteLine($"{Thread.CurrentThread.Name} запустился");
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                double x = a;
                double integral = 0;
                double progress = 0;

                while (x < b)
                {
                    for (int i = 0; i < 100000; i++)
                    {
                        int temp = 1 * 1;
                    }
                    double y = Math.Sin(x);
                    integral += y * step;
                    x += step;

                    progress = (x - a) / (b - a) * 100;

                    OnProgressChanged(progress);
                }

                stopwatch.Stop();
                double executionTime = stopwatch.Elapsed.TotalSeconds;
                Console.WriteLine($"Время выполнения {Thread.CurrentThread.Name}: " + executionTime + " мс");
                OnCalculationCompleted(integral, executionTime);

                semaphore.Release();
            }
            else
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                double x = a;
                double integral = 0;
                double progress = 0;

                while (x < b)
                {
                    for (int i = 0; i < 100000; i++)
                    {
                        int temp = 1 * 1;
                    }
                    double y = Math.Sin(x);
                    integral += y * step;
                    x += step;

                    progress = (x - a) / (b - a) * 100;

                    OnProgressChanged(progress);
                }

                stopwatch.Stop();
                double executionTime = stopwatch.Elapsed.TotalSeconds;
                Console.WriteLine("Время выполнения: " + executionTime + " мс");
                OnCalculationCompleted(integral, executionTime);
            }
        }

        protected virtual void OnCalculationCompleted(double result, double executionTime)
        {
            CalculationCompleted?.Invoke(this, result);
        }

        protected virtual void OnProgressChanged(double progress)
        {
            ProgressChanged?.Invoke(this, progress);
        }
    }
}
