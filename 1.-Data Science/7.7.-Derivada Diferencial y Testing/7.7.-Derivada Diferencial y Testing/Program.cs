using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Se usa la librería MathNet.Numerics, para ello se debe seleccionar la siguiente opción:
//Explorador de soluciones -> Clic Derecho en Referencias -> Administrar Paquetes NuGet -> Examinar -> NUnit -> Instalar.
//Explorador de soluciones -> Referencias -> Agregar Referencia -> Nombre Librería.
using NUnit.Framework;


namespace _7._7._Derivada_Diferencial_y_Testing
{
    class DerivadaConDefinicionDiferencial
    {
        static void Main(string[] args)
        {
            double umbralAssertion = 1e-4;
            double umbralNoseTesting = 1e-4;

            diff((x) => Math.Exp(x), 0, 0.01);
            diff((x) => Math.Exp(-2.0 * Math.Pow(x, 2)), 0, 0.01);
            diff((x) => Math.Cos(x), 2 * Math.PI, 0.01);
            diff((x) => Math.Log(x), 1, 0.01);

            assertionTesting(umbralAssertion);
            noseApplication(umbralNoseTesting);
        }

        static double diff(Func<double, double> f, double x, double h = 1e-5)
        {
            double df = (f(x + h) - f(x - h)) / (2.0 * h);
            return df;
        }

        static void assertionTesting(double umbralAssertionTesting)
        {
            double[] resultadoDerivada = { 1, 0, 0, 1 };
            double[] x = { 0, 0, 2 * Math.PI, 1 };
            double[] resultadoDiferencial = new double[4];
            double dx = 0.01;
            double[] error = new double[4];
            string[] nombreFunciones = { "e^x", "e^(-2x^2)", "cos(x)", "ln(x)" };
            string[][] tabla = new string[nombreFunciones.Length][];

            resultadoDiferencial[0] = diff((xx) => Math.Exp(xx), x[0], dx);
            resultadoDiferencial[1] = diff((xx) => Math.Exp(-2.0 * Math.Pow(xx, 2)), x[1], dx);
            resultadoDiferencial[2] = diff((xx) => Math.Cos(xx), x[2], dx);
            resultadoDiferencial[3] = diff((xx) => Math.Log(xx), x[3], dx);

            for (int i = 0; i < nombreFunciones.Length; i++)
            {
                error[i] = Math.Abs(resultadoDiferencial[i] - resultadoDerivada[i]);
                tabla[i] = new string[] { nombreFunciones[i], x[i].ToString(), resultadoDerivada[i].ToString(), resultadoDiferencial[i].ToString(), error[i].ToString() };
            }

            Console.WriteLine("f(x)\t\tValor de x\tDerivada evaluada en x\tDiferencial evaluada en x\tError");
            foreach (string[] row in tabla)
            {
                Console.WriteLine(string.Join("\t\t", row));
            }

            string notacionCientifica = umbralAssertionTesting.ToString("0.0e+0");
            Console.WriteLine("\n\n--------------------------------------------Assertion Testing--------------------------------------------");
            Console.WriteLine("Para pasar las pruebas de Assertion Testing el error debe ser menor o igual a: " + umbralAssertionTesting + " = " + notacionCientifica);
            Assert.LessOrEqual(error[0], umbralAssertionTesting, "Error muy grande al aproximar la derivada de e^x por medio de su diferencial");
            Assert.LessOrEqual(error[1], umbralAssertionTesting, "Error muy grande al aproximar la derivada de e^(-2x^2) por medio de su diferencial");
            Assert.LessOrEqual(error[2], umbralAssertionTesting, "Error muy grande al aproximar la derivada de cos(x) por medio de su diferencial");
            Assert.LessOrEqual(error[3], umbralAssertionTesting, "Error muy grande al aproximar la derivada de ln(x) por medio de su diferencial");
            Console.WriteLine("Todas las pruebas pasaron correctamente.");
        }

        static void noseApplication(double umbralNoseTesting)
        {
            double[] resultadoDerivada = { 1, 0, 0, 1 };
            double[] resultadoDiferencial = { diff((x) => Math.Exp(x), 0, 0.01), diff((x) => Math.Exp(-2.0 * Math.Pow(x, 2)), 0, 0.01), diff((x) => Math.Cos(x), 2 * Math.PI, 0.01), diff((x) => Math.Log(x), 1, 0.01) };

            Console.WriteLine("\n\n----------------------------------------------Nose Testing-----------------------------------------------");
            Console.WriteLine("Para pasar las pruebas de Nose Testing el error debe ser menor o igual a: " + umbralNoseTesting.ToString("0.0e+0"));
            Assert.AreEqual(resultadoDiferencial[0], resultadoDerivada[0], umbralNoseTesting, "Error muy grande al aproximar la derivada");
            Assert.AreEqual(resultadoDiferencial[1], resultadoDerivada[1], umbralNoseTesting, "Error muy grande al aproximar la derivada");
            Assert.AreEqual(resultadoDiferencial[2], resultadoDerivada[2], umbralNoseTesting, "Error muy grande al aproximar la derivada");
            Assert.AreEqual(resultadoDiferencial[3], resultadoDerivada[3], umbralNoseTesting, "Error muy grande al aproximar la derivada");
            Console.WriteLine("Todas las pruebas pasaron correctamente.");
        }
    }
}