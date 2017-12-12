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
        private double[] Y;
        private double[] X;

        public void ClcltLU_Dcmp(string source, out double[] vectorB)
        {
            IMatrix matrix;
            IOClass.ReadFile(source, out matrix, out vectorB);

            L = new HashMatrix(1, matrix.getN());
            U = new HashMatrix(1, matrix.getN());
            Y = new double[matrix.getN()];
            X = new double[matrix.getN()];

            ClcltLU(matrix, matrix.getN());

            Summary(matrix);

            GiveReslt(vectorB);
        }

        private void ClcltLU(IMatrix matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                L[i, 0] = matrix[i, 0];
                U[0, i] = matrix[0, i] / L[0, 0];
                U[i, i] = 1;                
            }
        }

        private void Summary(IMatrix matrix)
        {
            double sum = 0;

            for (int i = 1; i < L.getN(); i++)
            {
                for (int j = 1; j < L.getN(); j++)
                {
                    if (i >= j)
                    {
                        sum = 0;
                        for (int k = 0; k < j; k++)
                            sum += L[i, k] * U[k, j];

                        L[i, j] = matrix[i, j] - sum;
                    }
                    else
                    {
                        sum = 0;
                        for (int k = 0; k < i; k++)
                            sum += L[i, k] * U[k, j];

                        U[i, j] = (matrix[i, j] - sum) / L[i, i];
                    }
                }
            }
        }

        private void GiveReslt(double[] vectorB)
        {
            double item; 

            for (int i = 0; i < U.getN(); i++)
            {
                item = 0;
                for (int j = 0; j < i; j++)
                {
                    item += L[i, j] * Y[j];
                }
                Y[i] = (vectorB[i] - item) / L[i, i];

            }

            for (int i = U.getN() - 1; i >= 0; i--)
            {
                double d = 0;
                for (int j = U.getN() - 1; j >= i + 1; j--)
                {
                    d += U[i, j] * X[j];
                }
                X[i] = Y[i] - d;
            }
        }
    }
}
