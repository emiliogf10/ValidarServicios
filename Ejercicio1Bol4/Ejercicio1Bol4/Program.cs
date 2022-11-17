using System.Diagnostics;

namespace Ejercicio1Bol4
{
    internal class Program
    {


        static void Main(string[] args)
        {
            int[] v = { 2, 2, 6, 7, 1, 10, 3 };
            int[] aprobados = Array.FindAll(v, item => item >= 5);//Exist

            Console.WriteLine("Approved grades");
            Array.ForEach(aprobados, item => Console.WriteLine(item));

            Console.WriteLine("Last index of approved students");
            Console.WriteLine(Array.FindLastIndex(v, item => item >= 5));

            Console.WriteLine("Inverse of num");
            Array.ForEach(v, item => Console.WriteLine(1.0 / item));

            Array.ForEach(v, item => { Console.ForegroundColor = item >= 5 ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine($"Student grade: {item,3}.");
                Console.ResetColor();
            }); 
            int res = Array.FindIndex(v, item =>item>=5);

        }


    }
}