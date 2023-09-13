using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._3._POO_Polinomio
{
	class Polynomial
	{
		public readonly double[] coeff;
		string s;
		public Polynomial(double[] coeff)
		{
			this.coeff = coeff;
		}// Costructor
		public double Eval(double x)
		{
			double result = 0;
			for (int i = 0; i < coeff.Length; i++)
			{
				result = result + coeff[i] * Math.Pow(x, i);
			}
			return result;
		}//Evaluar el polinomio
		public static Polynomial operator +(Polynomial a, Polynomial b)
		{
			double[] result;
			if (a.coeff.Length > b.coeff.Length)
			{
				result = new double[a.coeff.Length];
				for (int i = 0; i < a.coeff.Length; i++)
				{
					result[i] = a.coeff[i];
				}
				for (int i = 0; i < b.coeff.Length; i++)
				{
					result[i] += b.coeff[i];
				}
			}
			else
			{
				result = new double[b.coeff.Length];
				for (int i = 0; i < b.coeff.Length; i++)
				{
					result[i] = b.coeff[i];
				}
				for (int i = 0; i < a.coeff.Length; i++)
				{
					result[i] += a.coeff[i];
				}
			}
			return new Polynomial(result);
		}//Sobrecarga del operador +
		public static Polynomial operator *(Polynomial a, Polynomial b)
		{
			double[] c = new double[a.coeff.Length];
			for (int i = 0; i < a.coeff.Length; i++)
			{
				c[i] = a.coeff[i];
			}
			double[] d = new double[b.coeff.Length];
			for (int i = 0; i < b.coeff.Length; i++)
			{
				d[i] = b.coeff[i];
			}
			int M = c.Length - 1;
			int N = d.Length - 1;
			double[] resultCoeff = new double[M + N + 1];
			for (int i = 0; i < resultCoeff.Length; i++)
			{
				resultCoeff[i] = 0;
			}
			for (int i = 0; i < M + 1; i++)
			{
				for (int j = 0; j < N + 1; j++)
				{
					resultCoeff[i + j] += c[i] * d[j];
				}
			}
			return new Polynomial(resultCoeff);
		}//Sobrecarga del operador *
		private double[] Differentiate(Polynomial a)
		{
			double[] result = new double[a.coeff.Length];
			for (int i = 0; i < a.coeff.Length; i++)
			{
				result[i] = a.coeff[i];
			}
			for (int i = 1; i < result.Length; i++)
			{
				result[i - 1] = i * result[i];
			}
			Array.Resize(ref result, result.Length - 1);
			return result;
		}
		public Polynomial Derivative()
		{
			double[] cd = new double[this.coeff.Length];
			for (int i = 0; i < this.coeff.Length; i++)
			{
				cd[i] = this.coeff[i];
			}
			Polynomial e = new Polynomial(cd);
			double[] result;
			result = Differentiate(e);
			return new Polynomial(result);
		}
		public override string ToString()
		{
			s = "";
			for (int i = 0; i < this.coeff.Length; i++)
			{
				if (this.coeff[i] != 0.0)
				{
					s += " + " + Convert.ToString(this.coeff[i])
						+ "*x^" + Convert.ToString(i);
				}
			}
			s = s.Replace("+ -", "- ");
			s = s.Replace("x^0", "1");
			s = s.Replace("1*", " ");
			s = s.Replace("x^1", "x");
			if (s.Substring(0, 3) == " + ")
			{
				s = s.Substring(3);
			}
			if (s.Substring(0, 3) == " - ")
			{
				s = "-" + s.Substring(3);
			}
			return s;
		}
	}
	class Program
	{
		static string ShowCoeff(Polynomial p)
		{
			string r = "[";
			for (int i = 0; i < p.coeff.Length; i++)
			{
				r += Convert.ToString(p.coeff[i]) + ",";
			}
			r += Convert.ToString(p.coeff[p.coeff.Length - 1]) + "]";
			return r;
		}
		static void Main(string[] args)
		{
			double[] cp1 = new double[] { 1, -1 };
			Polynomial p1 = new Polynomial(cp1);
			double[] cp2 = new double[] { 0, 1, 0, 0, -6, -1 };
			Polynomial p2 = new Polynomial(cp2);
			double x = 1;
			Console.WriteLine("P1(x={0} = {1}", x, p1.Eval(x));
			Console.WriteLine("P2(x={0} = {1}", x, p2.Eval(x));
			Polynomial p3;
			p3 = p1 + p2;
			Console.WriteLine("p3 = p1+p2 = {0}", ShowCoeff(p3));
			Polynomial p4;
			p4 = p1 * p2;
			Console.WriteLine("p4 = p1*p2 = {0}", ShowCoeff(p4));
			Polynomial p5;
			p5 = p2.Derivative();
			Console.WriteLine("p5 = dp2/dx = {0}", ShowCoeff(p5));
			Console.WriteLine("p1(x)={0}", p1);
			Console.WriteLine("p2(x)={0}", p2);
			Console.WriteLine("p3(x)={0}", p3);
			Console.WriteLine("p4(x)={0}", p4);
			Console.WriteLine("p5(x)={0}", p5);
		}
	}
}