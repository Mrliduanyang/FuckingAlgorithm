using System;
using System.Linq;

public class Solution {
    public bool CheckPermutation(string s1, string s2) {
        var ss1 = s1.OrderBy(x => x);
        var ss2 = s2.OrderBy(x => x);
        return ss1.SequenceEqual(ss2);
    }
}