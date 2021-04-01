public class Solution {
    public string RemoveDuplicateLetters(string s) {
        var stack = new Stack<char>();
        var count = new int[256];
        for (var i = 0; i < s.Length; i++) count[s[i]]++;
        var inStack = new bool[256];
        foreach (var c in s) {
            count[c]--;
            // 如果c已经出现过，那么跳过，进行下一个。
            if (inStack[c]) continue;
            // 如果栈顶元素比c大，要考虑将c移到前面。
            while (stack.Count != 0 && stack.Peek() > c) {
                // 但只有当栈顶元素个数不为0的时候才能移。
                if (count[stack.Peek()] == 0) break;
                inStack[stack.Pop()] = false;
            }

            // 找到c的正确位置，将c入栈，并标记c为已存在。
            stack.Push(c);
            inStack[c] = true;
        }

        var res = stack.ToArray();
        Array.Reverse(res);
        return new string(res);
    }
}