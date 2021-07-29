using System;
using System.Collections.Generic;

public class Solution {
    public IList<int> PathInZigZagTree(int label) {
        var rows = Math.Log2(label) + 1;
        var res = new List<int>();

        for (var row = 1; row < rows; ++row) {
            if (row % 2 == 0) {
                for (var j = (int) Math.Pow(2, row - 1); j <= Math.Min(Math.Pow(2, row) - 1, label); ++j) {
                    res.Add(j);
                }
            }
            else {
                for (var j = (int) Math.Min(Math.Pow(2, row) - 1, label); j >= Math.Pow(2, row) - 1; --j) {
                    res.Add(j);
                }
            }
        }
        return res;
    }
}