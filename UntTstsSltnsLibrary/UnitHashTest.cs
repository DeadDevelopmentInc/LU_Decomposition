using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SltnsLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UntTstsSltnsLibrary
{
    [TestClass]
    public class UnitHashTest
    {
        Hash hash = new Hash();

        double[] testArray = new double[] { 3.32, 0.10, 0.00, 7.89, 0.00, 0.00 };

        [TestMethod]
        public void TestHashGetSet()
        {
            int i = 0;
            foreach (double x in testArray)
            {
                hash.setValue(i, x);
                i++;
            }
            double[] X = new double[testArray.Length];
            for (int j = 0; j < i; j++)
            {
                X[j] = Math.Round(hash.getValue(j), 2);
            }

            Assert.AreEqual(testArray[0], X[0]);
            Assert.AreEqual(testArray[1], X[1]);
            Assert.AreEqual(testArray[2], X[2]);
            Assert.AreEqual(testArray[3], X[3]);
            Assert.AreEqual(testArray[4], X[4]);
            Assert.AreEqual(testArray[5], X[5]);
        }

        [TestMethod]
        public void TestHashAdd()
        {
            double[] testNewArray = new double[] { 9.32, 6.10, 6.00, 13.89, 6.00, 6.00 };
            int i = 0;
            foreach (double x in testArray)
            {
                hash.setValue(i, x);
                i++;
            }
            double[] X = new double[testArray.Length];
            for (int j = 0; j < i; j++)
            {
                X[j] = Math.Round(hash.getValue(j), 2) + 6;
            }

            Assert.AreEqual(testNewArray[0], X[0]);
            Assert.AreEqual(testNewArray[1], X[1]);
            Assert.AreEqual(testNewArray[2], X[2]);
            Assert.AreEqual(testNewArray[3], X[3]);
            Assert.AreEqual(testNewArray[4], X[4]);
            Assert.AreEqual(testNewArray[5], X[5]);
        }
    }
}
