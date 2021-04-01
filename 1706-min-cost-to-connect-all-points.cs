public class Solution {
    public int MinCostConnectPoints(int[][] points) {   
     
        if (points.Length < 2) return 0; //如果点数小于2

        List<int[]> pairDis = new List<int[]>();//索引对，距离键值对的泛型列表

        for (var i = 0; i < points.Length; i++)
            for (int j = i + 1; j < points.Length; j++)//每个顶点对 记录一个曼哈顿距离
                pairDis.Add(new int[3] { i, j ,
                    Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]) });

        pairDis.Sort((a, b) => a[2].CompareTo(b[2]));//列表按曼哈顿距离排序

        HashSet<int> nods = new HashSet<int>() { pairDis[0][0] };//列表0号索引对[0]号元素加入哈希表

        var ans = 0;

        while (nods.Count < points.Length)//哈希表数小于节点数, 表示还有节点未加入
        {
            foreach (int[] pair in pairDis)//遍历排序好的键值对距离列表
            {
                if ((nods.Contains(pair[0]) && !nods.Contains(pair[1]))
                    || (nods.Contains(pair[1]) && !nods.Contains(pair[0])))//如果哈希表有且只有一个索引
                {
                    ans += pair[2];//求和曼哈顿距离
                    nods.Add(pair[0]);//节点0加入到哈希表
                    nods.Add(pair[1]);//节点1加入到哈希表
                    break;//退出遍历
                }
            }
        }

        return ans;
    }
}
