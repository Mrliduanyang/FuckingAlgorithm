public class Solution {
    public string DecodeString(string s) {
                var res = new StringBuilder();
                int multi = 0;
                var numStack = new Stack<int>();
                var strStack = new Stack<string>();
                foreach (var ch in s) {
                    if (ch == '[') {
                        numStack.Push(multi);
                        strStack.Push(res.ToString());
                        multi = 0;
                        res = new StringBuilder();
                    } else if (ch == ']') {
                        StringBuilder tmp = new StringBuilder();
                        int curNum = numStack.Pop();
                        for (int i = 0; i < curNum; i++) tmp.Append(res);
                        res = new StringBuilder(strStack.Pop() + tmp);
                    } else if (ch >= '0' && ch <= '9') multi = multi * 10 + ch - '0';
                    else res.Append(ch);
                }
                return res.ToString();
    }
}