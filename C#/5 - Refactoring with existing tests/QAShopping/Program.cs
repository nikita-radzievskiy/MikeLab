using System;
using System.Collections.Generic;

namespace QAShopping
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> myBasket = new List<Item>
            {
                new Item { Id = 1, Name = "Baked beans", Price = 0.85, HasVat = false },
                new Item { Id = 2, Name = "Battenburg Cake", Price = 1, HasVat = true },
                new Item { Id = 3, Name = "Grannary Loaf", Price = 1.45, HasVat = false },
                new Item { Id = 4, Name = "Bottle of Red Wine", Price = 11.05, HasVat = true }
            };

            Console.WriteLine(Basket.PrintBasket(myBasket));
        }
    }
}
