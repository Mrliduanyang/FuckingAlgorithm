public class Solution {
    public int[] SortItems(int n, int m, int[] group, IList<IList<int>> beforeItems) {
        //双层拓扑排序
        //给group[i]==-1的任务分配新的groupId
        //组间排序和组内排序
        List<IList<int>> groups = new List<IList<int>>();
        List<IList<int>> groupNext = new List<IList<int>>();
        List<IList<int>> itemNext = new List<IList<int>>();
        IList<int> groupIndexs = new List<int>();
        for (var i = 0; i < n + m; i++) {
            groups.Add(new List<int>());
            groupNext.Add(new List<int>());
            groupIndexs.Add(i);
        }

        for (var i = 0; i < n; i++) itemNext.Add(new List<int>());
        var leftIndex = m;
        for (var i = 0; i < group.Length; i++) {
            if (group[i] == -1) {
                group[i] = leftIndex;
                leftIndex++;
            }

            groups[group[i]].Add(i);
        }

        var itemDeg = new int[n];
        var groupDeg = new int[m + n];

        for (var i = 0; i < beforeItems.Count; i++)
            foreach (var item in beforeItems[i])
                if (@group[item] == @group[i]) {
                    itemDeg[i]++;
                    itemNext[item].Add(i);
                }
                else {
                    groupDeg[@group[i]]++;
                    groupNext[@group[item]].Add(@group[i]);
                }

        List<int> sortedGroup = SortThis(groupDeg, groupNext, groupIndexs);
        //这说明group的拓扑中存在环，导致环中节点的deg无法降至0，这些节点都无法进入排序序列中
        if (sortedGroup.Count != m + n) return new int[0];
        var result = new int[n];
        var index = 0;
        for (var i = 0; i < sortedGroup.Count; i++) {
            int curG = sortedGroup[i];
            var sortInGroup = SortThis(itemDeg, itemNext, groups[curG]);
            if (sortInGroup.Count != groups[curG].Count) return new int[0];
            for (var j = 0; j < sortInGroup.Count; j++) {
                result[index] = sortInGroup[j];
                index++;
            }
        }

        if (index != n) return new int[0];
        return result;
    }

    private List<int> SortThis(int[] deg, List<IList<int>> next, IList<int> items) {
        List<int> result = new List<int>();
        Queue<int> q = new Queue<int>();
        for (var i = 0; i < items.Count; i++)
            if (deg[items[i]] == 0)
                q.Enqueue(items[i]);
        while (q.Count != 0) {
            int cur = q.Dequeue();
            result.Add(cur);
            foreach (var item in next[cur])
                if (--deg[item] == 0)
                    q.Enqueue(item);
        }

        return result;
    }
}