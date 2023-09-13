using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._3._Aproximación_de_Pi
{
    class AproximacionPi
    {
        //El código en C# se corre presionando CTRL + F5
        //EJERCICIO TAREA 3.13 APROXIMACIÓN DE PI:

        //Función para obtener la longitud de una ruta cualquiera:
        public static double longitudRuta(double[] x, double[] y)
        {
            double Longitud = 0, L = 0;
            //L = Σ√(xi - xi - 1) ^ 2 + (yi - yi - 1) ^ 2
            for (int i = 1; i < x.Length; i++)//Bucle for para realizar la sumatoria de los elementos
            {
                L = Math.Sqrt(Math.Pow((x[i] - x[i - 1]), 2) + Math.Pow((y[i] - y[i - 1]), 2));
                Longitud += L;
            }
            return Longitud;
        }

        /*Función para obtener el número de vértices del polígono con el que se pretende aproximar el valor de pi 
        al crear un círculo o lo que más se parezca teniendo (n^k)+1 vértices, la función recibe 1 parámetro y 
        retorna dos variables array tipo double.*/
        public static (double[], double[]) coordenadas_poligono(int num_vertices)
        {
            /*Declaración de los array vacíos que almacenarán las coordenadas x,y de cada uno de los vértices del 
            polígono que se aproxime al círculo de diámetro 1 para obtener el valor de pi, que es el perímetro del 
            círculo. El tamaño de los arrays se da por medio del parámetro num_vertices = (2^k)+1*/
            double[] x_p = new double[num_vertices];
            double[] y_p = new double[num_vertices];
            /*El bucle se tiene que ejecutar n + 1 veces, pero n = 2 ^ k, por lo tanto sebe ser:
            num_vertices = (n^k)+1 veces
            Pero este número de veces es el que recibe como parámetro la función.*/
            for (int i = 0; i < num_vertices; i++)
            {
                //xi = 1/2*cos(2*π*i/n) = 1/2*cos(2*π*i/(2^k)); i = n+1 = (2^k)+1
                x_p[i] = 0.5 * Math.Cos(2 * Math.PI * i / num_vertices);
                //yi = 1/2*sin(2*π*i/n) = 1/2*sin(2*π*i/(2^k)); i = n+1 = (2^k)+1
                y_p[i] = 0.5 * Math.Sin(2 * Math.PI * i / num_vertices);
            }
            return (x_p, y_p);
        }

        //Función main: Desde aquí se empieza a ejecutar todo el código
        static void Main(string[] args)
        {
            //n = base del número de vertices que tendrá el polígono que se aproxima al círculo para encontrar pi.
            int n = 2;
            /*Array k que debe almacenar todas las potencias de los n=2^k puntos en el polígono empezando desde 
            2 hasta el número 10.*/
            int[] k = new int[9];
            //Declaración de los arrays vacíos para obtener las coordenadas al usar la función coordenadas_poligono
            double[] coordenadas_x = new double[k.Length];
            double[] coordenadas_y = new double[k.Length];
            double[] circunferencias = new double[k.Length];
            for (int i = 0; i < k.Length; i++)
            {
                k[i] = (int)Math.Pow(n, i + 2);
                //Console.WriteLine(n[i]);
                (coordenadas_x, coordenadas_y) = coordenadas_poligono(k[i]);
                circunferencias[i] = longitudRuta(coordenadas_x, coordenadas_y);
                Console.WriteLine("Coordenadas del Pol[igono: {0}", k[i]);
                Console.WriteLine("Circunferencia = Valor de pi obtenido con la aproximación: {0}", circunferencias[i]);
                Console.WriteLine("Error: {0}", Math.PI - circunferencias[i]);
            }
        }
    }
}