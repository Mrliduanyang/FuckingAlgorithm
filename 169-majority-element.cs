public class Solution {
    public int MajorityElement(int[] nums) {
        var count = 0;
        var candidate = int.MinValue;
        foreach (var num in nums) {
            if (count == 0) candidate = num;
            if (candidate == num)
                count++;
            else
                count--;
        }

        return candidate;
    }
}