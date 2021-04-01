public class Solution {
    public void SortColors(int[] nums) {
        int p0 = 0, curr = 0;
        int p2 = nums.Length - 1;
        while (curr <= p2) {
            if (nums[curr] == 0) {
                int tmp = nums[curr];
                nums[curr] = nums[p0];
                nums[p0] = tmp;

                p0++;
                curr++;
            } else if (nums[curr] == 1) {
                curr++;
            } else if (nums[curr] == 2) {
                int tmp = nums[curr];
                nums[curr] = nums[p2];
                nums[p2] = tmp;

                p2--;
            }
        }
    }
}