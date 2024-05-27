using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;


class Relations
{
    public string Id;
    public ArrayList Podchin = new ArrayList();

    public Relations(string id, ArrayList pod)
    {
        Id = id;
        if (pod.Count > 0)
        {
            foreach (string i in pod) { Podchin.Add(i); }
        }
    }
    public void AppendPodchin(string id)
    {
        Podchin.Add(id);
    }
}

class Program
{
    static void Main()
    {
        ArrayList All = new ArrayList();
        SortedSet<string> Result = new SortedSet<string>();
        Dictionary<string, string> Names = new Dictionary<string, string>();

        void Check_pod(Relations user, ArrayList allPods)
        {
            if (user.Podchin.Count > 0)
            {
                foreach (string i in user.Podchin)
                {
                    foreach (Relations us in All)
                    {
                        if (us.Id == i) { allPods.Add(i); }
                    }
                    foreach (Relations us in All)
                    {
                        if (us.Id == i) { Check_pod(us, allPods); }
                    }
                }
            }
            else { foreach(string s in allPods) { Result.Add(s); } }
        }

        while (true)
        {
            string nach = Console.ReadLine();
            bool checkN;
            bool checkP;
            if( nach != "END") 
            {
                if(nach.Count() != 4)
                {
                    string[] input = nach.Split(' ');
                    nach = input[0];
                    if (Names.ContainsKey(nach) == false) 
                    {
                        if (input.Count() == 3)
                        {
                            Names.Add(nach, input[1] + " " + input[2]);
                        }
                        else
                        {
                            Names.Add(nach, input[1]);
                        }
                    }
                }
                string pod = Console.ReadLine();
                if (pod.Count() != 4)
                {
                    string[] input = pod.Split(' ');
                    pod = input[0];
                    if (Names.ContainsKey(pod) == false) 
                    {
                        if (input.Count() == 3)
                        {
                            Names.Add(pod, input[1] + " " + input[2]);
                        }
                        else
                        {
                            Names.Add(pod, input[1]);
                        }
                    }
                }
                checkN = false;
                checkP = false;
                foreach (Relations user in All)
                {
                    if (user.Id == nach)
                    {
                        user.AppendPodchin(pod);
                        checkN = true;
                        break;
                    }
                    if(user.Id == pod) { checkP = true; }
                }
                if(checkN == false) 
                {
                    All.Add(new Relations(nach, new ArrayList { pod }));
                }
                if(checkP == false) { All.Add(new Relations(pod, new ArrayList{ })); }
            }
            else
            {
                bool output = false;
                string neededID = Console.ReadLine();
                if (neededID.Count() != 4)
                {
                    foreach(var i in Names) { if(i.Value == neededID) { neededID = i.Key;break; } }
                }
                Console.WriteLine("----");
                foreach (Relations user in All)
                {
                    if (user.Id == neededID)
                    {
                        Check_pod(user, new ArrayList { });
                        foreach(string id in Result) 
                        { 
                            Console.Write(id);
                            if (Names.ContainsKey(id)) { Console.WriteLine($" {Names[id]}"); }
                            else { Console.WriteLine(" Unknown Name"); }
                            output = true;
                        }
                        break;
                    }
                }
                if(output == false) { Console.WriteLine("NO"); }
                break;
            }
        }
    }
}