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
        private static void Read(int n, double[] array, string filename)
        {
            using (var sr = new StreamReader(filename))
            {
                for (int i = 0; i < n; i++)
                {
                    try
                    {
                        array[i] = Convert.ToDouble(sr.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Ви ввели некоректне(-ні) значення у файлі {filename}");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
                Console.WriteLine($"Елементи файлу {filename}: ");
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(array[i]);
                }
            }
        }


        private static void NewX(int n_x, double[] x_array, double[] new_arrx)
        {
            for (int i = 0; i < n_x; i++)
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
        private static void FormZ(int n_x, int n_y, double[] z_array, double[] x_array, double[] y_array)
        {
            File.WriteAllText("z.txt", String.Empty);
            if (n_y == n_x)
            {
                Console.WriteLine("Елементи масиву z: ");
                for (int i = 0; i < n_x; i++)
                {
                    z_array[i] = Math.Pow(x_array[i], 2) + Math.Pow(y_array[i], 2);
                    using (var sw = new StreamWriter("z.txt", true))
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


        private static int Lines(int n, string filename)
        {
            try
            {
                var lines = File.ReadAllLines(filename).Where(arg => !string.IsNullOrWhiteSpace(arg));
                File.WriteAllLines(filename, lines);
                n = File.ReadAllLines(filename).Length;
                if (n == 0)
                {
                    Console.WriteLine($"Файл {filename} - пустий, будь ласка, заповніть файл {filename} ");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                return n;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Будь ласка, створіть файл {filename} ");
                Console.ReadKey();
                Environment.Exit(0);
            }
            return n;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Dictionary<string, int> fileLines = new Dictionary<string, int>
            {
                {"x.txt", 0},
                {"y.txt", 0}
            };
            int n = 0;
            foreach (string file in fileLines.Keys.ToList())
            {
                fileLines[file]=Lines(n, file);
            }
            double[] x_array = new double[fileLines["x.txt"]];
            double[] y_array = new double[fileLines["y.txt"]];
            double[] z_array = new double[fileLines["y.txt"]];
            Read(fileLines["x.txt"], x_array, "x.txt");
            Read(fileLines["y.txt"], y_array, "y.txt");
            Console.WriteLine($"Оновлені елементи файлу 'x.txt': ");
            for (int i = 0; i < fileLines["x.txt"]; i++)
            {
                NewX(fileLines["x.txt"], x_array, x_array);
                Console.WriteLine(x_array[i]);
            }
            
            FormZ(fileLines["x.txt"], fileLines["y.txt"], z_array, x_array, y_array);
            Console.ReadKey();
        }
    }
}
