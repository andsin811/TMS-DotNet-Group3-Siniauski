using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopSimulator
{
    public class Cart
    {
        public List<Product> Products { get; set; }

        public double TotalCost
        {
            get => Products.Sum(p => p.Price);
        }

        public Cart(List<Product> products)
        {
            Products = products;
        }

        // Генерация корзины со случайным количесвом случайных продуктов из переданного списка (Татьяна)
        public static Cart GenerateRandomCart(List<Product> products)
        {
            return new Cart(products);
        }
    }
}