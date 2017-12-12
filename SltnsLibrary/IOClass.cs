using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SltnsLibrary
{
    class IOClass
    {
        public static void ReadFile(string source, out IMatrix matrix,
            out double[] vectorB)
        {
            int count = 0;


            List<string> allElement = new List<string>();
            //Считвание значений в переменнуй строками
            using (StreamReader fs = new StreamReader(source))
            {
                string line;
                while ((line = fs.ReadLine()) != null)
                {
                    allElement.Add(line);
                    count++;
                }
            }
            //создание начальной матрицы
            matrix = new HashMatrix(1, count);
            vectorB = new double[count];
            //Ввод элементов из файла
            for (int i = 0; i < allElement.Count; i++)
            {
                string[] part = allElement[i].Split(' ');
                for (int j = 0; j < allElement.Count - 1; i++)
                {
                    matrix.addValue(i, j, Double.Parse(part[j]));
                }
                vectorB[i] = Convert.ToDouble(part[i]);
            }
        }
    }
}
