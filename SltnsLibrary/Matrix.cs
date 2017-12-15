using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SltnsLibrary
{
    public abstract class Matrix : IMatrix
    {
        // order of matrix
        private int N;

        public abstract double this[int row, int col] { get; set; }

        public Matrix(int N)
        {
            this.N = N;
        }



        // return order of matrix
        public int getN()
        {
            return N;
        }
    }
}