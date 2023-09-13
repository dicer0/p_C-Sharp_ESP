using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1._Área_Triángulo_con_Vértices
{
    class AreaTrianguloArbitrario
    {
        //El código en C# se corre presionando CTRL + F5
        //EJERCICIO TAREA 3.11 ÁREA DE UN TRIÁNGULO ARBITRARIO:
        static void Main(string[] args)
        {
            //Declaración de las variables double (número decimal) para poder hacer la operación que obtiene el área
            float x1, x2, x3, y1, y2, y3;
            //Coordenadas verticales y horizontales del primer vértice del triángulo
            Console.Write("Introduzca la coordenada x del primer vértice del triángulo: \t");
            x1 = float.Parse(Console.ReadLine());//Conversión a double de lo que viene de consola en forma String
            Console.Write("Introduzca la coordenada y del primer vértice del triángulo: \t");
            y1 = float.Parse(Console.ReadLine());
            //Coordenadas verticales y horizontales del segundo vértice del triángulo
            Console.Write("Introduzca la coordenada x del segundo vértice del triángulo: \t");
            x2 = float.Parse(Console.ReadLine());
            Console.Write("Introduzca la coordenada y del segundo vértice del triángulo: \t");
            y2 = float.Parse(Console.ReadLine());
            //Coordenadas verticales y horizontales del tercer vértice del triángulo
            Console.Write("Introduzca la coordenada x del tercer vértice del triángulo: \t");
            x3 = float.Parse(Console.ReadLine());
            Console.Write("Introduzca la coordenada y del tercer vértice del triángulo: \t");
            y3 = float.Parse(Console.ReadLine());

            double Resultado = areaTriangulo(x1, y1, x2, y2, x3, y3);
            Console.WriteLine("El área del triangulo con las coordenadas ({0}, {1}), ({2}, {3}) y ({4}, {5}) es de: {6}", x1, y1, x2, y2, x3, y3, Resultado);

        }

        public static float areaTriangulo(float x1, float y1, float x2, float y2, float x3, float y3)
        {
            float Area;
            /*El método abs de la clase Math saca el valor absoluto de la operación realizada en su paréntesis, que 
            sirve para obtener el área de un triángulo cualquiera*/
            Area = (float)0.5 * Math.Abs(x2 * y3 - x3 * y2 - x1 * y3 + x3 * y1 + x1 * y2 - x2 * y1);
            return Area;
        }
    }
}