using System;

namespace DepthFirstSearch_.NET
{
    internal class Program
    {
        private readonly int[,] _cost =
        {
            {4, 7, 8, 6, 4},
            {6, 7, 3, 9, 2},
            {3, 8, 1, 2, 4},
            {7, 1, 7, 3, 7},
            {2, 9, 8, 9, 3}
        };

        private readonly int[,] _memo =
        {
            {-1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1}
        };

        private static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.MinCost(4, 4));
        }

        private int MinCost(int m, int n)
        {
            // Memoization
            if (_memo[m, n] != -1)
            {
                return _memo[m, n];
            }
            
            // wegkosten zur zelle (0,0) = kosten der zelle (0,0)
            if (m == 0 && n == 0)
            {
                return Memorize(m, n, _cost[m, n]);
            }

            // boundaries beachten!
            if (m == 0)
            {
                return Memorize(m, n, _cost[m, n] + MinCost(m, n - 1));
            }

            if (n == 0)
            {
                return Memorize(m, n, _cost[m, n] + MinCost(m - 1, n));
            }

            // rekursion
            return Memorize(m, n, _cost[m, n] + Math.Min(MinCost(m - 1, n), MinCost(m, n - 1)));
        }

        private int Memorize(int m, int n, int cost)
        {
            if (_memo[m, n] == -1)
            {
                _memo[m, n] = cost;
            }
            return cost;
        }
    }
}