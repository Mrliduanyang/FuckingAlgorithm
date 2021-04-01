public class Solution {
    public IList<string> RestoreIpAddresses(string s) {
                var res = new List<string>();
                var segments = new int[4];
                void Helper(int segIdx, int idx) {
                    if (segIdx == 4) {
                        if (idx == s.Length) {
                            res.Add(string.Join(".", segments));
                        }
                        return;
                    }
                    if (idx == s.Length) return;
                    if (s[idx] == '0') {
                        segments[segIdx] = 0;
                        Helper(segIdx + 1, idx + 1);
                    }
                    int addr = 0;
                    for (int i = idx; i < s.Length; ++i) {
                        addr = addr * 10 + (s[i] - '0');
                        if (addr > 0 && addr <= 255) {
                            segments[segIdx] = addr;
                            Helper(segIdx + 1, i + 1);
                        } else {
                            break;
                        }
                    }
                }
                Helper(0, 0);
                return res;
    }
}