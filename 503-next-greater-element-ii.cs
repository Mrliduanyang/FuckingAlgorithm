public class Solution {
    public int[] NextGreaterElements(int[] nums) {
        var res = new int[nums.Length];
        var stack = new Stack<int>();
        for (var i = 2 * nums.Length - 1; i >= 0; --i) {
            while (stack.Count != 0 && nums[stack.Peek()] <= nums[i % nums.Length]) stack.Pop();
            res[i % nums.Length] = stack.Count == 0 ? -1 : nums[stack.Peek()];
            stack.Push(i % nums.Length);
        }

        return res;
    }
}