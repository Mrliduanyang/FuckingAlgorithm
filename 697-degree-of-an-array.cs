public class Solution {
    public int FindShortestSubArray(int[] nums) {
        var dict = new Dictionary<int, int[]>();
        for (var i = 0; i < nums.Length; i++)
            if (dict.ContainsKey(nums[i])) {
                dict[nums[i]][0]++;
                dict[nums[i]][2] = i;
            }
            else {
                dict[nums[i]] = new[] {1, i, i};
            }

        int maxCount = 0, minLen = 0;
        foreach (var (key, val) in dict)
            if (maxCount < val[0]) {
                maxCount = val[0];
                minLen = val[2] - val[1] + 1;
            }
            else if (maxCount == val[0]) {
                if (minLen > val[2] - val[1] + 1) minLen = val[2] - val[1] + 1;
            }

        return minLen;
    }
}