public class Solution {
    public bool IsAdditiveNumber(string num) {
                var res = new List<long>();
                int length = num.Length;

                bool Helper(int idx, long prev, long sum) {
                    if (idx == length) return res.Count >= 3;
                    long curLong = 0;
                    for (int i = idx; i < length; i++) {
                        // 当前块长度大于1，并且起始位是0，剪枝
                        if (i > idx && num[idx] == '0') break;
                        curLong = curLong * 10 + (num[i] - '0');
                        // if (curLong > int.MaxValue) break;
                        long cur = curLong;
                        if (res.Count >= 2) {
                            if (cur < sum) continue;
                            else if (cur > sum) break;
                        }
                        res.Add(cur);
                        if (Helper(i + 1, cur, prev + cur)) {
                            return true;
                        } else {
                            res.RemoveAt(res.Count - 1);
                        }
                    }
                    return false;
                }
                
                return Helper(0, 0, 0);
    }
}