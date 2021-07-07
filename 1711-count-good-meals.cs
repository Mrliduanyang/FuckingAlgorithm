using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int CountPairs(int[] deliciousness) {
        const int mod = 1000000007;
        var maxValue = deliciousness.Max();
        var maxSum = 2 * maxValue;
        var res = 0;
        var dict = new Dictionary<int, int>();
        foreach (var delicious in deliciousness) {
            for (var sum = 1; sum <= maxSum; sum <<= 1) {
                var count = 0;
                dict.TryGetValue(sum - delicious, out count);
                res = (res + count) % mod;
            }

            dict[delicious] = dict.GetValueOrDefault(delicious, 0) + 1;
        }

        return res;
    }
}