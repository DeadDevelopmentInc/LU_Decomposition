using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SltnsLibrary
{
    public class Hash
    {
        // hash table in format number of nonzero cell = cell value
        private Hashtable hash = new Hashtable();

        public void setValue(int num, double value)
        {
            // if the value is 0, then delete this cell
            if (value == 0)
            {
                if (hash.ContainsKey(num)) hash.Remove(num);
                return;
            }
            // if the value is not 0, we overwrite or add a cell
            hash[num] = value;
        }

        public void addValue(int num, double value)
        {
            if (hash.ContainsKey(num)) hash[num] = (double)hash[num] + value;
            else hash[num] = value;
        }

        //return value if hash contain num or return 0
        public double getValue(int num)
        {
            if (hash.ContainsKey(num)) return (double)hash[num];
            return 0;
        }
    }
}