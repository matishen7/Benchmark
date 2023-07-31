using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MentorshipProgram.Session2.MyQueueProgram;

namespace Benchmark
{
    public class Leetcode
    {
        public static void Main(string[] args)
        {
            var arr = new int[] { 4, 0, 4, 3, 3 };
            Console.WriteLine(FindMaxAverage(arr, 5));
        }

        public static double FindMaxAverage(int[] nums, int k)
        {
            if (nums.Length == 1) return nums[0];

            double sumInit = 0;
            for (var i = 0; i < k; i++)
                sumInit += nums[i];
            int left = 0, right = left + k;
            double sumResult = sumInit;
            while (right < nums.Length)
            {
                var currentSum = sumInit - nums[left] + nums[right];
                Console.WriteLine("currentSum =" + currentSum);
                if (currentSum > sumResult) sumResult = currentSum;
                sumInit= currentSum;
                left++;
                right++;
            }

            return sumResult / k;

        }

        public static int KthFactor(int n, int k)
        {
            var factors = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0) factors.Add(i);
            }

            if (factors.Count > k - 1) return factors[k - 1];
            return -1;
        }

        private static bool UniqueOccurrences(int[] arr)
        {
            var dic = new Dictionary<int, int>();
            for (var i = 0; i < arr.Length; i++)
            {
                if (dic.ContainsKey(arr[i]))
                {
                    var c = dic[arr[i]];
                    dic[arr[i]] = ++c;
                }
                else
                {
                    dic[arr[i]] = 1;
                }
            }
            var result = new Dictionary<int, object>();
            foreach (var keyvalue in dic)
            {
                var v = keyvalue.Value;
                if (!result.ContainsKey(v))
                {
                    result.Add(v, new object());
                }
                else return false;
            }
            return true;
        }
    }
}
