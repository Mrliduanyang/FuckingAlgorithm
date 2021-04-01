public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
                int lo = 0, hi = numbers.Length - 1;
                while (lo < hi) {
                    int sum = numbers[lo] + numbers[hi];
                    if (sum < target) {
                        lo++;
                    } else if (sum > target) {
                        hi--;
                    } else if (sum == target) {
                        return new int[] { lo + 1, hi + 1 };
                    }
                }
                return new int[] { };
    }
}