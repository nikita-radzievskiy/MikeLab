using System;
using System.Collections.Generic;
using NUnit.Framework;
using QAShopping;

namespace QAShoppingTests
{
    [TestFixture]
    public class PrintBasketTests
    {
        dynamic item1, item2, item3;
        dynamic basket;
        double vatRate = 1.2;

        [SetUp]
        public void SetUp()
        {
            item1 = new Item { Id = 1, Name = "Test", Price = 123.4, HasVat = false };
            item2 = new Item { Id = 2, Name = "Test name longer than 15", Price = 0.75, HasVat = false };
            item3 = new Item { Id = 3, Name = "Test", Price = 1.99, HasVat = true };

            basket = new List<Item> { item1, item2, item3 };
        }


        [Test]
        public void ShouldPrintAHeaderRowForTheBasket()
        {
            string actual = Basket.PrintBasket(basket);
            Console.WriteLine($"DEBUG OUTPUT:\n{actual}");  // Helps check formatting
            StringAssert.Contains("Item Name\t\t\tPrice\n", actual);
        }


        [Test]
        public void Should_print_the_item_name()
        {
            string actual = Basket.PrintBasket(basket);
            StringAssert.Contains($"{item1.Name}", actual);
        }

        [Test]
        public void Should_print_3_tabs_after_the_item_name_if_its_less_than_16_in_length()
        {
            string actual = Basket.PrintBasket(basket);
            StringAssert.Contains($"{item1.Name}\t\t\t", actual);
        }

        [Test]
        public void Should_print_2_tabs_after_the_item_name_if_its_16_or_in_length()
        {
            string actual = Basket.PrintBasket(basket);
            StringAssert.Contains($"{item2.Name}\t\t", actual);
            StringAssert.DoesNotContain($"{item2.Name}\t\t\t", actual);
        }

        [Test]
        public void Should_not_add_the_vat_to_the_item_price_if_vat_is_false()
        {
            string actual = Basket.PrintBasket(basket);
            StringAssert.Contains($"{item1.Price:0.00}", actual);
        }

        [Test]
        public void Should_add_the_vat_to_the_item_price_if_vat_is_true()
        {
            string actual = Basket.PrintBasket(basket);
            StringAssert.Contains($"{(item3.Price * vatRate):0.00}", actual);
        }

        [Test]
        public void Should_print_the_item_prices_fixed_to_2_decimal_places()
        {
            string actual = Basket.PrintBasket(basket);
            StringAssert.Contains("123.40", actual);
        }

        [Test]
        public void Should_print_a_newline_char_after_the_item_prices()
        {
            string actual = Basket.PrintBasket(basket);
            StringAssert.Contains("123.40\n", actual);
        }

        [Test]
        public void Should_only_print_the_name_and_price_on_a_row()
        {
            string actual = Basket.PrintBasket(basket);
            StringAssert.Contains("Test\t\t\t123.40\n", actual);
        }

        [Test]
        public void Should_print_a_newline_and_3_tabs_before_the_text_total_and_a_tab_after_it()
        {
            string actual = Basket.PrintBasket(basket);
            StringAssert.Contains("\n\t\t\tTotal\t", actual);
        }

        [Test]
        public void Should_print_a_total_of_the_basket()
        {
            double basketTotal = item1.Price + item2.Price + Math.Round((item3.Price * vatRate), 2);
            string actual = Basket.PrintBasket(basket);
            StringAssert.Contains($"£{basketTotal:0.00}", actual);
        }
    }
}