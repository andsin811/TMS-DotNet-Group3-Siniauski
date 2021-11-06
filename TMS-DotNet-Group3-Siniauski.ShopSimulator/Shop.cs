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
            return;
        }

        internal void PrintInfo()
        {
            return;
        }

        public void PrintConsoleImage()
        {
            return;
        }
    }
}