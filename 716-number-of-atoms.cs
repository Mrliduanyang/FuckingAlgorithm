using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution {
    public string CountOfAtoms(string formula) {
        var i = 0;
        var n = formula.Length;

        string ParseAtom() {
            var sb = new StringBuilder();
            sb.Append(formula[i++]);
            while (i < n && char.IsLower(formula[i])) {
                sb.Append(formula[i++]);
            }

            return sb.ToString();
        }

        int ParseNum() {
            if (i == n || !char.IsNumber(formula[i])) {
                return 1;
            }

            var num = 0;
            while (i < n && char.IsNumber(formula[i])) {
                num = num * 10 + formula[i++] - '0'; // 扫描数字
            }

            return num;
        }

        var stack = new Stack<Dictionary<string, int>>();
        stack.Push(new Dictionary<string, int>());
        while (i < n) {
            var ch = formula[i];
            if (ch == '(') {
                ++i;
                stack.Push(new Dictionary<string, int>());
            }
            else if (ch == ')') {
                ++i;
                var num = ParseNum();
                var pop = stack.Pop();
                var peek = stack.Peek();
                foreach (var (key, val) in pop) {
                    if (peek.ContainsKey(key)) {
                        peek[key] += val * num;
                    } else {
                        peek.Add(key, val * num);
                    }
                }
            }
            else {
                var atom = ParseAtom();
                var num = ParseNum();
                var peek = stack.Peek();
                if (peek.ContainsKey(atom)) {
                    peek[atom] += num;
                }
                else {
                    peek.Add(atom, num);
                }
            }
        }

        var last = stack.Pop();
        var res = last.OrderBy(item => item.Key).Aggregate(new StringBuilder(), (prev, cur) => {
            var atom = cur.Key;
            var num = cur.Value;
            prev.Append(atom);
            if (num != 1) {
                prev.Append(num);
            }

            return prev;
        });
        return res.ToString();
    }
}