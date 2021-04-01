public class Solution {
    public int LargestRectangleArea(int[] heights) {
        var n = heights.Length;
        var left = new int[n];
        var right = new int[n];
        Array.Fill(right, n);

        var monoStack = new Stack<int>();
        for (var i = 0; i < n; ++i) {
            while (monoStack.Count != 0 && heights[monoStack.Peek()] >= heights[i]) {
                // 单调递增栈，出栈时获得栈顶元素右边第一个比自己小的元素
                right[monoStack.Peek()] = i;
                monoStack.Pop();
            }

            // 单调递增栈，入栈时获得入栈元素左边第一个比子集小的元素
            left[i] = monoStack.Count == 0 ? -1 : monoStack.Peek();
            monoStack.Push(i);
        }

        var ans = 0;
        for (var i = 0; i < n; ++i) ans = Math.Max(ans, (right[i] - left[i] - 1) * heights[i]);
        return ans;
    }
}