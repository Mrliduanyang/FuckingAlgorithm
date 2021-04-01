public class Solution {
    public bool Find132pattern(int[] nums) {
        if (nums.Length < 3)
            return false;
        var stack = new Stack<int>();
        var min = new int[nums.Length];
        min[0] = nums[0];
        for (var i = 1; i < nums.Length; i++)
            min[i] = Math.Min(min[i - 1], nums[i]);
        for (var j = nums.Length - 1; j >= 0; j--)
            if (nums[j] > min[j]) {
                while (stack.Count != 0 && stack.Peek() <= min[j])
                    stack.Pop();
                if (stack.Count != 0 && stack.Peek() < nums[j])
                    return true;
                stack.Push(nums[j]);
            }

        return false;
    }
}