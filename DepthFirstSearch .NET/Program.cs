using System;

namespace DepthFirstSearch_.NET
{
    class Program
    {
        int[,] cost = {
            { 4, 7, 8, 6, 4 },
            { 6, 7, 3, 9, 2 },
            { 3, 8, 1, 2, 4 },
            { 7, 1, 7, 3, 7 },
            { 2, 9, 8, 9, 3 }
        };
        static void Main(string[] args)
        {
            Console.WriteLine(new Program().MinCost(4, 4));
        }
        
        int MinCost(int m, int n) {
            // wegkosten zur zelle (0,0) = kosten der zelle (0,0)
            if(m == 0 && n == 0) {
                return cost[m, n];
            }

            // boundaries beachten!
            if(m == 0) {
                return cost[m, n] + MinCost(m, n - 1);
            }
            if(n == 0) {
                return cost[m, n] + MinCost(m - 1, n);
            }
            // rekursion
            return cost[m, n] + Math.Min(MinCost(m - 1, n), MinCost(m, n - 1));
        }
    }
}