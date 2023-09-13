using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._5._Campana_de_Gauss
{
    class FuncionGaussiana
    {
        //El código en C# se corre presionando CTRL + F5
        //EJERCICIO TAREA 3.16 FUNCIÓN GAUSSIANA:

        static double gauss(double x, int m, int s)
        {
            double gauss = 0;

            gauss = Math.Exp(Math.Pow(((x - m) / s), 2) / (-2)) / (Math.Sqrt(2 * Math.PI) * s);


            return gauss;
        }

        //Función main: Desde aquí se empieza a ejecutar todo el código
        static void Main(string[] args)
        {
            //Rango de valores para los cuales se aplicará la función Gauss, esta estará en un intervalo de: [m-5s, m+5s]
            int m = 0;
            int s = 1;
            //número de valores
            int n = 30;
            //Número de elementos a los cuales se aplicará la función Gaussiana
            double[] x = new double[n + 1];
            double[] fg = new double[n + 1];

            //Número de elementos a los cuales se aplicará la función Gaussiana
            double r = (Math.Abs(m - 5 * s) + Math.Abs(m + 5 * s));//[m-5s, m+5s]
            double xi = r / n;//intervalo [m-5s, m+5s]/(n-1)

            //Creación de los valores con punto inicial m-5s, punto final m+5s e intervalo [m-5s, m+5s]/(n-1)
            for (int i = 0; i < n + 1; i++)
            {
                if (i == 0)
                {
                    x[i] = m - 5 * s;
                }
                else
                {
                    x[i] = x[i - 1] + xi;
                }
                fg[i] = gauss(x[i], m, s);//Aplicación de la función gauss
            }

            Console.WriteLine("\tx\t-----\t\tf(x)");
            /*Bucle for para crear la tabla con los valores de x y su resultado f(x) con la función Gauss e 
            imprimirla en consola*/
            for (int i = 0; i < n + 1; i++)
            {
                //Con la instrucción {num:F5} se limita a que se muestren 5 decimales de la variable.
                Console.Write(" x = {0:F5}\t-----\tf(x) = {1:F5}\n", x[i], fg[i]);
            }
        }
    }
}