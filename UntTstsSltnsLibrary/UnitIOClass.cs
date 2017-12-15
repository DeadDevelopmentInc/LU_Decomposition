using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SltnsLibrary;
using System.IO;

namespace UntTstsSltnsLibrary
{
    [TestClass]
    public class UnitIOClass
    {
        double[] X;
        string sourceMx;
        string sourceOut;
        const int from = 1;
        LU_Decomposition decomposition = new LU_Decomposition();

        private double[] ReadArray(string source, int num)
        {
            double[] XX = new double[num];
            int i = 0;
            using (StreamReader fs = new StreamReader(source))
            {
                string line = fs.ReadLine();
                string[] parts = line.Split(' ');
                foreach(string part in parts)
                {
                    XX[i] = Double.Parse(part);
                    i++;
                }
            }
            return XX;
        }

        [TestMethod]
        public void TestReadFile_4()
        {
            sourceMx = "Matrix4.txt";

            double[] XX = new double[] {0.73421, 0.27065, -1.05448, -0.50694};

            decomposition.ClcltLU_Dcmp(sourceMx, from, out X);
            
            int i = 0;
            bool fl = false;
            while(!fl && i < X.Length)
            {
                if (Math.Round(X[i], 5) == XX[0])
                    fl = true;
                i++;
            }
            Assert.AreEqual(true, fl);

        }

        [TestMethod]
        public void TestReadFile_3()
        {
            sourceMx = "Matrix3.txt";

            double[] XX = new double[] { 0.73421, 0.27065, -1.05448, -0.50694 };

            decomposition.ClcltLU_Dcmp(sourceMx, from, out X);

            foreach (double x in X)
            {
                X[0] = Math.Round(X[0], 5);
            }
            int i = 0;
            bool fl = false;
            while (!fl && i < X.Length)
            {
                if (X[i] == XX[0])
                    fl = true;
                i++;
            }
            Assert.AreEqual(true, fl);

        }

        [TestMethod]
        public void TestReadFile_40r()
        {
            sourceMx = "Matrix40r.txt";

            sourceOut = "Array40r.txt";

            double[] XX = new double[] { 0.73421, 0.27065, -1.05448, -0.50694 };

            decomposition.ClcltLU_Dcmp(sourceMx, from, out X);

            int i = 0;
            bool fl = false;
            while (!fl && i < X.Length)
            {
                if (Math.Round(X[i], 5) == XX[0])
                    fl = true;
                i++;
            }
            Assert.AreEqual(true, fl);

        }

        [TestMethod]
        public void TestReadFile_40()
        {
            sourceMx = "Matrix40.txt";

            sourceOut = "Array40.txt";

            double[] XX = ReadArray(sourceOut, 40);

            decomposition.ClcltLU_Dcmp(sourceMx, from, out X);

            int i = 0;
            bool fl = false;
            while (!fl && i < X.Length)
            {
                if (Math.Round(X[i], 5) == XX[0])
                    fl = true;
                i++;
            }
            Assert.AreEqual(true, fl);

        }

        [TestMethod]
        public void TestReadFile_100()
        {
            sourceMx = "Matrix100.txt";

            sourceOut = "Array100.txt";

            double[] XX = ReadArray(sourceOut, 100);

            decomposition.ClcltLU_Dcmp(sourceMx, from, out X);

            int i = 0;
            bool fl = false;
            while (!fl && i < X.Length)
            {
                if (Math.Round(X[i], 5) == XX[0])
                    fl = true;
                i++;
            }
            Assert.AreEqual(true, fl);
        }
    }
}
