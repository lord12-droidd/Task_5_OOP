using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Task_5
{

    class Program
    {
        private static void ReadX(int n_x, double[] x_array)
        {
            using (var sr = new StreamReader("x.txt"))
            {

                for (int i = 0; i< n_x; i++)
                {
                    try
                    {
                        x_array[i] = Convert.ToDouble(sr.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ви ввели некоректне(-ні) значення у файлі 'x.txt'");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
            }
        }
        private static void ReadY(int n_y, double[] y_array)
        {
            using (var sr = new StreamReader("y.txt"))
            {
                for (int i = 0; i < n_y; i++)
                {
                    try
                    {
                        y_array[i] = Convert.ToDouble(sr.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ви ввели некоректне(-ні) значення у файлі 'y.txt'");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
            }
        }

        private static void NewX(int n_x, double[] x_array, double[] new_arrx)
        {
            for(int i = 0; i < n_x; i++)
            {
                if (x_array[i] % 2 != 0)
                {
                    new_arrx[i] = x_array[i] + 5;
                }
                else
                {
                    new_arrx[i] = x_array[i];
                }
            }
        }
        private static void FormZ(int n_x,int n_y, double[] z_array, double[] x_array, double[] y_array)
        {
            File.WriteAllText("z.txt", String.Empty);
            Console.WriteLine("Елементи масиву z: ");
            if (n_y == n_x)
            {
                for (int i = 0; i < n_x; i++)
                {
                    z_array[i] = Math.Pow(x_array[i], 2) + Math.Pow(y_array[i], 2);
                    using (var sw = new StreamWriter("z.txt",true))
                    {
                        Console.WriteLine($"{z_array[i]}");
                        sw.WriteLine($"{z_array[i]}");
                        sw.Close();
                    }
                }
            }
            else
            {
                Console.WriteLine("Не можна сформувати масив 'z' так як різна кількість елементів в масивах");
            }
        }
        private static int LinesX(int n_x)
        {
            try
            {
                var lines = File.ReadAllLines("x.txt").Where(arg => !string.IsNullOrWhiteSpace(arg));
                File.WriteAllLines("x.txt", lines);
                n_x = File.ReadAllLines("x.txt").Length;
                if(n_x == 0)
                {
                    Console.WriteLine("Файл 'x.txt' - пустий, будь ласка, заповніть файл 'x.txt'");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                return n_x;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Будь ласка, створіть файл 'x.txt'");
                Console.ReadKey();
                Environment.Exit(0);
            }
            return n_x;
        }
        private static int LinesY(int n_y)
        {
            try
            {
                var lines = File.ReadAllLines("y.txt").Where(arg => !string.IsNullOrWhiteSpace(arg));
                File.WriteAllLines("y.txt", lines);
                n_y = File.ReadAllLines("y.txt").Length;
                if (n_y == 0)
                {
                    Console.WriteLine("Файл 'y.txt' - пустий, будь ласка, заповніть файл 'y.txt'");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                return n_y;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Будь ласка, створіть файл 'y.txt'");
                Console.ReadKey();
                Environment.Exit(0);
            }
            return n_y;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            int n_x = 0;
            n_x = LinesX(n_x);
            int n_y = 0;
            n_y = LinesY(n_y);
            double[] x_array = new double[n_x];
            double[] y_array = new double[n_y];
            double[] z_array = new double[n_y];
            ReadX(n_x, x_array);
            ReadY(n_y,y_array);
            for (int i = 0; i < n_x; i++)
            {
                NewX(n_x, x_array, x_array);
            }
            FormZ(n_x, n_y, z_array, x_array, y_array);
            Console.ReadKey();
        }
    }
}
