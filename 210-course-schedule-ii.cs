public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        var indegree = new int[numCourses];
        var adjacency = new List<List<int>>();
        var queue = new Queue<int>();
        var res = new List<int>();

        for (var i = 0; i < numCourses; i++) adjacency.Add(new List<int>());
        foreach (var node in prerequisites) {
            // node=[0,1]，要学习0，先学习1
            indegree[node[0]]++;
            adjacency[node[1]].Add(node[0]);
        }

        for (var i = 0; i < numCourses; i++) // 先找到入度为0的，作为起点
            if (indegree[i] == 0) {
                queue.Enqueue(i);
                res.Add(i);
            }

        while (queue.Count != 0) {
            int pre = queue.Dequeue();
            numCourses--;
            foreach (var cur in adjacency[pre]) // 入度降为0，说明没有前驱课程
                if (--indegree[cur] == 0) {
                    queue.Enqueue(cur);
                    res.Add(cur);
                }
        }

        return numCourses == 0 ? res.ToArray() : new int[] { };
    }
}