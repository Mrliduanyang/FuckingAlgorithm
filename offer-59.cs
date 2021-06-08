using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        var n = nums.Length;
        var res = new List<int>();
        var deque = new LinkedList<int>();
        for (var i = 0; i < n; ++i) {
            while (deque.Count !=0  && nums[deque.Last()] <= nums[i]) {
                deque.RemoveLast();
            }

            deque.AddLast(i);
            if (deque.First() < (i - k + 1)) {
                deque.RemoveFirst();
            }

            if (i >= k - 1) {
                res.Add(nums[deque.First()]);
            }
        }

        return res.ToArray();
    }
}