public class Solution {
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        var dict = new Dictionary<int, int>();
        var stack = new Stack<int>();
        var res = new int[nums1.Length];
        var n = nums2.Length;
        for (var i = n - 1; i >= 0; i--) {
            while (stack.Count != 0 && stack.Peek() <= nums2[i]) stack.Pop();
            dict[nums2[i]] = stack.Count == 0 ? -1 : stack.Peek();
            stack.Push(nums2[i]);
        }

        for (var i = 0; i < nums1.Length; i++) res[i] = dict[nums1[i]];
        return res;
    }
}