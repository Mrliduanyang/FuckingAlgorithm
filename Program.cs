using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuckingAlgorithm {
    public class Program {
        public class Algorithm {

            // 链表节点类
            public class ListNode {
                public int val;
                public ListNode next;
                public ListNode random;

                public ListNode() { }

                public ListNode(int _val) {
                    val = _val;
                }

                public ListNode(int _val, ListNode _next, ListNode _random) {
                    val = _val;
                    next = _next;
                    random = _random;
                }
            }

            // 树节点类
            public class TreeNode {
                public int val;
                public TreeNode left;
                public TreeNode right;
                // 存储二叉树相邻节点
                public TreeNode next;
                // 存储n叉树
                public List<TreeNode> children;

                public TreeNode(int _val, TreeNode _left, TreeNode _right) {
                    val = _val;
                    left = _left;
                    right = _right;
                }
                public TreeNode(int _val, List<TreeNode> _children) {
                    val = _val;
                    children = _children;

                }
                public TreeNode(int _val) {
                    val = _val;
                }
            }

            public int Fib(int N) {
                int[] dp = new int[N + 1];
                dp[1] = dp[2] = 1;
                for (int i = 3; i <= N; i++) {
                    dp[i] = dp[i - 1] + dp[i - 2];
                }
                return dp[N];
            }

            // #322
            public int CoinChange(int[] coins, int amount) {
                // 当目标金额为i时，至少需要dp[i]枚硬币凑出
                // 初始化dp，dp各元素设置为最大值
                int[] dp = new int[amount + 1];
                Array.Fill(dp, amount + 1);
                // base，金额为0，硬币为0
                dp[0] = 0;
                // 求dp中所有金额
                for (int i = 0; i < dp.Length; i++) {
                    // 遍历可用的硬币
                    foreach (var coin in coins) {
                        // 减去硬币面值后，金额小于0，无解跳过
                        if (i - coin < 0) continue;
                        // 选择硬币数最少的方案
                        dp[i] = Math.Min(dp[i], 1 + dp[i - coin]);
                    }
                }
                return (dp[amount] == amount + 1) ? -1 : dp[amount];
            }

            // #46
            public List<List<int>> Permute(int[] nums) {
                var res = new List<List<int>>();
                var path = new List<int>();
                void Helper() {
                    if (path.Count == nums.Length) {
                        res.Add(path.ToList());
                        return;
                    }
                    foreach (var num in nums) {
                        if (path.Contains(num)) {
                            continue;
                        }
                        path.Add(num);
                        Helper();
                        path.RemoveAt(path.Count - 1);
                    }
                }
                Helper();
                return res;
            }

            public int FindTargetSumWays(int[] nums, int target) {
                Dictionary<string, int> memo = new Dictionary<string, int>();
                int dp(int i, int rest) {
                    if (i == nums.Length) {
                        if (rest == 0) {
                            return 1;
                        }
                        return 0;
                    }
                    string key = i + "," + rest;
                    if (memo.ContainsKey(key)) {
                        return memo[key];
                    }
                    // 加上或者减去当前元素后，有多少种方案能凑出新的target
                    int result = dp(i + 1, rest - nums[i]) + dp(i + 1, rest + nums[i]);
                    memo.Add(key, result);
                    return result;
                }
                return dp(0, target);
            }

            // #300
            public int LengthOfLIS(int[] nums) {
                int[] dp = new int[nums.Length];
                // base， 以nums[i]结尾的最长递增子序列起码包含自己
                Array.Fill(dp, 1);
                // 找到前面比nums[i]小的元素，将nums[i]加在该元素后面，并将长度+1
                for (int i = 0; i < nums.Length; i++) {
                    for (int j = 0; j < i; j++) {
                        if (nums[i] > nums[j]) {
                            dp[i] = Math.Max(dp[i], dp[j] + 1);
                        }
                    }
                }
                return dp.Max();
            }

            // #53
            public int MaxSubArray(int[] nums) {
                int pre = 0, maxAns = nums[0];
                foreach (int x in nums) {
                    pre = Math.Max(pre + x, x);
                    maxAns = Math.Max(maxAns, pre);
                }
                return maxAns;
            }

            public bool CanPartition(int[] nums) {
                int sum = nums.Sum();
                // 如果和是奇数，没法等分，就不存在等和子集
                if (sum % 2 != 0) {
                    return false;
                }
                int n = nums.Length;
                sum = sum / 2;
                // 对于前i个物体，当背包容量为j时，是否可以装满
                bool[,] dp = new bool[n + 1, sum + 1];
                // base当背包容量为0，肯定已经装满，当没有物体，肯定无法装满
                for (int i = 1; i <= n; i++) {
                    dp[i, 0] = true;
                }
                for (int i = 1; i <= n; i++) {
                    for (int j = 1; j <= sum; j++) {
                        if (j - nums[i - 1] < 0) {
                            // 背包容量不足，不能装入第 i 个物品
                            dp[i, j] = dp[i - 1, j];
                        } else {
                            // 能装，但可以选择装或者不装
                            dp[i, j] = dp[i - 1, j] || dp[i - 1, j - nums[i - 1]];
                        }
                    }
                }
                return dp[n, sum];
            }

            public int Change(int amount, int[] coins) {
                int n = coins.Length;
                int[,] dp = new int[n + 1, amount + 1];
                // base不用任何硬币，凑不去任何金额，当要凑出0，只有一种方案
                for (int i = 0; i <= n; i++) {
                    dp[i, 0] = 1;
                }
                for (int i = 1; i <= n; i++) {
                    for (int j = 1; j <= amount; j++) {
                        if (j - coins[i - 1] >= 0) {
                            // 目标金额减去当前硬币金额大于硬币金额，可以使用该硬币，也可以不使用
                            dp[i, j] = dp[i - 1, j] + dp[i, j - coins[i - 1]];
                        } else {
                            // 不能使用该硬币
                            dp[i, j] = dp[i - 1, j];
                        }
                    }
                }
                return dp[n, amount];
            }

            // #72
            public int MinDistance(string word1, string word2) {
                int Min(int a, int b, int c) {
                    return Math.Min(Math.Min(a, b), c);
                }

                int m = word1.Length, n = word2.Length;
                int[,] dp = new int[m + 1, n + 1];
                // base，“”到m的编辑距离为0-m，“”到n的编辑距离为0-n
                for (int i = 0; i <= m; i++) dp[i, 0] = i;
                for (int i = 0; i <= n; i++) dp[0, i] = i;

                for (int i = 1; i <= m; i++) {
                    for (int j = 1; j <= n; j++) {
                        if (word1[i - 1] == word2[j - 1]) {
                            dp[i, j] = dp[i - 1, j - 1];
                        } else {
                            dp[i, j] = Min(
                                dp[i - 1, j] + 1,
                                dp[i, j - 1] + 1,
                                dp[i - 1, j - 1] + 1
                            );
                        }
                    }
                }
                return dp[m, n];
            }

            public int SuperEggDrop(int k, int n) {
                Dictionary<string, int> memo = new Dictionary<string, int>();
                int dp(int k, int n) {
                    // base如果只有1个鸡蛋，只能线性扫描
                    if (k == 1) {
                        return n;
                    }
                    // 如果是0层，尝试0次
                    if (n == 0) {
                        return 0;
                    }
                    // 备忘录
                    string key = k + "," + n;
                    if (memo.ContainsKey(key)) {
                        return memo[key];
                    }
                    var res = Int32.MaxValue;
                    // 存在重叠子问题，比如n-i = i-1
                    // 如果在i层没碎，鸡蛋数k不变，搜索楼层变为i+1 - n，如果鸡蛋碎了，k减1，搜索楼层变为1 - i-1。
                    // 也很好理解，如果在i层还没碎，那么还需要多少次能找到楼层就取决于在i层之后的楼层区间内要试验多少次。
                    for (int i = 1; i < n + 1; i++) {
                        res = Math.Min(res, Math.Max(dp(k, n - i), dp(k - 1, i - 1)) + 1);
                    }
                    memo.Add(key, res);
                    return res;
                }
                return dp(k, n);
            }

            public int SuperEggDrop_1(int k, int n) {
                // dp定义为给定k个鸡蛋，可以尝试扔m次鸡蛋，最坏情况下能确切测试一栋n层的楼
                // base dp[0][..] = 0 dp[..][0] = 0
                // m最大为n，线性扫描
                int[,] dp = new int[k + 1, n + 1];
                int m = 0;
                while (dp[k, m] < n) {
                    m++;
                    for (int i = 1; i <= k; i++) {
                        // dp[i, m - 1]是楼上的楼层数，鸡蛋没碎，i不变，扔鸡蛋次数m-1，dp[i - 1, m - 1]是楼下楼层数，鸡蛋碎了i-1，扔鸡蛋次数m-1
                        dp[i, m] = dp[i, m - 1] + dp[i - 1, m - 1] + 1;
                    }
                }
                return m;
            }

            public int Rob_1(int[] nums) {
                int n = nums.Length;
                // dp定义为从第i间房开始抢劫，最多能抢到的钱
                // base dp[n] = 0
                int[] dp = new int[n + 2];
                // 从n-1间房开始
                for (int i = n - 1; i >= 0; i--) {
                    // 
                    dp[i] = Math.Max(dp[i + 1], dp[i + 2] + nums[i]);
                }
                return dp[0];
            }

            public int Rob_2(int[] nums) {
                int RobRange(int start, int end) {
                    int n = nums.Length;
                    int[] dp = new int[n + 2];
                    for (int i = end; i >= start; i--) {
                        dp[i] = Math.Max(dp[i + 1], dp[i + 2] + nums[i]);
                    }
                    return dp[start];
                }

                int n = nums.Length;
                if (n == 1) {
                    return nums[0];
                }
                return Math.Max(RobRange(1, n - 1), RobRange(0, n - 2));
            }

            // #516
            public int LongestPalindromeSubseq(string s) {
                int n = s.Length;
                // 涉及两个字符串，用二维dp数组
                // dp定义为在array[i..j]中，最长回文子序列的长度为dp[i][j]
                int[,] dp = new int[n, n];
                // base如果只有一个字符，最长回文子序列长度为1
                for (int i = 0; i < n; i++) {
                    dp[i, i] = 1;
                }
                // 要求dp[0,n-1]，斜着遍历或者反着遍历
                for (int i = n - 1; i >= 0; i--) {
                    // j比i大
                    for (int j = i + 1; j < n; j++) {
                        if (s[i] == s[j]) {
                            // 如果s[i]和s[j]字符相同，最长回文子序列长度加2
                            dp[i, j] = dp[i + 1, j - 1] + 2;
                        } else {
                            // 反之，将两个字符分别添加上，比较长度
                            dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                        }
                    }
                }
                return dp[0, n - 1];
            }

            public int IntervalSchedule(int[][] intvs) {
                if (intvs.Length == 0) {
                    return 0;
                }
                // 按结束时间升序排列
                Array.Sort(intvs, (a, b) => a[1].CompareTo(b[1]));
                int count = 1;
                int x_end = intvs[0][1];
                foreach (var item in intvs) {
                    int start = item[0];
                    if (start >= x_end) {
                        count++;
                        x_end = item[1];
                    }
                }
                return count;
            }

            // #121
            public int MaxProfit(int[] prices) {
                int n = prices.Length;
                var dp = new int[n, 2];
                dp[0, 1] = -prices[0];
                for (int i = 1; i < n; i++) {
                    dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
                    dp[i, 1] = Math.Max(dp[i - 1, 1], -prices[i]);
                }
                return dp[n - 1, 0];
            }

            public int MaxProfit_2(int[] prices) {
                // 交易次数k=无穷
                int n = prices.Length;
                // 为了避免处理i-1导致的数组越界，将状态压缩
                int dp_i_0 = 0, dp_i_1 = Int32.MinValue;
                for (int i = 0; i < n; i++) {
                    int temp = dp_i_0;
                    dp_i_0 = Math.Max(dp_i_0, dp_i_1 + prices[i]);
                    dp_i_1 = Math.Max(dp_i_1, temp - prices[i]);
                }
                return dp_i_0;
            }
            public int MaxProfit_3(int[] prices) {
                // 交易次数k=无穷，加入冷冻期，间隔一天才能交易
                int n = prices.Length;
                int dp_i_0 = 0, dp_i_1 = Int32.MinValue;
                int dp_pre_0 = 0;
                for (int i = 0; i < n; i++) {
                    int temp = dp_i_0;
                    dp_i_0 = Math.Max(dp_i_0, dp_i_1 + prices[i]);
                    dp_i_1 = Math.Max(dp_i_1, dp_pre_0 - prices[i]);
                    // 旧的i-1在下次循环时就相当于i-2
                    dp_pre_0 = temp;
                }
                return dp_i_0;
            }

            // #714
            public int MaxProfit_4(int[] prices, int fee) {
                // 交易次数k=无穷，假如交易手续费，相当于买入股票价格高了，或者卖出股票价格减小了
                int n = prices.Length;
                int dp_i_0 = 0, dp_i_1 = Int32.MinValue;
                for (int i = 0; i < n; i++) {
                    int temp = dp_i_0;
                    dp_i_0 = Math.Max(dp_i_0, dp_i_1 + prices[i]);
                    dp_i_1 = Math.Max(dp_i_1, temp - prices[i] - fee);
                }
                return dp_i_0;
            }

            // #188
            // #123
            public int MaxProfit(int k, int[] prices) {
                int n = prices.Length;
                if (k > n / 2)
                    return MaxProfit_2(prices);

                int[,,] dp = new int[n + 1, k + 1, 2];
                for (int i = 0; i <= n; i++) {
                    for (int j = k; j >= 1; j--) {
                        if (i - 1 == -1) {
                            dp[0, j, 0] = 0;
                            dp[0, j, 1] = int.MinValue;
                            dp[i, 0, 0] = 0;
                            dp[i, 0, 1] = int.MinValue;
                            continue;
                        }
                        dp[i, j, 0] = Math.Max(dp[i - 1, j, 0], dp[i - 1, j, 1] + prices[i - 1]);
                        dp[i, j, 1] = Math.Max(dp[i - 1, j, 1], dp[i - 1, j - 1, 0] - prices[i - 1]);
                    }
                }
                return dp[n, k, 0];
            }

            // #5
            public string LongestPalindrome(string s) {
                string Palindrome(string s, int l, int r) {
                    while (l >= 0 && r < s.Length && s[l] == s[r]) {
                        l--;
                        r++;
                    }
                    return s.Substring(l + 1, r - l - 1);
                }

                string res = "";
                for (int i = 0; i < s.Length; i++) {
                    // 以s[i]为中心的最长回文子串
                    string s1 = Palindrome(s, i, i);
                    // 以s[i]和s[i+1]为中心的最长回文子串
                    string s2 = Palindrome(s, i, i + 1);
                    res = res.Length > s1.Length ? res : s1;
                    res = res.Length > s2.Length ? res : s2;
                }
                return res;
            }

            // #234
            public bool IsPalindrome(ListNode head) {
                ListNode left = head;
                bool Traverse(ListNode right) {
                    if (right == null) {
                        return true;
                    }
                    // 利用后序遍历，通过递归，深入到链表最后一个节点，然后比较right和left。
                    // 之后right返回到递归的上一层，相当于右指针左移，left=left.next等于左指针右移，巧妙实现双指针。
                    bool res = Traverse(right.next);
                    res = res && (left.val == right.val);
                    left = left.next;
                    return res;
                }
                return Traverse(head);
            }

            public int Trap_1(int[] height) {
                if (height.Length == 0) {
                    return 0;
                }
                int n = height.Length;
                int ans = 0;
                int[] lMax = new int[n], rMax = new int[n];
                // base。l_max表示位置i左侧最高柱子的高度，r_max表示位置右侧最高柱子的高度
                lMax[0] = height[0];
                rMax[n - 1] = height[n - 1];
                // 从左向右计算 l_max
                for (int i = 1; i < n; i++) {
                    lMax[i] = Math.Max(height[i], lMax[i - 1]);
                }
                // 从右向左计算 r_max
                for (int i = n - 2; i >= 0; i--) {
                    rMax[i] = Math.Max(height[i], rMax[i + 1]);
                }
                for (int i = 1; i < n - 1; i++) {
                    ans += Math.Min(lMax[i], rMax[i]) - height[i];
                }
                return ans;
            }

            public int Trap_2(int[] height) {
                int n = height.Length;
                int left = 0, right = n - 1;
                int l_max = height[0], r_max = height[n - 1];
                int ans = 0;
                while (left <= right) {
                    // left表示0-left的最高柱子高度，right表示right-end的最高柱子高度。
                    // 和备忘录方法中的left，right含义稍有区别，只用关心l_max和r_max的大小，不用管r_max是否是最。反正一样
                    l_max = Math.Max(l_max, height[left]);
                    r_max = Math.Max(r_max, height[right]);
                    if (l_max < r_max) {
                        ans += l_max - height[left];
                        left++;
                    } else {
                        ans += r_max - height[right];
                        right--;
                    }
                }
                return ans;
            }

            class UF {
                public int count;
                public int[] parent;
                // 记录数组重量
                public int[] size;
                public UF(int n) {
                    count = n;
                    parent = new int[n];
                    for (int i = 0; i < parent.Length; i++) {
                        parent[i] = i;
                    }
                }

                public UF(int n, int flag) {
                    count = n;
                    parent = new int[n];
                    size = new int[n];
                    for (int i = 0; i < parent.Length; i++) {
                        parent[i] = i;
                        size[i] = 1;
                    }
                }

                public void Union(int p, int q) {
                    int rootP = Find(p);
                    int rootQ = Find(q);
                    if (rootP == rootQ) {
                        return;
                    }
                    // 将两棵树合并为一棵
                    parent[rootP] = rootQ;
                    count--;
                }

                public void Union_1(int p, int q) {
                    int rootP = Find(p);
                    int rootQ = Find(q);
                    if (rootP == rootQ) {
                        return;
                    }
                    if (size[rootP] > size[rootQ]) {
                        // 重量小的树接到重量大的树下面，避免头重脚轻，更平衡
                        parent[rootQ] = rootP;
                        size[rootP] += size[rootQ];
                    } else {
                        parent[rootP] = rootQ;
                        size[rootQ] += size[rootP];
                    }
                    count--;
                }

                // 找节点x的根节点
                public int Find(int x) {
                    while (parent[x] != x) {
                        x = parent[x];
                    }
                    return x;
                }
                public int Find_1(int x) {
                    while (parent[x] != x) {
                        // 路径压缩，最终树高不会超过3
                        parent[x] = parent[parent[x]];
                        x = parent[x];
                    }
                    return x;
                }

                public int Count() {
                    return count;
                }

                public bool Connected(int p, int q) {
                    int rootP = Find(p);
                    int rootQ = Find(q);
                    return rootP == rootQ;
                }
            }

            public bool EuqationsPossible(string[] euqations) {
                UF uf = new UF(26);
                // 让相同的字母形成联通分量
                foreach (string eq in euqations) {
                    if (eq[1] == '=') {
                        var x = eq[0];
                        var y = eq[3];
                        uf.Union(x - 'a', y - 'a');
                    }
                }
                foreach (string eq in euqations) {
                    if (eq[1] == '!') {
                        var x = eq[0];
                        var y = eq[3];
                        // 如果在并查集中x和y已经存在联通关系，即x==y，那么就跟该不等关系冲突
                        if (uf.Connected(x - 'a', y - 'a')) {
                            return false;
                        }
                    }
                }
                return true;
            }

            public List<int> PancakeSort(int[] cakes) {
                List<int> res = new List<int>();
                void Reverse(int[] arr, int i, int j) {
                    while (i < j) {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                        i++;
                        j--;
                    }
                }
                void Sort(int[] cakes, int n) {
                    if (n == 1) {
                        return;
                    }
                    int maxCake = 0;
                    int maxCakeIndex = 0;
                    for (int i = 0; i < n; i++) {
                        if (cakes[i] > maxCake) {
                            maxCakeIndex = i;
                            maxCake = cakes[i];
                        }
                    }
                    // 第一次翻转，把最大的饼翻到最上面
                    Reverse(cakes, 0, maxCakeIndex);
                    res.Add(maxCakeIndex + 1);
                    // 第二次翻转，把最大的饼翻到最下面
                    Reverse(cakes, 0, n - 1);
                    res.Add(n);
                    // 递归求解子问题
                    Sort(cakes, n - 1);
                }
                Sort(cakes, cakes.Length);
                return res;
            }

            // 暴力算法也是线性搜索，找到一个合适的速度。所以可以用二分搜索来优化
            public int MinEatingSpeed(int[] piles, int h) {
                bool CanFinish(int[] piles, int speed, int h) {
                    int time = 0;
                    foreach (var item in piles) {
                        time += TimeOf(item, speed);
                    }
                    return time <= h;
                }

                int TimeOf(int n, int speed) {
                    // 题目规定，一堆吃不下的话就留到下一小时再吃，如果一堆吃完了还有胃口，也只会等到下一小时再吃
                    // n < speed时n % speed = 0，整体结果=1
                    return (n / speed) + ((n % speed > 0) ? 1 : 0);
                }

                int GetMax(int[] piles) {
                    int max = 0;
                    foreach (var item in piles) {
                        max = Math.Max(max, item);
                    }
                    return max;
                }

                int left = 1, right = GetMax(piles);
                while (left < right) {
                    int mid = (left + right) / 2; // = left + (right - left) / 2
                    if (CanFinish(piles, mid, h)) {
                        right = mid;
                    } else {
                        left = mid + 1;
                    }
                }
                return left;
            }

            public int[] TwoSum_1(int[] nums, int target) {
                int n = nums.Length;
                Dictionary<int, int> index = new Dictionary<int, int>();
                for (int i = 0; i < n; i++) {
                    index.Add(nums[i], i);
                }
                for (int i = 0; i < n; i++) {
                    int other = target - nums[i];
                    if (index.ContainsKey(other) && index[other] != i) {
                        return new int[] { i, index[other] };
                    }
                }
                return new int[] { -1, -1 };
            }

            class TwoSum {
                Dictionary<int, int> freq = new Dictionary<int, int>();

                public void Add(int number) {
                    freq.Add(number, freq.GetValueOrDefault(number, 0) + 1);
                }

                public bool Find(int value) {
                    foreach (var key in freq.Keys) {
                        int other = value - key;
                        // 情况1，两个加数相同，就需要看freq中该加数个数是否大于1
                        if (other == key && freq[key] > 1) {
                            return true;
                        }
                        // 情况2，两个加数不同，要判断另一个加数是否在freq中
                        if (other != key && freq.ContainsKey(other)) {
                            return true;
                        }
                    }
                    return false;
                }
            }

            class TwoSum_2 {
                HashSet<int> sum = new HashSet<int>();
                List<int> nums = new List<int>();

                // 针对Find优化，在存入number时，同时存入number与nums中所有元素的和，即可在O(1)时间内执行Find
                public void Add(int number) {
                    nums.ForEach((num) => {
                        sum.Add(num + number);
                    });
                    nums.Add(number);
                }

                public bool Find(int value) {
                    return sum.Contains(value);
                }
            }

            public bool CanJump(int[] nums) {
                int n = nums.Length;
                int farthest = 0;
                for (int i = 0; i < n - 1; i++) {
                    // 每一步都计算一下从当前位置最远能够跳到哪里。因为只要数组元素不为0，就肯定可以向前走，所以只需求得在位置i上能不能跳过终点。
                    farthest = Math.Max(farthest, i + nums[i]);
                    if (farthest <= i) {
                        return false;
                    }
                }
                return farthest >= n - 1;
            }

            public int Jump(int[] nums) {
                int n = nums.Length;
                int end = 0, farthest = 0;
                int jumps = 0;
                for (int i = 0; i < n - 1; i++) {
                    // i和end标记了从位置i开始可选的跳跃位置，farthest标记了可选跳跃位置中能到的最远距离。因为在i到end中，我们只用选择那个能跳的最远的点。
                    farthest = Math.Max(i + nums[i], farthest);
                    if (i == end) {
                        jumps++;
                        end = farthest;
                    }
                }
                return jumps;
            }

            public int[][] MergeIntervals(int[][] intervals) {
                // 按区间start升序排列
                Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
                List<int[]> res = new List<int[]>();
                res.Add(intervals[0]);
                for (int i = 1; i < intervals.Length; i++) {
                    var curr = intervals[i];
                    // res中最后一个元素的引用，所以可以不断修改last的end。
                    var last = res.Last();
                    // 如果curr的start小于last的end，说明curr可能在last的区间内，这时需要比较curr的end和last的end，确定是否更新last的end。
                    if (curr[0] <= last[1]) {
                        last[1] = Math.Max(last[1], curr[1]);
                    } else {
                        res.Add(curr);
                    }
                }
                return res.ToArray();
            }

            public List<int[]> IntervalIntersection(int[][] a, int[][] b) {
                int i = 0, j = 0;
                List<int[]> res = new List<int[]>();
                while (i < a.Length && j < b.Length) {
                    int a1 = a[i][0];
                    int a2 = a[i][1];
                    int b1 = a[j][0];
                    int b2 = a[j][1];
                    // 两个区间存在交集。两个区间不存在交集的情况为：a1 > b2 或者b1 > a2。否命题就是存在交集的情况。
                    if (b2 >= a1 && a2 >= b1) {
                        // 交集为大的start-小的end
                        res.Add(new int[] { Math.Max(a1, b1), Math.Min(a2, b2) });
                    }
                    // 指针前进，如果a2比较大，b中选择下一个；反之
                    if (b2 < a2) {
                        j++;
                    } else {
                        i++;
                    }
                }
                return res;
            }

            // 理论证明，从n个元素中选择1个，要保证每个元素被选择的概率都是1/n。对于1-i个元素，选择第i个元素的概率是1/i，
            // 为保证在n个元素中第i个元素被选择的概率不变，需要保证i后面的元素，都不被选择。概率连乘完的结果表明，第i个元素被选择的概率是1/n。
            public int GetRandom(ListNode head) {
                Random r = new Random();
                int i = 0, res = 0;
                ListNode p = head;
                while (p != null) {
                    // 生成一个[0，i]之间的整数，这个数等于0的概率即是1/i
                    if (r.Next(++i) == 0) {
                        res = p.val;
                    }
                    p = p.next;
                }
                return res;
            }

            public int[] GetRandom(ListNode head, int k) {
                Random r = new Random();
                int[] res = new int[k];
                ListNode p = head;

                // 前 k 个元素先默认选上
                for (int j = 0; j < k && p != null; j++) {
                    res[j] = p.val;
                    p = p.next;
                }

                int i = k;
                while (p != null) {
                    // 生成一个 [0, i) 之间的整数
                    int j = r.Next(++i);
                    // 这个整数小于 k 的概率就是 k/i
                    if (j < k) {
                        res[j] = p.val;
                    }
                    p = p.next;
                }
                return res;
            }

            // #268
            public int MissingNumber(int[] nums) {
                int n = nums.Length;
                int res = 0;
                // 先和新补的索引异或
                res ^= n;
                // 把所有的0-n索引和值异或，相同的异或完得0，剩下就是缺失的元素。
                for (int i = 0; i < n; i++) {
                    res ^= (i ^= nums[i]);
                }
                return res;
            }

            public int MissingNumber_2(int[] nums) {
                int n = nums.Length;
                int res = 0;
                // 补的新索引位置的元素
                res += n;
                for (int i = 0; i < n; i++) {
                    // 把索引和元素的差加起来
                    res += (i - nums[i]);
                }
                return res;
            }

            public int[] FindErrorNums(int[] nums) {
                int n = nums.Length;
                int dup = -1;
                // 每一个出现过的元素都变为相反数，以标记其出现过。值和索引值不一定对应，只要能标记出现过的元素即可。
                // 例如两个值4，对应索引4的值是2，会在第一次出现值4的时候，将2变为-2，如果第二次出现，就可以找到重复元素
                for (int i = 0; i < n; i++) {
                    // 所以此处index要取绝对值，
                    int index = Math.Abs(nums[i]);
                    if (nums[index] < 0) {
                        dup = Math.Abs(nums[i]);
                    } else {
                        nums[index] *= -1;
                    }
                }
                int missing = -1;
                for (int i = 0; i < n; i++) {
                    // 对应索引有值的索引都已经变为相反数，所以值为正的索引就是确实元素
                    if (nums[i] > 0)
                        // 将索引转换成元素
                        missing = i + 1;
                }
                return new int[] { dup, missing };
            }

            // #43
            public string Multiply(string num1, string num2) {
                if (num1 == "0" || num2 == "0") return "0";
                int m = num1.Length, n = num2.Length;
                int[] res = new int[m + n];
                for (int i = m - 1; i >= 0; i--) {
                    for (int j = n - 1; j >= 0; j--) {
                        // 字符转为数字后相乘
                        int mul = (num1[i] - '0') * (num2[j] - '0');
                        // 乘积在结果中对应的位置
                        int p1 = i + j, p2 = i + j + 1;
                        // 处理本位和
                        int sum = mul + res[p2];
                        // 本位结果
                        res[p2] = sum % 10;
                        // 进位结果
                        res[p1] += sum / 10;
                    }
                }
                return string.Join("", res).TrimStart('0');
            }

            // 洗牌算法的正确性准则，产生的结果必须啊有n!种。因为长度为n的数组的全排列有n!种，也就是说打乱结果总数为n!种。
            public void Shuffle(int[] arr) {
                Random r = new Random();
                int n = arr.Length;
                // 第一轮迭代是，rand取值n，第二轮迭代，rand取值有n-1个，依次类推，总共有n!种。符合正确性准则。
                for (int i = 0; i < n; i++) {
                    int rand = r.Next(i, n);
                    // Swap交换数组元素
                    int tmp = arr[i];
                    arr[i] = arr[rand];
                    arr[rand] = tmp;
                }
                // 错误的写法，共产生n^n种结果，!= n!。
                for (int i = 0; i < n; i++) {
                    // 每次都从闭区间 [0, n-1]中随机选取元素进行交换。
                    int rand = r.Next(i, n);
                }
            }

            public int[,] FloodFill(int[,] iamge, int sr, int sc, int newColor) {
                void Fill(int[,] iamge, int x, int y, int origColor, int newColor) {
                    // 出界。
                    if (!InArea(iamge, x, y)) {
                        return;
                    }
                    // 遇到其他颜色。
                    if (iamge[x, y] != origColor) {
                        return;
                    }
                    if (iamge[x, y] == -1) {
                        return;
                    }
                    // 按回溯法思路处理无限递归的情况，打标记，以免重复探索。
                    iamge[x, y] = -1;
                    // 递归替换左右上下的像素。
                    Fill(iamge, x, y - 1, origColor, newColor);
                    Fill(iamge, x, y + 1, origColor, newColor);
                    Fill(iamge, x - 1, y, origColor, newColor);
                    Fill(iamge, x + 1, y, origColor, newColor);
                    // 如果邻居都探索完了，没有问题，那么该点自然可以替换成newColor。
                    iamge[x, y] = newColor;
                }

                bool InArea(int[,] iamge, int x, int y) {
                    return x >= 0 && x < iamge.GetLength(0) && y >= 0 && y < iamge.GetLength(1);
                }
                int origColor = iamge[sr, sc];
                Fill(iamge, sr, sc, origColor, newColor);
                return iamge;
            }

            class KMP {
                int[,] dp;
                string pat;

                public KMP(string pat) {
                    this.pat = pat;
                    int m = pat.Length;
                    // ASCII不会超过256个，构造一个二维dp数组包含所有情况。
                    dp = new int[m, 256];
                    // base，遇到pat的第一个字符，才会前进。
                    dp[0, pat[0]] = 1;
                    int x = 0;
                    // pat串从第一个开始。
                    for (int i = 1; i < m; i++) {
                        for (int j = 0; i < 256; j++) {
                            if (pat[i] == j) {
                                // 遇到pat[i]可以前进。
                                dp[i, j] = i + 1;
                            } else {
                                // 否则等于影子状态。
                                dp[i, j] = dp[x, j];
                            }
                        }
                        // 更新影子状态x，x总是落后i一个状态。x貌似是沿着斜对角下来的。
                        x = dp[x, pat[i]];
                    }
                }

                public int Search(String txt) {
                    int m = pat.Length;
                    int n = txt.Length;
                    // pat的初始态为0。
                    int j = 0;
                    for (int i = 0; i < n; i++) {
                        // 计算pat的下一个状态。
                        j = dp[j, txt[i]];
                        // 到达终止态，返回结果。
                        if (j == m) return i - m + 1;
                    }
                    // 没到达终止态，匹配失败。
                    return -1;
                }
            }

            // class Tree {

            public bool IsSameTree(TreeNode p, TreeNode q) {
                if (p == null && q == null) {
                    return true;
                }
                if (p == null || q == null) {
                    return false;
                }
                if (p.val != q.val) {
                    return false;
                }
                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            }

            public int MaxDepth(TreeNode root) {
                if (root == null) return 0;
                var queue = new Queue<TreeNode>();
                queue.Enqueue(root);
                int level = 0;
                while (queue.Count != 0) {
                    int count = queue.Count;
                    level++;
                    for (int i = 0; i < count; i++) {
                        var node = queue.Dequeue();
                        if (node.left != null) {
                            queue.Enqueue(node.left);
                        }
                        if (node.right != null) {
                            queue.Enqueue(node.right);
                        }
                    }
                }
                return level;
            }

            // #144
            // public IList<int> PreorderTraversal(TreeNode root) {
            //     if (root == null) return new List<int> { };
            //     var stack = new Stack<TreeNode>();
            //     var res = new List<int>();
            //     stack.Push(root);
            //     while (stack.Count != 0) {
            //         var node = stack.Pop();
            //         res.Add(node.val);
            //         if (node.right != null) {
            //             stack.Push(node.right);
            //         }
            //         if (node.left != null) {
            //             stack.Push(node.left);
            //         }
            //     }
            //     return res;
            // }

            public IList<int> PreorderTraversal(TreeNode root) {
                var stack = new Stack<TreeNode>();
                var res = new List<int>();
                while (true) {
                    while (root != null) {
                        res.Add(root.val);
                        stack.Push(root.right);
                        root = root.left;
                    }
                    if (stack.Count == 0) break;
                    root = stack.Pop();
                }
                return res;
            }

            // #94
            public IList<int> InorderTraversal(TreeNode root) {
                var res = new List<int>();
                var stack = new Stack<TreeNode>();
                // root为null并且栈空，结束
                while (true) {
                    while (root != null) {
                        stack.Push(root);
                        root = root.left;
                    }
                    if (stack.Count == 0) break;
                    root = stack.Pop();
                    res.Add(root.val);
                    root = root.right;
                }
                return res;
            }
            // #145
            public IList<int> PostorderTraversal(TreeNode root) {
                var stack = new Stack<TreeNode>();
                var res = new List<int>();
                while (true) {
                    while (root != null) {
                        res.Add(root.val);
                        stack.Push(root.left);
                        root = root.right;
                    }
                    if (stack.Count == 0) break;
                    root = stack.Pop();
                }
                res.Reverse();
                return res;
            }

            // #226
            public TreeNode InvertTree(TreeNode root) {
                if (root == null) return null;

                var left = InvertTree(root.left);
                var right = InvertTree(root.right);

                root.left = right;
                root.right = left;

                return root;
            }

            // #102
            public IList<IList<int>> LevelOrder(TreeNode root) {
                var res = new List<IList<int>>();
                if (root == null) {
                    return res;
                }
                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(root);

                while (queue.Count > 0) {
                    var count = queue.Count;
                    var tmp = new List<int>();
                    for (int i = 0; i < count; i++) {
                        var node = queue.Dequeue();
                        tmp.Add(node.val);
                        if (node.children != null && node.children.Count != 0) {
                            foreach (var child in node.children) {
                                queue.Enqueue(child);
                            }
                        }
                    }
                    res.Add(tmp);
                }
                return res;
            }
            // }

            // 撑杆跳，一次把元素移动到位。
            public void Rotate(int[] nums, int k) {
                k %= nums.Length;
                int step = 0;
                for (int start = 0; start < nums.Length; start++) {
                    int curr = start;
                    // 第一位准备起跳。
                    int prevVal = nums[start];
                    do {
                        int next = (curr + k) % nums.Length;
                        int tmp = nums[next];
                        nums[next] = prevVal;
                        prevVal = tmp; // 下一位准备起跳。
                        curr = next;
                        step++;
                    } while (curr != start);
                }
            }

            public void Rotate_1(int[] nums, int k) {
                k %= nums.Length;
                int[] left = new int[nums.Length - k];
                int[] right = new int[k];
                Array.Copy(nums, 0, left, 0, nums.Length - k);
                Array.Copy(nums, nums.Length - k, right, 0, k);
                // 将数组两部分分别翻转。
                Array.Reverse(left);
                Array.Reverse(right);
                left.CopyTo(nums, 0);
                right.CopyTo(nums, nums.Length - k);
                // 合并后把整个数组翻转。
                Array.Reverse(nums);
            }

            // #26
            public int RemoveDuplicates(int[] nums) {
                int n = nums.Length;
                if (n == 0) return 0;
                int slow = 0, fast = 1;
                while (fast < n) {
                    if (nums[fast] != nums[slow]) {
                        nums[++slow] = nums[fast];
                    }
                    fast++;
                }
                return slow + 1;
            }

            public ListNode DeleteDuplicates(ListNode head) {
                if (head == null) return null;
                ListNode slow = head, fast = head.next;
                while (fast != null) {
                    if (slow.val != fast.val) {
                        // 跳过中间元素，slow直接和fast连起来。
                        slow.next = fast;
                        slow = slow.next;
                    }
                    fast = fast.next;
                }
                // fast断开和后面的连接。
                slow.next = null;
                return head;
            }

            public int[] TwoSum_3(int[] nums, int target) {
                Array.Sort(nums);
                int lo = 0, hi = nums.Length - 1;
                while (lo < hi) {
                    int sum = nums[lo] + nums[hi];
                    if (sum < target) {
                        lo++;
                    } else if (sum > target) {
                        hi--;
                    } else if (sum == target) {
                        return new int[] { nums[lo], nums[hi] };
                    }
                }
                return new int[] { };
            }

            public List<int[]> TwoSumTarget(int[] nums, int target) {
                Array.Sort(nums);
                var res = new List<int[]>();
                int lo = 0, hi = nums.Length - 1;
                while (lo < hi) {
                    int left = nums[lo], right = nums[hi];
                    int sum = nums[lo] + nums[hi];
                    if (sum < target) {
                        while (lo < hi && nums[lo] == left) lo++;
                    } else if (sum > target) {
                        while (lo < hi && nums[hi] == right) hi--;
                    } else if (sum == target) {
                        res.Add(new int[] { left, right });
                        while (lo < hi && nums[lo] == left) lo++;
                        while (lo < hi && nums[hi] == right) hi--;
                    }
                }
                return res;
            }

            // 改进的TwoSumTarget，从指定位置，开始查找后面元素和有没有等于target的。
            public List<List<int>> TwoSumTarget(int[] nums, int start, int target) {
                var res = new List<List<int>>();
                int lo = start, hi = nums.Length - 1;
                while (lo < hi) {
                    int left = nums[lo], right = nums[hi];
                    int sum = nums[lo] + nums[hi];
                    if (sum < target) {
                        while (lo < hi && nums[lo] == left) lo++;
                    } else if (sum > target) {
                        while (lo < hi && nums[hi] == right) hi--;
                    } else if (sum == target) {
                        res.Add(new List<int> { left, right });
                        while (lo < hi && nums[lo] == left) lo++;
                        while (lo < hi && nums[hi] == right) hi--;
                    }
                }
                return res;
            }

            // #15
            public List<List<int>> ThreeSumTarget(int[] nums, int start, int target) {
                Array.Sort(nums);
                int n = nums.Length;
                var res = new List<List<int>>();
                for (int i = start; i < n; i++) {
                    var tuples = TwoSumTarget(nums, i + 1, target - nums[i]);
                    foreach (var tuple in tuples) {
                        tuple.Add(nums[i]);
                        res.Add(tuple);
                    }
                    // 跳过第一个数字重复的情况。
                    while (i < n - 1 && nums[i] == nums[i + 1]) i++;
                }
                return res;
            }

            public List<List<int>> FourSum(int[] nums, int target) {
                Array.Sort(nums);
                int n = nums.Length;
                var res = new List<List<int>>();
                for (int i = 0; i < n; i++) {
                    // 对 target - nums[i] 计算 ThreeSum
                    var triples = ThreeSumTarget(nums, i + 1, target - nums[i]);
                    // 如果存在满足条件的三元组，再加上 nums[i] 就是结果四元组
                    foreach (var triple in triples) {
                        triple.Add(nums[i]);
                        res.Add(triple);
                    }
                    while (i < n - 1 && nums[i] == nums[i + 1]) i++;
                }
                return res;
            }

            // #116
            public TreeNode Connect(TreeNode root) {
                // 将相邻的两个节点连接起来。
                void Helper(TreeNode node1, TreeNode node2) {
                    if (node1 == null || node2 == null) return;
                    node1.next = node2;
                    // 连接相同父节点的两个子节点。
                    Helper(node1.left, node1.right);
                    Helper(node2.left, node2.right);
                    // 连接跨父节点的两个子节点。
                    Helper(node1.right, node2.left);
                }
                if (root == null) return null;
                Helper(root.left, root.right);
                return root;
            }

            // #117
            public TreeNode Connect_1(TreeNode root) {
                if (root == null) return null;
                var queue = new Queue<TreeNode>();
                queue.Enqueue(root);
                while (queue.Count != 0) {
                    int n = queue.Count;
                    TreeNode dummy = null;
                    for (int i = 0; i < n; i++) {
                        var node = queue.Dequeue();
                        if (node.left != null) {
                            queue.Enqueue(node.left);
                        }
                        if (node.right != null) {
                            queue.Enqueue(node.right);
                        }
                        if (i != 0) {
                            dummy.next = node;
                        }
                        dummy = node;
                    }
                }
                return root;
            }

            // #114
            public void Flatten(TreeNode root) {
                if (root == null) return;
                // 把左右子树都拉直了。
                Flatten(root.left);
                Flatten(root.right);

                var left = root.left;
                var right = root.right;
                // 左子树接在右子树的位置，左子树置空。
                root.left = null;
                root.right = left;

                var p = root;
                // 移动到右子树的末尾。
                while (p.right != null) {
                    p = p.right;
                }
                // 把右子树接在末尾。
                p.right = right;
            }

            // #654
            public TreeNode ConstructMaximumBinaryTree(int[] nums) {
                TreeNode Helper(int[] nums, int lo, int hi) {
                    // 递归base。
                    if (lo > hi) return null;

                    int index = -1, maxVal = int.MinValue;
                    for (int i = lo; i <= hi; i++) {
                        if (maxVal < nums[i]) {
                            maxVal = nums[i];
                            index = i;
                        }
                    }

                    // 递归构造左右子树。
                    TreeNode root = new TreeNode(maxVal);
                    root.left = Helper(nums, lo, index - 1);
                    root.right = Helper(nums, index + 1, hi);

                    return root;
                }

                return Helper(nums, 0, nums.Length - 1);
            }

            // #105
            public TreeNode BuildTree(int[] preorder, int[] inorder) {
                TreeNode Helper(int preStart, int preEnd, int inStart, int inEnd) {
                    if (preStart > preEnd) {
                        return null;
                    }
                    // root 节点对应的值就是前序遍历数组的第一个元素
                    int rootVal = preorder[preStart];
                    // rootVal 在中序遍历数组中的索引
                    int index = 0;
                    for (int i = inStart; i <= inEnd; i++) {
                        if (inorder[i] == rootVal) {
                            index = i;
                            break;
                        }
                    }

                    int leftSize = index - inStart;

                    // 先构造出当前根节点
                    TreeNode root = new TreeNode(rootVal);
                    // 递归构造左右子树
                    root.left = Helper(preStart + 1, preStart + leftSize,
                         inStart, index - 1);

                    root.right = Helper(preStart + leftSize + 1, preEnd,
                         index + 1, inEnd);
                    return root;
                }
                return Helper(0, preorder.Length - 1, 0, inorder.Length - 1);
            }

            public TreeNode BuildTree_1(int[] inorder, int[] postorder) {
                TreeNode build(int[] inorder, int inStart, int inEnd, int[] postorder, int postStart, int postEnd) {
                    if (inStart > inEnd) {
                        return null;
                    }
                    // root 节点对应的值就是后序遍历数组的最后一个元素
                    int rootVal = postorder[postEnd];
                    // rootVal 在中序遍历数组中的索引
                    int index = 0;
                    for (int i = inStart; i <= inEnd; i++) {
                        if (inorder[i] == rootVal) {
                            index = i;
                            break;
                        }
                    }
                    // 左子树的节点个数
                    int leftSize = index - inStart;
                    TreeNode root = new TreeNode(rootVal);
                    // 递归构造左右子树
                    root.left = build(inorder, inStart, index - 1,
                        postorder, postStart, postStart + leftSize - 1);

                    root.right = build(inorder, index + 1, inEnd,
                        postorder, postStart + leftSize, postEnd - 1);
                    return root;
                }
                return build(inorder, 0, inorder.Length - 1,
                    postorder, 0, postorder.Length - 1);
            }

            // #508
            public int[] FindFrequentTreeSum(TreeNode root) {
                var map = new Dictionary<int, int>();
                int max = 0;
                int Helper(TreeNode root) {
                    if (root == null) return 0;
                    int left = Helper(root.left);
                    int right = Helper(root.right);
                    int sum = root.val + left + right;
                    if (!map.ContainsKey(sum)) {
                        map.Add(sum, 0);
                    } else {
                        map[sum] += 1;
                    }
                    max = Math.Max(max, map[sum]);
                    return sum;
                }

                if (root == null) return new int[] { };

                Helper(root);

                var tmp = new List<int>();
                foreach (var key in map.Keys) {
                    if (map[key] == max) {
                        tmp.Add(key);
                    }
                }
                return tmp.ToArray();
            }

            class Difference {
                public int[] diff;
                public Difference(int[] nums) {
                    diff = new int[nums.Length];
                    diff[0] = nums[0];
                    for (int i = 1; i < nums.Length; i++) {
                        diff[i] = nums[i] - nums[i - 1];
                    }
                }

                public void Increment(int i, int j, int val) {
                    diff[i] += val;
                    if (j + 1 < diff.Length) {
                        diff[j + 1] -= val;
                    }
                }

                public int[] Result() {
                    int[] res = new int[diff.Length];
                    res[0] = diff[0];
                    for (int i = 1; i < diff.Length; i++) {
                        res[i] = res[i - 1] + diff[i];
                    }
                    return res;
                }
            }

            public int[] CorpFlightBookings(int[][] bookings, int n) {
                int[] nums = new int[n];
                var df = new Difference(nums);
                foreach (var booking in bookings) {
                    int i = booking[0] - 1;
                    int j = booking[1] - 1;
                    int val = booking[2];
                    df.Increment(i, j, val);
                }
                return df.Result();
            }

            public string RemoveDuplicateLetters(string s) {
                var stack = new Stack<char>();
                var count = new int[256];
                for (int i = 0; i < s.Length; i++) {
                    count[s[i]]++;
                }
                var inStack = new bool[256];
                foreach (var c in s) {
                    count[c]--;
                    // 如果c已经出现过，那么跳过，进行下一个。
                    if (inStack[c]) continue;
                    // 如果栈顶元素比c大，要考虑将c移到前面。
                    while (stack.Count != 0 && stack.Peek() > c) {
                        // 但只有当栈顶元素个数不为0的时候才能移。
                        if (count[stack.Peek()] == 0) {
                            break;
                        }
                        inStack[stack.Pop()] = false;
                    }
                    // 找到c的正确位置，将c入栈，并标记c为已存在。
                    stack.Push(c);
                    inStack[c] = true;
                }
                return new string(stack.ToArray().Reverse().ToArray());
            }

            // #75
            public void SortColors(int[] nums) {
                int p0 = 0, curr = 0;
                int p2 = nums.Length - 1;
                while (curr <= p2) {
                    if (nums[curr] == 0) {
                        int tmp = nums[curr];
                        nums[curr] = nums[p0];
                        nums[p0] = tmp;

                        p0++;
                        curr++;
                    } else if (nums[curr] == 1) {
                        curr++;
                    } else if (nums[curr] == 2) {
                        int tmp = nums[curr];
                        nums[curr] = nums[p2];
                        nums[p2] = tmp;

                        p2--;
                    }
                }
            }

            // #344
            public void ReverseString(char[] s) {
                if (s.Length == 0) return;
                int start = 0, end = s.Length - 1;
                while (end > start) {
                    var tmp = s[end];
                    s[end] = s[start];
                    s[start] = tmp;
                    start++;
                    end--;
                }
            }

            public TreeNode PruneTree(TreeNode root) {
                bool ContainsOne(TreeNode node) {
                    if (node == null) return false;
                    bool left = ContainsOne(node.left);
                    bool right = ContainsOne(node.right);
                    if (!left) node.left = null;
                    if (!right) node.right = null;
                    return node.val == 1 || left || right;
                }
                return ContainsOne(root) ? root : null;
            }

            public bool HasCycle(ListNode head) {
                if (head == null || head.next == null) return false;

                var slow = head;
                var fast = head.next;

                while (slow != fast) {
                    if (fast == null || fast.next == null) return false;
                    slow = slow.next;
                    fast = fast.next.next;
                }
                return true;
            }

            class AnnotatedNode {
                public TreeNode node;
                public int depth, pos;
                public AnnotatedNode(TreeNode n, int d, int p) {
                    node = n;
                    depth = d;
                    pos = p;
                }
            }

            public int WidthOfBinaryTree(TreeNode root) {
                var queue = new Queue<AnnotatedNode>();
                queue.Enqueue(new AnnotatedNode(root, 0, 0));
                int currDepth = 0, left = 0, ans = 0;
                while (queue.Count != 0) {
                    var tmp = queue.Dequeue();
                    if (tmp.node != null) {
                        queue.Enqueue(new AnnotatedNode(tmp.node.left, tmp.depth + 1, tmp.pos * 2));
                        queue.Enqueue(new AnnotatedNode(tmp.node.right, tmp.depth + 1, tmp.pos * 2 + 1));
                        // 每一个深度的第一个节点是这一层的最左边节点
                        if (currDepth != tmp.depth) {
                            currDepth = tmp.depth;
                            left = tmp.pos;
                        }
                        ans = Math.Max(ans, tmp.pos - left + 1);
                    }
                }
                return ans;
            }

            public int GetMinimumDifference(TreeNode root) {
                int pre;
                int ans;

                void DFS(TreeNode root) {
                    if (root == null) {
                        return;
                    }
                    DFS(root.left);
                    if (pre == -1) {
                        pre = root.val;
                    } else {
                        ans = Math.Min(ans, root.val - pre);
                        pre = root.val;
                    }
                    DFS(root.right);
                }

                ans = int.MaxValue;
                pre = -1;
                DFS(root);
                return ans;
            }

            // #103
            public List<List<int>> ZigzagLevelOrder(TreeNode root) {
                var res = new List<List<int>>();
                if (root == null) return res;

                var queue = new Queue<TreeNode>();
                queue.Enqueue(root);
                int depth = 1;

                while (queue.Count != 0) {
                    int count = queue.Count;
                    var tmp = new List<int>();
                    for (int i = 0; i < count; i++) {
                        var node = queue.Dequeue();
                        if (depth % 2 == 0) {
                            tmp.Insert(0, node.val);

                        } else {
                            tmp.Add(node.val);
                        }
                        if (node.left != null) {
                            queue.Enqueue(node.left);
                        }
                        if (node.right != null) {
                            queue.Enqueue(node.right);
                        }
                    }
                    depth++;
                    res.Add(tmp);
                }
                return res;
            }

            // #98
            public bool IsValidBST(TreeNode root) {
                //rot为当前节点值，low为子树下限，up为上限
                bool Helper(TreeNode node, int low, int up) {
                    if (node == null) {
                        return true;
                    }
                    //当前为左子树时，无下限，上限为根节点
                    if (!Helper(node.left, low, node.val))
                        return false;
                    //当前为右子树时，无上限，下限为根节点
                    if (!Helper(node.right, node.val, up))
                        return false;

                    if (low != -1 && node.val <= low)
                        return false;
                    if (up != -1 && node.val >= up)
                        return false;

                    return true;
                }
                return Helper(root, -1, -1);
            }

            public bool IsValidBST_2(TreeNode root) {
                var stack = new Stack<TreeNode>();
                var pre = int.MinValue;
                while (true) {
                    while (root != null) {
                        stack.Push(root);
                        root = root.left;
                    }
                    if (stack.Count == 0) break;
                    root = stack.Pop();
                    if (root.val > pre) return false;
                    pre = root.val;
                    root = root.right;
                }
                return true;
            }

            // #25
            public ListNode ReverseKGroup(ListNode head, int k) {
                ListNode Reverse(ListNode a, ListNode b) {
                    ListNode pre, cur, nxt;
                    pre = null;
                    cur = a;
                    nxt = a;
                    while (cur != b) {
                        nxt = cur.next;
                        cur.next = pre;
                        pre = cur;
                        cur = nxt;
                    }
                    return pre;
                }

                if (head == null) return null;

                ListNode a, b;
                a = b = head;
                for (int i = 0; i < k; i++) {
                    if (b == null) return head;
                    b = b.next;
                }
                var newHead = Reverse(a, b);
                a.next = ReverseKGroup(b, k);
                return newHead;
            }

            public List<string> CommonChars(string[] A) {
                var minFreq = new int[26];
                Array.Fill(minFreq, int.MaxValue);

                foreach (var str in A) {
                    var freq = new int[26];
                    foreach (var ch in str) {
                        freq[ch - 'a']++;
                    }
                    for (int i = 0; i < 26; i++) {
                        minFreq[i] = Math.Min(freq[i], minFreq[i]);
                    }
                }

                var ans = new List<string>();
                for (int i = 0; i < 26; i++) {
                    for (int j = 0; j < minFreq[i]; j++) {
                        ans.Add(((char)('a' + i)).ToString());
                    }
                }
                return ans;
            }

            // #129
            public int SumNumbers(TreeNode root) {
                int Helper(TreeNode root, int curr) {
                    if (root == null) return 0;
                    curr = curr * 10 + root.val;

                    if (root.left == null && root.right == null) {
                        return curr;
                    }
                    return Helper(root.left, curr) + Helper(root.right, curr);
                }
                return Helper(root, 0);
            }

            // #173
            public class BSTIterator {
                Stack<TreeNode> stack;

                public BSTIterator(TreeNode root) {
                    stack = new Stack<TreeNode>();
                    _inorder(root);
                }

                public void _inorder(TreeNode root) {
                    while (root != null) {
                        stack.Push(root);
                        root = root.left;
                    }
                }

                public int Next() {
                    var node = stack.Pop();
                    if (node.right != null) {
                        _inorder(node.right);
                    }
                    return node.val;
                }

                public bool HasNext() {
                    return stack.Count > 0;
                }
            }

            public int KthSmallest(TreeNode root, int k) {
                var stack = new Stack<TreeNode>();

                while (true) {
                    while (root != null) {
                        stack.Push(root);
                        root = root.left;
                    }
                    root = stack.Pop();
                    if (--k == 0) return root.val;
                    root = root.right;
                }
            }

            public int[] SortedSquares(int[] A) {
                int n = A.Length;
                int[] ans = new int[n];
                // 因为原数组升序排列，但存在负数，平方运算后，负数部分为降序排列。
                // 双指针从两端向中间移动，每次确定结果比较大的元素的位置。
                for (int i = 0, j = n - 1, pos = n - 1; i <= j;) {
                    if (A[i] * A[i] > A[j] * A[j]) {
                        ans[pos] = A[i] * A[i];
                        ++i;
                    } else {
                        ans[pos] = A[j] * A[j];
                        --j;
                    }
                    --pos;
                }
                return ans;
            }

            // #52
            public List<List<string>> TotalNQueens(int n) {
                var res = new List<List<string>>();
                var board = new char[n][];
                for (int i = 0; i < n; i++) {
                    var tmp = new char[n];
                    Array.Fill(tmp, '.');
                    board[i] = tmp;
                }
                bool IsValid(int row, int col) {
                    int n = board.GetLength(0);
                    // 判断列上是否有皇后
                    for (int i = 0; i < n; i++) {
                        if (board[i][col] == 'Q') return false;
                    }
                    // 检查右上方是否有皇后互相冲突
                    for (int i = row - 1, j = col + 1; i >= 0 && j < n; i--, j++) {
                        if (board[i][j] == 'Q') return false;
                    }
                    // 检查左上方是否有皇后互相冲突
                    for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--) {
                        if (board[i][j] == 'Q') return false;
                    }
                    return true;
                }
                void Backtrack(int row) {
                    if (row == board.GetLength(0)) {
                        res.Add(board.Select(item => String.Join("", item)).ToList());
                        return;
                    }
                    int cols = board.GetLength(0);
                    for (int col = 0; col < cols; col++) {
                        if (!IsValid(row, col)) {
                            continue;
                        }
                        board[row][col] = 'Q';
                        Backtrack(row + 1);
                        board[row][col] = '.';
                    }
                }


                Backtrack(0);

                return res;
            }

            public bool BackspaceCompare(string S, string T) {
                var stack1 = new Stack<char>();
                var stack2 = new Stack<char>();
                foreach (var ch in S) {
                    if (ch != '#') {
                        stack1.Push(ch);
                    }
                    if (ch == '#' && stack1.Count != 0) {
                        stack1.Pop();
                    }
                }
                foreach (var ch in T) {
                    if (ch != '#') {
                        stack2.Push(ch);
                    }
                    if (ch == '#' && stack2.Count != 0) {
                        stack2.Pop();
                    }
                }
                return String.Join("", stack1.ToArray()) == String.Join("", stack2.ToArray());
            }

            public void ReorderList(ListNode head) {
                if (head == null) return;
                var list = new List<ListNode>();
                var node = head;
                while (node != null) {
                    list.Add(node);
                    node = node.next;
                }
                int i = 0, j = list.Count - 1;
                while (i < j) {
                    list[i].next = list[j];
                    ++i;
                    if (i == j) break;
                    list[j].next = list[i];
                    --j;
                }
                list[i].next = null;
            }

            public bool IsLongPressedName(string name, string typed) {
                int i = 0, j = 0;
                while (j < typed.Length) {
                    if (i < name.Length && name[i] == typed[j]) {
                        i++;
                        j++;
                    } else if (j > 0 && typed[j] == typed[j - 1]) {
                        j++;
                    } else {
                        // 除了上面两种情况外，指针不会移动，判定失败
                        return false;
                    }
                }
                return i == name.Length;
            }

            public List<int> PartitionLabels(string S) {
                int[] last = new int[26];
                int length = S.Length;
                for (int i = 0; i < length; i++) {
                    last[S[i] - 'a'] = i;
                }
                var partition = new List<int>();
                int start = 0, end = 0;
                for (int i = 0; i < length; i++) {
                    end = Math.Max(end, last[S[i] - 'a']);
                    if (i == end) {
                        partition.Add(end - start + 1);
                        start = end + 1;
                    }
                }
                return partition;
            }

            // #77
            public List<List<int>> Combine(int n, int k) {
                var res = new List<List<int>>();
                var path = new List<int>();
                void Helper(int begin) {
                    if (path.Count == k) {
                        res.Add(path.ToList());
                        return;
                    }

                    for (int i = begin; i <= n; i++) {
                        path.Add(i);
                        Helper(i + 1);
                        path.RemoveAt(path.Count - 1);
                    }
                }
                if (k <= 0 || n < k) {
                    return res;
                }
                Helper(1);
                return res;
            }

            // #491
            public List<List<int>> FindSubsequences(int[] nums) {
                // 回溯法
                var res = new List<List<int>>();
                var path = new List<int>();
                void Helper(int cur, int last) {
                    if (cur == nums.Length) {
                        if (path.Count >= 2) {
                            res.Add(path);
                        }
                        return;
                    }

                    if (nums[cur] >= last) {
                        path.Add(nums[cur]);
                        Helper(cur + 1, nums[cur]);
                        path.RemoveAt(path.Count - 1);
                    }
                    if (nums[cur] != last) {
                        Helper(cur + 1, last);
                    }
                }

                Helper(0, int.MinValue);
                return res;
            }

            public int VideoStitching(int[][] clips, int T) {
                var maxN = new int[T];
                int last = 0, ret = 0, pre = 0;
                // 记录从clip[0]位置开始能到到的最远位置
                foreach (var clip in clips) {
                    if (clip[0] < T) {
                        maxN[clip[0]] = Math.Max(maxN[clip[0]], clip[1]);
                    }
                }
                for (int i = 0; i < T; i++) {
                    last = Math.Max(last, maxN[i]);
                    if (i == last) {
                        return -1;
                    }
                    if (i == pre) {
                        ret++;
                        pre = last;
                    }
                }
                return ret;
            }

            public int LongestMountain(int[] A) {
                int n = A.Length;
                if (n == 0) {
                    return 0;
                }
                int[] left = new int[n];
                for (int i = 1; i < n; ++i) {
                    left[i] = A[i - 1] < A[i] ? left[i - 1] + 1 : 0;
                }
                int[] right = new int[n];
                for (int i = n - 2; i >= 0; --i) {
                    right[i] = A[i + 1] < A[i] ? right[i + 1] + 1 : 0;
                }

                int ans = 0;
                for (int i = 0; i < n; ++i) {
                    if (left[i] > 0 && right[i] > 0) {
                        ans = Math.Max(ans, left[i] + right[i] + 1);
                    }
                }
                return ans;
            }

            public int[] SmallerNumbersThanCurrent(int[] nums) {
                // 索引排序，用下标完成排序
                int[] cnt = new int[101];
                int n = nums.Length;
                for (int i = 0; i < n; i++) {
                    cnt[nums[i]]++;
                }
                for (int i = 1; i <= 100; i++) {
                    cnt[i] += cnt[i - 1];
                }
                int[] ret = new int[n];
                for (int i = 0; i < n; i++) {
                    ret[i] = nums[i] == 0 ? 0 : cnt[nums[i] - 1];
                }
                return ret;
            }

            // #17
            public List<string> LetterCombinations(string digits) {
                var numCharMap = new Dictionary<char, char[]>() { { '2', new char[] { 'a', 'b', 'c' } }, { '3', new char[] { 'd', 'e', 'f' } }, { '4', new char[] { 'g', 'h', 'i' } }, { '5', new char[] { 'j', 'k', 'l' } }, { '6', new char[] { 'm', 'n', 'o' } }, { '7', new char[] { 'p', 'q', 'r', 's' } }, { '8', new char[] { 't', 'u', 'v' } }, { '9', new char[] { 'w', 'x', 'y', 'z' } },
                    };

                var path = new List<char>();
                var res = new List<string>();

                void Helper(int curr) {
                    if (path.Count == digits.Length) {
                        res.Add(string.Join("", path));
                        return;
                    }
                    foreach (var ch in numCharMap[digits[curr]]) {
                        path.Add(ch);
                        Helper(curr + 1);
                        path.RemoveAt(path.Count - 1);
                    }
                }

                if (digits.Length == 0) {
                    return res;
                }
                Helper(0);
                return res;
            }

            // #22
            public List<string> GenerateParenthesis(int n) {
                var res = new List<string>();
                var path = new List<char>();
                void Helper(int close, int open, int max) {
                    if (path.Count == max * 2) {
                        res.Add(string.Join("", path));
                        return;
                    }
                    if (open < max) {
                        path.Add('(');
                        Helper(close, open + 1, max);
                        path.RemoveAt(path.Count - 1);
                    }
                    if (close < open) {
                        path.Add(')');
                        Helper(close + 1, open, max);
                        path.RemoveAt(path.Count - 1);
                    }
                }
                Helper(0, 0, n);
                return res;
            }

            // #39
            public List<List<int>> CombinationSum(int[] candidates, int target) {
                // candidates中无重复元素，但每个元素可用无限次
                var path = new List<int>();
                var res = new List<List<int>>();

                void Helper(int begin, int sum) {
                    // 搜索结束条件，如果path中元素之和==target，说明path是一个有效答案
                    if (sum == target) {
                        res.Add(path.ToList());
                        return;
                    }
                    // begin用来指示本次回溯的选择起点，去重的关键
                    for (int i = begin; i < candidates.Length; i++) {
                        // 剪枝处理，减少不必要的回溯
                        if ((sum + candidates[i]) <= target) {
                            // 选择
                            path.Add(candidates[i]);
                            // 递归调用回溯。因为candidates中元素可以无限次使用，因此在下一次选择时，依旧可以从当前元素开始
                            Helper(i, sum + candidates[i]);
                            // 撤销选择
                            path.RemoveAt(path.Count - 1);
                        } else {
                            break;
                        }
                    }
                }
                if (candidates.Length == 0) {
                    return res;
                }
                Helper(0, 0);
                return res;
            }

            // #78
            public List<List<int>> Subsets(int[] nums) {
                var path = new List<int>();
                var res = new List<List<int>>();

                void Helper(int begin) {
                    // 搜索结束条件，任意一个路径都是一个子集
                    res.Add(path.ToList());
                    for (int i = begin; i < nums.Length; i++) {
                        // 选择
                        path.Add(nums[i]);
                        // 递归调用回溯，新的选择列表为当前元素位置之后的所有元素，所以在下一次选择时，从当前元素的下一个开始
                        Helper(i + 1);
                        // 撤销选择
                        path.RemoveAt(path.Count - 1);
                    }
                }

                if (nums.Length == 0) {
                    return res;
                }
                Helper(0);
                return res;
            }

            public bool UniqueOccurrences(int[] arr) {
                var numFreqMap = new Dictionary<int, int>();
                foreach (var num in arr) {
                    if (numFreqMap.ContainsKey(num)) {
                        numFreqMap[num] += 1;
                    } else {
                        numFreqMap.Add(num, 1);
                    }
                }
                var values = numFreqMap.Values.ToList();
                var res = values[0];
                for (int i = 1; i < values.Count; i++) {
                    res ^= values[i];
                }
                return res == 0;
            }

            // #1079
            public int NumTilePossibilities(string tiles) {
                var res = new List<List<int>>();
                var path = new List<int>();
                bool[] vis = new bool[tiles.Length];

                void Helper(int curr) {
                    res.Add(path.ToList());
                    for (int i = 0; i < tiles.Length; ++i) {
                        if (vis[i] || (i > 0 && tiles[i] == tiles[i - 1] && !vis[i - 1])) {
                            continue;
                        }
                        path.Add(tiles[i]);
                        vis[i] = true;
                        Helper(curr + 1);
                        vis[i] = false;
                        path.RemoveAt(path.Count - 1);
                    }
                }
                var tmp = tiles.ToCharArray();
                Array.Sort(tmp);
                tiles = string.Join("", tmp);
                Helper(0);
                return res.Count - 1;
            }

            // #47
            public List<List<int>> PermuteUnique(int[] nums) {
                var res = new List<List<int>>();
                var path = new List<int>();
                bool[] vis = new bool[nums.Length];

                void Helper(int curr) {
                    if (curr == nums.Length) {
                        res.Add(path.ToList());
                        return;
                    }
                    for (int i = 0; i < nums.Length; ++i) {
                        // 如果当前元素已访问，或者当前元素未访问，但当前元素和前一个元素相等，并且前一个元素访问过
                        // 要保证在所有的递归中，每个元素只被访问一次
                        if (vis[i] || (i > 0 && nums[i] == nums[i - 1] && !vis[i - 1])) {
                            continue;
                        }
                        path.Add(nums[i]);
                        vis[i] = true;
                        Helper(curr + 1);
                        vis[i] = false;
                        path.RemoveAt(path.Count - 1);
                    }
                }
                Array.Sort(nums);
                Helper(0);
                return res;
            }

            // #216
            public List<List<int>> CombinationSum3(int k, int n) {
                // 只有1-9，每个元素只能使用一次
                var path = new List<int>();
                var res = new List<List<int>>();
                var nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                void Helper(int curr, int sum, int len) {
                    if (sum == n && len == k) {
                        res.Add(path.ToList());
                        return;
                    }
                    for (int i = curr; i < nums.Length; i++) {
                        path.Add(nums[i]);
                        Helper(i + 1, sum + nums[i], len + 1);
                        path.RemoveAt(path.Count - 1);
                    }
                }

                Helper(0, 0, 0);
                return res;
            }

            // #40
            public List<List<int>> CombinationSum2(int[] candidates, int target) {
                // candidates中有重复元素，每个只能用一次
                // 排序+标记
                var path = new List<int>();
                var res = new List<List<int>>();
                var vis = new bool[candidates.Length];

                void Helper(int curr, int sum) {
                    if (sum == target) {
                        res.Add(path.ToList());
                        return;
                    } else if (sum < target) {
                        for (int i = curr; i < candidates.Length; i++) {
                            if (vis[i] || (i > 0 && candidates[i] == candidates[i - 1] && !vis[i - 1])) {
                                continue;
                            }
                            path.Add(candidates[i]);
                            vis[i] = true;
                            Helper(i + 1, sum + candidates[i]);
                            vis[i] = false;
                            path.RemoveAt(path.Count - 1);
                        }
                    }
                }

                Array.Sort(candidates);
                Helper(0, 0);
                return res;
            }

            public int IslandPerimeter(int[][] grid) {
                // 搜索上下左右的常用技巧
                int[] dx = { 0, 1, 0, -1 };
                int[] dy = { 1, 0, -1, 0 };

                int n = grid.Length, m = grid[0].Length;
                int ans = 0;
                for (int i = 0; i < n; ++i) {
                    for (int j = 0; j < m; ++j) {
                        if (grid[i][j] == 1) {
                            int cnt = 0;
                            // 统计每一个格子的边
                            for (int k = 0; k < 4; ++k) {
                                int tx = i + dx[k];
                                int ty = j + dy[k];
                                if (tx < 0 || tx >= n || ty < 0 || ty >= m || grid[tx][ty] == 0) {
                                    cnt += 1;
                                }
                            }
                            ans += cnt;
                        }
                    }
                }
                return ans;
            }

            // #79
            public bool Exist(char[][] board, string word) {
                int h = board.Length;
                int w = board[0].Length;
                var directions = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
                bool[,] vis = new bool[h, w];

                bool Helper(int i, int j, int idx) {
                    if (board[i][j] != word[idx]) {
                        return false;
                    } else if (idx == word.Length - 1) {
                        return true;
                    }
                    // 回溯的选择
                    vis[i, j] = true;
                    bool res = false;
                    foreach (var direction in directions) {
                        int tx = i + direction[0], ty = j + direction[1];
                        if (tx >= 0 && tx < h && ty >= 0 && ty < w) {
                            if (!vis[tx, ty]) {
                                bool flag = Helper(tx, ty, idx + 1);
                                // 剪枝，找到一个即可返回
                                if (flag) {
                                    res = true;
                                    break;
                                }
                            }
                        }
                    }
                    vis[i, j] = false;
                    return res;
                }

                for (int i = 0; i < h; i++) {
                    for (int j = 0; j < w; j++) {
                        bool flag = Helper(i, j, 0);
                        if (flag) {
                            return true;
                        }
                    }
                }
                return false;
            }

            // #90
            public List<List<int>> SubsetsWithDup(int[] nums) {
                var path = new List<int>();
                var res = new List<List<int>>();

                void Helper(int curr) {
                    res.Add(path.ToList());
                    for (int i = curr; i < nums.Length; i++) {
                        if (i > curr && nums[i] == nums[i - 1]) {
                            continue;
                        }

                        path.Add(nums[i]);
                        Helper(i + 1);
                        path.RemoveAt(path.Count - 1);
                    }
                }

                Array.Sort(nums);
                Helper(0);
                return res;
            }

            // #130
            public void Solve(char[][] board) {
                int rows = board.Length;
                if (rows == 0) return;
                int cols = board[0].Length;

                void Helper(int x, int y) {
                    if (x >= 0 && x <= rows - 1 && y >= 0 && y <= cols - 1 && board[x][y] == 'O') {
                        board[x][y] = '#';
                        // 深度遍历上下左右
                        Helper(x - 1, y);
                        Helper(x + 1, y);
                        Helper(x, y - 1);
                        Helper(x, y + 1);
                    } else {
                        return;
                    }
                }
                // 先把四周的点及跟他们相连的换成特殊字符。
                // 第一行
                for (int j = 0; j < cols; j++) {
                    Helper(0, j);
                }
                // 最后一行
                for (int j = 0; j < cols; j++) {
                    Helper(rows - 1, j);
                }
                // 第一列
                for (int i = 0; i < rows; i++) {
                    Helper(i, 0);
                }
                // 最后一列
                for (int i = 0; i < rows; i++) {
                    Helper(i, cols - 1);
                }
                for (int i = 0; i < rows; i++) {
                    for (int j = 0; j < cols; j++) {
                        if (board[i][j] == 'O') {
                            board[i][j] = 'X';
                        }
                        if (board[i][j] == '#') {
                            board[i][j] = 'O';
                        }
                    }
                }
            }

            public int Size(ListNode head) {
                int len = 0;
                while (head != null) {
                    len++;
                    head = head.next;
                }
                return len;
            }

            public int Size_1(ListNode head) {
                if (head == null) return 0;
                return Size_1(head.next) + 1;
            }

            public ListNode Reverse(ListNode head) {
                if (head == null) return null;
                ListNode curr = head, prev = null;
                while (curr != null) {
                    var next = curr.next;
                    // 开始更改当前节点的next指向。
                    curr.next = prev;
                    // 移动到下个节点。
                    prev = curr;
                    curr = next;
                }
                return prev;
            }

            public ListNode Reverse_1(ListNode head) {
                // 存疑，递归结束条件应该是head != null and head.next == null。
                if (head == null || head.next == null) return head;
                // 把next到最后的链表翻转了。
                ListNode newHead = Reverse_1(head.next);
                // 此时head的next是newHead链表的最后一个节点，需要让该节点的next指向head。
                head.next.next = head;
                // head指向null，标志链表结束。
                head.next = null;
                return newHead;
            }

            public ListNode Merge(ListNode head1, ListNode head2) {
                if (head1 == null || head2 == null) return head1 == null ? head2 : head1;
                if (head1.val > head2.val) {
                    head2.next = Merge(head1, head2.next);
                    return head2;
                } else {
                    head1.next = Merge(head1.next, head2);
                    return head1;
                }
            }

            public ListNode Merge_1(ListNode head1, ListNode head2) {
                if (head1 == null || head2 == null) return head1 == null ? head2 : head1;
                var dummy = new ListNode(0);
                while (head1 != null && head2 != null) {
                    if (head1.val > head2.val) {
                        dummy.next = head2;
                        head2 = head2.next;
                    } else {
                        dummy.next = head1;
                        head1 = head1.next;
                    }
                    dummy = dummy.next;
                }
                dummy.next = head1 == null ? head2 : head1;
                return dummy.next;
            }

            // #20
            public bool IsValid(string str) {
                var dict = new Dictionary<char, char>() { { ')', '(' }, { ']', '[' }, { '}', '{' } };
                var left = new Stack<char>();
                foreach (var c in str) {
                    if (c == '(' || c == '{' || c == '[') {
                        left.Push(c);
                    } else {
                        // 字符是右括号，要开始和栈顶的左括号匹配。匹配成功，栈顶元素弹出，否则是非法的括号组合
                        if (left.Count != 0 && dict[c] == left.Peek()) {
                            left.Pop();
                        } else {
                            return false;
                        }
                    }
                }
                // 如果全部匹配完栈中仍有剩余符号，说明是非法的括号组合。
                return left.Count == 0;
            }

            public int MinAddToMakeValid(string s) {
                int res = 0;
                int need = 0;
                foreach (var c in s) {
                    if (c == '(') {
                        // 右括号的需求+1。
                        need++;
                    }
                    if (c == ')') {
                        // 右括号需求-1。
                        need--;
                        if (need == -1) {
                            // 左括号不够了
                            res++;
                            need = 0;
                        }
                    }
                }
                // res是插入左括号个数，need是需要的右括号个数，如果need不为0，则还需要插入need个左括号。
                return res + need;
            }

            public int MinInsertions(string s) {
                int res = 0, need = 0;
                foreach (var c in s) {
                    if (c == '(') {
                        need += 2;
                        if (need % 2 == 1) {
                            res++;
                            need--;
                        }
                    }

                    if (c == ')') {
                        need--;
                        if (need == -1) {
                            res++;
                            need = 1;
                        }
                    }
                }
                return res + need;
            }

            // #62
            public int UniquePaths(int m, int n) {
                var dp = new int[m, n];
                for (int i = 0; i < m; i++) {
                    dp[i, 0] = 1;
                }
                for (int j = 1; j < n; j++) {
                    dp[0, j] = 1;
                }
                for (int i = 1; i < m; i++) {
                    for (int j = 1; j < n; j++) {
                        dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                    }
                }
                return dp[m - 1, n - 1];
            }

            public int UniquePathsWithObstacles(int[][] obstacleGrid) {
                int m = obstacleGrid.Length;
                int n = obstacleGrid[0].Length;
                var dp = new int[m, n];
                for (int i = 0; i < m; ++i) {
                    // 如果在第一列遇到障碍，那下面的都无法到达，break即可
                    if (obstacleGrid[i][0] == 1) break;
                    dp[i, 0] = 1;
                }

                for (int i = 0; i < n; ++i) {
                    if (obstacleGrid[0][i] == 1) break;
                    dp[0, i] = 1;
                }

                for (int i = 1; i < m; i++) {
                    for (int j = 1; j < n; j++) {
                        if (obstacleGrid[i][j] == 1) {
                            dp[i, j] = 0;
                            continue;
                        } else {
                            dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                        }
                    }
                }
                return dp[m - 1, n - 1];
            }
            public int MinPathSum(int[][] grid) {
                if (grid == null || grid.Length == 0 || grid[0].Length == 0) {
                    return 0;
                }
                int m = grid.Length;
                int n = grid[0].Length;
                var dp = new int[m, n];
                dp[0, 0] = grid[0][0];
                for (int i = 1; i < m; i++) {
                    dp[i, 0] = dp[i - 1, 0] + grid[i][0];
                }
                for (int i = 1; i < n; i++) {
                    dp[0, i] = dp[0, i - 1] + grid[0][i];
                }
                for (int i = 1; i < m; i++) {
                    for (int j = 1; j < n; j++) {
                        dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + grid[i][j];
                    }
                }
                return dp[m - 1, n - 1];
            }

            public int[] Intersection(int[] nums1, int[] nums2) {
                Array.Sort(nums1);
                Array.Sort(nums2);
                if (nums1.Length == 0 || nums1.Length == 0) {
                    return new int[] { };
                }

                int idx1 = 0, idx2 = 0;
                var res = new List<int>();
                while (idx1 < nums1.Length && idx2 < nums2.Length) {
                    int num1 = nums1[idx1], num2 = nums2[idx2];
                    if (num1 == num2) {
                        if (res.Count == 0 || res.Last() != num1) {
                            res.Add(num1);
                        }
                        idx1++;
                        idx2++;
                    } else if (num1 < num2) {
                        idx1++;
                    } else {
                        idx2++;
                    }
                }
                return res.ToArray();
            }

            public int MinimumTotal(List<List<int>> triangle) {
                if (triangle.Count == 0) {
                    return 0;
                }
                int n = triangle.Count;
                var dp = new int[n, n];
                // base
                dp[0, 0] = triangle[0][0];
                for (int i = 1; i < n; i++) {
                    dp[i, 0] = dp[i - 1, 0] + triangle[i][0];
                    dp[i, i] = dp[i - 1, i - 1] + triangle[i][i];
                }
                for (int i = 1; i < n; i++) {
                    for (int j = 0; j < i; j++) {
                        if (i == j) {
                            dp[i, j] = dp[i - 1, j - 1] + triangle[i][j];
                        } else if (j == 0) {
                            dp[i, 0] = dp[i - 1, 0] + triangle[i][0];
                        } else {
                            dp[i, j] = Math.Min(dp[i - 1, j - 1], dp[i - 1, j]) + triangle[i][j];
                        }
                    }
                }
                int res = int.MaxValue;
                for (int i = 0; i < n; i++) {
                    res = Math.Min(dp[n - 1, i], res);
                }
                return res;
            }

            public int MaximalSquare(char[][] matrix) {
                int maxSide = 0;
                if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) {
                    return maxSide;
                }
                int rows = matrix.Length, columns = matrix[0].Length;
                var dp = new int[rows, columns];
                for (int i = 0; i < rows; i++) {
                    for (int j = 0; j < columns; j++) {
                        if (matrix[i][j] == '1') {
                            if (i == 0 || j == 0) {
                                dp[i, j] = 1;
                            } else {
                                dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]) + 1;
                            }
                            maxSide = Math.Max(maxSide, dp[i, j]);
                        }
                    }
                }
                int maxSquare = maxSide * maxSide;
                return maxSquare;
            }

            public int IntegerBreak(int n) {
                int[] dp = new int[n + 1];
                for (int i = 2; i <= n; i++) {
                    int curMax = 0;
                    for (int j = 1; j < i; j++) {
                        curMax = Math.Max(curMax, Math.Max(j * (i - j), j * dp[i - j]));
                    }
                    dp[i] = curMax;
                }
                return dp[n];
            }

            public bool ValidMountainArray(int[] A) {
                // 双指针，从左右两边同时向中间靠近
                if (A.Length < 3) {
                    return false;
                }
                int left = 0, right = A.Length - 1;
                int i = 0;
                while (i < A.Length && left < right) {
                    if (A[left] < A[left + 1]) {
                        left++;
                    }
                    if (A[right] < A[right - 1]) {
                        right--;
                    }
                    i++;
                }
                return left == right && left != 0 && right != A.Length - 1;
            }

            public int MinSteps(int n) {
                // 二维dp，最后一次的操作肯定是粘贴，如果去掉最后一次粘贴的i个A，那么子问题变为求n-i个A的最少操作次数。也可以是n/2的长度经过复制、粘贴得到
                // dp定义为长度为
                int ans = 0, d = 2;
                while (n > 1) {
                    while (n % d == 0) {
                        ans += d;
                        n /= d;
                    }
                    d++;
                }
                return ans;
            }

            public int[] SortByBits(int[] arr) {
                // 统计每个数中1的个数，如果个数不等，按照1的个数比较，如果相等，按照原数比较。
                int BitCount(int v) {
                    int res = 0;
                    while (v > 0) {
                        // 与1做与运算，如果==1，说明最后有一位1，否则是0
                        if ((v & 1) == 1) res++;
                        // 右移一位
                        v >>= 1;
                    }
                    return res;
                }
                if (arr == null || arr.Length <= 0) return arr;

                Array.Sort(arr, (x, y) => {
                    var v1 = BitCount(x);
                    var v2 = BitCount(y);
                    return (v1 == v2) ? x.CompareTo(y) : v1.CompareTo(v2);

                });
                return arr;
            }

            // #54
            public List<int> SpiralOrder(int[][] matrix) {
                var res = new List<int>();
                int m = matrix.Length;
                if (m == 0) {
                    return res;
                }
                int n = matrix[0].Length;
                // 遍历完一行或者一列后，修改上下左右边界
                int top = 0, bottom = m - 1, left = 0, right = n - 1;
                while (left <= right && top <= bottom) {
                    // 遍历顶
                    for (int j = left; j <= right; j++) {
                        res.Add(matrix[top][j]);
                    }
                    top++;
                    // 遍历右
                    for (int i = top; i <= bottom; i++) {
                        res.Add(matrix[i][right]);
                    }
                    right--;
                    // 遍历底
                    for (int j = right; j >= left; j--) {
                        res.Add(matrix[bottom][j]);
                    }
                    bottom--;
                    // 遍历左
                    for (int i = bottom; i >= top; i--) {
                        res.Add(matrix[i][left]);
                    }
                    left++;
                }
                return res.GetRange(0, m * n);
            }

            // #69
            public int MySqrt(int x) {
                if (x == 0) {
                    return 0;
                }
                int ans = (int)Math.Exp(0.5 * Math.Log(x));
                // 浮点数取整可能出现错误
                return (long)(ans + 1) * (ans + 1) <= x ? ans + 1 : ans;
            }

            // #71
            public string SimplifyPath(string path) {
                var stack = new Stack<string>();
                var paths = path.Split("/");
                foreach (var item in paths) {
                    if (item == "") {
                        continue;
                    } else if (item == "..") {
                        if (stack.Count > 0) {
                            stack.Pop();
                        }
                    } else if (item != ".") {
                        stack.Push(item);
                    }
                }
                if (stack.Count > 0) {
                    var res = new List<string>();
                    while (stack.Count != 0) {
                        res.Insert(0, stack.Pop());
                        res.Insert(0, "/");
                    }
                    return string.Join("", res);
                } else {
                    return "/";
                }
            }

            public int LadderLength(string beginWord, string endWord, List<string> wordList) {
                if (!wordList.Contains(endWord)) return 0;

                List<string> NextWords(string word) {
                    var res = new List<string>();
                    foreach (var candidateWord in wordList) {
                        int notMatch = 0;
                        for (int i = 0; i < word.Length; i++) {
                            if (notMatch == 2) {
                                break;
                            }
                            if (candidateWord[i] != word[i]) {
                                notMatch++;
                            }
                        }
                        if (notMatch == 1) {
                            res.Add(candidateWord);
                        }
                    }
                    return res;
                }

                var path = new Queue<KeyValuePair<string, int>>();
                path.Enqueue(new KeyValuePair<string, int>(beginWord, 1));
                while (path.Count != 0) {
                    int cnt = path.Count;
                    for (int i = 0; i < cnt; i++) {
                        var word = path.Dequeue();
                        var nextWords = NextWords(word.Key);
                        foreach (var nextWord in nextWords) {
                            if (nextWord == endWord) {
                                return word.Value + 1;
                            }
                            wordList.Remove(nextWord);
                            path.Enqueue(new KeyValuePair<string, int>(nextWord, word.Value + 1));
                        }
                    }
                }
                return 0;
            }

            public int RemoveDuplicates_1(int[] nums) {
                int n = nums.Length;
                if (n == 0) return 0;
                int slow = 0, fast = 1;
                int count = 1;
                while (fast < n) {
                    if (nums[fast] == nums[fast - 1]) {
                        count++;
                    } else {
                        count = 1;
                    }
                    if (count <= 2) {
                        slow++;
                        nums[slow] = nums[fast];
                    }
                    fast++;
                }
                return slow + 1;
            }

            public ListNode DeleteDuplicates_1(ListNode head) {
                if (head == null || head.next == null) return head;
                var slow = head;
                var fast = head.next;

                while (fast != null) {
                    if (slow.val == fast.val) {
                        // 如果fast 和 slow相等，fast前进
                        fast = fast.next;
                    } else {
                        // 如果fast 和 slow 不等，都要前进
                        slow.next = fast;
                        slow = slow.next;
                        fast = fast.next;
                    }
                }
                slow.next = null;
                return head;
            }

            public int[][] KClosest(int[][] points, int K) {
                Array.Sort(points, (a, b) => (a[0] * a[0] + a[1] * a[1]) - (b[0] * b[0] + b[1] * b[1]));
                return points.Take(K).ToArray();
            }

            public ListNode Partition(ListNode head, int x) {
                if (head == null || head.next == null) {
                    return head;
                }
                var beforeHead = new ListNode();
                var afterHead = new ListNode();
                var before = beforeHead;
                var after = afterHead;
                while (head != null) {
                    if (head.val < x) {
                        before.next = head;
                        before = before.next;
                    } else {
                        after.next = head;
                        after = after.next;
                    }
                    head = head.next;
                }
                after.next = null;
                before.next = afterHead.next;
                return beforeHead.next;
            }

            // #3
            public int LengthOfLongestSubstring(string s) {
                var window = new Dictionary<char, int>();
                int left = 0, right = 0;
                int res = 0;
                while (right < s.Length) {
                    var ch = s[right];
                    right++;
                    window[ch] = window.GetValueOrDefault(ch, 0) + 1;

                    while (window[ch] > 1) {
                        var tmp = s[left];
                        left++;
                        window[tmp]--;
                    }
                    res = Math.Max(res, right - left);
                }
                return res;
            }

            // #31
            public void NextPermutation(int[] nums) {
                void Swap(int i, int j) {
                    int tmp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = tmp;
                }
                int i = nums.Length - 2;
                while (i >= 0 && nums[i] >= nums[i + 1]) {
                    i--;
                }
                if (i >= 0) {
                    int j = nums.Length - 1;
                    while (j >= 0 && nums[i] >= nums[j]) {
                        j--;
                    }
                    Swap(i, j);
                }
                Array.Reverse(nums, i + 1, nums.Length - i - 1);
            }

            // 6
            public string Convert(string s, int numRows) {
                if (numRows == 1) return s;

                var res = new List<List<char>>();
                for (int i = 0; i < Math.Min(s.Length, numRows); i++) {
                    res.Add(new List<char>());
                }

                int currRow = 0;
                bool goDown = false;
                for (int i = 0; i < s.Length; i++) {
                    res[currRow].Add(s[i]);
                    if (currRow == 0 || currRow == numRows - 1) goDown = !goDown;
                    currRow += goDown ? 1 : -1;
                }
                return string.Join("", res.Select(item => string.Join("", item)).ToList());
            }

            // #19
            public ListNode RemoveNthFromEnd(ListNode head, int n) {
                var dummy = new ListNode();
                dummy.next = head;
                var slow = dummy;
                var fast = dummy;
                int i = 0;
                // fast走n+1步，可以保证slow在待删除节点的前面
                while (i <= n) {
                    fast = fast.next;
                    i++;
                }
                while (fast != null) {
                    slow = slow.next;
                    fast = fast.next;
                }
                var tmp = slow.next;
                slow.next = tmp.next;
                return dummy.next;
            }

            public int ThreeSumClosest(int[] nums, int target) {
                Array.Sort(nums);
                int ans = nums[0] + nums[1] + nums[2];
                for (int i = 0; i < nums.Length; i++) {
                    int start = i + 1, end = nums.Length - 1;
                    while (start < end) {
                        int sum = nums[start] + nums[end] + nums[i];
                        if (Math.Abs(target - sum) < Math.Abs(target - ans))
                            ans = sum;
                        if (sum > target)
                            end--;
                        else if (sum < target)
                            start++;
                        else
                            return ans;
                    }
                }
                return ans;
            }

            public int SearchInsert(int[] nums, int target) {
                int left = 0, right = nums.Length - 1;
                int mid;
                while (left <= right) {
                    mid = left + (right - left) / 2;
                    if (nums[mid] > target) {
                        right = mid - 1;
                    } else if (nums[mid] < target) {
                        left = mid + 1;
                    } else {
                        return mid;
                    }
                }
                return left;
            }

            // #36
            public bool IsValidSudoku(char[][] board) {
                var rows = new int[9, 9];
                var cols = new int[9, 9];
                var blocks = new int[9, 9];

                for (int i = 0; i < 9; i++) {
                    for (int j = 0; j < 9; j++) {
                        if (board[i][j] != '.') {
                            var ele = int.Parse(board[i][j].ToString()) - 1;
                            int k = (i / 3) * 3 + j / 3;
                            if ((rows[i, ele] == 0) && (cols[j, ele] == 0) && (blocks[k, ele] == 0)) {
                                rows[i, ele]++;
                                cols[j, ele]++;
                                blocks[k, ele]++;
                            } else {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }

            public int[] SortArrayByParityII(int[] A) {
                int n = A.Length;
                if (n == 0) {
                    return new int[] { };
                }
                var odd = new List<int>();
                var even = new List<int>();
                var res = new List<int>();
                foreach (var num in A) {
                    if (num % 2 == 0) {
                        even.Add(num);
                    } else {
                        odd.Add(num);
                    }
                }
                for (int i = 0; i < n / 2; i++) {
                    res.Add(even[i]);
                    res.Add(odd[i]);
                }
                return res.ToArray();
            }

            // #48
            public void Rotate(int[][] matrix) {
                // matrix[i,j] -> matrix[k=j,n-i]
                int n = matrix.Length;
                for (int i = 0; i < n; i++) {
                    for (int j = i; j < n; j++) {
                        int tmp = matrix[i][j];
                        matrix[i][j] = matrix[j][i];
                        matrix[j][i] = tmp;
                    }
                }
                for (int i = 0; i < n; i++) {
                    for (int j = 0; j < n / 2; j++) {
                        int tmp = matrix[i][j];
                        matrix[i][j] = matrix[i][n - 1 - j];
                        matrix[i][n - 1 - j] = tmp;
                    }
                }
            }

            // #49
            public List<List<string>> GroupAnagrams(string[] strs) {
                if (strs.Length == 0) {
                    return new List<List<string>>();
                }
                var res = new Dictionary<string, List<string>>();

                for (int i = 0; i < strs.Length; i++) {
                    var tmp = string.Join("", strs[i].OrderBy(x => x));
                    if (!res.ContainsKey(tmp)) {
                        res[tmp] = new List<string>();
                    }
                    res[tmp].Add(strs[i]);
                }
                return res.Values.ToList();
            }

            // #328
            public ListNode OddEvenList(ListNode head) {
                if (head == null) {
                    return head;
                }
                ListNode evenHead = head.next;
                ListNode odd = head, even = evenHead;
                while (even != null && even.next != null) {
                    odd.next = even.next;
                    odd = odd.next;
                    even.next = odd.next;
                    even = even.next;
                }
                odd.next = evenHead;
                return head;
            }

            // #38
            public string CountAndSay(int n) {
                List<string> res = new List<string>();
                res.Add("1");
                for (int i = 1; i < n; ++i) {
                    var tmp = new StringBuilder();
                    int k = 0;
                    int j = 0;
                    int count = 0;
                    while (j < res[i - 1].Length) {
                        if (res[i - 1][k] == res[i - 1][j]) {
                            count++;
                            j++;
                        } else {
                            tmp.Append(count);
                            tmp.Append(res[i - 1][k]);
                            k = j;
                            count = 0;
                        }
                    }
                    tmp.Append(count);
                    tmp.Append(res[i - 1][k]);
                    res.Add(tmp.ToString());
                }
                return res.Last();
            }

            public bool SearchMatrix(int[][] matrix, int target) {
                int m = matrix.Length;
                if (m == 0) return false;
                int n = matrix[0].Length;

                int left = 0, right = m * n - 1;
                int pivotIdx, pivotValue;
                while (left <= right) {
                    pivotIdx = (left + right) / 2;
                    pivotValue = matrix[pivotIdx / n][pivotIdx % n];
                    if (target == pivotValue) {
                        return true;
                    } else {
                        if (target < pivotValue) right = pivotIdx - 1;
                        else left = pivotIdx + 1;
                    }
                }
                return false;
            }

            public int[] RelativeSortArray(int[] arr1, int[] arr2) {
                int upper = arr1.Max();
                int[] frequency = new int[upper + 1];
                foreach (var x in arr1) {
                    frequency[x]++;
                }
                int[] ans = new int[arr1.Length];
                int index = 0;
                foreach (var x in arr2) {
                    for (int i = 0; i < frequency[x]; ++i) {
                        ans[index++] = x;
                    }
                    frequency[x] = 0;
                }
                for (int x = 0; x <= upper; ++x) {
                    for (int i = 0; i < frequency[x]; ++i) {
                        ans[index++] = x;
                    }
                }
                return ans;
            }

            public int LengthOfLastWord(string s) {
                int lenght = 0;
                int i = s.Length - 1;
                while (i >= 0 && (s[i] != ' ' || i == s.Length - 1 || (i < s.Length - 1 && s[i + 1] == ' '))) {
                    if (s[i] != ' ') {
                        lenght++;
                        i--;
                    } else {
                        i--;
                    }
                }
                return lenght;
            }

            public ListNode DeleteDuplicates_2(ListNode head) {
                var dummy = new ListNode();
                dummy.next = head;
                var slow = dummy;
                var fast = head;
                while (fast != null && fast.next != null) {
                    if (slow.next.val != fast.next.val) {
                        slow = slow.next;
                        fast = fast.next;
                    } else {
                        while (fast.next != null && fast.val == fast.next.val) {
                            fast = fast.next;
                        }
                        fast = fast.next;
                        slow.next = fast;
                    }
                }
                return dummy.next;
            }

            // #402
            public string RemoveKdigits(string num, int k) {
                var monoStack = new Stack<char>();
                foreach (var item in num) {
                    while (monoStack.Count != 0 && k > 0 && monoStack.Peek() > item) {
                        monoStack.Pop();
                        k--;
                    }
                    monoStack.Push(item);
                }
                for (int i = 0; i < k; ++i) {
                    monoStack.Pop();
                }
                var res = string.Join("", monoStack.Reverse()).TrimStart('0');
                return res.Length == 0 ? "0" : res;
            }

            public int[] NextGreaterElement(int[] nums1, int[] nums2) {
                var dict = new Dictionary<int, int>();
                var stack = new Stack<int>();
                var res = new int[nums1.Length];
                int n = nums2.Length;
                for (int i = n - 1; i >= 0; i--) {
                    while (stack.Count != 0 && stack.Peek() <= nums2[i]) {
                        stack.Pop();
                    }
                    dict[nums2[i]] = stack.Count == 0 ? -1 : stack.Peek();
                    stack.Push(nums2[i]);
                }
                for (int i = 0; i < nums1.Length; i++) {
                    res[i] = dict[nums1[i]];
                }
                return res;
            }

            // #92
            public ListNode ReverseBetween(ListNode head, int left, int right) {
                var dummy = new ListNode(-1);
                dummy.next = head;
                var pre = dummy;
                for (int i = 0; i < left - 1; ++i) {
                    pre = pre.next;
                }
                var cur = pre.next;
                ListNode next;
                for (int i = 0; i < right - left; ++i) {
                    // 每次把next交换到最前面
                    next = cur.next;
                    cur.next = next.next;
                    next.next = pre.next;
                    pre.next = next;
                }
                return dummy.next;
            }

            // #206
            public ListNode ReverseList(ListNode head) {
                ListNode Helper(ListNode node) {
                    if (node.next == null) {
                        return node;
                    }
                    var last = Helper(node.next);
                    node.next.next = node;
                    node.next = null;
                    return last;
                }
                return head == null ? head : Helper(head);
            }

            public ListNode ReverseList_1(ListNode head) {
                if (head == null) return head;
                ListNode slow = null;
                var fast = head;
                while (fast != null) {
                    var next = fast.next;
                    fast.next = slow;
                    slow = fast;
                    fast = next;
                }
                return slow;
            }

            // #88
            public void Merge(int[] nums1, int m, int[] nums2, int n) {
                var tmp = new int[m];
                Array.Copy(nums1, tmp, m);
                int i = 0, j = 0, k = 0;
                while (i < m && j < n) {
                    nums1[k++] = tmp[i] <= nums2[j] ? tmp[i++] : nums2[j++];
                }
                if (i < m) {
                    Array.Copy(tmp, i, nums1, i + j, m + n - i - j);
                }
                if (j < n) {
                    Array.Copy(nums2, j, nums1, i + j, m + n - i - j);
                }
            }

            public int[][] ReconstructQueue(int[][] people) {
                Array.Sort(people, (x, y) => {
                    return x[0] == y[0] ? x[1] - y[1] : y[0] - x[0];
                });

                List<int[]> ans = new List<int[]>();
                foreach (int[] i in people) {
                    ans.Insert(i[1], i);
                }
                return ans.ToArray();
            }

            // #110
            public bool IsBalanced(TreeNode root) {
                (int height, bool isBalanced) Helper(TreeNode root) {
                    if (root == null) {
                        return (0, true);
                    } else {
                        var (lHeight, lBalanced) = Helper(root.left);
                        var (rHeight, rBalanced) = Helper(root.right);
                        return (Math.Max(lHeight, rHeight) + 1, Math.Abs(lHeight - rHeight) <= 1 && lBalanced && rBalanced);
                    }
                }
                return Helper(root).isBalanced;
            }

            public int MinDepth(TreeNode root) {
                if (root == null) {
                    return 0;
                }
                if (root.left == null && root.right == null) {
                    return 1;
                }

                int minDepth = int.MaxValue;
                // 必须得在left，right不为null的时候才能计算左右子树的最小高度，否则会返回1
                if (root.left != null) {
                    minDepth = Math.Min(MinDepth(root.left), minDepth);
                }
                if (root.right != null) {
                    minDepth = Math.Min(MinDepth(root.right), minDepth);
                }
                return minDepth + 1;
            }

            // #109
            public TreeNode SortedListToBST(ListNode head) {
                ListNode GetMedian(ListNode left, ListNode right) {
                    var slow = left;
                    var fast = left;
                    while (fast != right && fast.next != right) {
                        left = left.next;
                        fast = fast.next;
                        fast = fast.next;
                    }
                    return left;
                }
                TreeNode Helper(ListNode left, ListNode right) {
                    if (left == right) {
                        return null;
                    }
                    var mid = GetMedian(left, right);
                    var root = new TreeNode(mid.val);
                    root.left = Helper(left, mid);
                    root.right = Helper(mid.next, right);
                    return root;
                }
                return Helper(head, null);
            }

            public List<List<int>> Generate(int numRows) {
                var res = new List<List<int>>();
                if (numRows == 0) {
                    return res;
                }
                res.Add(new List<int> { 1 });
                for (int i = 1; i < numRows; i++) {
                    var row = new List<int>();
                    row.Add(1);
                    for (int j = 1; j < i; j++) {
                        row.Add(res[i - 1][j - 1] + res[i - 1][j]);
                    }
                    row.Add(1);
                    res.Add(row);
                }
                return res;
            }

            public int[][] AllCellsDistOrder(int R, int C, int r0, int c0) {
                if (R == 0 || C == 0) {
                    return new int[0][] { };
                };
                var res = new List<int[]>();
                var queue = new Queue<int[]>();
                var vis = new Dictionary<string, bool>();
                // 搜索上下左右的常用技巧
                int[] dx = { 0, 1, 0, -1 };
                int[] dy = { 1, 0, -1, 0 };
                queue.Enqueue(new int[] { r0, c0 });
                vis[$"{r0},{c0}"] = true;
                while (queue.Count != 0) {
                    var count = queue.Count;
                    for (int i = 0; i < count; i++) {
                        var cur = queue.Dequeue();
                        res.Add(cur);
                        for (int k = 0; k < 4; k++) {
                            int tx = cur[0] + dx[k];
                            int ty = cur[1] + dy[k];
                            if (tx >= 0 && tx < R && ty >= 0 && ty < C) {
                                var tmp = new int[] { tx, ty };
                                var pos = string.Join(",", tmp);
                                if (!vis.ContainsKey(pos)) {
                                    queue.Enqueue(tmp);
                                    vis[pos] = true;
                                }
                            }
                        }
                    }
                }
                return res.ToArray();
            }

            public List<int> GetRow(int rowIndex) {
                if (rowIndex < 0) {
                    return new List<int>();
                }
                if (rowIndex == 0) {
                    return new List<int> { 1 };
                }
                var res = new List<int> { 1, 1 };
                for (int i = 0; i <= rowIndex; i++) {
                    var row = new List<int>();
                    row.Add(1);
                    for (int j = 1; j < i; j++) {
                        row.Add(res[j - 1] + res[j]);
                    }
                    row.Add(1);
                    res = row;
                }
                return res;
            }

            // #134
            public int CanCompleteCircuit(int[] gas, int[] cost) {
                int n = gas.Length;
                int totalGas = 0;
                int curGas = 0;
                int startIdx = 0;
                for (int i = 0; i < n; i++) {
                    // 保证了从最后一次更新的startIdx出发可以绕一圈
                    totalGas += gas[i] - cost[i];
                    curGas += gas[i] - cost[i];
                    if (curGas < 0) {
                        startIdx = i + 1;
                        curGas = 0;
                    }
                }
                return totalGas >= 0 ? startIdx : -1;
            }

            // #125
            public bool IsPalindrome(string s) {
                var sgood = new StringBuilder();
                foreach (var ch in s) {
                    if (char.IsLetterOrDigit(ch)) {
                        sgood.Append(ch);
                    }
                }
                int left = 0, right = sgood.Length - 1;
                while (left < right) {
                    if (char.ToLower(sgood[left]) != char.ToLower(sgood[right])) {
                        return false;
                    }
                    ++left;
                    --right;
                }
                return true;
            }

            public int SingleNumber(int[] nums) {
                var set = new SortedSet<int>(nums);
                long setSum = 0, numsSum = 0;
                foreach (var num in nums) {
                    numsSum += num;
                }
                foreach (var num in set) {
                    setSum += num;
                }
                return (int)((3 * setSum - numsSum) / 2);
            }

            // #283
            public void MoveZeroes(int[] nums) {
                int slow = -1, fast = 0;
                while (slow <= fast && fast <= nums.Length - 1) {
                    if (nums[fast] != 0) {
                        slow++;
                        int tmp = nums[slow];
                        nums[slow] = nums[fast];
                        nums[fast] = tmp;
                    }
                    fast++;
                }
            }

            //#148 
            public ListNode SortList(ListNode head) {
                if (head == null || head.next == null) {
                    return head;
                }

                ListNode Cut(ListNode head, int n) {
                    while (head != null && n > 1) {
                        head = head.next;
                        n--;
                    }
                    if (head == null) { return null; }
                    var res = head.next;
                    head.next = null;
                    return res;

                }
                ListNode Merge(ListNode left, ListNode right) {
                    var dummy = new ListNode();
                    var p = dummy;
                    while (left != null && right != null) {
                        if (left.val < right.val) {
                            p.next = left;
                            left = left.next;
                        } else {
                            p.next = right;
                            right = right.next;
                        }
                        p = p.next;
                    }
                    p.next = left != null ? left : right;
                    return dummy.next;
                }
                // 链表长度
                int len = 0;
                var p = head;
                while (p != null) {
                    len++;
                    p = p.next;
                }

                // 自底向上归并
                var dummy = new ListNode();
                dummy.next = head;
                for (int i = 1; i < len; i *= 2) {
                    // cur是新一组的头
                    var cur = dummy.next;
                    // tail是上一组的尾巴
                    var tail = dummy;
                    while (cur != null) {
                        var left = cur;
                        var right = Cut(left, i);
                        cur = Cut(right, i);
                        tail.next = Merge(left, right);
                        while (tail.next != null) tail = tail.next;
                    }
                }
                return dummy.next;
            }

            public ListNode InsertionSortList(ListNode head) {
                if (head == null) {
                    return head;
                }
                var dummy = new ListNode(0);
                dummy.next = head;
                var last = head;
                var cur = head.next;
                while (cur != null) {
                    if (last.val <= cur.val) {
                        last = last.next;
                    } else {
                        var prev = dummy;
                        while (prev.next.val <= cur.val) {
                            prev = prev.next;
                        }
                        // 从后往前，last接上cur的next，cur插入到prev和prev的next之间 
                        last.next = cur.next;
                        cur.next = prev.next;
                        prev.next = cur;
                    }
                    cur = last.next;
                }
                return dummy.next;
            }

            public ListNode DetectCycle(ListNode head) {
                if (head == null) {
                    return null;
                }
                var slow = head;
                var fast = head;
                while (fast != null && fast.next != null) {
                    slow = slow.next;
                    fast = fast.next.next;
                    if (slow == fast) {
                        var ptr = head;
                        while (ptr != slow) {
                            ptr = ptr.next;
                            slow = slow.next;
                        }
                        return ptr;
                    }
                }
                return null;
            }

            public int EvalRPN(string[] tokens) {
                var stack = new Stack<int>();
                foreach (var token in tokens) {
                    int num = 0;
                    if (int.TryParse(token, out num)) {
                        stack.Push(num);
                    } else {
                        var num1 = stack.Pop();
                        var num2 = stack.Pop();
                        switch (token) {
                            case "+":
                                stack.Push(num2 + num1);
                                break;
                            case "-":
                                stack.Push(num2 - num1);
                                break;
                            case "*":
                                stack.Push(num2 * num1);
                                break;
                            case "/":
                                stack.Push(num2 / num1);
                                break;
                            default:
                                continue;
                        }
                    }
                }
                return stack.Pop();
            }

            // #138
            public ListNode CopyRandomList(ListNode head) {
                if (head == null) {
                    return null;
                }
                var vis = new Dictionary<ListNode, ListNode>();

                ListNode CloneNode(ListNode node) {
                    if (node != null) {
                        if (!vis.ContainsKey(node)) {
                            vis[node] = new ListNode(node.val, null, null);
                        }
                        return vis[node];
                    }
                    return null;
                }

                var old = head;
                var newNode = new ListNode(old.val);
                vis[old] = newNode;
                while (old != null) {
                    newNode.next = CloneNode(old.next);
                    newNode.random = CloneNode(old.random);
                    old = old.next;
                    newNode = newNode.next;
                }
                return vis[head];
            }

            // #151
            public string ReverseWords(string s) {
                int slow = 0, fast = 0;
                var stack = new Stack<string>();
                var n = s.Length;
                while ((slow <= fast) && (fast < n)) {
                    while (slow < n && s[slow] == ' ') {
                        slow++;
                    }
                    if (slow == n) break;
                    fast = slow + 1;
                    while (fast < n && s[fast] != ' ') {
                        fast++;
                    }
                    stack.Push(s.Substring(slow, fast - slow));
                    slow = fast;
                }
                return string.Join(" ", stack.ToList());
            }

            // #152
            public int MaxProduct(int[] nums) {
                var max = (int[])nums.Clone();
                var min = (int[])nums.Clone();
                for (int i = 1; i < nums.Length; i++) {
                    max[i] = Math.Max(Math.Max(max[i - 1] * nums[i], min[i - 1] * nums[i]), nums[i]);
                    min[i] = Math.Min(Math.Min(min[i - 1] * nums[i], max[i - 1] * nums[i]), nums[i]);
                }
                return max.Max();
            }

            // #153
            public int FindMin(int[] nums) {
                if (nums.Length == 1) {
                    return nums[0];
                }
                int left = 0, right = nums.Length - 1;
                if (nums[right] > nums[0]) {
                    return nums[0];
                }

                while (left < right) {
                    int mid = left + (right - left) / 2;
                    if (nums[mid] > nums[mid + 1]) {
                        return nums[mid + 1];
                    }
                    if (nums[mid - 1] > nums[mid]) {
                        return nums[mid];
                    }
                    if (nums[mid] > nums[0]) {
                        left = mid + 1;
                    } else {
                        right = mid;
                    }
                }
                return -1;
            }

            // #242
            public bool IsAnagram(string s, string t) {
                var dict = s.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
                foreach (var ch in t) {
                    if (dict.ContainsKey(ch)) {
                        dict[ch]--;
                    } else {
                        return false;
                    }
                }
                return dict.Values.All((item) => {
                    return item == 0;
                });
            }

            public int FindMinArrowShots(int[][] points) {
                if (points.Length == 0) {
                    return 0;
                }
                Array.Sort(points, (a, b) => {
                    return a[1] < b[1] ? -1 : 1;
                });
                int count = 1;
                int end = points[0][1];
                foreach (var point in points) {
                    var start = point[0];
                    if (start > end) {
                        count++;
                        end = point[1];
                    }
                }
                return count;
            }

            public int EraseOverlapIntervals(int[][] intervals) {
                if (intervals.Length == 0) {
                    return 0;
                }
                Array.Sort(intervals, (a, b) => {
                    return a[1] < b[1] ? -1 : 1;
                });
                int count = 1;
                int end = intervals[0][1];
                foreach (var interval in intervals) {
                    int start = interval[0];
                    if (start >= end) {
                        count++;
                        end = interval[1];
                    }
                }
                return intervals.Length - count;
            }

            // #160
            public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
                var dict = new Dictionary<ListNode, bool>();
                while (headA != null) {
                    dict[headA] = true;
                    headA = headA.next;
                }
                while (headB != null) {
                    if (dict.ContainsKey(headB)) {
                        return headB;
                    } else {
                        headB = headB.next;
                    }
                }
                return null;
            }

            public int FindPeakElement(int[] nums) {
                int left = 0, right = nums.Length - 1;
                while (left < right) {
                    int mid = left + (right - left) / 2;
                    if (nums[mid] > nums[mid + 1]) {
                        right = mid;
                    } else {
                        left = mid + 1;
                    }
                }
                return left;
            }

            // #168
            public string ConvertToTitle(int n) {
                var s = new StringBuilder();
                while (n != 0) {
                    n--;
                    s.Insert(0, (char)('A' + n % 26));
                    n = n / 26;
                }
                return s.ToString();
            }

            public List<string> FindRepeatedDnaSequences(string s) {
                var res = new List<string>();
                if (s.Length < 10) {
                    return res;
                }
                var dict = new Dictionary<string, int>();
                for (int i = 0; i <= s.Length - 10; i++) {
                    var segment = s.Substring(i, 10);
                    dict[segment] = dict.GetValueOrDefault(segment, 0) + 1;
                }
                foreach (var (key, val) in dict) {
                    if (val >= 2) {
                        res.Add(key);
                    }
                }
                return res;
            }

            public string SortString(string s) {
                var dict = new int[26];
                foreach (var ch in s) {
                    dict[ch - 'a']++;
                }
                var res = new StringBuilder();
                while (res.Length != s.Length) {
                    for (int i = 0; i < 26; i++) {
                        if (dict[i] > 0) {
                            res.Append((char)(i + 'a'));
                            dict[i]--;
                        }
                    }
                    for (int i = 25; i >= 0; i--) {
                        if (dict[i] > 0) {
                            res.Append((char)(i + 'a'));
                            dict[i]--;
                        }
                    }
                }
                return res.ToString();
            }

            public uint ReverseBits(uint n) {
                uint res = 0;
                for (int i = 0; i < 32; i++) {
                    res = (res << 1) + (n & 1);
                    n >>= 1;
                }
                return res;
            }

            public ListNode RemoveElements(ListNode head, int val) {
                var dummy = new ListNode();
                dummy.next = head;
                var prev = dummy;
                var cur = head;
                while (cur != null) {
                    if (cur.val == val) {
                        prev.next = cur.next;
                    } else {
                        prev = cur;
                    }
                    cur = cur.next;
                }
                return dummy.next;
            }

            public bool IsIsomorphic(string s, string t) {
                var dict1 = new Dictionary<char, int>();
                var res1 = new StringBuilder();
                int count1 = 0;
                foreach (var ch in s) {
                    if (!dict1.ContainsKey(ch)) {
                        dict1[ch] = count1;
                        count1++;
                    }
                    res1.Append(dict1[ch]);
                }
                var dict2 = new Dictionary<char, int>();
                var res2 = new StringBuilder();
                int count2 = 0;
                foreach (var ch in t) {
                    if (!dict2.ContainsKey(ch)) {
                        dict2[ch] = count2;
                        count2++;
                    }
                    res2.Append(dict2[ch]);
                }
                return res1.ToString() == res2.ToString();
            }

            public int MaxmiumGap(int[] nums) {
                int n = nums.Length;
                if (n < 2) {
                    return 0;
                }
                long exp = 1;
                var buf = new int[n];
                var maxVal = nums.Max();
                // 基数排序，按照每一位数字大小在该位上将元素顺序排列，最后可得到从高位到低位的相对顺序排列
                while (maxVal >= exp) {
                    int[] cnt = new int[10];
                    for (int i = 0; i < n; i++) {
                        int digit = (nums[i] / (int)exp) % 10;
                        cnt[digit]++;
                    }
                    // 通过将基数索引累加，可以确定元素按基数顺序在数组中的位置
                    for (int i = 1; i < 10; i++) {
                        cnt[i] += cnt[i - 1];
                    }
                    for (int i = n - 1; i >= 0; i--) {
                        int digit = (nums[i] / (int)exp) % 10;
                        buf[cnt[digit] - 1] = nums[i];
                        cnt[digit]--;
                    }
                    buf.CopyTo(nums, 0);
                    exp *= 10;
                }
                int res = 0;
                for (int i = 1; i < n; i++) {
                    res = Math.Max(res, nums[i] - nums[i - 1]);
                }
                return res;
            }

            public bool ContainsNearbyDuplicate(int[] nums, int k) {
                var set = new SortedSet<int>();
                for (int i = 0; i < nums.Length; ++i) {
                    if (set.Contains(nums[i])) {
                        return true;
                    }
                    set.Add(nums[i]);
                    if (set.Count > k) {
                        set.Remove(nums[i - k]);
                    }
                }
                return false;
            }

            public bool ContainsDuplicate(int[] nums) {
                var res = new SortedSet<int>();
                foreach (var num in nums) {
                    if (!res.Add(num)) {
                        return true;
                    }
                }
                return false;
            }

            public int FourSumCount(int[] A, int[] B, int[] C, int[] D) {
                var dict = new Dictionary<int, int>();
                foreach (var numA in A) {
                    foreach (var numB in B) {
                        dict[numA + numB] = dict.GetValueOrDefault(numA + numB, 0) + 1;
                    }
                }
                int ans = 0;
                foreach (var numC in C) {
                    foreach (var numD in D) {
                        if (dict.ContainsKey(-(numC + numD))) {
                            ans += dict[-(numC + numD)];
                        }
                    }
                }
                return ans;
            }

            public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H) {
                int area1 = (C - A) * (D - B);
                int area2 = (G - E) * (H - F);

                if (A >= G || C <= E || B >= H || D <= F)
                    return area1 + area2;

                int length = Math.Min(C, G) - Math.Max(A, E);
                int height = Math.Min(D, H) - Math.Max(B, F);
                int area3 = length * height;
                return area1 + area2 - area3;
            }

            // #207
            public bool CanFinish(int numCourses, int[][] prerequisites) {
                var indegree = new int[numCourses];
                var adjacency = new List<List<int>>();
                var queue = new Queue<int>();
                for (int i = 0; i < numCourses; i++) {
                    adjacency.Add(new List<int>());
                }
                foreach (var node in prerequisites) {
                    // node=[0,1]，要学习0，先学习1
                    indegree[node[0]]++;
                    adjacency[node[1]].Add(node[0]);
                }
                for (int i = 0; i < numCourses; i++) {
                    // 先找到入度为0的，作为起点
                    if (indegree[i] == 0) {
                        queue.Enqueue(i);
                    }
                }
                while (queue.Count != 0) {
                    int pre = queue.Dequeue();
                    numCourses--;
                    foreach (var cur in adjacency[pre]) {
                        // 入度降为0，说明没有前驱课程
                        if (--indegree[cur] == 0) {
                            queue.Enqueue(cur);
                        }
                    }
                }
                return numCourses == 0;
            }

            // #210
            public int[] FindOrder(int numCourses, int[][] prerequisites) {
                var indegree = new int[numCourses];
                var adjacency = new List<List<int>>();
                var queue = new Queue<int>();
                var res = new List<int>();

                for (int i = 0; i < numCourses; i++) {
                    adjacency.Add(new List<int>());
                }
                foreach (var node in prerequisites) {
                    indegree[node[0]]++;
                    adjacency[node[1]].Add(node[0]);
                }
                for (int i = 0; i < numCourses; i++) {
                    if (indegree[i] == 0) {
                        queue.Enqueue(i);
                        res.Add(i);
                    }
                }
                while (queue.Count != 0) {
                    int pre = queue.Dequeue();
                    numCourses--;
                    foreach (var cur in adjacency[pre]) {
                        if (--indegree[cur] == 0) {
                            queue.Enqueue(cur);
                            res.Add(cur);
                        }
                    }
                }
                return numCourses == 0 ? res.ToArray() : new int[] { };
            }

            // #169
            public int MajorityElement(int[] nums) {
                int count = 0;
                int candidate = int.MinValue;
                foreach (var num in nums) {
                    if (count == 0) {
                        candidate = num;
                    }
                    if (candidate == num) {
                        count++;
                    } else {
                        count--;
                    }
                }
                return candidate;
            }

            public List<int> MajorityElement_2(int[] nums) {
                var res = new List<int>();
                if (nums.Length == 0) {
                    return res;
                }
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
                foreach (var num in nums) {
                    if (num == cand1) {
                        count1++;
                    } else if (num == cand2) {
                        count2++;
                    }
                }
                if (count1 > nums.Length / 3) {
                    res.Add(cand1);
                }
                if (count2 > nums.Length / 3) {
                    res.Add(cand2);
                }
                return res;
            }

            public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t) {
                // AC不了，C#没有TreeSet数据结构，无法在logn时间内查找指定元素
                var set = new SortedSet<long?>();
                for (int i = 0; i < nums.Length; i++) {
                    var s = set.FirstOrDefault(item => item >= nums[i]);
                    if (s != null && s <= (long)nums[i] + t) {
                        return true;
                    }
                    var g = set.LastOrDefault(item => item <= nums[i]);
                    if (g != null && g >= (long)nums[i] - t) {
                        return true;
                    }
                    set.Add(nums[i]);
                    if (set.Count > k) {
                        set.Remove(nums[i - k]);
                    }
                }
                return false;
            }

            // #235
            public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
                TreeNode Helper(TreeNode root, TreeNode p, TreeNode q) {
                    if (p.val < root.val && q.val < root.val) {
                        return Helper(root.left, p, q);
                    } else if (p.val > root.val && q.val > root.val) {
                        return Helper(root.right, p, q);
                    } else {
                        return root;
                    }
                }
                return Helper(root, p, q);
            }

            public int Calculate(string s) {
                var res = new Stack<int>();
                var num = 0;
                var symbol = '+';
                for (int i = 0; i < s.Length; i++) {
                    var ch = s[i];
                    if (ch == ' ' && i != s.Length - 1) continue;
                    if ('0' <= ch && ch <= '9') {
                        num = num * 10 + (ch - '0');
                        if (i != s.Length - 1) {
                            continue;
                        }
                    }
                    switch (symbol) {
                        case '+':
                            res.Push(num);
                            break;
                        case '-':
                            res.Push(-num);
                            break;
                        case '*':
                            res.Push(res.Pop() * num);
                            break;
                        case '/':
                            res.Push(res.Pop() / num);
                            break;
                    }
                    symbol = ch;
                    num = 0;
                }
                return res.Sum();
            }

            public int LargestPerimeter(int[] A) {
                Array.Sort(A);
                for (int i = A.Length - 1; i >= 2; i--) {
                    if (A[i] < A[i - 1] + A[i - 2]) {
                        return A[i] + A[i - 1] + A[i - 2];
                    }
                }
                return 0;
            }

            // #236
            public TreeNode LowestCommonAncestor_1(TreeNode root, TreeNode p, TreeNode q) {
                TreeNode ans = null;
                // 当p和q分别在左右子树，或者p或q其中一个为根
                bool Helper(TreeNode root, TreeNode p, TreeNode q) {
                    if (root == null) return false;
                    var l = Helper(root.left, p, q);
                    var r = Helper(root.right, p, q);
                    if ((l && r) || ((root.val == p.val || root.val == q.val) && (l || r))) {
                        ans = root;
                    }
                    return l || r || (root.val == p.val || root.val == q.val);
                }
                Helper(root, p, q);
                return ans;
            }

            // #215
            public int FindKthLargest(int[] nums, int k) {
                void Swap(int i, int j) {
                    var tmp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = tmp;
                }
                void MaxHeapify(int i, int heapSize) {
                    int l = 2 * i + 1, r = 2 * i + 2, largest = i;
                    if (l < heapSize && nums[l] > nums[largest]) largest = l;
                    if (r < heapSize && nums[r] > nums[largest]) largest = r;
                    if (largest != i) {
                        Swap(i, largest);
                        MaxHeapify(largest, heapSize);
                    }
                }

                void BuildMaxHeap(int heapSize) {
                    // Floyd建堆，从最后一个内部节点开始（即末节点的父亲），依次执行下滤
                    for (int i = heapSize / 2; i >= 0; --i) {
                        MaxHeapify(i, heapSize);
                    }
                }

                // 原地堆排序
                int heapSize = nums.Length;
                BuildMaxHeap(heapSize);
                for (int i = nums.Length - 1; i >= nums.Length - k + 1; --i) {
                    Swap(0, i);
                    --heapSize;
                    MaxHeapify(0, heapSize);
                }
                return nums[0];
            }

            public string ReorganizeString(string S) {
                // 出现次数最多的字母有没有超过一半
                var mid = (S.Length + 1) / 2;
                // 计数
                var dict = S.GroupBy(x => x).OrderByDescending(x => x.Count()).ToDictionary(x => x.Key, x => x.Count());

                if (dict.Values.All(x => x <= mid)) {
                    var arr = new char[S.Length];
                    Action<int> action = (i) => {
                        var key = dict.Keys.First();
                        arr[i] = key;
                        dict[key]--;
                        if (dict[key] <= 0) dict.Remove(key);
                    };

                    // 交替生成
                    for (int i = 0; i < arr.Length; i += 2) action(i);
                    for (int i = 1; i < arr.Length; i += 2) action(i);

                    return new string(arr);
                }

                return "";
            }

            public int[] SearchRange(int[] nums, int target) {
                if (nums.Length == 0) {
                    return new int[] { -1, -1 };
                }
                int left = 0, right = nums.Length - 1;
                while (left <= right) {
                    int mid = left + (right - left) / 2;
                    if (nums[mid] == target) {
                        int l = mid, r = mid;
                        while (l >= 0 && nums[l] == target) {
                            l--;
                        }
                        while (r < nums.Length && nums[r] == target) {
                            r++;
                        }
                        return new int[] { l + 1, r - 1 };
                    } else if (nums[mid] < target) {
                        left = mid + 1;
                    } else {
                        right = mid - 1;
                    }
                }
                return new int[] { -1, -1 };
            }

            public int[] SingleNumber_1(int[] nums) {
                // 关键是把两个出现一次的数字分到两个组，两个数字的二进制肯定有不一样的位，根据第一个为1的位把两个数字分到两组
                var res = new int[2];
                if (nums.Length < 2) {
                    return res;
                }
                int xorRes = 0;
                foreach (var num in nums) {
                    xorRes ^= num;
                }
                int idx = 1;
                while (true) {
                    if ((xorRes & 1) == 1) {
                        break;
                    }
                    idx = idx << 1;
                    xorRes = xorRes >> 1;
                }

                foreach (var num in nums) {
                    if ((num & idx) == 0) {
                        res[0] ^= num;
                    } else {
                        res[1] ^= num;
                    }
                }
                return res;
            }

            public int HIndex(int[] citations) {
                int n = citations.Length;
                int[] papers = new int[n + 1];
                foreach (var citation in citations) {
                    papers[Math.Min(n, citation)]++;
                }
                int k = n;
                for (int s = papers[n]; k > s; s += papers[k]) {
                    k--;
                }
                return k;
            }

            public int[] MaxNumber(int[] nums1, int[] nums2, int k) {
                int[] MaxSubsequence(int[] nums, int k) {
                    int len = nums.Length;
                    int[] stack = new int[k];
                    int top = -1;
                    int remain = len - k;
                    for (int i = 0; i < len; i++) {
                        int num = nums[i];
                        // 如果num比较大，找到num在stack中的正确位置
                        while (top >= 0 && stack[top] < num && remain > 0) {
                            top--;
                            remain--;
                        }
                        // 将num放在stack中
                        if (top < k - 1) {
                            stack[++top] = num;
                        } else {
                            remain--;
                        }
                    }
                    return stack;
                }

                int[] Merge(int[] sub1, int[] sub2) {
                    int a = sub1.Length, b = sub2.Length;
                    if (a == 0) {
                        return sub2;
                    }
                    if (b == 0) {
                        return sub1;
                    }
                    int merglen = a + b;
                    int[] m = new int[merglen];
                    int n1 = 0, n2 = 0;
                    for (int i = 0; i < merglen; i++) {
                        if (Compare(sub1, sub2, n1, n2) > 0) {
                            m[i] = sub1[n1++];
                        } else {
                            m[i] = sub2[n2++];
                        }
                    }
                    return m;
                }

                int Compare(int[] sub1, int[] sub2, int n1, int n2) {
                    int a = sub1.Length, b = sub2.Length;
                    while (n1 < a && n2 < b) {
                        int dif = sub1[n1] - sub2[n2];
                        // 比较当前元素大小，选择大的元素；
                        // 如果一样大，比较后续元素；
                        if (dif != 0) {
                            return dif;
                        }
                        n1++;
                        n2++;
                    }
                    // 如果一个比较到头了，那肯定长度长的大
                    return (a - n1) - (b - n2);
                }

                int[] res = new int[k];
                int n1 = nums1.Length;
                int n2 = nums2.Length;
                int start = Math.Max(0, k - n2), end = Math.Min(k, n1);
                for (int i = start; i <= end; i++) {
                    int[] sub1 = MaxSubsequence(nums1, i);
                    int[] sub2 = MaxSubsequence(nums2, k - i);
                    int[] cur = Merge(sub1, sub2);
                    if (Compare(cur, res, 0, 0) > 0) {
                        Array.Copy(cur, 0, res, 0, k);
                    }
                }
                return res;
            }

            // #337
            public int Rob_3(TreeNode root) {
                var memo = new Dictionary<TreeNode, int>();
                // 利用备忘录消除重叠子问题
                int Helper(TreeNode root) {
                    if (root == null) return 0;

                    if (memo.ContainsKey(root)) {
                        return memo[root];
                    }
                    // 抢，然后去下下家
                    int doIt = root.val +
                        (root.left == null ?
                            0 : Helper(root.left.left) + Helper(root.left.right)) +
                        (root.right == null ?
                            0 : Helper(root.right.left) + Helper(root.right.right));
                    // 不抢，然后去下家
                    int dont = Helper(root.left) + Helper(root.right);

                    int res = Math.Max(doIt, dont);
                    memo[root] = res;
                    return res;
                }
                return Helper(root);
            }

            // #543
            public int DiameterOfBinaryTree(TreeNode root) {
                int ans = 1;
                int Helper(TreeNode root) {
                    if (root == null) {
                        return 0;
                    }
                    int l = Helper(root.left);
                    int r = Helper(root.right);
                    // 更新以当前节点为根的最大长度
                    ans = Math.Max(ans, l + r + 1);
                    // 返回以当前节点为根的子树高度
                    return Math.Max(l, r) + 1;
                }

                Helper(root);
                return ans - 1;
            }

            public bool FindTarget(TreeNode root, int k) {
                var res = new List<int>();
                var stack = new Stack<TreeNode>();
                // root为null并且栈空，结束
                while (root != null || stack.Count != 0) {
                    while (root != null) {
                        stack.Push(root);
                        root = root.left;
                    }
                    root = stack.Pop();
                    res.Add(root.val);
                    root = root.right;
                }
                int left = 0, right = res.Count - 1;
                while (left < right) {
                    int sum = res[left] + res[right];
                    if (sum == k)
                        return true;
                    if (sum < k)
                        left++;
                    else
                        right--;
                }
                return false;
            }

            public int CountPrimes(int n) {
                int[] isPrime = new int[n];
                Array.Fill(isPrime, 1);
                int ans = 0;
                for (int i = 2; i < n; ++i) {
                    if (isPrime[i] == 1) {
                        ans += 1;
                        if ((long)i * i < n) {
                            for (int j = i * i; j < n; j += i) {
                                isPrime[j] = 0;
                            }
                        }
                    }
                }
                return ans;
            }

            public string GetHint(string secret, string guess) {
                var dict = new int[10];
                int bulls = 0, cows = 0;
                for (int i = 0; i < secret.Length; i++) {
                    int cs = secret[i] - '0';
                    int cg = guess[i] - '0';
                    if (cs == cg) {
                        bulls++;
                    } else {
                        // 只有cs和cg不等时，才会变更个数。dict[cs] < 0说明在guess中有和cs不等的cg
                        if (dict[cs] < 0) {
                            cows++;
                        }
                        if (dict[cg] > 0) {
                            cows++;
                        }
                        // cs总是增加，cg总是减少
                        dict[cs]++;
                        dict[cg]--;
                    }
                }
                return $"{bulls}A{cows}B";
            }

            // #652
            public List<TreeNode> FindDuplicateSubtrees(TreeNode root) {
                var dict = new Dictionary<string, int>();
                var res = new List<TreeNode>();
                string Helper(TreeNode root) {
                    if (root == null) return "#";
                    string str = $"{root.val},{Helper(root.left)},{Helper(root.right)}";
                    dict[str] = dict.GetValueOrDefault(str, 0) + 1;
                    // 只在==2时添加一次，之后再出现同样的str，也无需添加
                    if (dict[str] == 2) {
                        res.Add(root);
                    }
                    return str;
                }
                Helper(root);
                return res;
            }

            public bool IsPossible(int[] nums) {
                var numCount = new SortedDictionary<int, int>();
                var tail = new SortedDictionary<int, int>();
                foreach (var num in nums) {
                    numCount[num] = numCount.GetValueOrDefault(num, 0) + 1;
                }
                foreach (var num in nums) {
                    if (numCount[num] == 0) continue;
                    else if (numCount[num] > 0 && tail.GetValueOrDefault(num - 1, 0) > 0) {
                        numCount[num]--;
                        tail[num - 1]--;
                        tail[num] = tail.GetValueOrDefault(num, 0) + 1;
                    } else if (numCount.GetValueOrDefault(num + 1, 0) > 0 && numCount.GetValueOrDefault(num + 2, 0) > 0) {
                        numCount[num]--;
                        numCount[num + 1]--;
                        numCount[num + 2]--;
                        tail[num + 2] = tail.GetValueOrDefault(num + 2, 0) + 1;
                    } else {
                        return false;
                    }
                }
                return true;
            }

            public List<double> AverageOfLevels(TreeNode root) {
                var res = new List<double>();
                if (root == null) return res;
                var queue = new Queue<TreeNode>();
                queue.Enqueue(root);
                while (queue.Count != 0) {
                    var count = queue.Count;
                    var level = new List<int>();
                    for (int i = 0; i < count; i++) {
                        var tmp = queue.Dequeue();
                        level.Add(tmp.val);
                        if (tmp.left != null) queue.Enqueue(tmp.left);
                        if (tmp.right != null) queue.Enqueue(tmp.right);
                    }
                    res.Add(level.Average());
                }
                return res;
            }

            public bool IsCompleteTree(TreeNode root) {
                if (root == null) return true;
                var queue = new Queue<TreeNode>();
                queue.Enqueue(root);
                var prev = root;
                while (queue.Count != 0) {
                    var count = queue.Count;
                    for (int i = 0; i < count; i++) {
                        var tmp = queue.Dequeue();
                        if (prev == null && tmp != null) return false;
                        if (tmp != null) {
                            queue.Enqueue(tmp.left);
                            queue.Enqueue(tmp.right);
                        }
                        prev = tmp;
                    }
                }
                return true;
            }

            // #965
            public bool IsUnivalTree(TreeNode root) {
                int val = root.val;
                bool Helper(TreeNode root) {
                    if (root == null) return true;
                    var left = Helper(root.left);
                    var right = Helper(root.right);
                    return left && right && root.val == val;
                }
                return Helper(root);
            }

            // #1026
            public int MaxAncestorDiff(TreeNode root) {
                if (root == null) return 0;
                var res = int.MinValue;
                (int, int) Helper(TreeNode root) {
                    if (root == null) {
                        return (100001, -1);
                    }
                    var curVal = root.val;
                    var (lMin, lMax) = Helper(root.left);
                    var (rMin, rMax) = Helper(root.right);
                    lMin = lMin == 100001 ? curVal : lMin;
                    lMax = lMax == -1 ? curVal : lMax;
                    rMin = rMin == 100001 ? curVal : rMin;
                    rMax = rMax == -1 ? curVal : rMax;
                    var curMin = Math.Min(lMin, rMin);
                    var curMax = Math.Max(lMax, rMax);
                    res = Math.Max(res, Math.Max(Math.Abs(curVal - curMin), Math.Abs(curVal - curMax)));
                    return (Math.Min(curVal, curMin), Math.Max(curVal, curMax));
                }
                Helper(root);
                return res;
            }

            public int MatrixScore(int[][] A) {
                int m = A.Length, n = A[0].Length;
                // 翻转第一列为0的行
                for (int i = 0; i < m; i++) {
                    if (A[i][0] == 0) {
                        for (int j = 0; j < n; j++) {
                            A[i][j] = (1 - A[i][j]);
                        }
                    }
                }
                for (int j = 0; j < n; j++) {
                    int zeroCount = 0, oneCount = 0;
                    for (int i = 0; i < m; i++) {
                        if (A[i][j] == 0) {
                            zeroCount++;
                        } else {
                            oneCount++;
                        }
                    }
                    if (zeroCount > oneCount) {
                        for (int i = 0; i < m; i++) {
                            A[i][j] = (1 - A[i][j]);
                        }
                    }
                }
                int res = 0;
                foreach (var row in A) {
                    int rowScore = 0;
                    foreach (var x in row) {
                        rowScore = ((rowScore << 1) + x);
                    }
                    res += rowScore;
                }
                return res;
            }

            // #988
            public string SmallestFromLeaf(TreeNode root) {
                var res = new List<string>();
                var str = new StringBuilder();
                void Helper(TreeNode root) {
                    if (root == null) return;
                    str.Append((char)('a' + root.val));
                    if (root.left == null && root.right == null) {
                        var tmp = new string(str.ToString().Reverse().ToArray());
                        res.Add(tmp);
                    }
                    Helper(root.left);
                    Helper(root.right);
                    str.Remove(str.Length - 1, 1);
                }
                Helper(root);
                return res.Min();
            }

            public TreeNode AddOneRow(TreeNode root, int v, int d) {
                if (d == 1) {
                    var tmp = new TreeNode(v);
                    tmp.left = root;
                    return tmp;
                }
                var queue = new Queue<TreeNode>();
                var prevRow = new List<TreeNode>();
                var height = 1;
                queue.Enqueue(root);
                while (queue.Count != 0) {
                    var count = queue.Count;
                    for (int i = 0; i < count; i++) {
                        var node = queue.Dequeue();
                        if (height == d - 1) prevRow.Add(node);
                        if (node.left != null) queue.Enqueue(node.left);
                        if (node.right != null) queue.Enqueue(node.right);
                    }
                    if (++height == d) break;
                }
                foreach (var node in prevRow) {
                    var tmp = new TreeNode(v);
                    tmp.left = node.left;
                    node.left = tmp;
                    tmp = new TreeNode(v);
                    tmp.right = node.right;
                    node.right = tmp;
                }
                return root;
            }

            // #238
            public int[] ProductExceptSelf(int[] nums) {
                int n = nums.Length;
                int[] prev = new int[n];
                int[] next = new int[n];
                prev[0] = 1;
                next[n - 1] = 1;
                for (int i = 1; i < n; i++) {
                    prev[i] = prev[i - 1] * nums[i - 1];
                }
                for (int i = n - 2; i >= 0; i--) {
                    next[i] = next[i + 1] * nums[i + 1];
                }
                return prev.Zip(next, (x, y) => x * y).ToArray();
            }

            // #287
            public int FindDuplicate(int[] nums) {
                Array.Sort(nums);
                int slow = 0, fast = 1;
                while (fast < nums.Length) {
                    if (nums[slow] == nums[fast]) {
                        return nums[slow];
                    }
                    slow++;
                    fast++;
                }
                return -1;
            }

            // #842
            public List<int> SplitIntoFibonacci(string S) {
                var res = new List<int>();
                int length = S.Length;

                bool Helper(int idx, int prev, int sum) {
                    if (idx == length) return res.Count >= 3;
                    long curLong = 0;
                    for (int i = idx; i < length; i++) {
                        // 当前块长度大于1，并且起始位是0，剪枝
                        if (i > idx && S[idx] == '0') break;
                        curLong = curLong * 10 + (S[i] - '0');
                        if (curLong > int.MaxValue) break;
                        int cur = (int)curLong;
                        if (res.Count >= 2) {
                            if (cur < sum) continue;
                            else if (cur > sum) break;
                        }
                        res.Add(cur);
                        if (Helper(i + 1, cur, prev + cur)) {
                            return true;
                        } else {
                            res.RemoveAt(res.Count - 1);
                        }
                    }
                    return false;
                }
                Helper(0, 0, 0);
                return res;
            }

            // #279
            public int NumSquares(int n) {
                // 跟换硬币差不多，把硬币换成完全平方数，并且不限制硬币个数
                var nums = new List<int>();
                for (int i = 1; i * i <= n; i++) {
                    nums.Add(i * i);
                }
                var dp = new int[n + 1];
                Array.Fill(dp, n + 1);
                dp[0] = 0;
                for (int i = 1; i <= n; i++) {
                    foreach (var num in nums) {
                        if ((i - num) < 0) continue;
                        dp[i] = Math.Min(dp[i], 1 + dp[i - num]);
                    }
                }
                return dp[n];
            }

            public bool WordPattern(string pattern, string s) {
                var patterns = pattern.ToArray();
                var words = s.Split(" ");
                if (patterns.Length != words.Length) return false;
                var dict1 = new Dictionary<char, string>();
                var dict2 = new Dictionary<string, char>();
                for (int i = 0; i < patterns.Length; i++) {
                    var ch = patterns[i];
                    var word = words[i];
                    if (dict1.ContainsKey(ch) && dict2.ContainsKey(word) && (dict1[ch] != word || dict2[word] != ch)) {
                        return false;
                    }
                    if (dict1.ContainsKey(ch) && !dict2.ContainsKey(word)) {
                        return false;
                    }
                    if (!dict1.ContainsKey(ch) && dict2.ContainsKey(word)) {
                        return false;
                    }
                    if (!dict1.ContainsKey(ch) && !dict2.ContainsKey(word)) {
                        dict1[ch] = word;
                        dict2[word] = ch;
                    }
                }
                return true;
            }

            // #331
            public bool IsValidSerialization(string preorder) {
                int slots = 1;
                int n = preorder.Length;
                for (int i = 0; i < n; ++i) {
                    // 出现一个‘，’意味着前面由字符，如果字符是‘#’，消耗一个槽位，如果是非‘#’，增加两个槽位
                    if (preorder[i] == ',') {
                        --slots;
                        if (slots < 0) return false;
                        if (preorder[i - 1] != '#') slots += 2;
                    }
                }
                // 最后一个单独处理
                slots = (preorder[n - 1] == '#') ? slots - 1 : slots + 1;
                return slots == 0;
            }

            // #326
            public bool IsPowerOfThree(int n) {
                return (Math.Log10(n) / Math.Log10(3)) % 1 == 0;
            }

            // #860
            public bool LemonadeChange(int[] bills) {
                int five = 0, ten = 0;
                foreach (var bill in bills) {
                    if (bill == 5) {
                        five++;
                    } else if (bill == 10) {
                        if (five == 0) {
                            return false;
                        }
                        five--;
                        ten++;
                    } else {
                        if (five > 0 && ten > 0) {
                            five--;
                            ten--;
                        } else if (five >= 3) {
                            five -= 3;
                        } else {
                            return false;
                        }
                    }
                }
                return true;
            }
            // #304
            public class NumMatrix {
                int[,] dp;
                public NumMatrix(int[][] matrix) {
                    if (matrix.Length == 0 || matrix[0].Length == 0) return;
                    dp = new int[matrix.Length + 1, matrix[0].Length + 1];
                    for (int r = 0; r < matrix.Length; r++) {
                        for (int c = 0; c < matrix[0].Length; c++) {
                            dp[r + 1, c + 1] = dp[r + 1, c] + dp[r, c + 1] + matrix[r][c] - dp[r, c];
                        }
                    }
                }

                public int SumRegion(int row1, int col1, int row2, int col2) {
                    return dp[row2 + 1, col2 + 1] - dp[row1, col2 + 1] - dp[row2 + 1, col1] + dp[row1, col1];
                }
            }

            // #11
            public int MaxArea(int[] height) {
                int l = 0, r = height.Length - 1;
                int ans = 0;
                while (l < r) {
                    int area = Math.Min(height[l], height[r]) * (r - l);
                    ans = Math.Max(ans, area);
                    if (height[l] <= height[r]) {
                        ++l;
                    } else {
                        --r;
                    }
                }
                return ans;
            }

            // #485
            public int FindMaxConsecutiveOnes(int[] nums) {
                if (nums.Length == 0) return 0;
                int ans = 0;
                int left = 0, right = 0;
                while (left < nums.Length && right < nums.Length) {
                    if (nums[left] != 1) {
                        left++;
                    } else {
                        right = left;
                        while (right < nums.Length && nums[right] == 1) {
                            right++;
                        }
                        ans = Math.Max(ans, right - left);
                        left = right;
                    }
                }
                return ans;
            }

            // #649
            public string PredictPartyVictory(string senate) {
                int n = senate.Length;
                var radiant = new Queue<int>();
                var dire = new Queue<int>();
                for (int i = 0; i < n; ++i) {
                    if (senate[i] == 'R') {
                        radiant.Enqueue(i);
                    } else {
                        dire.Enqueue(i);
                    }
                }
                while (radiant.Count != 0 && dire.Count != 0) {
                    int radiantIndex = radiant.Dequeue(), direIndex = dire.Dequeue();
                    if (radiantIndex < direIndex) {
                        radiant.Enqueue(radiantIndex + n);
                    } else {
                        dire.Enqueue(direIndex + n);
                    }
                }
                return radiant.Count != 0 ? "Radiant" : "Dire";
            }

            // #347
            public int[] TopKFrequent(int[] nums, int k) {
                var dict = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
                // [val, key]，大顶堆，先比较val大，key大的在堆顶
                var heap = new SortedSet<int[]>(Comparer<int[]>.Create((x, y) => x[0] != y[0] ? y[0] - x[0] : y[1] - x[1]));
                foreach (var (key, val) in dict) {
                    heap.Add(new[] { val, key });
                    if (heap.Count > k) {
                        heap.Remove(heap.Last());
                    }
                }
                var res = heap.Select(x => x[1]).ToArray();
                return res;
            }

            // #445
            public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
                var stack1 = new Stack<int>();
                var stack2 = new Stack<int>();
                while (l1 != null) {
                    stack1.Push(l1.val);
                    l1 = l1.next;
                }
                while (l2 != null) {
                    stack2.Push(l2.val);
                    l2 = l2.next;
                }
                int carry = 0;
                ListNode ans = null;
                while (stack1.Count != 0 || stack2.Count != 0 || carry != 0) {
                    var a = stack1.Count != 0 ? stack1.Pop() : 0;
                    var b = stack2.Count != 0 ? stack2.Pop() : 0;
                    int cur = a + b + carry;
                    carry = cur / 10;
                    cur %= 10;
                    var curNode = new ListNode(cur);
                    curNode.next = ans;
                    ans = curNode;
                }
                return ans;
            }

            // #350
            public int[] Intersect(int[] nums1, int[] nums2) {
                var shortNums = nums1.Length < nums2.Length ? nums1 : nums2;
                var longNums = nums1.Length >= nums2.Length ? nums1 : nums2;
                var dict = new Dictionary<int, int>();
                foreach (var num in shortNums) {
                    dict[num] = dict.GetValueOrDefault(num, 0) + 1;
                }
                var res = new int[shortNums.Length];
                var idx = 0;
                foreach (var num in longNums) {
                    var count = dict.GetValueOrDefault(num, 0);
                    if (count > 0) {
                        res[idx++] = num;
                        count--;
                        if (count > 0) {
                            dict[num] = count;
                        } else {
                            dict.Remove(num);
                        }
                    }
                }
                return res.Take(idx).ToArray();
            }

            // #354
            public int MaxEnvelopes(int[][] envelopes) {
                Array.Sort(envelopes, (x, y) => {
                    if (x[0] == y[0]) {
                        return y[1] - x[1];
                    } else {
                        return x[0] - y[0];
                    }
                });
                var secDim = envelopes.Select(x => x[1]).ToArray();
                var dp = new int[secDim.Length];
                var res = 0;
                Array.Fill(dp, 1);
                for (int i = 0; i < secDim.Length; i++) {
                    for (int j = 0; j < i; j++) {
                        if (secDim[i] > secDim[j]) {
                            dp[i] = Math.Max(dp[i], dp[j] + 1);
                        }
                    }
                    res = Math.Max(res, dp[i]);
                }
                return res;
            }

            // #365
            public bool CanMeasureWater(int x, int y, int z) {
                int gcd(int x, int y) {
                    int remainder = x % y;
                    while (remainder != 0) {
                        x = y;
                        y = remainder;
                        remainder = x % y;
                    }
                    return y;
                }
                // 最后请用以上水壶中的一或两个来盛放取得的z升水。
                if (x + y < z) {
                    return false;
                }
                if (x == 0 || y == 0) {
                    return z == 0 || x + y == z;
                }
                return z % gcd(x, y) == 0;
            }

            // #400
            int FindNthDigit(int n) {
                if (n == 0) { return 0; }
                int digit = 1; // digit位数
                long start = 1; // digit位数的起始数
                long idxCount = digit * 9 * start; // digit位数范围内索引长度

                while (n > idxCount) {
                    n = (int)(n - idxCount);
                    ++digit;
                    start *= 10;
                    idxCount = digit * 9 * start;
                }
                long num = start + (n - 1) / digit;
                int remainder = (n - 1) % digit;
                return (int)(num.ToString()[remainder] - '0');
            }

            // #373
            class KSmallComparer : IComparer {
                public int Compare(object x, object y) {
                    var x1 = (long)x;
                    var y1 = (long)y;
                    // 小顶堆比较器，小于返回-1
                    return x1 < y1 ? -1 : 1;
                }
            }
            public List<List<int>> KSmallestPairs(int[] nums1, int[] nums2, int k) {
                var heap = new SortedList(new KSmallComparer());
                foreach (var num1 in nums1) {
                    foreach (var num2 in nums2) {
                        long sum = num1 + num2;
                        heap.Add(sum, new List<int> { num1, num2 });
                        if (heap.Count > k) {
                            heap.RemoveAt(heap.Count - 1);
                        }
                    }
                }
                var res = new List<List<int>>();
                foreach (var item in heap.GetValueList()) {
                    res.Add((List<int>)item);
                }
                return res;
            }

            // #377
            public int CombinationSum4(int[] nums, int target) {
                int[] dp = new int[target + 1];
                int Helper(int target) {
                    if (target == 0) {
                        return 1;
                    }
                    if (dp[target] >= 0) {
                        return dp[target];
                    }
                    int count = 0;
                    for (int i = 0; i < nums.Length; i++) {
                        if (target >= nums[i]) {
                            count += Helper(target - nums[i]);
                        }
                    }
                    dp[target] = count;
                    return count;
                }

                Array.Sort(nums);
                Array.Fill(dp, -1);
                int count = Helper(target);
                return count;
            }

            // #738
            public int MonotoneIncreasingDigits(int N) {
                var digits = N.ToString().ToCharArray();
                int i = 1;
                while (i < digits.Length && digits[i - 1] <= digits[i]) {
                    i++;
                }
                if (i < digits.Length) {
                    while (i > 0 && digits[i - 1] > digits[i]) {
                        digits[i - 1]--;
                        i--;
                    }
                    for (++i; i < digits.Length; i++) {
                        digits[i] = '9';
                    }
                }
                return int.Parse(new string(digits));
            }

            // #378
            class KthSmallestComparer : IComparer {
                public int Compare(object x, object y) {
                    var x1 = (int)x;
                    var y1 = (int)y;
                    // 小顶堆比较器，小于返回-1
                    return x1 < y1 ? -1 : 1;
                }
            }
            public int KthSmallest(int[][] matrix, int k) {
                var heap = new SortedList(new KthSmallestComparer(), k);
                foreach (var row in matrix) {
                    foreach (var num in row) {
                        heap.Add(num, num);
                        if (heap.Count > k) {
                            heap.RemoveAt(k);
                        }
                    }
                }
                return (int)heap.GetValueList()[k - 1];
            }

            // #386
            public List<int> LexicalOrder(int n) {
                var res = new List<int>();
                void Helper(int i) {
                    if (i > n) {
                        return;
                    }
                    res.Add(i);
                    for (int j = 0; j < 10; j++) {
                        Helper(i * 10 + j);
                    }
                }
                for (int i = 1; i < 10; i++) {
                    Helper(i);
                }
                return res;
            }

            // #442
            public List<int> FindDuplicates(int[] nums) {
                var res = new List<int>();
                for (int i = 0; i < nums.Length; i++) {
                    int idx = Math.Abs(nums[i]) - 1;
                    if (nums[idx] > 0) {
                        nums[idx] = -nums[idx];
                    } else {
                        res.Add(idx + 1);
                    }
                }
                return res;
            }

            // #423
            public string OriginalDigits(string s) {
                char[] count = new char[26 + (int)
                    'a'];
                foreach (var letter in s.ToCharArray()) {
                    count[letter]++;
                }
                int[] nums = new int[10];
                nums[0] = count['z'];
                nums[2] = count['w'];
                nums[4] = count['u'];
                nums[6] = count['x'];
                nums[8] = count['g'];
                nums[3] = count['h'] - nums[8];
                nums[5] = count['f'] - nums[4];
                nums[7] = count['s'] - nums[6];
                nums[9] = count['i'] - nums[5] - nums[6] - nums[8];
                nums[1] = count['n'] - nums[7] - 2 * nums[9];

                StringBuilder output = new StringBuilder();
                for (int i = 0; i < 10; i++)
                    for (int j = 0; j < nums[i]; j++)
                        output.Append(i);
                return output.ToString();
            }

            // #427
            // public Node construct(int[][] grid) {
            //     Node subConstruct(int[][] grid, int i, int j, int length) {
            //         if (length == 1) return new Node(grid[i][j] == 1 ? true : false, true);
            //         bool mark = true;
            //         int num = grid[i][j];
            //         for (int a = i; a < i + length; ++a) {
            //             for (int b = j; b < j + length; ++b) {
            //                 if (num != grid[a][b]) {
            //                     mark = false;
            //                     break;
            //                 }
            //             }
            //         }
            //         if (mark) return new Node(grid[i][j] == 1 ? true : false, true);
            //         Node curNode = new Node(true, false);
            //         curNode.topLeft = subConstruct(grid, i, j, length / 2);
            //         curNode.topRight = subConstruct(grid, i, j + length / 2, length / 2);
            //         curNode.bottomLeft = subConstruct(grid, i + length / 2, j, length / 2);
            //         curNode.bottomRight = subConstruct(grid, i + length / 2, j + length / 2, length / 2);
            //         return curNode;
            //     }
            //     return subConstruct(grid, 0, 0, grid.Length);
            // }

            // #443
            public int Compress(char[] chars) {
                var length = chars.Length;
                int slow = 0, fast = 0, cur = 0;
                while (fast <= length) {
                    // 特殊处理fast
                    if (fast == length || chars[fast] != chars[slow]) {
                        chars[cur++] = chars[slow];
                        if ((fast - slow) >= 2) {
                            foreach (var ch in (fast - slow).ToString()) {
                                chars[cur++] = ch;
                            }
                        }
                        slow = fast;
                    }
                    fast++;
                }
                return chars.Take(cur).Count();
            }

            // #447
            public int NumberOfBoomerangs(int[][] points) {
                int res = 0;
                foreach (var point in points) {
                    var dict = new Dictionary<int, int>();
                    foreach (var targetPoint in points) {
                        int dx = point[0] - targetPoint[0];
                        int dy = point[1] - targetPoint[1];
                        var dis = dx * dx + dy * dy;
                        dict[dis] = dict.GetValueOrDefault(dis, 0) + 1;
                    }
                    foreach (var (key, value) in dict) {
                        res += (value * (value - 1));
                    }
                }
                return res;
            }

            // #421
            public int FindMaximumXOR(int[] nums) {
                if (nums.Length == 1) {
                    return 0;
                }
                int res = int.MinValue;
                for (int i = 0; i < nums.Length; i++) {
                    for (int j = i + 1; j < nums.Length; j++) {
                        res = Math.Max(res, nums[i] ^ nums[j]);
                    }
                }
                return res;
            }

            // #414
            public int ThirdMax(int[] nums) {
                long first = (long)int.MinValue - 1, second = (long)int.MinValue - 1, third = (long)int.MinValue - 1;
                foreach (var num in nums) {
                    if (num > first) {
                        third = second;
                        second = first;
                        first = num;
                    }
                    if (num < first && num > second) {
                        third = second;
                        second = num;
                    }
                    if (num < second && num > third) {
                        third = num;
                    }
                }
                return (int)(third != (long)int.MinValue - 1 ? third : first);
            }

            // #401
            public IList<string> ReadBinaryWatch(int num) {
                List<string> res = new List<string>();
                int[] data = new int[] { 1, 2, 4, 8, 1, 2, 4, 8, 16, 32 };

                void FindHour(int idx, int n, int hour, int minute) {
                    if (hour > 11 || minute > 59) return;

                    if (n == 0) {
                        var m = $"{minute}".PadLeft(2, '0');
                        res.Add($"{hour}:{m}");
                        return;
                    }
                    for (int i = idx; i < data.Length; i++) {
                        if (i < 4) {
                            hour += data[i];
                        } else {
                            minute += data[i];
                        }
                        FindHour(i + 1, n - 1, hour, minute);
                        if (i < 4) {
                            hour -= data[i];
                        } else {
                            minute -= data[i];
                        }
                    }
                }
                FindHour(0, num, 0, 0);
                return res;
            }

            // #427
            public int LongestPalindrome_1(string s) {
                var dict = new Dictionary<char, int>();
                int length = s.Length;
                foreach (var ch in s) {
                    dict[ch] = dict.GetValueOrDefault(ch, 0) + 1;
                }

                int ans = 0;
                foreach (var (key, val) in dict) {
                    ans += val / 2 * 2;
                    if (val % 2 == 1 && ans % 2 == 0) {
                        ans++;
                    }
                }
                return ans;
            }

            // #434
            public int CountSegments(string s) {
                int res = 0;
                for (int i = 0; i < s.Length; i++) {
                    if ((i == 0 || s[i - 1] == ' ') && s[i] != ' ') {
                        res++;
                    }
                }
                return res;
            }

            // #495
            public int FindPoisonedDuration(int[] timeSeries, int duration) {
                int res = 0;
                for (int i = 0; i < timeSeries.Length - 1; i++) {
                    if (timeSeries[i + 1] - timeSeries[i] >= duration) {
                        res += duration;
                    } else {
                        res += (timeSeries[i + 1] - timeSeries[i]);
                    }
                }
                return timeSeries.Length < 1 ? 0 : res + duration;
            }

            // #438
            public List<int> FindAnagrams(string s, string p) {
                var res = new List<int>();
                int left = 0, right = 0;
                var need = new Dictionary<char, int>();
                var window = new Dictionary<char, int>();
                int valid = 0;
                foreach (var ch in p) {
                    need[ch] = need.GetValueOrDefault(ch, 0) + 1;
                }
                while (right < s.Length) {
                    var ch = s[right];
                    right++;
                    if (need.ContainsKey(ch)) {
                        window[ch] = window.GetValueOrDefault(ch, 0) + 1;
                        if (window[ch] == need[ch]) {
                            valid++;
                        }
                    }
                    while (right - left >= p.Length) {
                        if (valid == need.Keys.Count) {
                            res.Add(left);
                        }
                        var delCh = s[left];
                        left++;
                        if (need.ContainsKey(delCh)) {
                            if (window[delCh] == need[delCh]) {
                                valid--;
                            }
                            window[delCh]--;
                        }
                    }
                }
                return res;
            }

            // #135
            public int Candy(int[] ratings) {
                int n = ratings.Length;
                int[] left = new int[n];
                for (int i = 0; i < n; i++) {
                    if (i > 0 && ratings[i] > ratings[i - 1]) {
                        left[i] = left[i - 1] + 1;
                    } else {
                        left[i] = 1;
                    }
                }
                int right = 0, ret = 0;
                for (int i = n - 1; i >= 0; i--) {
                    if (i < n - 1 && ratings[i] > ratings[i + 1]) {
                        right++;
                    } else {
                        right = 1;
                    }
                    ret += Math.Max(left[i], right);
                }
                return ret;
            }

            // #455
            public int FindContentChildren(int[] g, int[] s) {
                Array.Sort(g);
                Array.Sort(s);
                int res = 0;
                int i = 0, j = 0;
                while (true) {
                    while (i < g.Length && j < s.Length) {
                        if (s[j] >= g[i]) {
                            res++;
                            i++;
                        }
                        j++;
                    }
                    if (i == g.Length || j == s.Length) {
                        break;
                    }
                }
                return res;
            }

            // #448
            public List<int> FindDisappearedNumbers(int[] nums) {
                for (int i = 0; i < nums.Length; i++) {
                    int newIdx = Math.Abs(nums[i]) - 1;
                    if (nums[newIdx] > 0) {
                        nums[newIdx] *= -1;

                    }
                }
                var res = new List<int>();
                for (int i = 0; i < nums.Length; i++) {
                    if (nums[i] > 0) {
                        res.Add(i + 1);
                    }
                }
                return res;
            }

            // #475
            // public int FindRadius(int[] houses, int[] heaters) {
            //     int r = houses.Last();
            //     bool Helper(int[][] heaterRanges) {

            //     }
            //     while (r >= 1) {
            //         if (true) {

            //         } else {
            //             r /= 2;
            //         }
            //     }
            // }

            // #451
            public string FrequencySort(string s) {
                var res = new StringBuilder();
                var dict = new Dictionary<char, int>();
                foreach (var ch in s) {
                    dict[ch] = dict.GetValueOrDefault(ch, 0) + 1;
                }
                var tmp = dict.OrderByDescending(x => x.Value);
                foreach (var (key, val) in tmp) {
                    for (int i = 0; i < val; i++) {
                        res.Append(key);
                    }
                }
                return res.ToString();
            }

            // #453
            public int MinMoves(int[] nums) {
                int n = nums.Length, res = 0, sum = nums.Sum();
                while (true) {
                    if (((n - 1) * res + sum) % n == 0) {
                        break;
                    } else {
                        res++;
                    }
                }
                return res;
            }

            // #506
            public string[] FindRelativeRanks(int[] nums) {
                var dict = new Dictionary<int, string>();
                for (int i = 0; i < nums.Length; i++) {
                    dict[nums[i]] = i.ToString();
                }
                Array.Sort(nums, (x, y) => y - x);
                var res = new string[nums.Length];
                for (int i = 0; i < nums.Length; i++) {
                    if (i == 0) {
                        dict[nums[i]] = "Gold Medal";
                    } else if (i == 1) {
                        dict[nums[i]] = "Silver Medal";
                    } else if (i == 2) {
                        dict[nums[i]] = "Bronze Medal";
                    } else {
                        dict[nums[i]] = (i + 1).ToString();
                    }
                }
                return dict.Values.ToArray();
            }

            // #520
            public bool DetectCapitalUse(string word) {
                if (word.ToUpper() == word) return true;
                if (word.Substring(1).ToLower() == word.Substring(1)) return true;
                return false;
            }

            // #498
            public int[] FindDiagonalOrder(int[][] matrix) {
                if (matrix.Length == 0) {
                    return new int[0];
                }
                var res = new List<int>();
                List<int> Cur = new List<int>();
                int col = matrix.Length;
                int row = matrix[0].Length;

                for (int i = 0; i < col + row - 1; i++) {
                    int j = i < row ? 0 : i - row + 1;
                    int k = i < row ? i : row - 1;
                    while (j < col && k > -1) {
                        Cur.Add(matrix[j++][k--]);
                    }
                    if (i % 2 == 0) {
                        Cur.Reverse();
                    }
                    int[] x = Cur.ToArray();
                    for (int l = 0; l < x.Length; l++) {
                        res.Add(x[l]);
                    }
                    Cur.Clear();
                }
                return res.ToArray();
            }

            // #500
            public string[] FindWords(string[] words) {
                var dict = new Dictionary<char, int> { { 'q', 1 },
                        { 'w', 1 },
                        { 'e', 1 },
                        { 'r', 1 },
                        { 't', 1 },
                        { 'y', 1 },
                        { 'u', 1 },
                        { 'i', 1 },
                        { 'o', 1 },
                        { 'p', 1 },
                        { 'a', 2 },
                        { 's', 2 },
                        { 'd', 2 },
                        { 'f', 2 },
                        { 'g', 2 },
                        { 'h', 2 },
                        { 'j', 2 },
                        { 'k', 2 },
                        { 'l', 2 },
                        { 'z', 3 },
                        { 'x', 3 },
                        { 'c', 3 },
                        { 'v', 3 },
                        { 'b', 3 },
                        { 'n', 3 },
                        { 'm', 3 },
                    };
                var res = new List<string>();
                foreach (var word in words) {
                    var tmp = word.ToLower();
                    if (tmp.All(x => dict[x] == dict[tmp[0]])) {
                        res.Add(word);
                    }
                }
                return res.ToArray();
            }

            // #503
            public int[] NextGreaterElements(int[] nums) {
                int[] res = new int[nums.Length];
                var stack = new Stack<int>();
                for (int i = 2 * nums.Length - 1; i >= 0; --i) {
                    while (stack.Count != 0 && nums[stack.Peek()] <= nums[i % nums.Length]) {
                        stack.Pop();
                    }
                    res[i % nums.Length] = stack.Count == 0 ? -1 : nums[stack.Peek()];
                    stack.Push(i % nums.Length);
                }
                return res;
            }

            // #1046
            class StoneComparer : IComparer {
                public int Compare(object x, object y) {
                    var x1 = (int)x;
                    var y1 = (int)y;
                    // 大顶堆比较器，大于返回-1
                    return x1 > y1 ? -1 : 1;

                }
            }

            public int LastStoneWeight(int[] stones) {
                var heap = new SortedList(new StoneComparer());
                foreach (var stone in stones) {
                    heap.Add(stone, stone);
                }
                while (heap.Count > 1) {
                    var fisrt = (int)heap.GetByIndex(0);
                    heap.RemoveAt(0);
                    var second = (int)heap.GetByIndex(0);
                    heap.RemoveAt(0);
                    var residual = fisrt - second;
                    if (residual > 0) {
                        heap.Add(residual, residual);
                    }
                }
                return heap.Count == 0 ? 0 : (int)heap.GetByIndex(0);
            }

            // #542
            public int[][] UpdateMatrix(int[][] matrix) {
                int m = matrix.Length, n = matrix[0].Length;
                var dirs = new[] { new[] { -1, 0 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { 0, 1 } };
                var res = new int[m][];
                for (int i = 0; i < m; i++) {
                    res[i] = new int[n];
                }
                bool[,] vis = new bool[m, n];
                var queue = new Queue<Tuple<int, int>>();
                for (int i = 0; i < m; ++i) {
                    for (int j = 0; j < n; ++j) {
                        if (matrix[i][j] == 0) {
                            queue.Enqueue(new Tuple<int, int>(i, j));
                            vis[i, j] = true;
                        }
                    }
                }
                while (queue.Count != 0) {
                    (var i, var j) = queue.Dequeue();
                    for (int d = 0; d < 4; ++d) {
                        int ni = i + dirs[d][0];
                        int nj = j + dirs[d][1];
                        if (ni >= 0 && ni < m && nj >= 0 && nj < n && !vis[ni, nj]) {
                            res[ni][nj] = res[i][j] + 1;
                            queue.Enqueue(new Tuple<int, int>(ni, nj));
                            vis[ni, nj] = true;
                        }
                    }
                }

                return res;
            }

            // #525
            public int FindMaxLength(int[] nums) {
                var dict = new Dictionary<int, int>();
                dict[0] = -1;
                int maxlen = 0, count = 0;
                for (int i = 0; i < nums.Length; i++) {
                    count = count + (nums[i] == 1 ? 1 : -1);
                    if (dict.ContainsKey(count)) {
                        maxlen = Math.Max(maxlen, i - dict[count]);
                    } else {
                        dict[count] = i;
                    }
                }
                return maxlen;
            }

            // #413 
            public int NumberOfArithmeticSlices(int[] A) {
                int[] dp = new int[A.Length];
                int sum = 0;
                for (int i = 2; i < dp.Length; i++) {
                    if (A[i] - A[i - 1] == A[i - 1] - A[i - 2]) {
                        dp[i] = 1 + dp[i - 1];
                        sum += dp[i];
                    }
                }
                return sum;

            }

            // #547
            public int FindCircleNum(int[][] M) {
                int Find(int[] parent, int i) {
                    // 寻找根
                    if (parent[i] == -1)
                        return i;
                    return Find(parent, parent[i]);
                }

                void Union(int[] parent, int x, int y) {
                    int xP = Find(parent, x);
                    int yP = Find(parent, y);
                    if (xP != yP)
                        parent[xP] = yP;
                }

                int[] parent = new int[M.Length];
                Array.Fill(parent, -1);
                for (int i = 0; i < M.Length; i++) {
                    for (int j = 0; j < M.Length; j++) {
                        if (M[i][j] == 1 && i != j) {
                            Union(parent, i, j);
                        }
                    }
                }
                int count = 0;
                for (int i = 0; i < parent.Length; i++) {
                    if (parent[i] == -1)
                        count++;
                }
                return count;
            }

            // #239
            public int[] MaxSlidingWindow(int[] nums, int k) {
                int n = nums.Length;
                int[] res = new int[n - k + 1];
                LinkedList<int> deque = new LinkedList<int>();
                for (int i = 0; i < n; i++) {
                    while (deque.Count != 0 && nums[i] >= nums[deque.Last()]) {
                        deque.RemoveLast();
                    }
                    deque.AddLast(i);
                    if (deque.Count != 0 && deque.First() < (i - k + 1)) {
                        deque.RemoveFirst();
                    }
                    if (i >= k - 1) {
                        res[i - k + 1] = nums[deque.First()];
                    }
                }
                return res;
            }

            // #540
            public int SingleNonDuplicate(int[] nums) {
                int left = 0;
                int right = nums.Length - 1;
                while (left < right) {
                    int mid = left + (right - left) / 2;
                    bool halvesAreEven = (right - mid) % 2 == 0;
                    if (nums[mid + 1] == nums[mid]) {
                        if (halvesAreEven) {
                            left = mid + 2;
                        } else {
                            right = mid - 1;
                        }
                    } else if (nums[mid - 1] == nums[mid]) {
                        if (halvesAreEven) {
                            right = mid - 2;
                        } else {
                            left = mid + 1;
                        }
                    } else {
                        return nums[mid];
                    }
                }
                return nums[left];
            }

            // #526
            public int CountArrangement(int n) {
                int res = 0;
                var vis = new bool[n + 1];
                void Helper(int idx) {
                    if (idx == n + 1) res++;
                    for (int i = 1; i <= n; i++) {
                        if (!vis[i] && (idx % i == 0 || i % idx == 0)) {
                            vis[i] = true;
                            Helper(idx + 1);
                            vis[i] = false;
                        }
                    }
                }
                Helper(1);
                return res;
            }

            // #784
            public List<string> LetterCasePermutation(string S) {
                var n = S.Length;
                var path = new StringBuilder();
                var res = new List<string>();
                void Helper(int idx) {
                    if (path.Length == n) {
                        res.Add(path.ToString());
                        return;
                    };
                    var ch = S[idx];
                    if (char.IsLetter(ch)) {
                        path.Append(char.ToLower(ch));
                        Helper(idx + 1);
                        path.Remove(idx, 1);

                        path.Append(char.ToUpper(ch));
                        Helper(idx + 1);
                        path.Remove(idx, 1);
                    } else {
                        path.Append(ch);
                        Helper(idx + 1);
                        path.Remove(idx, 1);
                    }
                }
                Helper(0);
                return res;
            }

            // #830
            public List<List<int>> LargeGroupPositions(string s) {
                var res = new List<List<int>>();
                int n = s.Length;
                int num = 1;
                for (int i = 0; i < n; i++) {
                    if (i == n - 1 || s[i] != s[i + 1]) {
                        if (num >= 3) {
                            res.Add(new List<int> { i - num + 1, i });
                        }
                        num = 1;
                    } else {
                        num++;
                    }
                }
                return res;
            }

            // #797
            public List<List<int>> AllPathsSourceTarget(int[][] graph) {
                var res = new List<List<int>>();
                var path = new List<int> { 0 };
                int n = graph.Length;
                void Helper(int begin) {
                    if (begin == n - 1) {
                        res.Add(path.ToList());
                        return;
                    }
                    foreach (var node in graph[begin]) {
                        path.Add(node);
                        Helper(node);
                        path.RemoveAt(path.Count - 1);
                    }
                }
                Helper(0);
                return res;
            }

            // #1219
            public int GetMaximumGold(int[][] grid) {
                var dirs = new[] { new[] { 0, 1 }, new[] { 0, -1 }, new int[] { 1, 0 }, new[] { -1, 0 } };
                int res = 0;
                int m = grid.Length, n = grid[0].Length;
                var vis = new bool[m, n];

                void Helper(int i, int j, int sum) {
                    if (vis[i, j] || grid[i][j] == 0) {
                        if (sum > res) {
                            res = sum;
                        }
                        return;
                    }
                    sum += grid[i][j];
                    vis[i, j] = true;
                    foreach (var dir in dirs) {
                        int tx = i + dir[0];
                        int ty = j + dir[1];
                        if (tx < 0 || ty < 0 || tx >= m || ty >= n) continue;
                        Helper(tx, ty, sum);
                    }
                    sum -= grid[i][j];
                    vis[i, j] = false;
                }
                for (int i = 0; i < m; i++) {
                    for (int j = 0; j < n; j++) {
                        if (grid[i][j] != 0) {
                            Helper(i, j, 0);
                        }
                    }
                }
                return res;
            }

            // #89
            public List<int> GrayCode(int n) {
                var res = new List<int>();
                res.Add(0);
                int head = 1;
                for (int i = 0; i < n; i++) {
                    for (int j = res.Count - 1; j >= 0; j--)
                        res.Add(head + res[j]);
                    head <<= 1;
                }
                return res;
            }

            // #967
            public int[] NumsSameConsecDiff(int n, int k) {
                // BFS，第一层个数为1，第二层个数为2，依次类推
                var res = new List<int>();
                int depth = 0;
                var queue = new Queue<int>(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

                while (queue.Count != 0) {
                    int count = queue.Count;
                    depth++;
                    if (depth == n) {
                        res = queue.ToList();
                        queue.Clear();
                    } else {
                        for (int i = 0; i < count; i++) {
                            var num = queue.Dequeue();
                            int rem = num % 10;
                            if (rem + k <= 9) queue.Enqueue(num * 10 + rem + k);
                            if (rem - k >= 0 && k != 0) queue.Enqueue(num * 10 + rem - k);
                        }
                    }
                }
                return res.ToArray();
            }

            // #684
            public int[] FindRedundantConnection(int[][] edges) {
                int nodesCount = edges.Length;
                int[] parent = new int[nodesCount + 1];
                for (int i = 1; i <= nodesCount; i++) {
                    parent[i] = i;
                }
                void Union(int x, int y) {
                    int px = Find(x);
                    int py = Find(y);
                    if (px == py) {
                        return;
                    }
                    parent[px] = py;
                }

                int Find(int x) {
                    if (parent[x] == x) {
                        return x;
                    }
                    return Find(parent[x]);
                }

                for (int i = 0; i < nodesCount; i++) {
                    int[] edge = edges[i];
                    int node1 = edge[0], node2 = edge[1];
                    if (Find(node1) != Find(node2)) {
                        Union(node1, node2);
                    } else {
                        return edge;
                    }
                }
                return new int[0];
            }
            // #456
            public bool Find132pattern(int[] nums) {
                if (nums.Length < 3)
                    return false;
                var stack = new Stack<int>();
                int[] min = new int[nums.Length];
                min[0] = nums[0];
                for (int i = 1; i < nums.Length; i++)
                    min[i] = Math.Min(min[i - 1], nums[i]);
                for (int j = nums.Length - 1; j >= 0; j--) {
                    if (nums[j] > min[j]) {
                        while (stack.Count != 0 && stack.Peek() <= min[j])
                            stack.Pop();
                        if (stack.Count != 0 && stack.Peek() < nums[j])
                            return true;
                        stack.Push(nums[j]);
                    }
                }
                return false;
            }

            // #671
            public int FindSecondMinimumValue(TreeNode root) {
                if (root == null) return -1;
                int min = root.val;

                int Helper(TreeNode root) {
                    if (root == null) return -1;
                    if (root.val > min) return root.val;
                    int left = Helper(root.left);
                    int right = Helper(root.right);
                    if (left == -1) return right;
                    if (right == -1) return left;
                    return Math.Min(left, right);
                }

                return Helper(root);
            }

            // #572
            public bool IsSubtree(TreeNode s, TreeNode t) {
                // 返回t是否是s的子树
                bool Check(TreeNode s, TreeNode t) {
                    if (s == null && t == null) {
                        return true;
                    }
                    if (s == null || t == null || s.val != t.val) {
                        return false;
                    }
                    return Check(s.left, t.left) && Check(s.right, t.right);
                }
                bool Helper(TreeNode s, TreeNode t) {
                    if (s == null) {
                        return false;
                    }
                    return Check(s, t) || Helper(s.left, t) || Helper(s.right, t);
                }

                return Helper(s, t);
            }

            // #228
            public List<String> summaryRanges(int[] nums) {
                var res = new List<string>();
                int i = 0;
                for (int j = 0; j < nums.Length; j++) {
                    if (j + 1 == nums.Length || nums[j] + 1 != nums[j + 1]) {
                        var sb = new StringBuilder();
                        sb.Append(nums[i]);
                        if (i != j) {
                            sb.Append("->").Append(nums[j]);
                        }
                        res.Add(sb.ToString());
                        i = j + 1;
                    }
                }
                return res;
            }

            // #1202
            public string SmallestStringWithSwaps(string s, List<List<int>> pairs) {
                if (pairs.Count == 0) {
                    return s;
                }
                int len = s.Length;
                var parent = new int[len];

                // 这里的并查集没有优化，超时
                int Find(int x) {
                    // 寻找根
                    if (parent[x] == x)
                        return x;
                    return Find(parent[x]);
                }

                void Union(int x, int y) {
                    int xP = Find(x);
                    int yP = Find(y);
                    if (xP != yP)
                        parent[xP] = yP;
                }

                for (int i = 0; i < len; i++) {
                    parent[i] = i;
                }

                foreach (var pair in pairs) {
                    var idx1 = pair[0];
                    var idx2 = pair[1];
                    Union(idx1, idx2);
                }

                var dict = new Dictionary<int, List<char>>();
                for (int i = 0; i < s.Length; i++) {
                    int p = Find(i);
                    if (!dict.ContainsKey(p)) {
                        dict[p] = new List<char>();
                    }
                    dict[p].Add(s[i]);
                }

                foreach (var (key, val) in dict) {
                    val.Sort();
                }

                var sb = new StringBuilder();
                for (int i = 0; i < s.Length; i++) {
                    int x = Find(i);
                    var list = dict[x];
                    sb.Append(list[0]);
                    list.RemoveAt(0);
                }
                return sb.ToString();
            }

            // #1018
            public List<bool> PrefixesDivBy5(int[] A) {
                var list = new List<bool>();
                int prefix = 0;
                int length = A.Length;
                for (int i = 0; i < length; i++) {
                    prefix = ((prefix << 1) + A[i]) % 5;
                    list.Add(prefix == 0);
                }
                return list;
            }

            // #1232
            public bool CheckStraightLine(int[][] coordinates) {
                int deltaX = coordinates[0][0], deltaY = coordinates[0][1];
                int n = coordinates.Length;
                for (int i = 0; i < n; i++) {
                    coordinates[i][0] -= deltaX;
                    coordinates[i][1] -= deltaY;
                }
                int A = coordinates[1][1], B = -coordinates[1][0];
                for (int i = 2; i < n; i++) {
                    int x = coordinates[i][0], y = coordinates[i][1];
                    if (A * x + B * y != 0) {
                        return false;
                    }
                }
                return true;
            }

            // #628
            public int MaximumProduct(int[] nums) {
                Array.Sort(nums);
                int n = nums.Length;
                return Math.Max(nums[0] * nums[1] * nums[n - 1], nums[n - 3] * nums[n - 2] * nums[n - 1]);
            }

            // #989
            public List<int> AddToArrayForm(int[] A, int K) {
                var res = new List<int>();
                int n = A.Length;
                for (int i = n - 1; i >= 0; --i) {
                    int sum = A[i] + K % 10;
                    K /= 10;
                    if (sum >= 10) {
                        K++;
                        sum -= 10;
                    }
                    res.Add(sum);
                }
                for (; K > 0; K /= 10) {
                    res.Add(K % 10);
                }
                res.Reverse();
                return res;
            }

            // #674
            public int FindLengthOfLCIS(int[] nums) {
                int ans = 0;
                int n = nums.Length;
                int start = 0;
                for (int i = 0; i < n; i++) {
                    if (i > 0 && nums[i] <= nums[i - 1]) {
                        start = i;
                    }
                    ans = Math.Max(ans, i - start + 1);
                }
                return ans;
            }

            // #581
            public int FindUnsortedSubarray(int[] nums) {
                var stack = new Stack<int>();
                int l = nums.Length, r = 0;
                for (int i = 0; i < nums.Length; i++) {
                    while (stack.Count != 0 && nums[stack.Peek()] > nums[i]) {
                        l = Math.Min(l, stack.Pop());
                    }
                    stack.Push(i);
                }

                for (int i = nums.Length - 1; i >= 0; i--) {
                    while (stack.Count != 0 && nums[stack.Peek()] < nums[i]) {
                        r = Math.Max(r, stack.Pop());
                    }
                    stack.Push(i);
                }
                return r - l > 0 ? r - l + 1 : 0;
            }

            // #554
            public int LeastBricks(List<List<int>> wall) {
                var dict = new Dictionary<int, int>();
                foreach (var row in wall) {
                    int sum = 0;
                    for (int i = 0; i < row.Count - 1; i++) {
                        sum += row[i];
                        dict[sum] = dict.GetValueOrDefault(sum, 0) + 1;
                    }
                }
                return dict.Count > 0 ? wall.Count - dict.Values.Max() : wall.Count;
            }

            // #1128
            public int NumEquivDominoPairs(int[][] dominoes) {
                int[] num = new int[100];
                int ret = 0;
                foreach (var domino in dominoes) {
                    int val = domino[0] < domino[1] ? domino[0] * 10 + domino[1] : domino[1] * 10 + domino[0];
                    ret += num[val];
                    num[val]++;
                }
                return ret;
            }

            // #724
            public int PivotIndex(int[] nums) {
                if (nums == null || nums.Length < 3) return -1;
                int leftSum = 0, rightSum = 0, sum = nums.Sum();
                for (int i = 0, l = nums.Length; i < l; i++) {
                    if (leftSum == (sum - leftSum - nums[i]))
                        return i;
                    leftSum += nums[i];
                }
                return -1;
            }

            // #394
            public String DecodeString(String s) {
                var res = new StringBuilder();
                int num = 0;
                var numStack = new Stack<int>();
                var strStack = new Stack<string>();
                foreach (var ch in s) {
                    if (ch == '[') {
                        numStack.Push(num);
                        strStack.Push(res.ToString());
                        num = 0;
                        res.Clear();
                    } else if (ch == ']') {
                        StringBuilder tmp = new StringBuilder();
                        int curNum = numStack.Pop();
                        for (int i = 0; i < curNum; i++) tmp.Append(res.ToString());
                        // res保存]和上一个[之间的字符串
                        res = new StringBuilder(strStack.Pop() + tmp.ToString());
                    } else if (ch >= '0' && ch <= '9') num = num * 10 + ch - '0';
                    else res.Append(ch);
                }
                return res.ToString();
            }

            // #657
            public bool JudgeCircle(string moves) {
                int x = 0, y = 0;
                foreach (var ch in moves) {
                    switch (ch) {
                        case 'R':
                            x--;
                            break;
                        case 'L':
                            x++;
                            break;
                        case 'U':
                            y--;
                            break;
                        case 'D':
                            y++;
                            break;
                        default:
                            break;
                    }
                }
                return x == 0 && y == 0;
            }

            // #888
            public int[] FairCandySwap(int[] A, int[] B) {
                int diff = A.Sum() - B.Sum();
                var set = new HashSet<int>(A);
                foreach (var num in B) {
                    if (set.Contains((diff + 2 * num) / 2))
                        return new int[] {
                            (diff + 2 * num) / 2, num
                        };
                }
                return new int[0];
            }

            // #661
            public int[][] ImageSmoother(int[][] M) {
                int R = M.Length, C = M[0].Length;
                var ans = new int[R][];
                for (int r = 0; r < R; ++r) {
                    ans[r] = new int[C];
                    for (int c = 0; c < C; ++c) {
                        int count = 0;
                        for (int nr = r - 1; nr <= r + 1; ++nr) {
                            for (int nc = c - 1; nc <= c + 1; ++nc) {
                                if (0 <= nr && nr < R && 0 <= nc && nc < C) {
                                    ans[r][c] += M[nr][nc];
                                    count++;
                                }
                            }
                        }
                        ans[r][c] /= count;
                    }
                }
                return ans;
            }

            // #665
            public bool CheckPossibility(int[] nums) {
                int n = nums.Length;
                if (n <= 1) return true;
                int down = 0;
                for (int i = 1; i < n; i++) {
                    if (nums[i] < nums[i - 1]) {
                        down++;
                        if (down > 1) {
                            return false;
                        }
                        if (i > 1 && i < n - 1 && nums[i - 1] > nums[i + 1] && nums[i - 2] > nums[i]) {
                            return false;
                        }
                    }
                }
                return true;
            }

            // #673
            public int FindNumberOfLIS(int[] nums) {
                int[] dp = new int[nums.Length];
                int[] counter = new int[nums.Length];
                Array.Fill(dp, 1);
                Array.Fill(counter, 1);
                int max = -1;
                for (int i = 0; i < nums.Length; i++) {
                    for (int j = 0; j < i; j++) {
                        if (nums[i] > nums[j]) {
                            if (dp[j] + 1 > dp[i]) {
                                dp[i] = Math.Max(dp[i], dp[j] + 1);
                                counter[i] = counter[j];
                            } else if (dp[j] + 1 == dp[i]) {
                                counter[i] += counter[j];

                            }
                        }
                    }
                    max = Math.Max(max, dp[i]);
                }
                int res = 0;
                for (int i = 0; i < nums.Length; i++) {
                    if (dp[i] == max)
                        res += counter[i];
                }
                return res;
            }

            // #424
            public int CharacterReplacement(string s, int k) {
                //存放窗口内各大写字母出现的最大次数
                var t = new int[26];
                //左右指针
                int left = 0, right = 0;
                //窗口内出现过的字母最大重复次数
                int maxlen = 0;
                //左指针不变，右指针右移时，窗口扩展
                while (right < s.Length) {
                    //右指针所在字母的出现次数加一
                    t[s[right] - 'A']++;
                    //更新字母最大重复次数
                    maxlen = Math.Max(maxlen, t[s[right] - 'A']);
                    //右指针右移指向下一个字母，方便计算窗口长度
                    right++;
                    //扩展后的窗口长度大于字母最大重复次数加允许更改次数
                    if (right - left > maxlen + k) {
                        //扩展后的窗口过大不满足要求，需要窗口滑动
                        //左指针所指的字母将离开窗口，出现次数减一
                        t[s[left] - 'A']--;
                        //窗口不能扩展，左指针右移，窗口滑动
                        left++;
                    }
                }
                //窗口移动到最后，返回长度
                return right - left;
            }

            // #643
            public double FindMaxAverage(int[] nums, int k) {
                int sum = 0;
                int n = nums.Length;
                for (int i = 0; i < k; i++) {
                    sum += nums[i];
                }
                int maxSum = sum;
                for (int i = k; i < n; i++) {
                    sum = sum - nums[i - k] + nums[i];
                    maxSum = Math.Max(maxSum, sum);
                }
                return 1.0 * maxSum / k;
            }

            // #1208
            public int EqualSubstring(string s, string t, int maxCost) {
                var window = 0;
                var res = 0;
                int left = 0, right = 0;
                var diff = new int[s.Length];
                for (int i = 0; i < s.Length; i++) {
                    diff[i] = Math.Abs(s[i] - t[i]);
                }
                while (right < s.Length) {
                    var ch = s[right];
                    window += diff[right];
                    right++;
                    while (window > maxCost) {
                        window -= diff[left];
                        left++;
                    }
                    res = Math.Max(res, right - left);
                }
                return res;
            }

            // #1423
            public int MaxScore(int[] cardPoints, int k) {
                int n = cardPoints.Length;
                int windowSize = n - k;
                int sum = 0;
                for (int i = 0; i < windowSize; ++i) {
                    sum += cardPoints[i];
                }
                int minSum = sum;
                for (int i = windowSize; i < n; ++i) {
                    sum += cardPoints[i] - cardPoints[i - windowSize];
                    minSum = Math.Min(minSum, sum);
                }
                return cardPoints.Sum() - minSum;
            }

            // #700
            public TreeNode SearchBST(TreeNode root, int val) {
                TreeNode Helper(TreeNode node) {
                    if (node == null || node.val == val) return node;
                    return val < node.val ? Helper(node.left) : Helper(node.right);
                }
                return Helper(root);
            }

            // #978
            public int MaxTurbulenceSize(int[] arr) {
                int res = 1;
                int left = 0, right = 0;
                var window = new List<int>();
                while (right < arr.Length - 1) {
                    if (left == right) {
                        if (arr[left] == arr[left + 1]) {
                            left++;
                        }
                        right++;
                    } else {
                        if (arr[right - 1] < arr[right] && arr[right] > arr[right + 1]) {
                            right++;
                        } else if (arr[right - 1] > arr[right] && arr[right] < arr[right + 1]) {
                            right++;
                        } else {
                            left = right;
                        }
                    }
                    res = Math.Max(res, right - left + 1);
                }
                return res;
            }

            // #670
            public int MaximumSwap(int num) {
                var nums = num.ToString().ToArray();
                int[] idx = new int[nums.Length];
                int maxIdx = nums.Length - 1;
                for (int i = nums.Length - 1; i >= 0; i--) {
                    if (nums[i] > nums[maxIdx]) maxIdx = i;
                    idx[i] = maxIdx;
                }
                for (int i = 0; i < nums.Length; i++) {
                    if (nums[i] != nums[idx[i]]) {
                        var temp = nums[i];
                        nums[i] = nums[idx[i]];
                        nums[idx[i]] = temp;
                        break;
                    }
                }
                return int.Parse(nums);
            }

            // #678
            public bool CheckValidString(string s) {
                var leftStack = new Stack<int>();
                var starStack = new Stack<int>();
                for (int i = 0; i < s.Length; i++) {
                    if (s[i] == '(') {
                        leftStack.Push(i);
                    } else if (s[i] == '*') {
                        starStack.Push(i);
                    } else {
                        if (leftStack.Count != 0) {
                            leftStack.Pop();
                        } else if (starStack.Count != 0) {
                            starStack.Pop();
                        } else {
                            return false;
                        }
                    }
                }
                if (leftStack.Count > starStack.Count) return false;
                while (leftStack.Count != 0 & starStack.Count != 0) {
                    if (leftStack.Peek() > starStack.Peek())
                        return false;
                    else {
                        leftStack.Pop();
                        starStack.Pop();
                    }
                }
                if (leftStack.Count == 0) return true;
                return false;
            }

            // #992
            public int SubarraysWithKDistinct(int[] A, int K) {
                int Helper(int[] A, int K) {
                    int len = A.Length;
                    int[] freq = new int[len + 1];
                    int left = 0;
                    int right = 0;
                    int count = 0;
                    int res = 0;
                    while (right < len) {
                        if (freq[A[right]] == 0) {
                            count++;
                        }
                        freq[A[right]]++;
                        right++;

                        while (count > K) {
                            freq[A[left]]--;
                            if (freq[A[left]] == 0) {
                                count--;
                            }
                            left++;
                        }
                        res += right - left;
                    }
                    return res;
                }
                return Helper(A, K) - Helper(A, K - 1);
            }

            // #567
            public bool CheckInclusion(string s1, string s2) {
                if (s1.Length > s2.Length) return false;
                var counter1 = new int[26];
                var counter2 = new int[26];
                for (int i = 0; i < s1.Length; i++) {
                    counter1[s1[i] - 'a']++;
                    counter2[s2[i] - 'a']++;
                }
                if (Enumerable.SequenceEqual(counter1, counter2)) {
                    return true;
                }
                for (int i = s1.Length; i < s2.Length; i++) {
                    counter2[s2[i] - 'a']++;
                    counter2[s2[i - s1.Length] - 'a']--;
                    if (Enumerable.SequenceEqual(counter1, counter2)) {
                        return true;
                    };
                }
                return false;
            }

            // #692

            class MaxHeapComparer : IComparer {
                public int Compare(object item1, object item2) {
                    var x1 = (KeyValuePair<string, int>)item1;
                    var x2 = (KeyValuePair<string, int>)item2;
                    // 对比较器的理解，本来的顺序是x，y；如果保持这个顺序就返回-1，交换顺序就返回1，什么都不做就返回0；
                    return x1.Value == x2.Value ? x1.Key.CompareTo(x2.Key) : x1.Value >= x2.Value ? -1 : 1;
                }
            }
            public List<string> TopKFrequent(string[] words, int k) {
                var countDict = words.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
                var heap = new SortedList(new MaxHeapComparer());
                foreach (var item in countDict) {
                    heap.Add(item, 0);
                    if (heap.Count > k) {
                        heap.RemoveAt(heap.Count - 1);
                    }
                }
                var res = new List<string>();
                foreach (var item in heap.GetKeyList()) {
                    res.Add(((KeyValuePair<string, int>)item).Key);
                }
                return res;
            }

            // #733
            public int[][] FloodFill(int[][] image, int sr, int sc, int newColor) {
                if (image[sr][sc] == newColor) return image;
                int[] dx = { 0, 1, 0, -1 };
                int[] dy = { 1, 0, -1, 0 };
                int m = image.Length, n = image[0].Length, oldColor = image[sr][sc];
                var stack = new Stack<Tuple<int, int>>();
                stack.Push(new Tuple<int, int>(sr, sc));
                while (stack.Count != 0) {
                    var (curRow, curCol) = stack.Pop();
                    image[curRow][curCol] = newColor;
                    for (int i = 0; i < 4; i++) {
                        var tx = curRow + dx[i];
                        var ty = curCol + dy[i];
                        if (tx >= 0 && tx < m && ty >= 0 && ty < n && image[tx][ty] == oldColor) {
                            stack.Push(new Tuple<int, int>(tx, ty));
                        }
                    }
                }
                return image;
            }

            // #739
            public int[] DailyTemperatures(int[] T) {
                var res = new int[T.Length];
                var monoStack = new Stack<int>();
                for (int i = 0; i < T.Length; i++) {
                    while (monoStack.Count != 0 && T[i] > T[monoStack.Peek()]) {
                        var prevIdx = monoStack.Pop();
                        res[prevIdx] = i - prevIdx;
                    }
                    monoStack.Push(i);
                }
                return res;
            }

            // #747
            public int DominantIndex(int[] nums) {
                int maxIdx = 0;
                for (int i = 0; i < nums.Length; ++i) {
                    if (nums[i] > nums[maxIdx])
                        maxIdx = i;
                }
                for (int i = 0; i < nums.Length; ++i) {
                    if (maxIdx != i && nums[maxIdx] < 2 * nums[i])
                        return -1;
                }
                return maxIdx;
            }

            // #561
            public int ArrayPairSum(int[] nums) {
                Array.Sort(nums);
                int max = 0;
                for (int i = 0; i < nums.Length; i += 2) {
                    max += nums[i];
                }
                return max;
            }

            // #566
            public int[][] MatrixReshape(int[][] nums, int r, int c) {
                int m = nums.Length;
                int n = nums[0].Length;
                if (m * n != r * c) {
                    return nums;
                }

                int[][] ans = new int[r][];
                for (int i = 0; i < r; i++) {
                    ans[i] = new int[c];
                }
                for (int x = 0; x < m * n; ++x) {
                    ans[x / c][x % c] = nums[x / n][x % n];
                }
                return ans;
            }

            // #995
            public int MinKBitFlips(int[] A, int K) {
                int res = 0;
                var dequeue = new LinkedList<int>();
                for (int i = 0; i < A.Length; i++) {
                    if (dequeue.Count > 0 && i > dequeue.First() + K - 1) {
                        dequeue.RemoveFirst();
                    }
                    if (dequeue.Count % 2 == A[i]) {
                        if (i + K > A.Length) return -1;
                        dequeue.AddLast(i);
                        res += 1;
                    }
                }
                return res;
            }

            // #1004
            public int LongestOnes(int[] A, int K) {
                int left = 0, right = 0;
                int res = 0;
                int zeroCount = 0;
                while (right < A.Length) {
                    if (A[right] == 0) zeroCount++;
                    right++;
                    while (zeroCount > K) {
                        if (A[left] == 0) zeroCount--;
                        left++;
                    }
                    res = Math.Max(res, right - left + 1);
                }
                return res;
            }

            // #697
            public int FindShortestSubArray(int[] nums) {
                var dict = new Dictionary<int, int[]>();
                for (int i = 0; i < nums.Length; i++) {
                    if (dict.ContainsKey(nums[i])) {
                        dict[nums[i]][0]++;
                        dict[nums[i]][2] = i;
                    } else {
                        dict[nums[i]] = new int[] { 1, i, i };
                    }
                }
                int maxCount = 0, minLen = 0;
                foreach (var (key, val) in dict) {
                    if (maxCount < val[0]) {
                        maxCount = val[0];
                        minLen = val[2] - val[1] + 1;
                    } else if (maxCount == val[0]) {
                        if (minLen > val[2] - val[1] + 1) {
                            minLen = val[2] - val[1] + 1;
                        }
                    }
                }
                return minLen;
            }

            // #735
            // public int[] AsteroidCollision(int[] asteroids) {
            //     var stack = new Stack<int>();
            //     foreach (var asteriod in asteroids) {
            //         if (asteriod > 0) {
            //             stack.Push(asteriod);
            //         } else if (asteriod < 0) {
            //             while (stack.Count != 0 && (stack.Peek() > 0 && stack.Peek() < -asteriod)) {
            //                 stack.Pop();
            //             }
            //         }
            //     }
            // }

            // #1438
            public int LongestSubarray(int[] nums, int limit) {
                int left = 0, right = 0, n = nums.Length;
                var max = new LinkedList<int>();
                var min = new LinkedList<int>();
                while (right < n) {
                    while (max.Count > 0 && nums[max.Last()] <= nums[right]) max.RemoveLast();
                    while (min.Count > 0 && nums[min.Last()] >= nums[right]) min.RemoveLast();
                    max.AddLast(right);
                    min.AddLast(right);
                    right++;
                    if (max.First() < left) max.RemoveFirst();
                    if (min.First() < left) min.RemoveFirst();
                    if (nums[max.First()] - nums[min.First()] > limit) left++;
                }
                return right - left;
            }

            // #766
            public bool IsToeplitzMatrix(int[][] matrix) {
                int m = matrix.Length, n = matrix[0].Length;
                for (int i = 1; i < m; i++) {
                    for (int j = 1; j < n; j++) {
                        if (matrix[i][j] != matrix[i - 1][j - 1]) {
                            return false;
                        }
                    }
                }
                return true;
            }

            // #1052
            public int MaxSatisfied(int[] customers, int[] grumpy, int X) {
                int n = customers.Length, sum = 0, window = 0, res = 0;
                for (int i = 0; i < n; i++) {
                    sum += customers[i] * (1 - grumpy[i]);
                }
                for (int i = 0; i < X; i++) {
                    window += customers[i] * grumpy[i];
                }
                for (int i = X; i < n; i++) {
                    window = window + customers[i] * grumpy[i] - customers[i - X] * grumpy[i - X];
                    res = Math.Max(res, window);
                }
                return sum + res;
            }

            // #832
            public int[][] FlipAndInvertImage(int[][] A) {
                int n = A.Length;
                for (int i = 0; i < n; i++) {
                    int left = 0, right = n - 1;
                    while (left < right) {
                        if (A[i][left] == A[i][right]) {
                            A[i][left] ^= 1;
                            A[i][right] ^= 1;
                        }
                        left++;
                        right--;
                    }
                    if (left == right) {
                        A[i][left] ^= 1;
                    }
                }
                return A;
            }

            // #704
            public int Search(int[] nums, int target) {
                int left = 0, right = nums.Length;
                while (left < right) {
                    int mid = left + (right - left) / 2;
                    if (nums[mid] == target) {
                        return mid;
                    } else if (nums[mid] < target) {
                        left = mid + 1;
                    } else {
                        right = mid;
                    }
                }
                return -1;
            }

            // #718
            public int FindLength(int[] A, int[] B) {
                int n = A.Length, m = B.Length;
                int[,] dp = new int[n + 1, m + 1];
                int ans = 0;
                for (int i = 1; i <= n; i++) {
                    for (int j = 1; j <= m; j++) {
                        dp[i, j] = A[i - 1] == B[j - 1] ? dp[i - 1, j - 1] + 1 : 0;
                        ans = Math.Max(ans, dp[i, j]);
                    }
                }
                return ans;
            }

            // #867
            public int[][] Transpose(int[][] matrix) {
                int m = matrix.Length, n = matrix[0].Length;
                int[][] transposed = new int[n][];
                for (int i = 0; i < n; i++) {
                    transposed[i] = new int[m];
                }
                for (int i = 0; i < m; i++) {
                    for (int j = 0; j < n; j++) {
                        transposed[j][i] = matrix[i][j];
                    }
                }
                return transposed;
            }

            // #781
            public int NumRabbits(int[] answers) {
                int res = 0;
                var dict = new Dictionary<int, int>();
                foreach (var answer in answers) {
                    if (answer == 0) {
                        res += 1;
                    } else {
                        if (!dict.ContainsKey(answer)) {
                            dict[answer] = answer;
                            res += (answer + 1);
                        } else {
                            dict[answer]--;
                            if (dict[answer] == 0) {
                                dict.Remove(answer);
                            }
                        }
                    }
                }
                return res;
            }

            // #395
            public int LongestSubstring(String s, int k) {
                int ret = 0;
                int n = s.Length;
                for (int t = 1; t <= 26; t++) {
                    int l = 0, r = 0;
                    int[] cnt = new int[26];
                    int tot = 0;
                    int less = 0;
                    while (r < n) {
                        cnt[s[r] - 'a']++;
                        if (cnt[s[r] - 'a'] == 1) {
                            tot++;
                            less++;
                        }
                        if (cnt[s[r] - 'a'] == k) {
                            less--;
                        }

                        while (tot > t) {
                            cnt[s[l] - 'a']--;
                            if (cnt[s[l] - 'a'] == k - 1) {
                                less++;
                            }
                            if (cnt[s[l] - 'a'] == 0) {
                                tot--;
                                less--;
                            }
                            l++;
                        }
                        if (less == 0) {
                            ret = Math.Max(ret, r - l + 1);
                        }
                        r++;
                    }
                }
                return ret;
            }

            // #788
            public int RotatedDigits(int N) {
                bool Helper(int n, bool flag) {
                    if (n == 0) return flag;

                    int d = n % 10;
                    if (d == 3 || d == 4 || d == 7) return false;
                    if (d == 0 || d == 1 || d == 8) return Helper(n / 10, flag);
                    return Helper(n / 10, true);
                }
                int ans = 0;
                for (int n = 1; n <= N; ++n)
                    if (Helper(n, false)) ans++;
                return ans;
            }

            // #
            public bool IsMonotonic(int[] A) {
                bool inc = true, dec = true;
                int n = A.Length;
                for (int i = 0; i < n - 1; ++i) {
                    if (A[i] > A[i + 1]) {
                        inc = false;
                    }
                    if (A[i] < A[i + 1]) {
                        dec = false;
                    }
                }
                return inc || dec;
            }

            // #754
            public int ReachNumber(int target) {
                target = Math.Abs(target);
                int k = 0;
                while (target > 0)
                    target -= ++k;
                return target % 2 == 0 ? k : k + 1 + k % 2;
            }

            // #303
            class NumArray {
                int[] sums;
                public NumArray(int[] nums) {
                    int n = nums.Length;
                    sums = new int[n + 1];
                    for (int i = 0; i < n; i++) {
                        sums[i + 1] = sums[i] + nums[i];
                    }
                }

                public int SumRange(int i, int j) {
                    return sums[j + 1] - sums[i];
                }
            }

            // #799
            public double ChampagneTower(int poured, int query_row, int query_glass) {
                var A = new double[102, 102];
                A[0, 0] = (double)poured;
                for (int r = 0; r <= query_row; ++r) {
                    for (int c = 0; c <= r; ++c) {
                        double q = (A[r, c] - 1.0) / 2.0;
                        if (q > 0) {
                            A[r + 1, c] += q;
                            A[r + 1, c + 1] += q;
                        }
                    }
                }
                return Math.Min(1, A[query_row, query_glass]);
            }

            // #848
            public string shiftingLetters(string S, int[] shifts) {
                var res = new char[S.Length];
                var times = 0;
                for (int i = shifts.Length - 1; i >= 0; i--) {
                    times = (times + shifts[i]) % 26;
                    var idx = S[i] - 'a';
                    res[i] = (char)((idx + times) % 26 + 97);
                }
                return new string(res);
            }

            // #338
            public int[] CountBits(int num) {
                var res = new int[num + 1];
                res[0] = 0;
                for (int i = 0; i <= num; i++) {
                    if (i % 2 == 1) {
                        res[i] = res[i - 1] + 1;
                    } else {
                        res[i] = res[i / 2];
                    }
                }
                return res;
            }

            // #415
            public string AddStrings(string num1, string num2) {
                int carry = 0, i = num1.Length - 1, j = num2.Length - 1;
                var res = new StringBuilder();
                while (i >= 0 || j >= 0 || carry != 0) {
                    int x = i >= 0 ? num1[i] - '0' : 0;
                    int y = j >= 0 ? num2[j] - '0' : 0;
                    int tmp = x + y + carry;
                    res.Append(tmp % 10);
                    carry = tmp / 10;
                    i--;
                    j--;
                }
                return new string(res.ToString().Reverse().ToArray());
            }

            // #179
            public string LargestNumber(int[] nums) {
                var numStrs = nums.Select(x => x.ToString()).ToArray();
                Array.Sort(numStrs, (a, b) => {
                    var order1 = a + b;
                    var order2 = b + a;
                    return order2.CompareTo(order1);
                });
                if (numStrs[0].Equals("0")) return "0";
                var res = new StringBuilder();
                foreach (var numStr in numStrs) {
                    res.Append(numStr);
                }
                return res.ToString();
            }

            // #419
            public int CountBattleships(char[][] board) {
                int res = 0;
                if (board.Length == 0) return 0;
                for (int i = 0; i < board.Length; i++) {
                    for (int j = 0; j < board[0].Length; j++) {
                        if (board[i][j] == 'X' && (i == 0 || board[i - 1][j] == '.') && (j == 0 || board[i][j - 1] == '.')) res++;
                    }
                }
                return res;
            }

            // #200
            public int NumIslands(char[][] grid) {
                int m = grid.Length;
                if (m == 0) return 0;

                int n = grid[0].Length;
                void Helper(int r, int c) {
                    grid[r][c] = '0';
                    if (r - 1 >= 0 && grid[r - 1][c] == '1') Helper(r - 1, c);
                    if (r + 1 < m && grid[r + 1][c] == '1') Helper(r + 1, c);
                    if (c - 1 >= 0 && grid[r][c - 1] == '1') Helper(r, c - 1);
                    if (c + 1 < n && grid[r][c + 1] == '1') Helper(r, c + 1);
                }

                int res = 0;
                for (int r = 0; r < m; ++r) {
                    for (int c = 0; c < n; ++c) {
                        if (grid[r][c] == '1') {
                            res++;
                            Helper(r, c);
                        }
                    }
                }
                return res;
            }

            // #240
            public bool SearchMatrix_2(int[][] matrix, int target) {
                int row = matrix.Length - 1;
                int col = 0;
                while (row >= 0 && col < matrix[0].Length) {
                    if (matrix[row][col] > target) {
                        row--;
                    } else if (matrix[row][col] < target) {
                        col++;
                    } else {
                        return true;
                    }
                }
                return false;
            }

            // #253
            class MinMeetingRoomsComparer : IComparer {
                public int Compare(object item1, object item2) {
                    var x = (int)item1;
                    var y = (int)item2;
                    // 比较器，原顺序-1，交换顺序1，不做0
                    return x <= y ? -1 : 1;
                }
            }
            public int MinMeetingRooms(int[][] intervals) {
                if (intervals.Length == 0) return 0;
                // 按照会议开始时间升序排列，最小堆中记录每个房间的结束之间。这样堆顶房间的结束时间是最小的，当有新的会议到来时，直接选择最早结束的房间即可。
                Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
                var heap = new SortedList(new MinMeetingRoomsComparer());
                heap.Add(intervals[0][1], 0);
                for (int i = 1; i < intervals.Length; i++) {
                    if (intervals[i][0] >= (int)heap.GetKey(0)) {
                        heap.RemoveAt(0);
                    }
                    heap.Add(intervals[i][1], 0);
                }
                return heap.Count;
            }

            // #139
            public bool WordBreak(string s, IList<string> wordDict) {
                var wordDictSet = new HashSet<string>(wordDict);

                var dp = new bool[s.Length + 1];
                dp[0] = true;
                for (int i = 1; i <= s.Length; ++i) {
                    for (int j = 0; j < i; ++j) {
                        if (dp[j] && wordDictSet.Contains(s.Substring(j, i - j))) {
                            dp[i] = true;
                            break;
                        }
                    }
                }
                return dp[s.Length];
            }

            // #277
            public int FindCelebrity(int n) {
                bool Knows(int i, int j) {
                    return true;
                }

                int candidate = 0;
                for (int i = 0; i < n; i++) {
                    if (Knows(candidate, i)) {
                        candidate = i;
                    }
                }
                for (int i = 0; i < n; i++) {
                    if (i != candidate) {
                        if (!Knows(i, candidate)) return -1;
                        if (Knows(candidate, i)) return -1;
                    }
                }
                return candidate;
            }

            // #165
            public int CompareVersion(string version1, string version2) {
                var nums1 = version1.Split('.').Select(x => int.Parse(x)).ToArray();
                var nums2 = version2.Split('.').Select(x => int.Parse(x)).ToArray();
                int m = nums1.Length, n = nums2.Length;
                int i1, i2;
                for (int i = 0; i < Math.Max(m, n); i++) {
                    i1 = i < m ? nums1[i] : 0;
                    i2 = i < n ? nums2[i] : 0;
                    if (i1 != i2) {
                        return i1 > i2 ? 1 : -1;
                    }
                }
                return 0;
            }

            // #12
            public String IntToRoman(int num) {
                var values = new[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
                var symbols = new[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
                var res = new StringBuilder();
                for (int i = 0; i < values.Length && num >= 0; i++) {
                    while (values[i] <= num) {
                        num -= values[i];
                        res.Append(symbols[i]);
                    }
                }
                return res.ToString();
            }

            // #50
            public double MyPow(double x, int n) {
                double QuickMul(double x, long N) {
                    double ans = 1.0;
                    double xContribute = x;
                    while (N > 0) {
                        if (N % 2 == 1) {
                            ans *= xContribute;
                        }
                        xContribute *= xContribute;
                        N /= 2;
                    }
                    return ans;
                }
                // 分别在x的二进制表示为1的地方乘上对应贡献
                long N = n;
                return N >= 0 ? QuickMul(x, N) : 1.0 / QuickMul(x, -N);
            }

            // #91
            public int NumDecodings(string s) {
                if (s[0] == '0') return 0;
                var dp = new int[s.Length + 1];
                dp[0] = dp[1] = 1;
                for (int i = 1; i < s.Length; i++) {
                    if (s[i] == '0') {
                        if (s[i - 1] == '1' || s[i - 1] == '2') {
                            dp[i + 1] = dp[i - 1];
                        } else {
                            return 0;
                        }
                    } else if (s[i - 1] == '1' || (s[i - 1] == '2' && s[i] >= '1' && s[i] <= '6')) {
                        dp[i + 1] = dp[i] + dp[i - 1];
                    } else {
                        dp[i + 1] = dp[i];
                    }
                }
                return dp.Last();
            }

            // #131
            public List<List<string>> Partition(string s) {
                int n = s.Length;
                var mem = new int[n, n];
                var res = new List<List<string>>();
                var path = new List<string>();

                int IsPalindrome(int i, int j) {
                    if (mem[i, j] != 0) {
                        return mem[i, j];
                    }
                    if (i >= j) {
                        mem[i, j] = 1;
                    } else if (s[i] == s[j]) {
                        mem[i, j] = IsPalindrome(i + 1, j - 1);
                    } else {
                        mem[i, j] = -1;
                    }
                    return mem[i, j];
                }

                void Helper(int idx) {
                    if (idx == n) {
                        res.Add(path.ToList());
                        return;
                    }
                    for (int i = idx; i < n; i++) {
                        if (IsPalindrome(idx, i) == 1) {
                            path.Add(s.Substring(idx, i - idx + 1));
                            Helper(i + 1);
                            path.RemoveAt(path.Count - 1);
                        }
                    }
                }

                Helper(0);
                return res;
            }

            // #42
            public int Trap(int[] height) {
                var monoStack = new Stack<int>();
                var res = 0;
                for (int i = 0; i < height.Length; i++) {
                    while (monoStack.Count != 0 && height[i] > height[monoStack.Peek()]) {
                        var top = monoStack.Pop();
                        if (monoStack.Count == 0) break;
                        int distance = i - monoStack.Peek() - 1;
                        // i是右边第一个比top高的，Pop之后的Peek是左边第一个比top高的
                        int relaHeight = Math.Min(height[i], height[monoStack.Peek()]) - height[top];
                        res += (distance * relaHeight);
                    }
                    monoStack.Push(i);
                }
                return res;
            }

            // #703
            public class KthLargest {
                class KthLargestComparer : IComparer {
                    public int Compare(object item1, object item2) {
                        var x1 = (int)item1;
                        var x2 = (int)item2;
                        // 对比较器的理解，本来的顺序是x，y；如果保持这个顺序就返回-1，交换顺序就返回1，什么都不做就返回0；
                        return x1 <= x2 ? -1 : 1;
                    }
                }

                SortedList heap;
                int k;
                public KthLargest(int k, int[] nums) {
                    this.k = k;
                    heap = new SortedList(new KthLargestComparer());
                    foreach (var num in nums) {
                        this.Add(num);
                    }
                }
                public int Add(int val) {
                    heap.Add(val, val);
                    if (heap.Count > k) {
                        heap.RemoveAt(0);
                    }
                    return (int)(heap.GetKeyList())[0];
                }
            }

            // #295
            public class MedianFinder {

                class MinHeapComparer : IComparer {
                    public int Compare(object item1, object item2) {
                        var x1 = (int)item1;
                        var x2 = (int)item2;
                        return x1 <= x2 ? -1 : 1;
                    }
                }

                class MaxHeapComparer : IComparer {
                    public int Compare(object item1, object item2) {
                        var x1 = (int)item1;
                        var x2 = (int)item2;
                        return x1 >= x2 ? -1 : 1;
                    }
                }

                SortedList min;
                SortedList max;
                public MedianFinder() {
                    max = new SortedList(new MinHeapComparer()); // 存大的
                    min = new SortedList(new MaxHeapComparer()); // 存小的
                }

                public void AddNum(int num) {
                    // 不能保证num一定在min中，所以需要调整两次，保证num被插入到正确的堆中
                    min.Add(num, 0);
                    max.Add(min.GetKey(0), 0);
                    min.RemoveAt(0);
                    if (min.Count < max.Count) {
                        min.Add(max.GetKey(0), 0);
                        max.RemoveAt(0);
                    }
                }

                public double FindMedian() {
                    return min.Count > max.Count ? (int)min.GetKey(0) : ((int)min.GetKey(0) + (int)max.GetKey(0)) * 0.5;
                }
            }

            // #41
            public int FirstMissingPositive(int[] nums) {
                // 长度为n的数组，最多放n个数字，如果有放入>n的数字，那肯定会缺少在1-n内的数字，反之，缺少n+1
                var n = nums.Length;
                for (int i = 0; i < n; ++i) {
                    if (nums[i] <= 0) {
                        nums[i] = n + 1;
                    }
                }
                for (int i = 0; i < n; ++i) {
                    var num = Math.Abs(nums[i]);
                    if (num <= n) {
                        nums[num - 1] = -Math.Abs(nums[num - 1]);
                    }
                }
                for (int i = 0; i < n; ++i) {
                    if (nums[i] > 0) {
                        return i + 1;
                    }
                }
                return n + 1;
            }

            // #297
            public class Codec {
                public string serialize(TreeNode root) {
                    if (root == null) return string.Empty;

                    var res = new List<string>();
                    var queue = new Queue<TreeNode>();
                    queue.Enqueue(root);

                    while (queue.Count != 0) {
                        var node = queue.Dequeue();
                        if (node == null) {
                            res.Add("null");
                            continue;
                        }
                        res.Add(node.val.ToString());
                        queue.Enqueue(node.left);
                        queue.Enqueue(node.right);
                    }
                    return string.Join(",", res);
                }

                public TreeNode deserialize(string data) {
                    if (string.IsNullOrEmpty(data)) return null;

                    string[] nodes = data.Split(',');
                    var root = new TreeNode(int.Parse(nodes[0]));
                    var queue = new Queue<TreeNode>();
                    queue.Enqueue(root);
                    int idx = 1;
                    while (queue.Count != 0) {
                        var node = queue.Dequeue();
                        node.left = nodes[idx] == "null" ? null : new TreeNode(int.Parse(nodes[idx]));
                        if (node.left != null) {
                            queue.Enqueue(node.left);
                        }
                        idx++;

                        node.right = nodes[idx] == "null" ? null : new TreeNode(int.Parse(nodes[idx]));
                        if (node.right != null) {
                            queue.Enqueue(node.right);
                        }
                        idx++;
                    }
                    return root;
                }
            }

            // #23
            public class ListNodeIndex {
                public ListNode Node { get; set; }
                public int Index { get; set; }
                public ListNodeIndex(ListNode node, int index) { Node = node; Index = index; }
            }
            public ListNode MergeKLists(ListNode[] lists) {
                SortedSet<ListNodeIndex> heap = new SortedSet<ListNodeIndex>(Comparer<ListNodeIndex>.Create((a, b) => a.Node.val == b.Node.val ? a.Index - b.Index : a.Node.val - b.Node.val));
                ListNode dummy = new ListNode(0), head = dummy;

                for (int i = 0; i < lists.Length; i++) {
                    if (lists[i] != null) heap.Add(new ListNodeIndex(lists[i], i));
                }

                while (heap.Count != 0) {
                    ListNodeIndex min = heap.Min;
                    heap.Remove(min);
                    head.next = min.Node;
                    head = head.next;

                    min.Node = min.Node.next;
                    if (min.Node != null) heap.Add(min);
                }

                return dummy.next;
            }

            // #132
            public int MinCut(String s) {
                int n = s.Length;
                var isPalindrome = new bool[n][];
                for (int i = 0; i < n; ++i) {
                    isPalindrome[i] = new bool[n];
                    Array.Fill(isPalindrome[i], true);
                }

                for (int i = n - 1; i >= 0; --i) {
                    for (int j = i + 1; j < n; ++j) {
                        isPalindrome[i][j] = s[i] == s[j] && isPalindrome[i + 1][j - 1];
                    }
                }

                int[] dp = new int[n];
                Array.Fill(dp, int.MaxValue);
                for (int i = 0; i < n; ++i) {
                    if (isPalindrome[0][i]) {
                        dp[i] = 0;
                    } else {
                        for (int j = 0; j < i; ++j) {
                            if (isPalindrome[j + 1][i]) {
                                dp[i] = Math.Min(dp[i], dp[j] + 1);
                            }
                        }
                    }
                }
                return dp[n - 1];
            }

            // #7
            public int Reverse(int x) {
                int res = 0;
                while (x != 0) {
                    int cur = x % 10;
                    x /= 10;
                    if (res > int.MaxValue / 10 || (res == int.MaxValue / 10 && cur > int.MaxValue % 10)) return 0;

                    if (res < int.MinValue / 10 || (res == int.MinValue / 10 && cur < int.MinValue % 10)) return 0;
                    res = res * 10 + cur;
                }
                return res;
            }

            // #9
            public bool IsPalindrome(int x) {
                if (x < 0) return false;
                int res = 0;
                var oldX = x;
                while (x != 0) {
                    int cur = x % 10;
                    x /= 10;
                    if (res > int.MaxValue / 10) return false;
                    res = res * 10 + cur;
                }
                return oldX == res;
            }

            // #21
            public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
                var dummy = new ListNode();
                var head = dummy;
                while (l1 != null && l2 != null) {
                    if (l1.val <= l2.val) {
                        head.next = l1;
                        l1 = l1.next;
                    } else {
                        head.next = l2;
                        l2 = l2.next;
                    }
                    head = head.next;
                }
                if (l1 != null) head.next = l1;
                if (l2 != null) head.next = l2;
                return dummy.next;
            }

            // #13
            public int RomanToInt(string s) {
                var dict = new Dictionary<char, int>() { { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 } };
                int sum = 0, pre = dict[s[0]];
                for (int i = 1; i < s.Length; ++i) {
                    var num = dict[s[i]];
                    if (pre < num) {
                        sum -= pre;
                    } else {
                        sum += pre;
                    }
                    pre = num;
                }
                sum += pre;
                return sum;
            }

            // #1047
            public string RemoveDuplicates(string S) {
                var stack = new Stack<char>();
                foreach (var ch in S) {
                    if (stack.Count != 0 && ch == stack.Peek()) {
                        stack.Pop();
                    } else {
                        stack.Push(ch);
                    }
                }
                return new string(stack.Reverse().ToArray());
            }

            // #224
            public int Calculate_2(string s) {
                var ops = new Stack<int>();
                ops.Push(1);
                int sign = 1;

                int res = 0;
                int n = s.Length;
                int i = 0;
                while (i < n) {
                    if (s[i] == ' ') {
                        i++;
                    } else if (s[i] == '+') {
                        sign = ops.Peek();
                        i++;
                    } else if (s[i] == '-') {
                        sign = -ops.Peek();
                        i++;
                    } else if (s[i] == '(') {
                        // 记录括号前面的符号，要变号
                        ops.Push(sign);
                        i++;
                    } else if (s[i] == ')') {
                        ops.Pop();
                        i++;
                    } else {
                        int num = 0;
                        while (i < n && char.IsDigit(s[i])) {
                            num = num * 10 + s[i] - '0';
                            i++;
                        }
                        res += sign * num;
                    }
                }
                return res;
            }

            // #24
            public ListNode SwapPairs(ListNode head) {
                if (head == null) return null;

                ListNode Reverse(ListNode a, ListNode b) {
                    ListNode pre = null, cur = a, next = a;
                    while (cur != b) {
                        next = cur.next;
                        cur.next = pre;
                        pre = cur;
                        cur = next;
                    }
                    return pre;
                }

                ListNode a, b;
                a = b = head;
                for (int i = 0; i < 2; ++i) {
                    if (b == null) return head;
                    b = b.next;
                }
                var newHead = Reverse(a, b);
                a.next = SwapPairs(b);
                return newHead;
            }

            // #450
            public TreeNode DeleteNode(TreeNode root, int key) {
                int Successor(TreeNode node) {
                    node = node.right;
                    while (node.left != null) node = node.left;
                    return node.val;
                }
                int Predecessor(TreeNode node) {
                    node = node.left;
                    while (node.right != null) node = node.right;
                    return node.val;
                }

                TreeNode Helper(TreeNode node) {
                    if (node == null) return null;
                    if (key > node.val) node.right = Helper(node.right);
                    else if (key < node.val) node.left = Helper(node.left);
                    else {
                        if (node.left == null && node.right == null) node = null;
                        else if (node.right != null) {
                            node.val = Successor(node);
                            key = node.val;
                            node.right = Helper(node.right);
                        } else {
                            node.val = Predecessor(node);
                            key = node.val;
                            node.left = Helper(node.left);
                        }
                    }
                    return node;
                }
                return Helper(root);
            }

            // #70
            public int ClimbStairs(int n) {
                var dp = new int[n + 1];
                dp[0] = dp[1] = 1;
                for (int i = 2; i <= n; ++i) {
                    dp[i] = dp[i - 1] + dp[i - 2];
                }
                return dp[n];
            }

            // #76
            public string MinWindow(string s, string t) {
                var need = new Dictionary<char, int>();
                var window = new Dictionary<char, int>();
                foreach (var ch in t) {
                    need[ch] = need.GetValueOrDefault(ch, 0) + 1;
                }
                int left = 0, right = 0, valid = 0;
                int start = 0, len = int.MaxValue;
                while (right < s.Length) {
                    var ch = s[right];
                    ++right;
                    if (need.ContainsKey(ch)) {
                        window[ch] = window.GetValueOrDefault(ch, 0) + 1;
                        if (window[ch] == need[ch]) ++valid;
                    }
                    while (valid == need.Count) {
                        if ((right - left) < len) {
                            start = left;
                            len = right - left;
                        }
                        var leftCh = s[left];
                        ++left;
                        if (need.ContainsKey(leftCh)) {
                            if (window[leftCh] == need[leftCh]) --valid;
                            --window[leftCh];
                        }
                    }
                }
                return len == int.MaxValue ? "" : s.Substring(start, len);
            }

            // #171    
            public int TitleToNumber(string columnTitle) {
                int ans = 0;
                for (int i = 0; i < columnTitle.Length; i++) {
                    int num = columnTitle[i] - 'A' + 1;
                    ans = ans * 26 + num;
                }
                return ans;
            }

            // #557
            public string ReverseWords_2(string s) {
                var res = new StringBuilder();
                int len = s.Length;
                int i = 0;
                while (i < len) {
                    int start = i;
                    while (i < len && s[i] != ' ') {
                        i++;
                    }
                    for (int p = start; p < i; p++) {
                        res.Append(s[start + i - 1 - p]);
                    }
                    while (i < len && s[i] == ' ') {
                        i++;
                        res.Append(' ');
                    }
                }
                return res.ToString();
            }

            // #1239
            public int MaxLength(List<string> arr) {
                int res = 0;
                var path = new List<string>();
                void Helper(int idx) {
                    var pathStr = string.Join("", path);
                    if (pathStr.GroupBy(x => x).All(x => x.Count() == 1)) {
                        res = Math.Max(res, pathStr.Length);
                    }
                    for (int i = idx; i < arr.Count; ++i) {
                        path.Add(arr[i]);
                        Helper(i + 1);
                        path.RemoveAt(path.Count - 1);
                    }
                }
                Helper(0);
                return res;
            }

            // #128
            public int LongestConsecutive(int[] nums) {
                var set = new HashSet<int>(nums);
                int res = 0;
                foreach (var num in set) {
                    if (!set.Contains(num - 1)) {
                        int curNum = num;
                        int curLen = 1;
                        while (set.Contains(curNum + 1)) {
                            curNum += 1;
                            curLen += 1;
                        }
                        res = Math.Max(res, curLen);
                    }
                }
                return res;
            }

            // #44
            public bool IsMatch(string s, string p) {
                int m = s.Length, n = p.Length;
                var dp = new bool[m + 1, n + 1];
                dp[0, 0] = true;
                for (int i = 1; i <= n; ++i) {
                    if (p[i - 1] == '*') {
                        dp[0, i] = true;
                    } else {
                        break;
                    }
                }
                for (int i = 1; i <= m; ++i) {
                    for (int j = 1; j <= n; j++) {
                        if (p[j - 1] == '*') {
                            dp[i, j] = dp[i, j - 1] || dp[i - 1, j];
                        } else if (p[j - 1] == '?' || s[i - 1] == p[j - 1]) {
                            dp[i, j] = dp[i - 1, j - 1];
                        }
                    }
                }
                return dp[m, n];
            }

            // #124
            public int MaxPathSum(TreeNode root) {
                int res = int.MinValue;
                int Helper(TreeNode node) {
                    if (node == null) return 0;
                    int left = Math.Max(Helper(node.left), 0);
                    int right = Math.Max(Helper(node.right), 0);
                    int cur = node.val + left + right;
                    res = Math.Max(res, cur);
                    return node.val + Math.Max(left, right);
                }
                Helper(root);
                return res;
            }

            // #212
            public IList<string> FindWords(char[][] board, string[] words) {
                int h = board.Length;
                int w = board[0].Length;
                var directions = new int[][] { new[] { 0, 1 }, new[] { 0, -1 }, new[] { 1, 0 }, new[] { -1, 0 } };
                bool[,] vis = new bool[h, w];

                var res = new HashSet<string>();

                bool Exist(int i, int j, string word) {
                    bool Helper(int i, int j, int idx) {
                        if (board[i][j] != word[idx]) {
                            return false;
                        } else if (idx == word.Length - 1) {
                            return true;
                        }
                        // 回溯的选择
                        vis[i, j] = true;
                        bool res = false;
                        foreach (var direction in directions) {
                            int tx = i + direction[0], ty = j + direction[1];
                            if (tx >= 0 && tx < h && ty >= 0 && ty < w) {
                                if (!vis[tx, ty]) {
                                    bool flag = Helper(tx, ty, idx + 1);
                                    // 剪枝，找到一个即可返回
                                    if (flag) {
                                        res = true;
                                        break;
                                    }
                                }
                            }
                        }
                        vis[i, j] = false;
                        return res;
                    }

                    return Helper(i, j, 0);
                }

                for (int i = 0; i < h; i++) {
                    for (int j = 0; j < w; j++) {
                        foreach (var word in words) {
                            if (board[i][j] == word[0]) {
                                if (Exist(i, j, word)) {
                                    res.Add(word);
                                }
                            }
                        }
                    }
                }
                return res.ToList();
            }

            // #560
            public int SubarraySum(int[] nums, int k) {
                int res = 0, pre = 0;
                var dict = new Dictionary<int, int>();
                dict[0] = 1;
                for (int i = 0; i < nums.Length; i++) {
                    pre += nums[i];
                    if (dict.ContainsKey(pre - k)) {
                        res += dict[pre - k];
                    }
                    dict[pre] = dict.GetValueOrDefault(pre, 0) + 1;
                }
                return res;
            }

            // #237
            public void DeleteNode(ListNode node) {
                node.val = node.next.val;
                node.next = node.next.next;
            }

            // #140
            public IList<string> WordBreak_2(string s, IList<string> wordDict) {
                var map = new Dictionary<int, List<List<string>>>();
                var wordSet = new HashSet<string>(wordDict);
                int len = s.Length;
                List<List<string>> Helper(int idx) {
                    if (!map.ContainsKey(idx)) {
                        var wordBreaks = new List<List<string>>();
                        if (idx == len) {
                            wordBreaks.Add(new List<string>());
                        }
                        for (int i = idx + 1; i <= len; ++i) {
                            var word = s.Substring(idx, i - idx);
                            if (wordSet.Contains(word)) {
                                var nextWordBreaks = Helper(i);
                                foreach (var nextWordBreak in nextWordBreaks) {
                                    var wordBreak = new List<string>(nextWordBreak);
                                    wordBreak.Insert(0, word);
                                    wordBreaks.Add(wordBreak);
                                }
                            }
                        }
                        map[idx] = wordBreaks;
                    }
                    return map[idx];
                }
                var wordBreaks = Helper(0);
                return wordBreaks.Select(x => string.Join(" ", x)).ToList();
            }

            // #61
            public ListNode RotateRight(ListNode head, int k) {
                if (head == null) return null;
                if (head.next == null) return head;

                ListNode oldTail = head;
                int n = 1;
                while (oldTail.next != null) {
                    oldTail = oldTail.next;
                    ++n;
                }
                oldTail.next = head;

                ListNode newTail = head;
                for (int i = 0; i < n - k % n - 1; i++)
                    newTail = newTail.next;
                ListNode new_head = newTail.next;
                newTail.next = null;
                return new_head;
            }

            // #4
            public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
                int m = nums1.Length, n = nums2.Length;
                int len = m + n;
                int Helper(int k) {
                    // k表示第k个，而不是下标k
                    int idx1 = 0, idx2 = 0;
                    while (true) {
                        if (idx1 == m) return nums2[idx2 + k - 1];
                        if (idx2 == n) return nums1[idx1 + k - 1];
                        if (k == 1) return Math.Min(nums1[idx1], nums2[idx2]);
                        var half = k / 2;
                        var newIdx1 = Math.Min(idx1 + half, m) - 1;
                        var newIdx2 = Math.Min(idx2 + half, n) - 1;
                        int pivot1 = nums1[newIdx1], pivot2 = nums2[newIdx2];
                        if (pivot1 <= pivot2) {
                            // 新旧索引之间的全部移除
                            k -= (newIdx1 - idx1 + 1);
                            idx1 = newIdx1 + 1;
                        } else {
                            k -= (newIdx2 - idx2 + 1);
                            idx2 = newIdx2 + 1;
                        }
                    }
                }
                if (len % 2 == 1) {
                    int mid = len / 2;
                    var median = Helper(mid + 1);
                    return median;
                } else {
                    int mid1 = len / 2 - 1, mid2 = len / 2;
                    var median = (Helper(mid1 + 1) + Helper(mid2 + 1)) / 2.0;
                    return median;
                }
            }

            // #8
            public int MyAtoi(string s) {
                int sign = 1, cur = 0, i = 0;
                while (i < s.Length && s[i] == ' ') ++i;
                if (i < s.Length && (s[i] == '+' || s[i] == '-')) {
                    sign = 1 - 2 * ((s[i++] == '-') ? 1 : 0);
                }
                while (i < s.Length && s[i] >= '0' && s[i] <= '9') {
                    if (cur > int.MaxValue / 10 || (cur == int.MaxValue / 10 && s[i] - '0' > int.MaxValue % 10))
                        return sign == 1 ? int.MaxValue : int.MinValue;
                    cur = cur * 10 + (s[i++] - '0');
                }
                return cur * sign;
            }

            // #28
            public int StrStr(string haystack, string needle) {
                int L = needle.Length, n = haystack.Length;
                for (int start = 0; start < n - L + 1; ++start) {
                    if (haystack.Substring(start, L) == needle) {
                        return start;
                    }
                }
                return -1;
            }

            // #10
            public bool IsMatch_2(string s, string p) {
                if (s == null || p == null) return false;
                int m = s.Length, n = p.Length;
                var dp = new bool[m + 1, n + 1];
                dp[0, 0] = true;
                for (int i = 1; i <= n; ++i) {
                    if (p[i - 1] == '*' && dp[0, i - 2]) {
                        dp[0, i] = true;
                    }
                }

                for (int i = 1; i <= m; ++i) {
                    for (int j = 1; j <= n; ++j) {
                        if (s[i - 1] == p[j - 1] || p[j - 1] == '.') {
                            dp[i, j] = dp[i - 1, j - 1];
                        } else if (p[j - 1] == '*') {
                            if (p[j - 2] != s[i - 1] && p[j - 2] != '.') {
                                dp[i, j] = dp[i, j - 2];
                            } else {
                                dp[i, j] = (dp[i, j - 2] || dp[i, j - 1] || dp[i - 1, j]);
                            }
                        }
                    }
                }
                return dp[m, n];
            }

            // #59
            public int[][] GenerateMatrix(int n) {
                int maxNum = n * n;
                int curNum = 0;
                int[][] matrix = new int[n][];
                for (int i = 0; i < n; ++i) {
                    matrix[i] = new int[n];
                }
                int top = 0, bottom = n - 1, left = 0, right = n - 1;
                while (curNum < n * n) {
                    for (int j = left; j <= right; ++j) {
                        matrix[top][j] = ++curNum;
                    }
                    ++top;
                    for (int i = top; i <= bottom; ++i) {
                        matrix[i][right] = ++curNum;
                    }
                    --right;
                    for (int j = right; j >= left; j--) {
                        matrix[bottom][j] = ++curNum;
                    }
                    --bottom;
                    for (int i = bottom; i >= top; i--) {
                        matrix[i][left] = ++curNum;
                    }
                    ++left;
                }
                return matrix;
            }

            // #273
            public string NumberToWords(int num) {
                var less20 = new[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tens = new[] { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
                var units = new[] { "", "Thousand", "Million", "Billion" };

                // 只处理千以下的
                string Helper(int num) {
                    if (num == 0) return "";
                    else if (num < 20) {
                        return less20[num] + " ";
                    } else if (num < 100) {
                        return tens[num / 10] + " " + Helper(num % 10);
                    } else {
                        return Helper(num / 100) + "Hundred " + Helper(num % 100);
                    }
                }

                if (num == 0) return "Zero";
                int i = 0;
                string words = "";

                while (num > 0) {
                    if (num % 1000 != 0) {
                        words = Helper(num % 1000) + units[i] + " " + words;
                    }
                    num /= 1000;
                    i++;
                }
                return words.Trim();
            }

            // #33
            public int Search_2(int[] nums, int target) {
                int n = nums.Length;
                if (n == 0) return -1;
                if (n == 1) return nums[0] == target ? 0 : -1;
                int l = 0, r = n - 1;
                while (l <= r) {
                    int mid = l + (r - l) / 2;
                    if (nums[mid] == target) return mid;
                    // 左边有序
                    if (nums[0] <= nums[mid]) {
                        if (nums[0] <= target && target < nums[mid]) {
                            r = mid - 1;
                        } else {
                            l = mid + 1;
                        }
                    } else {
                        if (nums[mid] < target && target <= nums[n - 1]) {
                            l = mid + 1;
                        } else {
                            r = mid - 1;
                        }
                    }
                }
                return -1;
            }

            // #186
            public void ReverseWords(char[] s) {
                void Reverse(int left, int right) {
                    while (left < right) {
                        char temp = s[left];
                        s[left++] = s[right];
                        s[right--] = temp;
                    }
                }
                int i = 0; int j = 0;
                while (j < s.Length) {
                    while (s[j] != ' ') ++j;
                    Reverse(i, j - 1);
                    i = ++j;
                }
                Reverse(0, s.Length - 1);
            }

            // #115
            public int NumDistinct(string s, string t) {
                int m = s.Length, n = t.Length;
                if (m < n) {
                    return 0;
                }
                var dp = new int[m + 1, n + 1];
                for (int i = 0; i <= m; i++) {
                    dp[i, n] = 1;
                }
                for (int i = m - 1; i >= 0; i--) {
                    for (int j = n - 1; j >= 0; j--) {
                        if (s[i] == t[j]) {
                            dp[i, j] = dp[i + 1, j + 1] + dp[i + 1, j];
                        } else {
                            dp[i, j] = dp[i + 1, j];
                        }
                    }
                }
                return dp[0, 0];
            }

            // #99
            public void RecoverTree(TreeNode root) {
                var stack = new Stack<TreeNode>();
                TreeNode x = null, y = null, pred = null;
                void Swap(TreeNode x, TreeNode y) {
                    int tmp = x.val;
                    x.val = y.val;
                    y.val = tmp;
                }
                while (true) {
                    while (root != null) {
                        stack.Push(root);
                        root = root.left;
                    }
                    if (stack.Count == 0) break;
                    root = stack.Pop();
                    if (pred != null && root.val < pred.val) {
                        y = root;
                        if (x == null) {
                            x = pred;
                        } else {
                            break;
                        }
                    }
                    pred = root;
                    root = root.right;
                }
                Swap(x, y);
            }

            // // #545
            // public List<int> BoundaryOfBinaryTree(TreeNode root) {

            // }

            // #412
            public List<string> fizzBuzz(int n) {
                var ans = new List<string>();
                for (int num = 1; num <= n; num++) {
                    bool divisibleBy3 = (num % 3 == 0);
                    bool divisibleBy5 = (num % 5 == 0);

                    var numAnsStr = "";
                    if (divisibleBy3) {
                        numAnsStr += "Fizz";
                    }
                    if (divisibleBy5) {
                        numAnsStr += "Buzz";
                    }
                    if (numAnsStr == "") {
                        numAnsStr += num;
                    }
                    ans.Add(numAnsStr);
                }
                return ans;
            }

            // #93
            public List<string> RestoreIpAddresses(string s) {
                var res = new List<string>();
                var segments = new int[4];
                void Helper(int segIdx, int idx) {
                    if (segIdx == 4) {
                        if (idx == s.Length) {
                            res.Add(string.Join(".", segments));
                        }
                        return;
                    }
                    if (idx == s.Length) return;
                    if (s[idx] == '0') {
                        segments[segIdx] = 0;
                        Helper(segIdx + 1, idx + 1);
                    }
                    int addr = 0;
                    for (int i = idx; i < s.Length; ++i) {
                        // 每次都尽可能多的往后选，
                        addr = addr * 10 + (s[i] - '0');
                        if (addr > 0 && addr <= 255) {
                            segments[segIdx] = addr;
                            Helper(segIdx + 1, i + 1);
                        } else {
                            // 剪枝，超过255可以直接退出当前选择了
                            break;
                        }
                    }
                }
                Helper(0, 0);
                return res;
            }

            // #14
            public string longestCommonPrefix(string[] strs) {
                if (strs == null || strs.Length == 0) {
                    return "";
                }
                int len = strs[0].Length;
                int count = strs.Length;
                for (int i = 0; i < len; i++) {
                    char c = strs[0][i];
                    for (int j = 1; j < count; j++) {
                        if (i == strs[j].Length || strs[j][i] != c) {
                            return strs[0].Substring(0, i);
                        }
                    }
                }
                return strs[0];
            }

            // #285
            public TreeNode InorderSuccessor(TreeNode root, TreeNode p) {
                if (p.right != null) {
                    p = p.right;
                    while (p.left != null) p = p.left;
                    return p;
                }

                var stack = new Stack<TreeNode>();
                int inorder = int.MinValue;
                while (true) {
                    while (root != null) {
                        stack.Push(root);
                        root = root.left;
                    }
                    if (stack.Count == 0) break;
                    root = stack.Pop();
                    if (inorder == p.val) return root;
                    inorder = root.val;
                    root = root.right;
                }
                return null;
            }

            // #545
            public List<int> BoundaryOfBinaryTree(TreeNode root) {
                var res = new List<int>();
                bool IsLeaf(TreeNode node) {
                    return node.left == null && node.right == null;
                }
                void AddLeaves(TreeNode node) {
                    if (IsLeaf(node)) {
                        res.Add(node.val);
                    } else {
                        if (node.left != null) {
                            AddLeaves(node.left);
                        }
                        if (node.right != null) {
                            AddLeaves(node.right);
                        }
                    }
                }

                if (root == null) return res;
                if (!IsLeaf(root)) res.Add(root.val);
                // 添加左边界
                var node = root.left;
                while (node != null) {
                    if (!IsLeaf(node)) res.Add(node.val);
                    if (node.left != null) {
                        node = node.left;
                    } else {
                        node = node.right;
                    }
                }
                // 添加叶子
                AddLeaves(root);
                var stack = new Stack<int>();
                // 添加右边界
                node = root.right;
                while (node != null) {
                    if (!IsLeaf(node)) stack.Push(node.val);
                    if (node.right != null) {
                        node = node.right;
                    } else {
                        node = node.left;
                    }
                }
                res.AddRange(stack);
                return res;
            }

            // #387
            public int FirstUniqChar(string s) {
                var dict = s.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
                for (int i = 0; i < s.Length; i++) {
                    if (dict[s[i]] == 1) {
                        return i;
                    }
                }
                return -1;
            }

            // #836
            public bool IsRectangleOverlap(int[] rec1, int[] rec2) {
                if (rec1[0] == rec1[2] || rec1[1] == rec1[3] || rec2[0] == rec2[2] || rec2[1] == rec2[3]) {
                    return false;
                }
                return !(rec1[2] <= rec2[0] || rec1[3] <= rec2[1] || rec1[0] >= rec2[2] || rec1[1] >= rec2[3]);
            }

            // #101
            public bool IsSymmetric(TreeNode root) {
                bool Helper(TreeNode node1, TreeNode node2) {
                    if (node1 == null && node2 == null) {
                        return true;
                    }
                    if (node1 == null || node2 == null || node1.val != node2.val) {
                        return false;
                    }
                    return Helper(node1.left, node2.right) && Helper(node1.right, node2.left);
                }
                return Helper(root, root);
            }

        }

        public class DataStructure {
            public class LRU {
                public class Node {
                    public Node(int k, int v) {
                        key = k;
                        val = v;
                    }
                    public int key, val;
                    public Node next, prev;
                }

                public class DoubleList {
                    public Node head, tail;
                    public int size;

                    public DoubleList() {
                        head = new Node(0, 0);
                        tail = new Node(0, 0);
                        head.next = tail;
                        tail.prev = head;
                        size = 0;
                    }

                    public void AddLast(Node x) {
                        // 把x插入到tail之前
                        x.prev = tail.prev;
                        x.next = tail;
                        tail.prev.next = x;
                        tail.prev = x;
                        size++;
                    }

                    public void Remove(Node x) {
                        x.prev.next = x.next;
                        x.next.prev = x.prev;
                        size--;
                    }

                    public Node RemoveFirst() {
                        if (head.next == tail) {
                            return null;
                        }
                        Node first = head.next;
                        Remove(first);
                        return first;
                    }

                    public int Size() {
                        return size;
                    }
                }

                public class LRUCache {
                    public Dictionary<int, Node> map;
                    public DoubleList cache;
                    public int cap;

                    public LRUCache(int capacity) {
                        cap = capacity;
                        map = new Dictionary<int, Node>();
                        cache = new DoubleList();
                    }

                    // 将key对应node提升为最近使用的，也就是把node从表头删除，插入到表尾
                    public void MakeRecently(int key) {
                        Node x = map[key];
                        cache.Remove(x);
                        cache.AddLast(x);
                    }

                    // 添加最近使用的node，初始化一个node，并插入到表尾，同时在map中添加映射
                    public void AddRecently(int key, int val) {
                        Node x = new Node(key, val);
                        cache.AddLast(x);
                        map[key] = x;
                    }

                    // 删除某一个key，从表中删除，从map中删除
                    public void DeleteKey(int key) {
                        Node x = map[key];
                        cache.Remove(x);
                        map.Remove(key);
                    }

                    // 删除最久未使用的，即表头节点
                    public void RemoveLeastRecently() {
                        Node deleteNode = cache.RemoveFirst();
                        int key = deleteNode.key;
                        map.Remove(key);
                    }

                    public int Get(int key) {
                        if (!map.ContainsKey(key)) {
                            return -1;
                        }
                        // 如果存在，将该节点提升为最近使用的
                        MakeRecently(key);
                        return map[key].val;
                    }

                    public void Put(int key, int val) {
                        // 如果key存在，将key对应的val修改，并提到最近使用
                        if (map.ContainsKey(key)) {
                            map[key].val = val;
                            MakeRecently(key);
                            return;
                        }
                        // 如果缓存满了，删除掉最近最少使用的元素
                        if (cap == cache.Size()) {
                            RemoveLeastRecently();
                        }
                        // 添加最近使用元素
                        AddRecently(key, val);
                    }
                }
            }

            // #381
            public class RandomizedCollection {
                Dictionary<int, SortedSet<int>> idx;
                List<int> nums;
                Random random;
                public RandomizedCollection() {
                    idx = new Dictionary<int, SortedSet<int>>();
                    nums = new List<int>();
                    random = new Random();
                }

                public bool Insert(int val) {
                    nums.Add(val);
                    var set = idx.GetValueOrDefault(val, new SortedSet<int>());
                    set.Add(nums.Count - 1);
                    idx[val] = set;
                    return set.Count == 1;
                }

                public bool Remove(int val) {
                    if (!idx.ContainsKey(val)) {
                        return false;
                    }
                    // 从val的索引集合中选择一个，换到最后，以实现O（1）的删除
                    int i = idx[val].First();
                    idx[val].Remove(i);

                    if (i == nums.Count - 1) {
                        // 如果要删除的正好是最后一个元素，直接从集合中删除索引
                        idx[val].Remove(i);
                    } else {
                        // 否则，从val的索引集合中删除索引i，从lastNum的索引集合中删除最后一个，并添加i
                        int lastNum = nums.Last();
                        idx[lastNum].Remove(nums.Count - 1);
                        idx[lastNum].Add(i);
                        nums[i] = lastNum;
                    }
                    if (idx[val].Count == 0) {
                        idx.Remove(val);
                    }
                    nums.RemoveAt(nums.Count - 1);
                    return true;
                }

                public int GetRandom() {
                    return nums[random.Next(nums.Count)];
                }
            }

            // #380
            public class RandomizedSet {
                Dictionary<int, int> idx;
                List<int> nums;
                Random random;
                public RandomizedSet() {
                    idx = new Dictionary<int, int>();
                    nums = new List<int>();
                    random = new Random();
                }

                public bool Insert(int val) {
                    if (idx.ContainsKey(val)) {
                        return false;
                    } else {
                        nums.Add(val);
                        idx[val] = nums.Count - 1;
                        return true;
                    }
                }

                public bool Remove(int val) {
                    if (!idx.ContainsKey(val)) {
                        return false;
                    }
                    var valIdx = idx[val];
                    if (valIdx != nums.Count - 1) {
                        var lastNum = nums.Last();
                        nums[valIdx] = lastNum;
                        idx[lastNum] = valIdx;
                    }
                    idx.Remove(val);
                    nums.RemoveAt(nums.Count - 1);
                    return true;
                }

                public int GetRandom() {
                    return nums[random.Next(nums.Count)];
                }
            }

            // #384
            public class ShuffleArray {
                int[] _nums;
                int[] _shuffle;
                Random r = new Random();
                public ShuffleArray(int[] nums) {
                    _nums = nums;
                    _shuffle = nums.Clone() as int[];
                }
                public int[] Reset() {
                    return _nums;
                }

                public int[] Shuffle() {
                    for (int i = 0; i < _nums.Length; i++) {
                        var index = r.Next(i, _nums.Length);
                        var tmp = _shuffle[i];
                        _shuffle[i] = _shuffle[index];
                        _shuffle[index] = tmp;
                    }
                    return _shuffle;
                }
            }

            // #155
            public class MinStack {
                Stack<int> stack;
                Stack<int> minStack;
                public MinStack() {
                    stack = new Stack<int>();
                    minStack = new Stack<int>();
                    minStack.Push(int.MaxValue);
                }

                public void Push(int x) {
                    stack.Push(x);
                    minStack.Push(Math.Min(x, minStack.Peek()));
                }

                public void Pop() {
                    stack.Pop();
                    minStack.Pop();
                }

                public int Top() {
                    return stack.Peek();
                }

                public int GetMin() {
                    return minStack.Peek();
                }
            }

            public class MyStack {
                public Queue<int> queue;
                public MyStack() {
                    queue = new Queue<int>();
                }

                public void Push(int x) {
                    int n = queue.Count;
                    queue.Enqueue(x);
                    for (int i = 0; i < n; i++) {
                        queue.Enqueue(queue.Dequeue());
                    }
                }

                public int Pop() {
                    return queue.Dequeue();
                }

                public int Top() {
                    return queue.First();
                }

                public bool Empty() {
                    return queue.Count == 0;
                }
            }

            // #208
            public class Trie {
                class TireNode {
                    public bool isEnd;
                    public TireNode[] next;
                    public TireNode() {
                        isEnd = false;
                        next = new TireNode[26];
                    }
                }

                TireNode root;
                public Trie() {
                    root = new TireNode();
                }

                public void Insert(string word) {
                    var node = root;
                    foreach (var ch in word) {
                        if (node.next[ch - 'a'] == null) {
                            node.next[ch - 'a'] = new TireNode();
                        }
                        node = node.next[ch - 'a'];
                    }
                    node.isEnd = true;
                }

                public bool Search(string word) {
                    var node = root;
                    foreach (var ch in word) {
                        node = node.next[ch - 'a'];
                        if (node == null) {
                            return false;
                        }
                    }
                    return node.isEnd;
                }

                public bool StartsWith(string prefix) {
                    TireNode node = root;
                    foreach (var ch in prefix) {
                        node = node.next[ch - 'a'];
                        if (node == null) {
                            return false;
                        }
                    }
                    return true;
                }
            }

            // #232
            public class MyQueue {
                Stack<int> pushStack;
                Stack<int> popStack;
                public MyQueue() {
                    pushStack = new Stack<int>();
                    popStack = new Stack<int>();
                }

                public void Push(int x) {
                    pushStack.Push(x);
                }

                public int Pop() {
                    if (popStack.Count == 0) {
                        while (pushStack.Count != 0) {
                            popStack.Push(pushStack.Pop());
                        }
                    }
                    return popStack.Pop();
                }

                public int Peek() {
                    if (popStack.Count == 0) {
                        while (pushStack.Count != 0) {
                            popStack.Push(pushStack.Pop());
                        }
                    }
                    return popStack.Peek();
                }

                public bool Empty() {
                    return pushStack.Count == 0 && popStack.Count == 0;
                }
            }

            // #705
            public class MyHashSet {
                LinkedList<int>[] data;
                int BASE = 769;
                public MyHashSet() {
                    data = new LinkedList<int>[BASE];
                    for (int i = 0; i < BASE; ++i) {
                        data[i] = new LinkedList<int>();
                    }
                }

                public void Add(int key) {
                    int h = key % BASE;
                    if (data[h].Contains(key)) return;
                    data[h].AddLast(key);
                }

                public void Remove(int key) {
                    int h = key % BASE;
                    data[h].Remove(key);
                }

                public bool Contains(int key) {
                    int h = key % BASE;
                    return data[h].Contains(key);
                }
            }

            // #348
            public class TicTacToe {
                int n;
                int[,] rows, cols, diagonals;
                public TicTacToe(int n) {
                    this.n = n;
                    rows = new int[3, n];
                    cols = new int[3, n];
                    diagonals = new int[3, 2];

                }

                public int Move(int row, int col, int player) {
                    if (++rows[player, row] == n) return player;
                    if (++cols[player, col] == n) return player;
                    if (row == col && ++diagonals[player, 0] == n) return player;
                    if ((row + col == n - 1) && ++diagonals[player, 1] == n) return player;
                    return 0;

                }
            }
        }

        static void Main(string[] args) {
            var algorithm = new Algorithm();
            
        }
    }
}
