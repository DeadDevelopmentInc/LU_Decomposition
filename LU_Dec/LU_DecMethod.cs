using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU
{
    class MethodLU
    {
        double[,] U;
        double[,] L;
        double[] Y;
        double[] X;

        public double[] Soulution(double[,] matrixA, double[] vectorB)
        {
            L = new double[vectorB.GetLength(0), vectorB.GetLength(0)];
            U = new double[vectorB.GetLength(0), vectorB.GetLength(0)];
            Y = new double[vectorB.GetLength(0)];
            X = new double[vectorB.GetLength(0)];

            double item;

            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                L[i, 0] = matrixA[i, 0];
                U[0, i] = matrixA[0, i] / L[0, 0];
                U[i, i] = 1;
            }

            double sum = 0;
            for (int i = 1; i < L.GetLength(0); i++)
            {
                for (int j = 1; j < L.GetLength(1); j++)
                {
                    if (i >= j)
                    {
                        sum = 0;
                        for (int k = 0; k < j; k++)
                            sum += L[i, k] * U[k, j];

                        L[i, j] = matrixA[i, j] - sum;
                    }
                    else
                    {
                        sum = 0;
                        for (int k = 0; k < i; k++)
                            sum += L[i, k] * U[k, j];

                        U[i, j] = (matrixA[i, j] - sum) / L[i, i];
                    }
                }
            }


            for (int i = 0; i < U.GetLength(0); i++)
            {
                item = 0;
                for (int j = 0; j < i; j++)
                {
                    item += L[i, j] * Y[j];
                }
                Y[i] = (vectorB[i] - item) / L[i, i];

            }

            for (int i = U.GetLength(0) - 1; i >= 0; i--)
            {
                double d = 0;
                for (int j = U.GetLength(1) - 1; j >= i + 1; j--)
                {
                    d += U[i, j] * X[j];
                }
                X[i] = Y[i] - d;
            }

            return X;
        }
    }
}
