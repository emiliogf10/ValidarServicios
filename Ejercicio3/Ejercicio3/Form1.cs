using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ejercicio3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string delimitar (string cadena)
        {
            if (cadena.Length >= 10)
            {
                string cambio = cadena.Substring(0, 7) + "...";
                return cambio;

            }
            else
            {
                return cadena;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Process[] processes = Process.GetProcesses();
                string format = "{0,10}{1,50}{2,50}\r\n";
                textBox1.Text = String.Format(format, "PID", "Name", "Main Window Name");
                foreach (Process process in processes)
                {

                    string ProcessN = process.ProcessName;
                    string MainName = process.MainWindowTitle;

                    //delimitar(ProcessN);
                    //delimitar(MainName);

                    //if (ProcessN.Length >= 10)
                    //{
                    //    ProcessN = ProcessN.Substring(0, 7)
                    //        + "...";
                    //}

                    //if (MainName.Length >= 10)
                    //{
                    //    MainName = MainName.Substring(0, 7)
                    //        + "...";
                    //}

                    string d = String.Format(format, process.Id, delimitar(ProcessN), delimitar(MainName));
                    textBox1.Text += (d);
                }
            }
            catch (ArgumentNullException)
            {

            }
            catch (FormatException)
            {
                
            }
            catch (ArgumentOutOfRangeException)
            {

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


            int texto = int.Parse(textBox2.Text);
            Process process = Process.GetProcessById(texto);
            ProcessModuleCollection pm = process.Modules;
            ProcessThreadCollection pt = process.Threads;
            textBox1.Text = String.Format("Name: {0}\r\n  PID: {1}\r\n  Main Window Tittle: {2}\r\n "
                , process.ProcessName, process.Id.ToString(), process.MainWindowTitle.ToString());
                textBox1.Text += "Modules:\r\n";

                for(int i = 0; i < pm.Count; i++)
                {
                    textBox1.Text += String.Format("Module: {0}\r\n File name:{1}\r\n\r\n", pm[i].ModuleName, pm[i].FileName);

                }
                textBox1.Text += "Subprocesses\r\n";
                for(int i = 0; i < pt.Count; i++)
                {
                    textBox1.Text += String.Format("Subproceso: {0}\r\n Start hour:{1}\r\n\r\n", pt[i].Id, pt[i].StartTime);

                }
            }
            catch(ArgumentNullException)
            {

            }
            catch(FormatException)
            {
                Console.WriteLine("Invalid format");
            }
            catch (Win32Exception)
            {

            }
            catch (InvalidOperationException)
            {

            }
            catch (NotSupportedException)
            {

            }
            catch (OverflowException)
            {

            }
        }

            

            



        

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int texto = int.Parse(textBox2.Text);
                Process.GetProcessById(texto).CloseMainWindow();
            }
            catch (InvalidOperationException)
            {

            }
            catch (ArgumentException)
            {

            }






        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int texto = int.Parse(textBox2.Text);
                Process.GetProcessById(texto).Kill();
            }
            catch (InvalidOperationException)
            {

            }
            catch (FormatException)
            {

            }
            catch (ArgumentException)
            {
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Process[] processes = Process.GetProcesses();
                string texto = textBox2.Text;
                Process p;

                p = Process.Start(texto);

            }
            catch (InvalidOperationException)
            {

            }
            catch (Win32Exception)
            {

            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            
            try
            {
                
                Process[] processes = Process.GetProcesses();
                textBox1.Text = "";
                string format = "{0,10}{1,50}\r\n";
                textBox1.Text += String.Format(format, "PID", "Name");
                string texto = textBox2.Text;
                foreach (Process process in processes)
                {


                        string ProcessN = process.ProcessName;
                       

                        if (ProcessN.Length >= 10)
                        {
                            ProcessN = ProcessN.Substring(0, 7)
                                + "...";
                        }

                    if (!textBox2.Text.Equals("")){

                        if (ProcessN.StartsWith(texto))
                        {



                            string d = String.Format(format, process.Id, ProcessN);
                            textBox1.Text += (d);
                        }
                        else
                        {
                            textBox1.Text = "No hay procesos que mostrar";
                        }
                    }

                        
                }

            }
            catch (InvalidOperationException)
            {

            }
            catch(FormatException)
            {

            }
            catch (Win32Exception)
            {

            }
            
            
           


        }


    }
}