using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ShopSimulator
{
    public class Cash
    {
        private Shop _shop;
        private int _number;
        private int _serviceSpeed;
        private double _totalCash;
        private int _countOfCustomers;
        public Queue<Customer> Customers = new Queue<Customer>();

        public int Number => _number;
        public double TotalCash => _totalCash;
        public double CountOfCustomers => _countOfCustomers;

        private static Mutex _mutex = new Mutex();

        public Cash(int number, Shop shop)
        {
            _shop = shop;
            _number = number;
            Random random = new Random();
            _serviceSpeed = random.Next(20, 40);
            _totalCash = 0;
            _countOfCustomers = 0;
        }

        public void PrintWorkResult()
        {
            Console.WriteLine(new string('-', 35));
            Console.WriteLine($"Cash {_number}:" +
                $"\n\tservice speed - {_serviceSpeed}" +
                $"\n\tcount of customers - {_countOfCustomers}" +
                $"\n\ttotal cash - {Math.Round(_totalCash, 2)}");
            Console.WriteLine(new string('-', 35));
        }

        public void StartWork(CancellationToken token)
        {
            while (true)
            {
                if (Customers.Count > 0)
                {
                    _mutex.WaitOne();
                    _shop.PrintConsoleImage();
                    _mutex.ReleaseMutex();
                    Task.Delay(60000 / _serviceSpeed).Wait();
                    Customer customer = Customers.Dequeue();
                    double totalCostOfProducts = customer.Cart.TotalCost;
                    _totalCash += totalCostOfProducts;
                    _countOfCustomers++;
                    continue;
                }
                if (token.IsCancellationRequested)
                {
                    break;
                }
            }
        }
    }
}