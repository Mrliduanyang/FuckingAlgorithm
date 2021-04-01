internal class NumArray {
    private readonly int[] sums;

    public NumArray(int[] nums) {
        var n = nums.Length;
        sums = new int[n + 1];
        for (var i = 0; i < n; i++) sums[i + 1] = sums[i] + nums[i];
    }

    public int SumRange(int i, int j) {
        return sums[j + 1] - sums[i];
    }
}