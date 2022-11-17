namespace Ejercicio2
{
    internal class Program
    {
        public delegate void MyDelegate();
        public static bool MenuGenerator(string[] options, MyDelegate[] functions) //bool
        {
            int cont = 1;
            int i = 0;
            string opcMenu;
            bool result = false;
            
            

            if(functions.Length == options.Length && options != null) //!null
            {
                do
                {
                    Array.ForEach(options, item => Console.WriteLine("{0} {1}", cont++, item));
                    Console.WriteLine("{0} Salir",cont);
                    opcMenu = Console.ReadLine();
                    result = int.TryParse(opcMenu, out i);
                    if (result)
                    {
                        i = int.Parse(opcMenu);

                        if (i < 1 || i > options.Length + 1)
                        {
                            Console.WriteLine("Incorrect option, try again");
                        }
                        else if (i != options.Length + 1)
                        {

                            functions[i - 1]();//Accedemos a la funcion elegida
                        }
                    }
                    else
                    {
                        Console.WriteLine("Option must be a number");
                    }

                
                    
                    cont = 1;

                } while (i!=options.Length+1);

                return result;
                
            }
            else
            {
                Console.WriteLine("An error has ocurred with the parameters");
                result = true;
                
            }

            return result;


        }
        
        static void Main(string[] args)
        {

            MenuGenerator(new string[] { "Op1", "Op2", "Op3","OP" },
                            new MyDelegate[] { 
                            ()=>Console.WriteLine("A"),
                            ()=>Console.WriteLine("B"),  ()=>Console.WriteLine("D"),
                            ()=>Console.WriteLine("C")

                            });
            Console.ReadKey();
        }
    }
}