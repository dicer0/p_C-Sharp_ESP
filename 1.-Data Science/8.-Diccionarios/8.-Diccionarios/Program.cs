using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8._Diccionarios
{
    class FrecuenciadeNumDiccionario
    {
        //Método FrecuenciaCaracterDiccionario
        static void char_frequency(string str1)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            dict.Clear(); //Limpia el diccionario
            foreach (char caracter in str1)
            {
                try
                {
                    //Si no existe la llave entra al try
                    dict.Add(caracter, 1);
                }
                catch
                { //Si existe la llave ejecuta la instruccipn del catch
                    dict[caracter] += 1;
                }
            }
            //Impresión del diccionario
            foreach (KeyValuePair<char, int> kvp in dict)
            {
                Console.WriteLine("El caracter {0} apareció {1} veces", kvp.Key, kvp.Value);
            }
        }


        //Método FrecuenciaNúmeroDiccionario
        static void element_frequency(double[] x)
        {
            Dictionary<double, int> dict = new Dictionary<double, int>();
            dict.Clear(); //Limpia el diccionario
            foreach (double caracter in x)
            {
                try
                {
                    //Si no existe la llave entra al try
                    dict.Add(caracter, 1);
                }
                catch
                { //Si existe la llave ejecuta la instruccipn del catch
                    dict[caracter] += 1;
                }
            }
            //Impresión del diccionario
            foreach (KeyValuePair<double, int> kvp in dict)
            {
                Console.WriteLine("El caracter {0} apareció {1} veces", kvp.Key, kvp.Value);
            }
        }


        static void Main(string[] args)
        {
            //Método FrecuenciaCaracterDiccionario
            char_frequency("google.com");
            Console.WriteLine("------------------------Frecuencia Caracter Diccionario------------------------");
            Console.WriteLine(" ");

            //Método FrecuenciaNúmeroDiccionario
            double[] xD = new double[] { 1.1, 0.1, 2.3, 4.0, 0.1, 1.10, 4.0, 2.2, 0, 0.2, 0.3, 0.1, 0.2 };
            element_frequency(xD);
            Console.WriteLine("-------------------------Frecuencia Número Diccionario-------------------------");
            Console.WriteLine(" ");

            //Método FrecuenciaNúmeroSinDiccionario
            double[] x = new double[] { 1.1, 0.1, 2.3, 4.0, 0.1, 1.10, 4.0, 2.2, 0, 0.2, 0.3, 0.1, 0.2 };
            int numelem = x.Length; //Número de elementos
            double temp; //variable char temporal
            int[] chindex = new int[0];//Arreglo para identificar los índices de los caracteres
            int count = 0; //variable auxiliar
            int[] chnewindex = new int[0]; //arreglo auxiliar
            int hold;
            int comp;
            int index;
            int[] freq; //Arreglo para guardar frecuencia 
            int sumFreq;
            for (int i = 0; i < numelem; i++)
            {
                temp = x[i];
                for (int j = 0; j < numelem; j++)
                {
                    if (temp == x[j])
                    {
                        count++;
                        Array.Resize(ref chindex, count);//Redimensionamiento en un elemento del arreglo chindex
                        chindex[i] = j; //Se guarda el índice j
                        break;
                    }
                }
            }
            Array.Sort(chindex); //Ordenamiento del índice de menor valor al de mayor valor.
            index = 0;
            Array.Resize(ref chnewindex, chnewindex.Length + 1);
            chnewindex[chnewindex.Length - 1] = chindex[0];
            for (int i = 0; i < chindex.Length; i++)
            {
                hold = chindex[index];
                comp = index;
                for (; comp < chindex.Length; comp++)
                {
                    if (hold != chindex[comp])
                    {
                        index = comp;
                        Array.Resize(ref chnewindex, chnewindex.Length + 1);
                        chnewindex[chnewindex.Length - 1] = chindex[comp];
                        break;
                    }
                }
            }
            freq = new int[chnewindex.Length];
            for (int i = 0; i < chnewindex.Length; i++)
            {
                sumFreq = 0;
                for (int j = 0; j < chindex.Length; j++)
                {
                    if (chindex[j] == chnewindex[i])
                    {
                        sumFreq += 1; //suma = suma +1;
                    }
                    freq[i] = sumFreq;
                }
            }
            for (int i = 0; i < chnewindex.Length; i++)
            {
                Console.WriteLine("El caracter {0} apareció {1} veces",
               x[chnewindex[i]], freq[i]);
            }
            Console.WriteLine("-----------------------Frecuencia Número Sin Diccionario-----------------------");
        }//Main
    }//clase FrecuenciadeNumSinDiccionario
}//Espaciodenombres