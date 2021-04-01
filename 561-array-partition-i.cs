public class Solution {
    public int ArrayPairSum(int[] nums) {
        Array.Sort(nums);
            int max = 0;
            for (int i = 0; i < nums.Length; i+=2)
            {
                max += nums[i];  
            }
            return max;
    }
}