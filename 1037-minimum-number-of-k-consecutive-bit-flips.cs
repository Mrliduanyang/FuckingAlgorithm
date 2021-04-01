public class Solution {
    public int MinKBitFlips(int[] A, int K) {
            int n = A.Length;
            int[] diff = new int[n + 1];
            int ans = 0, revCnt = 0;//反转次数
            for (int i = 0; i < n; i++)//遍历数组
            {
                revCnt += diff[i];//统计翻转次数
                if ((A[i] + revCnt) % 2 == 0)//如果翻转次数后结果为0
                {
                    if (i + K > n) return -1;//如果翻转越界了
                    ans++;//结果递增
                    revCnt++;//翻转次数递增
                    diff[i + K]--;//越界的次数递减
                }
            }
            return ans;
    }
}
