using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Se usa la librería System Numerics, agregada dando clic derecho en la parte de:
//Explorador de soluciones -> Referencias -> Agregar Referencia -> Nombre Librería.
using System.IO; //Librería utilizada para poder manipular archivos

namespace _9._Abrir__Escribir_y_Leer_un_Archivo
{
    class EditarArchivoConConsola
    {
        //CÓDIGO PARA LEER UN CREAR, ESCRIBIR Y LEER EL CONTENIDO DE UN ARCHIVO CUALQUIERA:
        static void Main(string[] args)
        {
            Console.WriteLine("Escribe un mensaje: ");
            /*El método Console.ReadLine() sirve para permitir al usuario que ingrese algo por consola, que será de 
            tipo String por default*/
            string msg = Console.ReadLine();

            /*Para indicar una ruta en C# se debe poner un @ antes de indicar la ruta en cualquier string, es para que 
            no den errores en el programa cuando se usen caracteres especiales en los nombres de la dirección del 
            archivo y poder usar diagonales.
            Para leer una imagen o cualquier otro archivo se usa la dirección relativa o absoluta de un directorio: 
            - Dirección relativa: Es una dirección que busca un archivo desde donde se encuentra la carpeta del 
              archivo python actualmente, esta se debe colocar entre comillas simples o dobles.
            - Dirección absoluta: Es una dirección que coloca toda la ruta desde el disco duro C o cualquier otro 
              que se esté usando hasta la ubicación del archivo, la cual se debe colocar entre comillas simples o 
              dobles.
            ..      : Significa que nos debemos salir de la carpeta donde nos encontramos actualmente.
            /       : Sirve para introducirnos a alguna carpeta cuyo nombre se coloca después del slash.
            .ext    : Se debe colocar siempre el nombre del archivo + su extensión.*/
            string path = @"C:\Users\diego\OneDrive\Documents\MechaBible\p_C#\1.-Data Science\0.-Archivos_Ejercicios_C#\9.-Abrir, Escribir y Leer un Archivo\MensajeC#.txt";
            /*El método using hace uso de la librería System.IO, este método debe usar un objeto de la clase StreamWriter
            y recibe como parámetro un string que dé una dirección de algún archivo.*/
            using (StreamWriter objetoClaseStreamWriter = new StreamWriter(path))
            {
                objetoClaseStreamWriter.WriteLine(msg);
            }//using

            //Lectura del archivo
            string mensajeRecuperado = File.ReadAllText(path);

            //Despliegue del mensaje recuperado en consola
            Console.WriteLine(mensajeRecuperado);

        }//Método main: Desde el método main se ejecutan todas las partes del proyecto
    }//Clase del programa
}//Espacio de nombres: En esta parte del código se pueden declarar más de una clase que conforme el proyecto