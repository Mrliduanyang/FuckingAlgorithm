public class Solution {
    public int SingleNonDuplicate(int[] nums) {
        var lo = 0;
        var hi = nums.Length - 1;
        while (lo < hi) {
            var mid = lo + (hi - lo) / 2;
            var halvesAreEven = (hi - mid) % 2 == 0;
            if (nums[mid + 1] == nums[mid]) {
                if (halvesAreEven)
                    lo = mid + 2;
                else
                    hi = mid - 1;
            }
            else if (nums[mid - 1] == nums[mid]) {
                if (halvesAreEven)
                    hi = mid - 2;
                else
                    lo = mid + 1;
            }
            else {
                return nums[mid];
            }
        }

        return nums[lo];
    }
}