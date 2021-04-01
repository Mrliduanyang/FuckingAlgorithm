public class Solution {
    public IList<IList<int>> FindCriticalAndPseudoCriticalEdges(int n, int[][] edges) {
            int m = edges.Length;
            int[][] newEdges = new int[m][];
            for (int i = 0; i < m; ++i)//增加一个索引位
            {
                newEdges[i] = new int[4];
                for (int j = 0; j < 3; ++j)
                {
                    newEdges[i][j] = edges[i][j];
                }
                newEdges[i][3] = i;
            }
            Array.Sort(newEdges, (x, y) => x[2].CompareTo(y[2]));//权值排序

            UnionFind ufStd = new UnionFind(n);
            int value = 0;
            for (int i = 0; i < m; ++i)//求最小权值和
            {
                if (ufStd.Unite(newEdges[i][0], newEdges[i][1]))
                {
                    value += newEdges[i][2];
                }
            }

            IList<IList<int>> ans = new List<IList<int>>();
            for (int i = 0; i < 2; ++i)
            {
                ans.Add(new List<int>());//答案增加两个新列表集合元素
            }

            for (int i = 0; i < m; ++i)//遍历每条边
            {
                UnionFind uf = new UnionFind(n);//新的并查集
                int v = 0;
                for (int j = 0; j < m; ++j)
                {
                    if (i != j && uf.Unite(newEdges[j][0], newEdges[j][1]))//排除i
                    {
                        v += newEdges[j][2];
                    }
                }
                if (uf.treeCount != 1 || (uf.treeCount == 1 && v > value))//如果有多颗树，或者权值更大，表示是关键边
                {
                    ans[0].Add(newEdges[i][3]);
                    continue;//注意这里，不再继续
                }

                uf = new UnionFind(n);//新的并查集
                uf.Unite(newEdges[i][0], newEdges[i][1]);//并上i号边的端点, 也就是说必定使用第i号边的情况
                v = newEdges[i][2];
                for (int j = 0; j < m; ++j)
                {
                    if (i != j && uf.Unite(newEdges[j][0], newEdges[j][1]))//已经使用了i号，这里要排除i
                    {
                        v += newEdges[j][2];
                    }
                }
                if (v == value)//如果一定使用这条边仍然保持最小生成树的权值，表示是伪关键边
                {
                    ans[1].Add(newEdges[i][3]);//权值并未改变，仍然保持最小生成树的权值，是伪关键边
                }
            }
            (ans[0] as List<int>).Sort();//排个序
            (ans[1] as List<int>).Sort();//排个序
            return ans;
        }

        class UnionFind
        {
            public int n, treeCount;
            readonly int[] parent;

            public UnionFind(int _n)
            {
                n = _n;
                treeCount = n;
                parent = new int[n];
                for (int i = 0; i < n; ++i) parent[i] = i;
            }

            public int Findset(int x)//寻找根节点
            {
                return parent[x] == x ? x : (parent[x] = Findset(parent[x]));
            }

            public bool Unite(int x, int y)//返回是否有合并
            {
                x = Findset(x);
                y = Findset(y);
                if (x == y) return false;
                parent[y] = x;
                treeCount--;
                return true;
            }
        }
    }
