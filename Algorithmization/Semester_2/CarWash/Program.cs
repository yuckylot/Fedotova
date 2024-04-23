using System;
/*
    Разработать программу, которая реализует взаимодействие следующих классов:
    автомобиль, гараж (гараж это коллекция автомобилей), 
    мойка (независимое предприятие, только принимает автомобили).
    Необходимо выполнить помывку всех автомобилей, делегируя выполнение работы мойке.
*/
namespace CarWash
{

    class Car
    {
        public int Number { get; set; }
        
        public string Color { get; set; }

        public bool IsWashed { get; set; }

        public Car(int number, string color, bool isWashed) 
        {
            this.Number = number;
            this.Color = color;
            this.IsWashed = isWashed;
        }

        public void ShowCar()
        {
            Console.WriteLine($"Номер: {this.Number} \tЦвет: {this.Color} \tМыта? {this.IsWashed}\n");
        }
    }

    class Garage
    {
        public List<Car> Cars { get; set; }

        public Garage(List<Car> cars) 
        {
            this.Cars = cars;
        }

        public static Garage FillGarage(int count)
        {
            List<Car> list = new List<Car>();

            string[] colors = { "Белый     ", "Чёрный    ", "Зеленый   ", "Голубой   ", "Серый     ", "Розовый   ", "Фиолетовый" };

            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                list.Add(new Car(rnd.Next(100, 1000), colors[rnd.Next(0, 7)], rnd.Next(0, 2) == 1));
            }

            Garage FilledGarage = new Garage(list);

            return FilledGarage;
        }
    }

    class CarWash
    {
        public static void Wash(Car car)
        {
            car.IsWashed = true;
        }
        public delegate void Washer(Car car);
    }



    class Program
    {
        static void Main() 
        {
            CarWash.Washer wash = CarWash.Wash;
            Garage garage = Garage.FillGarage(5);
            int i = 1;
            Console.WriteLine("Машины в гараже");
            foreach (Car x in garage.Cars)
            {
                Console.WriteLine(i++);
                x.ShowCar();
            }

            Console.WriteLine("Нажмите любую кнопку\n");
            Console.ReadKey();

            foreach (Car x in garage.Cars)
            {
                if (x.IsWashed) { Console.WriteLine($"!!! {x.Number} Уже чистая\n"); }
                else
                {
                    Console.WriteLine($"*** Моем {x.Number}\n");
                    wash(x);
                }
            }
            i = 1;
            Console.WriteLine("Машины помыты");
            foreach (Car x in garage.Cars)
            {
                Console.WriteLine(i++);
                x.ShowCar();
            }
        }
    }
}