using System;
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
            item1 = new { _id = 1, _name = "Test", _price = 123.4, _vat = false };
            item2 = new { _id = 2, _name = "Test name longer than 15", _price = 0.75, _vat = false };
            item3 = new { _id = 3, _name = "Test", _price = 1.99, _vat = true };
            basket = new dynamic[] { item1, item2, item3 };
        }

        [Test]
        public void ShouldPrintAHeaderRowForTheBasket()
        {
            string actual = Basket.PrintBasket(basket);
            StringAssert.Contains("Item Name\t\t\tPrice\n", actual);
        }

        [Test]
        public void Should_print_the_item_name()
        {
            string actual = Basket.PrintBasket(basket);
            StringAssert.Contains($"{item1._name}", actual);
        }

        [Test]
        public void Should_print_3_tabs_after_the_item_name_if_its_less_than_16_in_length()
        {
            string actual = Basket.PrintBasket(basket);
            StringAssert.Contains($"{item1._name}\t\t\t", actual);
        }

        [Test]
        public void Should_print_2_tabs_after_the_item_name_if_its_16_or_in_length()
        {
            string actual = Basket.PrintBasket(basket);
            StringAssert.Contains($"{item2._name}\t\t", actual);
            StringAssert.DoesNotContain($"{item2._name}\t\t\t", actual);
        }

        [Test]
        public void Should_not_add_the_vat_to_the_item_price_if_vat_is_false()
        {
            string actual = Basket.PrintBasket(basket);
            StringAssert.Contains($"{item1._price:0.00}", actual);
        }

        [Test]
        public void Should_add_the_vat_to_the_item_price_if_vat_is_true()
        {
            string actual = Basket.PrintBasket(basket);
            StringAssert.Contains($"{(item3._price * vatRate):0.00}", actual);
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
            double basketTotal = item1._price + item2._price + Math.Round((item3._price * vatRate), 2);
            string actual = Basket.PrintBasket(basket);
            StringAssert.Contains($"£{basketTotal:0.00}", actual);
        }
    }
}