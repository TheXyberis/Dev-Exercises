using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Search_Engine.SearchAlgorithms
{
    public static class SentinelSearch
    {
        public static int Search(List<int> data, int target)
        {
            int n = data.Count;

            int last = data[n - 1]; // save the real last item so don't lose it
            data[n - 1] = target; //put our target at the end

            int i = 0;
            while (data[i] != target)//keep going until we find the target
            {
                i++;
            }
            data[n - 1] = last; //restore the original last item

            // - if 'i' is less than the last index, we found it in the middle
            // - if 'i' is the last index, check if the real last item was the target
            return (i < n - 1 || data[n - 1] == target) ? i : -1;
        }
    }
}
