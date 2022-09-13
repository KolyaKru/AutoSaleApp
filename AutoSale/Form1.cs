using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AutoSale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Установка фильтра расширения для сохрнанения
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        //Создание объекта Главное окно
        MainWindow window = new MainWindow();

        private void Form1_Load(object sender, EventArgs e)
        {
            //Добавление автомобилей в автосалон
            window.AddCar(new Car("Mazda", 1995, "Серый", 1500, 105, 5));
            window.AddCar(new Car("Dodge", 2018, "Красный", 68000, 707, 3));
            window.AddCar(new Car("BMW", 2002, "Розовый", 3500, 130, 6));
            window.AddCar(new Car("Jeep", 2015, "Красный", 32500, 325, 7));
            window.AddCar(new Car("Porsche", 2021, "Синий", 120000, 650, 2));
            window.AddCar(new Truck("ЗиЛ", 2008, "Синий", 15000, 3.6, 5));
            window.AddCar(new Truck("Daf", 2011, "Белый", 40000, 4.2, 6));
            window.AddCar(new Truck("MB", 2000, "Зелёный", 17000, 4.8, 7));
            window.AddCar(new Truck("Volvo", 2016, "Синий", 90000, 3.3, 6));
            window.AddCar(new Truck("Iveco", 2007, "Серый", 58000, 5, 11));
        }

        private void button1_Click(object sender, EventArgs e)                     //Кнопка Добавить Заказ
        {
            try
            {
                //Если номер заказа не повторяется, добавляем его
                if (window.CountRepeat(Convert.ToInt32(textBox1.Text)) == 0)
                {
                    window.AddOrder(new Order(Convert.ToInt32(textBox1.Text), dateTimePicker1.Value, comboBox2.SelectedItem.ToString()));
                    MessageBox.Show("Заказ Добавлен!");
                    groupBox4.Visible = true;
                    groupBox5.Visible = true;
                    groupBox6.Visible = true;
                    ReturnListBox3.DataSource = null;
                    ReturnListBox3.DataSource = window.ReturnListOrd;
                    ReturnListBox3.DisplayMember = "Info";
                    window.SelectOrder = (Order)ReturnListBox3.SelectedItem;
                    richTextBox1.Text = window.SelectOrder.ToString();
                    textBox1.Clear();
                    comboBox2.SelectedItem = null;
                }
                else { MessageBox.Show("Введите другой номер заказа"); }
            }
            catch { }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)     //Кнопка Легковые
        {
            try
            {
                //При нажатии на тип авто выводит соответсвующие автомобили из автосалона
                if (radioButton1.Checked == true)
                {
                    ReturnListBox1.DataSource = null;
                    ReturnListBox1.DataSource = window.ReturnListCar;
                }
            }
            catch { }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)    //Кнопка Грузовые
        {
            try
            {
                //При нажатии на тип авто выводит соответсвующие автомобили из автосалона
                if (radioButton2.Checked == true)
                {
                    ReturnListBox1.DataSource = null;
                    ReturnListBox1.DataSource = window.ReturnListTruck;
                }
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)              //Кнопка Добавить авто в заказ
        {       
            try
            {
                //Проверка класса выбранного объекта, и последующее добавление его в соотвествующий список заказа 
                //При добавлении в заказ, из списка автосалона логично, что удаляется
                if (ReturnListBox1.SelectedItem is Car)
                {
                    window.SelectOrder = (Order)ReturnListBox3.SelectedItem;
                    window.AddCarOrd((AllCars)ReturnListBox1.SelectedItem);
                    MessageBox.Show("Car " + ((Car)ReturnListBox1.SelectedItem).Brand + " успешно добавлен в " + window.SelectOrder.Info);
                    ReturnListBox1.DataSource = null;
                    ReturnListBox2.DataSource = null;
                    ReturnListBox1.DataSource = window.ReturnListCar;
                    ReturnListBox2.DataSource = window.SelectOrder.AllCarsOrd;
                    richTextBox1.Text = window.SelectOrder.ToString();
                }

                if (ReturnListBox1.SelectedItem is Truck)
                {
                    window.SelectOrder = (Order)ReturnListBox3.SelectedItem;
                    window.AddCarOrd((AllCars)ReturnListBox1.SelectedItem);
                    MessageBox.Show("Truck " + ((Truck)ReturnListBox1.SelectedItem).Brand + " успешно добавлен в " + window.SelectOrder.Info);
                    ReturnListBox1.DataSource = null;
                    ReturnListBox2.DataSource = null;
                    ReturnListBox1.DataSource = window.ReturnListTruck;
                    ReturnListBox2.DataSource = window.SelectOrder.AllCarsOrd;
                    richTextBox1.Text = window.SelectOrder.ToString();
                } 
            }
            catch { MessageBox.Show("Создайте или выберите необходимый заказ, для добавления автомобиля"); }
        }

        private void button5_Click(object sender, EventArgs e)          //Кнопка Удалить авто из заказа
        {
            try
            {
                //Проверка класса выбранного объекта, и последующее удаление из соотвествующего списка заказа
                //И добавление в список автосалона
                if (ReturnListBox2.SelectedItem is Car)
                {
                    window.SelectOrder = (Order)ReturnListBox3.SelectedItem;
                    window.DeleteCarOrd((AllCars)ReturnListBox2.SelectedItem);
                    MessageBox.Show("Car " + ((Car)ReturnListBox2.SelectedItem).Brand + " успешно удалён из " + window.SelectOrder.Info);
                    radioButton1.Checked = true;
                    ReturnListBox1.DataSource = null;
                    ReturnListBox1.DataSource = window.ReturnListCar;
                    ReturnListBox2.DataSource = null;
                    ReturnListBox2.DataSource = window.SelectOrder.AllCarsOrd;
                    richTextBox1.Text = window.SelectOrder.ToString();
                }

                if (ReturnListBox2.SelectedItem is Truck)
                {
                    window.SelectOrder = (Order)ReturnListBox3.SelectedItem;
                    window.DeleteCarOrd((AllCars)ReturnListBox2.SelectedItem);
                    MessageBox.Show("Truck " + ((Truck)ReturnListBox2.SelectedItem).Brand + " успешно удалён из " + window.SelectOrder.Info);
                    radioButton2.Checked = true;
                    ReturnListBox1.DataSource = null;
                    ReturnListBox1.DataSource = window.ReturnListTruck;
                    ReturnListBox2.DataSource = null;
                    ReturnListBox2.DataSource = window.SelectOrder.AllCarsOrd;
                    richTextBox1.Text = window.SelectOrder.ToString();
                }
            }
            catch { }
        }
           
        

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)      //Поведение Списка Заказов, при Изменении выбора заказа
        {
            if (listBox3.SelectedIndex != -1)
            {
                window.SelectOrder = (Order)ReturnListBox3.SelectedItem;
                richTextBox1.Text = window.SelectOrder.ToString();
                ReturnListBox2.DataSource = null;
                ReturnListBox2.DataSource = window.SelectOrder.AllCarsOrd;
            }
        }
    
        private void button6_Click(object sender, EventArgs e)              //Кнопка Удалить заказ
        {
            try
            {   
                //При удалении заказа, заказ удаляем из списка
                //Авто из заказа добавляем обратно в списки автосалон 
                window.DeleteOrder((Order)ReturnListBox3.SelectedItem);
                MessageBox.Show(((Order)ReturnListBox3.SelectedItem).Info + " удалён");
                ReturnListBox3.SelectedItem = null;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                ReturnListBox1.DataSource = null;
                ReturnListBox2.DataSource = null;
                ReturnListBox3.DataSource = null;
                richTextBox1.Clear();
                ReturnListBox3.DataSource = window.ReturnListOrd;
                ReturnListBox3.DisplayMember = "Info";
            }
            catch { }
        }

        private void button7_Click(object sender, EventArgs e)              //Кнопка Сохранить заказ
        {
            try
            {
                //Сохраняем заказ в .txt
                if (ReturnListBox3.SelectedIndex != -1)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string namefile = saveFileDialog1.FileName;
                        File.WriteAllText(namefile, richTextBox1.Text);
                        MessageBox.Show(((Order)ReturnListBox3.SelectedItem).Info + " сохранён!");
                    }
                }
            }
            catch { }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)   //Кнопка Выход
        {   
            Close();
        }

        //Свойства для получения листбоксов
        public ListBox ReturnListBox1 { get { return listBox1; } }
        public ListBox ReturnListBox2 { get { return listBox2; } }
        public ListBox ReturnListBox3 { get { return listBox3; } }
    }
}
