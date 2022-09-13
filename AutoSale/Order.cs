using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace AutoSale
{
    class Order  //Класс Заказ
    {
        // Свойство Номер заказа
        public int Number { get; set; }

        // Свойство Дата заказа
        public DateTime DateOrder { get; set; }

        // Свойство Тип оплаты
        public string TypePayment { get; set; }

        // Свойство Итоговая цена
        public double TotalPrice { get; set; }

        // Свойство Краткая информация о заказе
        public string Info
        { get { return "Заказ №" + Number; } }

        private List<Car> carsord = new List<Car>();            //список легк. авто заказа
        private List<Truck> trucksord = new List<Truck>();      //список груз. авто заказа  
        private ArrayList allcarsord = new ArrayList();         //список всех авто заказа      

        // Свойство CarsOrd
        public List<Car> CarsOrd { get { return carsord; } set { carsord = value; } }

        // Свойство TrucksOrd
        public List<Truck> TrucksOrd { get { return trucksord; } set { trucksord = value; } }

        // Свойство AllCarsOrd
        public ArrayList AllCarsOrd { get { return allcarsord; }  }

        //Конструктор
        public Order(int number, DateTime dateorder, string typepayment, double totalprice = 0, List<Car> cars = null, List<Truck> trucks = null)
        {
            Number = number;
            DateOrder = dateorder;
            TypePayment = typepayment;
            TotalPrice = totalprice;

            //Если задаётся пустой список авто, то присваивается программный
            if (cars != null)                         
            {
                carsord = new List<Car>(cars);
            }

            if (trucks != null)
            {
                trucksord = new List<Truck>(trucks);
            }
        }

        //Метод Обновления списка всех авто
        public void RefreshAllList()
        {
            AllCarsOrd.Clear();
            AllCarsOrd.AddRange(CarsOrd);
            AllCarsOrd.AddRange(TrucksOrd);
        }

        //Переопределение виртуального метода ToString()
        public override string ToString()
        {
            string info;

            info = "Заказ № " + Number + "\nДата заказа: " + DateOrder + "\nТип оплаты: " + TypePayment + "\nCписок авто: ";

            if (CarsOrd != null)
            {
                for (int i = 0; i < CarsOrd.Count; i++)
                {
                    info += "\n" + ((Car)CarsOrd[i]).ToString();
                }
            }

            if (TrucksOrd != null)
            {
                for (int i = 0; i < TrucksOrd.Count; i++)
                {
                    info += "\n" + ((Truck)TrucksOrd[i]).ToString();
                }
            }

            info += "\nИтоговая цена: " + TotalPrice + "$";

            return info;
        }
    }
}
