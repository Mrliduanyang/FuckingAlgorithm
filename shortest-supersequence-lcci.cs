using System;
using System.Collections.Generic;

public class Solution {
    public int[] ShortestSeq(int[] big, int[] small) {
        var need = new Dictionary<int, int>();
        var window = new Dictionary<int, int>();
        foreach (var num in small) {
            need[num] = 1;
        }

        int left = 0, right = 0, valid = 0;
        int start = 0, end = big.Length + 1;

        while (right < big.Length) {
            var rNum = big[right];
            if (need.ContainsKey(rNum)) {
                window[rNum] = window.GetValueOrDefault(rNum, 0) + 1;
                if (window[rNum] == need[rNum]) ++valid;
            }

            while (valid == need.Count) {
                if (right - left < end - start) {
                    start = left;
                    end = right;
                }

                var lNum = big[left];
                ++left;
                if (need.ContainsKey(lNum)) {
                    if (window[lNum] == need[lNum]) --valid;
                    --window[lNum];
                }
            }

            ++right;
        }

        return end == big.Length + 1 ? Array.Empty<int>() : new[] {start, end};
    }
}