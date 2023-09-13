using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.__Multiplicación_de_matrices
{
    class Program
    {
        //El código en C# se corre presionando CTRL + F5
        //CÓDIGO PARA MULTIPLICAR DOS MATRICES:
        static void Main(string[] args)
        {
            /*Arrays: Cuando se declara un array en C# se debe indicar su tipo de dato, el número de elementos 
            que vaya a contener y su nombre, como el array declarado es un objeto de la clase Array, se debe 
            crear una instancia por medio de la palabra reservada new, pero cuando no se sabe el tamaño que 
            tendrá el array, simplemente se pone una coma dentro de los corchetes que van después del tipo de 
            dato que almacenará el array.*/
            /*tipo_de_dato_array[,] Nombre_Matriz = new tipo_de_dato_array[,] {{fila1},{fila2},...,{fila_n}}, 
            FILA X COLUMNA.
            tipo_de_dato_array[,] vector_renglon = new tipo_de_dato_array[,] {{1,2,3}}
            tipo_de_dato_array[,] vector_columna = new tipo_de_dato_array[,] {{1},{2},{3}}*/
            //Declaración e iniciación de las matrices A y B
            int[,] A = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };//Matriz A, 3X3
            int[,] B = new int[,] { { 1 }, { 2 }, { 3 } };//Matriz B, 3X1
            /*En C# para poder imprimir el contenido de un vector o matriz se debe hacer uso de Bucles for:*/
            Console.WriteLine("El resultado de la multiplicación de las matrices A:");
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    Console.Write(A[i, j] + " ");
                }
                Console.WriteLine();
            }
            /*En C# para poder imprimir el contenido de un vector o matriz se debe hacer uso de Bucles for:*/
            Console.WriteLine("\n Y B: ");
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    Console.Write(B[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nEs igual a: ");
            /*El producto AB de la matriz A por la matriz B está definido sólo cuando el número de columnas de A 
            son iguales al número de renglones de B y el resultado tendrá el número de filas de A y el número de 
            columnas de B.*/
            /*Obtención de las dimensiones de la matriz para accesar a las posiciones de sus elementos y realizar 
            la multiplicación, ya que debe coincidir el tamaño de las columnas de la matriz A con el tamaño de las 
            filas de la matriz B para que se pueda hacer su producto.*/
            /*GetLength(): Este método sirve para ver el tamaño de un array, en su parámetro se le debe pasar la 
            dimensión del array que se quiere ver su tamaño*/
            //Número de filas o renglones de la matriz A, la dimensión es cero porque es la de hasta afuera.
            int m = A.GetLength(0);
            /*Si un array tiene posiciones con arrays internos, como lo es en el caso de las matrices, lo que se 
            hace para saber el tamaño de las listas internas es que se indica al método GetLength() que se quiere 
            saber el tamaño de la dimensión 1 del array, así se meterá a los arrays internos y verá su tamaño.*/
            //Número de columnas de la matriz B, la dimensión es uno porque es la de un array interno.
            int n = B.GetLength(1);
            /*El número de columnas de la matriz A debe ser igual al número de filas de la mariz B para que se pueda
            hacer la multiplicación.*/
            //l = A.GetLength(1) = B.GetLength(0)
            int l = A.GetLength(1);

            //Se debe declarar la matriz vacía que almacenará el resultado de la multiplicación:
            int[,] C = new int[m, n];//Matriz C = A*B, 3X1

            /*Declaración de la variable que almacenará el valor de cada elemento de la matriz resultante C, esta se 
            debe declarar fuera del siguiente bucle for sino el resultado de la operación será erróneo.*/
            int sum;

            /*BUCLE FOR: El bucle for en C# se declara como en la mayoría de los lenguajes de programación, indicando 
            una variable local de tipo primitivo número entero, hasta donde va a llegar el conteo y el paso con el 
            que irá contando.*/
            for (int i = 0; i < m; i++)//Bucle que lee el contenido de las filas de la matriz A
            {
                for (int j = 0; j < n; j++)//Bucle que lee el contenido de las columnas de la matriz B
                {
                    //Inicialización de la variable que almacenará el valor de cada elemento de la matriz resultante C
                    sum = 0;
                    for (int k = 0; k < l; k++)//Lee el contenido de las columnas de la matriz A y filas de la matriz B
                    {
                        //Cálculo de cada uno de los elementos de la matriz C = A*B
                        sum = sum + A[i, k] * B[k, j];
                    }
                    //Asignación de cada uno de los elementos a su respectiva posición en la matriz C
                    C[i, j] = sum;
                }
            }

            //Despliegue de la matriz C en pantalla
            for (int p = 0; p < m; p++)//Bucle que lee el contenido de las filas de la matriz A
            {
                for (int q = 0; q < n; q++)//Bucle que lee el contenido de las columnas de la matriz B
                {
                    /*Método para imprimir en consola, usando la clase Console y su método Write para imprimir en 
                    consola y después no ejecutar un salto de línea.*/
                    Console.Write(C[p, q]); //Impresión en pantalla de todos los valores de la matriz resultante C
                    Console.Write(" ");
                }
                /*Impresión en consola con un salto de línea para diferenciar los valores de la matriz C.*/
                Console.WriteLine();
            }
        }//Método main: Desde el método main se ejecutan todas las partes del proyecto
    }//Clase del programa
}//Espacio de nombres: En esta parte del código se pueden declarar más de una clase que conforme el proyecto
