using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._4._Series_de_Fourier___Escalón
{
    class Aproximacion_Escalon_Suma_Senos
    {
        //El código en C# se corre presionando CTRL + F5
        //EJERCICIO TAREA 3.15 PROXIMAR UNA FUNCIÓN ESCALÓN AL SUMAR SEÑALES SENOIDALES:

        //Funciones para crear ambas expresiones matemáticas:
        //S(t, n, T) = (4/π)*Σ(1/(2i-1))*sin((2*(2i-1)*πt)/(T))
        static double S(double t, int n, double T)
        {
            double suma_senos = 0;
            for (int i = 1; i < n + 1; i++)
            {
                //#S(t, n, T) = Σ(1/(2i-1))*sin((2*(2i-1)*πt)/(T))
                suma_senos = suma_senos + 1.0 / (2 * i - 1) * Math.Sin((2 * ((2 * i) - 1) * Math.PI * t) / T);
            }
            //#S(t, n, T) = (4/π)*Σ(1/(2i-1))*sin((2*(2i-1)*πt)/(T))
            suma_senos = suma_senos * (4 / Math.PI);
            return suma_senos;
        }

        //f(t, T) = 1, 0, -1 que va de t=0 a t=T y se vuelve cero cuando t = T/2
        static int f(double t, double T)
        {
            int senal_escalon;
            if (0 < t && t < T / 2) //0<t<T/2
            {
                senal_escalon = 1;
            }
            /*Comparador con tolerancia, el método Math.Abs() saca el valor absoluto de una resta y si el resultado es
            menor a el número decimal descrito, el resultado es erróneo y en este caso t es igual a T/2, osea: t == T/2*/
            else if (Math.Abs(t - T / 2) < 1E-8) //t=T/2
            {
                senal_escalon = 0;
            }
            else if (T / 2 < t && t < T)//T/2<t<T
            {
                senal_escalon = -1;
            }
            else
            {
                Console.WriteLine("El vector t se sale del rango del tiempo, debe estar en el intervalo 0<t<T, intenta de nuevo");
                senal_escalon = 0;
            }
            return senal_escalon;
        }

        //Función main: Desde aquí se empieza a ejecutar todo el código
        static void Main(string[] args)
        {
            //Número de interaciones que se realizará a la función S(t, n, T) para acercarse a f(t, T)
            int[] iteraciones_S = { 1, 3, 5, 10, 30, 100 };
            //Periodo de la función senoidal = 2π
            double T = 2 * Math.PI;
            //Factor alfa de multiplicación para obtener un tiempo en específico respecto al periodo T
            double[] α = { 0.01, 0.25, 0.49, 0.5, 0.99 };
            //En C# al crear un array siempre de debe indicar su tamaño, el tamaño del array es igual al de α
            double[] tiempo = new double[α.Length];

            //Bucle for para rellenar el array del tiempo con la operación indicada:
            for (int i = 0; i < α.Length; i++)
            {
                //t = α*T
                tiempo[i] = α[i] * T;
            }

            //bucle for each: Recorre todos los elementos del array nombrado en el bucle
            foreach (int n in iteraciones_S)
            {
                Console.WriteLine("Número de sumas de Fourier: {0}", n);
                Console.WriteLine("1.- t = {0}*2π \tf(t, T) = {1}\tS(t, n, T) = {2}\t\tError = %{3}", α[0], f(tiempo[0], T), S(tiempo[0], n, T), 100 * Math.Abs(S(tiempo[0], n, T) - f(tiempo[0], T)));
                Console.WriteLine("2.- t = {0}*2π \tf(t, T) = {1}\tS(t, n, T) = {2}\t\tError = %{3}", α[1], f(tiempo[1], T), S(tiempo[1], n, T), 100 * Math.Abs(S(tiempo[1], n, T) - f(tiempo[1], T)));
                Console.WriteLine("3.- t = {0}*2π \tf(t, T) = {1}\tS(t, n, T) = {2}\t\tError = %{3}", α[2], f(tiempo[2], T), S(tiempo[2], n, T), 100 * Math.Abs(S(tiempo[2], n, T) - f(tiempo[2], T)));
                Console.WriteLine("4.- t = {0}*2π \t\tf(t, T) = {1}\tS(t, n, T) = {2}\tError = %{3}", α[3], f(tiempo[3], T), S(tiempo[3], n, T), 100 * Math.Abs(S(tiempo[3], n, T) - f(tiempo[3], T)));
                Console.WriteLine("5.- t = {0}*2π \tf(t, T) = {1}\tS(t, n, T) = {2}\t\tError = %{3}", α[4], f(tiempo[4], T), S(tiempo[4], n, T), 100 * Math.Abs(S(tiempo[4], n, T) - f(tiempo[4], T)));
                Console.WriteLine();
            }
        }
    }
}