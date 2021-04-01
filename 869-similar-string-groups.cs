public class Solution
{
    public int NumSimilarGroups(string[] strs)
    {
        var n = strs.Length;
        var uf = new UnionFind(n);
        for (int i = 0; i < n; ++i)
        {
            for (int j = i + 1; j < n; ++j)
            {
                if (Check(strs[i], strs[j]))
                {
                    uf.Merge(i, j);
                }
            }
        }
        return uf.Size;
    }
    private bool Check(string str1, string str2)
    {
        if (str1.Length != str2.Length) return false;
        var n = str1.Length;
        var count_diff = 0;
        for (int i = 0; i < n; ++i)
        {
            if (str1[i] != str2[i])
            {
                ++count_diff;
                if (count_diff > 2)
                {
                    return false;
                }
            }
        }
        return count_diff != 1;
    }
}
public class UnionFind
{
    private int[] parent;
    private int n;
    private int size;
    public int Size { get { return size; } }
    public UnionFind(int _n)
    {
        n = _n;
        size = _n;
        parent = new int[_n];
        for (int i = 0; i < _n; ++i)
        {
            parent[i] = i;
        }
    }
    public bool IsConnected(int _x, int _y)
    {
        return Find(_x) == Find(_y);
    }
    private int Find(int _x)
    {
        if (parent[_x] == _x) return _x;
        return parent[_x] = Find(parent[_x]);
    }
    public void Merge(int _x, int _y)
    {
        var root_x = Find(_x);
        var root_y = Find(_y);
        if (root_x == root_y) return;
        parent[root_x] = root_y;
        --size;
    }
}
