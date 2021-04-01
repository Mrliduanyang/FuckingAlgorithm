public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        // 第一步 统计每种任务的数量
        var types = new int[26];
        foreach (var item in tasks) types[item - 'A'] = types[item - 'A'] + 1;

        // 第二步 对任务数量进行排序
        Array.Sort(types);

        //第三步 根据任务量最多（如A任务）的任务计算时间
        var max = types[25];
        var time = (max - 1) * (n + 1) + 1; // 最多任务为max，那么间隔有max-1个，间隔时间加上本身任务的运行时间
        var i = 24;

        //第四步 检查是否还有和任务最多数量一样多的任务，统计最后一个A运行完之后是否还有任务，这取决于和A数量一样多的任务
        while (i >= 0 && types[i] == max) {
            time++;
            i--;
        }

        return Math.Max(time, tasks.Length);
    }
}