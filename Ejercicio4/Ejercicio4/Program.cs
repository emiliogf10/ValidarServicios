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
                //Se crea una seccion critica con el lock, que hace que otro hilo no pueda cambiar cont hasta que este acabe 
                //toda la ejecucion
                lock (l)
                {
                    //Se vuelve a comprobar que finished es false porque no se sabe cuando un hilo puede parar su ejecucion para darle paso al otro;
                    //con lo cual, si haces la comprobacion de arriba, se ejecuta otro hilo y finished se pone a true, tienes que tener
                    //otra comprobacion para que el programa sepa que tiene que parar.
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

                    if (cont == -1000)
                    {
                        finished = true;
                    }


                }



            }





        }
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(increase);
            Thread thread2 = new Thread(decrease);

            thread1.Start();
            thread2.Start();

            //thread1.Join();
            //thread2.Join();

            if (cont == 1000)
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