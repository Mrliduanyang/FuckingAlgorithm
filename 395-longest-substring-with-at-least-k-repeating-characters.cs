public class Solution {
public int LongestSubstring(String s, int k) {
                int ret = 0;
                int n = s.Length;
                for (int t = 1; t <= 26; t++) {
                    int l = 0, r = 0;
                    int[] cnt = new int[26];
                    int tot = 0;
                    int less = 0;
                    while (r < n) {
                        cnt[s[r] - 'a']++;
                        if (cnt[s[r] - 'a'] == 1) {
                            tot++;
                            less++;
                        }
                        if (cnt[s[r] - 'a'] == k) {
                            less--;
                        }

                        while (tot > t) {
                            cnt[s[l] - 'a']--;
                            if (cnt[s[l] - 'a'] == k - 1) {
                                less++;
                            }
                            if (cnt[s[l] - 'a'] == 0) {
                                tot--;
                                less--;
                            }
                            l++;
                        }
                        if (less == 0) {
                            ret = Math.Max(ret, r - l + 1);
                        }
                        r++;
                    }
                }
                return ret;
            }
}