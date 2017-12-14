using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SltnsLibrary
{
    public interface IMatrix
    {
        // возвращает порядок матрицы
        int getN();

        double this[int row, int col]
        {
            get;
            set;
        }
    }
}