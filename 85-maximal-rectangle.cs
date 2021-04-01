public class Solution {
                public int LargestRectangleArea(int[] heights) {
                int n = heights.Length;
                int[] left = new int[n];
                int[] right = new int[n];
                Array.Fill(right, n);

                var monoStack = new Stack<int>();
                for (int i = 0; i < n; ++i) {
                    while (monoStack.Count != 0 && heights[monoStack.Peek()] >= heights[i]) {
                        // 单调递增栈，出栈时获得栈顶元素右边第一个比自己小的元素
                        right[monoStack.Peek()] = i;
                        monoStack.Pop();
                    }
                    // 单调递增栈，入栈时获得入栈元素左边第一个比子集小的元素
                    left[i] = (monoStack.Count == 0 ? -1 : monoStack.Peek());
                    monoStack.Push(i);
                }
                int ans = 0;
                for (int i = 0; i < n; ++i) {
                    ans = Math.Max(ans, (right[i] - left[i] - 1) * heights[i]);
                }
                return ans;
            }
    public int MaximalRectangle(char[][] matrix) {
                if (matrix.Length == 0) return 0;
                var heights = new int[matrix[0].Length];
                int res = 0;
                for (int i = 0; i < matrix.Length; ++i) {
                    for (int j = 0; j < matrix[0].Length; ++j) {
                        if (matrix[i][j] == '1') {
                            heights[j] += 1;
                        } else {
                            heights[j] = 0;
                        }
                    }
                    res = Math.Max(res, LargestRectangleArea(heights));
                }
                return res;
    }
}