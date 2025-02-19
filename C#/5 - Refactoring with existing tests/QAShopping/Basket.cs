
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAShopping
{
    public static class Basket
    {
        public static string PrintBasket(dynamic basket)
        {
            string basketOutput = "Item Name\t\t\tPrice\n";
            double total = 0;
            foreach (dynamic item in basket)
            {
                foreach (var property in item.GetType().GetProperties())
                {
                    switch (property.Name)
                    {
                        case "_name":
                            basketOutput += $"{property.GetValue(item)}";
                            basketOutput += property.GetValue(item).Length < 16 ? "\t\t\t" : "\t\t";
                            break;
                        case "_price":
                            double price = property.GetValue(item);
                            bool vat = item.GetType().GetProperty("_vat").GetValue(item);
                            double priceToAdd = vat ? Math.Round(price * 1.2, 2) : price;
                            basketOutput += $"{priceToAdd:0.00}\n";
                            total += priceToAdd;
                            break;
                        case "_id":
                        case "_vat":
                        default:
                            break;
                    }
                }
            }
            basketOutput += $"\n\t\t\tTotal\t£{total:0.00}";
            return basketOutput;
        }
    }
}