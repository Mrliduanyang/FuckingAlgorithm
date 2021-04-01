public class Solution {
    public int ThirdMax(int[] nums) {
                long first = (long) int.MinValue - 1, second = (long) int.MinValue - 1, third = (long) int.MinValue - 1;
                foreach (var num in nums) {
                    if (num > first) {
                        third = second;
                        second = first;
                        first = num;
                    }
                    if (num < first && num > second) {
                        third = second;
                        second = num;
                    }
                    if (num < second && num > third) {
                        third = num;
                    }
                }
                return (int) (third != (long) int.MinValue - 1 ? third : first);
    }
}