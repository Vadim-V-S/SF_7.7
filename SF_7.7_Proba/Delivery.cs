using System;
using System.Collections.Generic;
using System.Text;

namespace SF_7._7_Proba
{
    abstract class Delivery : Order
    {
        public string Address;
        public int OrderNum;
        public double OrderPrice;
        public Products Order = new Order();

        public Delivery()
        {
            OrderNum = orders[0].OrderNumber;
            ProductName = orders[0].ProductName;
            AvailableProducts = orders[0].AvailableProducts;
            OrdePrice = orders[0].OrdePrice * AvailableProducts;
        }

        virtual public void InputData(string str)
        {
            Address = Order.DataInput<string>(string.Format(str));
        }

        virtual public void DisplayDelivaryInfo()
        {
            Console.Clear();
            Console.WriteLine("Номер заказа:\t{0}", OrderNum);
            Console.WriteLine("Товар:\t{0}", ProductName);
            Console.WriteLine("Количество:\t{0}", AvailableProducts);
            Console.WriteLine("Стоимость:\t{0} руб", OrdePrice);
            Console.WriteLine("Адрес доставки:\t{0}", Address);
        }
    }

    class HomeDelivery : Delivery
    {
        public string ByerLastName;
        public string ByerFirstName;

        public HomeDelivery(string byerLastName, string byerFirstName)
        {
            ByerLastName = byerLastName;
            ByerFirstName = byerFirstName;
        }

        public override void DisplayDelivaryInfo()
        {
            InputData(string.Format("Введите адрес доставки на дом:\t"));
            base.DisplayDelivaryInfo();
            Console.WriteLine("Покупатель:\t{0} {1}", ByerFirstName, ByerLastName);
        }
    }

    class PickPointDelivery : Delivery
    {
        public PickPointDelivery() { }

        public override void DisplayDelivaryInfo()
        {
            InputData(string.Format("Введите адрес пункта выдачи:\t"));
            base.DisplayDelivaryInfo();
        }
    }

    class ShopDelivery : Delivery
    {
        public string ShopID;
        // public ShopDelivery(string shopID, int orderNumber, string productName, double price, int availableProducts)
        public ShopDelivery(string shopID)
        {
            ShopID = shopID;
        }
        public override void DisplayDelivaryInfo()
        {
            InputData(string.Format("Введите адрес мвгвзина:\t"));
            base.DisplayDelivaryInfo();
            Console.WriteLine("Название магазина выдачи:\t{0}", ShopID);
        }
    }

    class ExecuteOrder<TDelivery> : Delivery
    {
        //public TDelivery Delivery;

        public ExecuteOrder(int orderNumber, string productName, double price, int availableProducts)
        {
            OrderNumber = orderNumber;
            ProductName = productName;
            OrdePrice = price;
            AvailableProducts = availableProducts;
        }

        public void MakeOrder()
        {
            Order order = new Order();
            Console.WriteLine("Чтобы оформить доставку {0} на дом: введите - 1", order.ProductName);
            Console.WriteLine("Чтобы оформить покупку {0} через пункт выдачи: введите - 2", order.ProductName);
            Console.WriteLine("Чтобы оформить покупку {0} через магазин: введите - 3", order.ProductName);
            string caseSwitch = Console.ReadLine().ToLower();
            switch (caseSwitch)
            {
                case "1":
                    string byerLastName = order.DataInput<string>(string.Format("Введите фамилию:\t"));
                    string byerFirstName = order.DataInput<string>(string.Format("Введите имя:\t"));
                    var homeDelivery = new HomeDelivery(byerLastName, byerFirstName);
                    homeDelivery.DisplayDelivaryInfo();
                    break;
                case "2":

                    var pickPointDelivery = new PickPointDelivery();
                    pickPointDelivery.DisplayDelivaryInfo();
                    break;
                case "3":
                    string shopID = order.DataInput<string>(string.Format("Введите ID магазина:\t"));
                    var shopDelivery = new ShopDelivery(shopID);
                    shopDelivery.DisplayDelivaryInfo();
                    break;
                default:
                    Console.WriteLine("Введите вариант от 1 до 3");
                    Order orders = new Order();
                    orders.Execute();
                    break;
            }
        }
    }
}
