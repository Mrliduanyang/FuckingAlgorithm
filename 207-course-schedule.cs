public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        var indegree = new int[numCourses];
        var adjacency = new List<List<int>>();
        var queue = new Queue<int>();
        for (var i = 0; i < numCourses; i++) adjacency.Add(new List<int>());
        foreach (var node in prerequisites) {
            // node=[0,1]，要学习0，先学习1
            indegree[node[0]]++;
            adjacency[node[1]].Add(node[0]);
        }

        for (var i = 0; i < numCourses; i++)
            if (indegree[i] == 0)
                queue.Enqueue(i);
        while (queue.Count != 0) {
            int pre = queue.Dequeue();
            numCourses--;
            foreach (var cur in adjacency[pre])
                if (--indegree[cur] == 0)
                    queue.Enqueue(cur);
        }

        return numCourses == 0;
    }
}