using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bt_tk_Algorithm
{
    public class PrefixSum2D
    {
        private int[,] originArr;
        private int[,] prefixArr;

        public PrefixSum2D(int[,] arr)
        {
            originArr = arr;
            GetPrefixSum();
        }

        private int[,] GetPrefixSum()
        {
            int rows = originArr.GetLength(0);
            int cols = originArr.GetLength(1);
            prefixArr = new int[rows + 1, cols + 1];

            for (int i = 1; i <= rows; i++)
            {
                for(int j = 1; j <= cols; j++)
                {
                    prefixArr[i, j] = originArr[i -1, j - 1]
                        + prefixArr[i - 1, j]
                        + prefixArr[i, j - 1]
                        - prefixArr[i - 1, j - 1];
                }
            }

            return prefixArr;
        }

        public int GetSectionSum(int r1, int c1, int r2, int c2)
        {
            return prefixArr[r2, c2]
                - prefixArr[r1 - 1, c2]
                - prefixArr[r2, c1 - 1]
                + prefixArr[r1 - 1, c1 - 1];
        }
    }
}
