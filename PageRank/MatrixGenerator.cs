using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageRank
{
    public class MatrixGenerator
    {
        Random rnd = new Random();

        public void createMatrix(int n)
        {
            int[,] matrix = new int[n, n];

            for (int j = 0; j < n; j++)
                for (int k = 0; k < n; k++)
                    matrix[j, k] = rnd.Next(0, 1);

            using (StreamWriter writetext = new StreamWriter("randomMatrix.txt"))
            {
                writetext.WriteLine(matrix.ToString());
            }

        }
    }
}
