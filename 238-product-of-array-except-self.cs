public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        var n = nums.Length;
        var prev = new int[n];
        var next = new int[n];
        prev[0] = 1;
        next[n - 1] = 1;
        for (var i = 1; i < n; i++) prev[i] = prev[i - 1] * nums[i - 1];
        for (var i = n - 2; i >= 0; i--) next[i] = next[i + 1] * nums[i + 1];
        var res = new int[n];
        for (var i = 0; i < n; i++) res[i] = prev[i] * next[i];
        return res;
    }
}