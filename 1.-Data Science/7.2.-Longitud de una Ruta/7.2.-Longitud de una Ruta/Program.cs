using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._2._Longitud_de_una_Ruta
{
    class LongitudRutaArbitraria
    {
        //El código en C# se corre presionando CTRL + F5
        //EJERCICIO TAREA 3.12 LONGITUD DE UN CAMINO ARBITRARIO:

        //Función para obtener la longitud de una ruta cualquiera:
        public static double longitudRuta(float[] x, float[] y)
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

        static void Main(string[] args)
        {
            Console.WriteLine("Indique el número de coordenadas del camino (igual o mayor que 2)");
            //Conversión a int del valor proveniente de la consola en forma de String
            int num_coordenadas = Convert.ToInt32(Console.ReadLine());
            //Condicional para evaluar si el número de coordenadas es mayor o igual a 2
            if (num_coordenadas < 2)
            {
                Console.WriteLine("Un camino no puede tener solo una coordenada, deben ser mínimo más de 2");
            }
            else
            {
                //Declaración de dos arrays vacíos tipo double donde se almacenarán todos los puntos de las coordenadas
                //de la ruta
                float[] x = new float[num_coordenadas];
                float[] y = new float[num_coordenadas];
                //Dependiendo del número de coordenadas que haya introducido el usuario, se ejecutará varias veces el
                //bucle para que el usuario las introduzca todas 
                for (int i = 0; i < num_coordenadas; i++)
                {
                    Console.Write("Ingrese la coordenada horizontal del punto x{0}: \t", i + 1);
                    x[i] = float.Parse(Console.ReadLine());
                    Console.Write("Ingrese la coordenada vertical del punto y{0}: \t", i + 1);
                    y[i] = float.Parse(Console.ReadLine());
                }
                double Longitud_total = longitudRuta(x, y);
                Console.WriteLine("La distancia total de la ruta con {0} puntos tiene una longitud de {1}", num_coordenadas, Longitud_total);
            }
        }
    }
}