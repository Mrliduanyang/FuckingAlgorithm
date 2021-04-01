public class Solution {
    public int[] SmallerNumbersThanCurrent(int[] nums) {
        // 索引排序，用下标完成排序
        var cnt = new int[101];
        var n = nums.Length;
        for (var i = 0; i < n; i++) cnt[nums[i]]++;
        for (var i = 1; i <= 100; i++) cnt[i] += cnt[i - 1];
        var ret = new int[n];
        for (var i = 0; i < n; i++) ret[i] = nums[i] == 0 ? 0 : cnt[nums[i] - 1];
        return ret;
    }
}