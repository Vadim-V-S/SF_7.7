using System;
using System.Collections.Generic;
using System.Text;

namespace SF_7._7_Proba
{
    class Order : Warehouse
    {
        public static Order[] orders;

        public Products this[int index] // индексатор
        {
            get
            {
                if (index >= 0 && index < products.Length)
                {
                    return products[index];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (index >= 0 && index < products.Length)
                {
                    products[index] = value;
                }
            }
        }

        public void ProductPicker()
        {
            Products prodOrder = new Products();
            int index = prodOrder.DataInput<int>(string.Format("\n\nВведите позицию продукта для заказа:\t"));
            var productOrder = products[index - 1];
            int orderAmount = prodOrder.DataInput<int>(string.Format("\nВведите количество для покупки:\t"));
            while(products[index - 1].AvailableProducts < orderAmount)
            {
                Console.WriteLine("Для заказа доступно не более {0}", products[index - 1].AvailableProducts);
                orderAmount = prodOrder.DataInput<int>(string.Format("\nВведите количество для покупки:\t"));
            }
                products[index - 1].AvailableProducts -= orderAmount;


            orders = new Order[1];
            orders[0] = new Order
            {
                OrderNumber = productOrder.OrderNumber,
                ProductName = productOrder.ProductName,
                OrdePrice = productOrder.OrdePrice,
                AvailableProducts = orderAmount
            };

            Console.Clear();
            Console.WriteLine("\t\t\tТОВАР НА СКЛАДЕ:\n");
            GetProducts(Products.products);
            Console.WriteLine("\n\n\t\t\tТОВАР В КОРЗИНЕ:\n");
            GetProducts(Order.orders);
            Console.WriteLine("\n\nДля оформления заказа нажмите любую клавишу:");
            Console.ReadKey();

            Execute();
        }

        public void Execute()
        {
            ExecuteOrder<Delivery> order = new ExecuteOrder<Delivery>(OrderNumber, ProductName, OrdePrice, AvailableProducts);
            order.MakeOrder();
        }
    }
}
