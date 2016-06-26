using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quad
{
    public class Program
    {
        public bool CheckArguments(string[] args1)
        {
            if (args1.Length < 3)
            {

                Console.WriteLine("there aren't 3 arguments");
                return false;
            }
            return true;
        }

        public bool CheckParse(string[] args1, out double a, out double b, out double c)
        {
            if (double.TryParse(args1[0], out a) && double.TryParse(args1[1], out b) && double.TryParse(args1[2], out c))
                return true;
            Console.WriteLine("parsing didn't succeed");
            a = 0;
            b = 0;
            c = 0;
            return false;
        }
        public double OneSolutionA(double a, double b, double c)
        {
            return (-1) * c / b;

        }
        public double OneSolutionB(double a, double b, double c)
        {
            return -Math.Sqrt(c) / Math.Sqrt(a);
        }
        public bool NoSolution(out double toSqrt, double a, double b, double c)
        {
            toSqrt = Math.Pow(b, 2) - 4 * a * c;
            if (toSqrt < 0)
            {
                Console.WriteLine("no solution");
                return false;
            }

            return true;
        }
        public string Stringequation(double toSqrt, double a, double b, double c)
        {
            return ("X1 = " + ((toSqrt - b) / (2 * a)).ToString(CultureInfo.InvariantCulture) + ",X2 = " + ((-1) * (toSqrt + b) / (2 * a)));
        }
        static void Main(string[] args)
        {
            double a, b, c, toSqrt;
            Program q = new Program();
            if (!q.CheckArguments(args))
            {
                Console.ReadLine();
                return;
            }

            if (!q.CheckParse(args, out a, out b, out c))
            {
                Console.ReadLine();
                return;
            }

            if (a == 0)
            {
                Console.WriteLine("x = {0}", q.OneSolutionA(a, b, c));
                Console.ReadLine();
                return;
            }
            if (b == 2 * a * c)
            {
                Console.WriteLine("x = {0}", q.OneSolutionB(a, b, c));
                Console.ReadLine();
                return;
            }

            if (q.NoSolution(out toSqrt, a, b, c) == false)
            {
                Console.ReadLine();
                return;
            }

            toSqrt = Math.Sqrt(toSqrt);
            Console.WriteLine(q.Stringequation(toSqrt, a, b, c));
            Console.ReadLine();
        }
    }
}
