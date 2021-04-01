public class Solution {
    public int Calculate(string s) {
        var ops = new Stack<int>();
                ops.Push(1);
                int sign = 1;

                int ret = 0;
                int n = s.Length;
                int i = 0;
                while (i < n) {
                    if (s[i] == ' ') {
                        i++;
                    } else if (s[i] == '+') {
                        sign = ops.Peek();
                        i++;
                    } else if (s[i] == '-') {
                        sign = -ops.Peek();
                        i++;
                    } else if (s[i] == '(') {
                        ops.Push(sign);
                        i++;
                    } else if (s[i] == ')') {
                        ops.Pop();
                        i++;
                    } else {
                        int num = 0;
                        while (i < n && char.IsDigit(s[i])) {
                            num = num * 10 + s[i] - '0';
                            i++;
                        }
                        ret += sign * num;
                    }
                }
                return ret;
    }
}