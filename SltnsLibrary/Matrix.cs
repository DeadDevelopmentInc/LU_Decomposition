using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SltnsLibrary
{
    public abstract class Matrix : IMatrix
    {
        // порядок матрицы
        private int N;

        public abstract double this[int row, int col] { get; set; }

        public Matrix(int N)
        {
            this.N = N;
        }



        // возвращает порядок матрицы
        public int getN()
        {
            return N;
        }
    }
}