using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopSimulator
{
    public class Customer
    {
        public Cart Cart { get; set; }

        public Customer(Cart cart)
        {
            Cart = cart;
        }

        public static void GenerateRandomCustomers(List<Product> products, List<Cash> cashes, CancellationToken token)
        {
            Random random = new Random();
            while (!token.IsCancellationRequested)
            {
                Customer customer = new Customer(Cart.GenerateRandomCart(products));
                List<Cash> cashesWithMinCountOfCustomers = cashes.Where(cash => cash.Customers.Count == cashes.Min(c => c.Customers.Count)).ToList();
                cashesWithMinCountOfCustomers[random.Next(0, cashesWithMinCountOfCustomers.Count)].Customers.Enqueue(customer);
                Task.Delay(500).Wait();
            }
        }
    }
}