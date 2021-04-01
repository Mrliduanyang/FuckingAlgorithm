public class Solution {
    public int CoinChange(int[] coins, int amount) {
        // 当目标金额为i时，至少需要dp[i]枚硬币凑出
        // 初始化dp，dp各元素设置为最大值
        var dp = new int[amount + 1];
        Array.Fill(dp, amount + 1);
        // base，金额为0，硬币为0
        dp[0] = 0;
        // 求dp中所有金额
        for (var i = 0; i < dp.Length; i++) // 遍历可用的硬币
            foreach (var coin in coins) {
                // 减去硬币面值后，金额小于0，无解跳过
                if (i - coin < 0) continue;
                // 选择硬币数最少的方案
                dp[i] = Math.Min(dp[i], 1 + dp[i - coin]);
            }

        return dp[amount] == amount + 1 ? -1 : dp[amount];
    }
}