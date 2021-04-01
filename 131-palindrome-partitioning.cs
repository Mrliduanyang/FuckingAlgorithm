public class Solution {
    public IList<IList<string>> Partition(string s) {
                int n = s.Length;
                var mem = new int[n, n];
                var res = new List<IList<string>>();
                var path = new List<string>();

                int IsPalindrome(int i, int j) {
                    if (mem[i, j] != 0) {
                        return mem[i, j];
                    }
                    if (i >= j) {
                        mem[i, j] = 1;
                    } else if (s[i] == s[j]) {
                        mem[i, j] = IsPalindrome(i + 1, j - 1);
                    } else {
                        mem[i, j] = -1;
                    }
                    return mem[i, j];
                }

                void Helper(int idx) {
                    if (idx == n) {
                        res.Add(path.ToList());
                        return;
                    }
                    for (int i = idx; i < n; i++) {
                        if (IsPalindrome(idx, i) == 1) {
                            path.Add(s.Substring(idx, i - idx +1));
                            Helper(i+1);
                            path.RemoveAt(path.Count - 1);
                        }
                    }
                }

                Helper(0);
                return res;
    }
}