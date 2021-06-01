using System;
using System.Collections.Generic;
using System.Text;

namespace SF_7._7_Proba
{
    class Warehouse : Products // наследование
    {
        public Warehouse() { }

        public void GetProducts(Products[] array)
        {
            foreach (var NumOrder in array)
            {
                DisplayProducts(NumOrder);
            }
        }

        string Gap(int interval, char sym)
        {
            return "".PadRight(Math.Abs(interval), sym);
        }

        void DisplayProducts(Products product)
        {
            int interval1 = MaxProductLength - product.ProductName.Length;
            int interval2 = MaxPriceLength - product.OrdePrice.ToString().Length;
            string str = (string.Format("номер заказа {0,5} | Наименование - {1}{2} | Стоимость - {3} (руб.){4} | Количество - {5}",
                product.OrderNumber, Gap(interval1, ' '), product.ProductName, product.OrdePrice, Gap(interval2, ' '), product.AvailableProducts));
            Console.WriteLine(str);
        }

        public void ReturnAsCstomer()
        {
            Console.WriteLine("\n\nНажмите любую клавишу для входа как покупатель:");
            Console.ReadKey();

            Console.Clear();
            User.EntryAsBuyer();

        }
    }
}
