public class Solution {
    public int TotalHammingDistance(int[] nums) {
        int ans = 0, n = nums.Length;
        for (var i = 0; i < 30; ++i) {
            var c = 0;
            foreach (var val in nums) {
                c += (val >> i) & 1;
            }
            ans += c * (n - c);
        }
        return ans;
    }
} 