using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEuler
{
    public class FunctionLib
    {
        public FunctionLib()
        {

        }
        public void Main(String[] args)
        {
            BitArray array = new BitArray(10);
            array.Set(5, true);
            Console.WriteLine(array[5]);
        }
        // find a list of primes using the sieve of Erotoshenes
        public List<int> listPrimes(int max)
        {
            List<int> results = new List<int>();

            //use n ln n as the upper bound on estimated nth number by PNT
            int limit =(int)(max * Math.Log(max));
            BitArray array = new BitArray(limit);
            array.SetAll(true);
            array.Set(0, false);
            array.Set(1, false);
            for (int i = 2; i * i <= limit; i++)
            {
                if (array.Get(i))
                {
                    //starts with i*i as anything lower will be a multiple of smaller primes
                    for (int j = i*i; j <= limit; j += i)
                    {
                        array.Set(j, false);
                    }
                }
            }

                return results;
        }
        public List<int> primeFactorize(int number)
        {
            List<int> results = new List<int>();

            return results;
        }
        public List<int> listMultiples(int max, params int[] variables)
        {
            List<int> results = new List<int>();

            return results;
        }
    }
}
