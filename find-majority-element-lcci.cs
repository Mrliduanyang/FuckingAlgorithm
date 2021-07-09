using System.Linq;

public class Solution {
    public int MajorityElement(int[] nums) {
        var candidate = -1;
        var count = 0;
        foreach (var num in nums) {
            if (count == 0) {
                candidate = num;
            }

            if (candidate == num) {
                ++count;
            }
            else {
                --count;
            }
        }

        count = nums.Count(num => num == candidate);

        return count * 2 > nums.Length ? candidate : -1;
    }
}