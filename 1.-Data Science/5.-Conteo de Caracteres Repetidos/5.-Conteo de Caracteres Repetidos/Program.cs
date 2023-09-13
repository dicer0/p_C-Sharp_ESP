using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//El código se corre dando clic en CTRL + F5
namespace _5._Conteo_de_Caracteres_Repetidos
{
    //Namespace: Es una parte del código donde se puede crear una biblioteca con varias clases y cuando queramos crear otra
    //clase podemos importar el namespace del proyecto y eso va a importar todas las clases que lo conforman
    class ExtraerCaracteresDeString
    {
        static void Main(string[] args)
        {
            //El programa lo que hará es leer un string e indicar cuantas veces aparece cada una de sus letras.
            string st = "google.com";
            int n = st.Length; //Número de caracteres
            char temp;
            int[] chIndex = new int[0]; //Array con 0 elementos
            int count = 0;
            int[] chNewIndex = new int[0];
            int hold;
            int comp;
            int index;
            int[] freq;
            int sumFreq;
            for (int i = 0; i < n; i++)
            {
                temp = st[i];
                for (int j = 0; j < n; j++)
                {
                    if (temp == st[j])
                    {
                        count = count + 1;
                        //El Método rezise lo que hace es aumentar el tamaño de un array, en específico aumenta
                        //el tamaño del array chIndex que ahora tiene tamaño de 0 elementos, se usa la palabra
                        //reservada ref para declarar a qué Array se le quiere modificar su tamaño
                        Array.Resize(ref chIndex, count);
                        chIndex[i] = j;
                        break;
                    }//if
                }//for j
            }//for i

            //Bucle for para la impresión en pantalla del arreglo chIndex
            Console.WriteLine("Arreglo chIndex");
            for (int i = 0; i < chIndex.Length; i++)
            {
                Console.Write(chIndex[i] + " ");
            }
            Console.WriteLine();//Para imprimir en consola un salto de línea

            Array.Sort(chIndex);//Con esto se ordenan en forma ascendente los elementos del array chIndex

            //Bucle for para la impresión en pantalla del arreglo chIndex ordenado de forma ascendente
            Console.WriteLine("Arreglo chIndex ordenado en forma ascendente");
            for (int i = 0; i < chIndex.Length; i++)
            {
                Console.Write(chIndex[i] + " ");
            }
            Console.WriteLine();//Para imprimir en consola un salto de línea

            index = 0;
            Array.Resize(ref chNewIndex, chNewIndex.Length + 1);//Aumenta el tamaño de un array
            chNewIndex[chNewIndex.Length - 1] = chIndex[0];

            for (int i = 0; i < chIndex.Length; i++)
            {
                int v = chIndex[index];
                hold = v;
                //comp = index;
                //for (; comp < chIndex.Length; comp++){}
                //Esto lo que hace es lo mismo que el for que se define abajo
                for (comp = index; comp < chIndex.Length; comp++)
                {
                    if (hold != chIndex[comp])
                    {
                        index = comp;
                        Array.Resize(ref chNewIndex, chNewIndex.Length + 1);
                        chNewIndex[chNewIndex.Length - 1] = chIndex[comp];
                        break;
                    }//if
                }//for
            }//for

            //Bucle for para la impresión en pantalla del arreglo chNewIndex
            Console.WriteLine("Arreglo chNewIndex");
            for (int i = 0; i < chNewIndex.Length; i++)
            {
                Console.Write(chIndex[i] + " ");
            }
            Console.WriteLine();//Para imprimir en consola un salto de línea


            freq = new int[chNewIndex.Length];
            for (int i = 0; i < chNewIndex.Length; i++)
            {
                sumFreq = 0;
                for (int j = 0; j < n; j++)
                {
                    if (chIndex[j] == chNewIndex[i])
                    {
                        sumFreq = sumFreq + 1;
                    }//if
                    freq[i] = sumFreq; //Asignación de valor al array freq
                }//for j
            }//for i

            Console.WriteLine("Arreglo frecuencia:");
            for (int i = 0; i < freq.Length; i++)
            {
                Console.Write(freq[i] + " ");
            }//for
            Console.WriteLine();//Para imprimir en consola un salto de línea

            //Impresión de resultado
            for (int i = 0; i < freq.Length; i++)
            {
                Console.WriteLine("El caracter {0}, apareció {1} veces", st[chNewIndex[i]], freq[i]);
            }
        }//Método Main
    }//Clase del proyecto
}//Espacio de nombres
 //El código se corre dando clic en CTRL + F5