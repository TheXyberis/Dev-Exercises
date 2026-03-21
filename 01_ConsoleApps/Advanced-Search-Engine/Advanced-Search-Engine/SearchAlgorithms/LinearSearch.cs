using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Search_Engine.SearchAlgorithms
{
    public static class LinearSearch
    {
        public static int Search(List<string> data, string target)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] == target)
                {
                    return i; // found position
                }
            }
            return -1; //not found
        }
    }
}
