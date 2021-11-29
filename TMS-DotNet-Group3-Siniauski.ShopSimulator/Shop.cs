using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopSimulator
{
    public class Shop
    {
        private static readonly List<Product> _products = new List<Product>()
        {
            new Product("Bacon", 10.5),
            new Product("Chicken", 8.2),
            new Product("Salmon", 7.5),
            new Product("Avocado", 3.8),
            new Product("Garlic", 0.35),
            new Product("Potato", 0.1),
            new Product("Apple", 1.4),
            new Product("Blueberry", 4),
            new Product("Milk", 1.1),
            new Product("Honey", 9.3)
        };

        private List<Cash> _cashes = new List<Cash>();
        private int _countOfCashes;
        private int _workTimeInSeconds;

        public Shop(int countOfCashes, int workTimeInSeconds)
        {
            _countOfCashes = countOfCashes;
            _workTimeInSeconds = workTimeInSeconds;
        }

        public double TotalCash => _cashes.Sum(c => c.TotalCash);
        public double CountOfCustomers => _cashes.Sum(c => c.CountOfCustomers);

        public void Run()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;
            List<Task> CashTasks = new List<Task>();
            for (int i = 1; i <= _countOfCashes; i++)
            {
                Cash cash = new Cash(i, this);
                _cashes.Add(cash);
                CashTasks.Add(Task.Factory.StartNew(() => cash.StartWork(token)));
            }
            Task generateRandomCustomersTask = Task.Factory.StartNew(() => Customer.GenerateRandomCustomers(_products, _cashes, token));
            Task.Delay(_workTimeInSeconds * 1000).Wait();
            cancelTokenSource.Cancel();
            generateRandomCustomersTask.Wait();
            Task.WaitAll(CashTasks.ToArray());
            PrintInfo();
        }

        internal void PrintInfo()
        {
            Console.Clear();
            foreach (Cash cash in _cashes)
            {
                cash.PrintWorkResult();
            }
            Console.WriteLine(new string('*', 40));
            Console.WriteLine($"Shop:" +
                $"\n\twork time - {_workTimeInSeconds} s" +
                $"\n\ttotal count of customers - {CountOfCustomers}" +
                $"\n\ttotal cash - {Math.Round(TotalCash, 2)}");
            Console.WriteLine(new string('*', 40));
        }

        public void PrintConsoleImage()
        {
            Console.Clear();
            foreach (Cash cash in _cashes)
            {
                Console.WriteLine($"{new string('-', 13)}");
                Console.WriteLine($"-- C A S H --\tCount of customers: {cash.CountOfCustomers}");
                Console.WriteLine($"--    {cash.Number}    --\tTotal cash: {Math.Round(cash.TotalCash, 2)}");
                Console.WriteLine($"{new string('-', 13)}");
                for (int i = 0; i < cash.Customers.Count; i++)
                {
                    Console.Write("   () ");
                }
                Console.WriteLine();
                for (int i = 0; i < cash.Customers.Count; i++)
                {
                    Console.Write(@"  /||\");
                }
                Console.WriteLine();
                for (int i = 0; i < cash.Customers.Count; i++)
                {
                    Console.Write(@"   /\ ");
                }
                Console.WriteLine("\n");
            }
        }
    }
}