using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] FindErrorNums(int[] nums) {
        var len = nums.Length;
        var total = new HashSet<int>(nums).Sum();
        return new[] {nums.Sum() - total, (1 + len) * len / 2 - total};
    }
}