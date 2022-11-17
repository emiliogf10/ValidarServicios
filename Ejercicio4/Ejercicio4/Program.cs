namespace Ejercicio4

{
    
    internal class Program
    {
        static int cont = 0;
        static readonly object l = new object();
        static bool finished = false;

        static void increase()
        {
           
                while (!finished)
                {
                    lock (l)
                    {
                        if (!finished)
                        {
                            cont++;
                            Console.WriteLine("Increase: {0}", cont);
                            
                             if (cont == 1000)
                             {
                                finished = true;
                             }
                        }


                    }

                
                
                }
            
        }

        static void decrease()
        {
                while (!finished)
                {
                    lock (l)
                    {
                        if (!finished)
                        {
                            cont--;
                            Console.WriteLine("Decrease: {0}", cont);
                        }




                    }

                if (cont == -1000){
                    finished = true;
                }
                
            }

           
            

            
        }
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(increase);
            Thread thread2 = new Thread(decrease);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            if(cont == 1000)
            {
                Console.WriteLine("Thread 1 wins");
            }
            else
            {
                Console.WriteLine("Thread 2 wins");
            }




        }
    }
}