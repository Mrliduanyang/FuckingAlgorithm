public class Solution {
    public int WiggleMaxLength(int[] nums) {
        var len = nums.Length;
        if (len == 0) return 0;
        List<int> res = new List<int>();
        int index = 0, i = 1;
        var Up = false;
        res.Add(nums[index]);
        while (i < len && nums[i] == res[index]) i++;
        if (i == len) return 1;
        if (nums[i] > res[index]) Up = true;
        res.Add(nums[i++]);
        index++;
        for (; i < len; i++)
            if (nums[i] > res[index]) {
                if (!Up) {
                    index++;
                    res.Add(nums[i]);
                    Up = true;
                }
                else {
                    res[index] = nums[i];
                }
            }
            else if (nums[i] < res[index]) {
                if (Up) {
                    index++;
                    res.Add(nums[i]);
                    Up = false;
                }
                else {
                    res[index] = nums[i];
                }
            }

        return res.Count;
    }
}