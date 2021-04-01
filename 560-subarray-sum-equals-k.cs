public class Solution {
    public int SubarraySum(int[] nums, int k) {
        int res = 0, pre = 0;
        var dict = new Dictionary<int, int>();
        dict[0] = 1;
        for (var i = 0; i < nums.Length; i++) {
            pre += nums[i];
            if (dict.ContainsKey(pre - k)) res += dict[pre - k];
            dict[pre] = dict.GetValueOrDefault(pre, 0) + 1;
        }

        return res;
    }
}