using System;
using System.Collections.Generic;
using System.Text;

namespace SF_7._7_Proba
{
    class User
    {
        public static string user;
        static Warehouse products = new Warehouse();
        static Order order = new Order();

        public static void EntryAsSeller()
        {
            products.InputProducts();
            Console.Clear();
            Console.WriteLine("\t\t\tТОВАР НА СКЛАДЕ:\n");
            products.GetProducts(Products.products);
            products.ReturnAsCstomer();
        }

        public static void EntryAsBuyer()
        {
            Console.Clear();
            if (products.amount == 0)
            {
                Console.WriteLine("Товара на складе нет. Войдите как сотрудник");
                Program.Main();
            }
            user = "buyer";
            Console.WriteLine("\t\t\tСЕГОДНЯ В ПРОДАЖЕ:\n");
            products.GetProducts(Products.products);
            order.ProductPicker();
        }

        public static void UserEntry()
        {
            Console.WriteLine("Войти как покупатель: введите - ДА, иначе Войти как сотрудник");
            string caseSwitch = Console.ReadLine().ToLower();
            switch (caseSwitch)
            {
                case "да":
                    EntryAsBuyer();
                    break;
                default:
                    EntryAsSeller();
                    break;
            }
        }
    }
}
