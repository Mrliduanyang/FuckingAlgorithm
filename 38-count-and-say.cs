public class Solution {
    public string CountAndSay(int n) {
                List<string> res = new List<string>();
                res.Add("1");
                for (int i = 1; i < n; ++i) {
                    var tmp = new StringBuilder();
                    int k = 0;
                    int j = 0;
                    int count = 0;
                    while (j < res[i - 1].Length) {
                        if (res[i - 1][k] == res[i - 1][j]) {
                            count++;
                            j++;
                        } else {
                            tmp.Append(count);
                            tmp.Append(res[i - 1][k]);
                            k = j;
                            count = 0;
                        }
                    }
                    tmp.Append(count);
                    tmp.Append(res[i - 1][k]);
                    res.Add(tmp.ToString());
                }
                return res.Last();
    }
}