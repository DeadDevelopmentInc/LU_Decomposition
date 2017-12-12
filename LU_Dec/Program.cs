using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SltnsLibrary;

namespace LU
{
    class Program
    {
        static void Main(string[] args)
        {
            string source = "input.txt";

            double[] vector;

            LU_Decomposition decomposition = new LU_Decomposition();

            decomposition.ClcltLU_Dcmp(source, out vector);

            foreach(double x in vector)
            {
                Console.Write(x + " ");
            }
        }
    }
}
