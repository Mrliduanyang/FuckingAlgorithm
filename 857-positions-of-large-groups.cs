public class Solution {
    public IList<IList<int>> LargeGroupPositions(string s) {
                var res = new List<IList<int>>();
                int n = s.Length;
                int num = 1;
                for (int i = 0; i < n; i++) {
                    if (i == n - 1 || s[i] != s[i + 1]) {
                        if (num >= 3) {
                            res.Add(new List<int> { i - num + 1, i });
                        }
                        num = 1;
                    } else {
                        num++;
                    }
                }
                return res;

    }
}