using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageRank
{
    class Program
    {
        public int[,] path = new int[10, 10];
        public double[] pagerank = new double[10];

        public void calc(double n)
        {
            double init, c = 0;
            int u = 1, k = 1;
            double[] temp = new double[10];
            init = 1 / n;
            System.Console.WriteLine("N value:" + n + "\t init value: " + init + "\n");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Init is: " + init);
                this.pagerank[i] = init;
                Console.WriteLine(this.pagerank[i] + " ");

            }
            System.Console.WriteLine("Inital PageRank Values, 0th step");
            for (int j = 1; j <= n; j++)
            {
                System.Console.WriteLine("Page Rank of " + j + " is: \t " + this.pagerank[j]);
            }

            while (u <= 2)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Temp is: " + temp[i]);
                    temp[i] = this.pagerank[i];
                    Console.WriteLine("Temp is now: " + temp[i]);
                    Console.WriteLine("Page rank is: "+ this.pagerank[i]);
                    this.pagerank[i] = 0;
                }
                for (int j = 0; j < n; j++)
                {
                    for (int h = 0; h < n; h++)
                    {
                        if (path[h, j] == 1)
                        {
                            k = 1;
                            c = 0;

                            while (k <= n)
                            {
                                if (path[h, k] == 1)
                                {
                                    c = c + 1;
                                    k = k + 1;
                                }
                            }
                            this.pagerank[h] = this.pagerank[h] + temp[j] * (1 / c);
                        }

                    }
                    System.Console.WriteLine("Page Rank of " + j + " is: \t" + this.pagerank[j]);
                    u = u + 1;
                }
            }
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            int nodes = 0;
            int cost = 0;

            Console.WriteLine("Enter the Number of WebPages");
            nodes = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Adjacency Matrix with 1 -> PATH & 0 -> No PATH between two WebPages:");

            for (int i = 0; i < nodes; i++)
            {
                for (int j = 0; j < nodes; j++)
                {
                    string[] integers = Console.ReadLine().Split();
                    cost = int.Parse(integers[j]);
                    p.path[i, j] = cost;

                    if (j == i)
                        p.path[i, j] = 0;
                }
                p.calc(nodes);
            }

        }
    }
}

//http://codispatch.blogspot.com/2015/12/java-program-implement-google-page-rank-algorithm.html