using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FuckingAlgorithm {
    public class Program {
        public class Algorithm {

            // 链表节点类
            public class Node {
                public int val;
                public Node next;

                public Node(int _val) {
                    this.val = _val;
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

            public List<int[]> Permute(int[] nums) {
                // 存储全排列结果
                List<int[]> res = new List<int[]>();
                void backtrack(int[] nums, List<int> track) {
                    if (track.Count == nums.Length) {
                        // 结束条件，如果nums中所有元素都在track中，找到一个全排列，添加进全排列结果里
                        res.Add(track.ToArray());
                        return;
                    }
                    // 做选择
                    foreach (var num in nums) {
                        // 如果路径中已存在元素num，则跳过
                        if (track.Contains(num)) {
                            continue;
                        }
                        // 做选择
                        track.Add(num);
                        // 进入下一层选择
                        backtrack(nums, track);
                        // 回溯，撤销选择
                        track.RemoveAt(track.Count - 1);
                    }
                }

                // 回溯路径
                List<int> track = new List<int>();
                backtrack(nums, track);
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
                Array.Sort(dp);
                return dp[dp.Length - 1];
            }

            public int MaxSubArray(int[] nums) {
                if (nums.Length == 0) {
                    return 0;
                }
                // base第1个元素前面没有子数组，其本身就是最大
                int[] dp = new int[nums.Length];
                // 状态转移，元素nums[i]要么自己最大，要么和前面的子数组连起来后最大
                for (int i = 1; i < nums.Length; i++) {
                    dp[i] = Math.Max(nums[i], nums[i] + dp[i - 1]);
                }
                Array.Sort(dp);
                return dp[dp.Length - 1];
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
                bool[, ] dp = new bool[n + 1, sum + 1];
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
                int[, ] dp = new int[n + 1, amount + 1];
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

            public int MinDistance(string s1, string s2) {
                int m = s1.Length, n = s2.Length;
                int[, ] dp = new int[m + 1, n + 1];
                // base，“”到m的编辑距离为0-m，“”到n的编辑距离为0-n
                for (int i = 0; i <= m; i++) {
                    dp[i, 0] = i;
                }
                for (int i = 0; i <= n; i++) {
                    dp[0, i] = i;
                }
                for (int i = 1; i <= m; i++) {
                    for (int j = 1; j <= n; j++) {
                        if (s1[i - 1] == s2[j - 1]) {
                            // 如果两个字符串当前位置字符一样，跳过
                            dp[i, j] = dp[i - 1, j - 1];
                        } else {
                            // 如果不一致，需要选择操作数最少的操作
                            dp[i, j] = Min(
                                // 把s[i]这个字符删掉，前移i，继续跟j对比
                                dp[i - 1, j] + 1,
                                // s1[i]后面插入一个和s2[j]一样的字符，因为i没变，所以前移j
                                dp[i, j - 1] + 1,
                                // 替换，把s1[i] 替换成s2[j]，然后同时前进
                                dp[i - 1, j - 1] + 1
                            );
                        }
                    }
                }
                return dp[m, n];
            }

            public int Min(int a, int b, int c) {
                return Math.Min(Math.Min(a, b), c);
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
                int[, ] dp = new int[k + 1, n + 1];
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

            public int LongestPalindromeSubseq(string s) {
                int n = s.Length;
                // 涉及两个字符串，用二维dp数组
                // dp定义为在array[i..j]中，最长回文子序列的长度为dp[i][j]
                int[, ] dp = new int[n, n];
                // base如果只有一个字符，最长回文子序列长度为1
                for (int i = 0; i < n; i++) {
                    dp[i, i] = 1;
                }
                // 要求dp[0,n-1]，斜着遍历或者反着遍历
                for (int i = n - 1; i >= 0; i--) {
                    // j比i大
                    for (int j = i + 1; i < n; i++) {
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

            public int EraseOverlapIntervals(int[][] intvs) {
                int n = intvs.Length;
                return n - IntervalSchedule(intvs);
            }

            public int MaxProfit_1(int[] prices) {
                // 交易次数k=1
                int n = prices.Length;
                int[, ] dp = new int[n, 2];
                // dp定义为第i天持有/未持有股票的收益
                // base dp[-1, 0] = 0，还没开始交易，利润是0 dp[-1, 1] = -prices[i]，没开始交易，不可能持有股票
                // 
                for (int i = 0; i < n; i++) {
                    if (i - 1 == -1) {
                        dp[i, 0] = 0;
                        dp[i, 1] = -prices[i];
                        continue;
                    }
                    // 第i天未持有股票，可能是i-1天就未持有，也可能是i-1天持有股票，然后卖了
                    dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
                    // 第i天持有股票，可能是i-1天就持有，也可能是i-1天未持有，但买入了，因为只交易一次，所以收益直接-prices[i]
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

            // public  int MaxProfit_5(int[] prices) {
            //     int max_k = 2;
            //     int n = prices.Length;
            //     int[, , ] dp = new int[n, max_k + 1, 2];
            //     // dp定义为第i天持有/未持有股票的收益
            //     // base dp[-1, 0] = 0，还没开始交易，利润是0 dp[-1, 1] = -prices[i]，没开始交易，不可能持有股票
            //     // 
            //     for (int i = 0; i < n; i++) {
            //         if (i - 1 == -1) {
            //             dp[i, 0] = 0;
            //             dp[i, 1] = -prices[i];
            //             continue;
            //         }
            //         // 第i天未持有股票，可能是i-1天就未持有，也可能是i-1天持有股票，然后卖了
            //         dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
            //         // 第i天持有股票，可能是i-1天就持有，也可能是i-1天未持有，但买入了，因为只交易一次，所以收益直接-prices[i]
            //         dp[i, 1] = Math.Max(dp[i - 1, 1], -prices[i]);
            //     }
            //     return dp[n - 1, 0];
            // }

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
                    res = res.Length > s1.Length? res : s1;
                    res = res.Length > s2.Length? res : s2;
                }
                return res;
            }

            public class ListNode {
                public char val;
                public ListNode next;
            }

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
                int[] l_max = new int[n], r_max = new int[n];
                // base。l_max表示位置i左侧最高柱子的高度，r_max表示位置右侧最高柱子的高度
                l_max[0] = height[0];
                r_max[n - 1] = height[n - 1];
                // 从左向右计算 l_max
                for (int i = 1; i < n; i++) {
                    l_max[i] = Math.Max(height[i], l_max[i - 1]);
                }
                // 从右向左计算 r_max
                for (int i = n - 2; i >= 0; i--) {
                    r_max[i] = Math.Max(height[i], r_max[i + 1]);
                }
                for (int i = 1; i < n - 1; i++)
                    ans += Math.Min(l_max[i], r_max[i]) - height[i];
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
                return new int[] {-1, -1 };
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

            public List<int[]> MergeIntervals(int[][] intervals) {
                if (intervals.Length == 0) {
                    return new List<int[]>();
                }
                // 按区间start升序排列
                Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
                List<int[]> res = new List<int[]>();
                res.Add(intervals[0]);
                for (int i = 1; i < intervals.Length; i++) {
                    var curr = intervals[i];
                    // res中最后一个元素的引用，所以可以不断修改last的end。
                    var last = res[res.Count - 1];
                    // 如果curr的start小于last的end，说明curr可能在last的区间内，这时需要比较curr的end和last的end，确定是否更新last的end。
                    if (curr[0] <= last[1]) {
                        last[1] = Math.Max(last[1], curr[1]);
                    } else {
                        res.Add(curr);
                    }
                }
                return res;
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

            public int MissingNumber_1(int[] nums) {
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

            public string Multiply(string num1, string num2) {
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
                        res[p1] = sum / 10;
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
                    int rand = r.Next(i, n - 1);
                    // Swap交换数组元素
                    int tmp = arr[i];
                    arr[i] = arr[rand];
                    arr[rand] = tmp;
                }
                // 错误的写法，共产生n^n种结果，!= n!。
                for (int i = 0; i < n; i++) {
                    // 每次都从闭区间 [0, n-1]中随机选取元素进行交换。
                    int rand = r.Next(i, n - 1);
                }
            }

            public int[, ] FloodFill(int[, ] iamge, int sr, int sc, int newColor) {
                void Fill(int[, ] iamge, int x, int y, int origColor, int newColor) {
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

                bool InArea(int[, ] iamge, int x, int y) {
                    return x >= 0 && x < iamge.GetLength(0) && y >= 0 && y < iamge.GetLength(1);
                }
                int origColor = iamge[sr, sc];
                Fill(iamge, sr, sc, origColor, newColor);
                return iamge;
            }

            class KMP {
                int[, ] dp;
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

            public IList<int> PreorderTraversal(TreeNode root) {
                if (root == null) return new List<int> { };
                var stack = new Stack<TreeNode>();
                var res = new List<int>();
                stack.Push(root);
                while (stack.Count != 0) {
                    var node = stack.Pop();
                    res.Add(node.val);
                    if (node.right != null) {
                        stack.Push(node.right);
                    }
                    if (node.left != null) {
                        stack.Push(node.left);
                    }
                }
                return res;
            }

            public IList<int> PostorderTraversal(TreeNode root) {
                if (root == null) return new List<int> { };
                var stack = new Stack<TreeNode>();
                var res = new List<int>();
                stack.Push(root);
                while (stack.Count != 0) {
                    var node = stack.Pop();
                    res.Insert(0, node.val);
                    if (node.left != null) {
                        stack.Push(node.left);
                    }
                    if (node.right != null) {
                        stack.Push(node.right);
                    }
                }
                return res;
            }

            public TreeNode InvertTree(TreeNode root) {
                if (root == null) return null;

                var left = InvertTree(root.left);
                var right = InvertTree(root.right);

                root.left = right;
                root.right = left;

                return root;
            }

            // public class Node {
            //     public int val;
            //     public IList<Node> children;
            //     public Node() { }
            //     public Node(int _val) {
            //         val = _val;
            //     }
            //     public Node(int _val, IList<Node> _children) {
            //         val = _val;
            //         children = _children;
            //     }
            // }
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
                int[] left = new int[k];
                int[] right = new int[nums.Length - k];
                Array.Copy(nums, 0, left, 0, k);
                Array.Copy(nums, k, right, 0, nums.Length - k);
                // 将数组两部分分别翻转。
                Array.Reverse(left);
                Array.Reverse(right);
                left.CopyTo(nums, 0);
                right.CopyTo(nums, k);
                // 合并后把整个数组翻转。
                Array.Reverse(nums);
            }

            public int RemoveDuplicates(int[] nums) {
                int n = nums.Length;
                if (n == 0) return 0;
                int slow = 0, fast = 1;
                while (fast < n) {
                    if (nums[fast] != nums[slow]) {
                        slow++;
                        nums[slow] = nums[fast];
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
                fast.next = null;
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
            // 快速排序可以理解为二叉树的前序遍历，归并排序可以理解为二叉树的后序遍历。
            // public class TreeNode {
            //     public int val;
            //     public TreeNode left;
            //     public TreeNode right;
            //     public TreeNode next;

            //     public TreeNode(int _val) {
            //         val = _val;
            //     }
            // }
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

            public TreeNode BuildTree(int[] preorder, int[] inorder) {
                TreeNode build(int[] preorder, int preStart, int preEnd,
                    int[] inorder, int inStart, int inEnd) {
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
                    root.left = build(preorder, preStart + 1, preStart + leftSize,
                        inorder, inStart, index - 1);

                    root.right = build(preorder, preStart + leftSize + 1, preEnd,
                        inorder, index + 1, inEnd);
                    return root;
                }
                return build(preorder, 0, preorder.Length - 1,
                    inorder, 0, inorder.Length - 1);
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

            public bool IsValidBST(TreeNode root) {
                //rot为当前节点值，low为子树下限，up为上限
                bool Helper(TreeNode rot, int low, int up) {
                    if (rot == null) {
                        return true;
                    }
                    //当前为左子树时，无下限，上限为根节点
                    if (!Helper(rot.left, low, rot.val))
                        return false;
                    //当前为右子树时，无上限，下限为根节点
                    if (!Helper(rot.right, rot.val, up))
                        return false;

                    if (low != -1 && rot.val <= low)
                        return false;
                    if (up != -1 && rot.val >= up)
                        return false;

                    return true;
                }
                return Helper(root, -1, -1);
            }

            public ListNode ReverseKGroup(ListNode head, int k) {
                ListNode Reverse(ListNode a, ListNode b) {
                    ListNode pre, cur, nxt;
                    pre = null;
                    cur = a;
                    nxt = a;
                    // while 终止的条件改一下就行了
                    while (cur != b) {
                        nxt = cur.next;
                        cur.next = pre;
                        pre = cur;
                        cur = nxt;
                    }
                    // 返回反转后的头结点
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
                        ans.Add(((char) ('a' + i)).ToString());
                    }
                }
                return ans;
            }

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

            public class BSTIterator {
                List<int> nodesSorted;
                int index;

                public BSTIterator(TreeNode root) {
                    this.nodesSorted = new List<int>();
                    this.index = -1;
                    this._inorder(root);
                }

                public void _inorder(TreeNode root) {
                    if (root == null) {
                        return;
                    }
                    this._inorder(root.left);
                    this.nodesSorted.Add(root.val);
                    this._inorder(root.right);
                }

                public int Next() {
                    return this.nodesSorted[(++this.index)];
                }

                public bool HasNext() {
                    return this.index + 1 < this.nodesSorted.Count;
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

            public List<List<string>> TotalNQueens(int n) {
                var res = new List<List<string>>();
                bool IsValid(char[][] board, int row, int col) {
                    int n = board.GetLength(0);
                    // 判断列上是否有皇后
                    for (int i = 0; i < n; i++) {
                        if (board[i][col] == 'Q') {
                            return false;
                        }
                    }
                    // 检查右上方是否有皇后互相冲突
                    for (int i = row - 1, j = col + 1; i >= 0 && j < n; i--, j++) {
                        if (board[i][j] == 'Q')
                            return false;
                    }
                    // 检查左上方是否有皇后互相冲突
                    for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--) {
                        if (board[i][j] == 'Q')
                            return false;
                    }
                    return true;
                }
                void Backtrack(char[][] board, int row) {
                    if (row == board.GetLength(0)) {
                        res.Add(board.Select(item => String.Join("", item)).ToList());
                        return;
                    }
                    int cols = board.GetLength(0);
                    for (int col = 0; col < cols; col++) {
                        if (!IsValid(board, row, col)) {
                            continue;
                        }
                        board[row][col] = 'Q';
                        Backtrack(board, row + 1);
                        board[row][col] = '.';
                    }
                }

                var board = new char[n][];
                for (int i = 0; i < n; i++) {
                    var tmp = new char[n];
                    Array.Fill(tmp, '.');
                    board[i] = tmp;
                }
                Backtrack(board, 0);

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
                ListNode MiddleNode(ListNode head) {
                    ListNode slow = head;
                    ListNode fast = head;
                    while (fast.next != null && fast.next.next != null) {
                        slow = slow.next;
                        fast = fast.next.next;
                    }
                    return slow;
                }

                ListNode ReverseList(ListNode head) {
                    ListNode prev = null;
                    ListNode curr = head;
                    while (curr != null) {
                        ListNode nextTemp = curr.next;
                        curr.next = prev;
                        prev = curr;
                        curr = nextTemp;
                    }
                    return prev;
                }

                void MergeList(ListNode l1, ListNode l2) {
                    ListNode l1_tmp;
                    ListNode l2_tmp;
                    while (l1 != null && l2 != null) {
                        l1_tmp = l1.next;
                        l2_tmp = l2.next;

                        l1.next = l2;
                        l1 = l1_tmp;

                        l2.next = l1;
                        l2 = l2_tmp;
                    }
                }
                if (head == null) {
                    return;
                }
                ListNode mid = MiddleNode(head);
                ListNode l1 = head;
                ListNode l2 = mid.next;
                mid.next = null;
                l2 = ReverseList(l2);
                MergeList(l1, l2);
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

            public List<List<int>> Combine(int n, int k) {
                var res = new List<List<int>>();
                var path = new List<int>();
                void Helper(int n, int k, int begin) {
                    if (path.Count == k) {
                        res.Add(path.ToList());
                        return;
                    }

                    for (int i = begin; i <= n; i++) {
                        path.Add(i);
                        Helper(n, k, i + 1);
                        path.RemoveAt(path.Count - 1);
                    }
                }
                if (k <= 0 || n < k) {
                    return res;
                }
                Helper(n, k, 1);
                return res;
            }

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
                    // 还不懂，没明白如何保证不重复
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

            public List<List<int>> CombinationSum(int[] candidates, int target) {
                // candidates中无重复元素，但每个元素可用无限次
                var path = new List<int>();
                var res = new List<List<int>>();

                void Helper(int begin, int sum, int target) {
                    if (sum == target) {
                        res.Add(path.ToList());
                        return;
                    }
                    for (int i = begin; i < candidates.Length; i++) {
                        if ((sum + candidates[i]) <= target) {
                            path.Add(candidates[i]);
                            Helper(i, sum + candidates[i], target);
                            path.RemoveAt(path.Count - 1);
                        } else {
                            break;
                        }
                    }
                }
                if (candidates.Length == 0) {
                    return res;
                }
                Array.Sort(candidates);
                Helper(0, 0, target);
                return res;
            }

            public List<List<int>> Subsets(int[] nums) {
                var path = new List<int>();
                var res = new List<List<int>>();

                void Helper(int curr) {
                    res.Add(path.ToList());
                    for (int i = curr; i < nums.Length; i++) {
                        path.Add(nums[i]);
                        Helper(i + 1);
                        path.RemoveAt(path.Count - 1);
                    }
                }

                if (nums.Length == 0) {
                    return res;
                }
                Array.Sort(nums);
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

            public int[] TopKFrequent(int[] nums, int k) {
                var freqMap = new Dictionary<int, int>();
                foreach (var num in nums) {
                    if (freqMap.ContainsKey(num)) {
                        freqMap[num] += 1;
                    } else {
                        freqMap.Add(num, 1);
                    }
                }
                return new int[] { };
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

            public bool Exist(char[][] board, string word) {
                int h = board.Length;
                int w = board[0].Length;
                var directions = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] {-1, 0 } };
                bool[, ] vis = new bool[h, w];

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

            public int Size(Node head) {
                int len = 0;
                while (head != null) {
                    len++;
                    head = head.next;
                }
                return len;
            }

            public int Size_1(Node head) {
                if (head == null) return 0;
                return Size_1(head.next) + 1;
            }

            public Node Reverse(Node head) {
                if (head == null) return null;
                Node curr = head, prev = null;
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

            public Node Reverse_1(Node head) {
                // 存疑，递归结束条件应该是head != null and head.next == null。
                if (head == null || head.next == null) return head;
                // 把next到最后的链表翻转了。
                Node newHead = Reverse_1(head.next);
                // 此时head的next是newHead链表的最后一个节点，需要让该节点的next指向head。
                head.next.next = head;
                // head指向null，标志链表结束。
                head.next = null;
                return newHead;
            }

            public Node Merge(Node head1, Node head2) {
                if (head1 == null || head2 == null) return head1 == null ? head2 : head1;
                if (head1.val > head2.val) {
                    head2.next = Merge(head1, head2.next);
                    return head2;
                } else {
                    head1.next = Merge(head1.next, head2);
                    return head1;
                }
            }

            public Node Merge_1(Node head1, Node head2) {
                if (head1 == null || head2 == null) return head1 == null ? head2 : head1;
                var dummy = new Node(0);
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
                dummy.next = head1 == null?head2 : head1;
                return dummy.next;
            }

            public bool IsValid(string str) {
                char LeftOf(char c) {
                    if (c == ')') return '(';
                    if (c == ']') return '[';
                    return '{';
                }
                var left = new Stack<char>();
                foreach (var c in str) {
                    if (c == '(' || c == '{' || c == '[') {
                        left.Push(c);
                    } else {
                        // 字符是右括号，要开始和栈顶的左括号匹配。匹配成功，栈顶元素弹出，否则是非法的括号组合
                        if (left.Count != 0 && LeftOf(c) == left.Peek()) {
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
                        map.Add(key, x);
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

                    public int get(int key) {
                        if (!map.ContainsKey(key)) {
                            return -1;
                        }
                        // 如果存在，将该节点提升为最近使用的
                        MakeRecently(key);
                        return map[key].val;
                    }

                    public void put(int key, int val) {
                        // 如果key存在，将key对应的val修改，并提到最近使用
                        if (map.ContainsKey(key)) {
                            map[key].val = val;
                            MakeRecently(key);
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
        }
        static void Main(string[] args) {
            var algorithm = new Algorithm(); <<
            <<
            <<
            <
            HEAD
            System.Console.WriteLine(algorithm.FindTargetSumWays(new int[] { 1, 1, 1, 1, 1 }, 3)); ==
            ==
            ==
            =
            System.Console.WriteLine(algorithm.ValidMountainArray(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })); >>
            >>
            >>
            >
            244e d0f54d24278c77d646165ff2a5afe2c44dde
        }
    }
}