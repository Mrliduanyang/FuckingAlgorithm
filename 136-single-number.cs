public class Solution {
    public int SingleNumber(int[] nums) {
        var single = 0;
        foreach (var num in nums) single ^= num;
        return single;
    }
}