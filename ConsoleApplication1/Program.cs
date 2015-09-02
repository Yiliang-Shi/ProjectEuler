using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PEulerFunctions;

namespace ProjectEulerChallenges
{
    static class EulerProjectSolutions
    {
        static void Main(string[] args)
        {
            IOInterface();
        }

        private static void IOInterface()
        {
            int problemNum;
            do
            {
                Console.WriteLine("Project Euler - input the problem number (-1 to exit): ");
                String input = Console.ReadLine();
                if (int.TryParse(input, out problemNum))
                {
                    if (problemNum == -1)
                        break;
                    if (problemNum < 1)
                    {
                        Console.WriteLine("Invalid Problem number - Hit any key to continue");
                        Console.ReadKey(true);
                        continue;
                    }
                    int solution = runMethod(problemNum);
                    if (solution == -10005000)
                    {
                        Console.WriteLine("Invalid Problem number - Hit any key to continue");
                        Console.ReadKey(true);
                        continue;
                    }
                    Console.WriteLine("Solution is: " + solution);
                }
                else
                {
                    Console.WriteLine("Invalid Input - Hit any key to continue");
                    Console.ReadKey(true);
                    continue;
                }
            } while (true);
        }

        private static int runMethod(int problemNum)
        {
            switch (problemNum)
            {
                case 1: return problem1();
                case 2: return problem2();
                case 3: return problem3();
                case 4: return problem4();
                default: return -10005000;
            }
        }
        private static int problem4()
        {
            int result = 999999;
            int[] input = new int[] { 9, 9, 9, 9, 9, 9 };
            while (result > 1)
            {
                Tuple<int, int[]> nextPandl = FunctionLib.NextLesserPanlindrome(input);
                result = nextPandl.Item1;
                List<int[]> factors = FunctionLib.PrimeFactorize(nextPandl.Item1);
                if (factors.Count > 1)
                {
                    List<int> allFactors = new List<int>();
                    foreach (int[] n in factors)
                    {
                        foreach (int i in n)
                            allFactors.Add(i);
                    }
                    //permutation algorithm

                }
                input = nextPandl.Item2;
                nextPandl = FunctionLib.NextLesserPanlindrome(input);
            }
            return result;
        }
        private static int problem3()
        {
            List<int[]> listNum = FunctionLib.PrimeFactorize(600851475143);
            return listNum.ElementAt(listNum.Count - 1)[0];
        }

        private static int problem1()
        {
            List<int> listNum = FunctionLib.ListMultiples(999, 3, 5);
            return FunctionLib.SumArray(listNum.ToArray());
        }

        private static int problem2()
        {
            FunctionLib.NextSequenceElement funct = FunctionLib.NextEvenFibonacci;
            List<int> listNum = FunctionLib.MakeSequenceUnder(funct, 2, 4000000, 1, 2);
            return FunctionLib.SumArray(listNum.ToArray());
        }
    }
}
