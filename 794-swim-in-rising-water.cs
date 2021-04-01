public class Solution
{
    readonly (int, int)[] dirs = new (int, int)[] { (0, -1), (1, 0), (0, 1), (-1, 0) };
    public int SwimInWater(int[][] grid)
    {
        var n = grid.Length;
        var uf = new UnionFind(n * n);
        var height_pos = new (int, int)[n * n];
        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                height_pos[grid[i][j]] = (i, j);
            }
        }
        for (var height = 0; height < n * n; ++height)
        {
            var (pos_x, pos_y) = height_pos[height];
            foreach (var (dir_x, dir_y) in dirs)
            {
                var new_pos_x = pos_x + dir_x;
                var new_pos_y = pos_y + dir_y;
                if (new_pos_x >= 0 && new_pos_x < n && new_pos_y >= 0 && new_pos_y < n && grid[new_pos_x][new_pos_y] <= height)
                {
                    uf.Merge(pos_x * n + pos_y, new_pos_x * n + new_pos_y);
                }
            }
            if (uf.IsConnected(0, n * n - 1)) return height;
        }
        return -1;
    }
}
public class UnionFind
{
    int[] parent;
    int n;
    public UnionFind(int _n)
    {
        n = _n;
        parent = new int[n];
        for (int i = 0; i < n; ++i)
        {
            parent[i] = i;
        }
    }
    public void Merge(int _x, int _y)
    {
        var root_x = Find(_x);
        var root_y = Find(_y);
        if (root_x == root_y) return;
        parent[root_x] = root_y;
    }
    private int Find(int _x)
    {
        if (parent[_x] == _x) return _x;
        return parent[_x] = Find(parent[_x]);
    }
    public bool IsConnected(int _x, int _y)
    {
        return Find(_x) == Find(_y);
    }
}
