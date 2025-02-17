using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bt_tk_Algorithm
{
    public class PrefixSum2D
    {
        private int[][] originArr;
        private int[][] prefixArr;

        public PrefixSum2D(int[][] arr)
        {
            originArr = arr;
            GetPrefixSum();
        }

        private int[][] GetPrefixSum()
        {
            for (int i = 0; i < originArr.Length; i++)
            {
                for(int j = 0; j < prefixArr.Length; j++)
                {

                }
            }

            return prefixArr;
        }

        public int GetSectionSum(int r1, int c1, int r2, int c2)
        {
            return 0;
        }
    }
}
