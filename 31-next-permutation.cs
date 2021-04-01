public class Solution {
    public void NextPermutation(int[] nums) {
        void Swap(int i, int j) {
            var tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }

        var i = nums.Length - 2;
        while (i >= 0 && nums[i] >= nums[i + 1]) i--;
        if (i >= 0) {
            var j = nums.Length - 1;
            while (j >= 0 && nums[i] >= nums[j]) j--;
            Swap(i, j);
        }

        Array.Reverse(nums, i + 1, nums.Length - i - 1);
    }
}