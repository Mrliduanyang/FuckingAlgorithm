public class Solution {
    public int NumTilePossibilities(string tiles) {
        var res = new List<List<int>>();
        var path = new List<int>();
        var vis = new bool[tiles.Length];

        void Helper(int curr) {
            res.Add(path.ToList());
            for (var i = 0; i < tiles.Length; ++i) {
                // 如果当前元素已访问，或者当前元素未访问，但当前元素和前一个元素相等，并且前一个元素访问过
                // 要保证在所有的递归中，每个元素只被访问一次
                if (vis[i] || i > 0 && tiles[i] == tiles[i - 1] && !vis[i - 1]) continue;
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
        // string.Sort(tiles);
        Helper(0);
        return res.Count - 1;
    }
}