public class Solution {
    public IList<int> MajorityElement(int[] nums) {
        var res = new List<int>();
        if (nums.Length == 0) return res;
        int cand1 = 0, cand2 = 0;
        int count1 = 0, count2 = 0;

        foreach (var num in nums) {
            // 一个票只能给一个候选人，只能选择一个if
            // 还必须得把候选人判断放在计数判断之前，否则会出现cand1和cand2相等的情况
            if (cand1 == num) {
                count1++;
                continue;
            }

            if (cand2 == num) {
                count2++;
                continue;
            }

            if (count1 == 0) {
                cand1 = num;
                count1++;
                continue;
            }

            if (count2 == 0) {
                cand2 = num;
                count2++;
                continue;
            }

            count1--;
            count2--;
        }

        count1 = count2 = 0;
        foreach (var num in nums)
            if (num == cand1)
                count1++;
            else if (num == cand2) count2++;
        if (count1 > nums.Length / 3) res.Add(cand1);
        if (count2 > nums.Length / 3) res.Add(cand2);
        return res;
    }
}