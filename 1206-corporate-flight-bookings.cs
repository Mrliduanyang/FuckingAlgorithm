public class Solution {
    public int[] CorpFlightBookings(int[][] bookings, int n) {
        var nums = new int[n];
        var df = new Difference(nums);
        foreach (var booking in bookings) {
            var i = booking[0] - 1;
            var j = booking[1] - 1;
            var val = booking[2];
            df.Increment(i, j, val);
        }

        return df.Result();
    }

    private class Difference {
        private readonly int[] diff;

        public Difference(int[] nums) {
            diff = new int[nums.Length];
            diff[0] = nums[0];
            for (var i = 1; i < nums.Length; i++) diff[i] = nums[i] - nums[i - 1];
        }

        public void Increment(int i, int j, int val) {
            diff[i] += val;
            if (j + 1 < diff.Length) diff[j + 1] -= val;
        }

        public int[] Result() {
            var res = new int[diff.Length];
            res[0] = diff[0];
            for (var i = 1; i < diff.Length; i++) res[i] = res[i - 1] + diff[i];
            return res;
        }
    }
}