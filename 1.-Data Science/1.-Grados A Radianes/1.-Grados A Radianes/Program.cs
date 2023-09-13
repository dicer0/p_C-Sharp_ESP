using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._Grados_A_Radianes
{
    class ConversionGradosARadianes
    {
        //El código en C# se corre presionando CTRL + F5
        //CÓDIGO PARA INTRODUCIR EN CONSOLA GRADOS Y CONVERTIR A RADIANES:
        static void Main(string[] args)
        {
            //Declaración de las variables que almacenan el ángulo en grados y radianes, ambas son de tipo double
            double Grados, Radianes;
            //Declaración de la variable result que es de tipo String y se imprimirá en consola
            String Result;
            /*Método para imprimir en consola, usando la clase Console y su método WriteLine para imprimir en consola
            y después ejecutar un salto de línea.*/
            Console.WriteLine("Ingresa un ángulo en grados: ");
            //GESTIÓN DE EXCEPCIONES
            /*TRY CATCH: Es una forma de decirle al código que debe hacer cuando ocurra un error, para ello se
            puede utilizar el try para indicar que debe hacer el código cuando no ocurra error y en el catch
            se declara lo que debe hacer el programa cuando ocurra un error.*/
            try
            {
                /*El método Console.ReadLine() sirve para permitir al usuario que ingrese algo por consola, que será de 
                tipo String y se usa el método Convert.ToDouble() para convertir el tipo primitivo del input que viene 
                siendo un String a un tipo numérico decimal Double y se guarde en la variable Grados*/
                Grados = Convert.ToDouble(Console.ReadLine());
                //Fórmula para convertir grados a radianes, usa la constante PI de la clase Math
                Radianes = Grados*(Math.PI/180);
                /*Método para imprimir en consola, pero debe ser convertido antes a un tipo primitivo String con el 
                métoto ToString() ya que solo se puede imprimir en consola datos de este tipo, lo que hace el 
                parámetro que se le pasa al método ToString("F5"), es que cuando se convierta un dato numérico a 
                String, el F5 hace que aparezcan 5 decimales, F3 haría que aparecieran solo 3, etc.*/
                Result = Radianes.ToString("F5");
                /*Cuando se quiere contatenar valores en C#, lo que se hace es usar el método Console.WriteLine y 
                luego en donde se quiera colocar el valor de la variable se pone su índice, este depende del órden en 
                el que se hayan declarado los parámetros puestos en el método después del mensaje impreso en consola, 
                se indica de la siguiente manera: {indice}*/
                Console.WriteLine("El ángulo en radianes es: {0} del ángulo {1} ingresado en grados", Result, Grados);
            }
            catch
            {
                Console.WriteLine("Ingresa un ángulo válido");
            }
        }//Método main: Desde el método main se ejecutan todas las partes del proyecto
    }//Clase del programa
}//Espacio de nombres: En esta parte del código se pueden declarar más de una clase que conforme el proyecto