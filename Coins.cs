using System;

namespace coins
{
    class Program
    {
        // make change: an example of dynamic programming
        // Test: Prove that this works by have a fake 21 cent denomincation coin and make the code to
        // accurately make 3 of them of make change for 63 cents. there is always a 1 cent coin so all denominations are possible
        // algorithm: 
        // for coin k there are many ways to make change
        // it would be a function of min (coinchange(1,k-1), coinchange(2, k-2), coinchange(3,k-3) etc till k/2)
        // but we would repeat coinchange(1, k-1) when we do coinchange(2, k-2)
        // so the idea is to store the min for coinchange(1,k-1) so that we can use that value when we do coinchange(2, k-2)
        // algorithm for coinchange(1, k-1) is if the change can be made using 1 coin we are done, that is the minimum
        // else we keep adding a coin to get to the min. value. the trick is to add the right coin to k - n when we already know
        // min coins for n. The way to pick that coin is to see if a denomination coin already matches. for example, if we know that 
        // for a 42 cent coin is made by 2 21 cents, we should know that we need one more 21 cent coin to make it 63
        static void Main(string[] args)
        {
            int[] denominations = new int[]{1, 5, 10, 21, 25}; // not stoe in increasing order of value;
            const int makeChangeFor = 63;
            int[] minCoins = new int[makeChangeFor + 1]; // look up table that stores the min. number of coins for the "index" of the array
            int[] lastCoin = new int[makeChangeFor + 1]; // the last coin used when a min number of coins are chosen for the "index" of the array
            
            
            for(int i = 1; i <= makeChangeFor; i++)
            {
                minCoins[i] = i;
                lastCoin[i] = 1;
                for(int d = 0; d < denominations.Length; d++)
                {
                    if (i < denominations[d])
                    {
                        break;
                    }
                    if (minCoins[i] > 1 + minCoins[i-denominations[d]])
                    {
                        minCoins[i] = 1 + minCoins[i-denominations[d]];
                        lastCoin[i] = denominations[d];
                    }
                }
            }

            for (int i = 0; i <= makeChangeFor; i++){
                Console.WriteLine(i + "\t\t" + minCoins[i] + "\t\t" + lastCoin[i]);
            }            
        }
    }
}
