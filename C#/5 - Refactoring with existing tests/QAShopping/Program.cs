using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAShopping
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic myBasket = new List<dynamic>();

            dynamic item1 = new { _id = 1, _name = "Baked beans", _price = 0.85, _vat = false };
            myBasket.Add(item1);
            Console.WriteLine(Basket.PrintBasket(myBasket));
            Console.WriteLine();

            dynamic item2 = new { _id = 2, _name = "Battenburg Cake", _price = 1, _vat = true };
            myBasket.Add(item2);
            Console.WriteLine(Basket.PrintBasket(myBasket));
            Console.WriteLine();

            dynamic item3 = new { _id = 3, _name = "Grannary Loaf", _price = 1.45, _vat = false };
            myBasket.Add(item3);
            Console.WriteLine(Basket.PrintBasket(myBasket));
            Console.WriteLine();

            dynamic item4 = new { _id = 4, _name = "Bottle of Red Wine", _price = 11.05, _vat = true };
            myBasket.Add(item4);
            Console.WriteLine(Basket.PrintBasket(myBasket));
            Console.WriteLine();
        }
    }
}