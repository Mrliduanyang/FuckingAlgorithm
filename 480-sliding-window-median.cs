public class Solution {
    public double[] MedianSlidingWindow(int[] nums, int k) {
        var len = nums.Length - k + 1;
        var result = new double[len];
        var w = new int[k];

        // 窗口初始化并排序记录第一个中位数
        for (var i = 0; i < k; i++) w[i] = nums[i];
        //数组排序
        Array.Sort(w);
        //结果记录第一个
        result[0] = GetTemp(w);

        // 窗口开始滑动
        for (var n = 1; n < len; n++) {
            // 需要删除的元素位置
            var rmIndex = 0;
            for (var i = 0; i < k; i++)
                if (w[i] == nums[n - 1]) {
                    rmIndex = i;
                    break;
                }

            // 定位新元素需要插入的位置
            var newNum = nums[n + k - 1];
            var adIndex = 0;
            for (var i = 0; i < k; i++)
                if (newNum > w[i])
                    adIndex++;
                else
                    break;

            if (adIndex <= rmIndex) {
                // 如果新元素需要插入的位置在删除元素位置左侧，那么中间元素向右移动覆盖掉被删除的元素
                for (var i = rmIndex; i > adIndex; i--) w[i] = w[i - 1];
            }
            else {
                // 如果新元素需要插入的位置在删除元素位置右侧，那么应去除需要删除元素造成的影响因此adIndex--;
                adIndex--;
                // 中间元素向左移动覆盖掉被删除的元素
                for (var i = rmIndex; i < adIndex; i++) w[i] = w[i + 1];
            }

            // 将新元素放入相应的位置
            w[adIndex] = newNum;
            result[n] = GetTemp(w);
        }

        return result;
    }

    // 获取数组的中位数
    public double GetTemp(int[] w) {
        double temp = 0;
        var k = w.Length;
        if (k % 2 == 0) {
            var sum = w[k / 2] + (long) w[k / 2 - 1];
            temp = sum / 2.0;
        }
        else {
            temp = w[k / 2];
        }

        return temp;
    }
}