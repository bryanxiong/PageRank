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

        public void calc(double n)
        {
            double init, c = 0;
            int u = 1, k = 1;
            double[] temp = new double[10];

            init = 1 / n;

            System.Console.WriteLine("\nN value:" + n + "\t init value: " + init + "\n");

            for (int i = 0; i < n; i++)
            //{
                //Console.WriteLine("Init is: " + init);
                this.pagerank[i] = init;
               // Console.WriteLine(this.pagerank[i] + " ");

            //}
            System.Console.WriteLine("\nInital PageRank Values, 0th step\n");
            for (int j = 1; j <= n; j++)
            {
                System.Console.WriteLine("Page Rank of " + j + " is: \t " + this.pagerank[j-1]);
            }

            while (u <= 2)
            {
                
                for (int i = 0; i < n; i++)
                {
                    temp[i] = this.pagerank[i];
                    this.pagerank[i] = 0;
                }

                for (int j = 0; j < n; j++)
                //{ 
                    for (int h = 0; h < n; h++)
                    {
                        if (path[h, j] == 1)
                        //{
                        { 
                            k = 1;
                            c = 0;
                        //}

                            while (k <= n)
                            {
                            if (path[h, k] == 1)
                            //{
                                c = c + 1;
                           // }
                                    k = k + 1;
                                //}
                            }
                        this.pagerank[j] = this.pagerank[j] + temp[h] * (1 / c);
                    }
                    
                }
                System.Console.WriteLine("\nAfter " + u + "th Step\n");
                for (int i = 1; i <= n; i++)
                    System.Console.WriteLine("Page Rank of " + i + " is: \t" + this.pagerank[i-1]);
                u = u + 1;
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
            Console.ReadKey();
        }
    }
}
//\http://codispatch.blogspot.com/2015/12/java-program-implement-google-page-rank-algorithm.html
