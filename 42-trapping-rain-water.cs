public class Solution {
    public int Trap(int[] height) {
        // 单调递减栈可以同时获取左右第一个比自己大的元素
        var monoStack = new Stack<int>();
        var res = 0;
        for (var i = 0; i < height.Length; i++) {
            while (monoStack.Count != 0 && height[i] > height[monoStack.Peek()]) {
                var top = monoStack.Pop();
                if (monoStack.Count == 0) break;
                var distance = i - monoStack.Peek() - 1;
                var relaHeight = Math.Min(height[i], height[monoStack.Peek()]) - height[top];
                res += distance * relaHeight;
            }

            monoStack.Push(i);
        }

        return res;
    }
}