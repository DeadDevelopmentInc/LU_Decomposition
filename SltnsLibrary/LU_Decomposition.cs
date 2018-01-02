using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SltnsLibrary
{
    public class LU_Decomposition
    {
        
        private IMatrix L;
        private IMatrix U;
        private IMatrix R;
        private double[] Y;

        public void ClcltLU_Dcmp(string source, int inputType, out double[] X)
        {
            IMatrix A;
            double[] vectorB;
            if(inputType == 1)
            {
                IOClass.ReadFile(source, out A, out vectorB);
            }
            else
            {
                IOClass.ReadConsole(out A, out vectorB);
            }

            L = new LMatrix(A.getN());
            U = new UMatrix(A.getN());
            R = new UMatrix(A.getN());
            Y = new double[A.getN()];
            X = new double[A.getN()];

            ClcltLU(A, A.getN(), vectorB, X);
        }

        private void ClcltLU(IMatrix A, int n, double[] vectorB, double[] X)
        {
            double item;

            for (int i = 0; i < n; i++)
            {
                U[i, 0] = A[i, 0];
                L[0, i] = A[0, i] / U[0, 0];
                L[i, i] = 1;
            }

            double sum = 0;
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (i >= j)
                    {
                        sum = 0;
                        for (int k = 0; k < j; k++)
                            sum += U[i, k] * L[k, j];

                        U[i, j] = A[i, j] - sum;
                    }
                    else
                    {
                        sum = 0;
                        for (int k = 0; k < i; k++)
                            sum += U[i, k] * L[k, j];

                        L[i, j] = (A[i, j] - sum) / U[i, i];
                    }
                }
            }


            for (int i = 0; i < n; i++)
            {
                item = 0;
                for (int j = 0; j < i; j++)
                {
                    item += U[i, j] * Y[j];
                }
                Y[i] = (vectorB[i] - item) / U[i, i];

            }

            for (int i = n - 1; i >= 0; i--)
            {
                double d = 0;
                for (int j = n - 1; j >= i + 1; j--)
                {
                    d += L[i, j] * X[j];
                }
                X[i] = Y[i] - d;
            }
        }
    }
}
