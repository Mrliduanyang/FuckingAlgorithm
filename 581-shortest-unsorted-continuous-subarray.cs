public class Solution {
    public int FindUnsortedSubarray(int[] nums) {
                var stack = new Stack<int>();
                int l = nums.Length, r = 0;
                for (int i = 0; i < nums.Length; i++) {
                    while (stack.Count != 0 && nums[stack.Peek()] > nums[i]) {
                        l = Math.Min(l, stack.Pop());
                    }
                    stack.Push(i);
                }

                for (int i = nums.Length - 1; i >= 0; i--) {
                    while (stack.Count != 0 && nums[stack.Peek()] < nums[i]) {
                        r = Math.Max(r, stack.Pop());
                    }
                    stack.Push(i);
                }
                return r - l > 0 ? r - l + 1 : 0;
    }
}