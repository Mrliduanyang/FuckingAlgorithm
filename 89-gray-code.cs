public class Solution {
            public List<int> GrayCode(int n) {
                var res = new List<int>();
                res.Add(0);
                int head = 1;
                for (int i = 0; i < n; i++) {
                    for (int j = res.Count - 1; j >= 0; j--)
                        res.Add(head + res[j]);
                    head <<= 1;
                }
                return res;
            }
}