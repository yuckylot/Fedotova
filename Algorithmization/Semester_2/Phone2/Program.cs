using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;





namespace Phone2
{
    class Call
    {
        public string PhoneNumberOut;
        public string Date;
        public string PhoneNumberIn;
        public int Minutes;

        public Call(string numberOut, string date, string numberIn, int mins)
        {
            this.PhoneNumberOut = numberOut;
            this.Date = date;
            this.PhoneNumberIn = numberIn;
            this.Minutes = mins;
        }
        public void Show()
        {
            Console.WriteLine($"{PhoneNumberOut}, {Date}, {PhoneNumberIn}, {Minutes}");
        }
    }
    class Program
    {
        static void Main()
        {
            Random rand = new Random();
            string[] phoneNumbers = {
                    "+9 (123) 456-7890",
                    "+7 (234) 567-8901",
                    "+7 (345) 678-9012",
                    "+7 (456) 789-0123",
                    "+7 (567) 890-1234",
                    "+7 (678) 901-2345",
                    "+7 (789) 012-3456",
                    "+7 (890) 123-4567",
                    "+7 (901) 234-5678",
                    "+7 (012) 345-6789"
            };
            List<Call> calls = new List<Call>(300);
            for (int i = 0; i < 300; i++)
            {

                string phoneNumberOut = phoneNumbers[rand.Next(0, 10)];
                string phoneNumberIn = phoneNumbers[rand.Next(0, 10)];
                while (phoneNumberIn == phoneNumberOut)
                {
                    phoneNumberIn = phoneNumbers[rand.Next(0, 10)];
                }
                string callDate = $"{rand.Next(1, 31)}.{rand.Next(12, 12)}.{rand.Next(2023, 2023)}";
                int durationMinutes = rand.Next(1, 180);

                calls.Add(new Call(phoneNumberOut, callDate, phoneNumberIn, durationMinutes));
            }

            Dictionary<string,int> OutInCount = new Dictionary<string, int>();
            Dictionary<string,int> OutInMins = new Dictionary<string,int>();
            Call x;
            string ad;
            for (int i = 0; i < calls.Count; i++)
            {
                x = calls[i];
                ad = $"{x.PhoneNumberOut} => {x.PhoneNumberIn}";
                if (!(OutInCount.ContainsKey($"{x.PhoneNumberOut} => {x.PhoneNumberIn}")))
                {
                    OutInCount.Add(ad, 1);
                    OutInMins.Add(ad, x.Minutes);
                }
                else
                {
                    OutInCount[ad] = int.Parse(OutInCount[ad].ToString()) + 1;
                    OutInMins[ad] = int.Parse(OutInMins[ad].ToString()) + x.Minutes;
                }
            }
            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                Console.WriteLine($"{i+1}. {phoneNumbers[i]}");
            }
            Console.WriteLine("Choose number");
            string input = Console.ReadLine();

            while (input != "")
            {
                if (input == "" )
                {
                    Console.WriteLine("bye");
                    Console.ReadKey();
                }
                if (!(Convert.ToInt32(input) > phoneNumbers.Length || Convert.ToInt32(input) < 1))
                {

                    string neededNumber = phoneNumbers[Convert.ToInt32(input)-1];
                    List<string> listCalls = new List<string>();
                    foreach (string call in OutInCount.Keys) 
                    {
                        if (call.Contains($"{neededNumber} => "))
                        {
                            listCalls.Add(call);
                        }
                    }
                    Dictionary<string, int> sortedNumsCount = new Dictionary<string, int>();
                    Dictionary<string,int> sortedNumsMins = new Dictionary<string,int>();
                    listCalls.ForEach(call => {
                        sortedNumsCount.Add(call, OutInCount[call]);
                        sortedNumsMins.Add(call, OutInMins[call]);
                    });
                    if (sortedNumsCount.Count > 0)
                    {
                        Console.WriteLine("Maxium Calls");
                        int maxValueCount = sortedNumsCount.Values.Max();
                        var keysWithMaxValueCount = sortedNumsCount.Where(x => x.Value == maxValueCount).Select(x => x.Key);

                        foreach (var key in keysWithMaxValueCount)
                        {
                            Console.WriteLine($"{key}: {maxValueCount} times");
                        }
                        Console.WriteLine("Maxium Calls Time");
                        int maxValueMins = sortedNumsMins.Values.Max();
                        var keysWithMaxValueMins = sortedNumsMins.Where(x => x.Value == maxValueMins).Select(x => x.Key);

                        foreach (var key in keysWithMaxValueMins)
                        {
                            Console.WriteLine($"{key}: {maxValueMins} mins");
                        }
                        input = Console.ReadLine();

                    }
                    else 
                    {
                        Console.WriteLine("This number doesn`t have calls");
                        input = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("This number doesn`t have calls");
                    input = Console.ReadLine();
                }

            }
        }
    }
}
