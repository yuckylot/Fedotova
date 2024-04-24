using System;

namespace Yuckylot
{
    class Program
    {
        
        static void Main()
        {
            string path1 = @".\\..\\..\\..\Input1.txt";
            string path2 = @".\\..\\..\\..\Input2.txt";
            string path3 = @".\\..\\..\\..\Output.txt";

            StreamReader reader_1 = new StreamReader(path1);
            StreamReader reader_2 = new StreamReader(path2);

            int num1 = Convert.ToInt32(reader_1.ReadLine());
            int num2 = Convert.ToInt32(reader_2.ReadLine());
            int check = 0;

            File.WriteAllText(path3, "");

            while (true)
            {
                if (num1 < num2)
                {
                    File.AppendAllText(path3, num1.ToString() + "\n");
                    string read1 = reader_1.ReadLine();
                    if (read1 != null)
                    {
                        num1 = Convert.ToInt32(read1);
                    }
                    else { check = 1; break; }

                }
                else
                {
                    File.AppendAllText(path3, num2.ToString() + "\n");
                    string read2 = reader_2.ReadLine();
                    if (read2 != null)
                    {
                        num2 = Convert.ToInt32(read2);
                    }
                    else { check = 2; break; }
                }
            }

            if (check == 2)
            {
                File.AppendAllText(path3, num1.ToString() + "\n");
                while (true)
                {
                    string read1 = reader_1.ReadLine();
                    if (read1 != null)
                    {
                        num1 = Convert.ToInt32(read1);
                        File.AppendAllText(path3, num1.ToString() + "\n");
                    }
                    else { break; }
                }
            }

            else if (check == 1)
            {
                File.AppendAllText(path3, num2.ToString() + "\n");
                while (true)
                {
                    string read2 = reader_2.ReadLine();
                    if (read2 != null)
                    {
                        num2 = Convert.ToInt32(read2);
                        File.AppendAllText(path3, num2.ToString() + "\n");
                    }
                    else { break; }
                }
            }
            Console.WriteLine("Succses");
        }
    }
}