using System;
using System.Collections;





namespace Phone1
{
    class Call
    {
        public string PhoneNumber;
        public string Date;
        public string StartTime;
        public int Minutes;

        public Call(string numberm, string date, string starttime, int mins)
        {
            this.PhoneNumber = numberm;
            this.Date = date;
            this.StartTime = starttime;
            this.Minutes = mins;
        }
        public void Show()
        {
            Console.WriteLine($"{PhoneNumber}, {Date}, {StartTime}, {Minutes}");
        }
    }
    class Program
    {
        static void Main()
        {
            Random rand = new Random();
            string[] phoneNumbers = { "+7 999 683 46 02", "+7 912 345 67 89", " +7 999 888 77 66", "+7 987 654 32 10" }; 
            Queue<Call> calls = new Queue<Call>(5);
            for (int i = 0; i < 10; i++)
            { 
        
                string phoneNumber = phoneNumbers[rand.Next(0, 3)];
                string callDate = $"{rand.Next(1, 31)}.{rand.Next(12,12)}.{rand.Next(2023,2023)}";
                string callTime = $"{rand.Next(0,23)}.{rand.Next(0,59)}";
                int durationMinutes = rand.Next(1,180);

                calls.Enqueue(new Call(phoneNumber, callDate, callTime, durationMinutes));
            }
            Dictionary<string, int> dict1 = new Dictionary<string, int>();
            Hashtable hash1 = new Hashtable();
            Dictionary<string, int> dict2 = new Dictionary<string, int>();
            Hashtable hash2 = new Hashtable();
            Call x;
            for (int i = 0; i < calls.Count; i++)
            {
                x = calls.Dequeue();
                if (dict1.ContainsKey(x.PhoneNumber))
                {
                    dict1[x.PhoneNumber] += x.Minutes;

                    hash1[x.PhoneNumber] = int.Parse(hash1[x.PhoneNumber].ToString()) + x.Minutes;
                }
                else if (!(dict1.ContainsKey(x.PhoneNumber)))
                {
                    dict1.Add(x.PhoneNumber, x.Minutes);
                    hash1.Add(x.PhoneNumber, x.Minutes);
                }

                if (dict2.ContainsKey(x.Date))
                {
                    dict2[x.Date] += x.Minutes;
                    hash2[x.Date] = int.Parse(hash2[x.Date].ToString()) + x.Minutes;
                }
                else
                {
                    dict2.Add(x.Date, x.Minutes);
                    hash2.Add(x.Date, x.Minutes);
                }

            }
            Console.WriteLine("\nData from Hashtable");
            foreach (string key in hash1.Keys)
            {
                Console.WriteLine(String.Format("Number: {0} -> {1} mins", key, hash1[key]));
            }
            Console.WriteLine("\nData from Dictionary");
            foreach (string key in dict1.Keys)
            {
                Console.WriteLine(String.Format("Number: {0} -> {1} mins", key, dict1[key]));
            }
            
            Console.WriteLine("\nData from Hashtable");
            foreach (string key in hash2.Keys)
            {
                Console.WriteLine(String.Format("Date: {0} -> {1} mins", key, hash2[key]));
            }
            Console.WriteLine("\nData from Dictionary");
            foreach (string key in dict2.Keys)
            {
                Console.WriteLine(String.Format("Date: {0} -> {1} mins", key, dict2[key]));
            }
        }
    }
}