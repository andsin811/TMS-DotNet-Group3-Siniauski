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

        public static Cart GenerateRandomCart(List<Product> products)

        {
            List<Product> cartProducts = new List<Product>();
            Random random = new Random();
            int countOfProducts = random.Next(1, products.Count + 1);
            while (cartProducts.Count < countOfProducts)
            {
                cartProducts.Add(products[random.Next(0, products.Count)]);
            }
            return new Cart(cartProducts);
        }
    }
}