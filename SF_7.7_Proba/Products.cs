using System;
using System.Collections.Generic;
using System.Text;

namespace SF_7._7_Proba
{
    class Products
    {
        internal string ProductName { get; set; }
        internal int AvailableProducts { get; set; }
        internal double OrdePrice { get; set; }
        internal int Num { get; set; }

        internal int OrderNumber;

        internal int MaxProductLength;
        internal int MaxPriceLength;
        internal int amount;

        public Products() { }

        public static Products[] products;

        public Products(string productName, int availableProducts, double price)
        {
            ProductName = productName;
            AvailableProducts = availableProducts;
            OrdePrice = price;
        }

        public T DataInput<T>(string str) // обобщенный метод
        {
            Console.Write(str);
            if (typeof(T) == typeof(int))
            {
                int intType;
                while (!int.TryParse(Console.ReadLine(), out intType))
                    Console.WriteLine("Введите корректное число");
                return (T)Convert.ChangeType(intType, typeof(T));
            }
            else { return (T)Convert.ChangeType(Console.ReadLine(), typeof(T)); }
        }

        int MaxValue(string str1, int MaxLength)
        {
            if (str1.Length > MaxLength) { return MaxLength = str1.Length; } else { return MaxLength; }
        }

        public void InputProducts()
        {
            Console.Clear();
            amount = DataInput<int>(string.Format("Введите количество ассортимента:\t"));
            products = new Products[amount];
            for (int i = 0; i < amount; i++)
            {
                Console.Clear();
                ProductName = DataInput<string>(string.Format("Введите название продукта {0}:\t", i + 1));
                MaxProductLength = MaxValue(ProductName, MaxProductLength);

                OrdePrice = Math.Round(DataInput<double>(string.Format("Введите стоимость продукта {0}:\t", i + 1)), 1);
                MaxPriceLength = MaxValue(OrdePrice.ToString(), MaxPriceLength);

                Num = DataInput<int>(string.Format("Введите количество на складе {0}:\t", i + 1));

                ProductArray(i);
            }
        }

        public void ProductArray(int i)
        {
            products[i] = new Products()
            {
                OrderNumber = i + 1,
                ProductName = ProductName,
                OrdePrice = OrdePrice,
                AvailableProducts = Num
            };
        }
    }
}
