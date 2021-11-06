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

        // Генерация случайных пользователей со случайными корзинами с переодичностью в 500 мс пока !token.IsCancellationRequested и добавление в одну из наименьших очередей (Татьяна)
        public static void GenerateRandomCustomers(List<Product> products, List<Cash> cashes, CancellationToken token)
        {
            return;
        }
    }
}