public class Solution {
    public int HIndex(int[] citations) {
        var n = citations.Length;
        var papers = new int[n + 1];
        foreach (var citation in citations) papers[Math.Min(n, citation)]++;
        var k = n;
        for (var s = papers[n]; k > s; s += papers[k]) k--;
        return k;
    }
}