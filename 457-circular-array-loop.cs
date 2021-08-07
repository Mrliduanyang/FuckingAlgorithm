public class Solution {
    public bool CircularArrayLoop(int[] nums) {
        var n = nums.Length;

        int Next(int cur) {
            return ((cur + nums[cur]) % n + n) % n;
        }

        for (var i = 0; i < n; i++) {
            if (nums[i] == 0) {
                continue;
            }

            int slow = i, fast = Next(i);
            while (nums[slow] * nums[fast] > 0 && nums[slow] * nums[Next(fast)] > 0) {
                if (slow == fast) {
                    if (slow != Next(slow)) {
                        return true;
                    }
                    else {
                        break;
                    }
                }

                slow = Next(slow);
                fast = Next(Next(fast));
            }

            var add = i;
            while (nums[add] * nums[Next(add)] > 0) {
                var tmp = add;
                add = Next(add);
                nums[tmp] = 0;
            }
        }

        return false;
    }
}