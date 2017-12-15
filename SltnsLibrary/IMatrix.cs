using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SltnsLibrary
{
    public interface IMatrix
    {
        //returns the order of the matrix
        int getN();

        //index
        double this[int row, int col]
        {
            get;
            set;
        }
    }
}