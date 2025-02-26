using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] a = { 1, 2, 0, 3, 1,-1 };
            //double[] b = { 1, 2, 3 };
            //Matrix matrix = new Matrix(3,3,a,true);
            //Matrix matrix1= new Matrix(3,1,b,true);
            //Console.WriteLine(matrix.ToString());
            //Console.WriteLine();
            //Console.WriteLine(matrix1.ToString());

            //Matrix matrix2 = matrix * matrix1;
            //Console.WriteLine();
            //Console.WriteLine(matrix2.ToString());
            //matrix.Single(3);
            //Console.WriteLine(matrix.ToString());
            Matrix matrix = new Matrix(5,5,true);
            Console.WriteLine(matrix.ToString());
            Console.ReadLine();
        }
    }
}
