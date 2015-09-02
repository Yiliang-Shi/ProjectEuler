using System;
using System.Collections.Generic;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PEulerFunctions;

namespace PEulerFunctionsTest
{

    [TestClass]
    public class TestFunctionLib
    {

        [TestMethod]
        public void TestNextLesserPanlindrome()
        {
            IComparer x = new StructInt32d();
            int[] input = new int[] { 9,9,9,9,9,9};
            var expected = Tuple.Create(998899, new int[] { 9,9,8,8,9,9 });
            var actual = FunctionLib.NextLesserPanlindrome(input);
            Assert.AreEqual(expected.Item1, actual.Item1);
            Assert.IsTrue(x.Compare(expected.Item2, actual.Item2) == 0);

            input = new int[] { 9,9,9,9,9 };
            expected = Tuple.Create(99899, new int[] { 9, 9, 8, 9, 9 });
            actual = FunctionLib.NextLesserPanlindrome(input);
            Assert.AreEqual(expected.Item1, actual.Item1);
            Assert.IsTrue(x.Compare(expected.Item2, actual.Item2) == 0);

            input = new int[] { 9,9,0,9,9 };
            expected = Tuple.Create(98989, new int[] { 9, 8,9,8, 9 });
            actual = FunctionLib.NextLesserPanlindrome(input);
            Assert.AreEqual(expected.Item1, actual.Item1);
            Assert.IsTrue(x.Compare(expected.Item2, actual.Item2) == 0);

            input = new int[] { 9};
            expected = Tuple.Create(8, new int[] { 8 });
            actual = FunctionLib.NextLesserPanlindrome(input);
            Assert.AreEqual(expected.Item1, actual.Item1);
            Assert.IsTrue(x.Compare(expected.Item2, actual.Item2) == 0);
        }

        [TestMethod]
        public void TestIntToCharArray()
        {
            char[] expected = new char[] { '1', '2', '3', '4' };
            char[] actual = FunctionLib.IntToCharArray(1234);
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
        [TestMethod]
        public void TestCountInteger()
        {
            Assert.AreEqual(3, FunctionLib.CountIntegerChar(100));
            Assert.AreEqual(0, FunctionLib.CountIntegerChar(0));
            Assert.AreEqual(3, FunctionLib.CountIntegerChar(-100));
            Assert.AreEqual(3, FunctionLib.CountIntegerChar(100));
            Assert.AreEqual(3, FunctionLib.CountIntegerChar(999));
        }
        [TestMethod]
        public void TestMakeSequence()
        {
            FunctionLib.NextSequenceElement funct = FunctionLib.NextEvenFibonacci;
            List<int> listNum = FunctionLib.MakeSequence(funct, 2, 10, 1, 2);
            Assert.AreEqual(4613732, FunctionLib.SumArray(listNum.ToArray()));
        }

        [TestMethod]
        public void TestMakeSequenceUnder()
        {
            FunctionLib.NextSequenceElement funct = FunctionLib.NextEvenFibonacci;
            List<int> listNum = FunctionLib.MakeSequenceUnder(funct, 2, 4000000, 1, 2);
            Assert.AreEqual(4613732, FunctionLib.SumArray(listNum.ToArray()));
        }

        [TestMethod]
        public void TestNextEvenFibonacci()
        {
            IComparer x = new StructInt32d();
            int[] input = new int[] { 1, 2 };
            var expected = Tuple.Create(8, new int[] { 5, 8 });
            var actual = FunctionLib.NextEvenFibonacci(input);
            Assert.AreEqual(expected.Item1, actual.Item1);        
            Assert.IsTrue(x.Compare(expected.Item2, actual.Item2)==0);
            actual = FunctionLib.NextEvenFibonacci(input);

            input = new int[] { 2, 3 };
            actual = FunctionLib.NextEvenFibonacci(input);
            Assert.AreEqual(expected.Item1, actual.Item1);
            Assert.IsTrue(x.Compare(expected.Item2, actual.Item2) == 0);

            input = new int[] {3,5 };
            actual = FunctionLib.NextEvenFibonacci(input);
            Assert.AreEqual(expected.Item1, actual.Item1);
            Assert.IsTrue(x.Compare(expected.Item2, actual.Item2) == 0);
        }
        [TestMethod]
        public void TestSumArray()
        {
            int[] test = new int []{ 3, 5, 7 };
            Assert.AreEqual(15, FunctionLib.SumArray(test));
        }
        [TestMethod]
        public void TestListPrimes()
        {

            List<int> list = FunctionLib.ListPrimes(100);
            Assert.AreEqual(100, list.Count);
            List<int> expected = new List<int>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541 };
            Assert.AreEqual(100, expected.Count);
            CollectionAssert.AreEqual(expected, list);
        }

        [TestMethod]
        public void TestListPrimesUnder()
        {

            List<int> list = FunctionLib.ListPrimesUnder(100);
            List<int> expected = new List<int>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97};
            CollectionAssert.AreEqual(expected, list);
        }

        [TestMethod]
        public void TestPrimeFactorize()
        {
            List<int[]> list = FunctionLib.PrimeFactorize(199);
            List<int[]> expected = new List<int[]> { new int[2] { 199, 1 } };
            IComparer cmp=(IComparer)new StructInt32d();
            CollectionAssert.AreEqual(
                expected, list, cmp);
            for (int i = 2; i <= 100; i++)
            {
                int calculatedNum = 1;
                list = FunctionLib.PrimeFactorize(i);
                foreach (int[] n in list)
                {
                    for (int j = 0; j < n[1]; j++)
                    {
                        calculatedNum *= n[0];
                    }
                }
                Assert.AreEqual(i, calculatedNum);
            }
        }

        [TestMethod]
        public void TestListMultiples()
        {
            List<int> list = FunctionLib.ListMultiples(10, 21, 132132131, 0);
            List<int> expected = new List<int> { };
            CollectionAssert.AreEqual(expected, list);
            list = FunctionLib.ListMultiples(10, 21, 132132131, 1);
            expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            CollectionAssert.AreEqual(expected, list);
        }
    }

    public class StructInt32d : IComparer
    {
        int IComparer.Compare(object a, object b)
        {
            int[] x = (int[])a;
            int[] y = (int[])b;
            if (object.ReferenceEquals(x, y)) return 0;

            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
                throw new ArgumentNullException();
            if (x.Length > y.Length)
            {
                return 1;
            }
            else if (x.Length < y.Length)
                return -1;
            else
            {
                for (int i = 0; i < x.Length; i++)
                {
                    if (x[i] > y[i])
                        return 1;
                    if  (x[i] < y[i])
                        return -1;
                    
                }
                return 0;
            }
                
        }

    }

}
