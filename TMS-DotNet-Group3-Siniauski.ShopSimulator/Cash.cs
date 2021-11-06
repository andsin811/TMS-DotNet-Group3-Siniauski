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
            _serviceSpeed = random.Next(15, 30);
            _totalCash = 0;
            _countOfCustomers = 0;
        }
                
        public void PrintWorkResult()
        {
            return;
        }

        public void StartWork(CancellationToken token)
        {
            return;
        }
    }
}