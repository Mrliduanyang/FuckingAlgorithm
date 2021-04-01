public class Solution {
    public int FindContentChildren(int[] g, int[] s) {
Array.Sort(g);
                Array.Sort(s);
                int res = 0;
                int i = 0, j = 0;
                while (true) {
                    while (i < g.Length && j < s.Length) {
                        if (s[j] >= g[i]) {
                            res++;
                            i++;
                        }
                        j++;
                    }
                    if (i == g.Length || j == s.Length) {
                        break;
                    }
                }
                return res;
    }
}