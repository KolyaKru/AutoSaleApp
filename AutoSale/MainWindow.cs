using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSale
{
    class MainWindow   //Класс Главное окно 
    {
        private List<Order> allorder = new List<Order>();       //список заказов
        private List<Car> allcars = new List<Car>();            //список легк. авто в автосалоне
        private List<Truck> alltrucks = new List<Truck>();      //список груз. авто в автосалоне 
        Order order;                                            //обьект класса Заказ

        //Свойство Возврат списка легк. авто
        public List<Car> ReturnListCar { get { return allcars; } }

        //Свойство Возврат списка груз. авто
        public List<Truck> ReturnListTruck { get { return alltrucks; } }

        //Свойство Возврат списка заказов
        public List<Order> ReturnListOrd { get { return allorder; } }

        //Свойство Выбор заказа из списка
        public Order SelectOrder { get { return order; } set { order = value; } }

        //Метод Добавление авто в автосалон 
        public void AddCar(AllCars car)
        {
            if (car is Car)
            {
                ReturnListCar.Add((Car)car);
            }

            if (car is Truck)
            {
                ReturnListTruck.Add((Truck)car);
            }
        }

        //Метод Удаление авто из автосалона
        public void DeleteCar(AllCars car)
        {
            if (car is Car)
            {
                ReturnListCar.Remove((Car)car);
            }

            if (car is Truck)
            {
                ReturnListTruck.Remove((Truck)car);
            }

        }

        //Метод Добавление авто в заказ
        public void AddCarOrd(AllCars car)
        {
            if (car is Car)
            {
                SelectOrder.CarsOrd.Add((Car)car);
                SelectOrder.TotalPrice += ((Car)car).Price;
                SelectOrder.RefreshAllList();
                DeleteCar((Car)car);
            }

            if (car is Truck)
            {
                SelectOrder.TrucksOrd.Add((Truck)car);
                SelectOrder.TotalPrice += ((Truck)car).Price;
                SelectOrder.RefreshAllList();
                DeleteCar((Truck)car);
            }
            
        }

        //Метод Удаление авто из заказа
        public void DeleteCarOrd (AllCars car)
        {
            if (car is Car)
            {
                SelectOrder.TotalPrice -= ((Car)car).Price;
                SelectOrder.CarsOrd.Remove((Car)car);
                SelectOrder.RefreshAllList();
                AddCar((Car)car);
            }

            if (car is Truck)
            {
                SelectOrder.TotalPrice -= ((Truck)car).Price;
                SelectOrder.TrucksOrd.Remove((Truck)car);
                SelectOrder.RefreshAllList();
                AddCar((Truck)car);
            } 
        }

        //Метод Добавление заказа в автосалон
        public void AddOrder(Order order)
        {
            ReturnListOrd.Add(order);
        }

        //Метод Удаление заказа из автосалона
        public void DeleteOrder(Order order)
        {
            ReturnListCar.AddRange(order.CarsOrd);
            ReturnListTruck.AddRange(order.TrucksOrd);
            ReturnListOrd.Remove(order);
        }

        //Метод Поверка на повтор номера заказа
        public int CountRepeat(int number)
        {
            int count = 0;
            for(int i = 0; i< ReturnListOrd.Count; i++)
            {
                if (((Order)ReturnListOrd[i]).Number == number)
                    count++;
            }
            return count;
        }

        //Конструктор
        public MainWindow() { }   
    }
}
