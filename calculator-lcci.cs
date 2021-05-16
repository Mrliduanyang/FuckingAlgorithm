using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int Calculate(string s) {
        var res = new Stack<int>();
        var num = 0;
        var symbol = '+';
        s = s.Replace(" ", "");
        for (var i = 0; i < s.Length; i++) {
            var ch = s[i];
            if (char.IsDigit(ch)) {
                num = num * 10 + (ch - '0');
                if (i != s.Length - 1) {
                    continue;
                }
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