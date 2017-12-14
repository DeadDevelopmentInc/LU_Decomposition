using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SltnsLibrary
{
    public class UMatrix : Matrix
    {
        // тип хранения данных: массив или хэш-таблица
        public const byte ARRAY_TYPE = 0;
        public const byte HASH_TYPE = 1;

        // jp - строки полуматрицы
        private IRow[] jp;

        // конструктор матрицы
        // type - тип хранения данных ARRAY_TYPE/HASH_TYPE
        // N - порядок матрицы
        public UMatrix(byte type, int N) : base(N)
        {
            if (type == HASH_TYPE)
            {
                jp = new Hash[N];
                for (int i = 0; i < N; i++)
                {
                    jp[i] = new Hash();
                }
            }
            else
            {
                jp = new Array[N];
                for (int i = 0; i < N; i++)
                {
                    jp[i] = new Array();
                }
            }
        }

        public override double this[int row, int col]
        {
            get
            {
                return jp[row].getValue(col);
            }
            set
            {
                jp[row].setValue(col, value);
            }
        }
    }
}
