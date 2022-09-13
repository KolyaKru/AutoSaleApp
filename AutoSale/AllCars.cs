using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSale
{
    public abstract class AllCars   //Абстрактный класс Автомобили (родительский) 
    {
        //Свойсво Бренд
        public string Brand { get; set; }

        //Свойсво Год изготовления
        public int YearBirth { get; set; }

        //Свойство Цвет
        public string Color { get; set; }

        //Свойство Цена
        public double Price { get; set;}

        //Конструктор
        public AllCars(string brand, int yearbirth, string color, double price)
        {
            Color = color;
            Brand = brand;
            YearBirth = yearbirth;
            Price = price;
        }
    }
}
