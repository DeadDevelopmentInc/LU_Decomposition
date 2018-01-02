using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SltnsLibrary
{
    public class LMatrix : Matrix
    {
        // jp - rows of the semimatrix
        private Hash[] jp;
        /// <summary>
        /// Constructor of matrix
        /// </summary>
        /// <param name="N">order of the matrix</param>
        public LMatrix(int N) : base(N)
        {
            jp = new Hash[N];
            for (int i = 0; i < N; i++)
            {
                jp[i] = new Hash();
            }
        }

        /// <summary>
        /// Override method for index in matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>return value for row and col</returns>
        public override double this[int row, int col]
        {
            get
            {
                if(row == col)
                {
                    return 1;
                }
                else
                {
                    return jp[row].getValue(col);
                }
            }
            set
            {
                if(row == col)
                {
                    return;
                }
                else
                {
                    jp[row].setValue(col, value);
                }
            }
        }
    }
}