public class Solution {
    public string[] FindRelativeRanks(int[] nums) {
        var dict = new Dictionary<int, string>();
        for (var i = 0; i < nums.Length; i++) dict[nums[i]] = i.ToString();
        Array.Sort(nums, (x, y) => y - x);
        var res = new string[nums.Length];
        for (var i = 0; i < nums.Length; i++)
            if (i == 0)
                dict[nums[i]] = "Gold Medal";
            else if (i == 1)
                dict[nums[i]] = "Silver Medal";
            else if (i == 2)
                dict[nums[i]] = "Bronze Medal";
            else
                dict[nums[i]] = (i + 1).ToString();
        return dict.Values.ToArray();
    }
}