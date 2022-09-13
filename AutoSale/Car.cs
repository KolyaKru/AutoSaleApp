using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSale
{
    class Car : AllCars  //Класс Легковые авто (наследуемый)
    {
        //Свойство Количество посадочных мест
        public int KolSeats { get; set; }

        //Свойство Мощность
        public int HorsePower { get; set; }
 
        //Конструктор
        public Car(string brand, int yearbirth, string color, double price, int horsepower, int kolseats)
            : base(brand, yearbirth,color, price)
        {
            HorsePower = horsepower;
            KolSeats = kolseats;
        }

        //Переопределение виртуального метода ToString()
        public override string ToString()
        {
            return "Car: " + Brand + " " + YearBirth + " г. " + Color + " Мощность: " + HorsePower + "л.с." + " Колич. мест: " + KolSeats + " Цена: " + Price + "$";
        }
    }
}
