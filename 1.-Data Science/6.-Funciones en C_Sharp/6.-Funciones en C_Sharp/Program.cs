using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Se usa la librería System Numerics, agregada dando clic derecho en la parte de:
//Explorador de soluciones -> Referencias -> Agregar Referencia -> Nombre Librería.
using System.Numerics;

//Para correr el código en consola se debe dar clic en CTRL + F5
namespace _6._Funciones_en_C_Sharp
{
    class DemoIntroFunciones
    {
        //Dentro de la clase se declaran las funciones
        //Función que no recibe parámetros ni retorna ningún valor
        static void ImprimirHola()
        {
            Console.WriteLine("Hola!");
        }

        //Función que recibe parámetros pero no retorna ningún valor, se debe indicar el tipo primitivo de los argumentos
        static void ImprimirSumarArgumentos(String argumento_1, String argumento_2)
        {
            Console.WriteLine(argumento_1 + argumento_2);
        }
        //Polimorfismo: Es cuando se declara una misma función pero con distintos tipos de datos primitivos para que 
        //sepa que hacer cuando le llegue cada uno.
        static void ImprimirSumarArgumentos(int argumento_1, int argumento_2)
        {
            Console.WriteLine(argumento_1 + argumento_2);
        }
        static void ImprimirSumarArgumentos(double argumento_1, double argumento_2)
        {
            Console.WriteLine(argumento_1 + argumento_2);
        }
        //Para poder usar números imaginarios se utiliza la librería System Numerics, agregada dando clic derecho en la
        //parte de Explorador de soluciones -> Referencias, esto para agregar polimorfismo a la función, pero para
        //usarla se deberá crear un objeto Complex
        static void ImprimirSumarArgumentos(Complex argumento_1, Complex argumento_2)
        {
            Console.WriteLine(argumento_1 + argumento_2);
        }

        //Función que no recibe parámetros pero retorna un valor
        static double RegresarPI()
        {
            return Math.PI;
        }
        //Función que recibe parámetros y retorna un valor, se hacen varias para que haya polimorfismo
        static String multiplicica_A_y_B(int repetir, String argumento)
        {
            //Variable intermedia donde se guarda el resultado del bucle for
            String result = "";
            for (int i = 0; i < repetir; i++)
            {
                //Concatenación de las palabras que se pongan en el segundo parámetro
                result = result + argumento;
            }
            return result; //Valor que retorna la función
        }
        static Complex multiplicica_A_y_B(Complex c1, Complex c2)
        {
            //Variable intermedia donde se guarda el resultado del bucle for
            Complex result;
            return result = c1 * c2; //Valor que retorna la función
        }

        //Método longitud de arco
        static double LongitudArco(double r, double thetaDeg)//Método estatico es aquel que no requiere de la creacion de un objeto para ser llamado
        {
            double thetaRad;
            thetaRad = (thetaDeg % 360.0) * (Math.PI / 180.0);//math es una clase que es un espacio de nombre y pi es una variable de instancia de math
            return thetaRad * r;
        }//Método longitud de arco

        //Método Área de Círculo
        private static double areaCirc(double radius)
        {
            return (Math.Pow(radius, 2)) * Math.PI;
        }//Método Área de Círculo

        //Método suma de los elementos de un vector
        static double GenerateVector(double x0, double xf, double deltax)
        {
            int numberPoints;
            double suma;
            numberPoints = Convert.ToInt32((xf - x0) / deltax);
            double[] geneVector = new double[numberPoints + 1];
            for (int i = 0; i < numberPoints + 1; i++)
            {
                geneVector[i] = i * deltax;
            }//for
            suma = 0;
            for (int i = 0; i < numberPoints + 1; i++)
            {
                suma = suma + geneVector[i];
            }//for
            return suma;
        }//Método suma de los elementos de un vector

        //Método para obtener el Área y Perímetro de un Círculo
        private static double[] x;
        private static double[] infoCirc(double radius)
        {
            double area;
            double perimetro;
            double[] vector = new double[2];
            area = (Math.Pow(radius, 2)) * Math.PI;
            perimetro = 2 * Math.PI * radius;
            vector[0] = area;
            vector[1] = perimetro;
            return vector;
        }//Método para obtener el Área y Perímetro de un Círculo




        //Método main: Dentro de él se mandan a llamar las funciones
        static void Main(string[] args)
        {
            Console.WriteLine("Funciones en C#:");
            //Dentro del método main se mandan a llamar las funciones
            ImprimirHola(); //Función que no recibe parámetros ni retorna ningún valor
            ImprimirSumarArgumentos("¡Hola", " Mundo!"); //Función que recibe parámetros pero no retorna ningún valor
            ImprimirSumarArgumentos(1, 2); //Función que recibe parámetros pero no retorna ningún valor
            ImprimirSumarArgumentos(1.0, 2.0); //Función que recibe parámetros pero no retorna ningún valor
            //Creación de un objeto Complex para declarar un número complejo que se utilizará en la función
            Complex a_c = new Complex(1, 2);
            Complex b_c = new Complex(1, 2);
            ImprimirSumarArgumentos(a_c, b_c); //Función que recibe parámetros pero no retorna ningún valor
            //Variable que almacenará el valor de la variable que usa el número PI retornado por la función
            double areaCirculo = RegresarPI() * Math.Pow(1, 2); //Función que no recibe parámetros y retorna un valor
            //Dentro de Console.WriteLine se pone {index} para indicar donde se imprime cada parámetro del método
            //indicado por su posición
            Console.WriteLine("El área del circulo unitario es: {0} y un número complejo es: {1}", areaCirculo, a_c);
            //Variable para almacenar el valor que retorna la función que usa polimorfismo
            String var_resultado_multiplicacion_1 = multiplicica_A_y_B(2, "Hola");
            Console.WriteLine(var_resultado_multiplicacion_1);
            //Creación de un objeto Complex para declarar un número complejo que se utilizará en la función
            Complex c1 = new Complex(1, 1);
            Complex c2 = new Complex(1, -1);
            Complex var_resultado_multiplicacion_2 = multiplicica_A_y_B(c1, c2);
            Console.WriteLine(var_resultado_multiplicacion_2);


            //Método longitud de arco
            double thetaDeg = 180;
            double r = 1;
            Console.WriteLine("s={0}", LongitudArco(r, thetaDeg));//writeline es un metodo de la clase console

            //Método Área de Círculo
            //impresion en pantalla de la llamada al metodo areacirculo
            Console.WriteLine("El área del circulo es:{0}", areaCirc(5).ToString("F5"));

            //Método suma de los elementos de un vector
            //impresion en pantalla de la llamada al metodo Generatevector()
            Console.WriteLine("la suma de los valores del vector es: {0}", GenerateVector(0, 10, 0.1).ToString("F5"));

            //Método para obtener el Área y Perímetro de un Círculo
            x = infoCirc(5);
            Console.WriteLine("El área del circulo es:{0} y su perimetro es: {1}", x[0].ToString("F5"), x[1].ToString("F5"));
        }//Método main
    }//Clase DemoIntroFunciones
}//Espacio de nombres
 //Para correr el código en consola se debe dar clic en CTRL + F5