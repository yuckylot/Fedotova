using System;
using System.Dynamic;
using System.Linq;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

/*
    Даны сведения о товарах на складах (несколько!) компании 
            поля: 
            * артикул товара
            * наименование товара
            * категория товара
            * кол-во товара(на данном складе)
            * цена за единицу
            * склад размещения
    С помощью запросов узнать:
            - объем товара в денежном эквиваленте по каждом складу
            - максимальную цену по каждой категории
            - среднюю цену товара по каждому складу и по всем складам (всех товаров на складе)
            - определить самый дешевый товар
            - вывести данные по складу, в котором наименьшая суммарная стоимость товаров (вывести все данные)
    Хранение данных: можно несколько классов, может быть один класс 
*/

namespace Yuckylot
{
    class Company
    {
        public string Name;
        public List<StoreHouse> Stores;
        public List<Item> Items;

        public Company(string name) 
        {
            Name = name;
            Stores = new List<StoreHouse>();
            Items = Item.GenerateRandomItem();
        }

        public void AddStorage(List<StoreHouse> stores)
        {
            foreach (StoreHouse x in stores)
            {
                if (stores.Count > 0)
                {
                    Stores.Add(x);

                }
            }
        }

        public void FillStorage()
        {
            foreach (StoreHouse store in Stores)
            {
                store.GenerateRundomProduct(Items);
            }          
        }

        public void GetAllSumFromStores()
        {
            Console.WriteLine("\nОбъем товара в денежном эквиваленте по каждом складу:");
            foreach(StoreHouse x in Stores)
            {
                
                Console.WriteLine($"На скаладе {x.Id} товара на сумму {Math.Round(x.GetAllSum(),2)}");
            }
        }
        public void MaxPriceInCategories()
        {
            List<Product> products = new List<Product>();
            foreach(StoreHouse store in Stores)
            {
                products.AddRange(store.Items);
            }
            Console.WriteLine("\nМаксимальная цена по каждой категории:");
            products
                .GroupBy(item => item.Category)
                .Select(y => new
                {
                    key = y.Key,
                    value = y.Max(x => x.Price)
                })
                .ToList()
                .ForEach(x => 
                Console.WriteLine($"В катогории {x.key} наибольшая цена {Math.Round(x.value, 2)} ")
                );

        }
        public void AveragePrice()
        {
            Console.WriteLine("\nСредняя цена товара по каждому складу и по всем складам (всех товаров на складе):");

            foreach (StoreHouse store in Stores)
            {
                Console.WriteLine($"На складе {store.Id} средняя цена товара: {Math.Round(store.Items.Average(x => x.Price), 2)}");
            }

            List<Product> products = new List<Product>();
            foreach (StoreHouse store in Stores)
            {
                products.AddRange(store.Items);
            }
            Console.WriteLine($"По всем складам средняя цена товара: {Math.Round(products.Average(x => x.Price), 2)}");
        }
        public void CheapestProduct() 
        {
            List<Product> products = new List<Product>();
            foreach (StoreHouse store in Stores)
            {
                products.AddRange(store.Items);
            }
            Product cheapest = products.Where(x => x.Price == products.Min(x => x.Price)).First();
            Console.WriteLine($"\nСамый дешевый товар: арт: {cheapest.Art} { cheapest.Name }  по цене {Math.Round(cheapest.Price, 2)} на складе {cheapest.StoreHouse_Id}");
        }
        public void DataOfStoreHouseWithMinAllSum()
        {
            List<double> Sums = Stores
                .Select(x => x.GetAllSum())
                .ToList();

            Stores
                .Where(x => x.GetAllSum() == Sums.Min())
                .First()
                .GetAllStoreHouseData();
        }
    }
    class Product
    {
        public string Art;
        public string Name;
        public string Category;
        public int Conut;
        public double Price;
        public string StoreHouse_Id;
        public Product(Item item, int count, double price, string stock)
        { 
            Art = item.Art;
            Name = item.Name;
            Category = item.Category;
            Conut = count;
            Price = price;
            StoreHouse_Id = stock;
        }

        
    }
    
    class Item
    {
        public string Art;
        public string Name;
        public string Category;
        
        public Item(string art, string cat, string name)
        {
            Art = art;
            Name = name;
            Category = cat;
        }

        public void Show()
        {
            Console.WriteLine($"Art: {Art}, Name: {Name}, Category: {Category}");
        }

        public static List<Item> GenerateRandomItem()
        {
            List<Item> items = new List<Item>();

            Random rnd = new Random();

            List<string> arts = new List<string> {
                "A1234", "B5678", "C9876", "D2345",
                "E7890", "F1234", "G5678", "H9876",
                "I2345", "J7890", "K1234", "L5678",
                "M9876", "N2345", "O7890", "P1234",
                "Q5678", "R9876", "S2345", "T7890" 
            };
            List<string> categories = new List<string> { "Electronics", "Accessories"};
            List<string> electronicsProducts = new List<string> { "Laptop     ", "Smartphone ", "Printer    ", "TV         " };
            List<string> accessoriesProducts = new List<string> { "Smart Watch", "Headphones ", "PowerBank  "};

            foreach (string art in arts)
            {
                string cat = categories[rnd.Next(0,2)];
                if (cat == categories[0])
                {
                    items.Add(new Item(art, cat, electronicsProducts[rnd.Next(0, 4)]));
                }
                else if (cat == categories[1])
                {
                    items.Add(new Item(art, cat, accessoriesProducts[rnd.Next(0, 3)]));
                }
                
            }
            return items;
        }
    }

    class StoreHouse
    {
        public string Id;
        public List<Product> Items;
        public StoreHouse(string id)
        {
            Id = id;
            Items = new List<Product>();
        }

        public void GenerateRundomProduct(List<Item> items)
        {
            List<Product> products = new List<Product>();

            Random rnd = new Random();

            foreach (Item item in items) 
            {
                products.Add(new Product(item, rnd.Next(0, 5000), rnd.NextDouble() * 100000, Id));
            };

            Items =  products;
        }

        public double GetAllSum()
        {
            return Items
                .Select(x => x.Conut * x.Price)
                .ToList()
                .Sum();
        }
        public void GetAllStoreHouseData()
        {
            Console.WriteLine($"\nСклад {Id} \nОбщая стоимость товаров со склада {Math.Round(GetAllSum(), 2)} \nТовары на складе:\n");
            foreach (Product prod in Items)
            {
                Console.WriteLine($"Название: {prod.Name} | Категория: {prod.Category} | Артикул: {prod.Art} | Цена: {Math.Round(prod.Price, 2)} | Кол-во на складе: {prod.Conut}");
            }
        }
    }
    class Program
    {
        static void Main()
        {
            
            Company company = new Company("Store");

            company.AddStorage(new List<StoreHouse>() 
            {
                new StoreHouse("01"),
                new StoreHouse("02"),
                new StoreHouse("03") 
            });
            company.Items.ForEach(x => x.Show());
            company.FillStorage();



            company.GetAllSumFromStores();
            company.MaxPriceInCategories();
            company.AveragePrice();
            company.CheapestProduct();
            company.DataOfStoreHouseWithMinAllSum();
        }
    }
}