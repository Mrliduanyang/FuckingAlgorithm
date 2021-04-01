public class Solution {
    public int FindDuplicate(int[] nums) {
        var res = new int[nums.Length];
        foreach (var num in nums) res[num]++;
        for (var i = 0; i < res.Length; i++)
            if (res[i] >= 2)
                return i;
        return -1;
    }
}