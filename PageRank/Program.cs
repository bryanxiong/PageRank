using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageRank
{
    public class Program
    {
        public int[,] path = new int[10, 10];
        public double[] pagerank = new double[10];
        public double[] temp = new double[10];

        public void calc(double n, int loop)
        {
            double init, c = 0;
            int u = 1, k = 1;

            init = 1 / n;

            System.Console.WriteLine("\nN value:" + n + "\t init value: " + init + "\n");
            for (int i = 1; i <= n; i++)
                this.pagerank[i] = init;
            System.Console.WriteLine("\nInital PageRank Values, 0th step\n");
            for (int j = 1; j <= n; j++)
                System.Console.WriteLine("Page Rank of " + j + " is: \t " + this.pagerank[j]);

            while (u <= loop)
            {
                for (int i = 1; i <= n; i++)
                {
                    this.temp[i] = this.pagerank[i];
                    this.pagerank[i] = 0;
                }

                for (int j = 1; j <= n; j++)
                    for (int i = 1; i <= n; i++)
                    {
                        if (this.path[i,j] == 1)
                        {
                            k = 1; c = 0;
                            while (k<=n)
                            {
                                if (this.path[i, k] == 1)
                                    c = c + 1;
                                k = k + 1;
                            }
                            this.pagerank[j] = this.pagerank[j] + this.temp[i] * (1 / c);
                        }
                    }
                System.Console.WriteLine("\nAfter " + u + "th Step\n");
                for (int i = 1; i <= n; i++)
                    System.Console.WriteLine("Page Rank of " + i + " is: \t" + this.pagerank[i]);
                u = u + 1;
            }
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            int nodes = 0;
            int loop = 0;
            List<string[]> matrix = new List<string[]>();

            Console.WriteLine("Enter the Number of WebPages");
            nodes = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How many times to loop?");
            loop = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Adjacency Matrix with 1 -> PATH & 0 -> No PATH between two WebPages:");

            String integers;
            for (int i = 1; i <= nodes; i++)
            {
                integers = Console.ReadLine();
                matrix.AddRange(integers);
                for (int j = 1; j <= nodes; j++)
                {
                    List<int> cost = integers.Split().Select(x => int.Parse(x)).ToList();
                    
                    p.path[i, j] = cost[j-1];

                    if (j == i)
                        p.path[i, j] = 0;
                }
                foreach(var m in matrix)
                {
                    Console.Write(m.ToString() + " ");
                }
            }
     
            p.calc(nodes, loop);
            
        }
    }
}
//http://codispatch.blogspot.com/2015/12/java-program-implement-google-page-rank-algorithm.html
//http://www.cs.princeton.edu/~chazelle/courses/BIB/pagerank.htm