using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._1._POO_Cinemática
{
    //Declaración de la clase Y
    class Y
    {
        //Variables de instancia, son los datos que manejará la clase
        public double y0;
        public double v0;
        public double g;

        //Constructor de la clase
        public Y(double y0, double v0)
        {
            /*El operador this lo que hace es referenciar no a la variable local del constructor, sino a la variable
            de instancia declarada dentro de la clase, de esta manera indicamos que a la variable de instancia y0 
            se le asigna el valor del parámetro y0 del cosntructor.*/
            this.y0 = y0;
            this.v0 = v0;
            g = 9.81;
        }

        //Métodos cualquiera de la clase, ya declarado el constructor no se debe usar el operador this
        public double Valorcito(double t)
        {
            return y0 + v0 * t + 0.5 * g * Math.Pow(t, 2);
        }
        public void Formulita()
        {
            Console.WriteLine("y = {0} + {1}*t + 0.5*{2}*t^2", y0, v0, g);
        }
    }//Clase Y

    class POO
    {
        static void Main(string[] args)
        {
            double y0 = 10;
            double v0 = 5;
            double t = 15;

            Y objeto_y = new Y(y0, v0); //Creación de un objeto de la clase Y
            double y_eval = objeto_y.Valorcito(t);
            Console.WriteLine("y(t = {0} = {1})", t, y_eval);
            objeto_y.Formulita();

            objeto_y.y0 = 0;
            double yConY0Cero = objeto_y.Valorcito(t);
            Console.WriteLine("y(t = {0} = {1})", t, yConY0Cero);
            objeto_y.Formulita();
        }//Método main
    }//Clase default del proyecto
}//Espacio de nombres