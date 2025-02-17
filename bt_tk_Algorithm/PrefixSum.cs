using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bt_tk_Algorithm
{
    public class PrefixSum
    {
        private int[] originArr;

        private int[] prefixArr;

        public PrefixSum(int[] arr)
        {
            originArr = arr;

            //누진 배열 만들기
            prefixArr = GetPrefixArr();
        }

        private int[] GetPrefixArr()
        {
            int[] arr = new int[originArr.Length + 1];
            arr[0] = 0;

            for (int i = 1; i <= originArr.Length; i++)
            {
                arr[i] = arr[i - 1] + originArr[i - 1];
            }

            return arr;
        }

        public int GetSectionSum(int startIndex, int endIndex)
        {
            return prefixArr[endIndex + 1] - prefixArr[startIndex]; 
        }

    }
}
