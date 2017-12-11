using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU
{
    class Program
    {
        static void Main(string[] args)
        {
            string s;
            int sizeMatrix;
            double[,] matrixA;
            double[] vectorB;
            double[] X;
            string fileName = "Matrix.txt";

            int index = 0;
            StreamReader f = null;
            try
            {
                f = new StreamReader(fileName);
                s = f.ReadLine();
                sizeMatrix = Convert.ToInt32(s);
                matrixA = new double[sizeMatrix, sizeMatrix];
                vectorB = new double[sizeMatrix];
                X = new double[sizeMatrix];

                while (!f.EndOfStream)
                {
                    s = f.ReadLine();
                    string[] str = s.Split(' ');

                    for (int i = 0; i < sizeMatrix; i++)
                    {
                        matrixA[index, i] = Convert.ToDouble(str[i]);
                    }
                    vectorB[index] = Convert.ToDouble(str[sizeMatrix]);
                    index++;
                }

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }
            MethodLU methodLU = new MethodLU();
            X = methodLU.Soulution(matrixA, vectorB);

            for (int i = 0; i < X.GetLength(0); i++)
            {
                Console.Write("{0:f2}     ", X[i]);
            }
            Console.ReadKey();


        }
    }
}
