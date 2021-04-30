using System.Collections.Generic;

public class Solution {
    public int SingleNumber(int[] nums) {
        var set = new SortedSet<int>(nums);
        long setSum = 0, numsSum = 0;
        foreach (var num in nums) numsSum += num;
        foreach (var num in set) setSum += num;
        return (int) ((3 * setSum - numsSum) / 2);
    }
}