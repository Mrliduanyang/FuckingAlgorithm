using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int BestSeqAtIndex(int[] height, int[] weight) {
        var heightAdnWeight = height.Zip(weight, (x, y) => new[] {x, y}).ToArray();
        Array.Sort(heightAdnWeight, (x, y) => {
            if (x[0] == y[0]) {
                return y[1] - x[1];
            }
            else {
                return x[0] - y[0];
            }
        });

        var secDim = heightAdnWeight.Select(x => x[1]).ToArray();

        var res = new List<int> {secDim[0]};
        for (var i = 1; i < secDim.Length; ++i) {
            var num = secDim[i];
            if (num > res.Last()) {
                res.Add(num);
            }
            else {
                var idx = res.BinarySearch(num);
                if (idx < 0) //idx小于0的情况下是补码，具体了解api
                    idx = -(idx + 1);
                res[idx] = num;
            }
        }

        return res.Count;
    }
}