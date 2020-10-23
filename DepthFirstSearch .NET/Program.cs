using System;

namespace DepthFirstSearch_.NET
{
    internal class Program
    {
        private readonly int[,] _cost = {
            { 4, 7, 8, 6, 4 },
            { 6, 7, 3, 9, 2 },
            { 3, 8, 1, 2, 4 },
            { 7, 1, 7, 3, 7 },
            { 2, 9, 8, 9, 3 }
        };

        private static void Main(string[] args)
        {
            Console.WriteLine(new Program().MinCost(4, 4));
        }

        private int MinCost(int m, int n) {
            // wegkosten zur zelle (0,0) = kosten der zelle (0,0)
            if(m == 0 && n == 0) {
                return _cost[m, n];
            }

            // boundaries beachten!
            if(m == 0) {
                return _cost[m, n] + MinCost(m, n - 1);
            }
            if(n == 0) {
                return _cost[m, n] + MinCost(m - 1, n);
            }
            // rekursion
            return _cost[m, n] + Math.Min(MinCost(m - 1, n), MinCost(m, n - 1));
        }
    }
}