using System;
using System.Collections.Generic;

public class Solution {
    public int MaxLength(IList<string> arr) {
        var res = 0;
        var masks = new List<int>();

        int BitCount(int num) {
            var res = 0;
            while (num != 0) {
                num &= num - 1;
                ++res;
            }

            return res;
        }

        void Helper(int idx, int mask) {
            if (idx == masks.Count) {
                res = Math.Max(res, BitCount(mask));
                return;
            }

            if ((mask & masks[idx]) == 0) {
                Helper(idx + 1, mask | masks[idx]);
            }

            Helper(idx + 1, mask);
        }

        foreach (var s in arr) {
            int mask = 0;
            for (var i = 0; i < s.Length; ++i) {
                var ch = s[i] - 'a';
                if (((mask >> ch) & 1) != 0) {
                    mask = 0;
                    break;
                }

                mask |= 1 << ch;
            }

            if (mask > 0) {
                masks.Add(mask);
            }
        }

        Helper(0, 0);
        return res;
    }
}