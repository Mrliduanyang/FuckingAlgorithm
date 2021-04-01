public class Solution {
    public int[] SortByBits(int[] arr) {
        /**
            此题的考点：
            1。二进制位1的个数，这个会在很多地方应用到，比如快速幂，通过位运算 (x & 1) == 1 表示当前位是1
            然后让x /= 2 (x >>= 1) 向右移一位，直到 n <= 0为止

            2。自定义排序，我们要根据二进制位1的个数进行排序，默认从小到大

            在比较函数中，x comapre y 分有三种情况：
            : x > y时，返回值 > 0
            : x < y时，返回值 < 0
            : x == y时，返回值 = 0

            需要注意的是，返回值并不是严格的1，但通常会用-1，0，1 来进行统一的表示

            Array.Sort(nums, (x, y)...)

            这里的x，y要注意：

            是比较和被比较的关系
            
            比如num[2,3,4,5]

            第一次，x = ？

            x = 3,y = 2
            
            是从第1个元素开始，从后向前判断！
            第一次是：x = 3, y = 2
            第二次是：x = 4, y = 3
            第三次是：x = 5, y = 4

            3比较2，返回值 > 0
            如果是2比较3，返回值 < 0

            < 0 会交换位置， >= 0保持当前的位置不变

            默认从小到大排序，就是x.compareTo(y)
            如果从大到小排序就是 ：y.compareTo(x)

            我们也看到返回x - y的形式，结果是一样的，x-y 如果x < y 返回 < 0 ,如果 x > y 返回 > 0 否则等于0
            
            此题是按二进制位从小到大排序，我们直接返回x.compareto(y)，如果二进位相等，按字典序从小到大排，也是x.compareto(y)

        */

        if (arr == null || arr.Length <= 0) return arr;

        Array.Sort(arr, (x, y) => {
            var v1 = BitCount(x);
            var v2 = BitCount(y);
            return v1 == v2 ? x.CompareTo(y) : v1.CompareTo(v2);
        });

        return arr;
    }

    private int BitCount(int v) {
        var res = 0;
        while (v > 0) {
            if ((v & 1) == 1) res++;
            v >>= 1;
        }

        return res;
    }
}