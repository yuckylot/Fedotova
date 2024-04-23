using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;

/*
 В файле хранятся данные следующей структуры:
        -год рождения
        -город рождения
        -страна рождения
Задание: необходимо создать 3 выходных файла. 
        *1 файл: данные сгруппированы по году рождения (без разницы, по возрастанию или убыванию), 
        *2 файл: сгруппировать по городам
        *3 файл: вывести данные тех, кто родился в определенной стране. Страна запрашивается пользователем.
 */
namespace Files
{
    class User
    {
        public string Id { get;}
        public string Year { get;}
        public string City { get;}
        public string Country { get;}

        public User(string id, string year, string city, string country)
        {
            Id = id;
            Year = year;
            City = city;
            Country = country;
        }

        public void ShowUserData()
        {
            Console.WriteLine($"Id {this.Id}, Год {this.Year}, Город {this.City}, Страна {this.Country}");
        }
        public string GetUserData()
        {
            return $"Id {this.Id}, Год {this.Year}, Город {this.City}, Страна {this.Country}";
        }
    }

    class Users
    {
        private List<User> Fields = new List<User>();

        public void AddUser(User user)
        {
            Fields.Add(user);
        }

        public void Show()
        {
            foreach (User user in Fields)
            {
                user.ShowUserData();
            }
        }
        public static string ReadString(string s = "")
        {
            if (s.Length > 0) { Console.WriteLine(s); }

            string key = "";
            bool flag = false;
            while (!flag)
            {
                key = Console.ReadLine() ?? "";
                if (key.Length > 0)
                {
                    flag = true;
                }
            }
            return key;

        }

        public User GetUserById(string id)
        {
            User user = new User(" ", " ", " ", " ");

            foreach (User x in Fields)
            {
                if (id == x.Id)
                {
                    user = x;
                    break;
                }

            }
            return user;
        }

        public void GetCountrys()
        {
            Dictionary<string, int> countrys = new Dictionary<string, int>();
            foreach (User x in Fields)
            {
                if (countrys.ContainsKey(x.Country))
                {
                    countrys[x.Country] += 1;
                }
                else
                {
                    countrys.Add(x.Country, 1);
                }
            }
            var keys = countrys.Keys;
            foreach (string key in keys)
            {
                Console.WriteLine(key);
            }
        }
        // *1 файл: данные сгруппированы по году рождения (без разницы, по возрастанию или убыванию)
        public void SortByYear(string path)
        {
            Dictionary<string, List<string>> userSameYear = new Dictionary<string, List<string>>();

            foreach (User x in Fields)
            {
                if (userSameYear.ContainsKey(x.Year))
                {
                    userSameYear[x.Year].Add(x.Id);
                }
                else
                {
                    userSameYear.Add(x.Year, new List<string> { x.Id });
                }
            }
            StringBuilder result = new StringBuilder();
            foreach (var item in userSameYear)
            {
                result.Append($"В {item.Key}: \n\n");
                foreach (var x in item.Value)
                {
                    User user = GetUserById(x);
                    result.Append(user.GetUserData() + "\n");
                }
                result.Append("____________________________\n\n");
            }

            File.WriteAllText(path, result.ToString());
        }

        //  *2 файл: сгруппировать по городам
        public void SortByCity(string path)
        {
            Dictionary<string, List<string>> userSameYear = new Dictionary<string, List<string>>();

            foreach (User x in Fields)
            {
                if (userSameYear.ContainsKey(x.City))
                {
                    userSameYear[x.City].Add(x.Id);
                }
                else
                {
                    userSameYear.Add(x.City, new List<string> { x.Id });
                }
            }
            StringBuilder result = new StringBuilder();
            foreach (var item in userSameYear)
            {
                result.Append($"В {item.Key}: \n\n");
                foreach (var x in item.Value)
                {
                    User user = GetUserById(x);
                    result.Append(user.GetUserData() + "\n");
                }
                result.Append("____________________________\n\n");
            }

            File.WriteAllText(path, result.ToString());
        }
        
        //*3 файл: вывести данные тех, кто родился в определенной стране. Страна запрашивается пользователем.
        public void SortByCountry(string path)
        {
            Dictionary<string, List<string>> userSameYear = new Dictionary<string, List<string>>();

            foreach (User x in Fields)
            {
                if (userSameYear.ContainsKey(x.Country))
                {
                    userSameYear[x.Country].Add(x.Id);
                }
                else
                {
                    userSameYear.Add(x.Country, new List<string> { x.Id });
                }
            }
            StringBuilder result = new StringBuilder();
            string country = ReadString("\nВведите Страну");

            if (userSameYear.ContainsKey(country))
            {
                result.Append($"\nВ {country}: \n\n");
                foreach (var item in userSameYear)
                {
                    foreach (var id in item.Value)
                    {
                        
                        User user = GetUserById(id);
                        if (user.Country == country)
                        {
                            result.Append(user.GetUserData() + "\n");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Попробуйте снова");
            }
            result.Append("____________________________\n\n");
            Console.WriteLine(result.ToString());
            File.WriteAllText(path, result.ToString());
        }


    }
    class Program
    {
        static void Main()
        {
            string path = @"..\..\..\Users.txt";

            string[] fileText = File.ReadAllLines(path);

            Users data = new Users();

            for (int i = 0; i < fileText.Length; i++)
            {
                string[] s = fileText[i].Split(", ");

                data.AddUser(new User(s[0], s[1], s[2], s[3]));
            }
            data.GetCountrys();
            data.SortByCountry(@"..\..\..\ByCountry.txt");
            data.SortByYear(@"..\..\..\ByYear.txt");
            data.SortByCity(@"..\..\..\ByCity.txt");
            Console.ReadKey();

        }
    }
}