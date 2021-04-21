using System;
using System.Linq;

public class Solution {
    public string MinNumber(int[] nums) {
        var numStrs = nums.Select(x => x.ToString()).ToArray();
        Array.Sort(numStrs, (a, b) => {
            var order1 = a + b;
            var order2 = b + a;
            return order1.CompareTo(order2);
        });

        if (numStrs[0] == "0") return "0";
        return string.Join("", numStrs);
    }
}