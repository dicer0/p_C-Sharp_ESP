using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Se usa la librería System Numerics, agregada dando clic derecho en la parte de Explorador de soluciones -> Referencias ->
 *Agregar referencia -> System.Numerics -> Aceptar*/
using System.Numerics;

namespace _2._Raíces_de_una_Función_Cuadrática
{
    //El código en C# se corre en consola presionando CTRL+F5
    //CÓDIGO PARA INTRODUCIR EN CONSOLA LOS COEFICIENTES DE UN POLINOMIO CUADRÁTICO Y CALCULAR SUS RAÍCES:
    class Program
    {
        static void Main(string[] args)
        {
            //Decalaración de variables decimales a, b, c, r1 y r2 para obtener las raíces de una ecuación cuadrática
            double a, b, c, r1, r2;
            /*Método para imprimir en consola, usando la clase Console y su método WriteLine para imprimir en consola
            y después ejecutar un salto de línea.*/
            Console.WriteLine("Ingresa en consola los coeficientes de la ecuación cuadrática:");
            //GESTIÓN DE EXCEPCIONES
            /*TRY CATCH: Es una forma de decirle al código que debe hacer cuando ocurra un error, para ello se
            puede utilizar el try para indicar que debe hacer el código cuando no ocurra error y en el catch
            se declara lo que debe hacer el programa cuando ocurra un error.*/
            try
            {
                /*El método Console.ReadLine() sirve para permitir al usuario que ingrese algo por consola, que será de 
                tipo String y se usa el método Convert.ToDouble() para convertir el tipo primitivo del input que viene 
                siendo un String a un tipo numérico decimal Double y se guarde en la variable Grados*/
                //Lectura de coeficientes a, b y c de la fórmula cuadrática: ax2 + bx + c = 0
                Console.WriteLine("Ingresa el coeficiente a: ");
                a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Ingresa el coeficiente b: ");
                b = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Ingresa el coeficiente c: ");
                c = Convert.ToDouble(Console.ReadLine());
                //Operación para obtener las raíces: raiz1,2 = -b±√(b^2-4ac)/2a
                //El método Math.Sqrt() sirve para aplicar una raiz cuadrada al elemento que tenga dentro
                //El método Math.Pow() sirve para aplicar una exponente al elemento que tenga dentro, su primer parámetro
                //es la base y su segundo parámetro es la potencia.
                r1 = (-b + Math.Sqrt(Math.Pow(b, 2) - (4 * a * c))) / (2 * a);
                r2 = (-b - Math.Sqrt(Math.Pow(b, 2) - (4 * a * c))) / (2 * a);
                //Comprobación de que las raíces sean reales y no complejas (imaginarias)
                /*El método Double.IsNan() lo que hace es determinar si el número que se encuentra entre su paréntesis 
                es un número o no, si no lo es significa que es una raiz compleja, su valor será NaN (Not a Number) y 
                el método retornará un valor booleano true, si el parámetro del método es numérico retornará un valor 
                booleano false.*/
                /*La línea | es el operador lógico OR, por lo que si cualquiera de las raíces es real, las imprimirá
                en consola, solo si ambas son imaginarias se meterá al else indicando que las raíces son imaginarias*/
                if (Double.IsNaN(r1) == false | Double.IsNaN(r2) == false)
                {
                    /*Método para imprimir en consola, pero debe ser convertido antes a un tipo primitivo String con el 
                    métoto ToString() ya que solo se puede imprimir en consola datos de este tipo, lo que hace el 
                    parámetro que se le pasa al método ToString("F5"), es que cuando se convierta un dato numérico a 
                    String, el F5 hace que aparezcan 5 decimales, F3 haría que aparecieran solo 3, etc.*/
                    Console.WriteLine("La primera raiz es: {0}", r1.ToString("F5"));
                    Console.WriteLine("La segunda raiz es: {0}", r2.ToString("F5"));
                }
                else
                {
                    Console.WriteLine("Las raíces son imaginarias, ingresa en consola los coeficientes de la ecuación " +
                        "cuadrática imaginaria: ");
                    //Declaración de objetos de la clase Complex que pertenece a la librería System Numerics
                    Complex ai, bi, ci, r1i, r2i;
                    try
                    {
                        /*Conversión de los coeficientes en objetos Complex para obtener las raices imaginarias*/
                        ai = new Complex(a, 0);
                        bi = new Complex(b, 0);
                        ci = new Complex(c, 0);
                        //Calculo de las raíces imaginarias con los mismos métodos pero de la clase Complex en vez de Math
                        r1i = (-bi + Complex.Sqrt(Complex.Pow(bi, 2) - (4 * ai * ci))) / (2 * ai);
                        r2i = (-bi - Complex.Sqrt(Complex.Pow(bi, 2) - (4 * ai * ci))) / (2 * ai);
                        /*Impresión en consola de las raíces imaginarias, al imprimir números compejos el primer dato
                        es el número real y el segundo el imaginario*/
                        Console.WriteLine("La primera raiz es: {0}", r1i.ToString("F5"));
                        Console.WriteLine("La segunda raiz es: {0}", r2i.ToString("F5"));
                    }
                    catch
                    {
                        Console.WriteLine("Error con los datos ingresados");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error con los datos ingresados");
            }
        }//Método main: En este se corre el código de todas las clases del proyecto
    }//Clase del proyecto
}//Espacio de nombres: En esta parte se declaran todas las clases que se usen en el proyecto, puede haber más de 1