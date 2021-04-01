public class Solution {
    public int RomanToInt(string s) {
                        var dict = new Dictionary<char, int>() { { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 } };
                int sum = 0, pre = dict[s[0]];
                for (int i = 1; i < s.Length; ++i) {
                    var num = dict[s[i]];
                    if (pre < num) {
                        sum -= pre;
                    } else {
                        sum += pre;
                    }
                    pre = num;
                }
                sum += pre;
                return sum;
    }
}