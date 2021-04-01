public class Solution {
    public int Calculate(string s) {
        var res = new Stack<int>();
        var num = 0;
        var symbol = '+';
        for (var i = 0; i < s.Length; i++) {
            var ch = s[i];
            if (ch == ' ' && i != s.Length - 1) continue;
            if ('0' <= ch && ch <= '9') {
                num = num * 10 + (ch - '0');
                if (i != s.Length - 1) continue;
            }

            switch (symbol) {
                case '+':
                    res.Push(num);
                    break;
                case '-':
                    res.Push(-num);
                    break;
                case '*':
                    res.Push(res.Pop() * num);
                    break;
                case '/':
                    res.Push(res.Pop() / num);
                    break;
            }

            symbol = ch;
            num = 0;
        }

        return res.Sum();
    }
}