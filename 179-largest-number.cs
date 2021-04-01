public class Solution {
    public string LargestNumber(int[] nums) {
        var numStrs = nums.Select(x => x.ToString()).ToArray();
        Array.Sort(numStrs, (a, b) => {
            var order1 = a + b;
            var order2 = b + a;
            return order2.CompareTo(order1);
        });
        if (numStrs[0].Equals("0")) return "0";
        var res = new StringBuilder();
        foreach (var numStr in numStrs) res.Append(numStr);
        return res.ToString();
    }
}