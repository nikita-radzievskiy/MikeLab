using System;
using System.Collections.Generic;
using System.Text;

namespace QAShopping
{
    // Introduce a strongly typed Item class instead of using dynamic objects
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool HasVat { get; set; }

        public double GetFinalPrice()
        {
            return HasVat ? Math.Round(Price * 1.2, 2) : Price;
        }
    }

    public static class Basket
    {
        public static string PrintBasket(List<Item> basket)
        {
            // Use StringBuilder for efficient string concatenation
            StringBuilder basketOutput = new StringBuilder();
            basketOutput.AppendLine("Item Name\t\t\tPrice\n");


            double total = 0;

            foreach (var item in basket)
            {
                string tabSpacing = item.Name.Length < 16 ? "\t\t\t" : "\t\t";
                double finalPrice = item.GetFinalPrice();

                basketOutput.AppendFormat("{0}{1}{2:0.00}\n", item.Name, tabSpacing, finalPrice);
                total += finalPrice;
            }

            basketOutput.AppendFormat("\n\t\t\tTotal\t£{0:0.00}", total);

            return basketOutput.ToString();
        }
    }
}
