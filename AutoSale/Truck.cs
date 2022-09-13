using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSale
{
    class Truck : AllCars  ////Класс Грузовые авто (наследуемый от AllCars)
    {
        //Свойство Масса авто   
        public double Weight { get; set; }

        //Свойство Грузоподъёмность
        public int LoadCapacity {get; set;}

        //Конструктор
        public Truck(string brand, int yearbirth, string color, double price, double weight, int loadcapacity)
            : base(brand, yearbirth, color, price)
        {
            Color = color;
            Weight = weight;
            LoadCapacity = loadcapacity;
        }

        //Переопределение виртуального метода ToString()
        public override string ToString()
        {
            return "Truck: " + Brand  + " " + YearBirth + " г. " + Color + " Масса: " + Weight + "т." + " Грузоподёмность: " + LoadCapacity + "т." + " Цена: " + Price + "$";
        }
    }
}
