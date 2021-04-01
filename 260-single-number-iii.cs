public class Solution {
    public int[] SingleNumber(int[] nums) {
        var res = new int[2];
        if (nums.Length < 2) return res;
        var xorRes = 0;
        foreach (var num in nums) xorRes ^= num;
        var idx = 1;
        while (true) {
            if ((xorRes & 1) == 1) break;
            idx = idx << 1;
            xorRes = xorRes >> 1;
        }

        foreach (var num in nums)
            if ((num & idx) == 0)
                res[0] ^= num;
            else
                res[1] ^= num;
        return res;
    }
}