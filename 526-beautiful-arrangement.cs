public class Solution {
    public int CountArrangement(int n) {
                int res = 0;
                var vis = new bool[n + 1];
                void Helper(int idx) {
                    if (idx == n + 1) res++;
                    for (int i = 1; i <= n; i++) {
                        if (!vis[i] && (idx % i == 0 || i % idx == 0)) {
                            vis[i] = true;
                            Helper(idx + 1);
                            vis[i] = false;
                        }
                    }
                }
                Helper(1);
                return res;
    }
}