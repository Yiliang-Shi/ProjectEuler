using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEulerFunctions
{
    public static class FunctionLib
    {

        //sum the elements of an integer array
        public static int SumArray(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
                sum += array[i];
            return sum;
        }

        public delegate Tuple<int, int[]> NextSequenceElement(int[] input);


        public static Tuple<int, int[]> NextLesserPanlindrome(int[] input)
        {
            int result=0;
            int length = input.Length;
            if(length % 2 == 0)
            {
                int center =length / 2;
                int posToChange = center;
                while (true)
                {
                    if (posToChange < 1)
                        throw new InvalidOperationException();
                    if (input[posToChange - 1] == 0)
                    {
                        input[posToChange - 1] = 9;
                        input[center + (center - posToChange)] = input[posToChange - 1];
                        posToChange--;
                    }
                    else
                        break;
                }
                input[posToChange - 1]--;
                input[center + (center - posToChange)] = input[posToChange -1];
            }
            else
            {
                int center =length / 2 + 1;
                int posToChange = center;
                if (posToChange < 1)
                    throw new InvalidOperationException();
                if (input[posToChange - 1] == 0)
                {
                    input[posToChange - 1] = 9;
                    input[center + (center - posToChange) - 1] = input[posToChange - 1];
                    posToChange--;
                    if (posToChange < 1)
                        throw new InvalidOperationException();
                }

                input[posToChange - 1]--;
                input[center + (center - posToChange) - 1] = input[posToChange - 1];
            }

           
            for(int i=0;i<length;i++){
                result+=(input[i])*(int)Math.Pow(10,length-1-i);
            }
            return Tuple.Create(result, input);
        }

        //Convert an Integer to an Char array of its digits
        public static char[] IntToCharArray(int num)
        {
            int length = CountIntegerChar(num);
            char[] result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] =(char) (48 + num%10);
                num /= 10;
                Console.WriteLine(result[i]+" "+num);
            }
            char temp;
            for (int i = 0; i < length/2; i++)
            {
                temp = result[i];
                result[i] = result[result.Length - 1 - i];
                result[result.Length - 1 - i] = temp;
            }
                return result;
        }

        //Count the number of digits in an Integer
        public static int CountIntegerChar(int num)
        {
            int count = 0;
            while (num != 0)
            {
                num /= 10;
                count++;
            }
            return count;

        }
        public static List<int> MakeSequence(NextSequenceElement generateNext, int first, int length, params int[] inputs)
        {
            List<int> results = new List<int>();
            results.Add(first);
            for (int i = 0; i < length; i++)
            {
                Tuple<int, int[]> temp = generateNext(inputs);
                results.Add(temp.Item1);
                inputs = temp.Item2;
            }
            return results;
        }

        public static List<int> MakeSequenceUnder(NextSequenceElement generateNext, int first, int max, params int[] inputs)
        {
            List<int> results = new List<int>();
            results.Add(first);
            while (generateNext(inputs).Item1 < max)
            {
                Tuple<int, int[]> temp = generateNext(inputs);
                results.Add(temp.Item1);
                inputs = temp.Item2;
            }
            return results;
        }

        public static Tuple<int, int[]> NextEvenFibonacci(int[] input)
        {
            if (input[0] % 2 == 1 && input[1] % 2 == 0)
            {
                int result = 2 * input[0] + 3 * input[1];
                int[] newInput = new int[] { input[0] + 2 * input[1], result };
                return Tuple.Create(result, newInput);
            }
            else if (input[0] % 2 == 0 && input[1] % 2 == 1)
            {
                int result = input[0] + 2 * input[1];
                int[] newInput = new int[] { input[0] + input[1], result };
                return Tuple.Create(result, newInput);
            }
            else
            {
                int result = input[0] + input[1];
                int[] newInput = new int[] { input[1], result };
                return Tuple.Create(result, newInput);
            }
        }
        // find a list of num primes using the sieve of Erotoshenes
        public static List<int> ListPrimes(int num)
        {
            List<int> results = new List<int>();
            if (num < 1)
                throw new ArgumentOutOfRangeException();
            if (num == 1)
            {
                results.Add(2);
                return results;
            }

            //use n ln n as the upper bound on estimated nth number by PNT
            int limit = (int)(num * (Math.Log(num) + Math.Log(Math.Log(num)) + 8));
            BitArray array = new BitArray(limit);
            array.SetAll(true);
            array.Set(0, false);
            array.Set(1, false);
            int found = 0;
            //all primes are found by sqrt(limit). However, to get complete list, it is necessary to iterate over whole space
            for (int i = 2; found < num && i <= limit; i++)
            {
                //the actual operation below happens around n log log n times in total due to prime harmonic series asymtope 
                if (array.Get(i))
                {
                    results.Add(i);
                    found++;
                    //starts with i*i as anything lower will be a multiple of smaller primes
                    if ((long)i * i > limit)
                        continue;
                    for (int j = i * i; j < limit; j += i)
                    {
                        array.Set(j, false);
                    }
                }
            }


            return results;
        }

        // find a list of primes under num using the sieve of Erotoshenes
        public static List<int> ListPrimesUnder(int num)
        {
            List<int> results = new List<int>();
            if (num < 3)
                return results;

            //use n ln n as the upper bound on estimated nth number by PNT
            int limit = num;
            BitArray array = new BitArray(limit);
            array.SetAll(true);
            array.Set(0, false);
            array.Set(1, false);
            //all primes are found by sqrt(limit). However, to get complete list, it is necessary to iterate over whole space
            for (int i = 2; i < limit; i++)
            {
                //the actual operation below happens around n log log n times in total due to prime harmonic series asymtope 
                if (array[i])
                {
                    results.Add(i);
                    //starts with i*i as anything lower will be a multiple of smaller primes
                    if (i <= Math.Sqrt(limit))
                        for (int j = i * i; j < limit; j += i)
                        {
                            array.Set(j, false);
                        }
                }
            }


            return results;
        }
        //returns a list of size 2 int arrays with the 1st element being the prime number and the 2nd its power
        public static List<int[]> PrimeFactorize(long number)
        {
            if (number < 2)
                throw new ArgumentOutOfRangeException();
            List<int[]> results = new List<int[]>();
            //list of primes to check against. Sqrt(number) is sufficent as it's not possible for 
            List<int> primeList = ListPrimes((int)Math.Sqrt(number));
            int[,] temp = new int[primeList.Count, 2];

            //add factors and power to a temp array
            for (int n = 0; n < primeList.Count; n++)
            {
                temp[n, 0] = primeList[n];
                temp[n, 1] = 0;
                while (number % primeList[n] == 0)
                {
                    number /= primeList[n];
                    temp[n, 1]++;
                }
            }

            //transfer temp array to list results
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                if (temp[i, 1] > 0)
                {
                    results.Add(new int[] { temp[i, 0], temp[i, 1] });
                }
            }
            //if the final number is not one, it is also prime. Add to results
            if (number != 1)
                results.Add(new int[] { (int)number, 1 });

            return results;
        }

        //Returns a list of all possible multiples of specified variables up to max 
        public static List<int> ListMultiples(int max, params int[] variables)
        {

            HashSet<int> multiples = new HashSet<int>();
            for (int i = 0; i < variables.Length; i++)
            {
                if (variables[i] == 0)
                    continue;
                for (int j = 1; j * variables[i] <= max; j++)
                {
                    multiples.Add(j * variables[i]);
                }
                if (variables[i] == 1)
                    break;
            }
            List<int> results = multiples.ToList();
            return results;
        }
    }
}
