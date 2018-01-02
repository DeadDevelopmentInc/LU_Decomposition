using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SltnsLibrary
{
    public class IOClass
    {
        /// <summary>
        /// Method for read fole
        /// </summary>
        /// <param name="source">sourse for read</param>
        /// <param name="matrix">out param readed matrix</param>
        /// <param name="vectorB">out param readed vector B</param>
        public static void ReadFile(string source, out IMatrix matrix,
            out double[] vectorB)
        {
            int count = 0;


            List<string> allElement = new List<string>();
            //Counting values in alternating rows
            using (StreamReader fs = new StreamReader(source))
            {
                string line;
                while ((line = fs.ReadLine()) != null)
                {
                    allElement.Add(line);
                    count++;
                }
            }
            //Creation of the initial matrix
            matrix = new UMatrix(count);
            vectorB = new double[count];
            //Entering elements from a file
            for (int i = 0; i < allElement.Count; i++)
            {
                string[] part = allElement[i].Split(' ');
                for (int j = 0; j < part.Length - 1; j++)
                {
                    matrix[i, j] =  Double.Parse(part[j]);
                }
                vectorB[i] = Convert.ToDouble(part[part.Length - 1]);
            }
        }

        /// <summary>
        /// Method for read value from console
        /// </summary>
        /// <param name="matrix">out param readed matrix</param>
        /// <param name="vectorB">out param readed vector B</param>
        public static void ReadConsole(out IMatrix matrix, out double[] vectorB)
        {
            int count = 0;
            bool fl = false;
            while(!fl)
            {
                Console.Clear();
                Console.WriteLine("Input rows and colns of matrix");
                count = int.Parse(Console.ReadLine());
                if (count > 0 && count <= 50000)
                {
                    fl = true;
                }
                else
                {
                    Console.WriteLine("Please write correct value. More than 0 and less than 50000");
                    Console.WriteLine("Press any key to retry");
                    Console.ReadKey();
                }

            }

            matrix = new UMatrix(count);
            vectorB = new double[count];
            int i = 0;
            while(i < count)
            {
                Console.WriteLine("Input " + (i+ 1).ToString() + " rows");
                try
                {
                    string byfer = Console.ReadLine();
                    string[] parts = byfer.Split(' ');
                    for (int j = 0; j < parts.Length; j++)
                    {
                        matrix[i, j] = Double.Parse(parts[j]);
                    }
                    i++;
                }
                catch
                {
                    Console.WriteLine("Please reinput string.");
                }
            }
            Console.WriteLine("Input vector B");
            string byfers = Console.ReadLine();
            string[] part = byfers.Split(' ');
            for (int j = 0; j < part.Length; j++)
            {
                vectorB[j] = Convert.ToDouble(part[j]);
            }
        }
    }
}