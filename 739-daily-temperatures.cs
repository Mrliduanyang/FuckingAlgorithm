public class Solution {
    public int[] DailyTemperatures(int[] T) {
                var res = new int[T.Length];
                var monoStack = new Stack<int>();
                for (int i = 0; i < T.Length; i++) {
                    while (monoStack.Count != 0 && T[i] >T[monoStack.Peek()]) {
                        var prevIdx = monoStack.Pop();
                        res[prevIdx] = i - prevIdx;
                    }
                    monoStack.Push(i);
                }
                return res;
    }
}