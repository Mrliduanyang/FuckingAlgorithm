public class Solution {
    public IList<int> SplitIntoFibonacci(string S) {
        var res = new List<int>();
        var length = S.Length;

        bool Helper(int idx, int prev, int sum) {
            if (idx == length) return res.Count >= 3;
            long curLong = 0;
            for (var i = idx; i < length; i++) {
                if (i > idx && S[idx] == '0') break;
                curLong = curLong * 10 + (S[i] - '0');
                if (curLong > int.MaxValue) break;
                var cur = (int) curLong;
                if (res.Count >= 2) {
                    if (cur < sum) continue;
                    if (cur > sum) break;
                }

                res.Add(cur);
                if (Helper(i + 1, cur, prev + cur))
                    return true;
                res.RemoveAt(res.Count - 1);
            }

            return false;
        }

        Helper(0, 0, 0);
        return res;
    }
}