public class Solution {
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) {
        int n = accounts.Count;
        Djset ds = new Djset(n);
        Hashtable hs = new Hashtable();
        for(int i = 0; i < n; i++){
            int m = accounts[i].Count;
            for(int j = 1; j < m; j++){
                string mail = accounts[i][j];
                if(!hs.Contains(mail)){
                    hs.Add(mail, i);
                }
                else{
                    ds.Merge((int)hs[mail], i);
                }
            }
        }
        Hashtable hs2 = new Hashtable();
        IList<IList<string>> ans = new List<IList<string>>();
        foreach(DictionaryEntry item in hs){
            int root = ds.Find((int)(item.Value));
            if(!hs2.Contains(root)){
                IList<string> temp = new List<string>();
                temp.Add(item.Key as string);
                hs2.Add(root, temp);
            }
            else{
                (hs2[root] as List<string>).Add(item.Key as string);
            }
        }
        foreach(DictionaryEntry item in hs2){
            List<string> temp = item.Value as List<string>;
            temp.Sort(string.CompareOrdinal);
            temp.Insert(0, accounts[(int)item.Key][0]);
            ans.Add(temp);
        }
        return ans;
    }
}

public class Djset{
    private int[] parent;
    private int[] rank;

    public Djset(int n){
        parent = new int[n];
        rank = new int[n];
        for(int i = 0; i < n; i++){
            parent[i] = i;
        }
    }

    public int find(int x){
        if(x != parent[x]){
            parent[x] = find(parent[x]);
        }
        return parent[x];
    }

    public int Find(int x){
        return find(x);
    }

    public void Merge(int x, int y){
        int rootx = find(x);
        int rooty = find(y);
        if(rootx == rooty){
            return;
        }
        if(rank[rootx] > rank[rooty]){
            parent[rooty] = rootx;
        }
        else{
            parent[rootx] = rooty;
            if(rootx == rooty){
                rank[rooty]++;
            }
        }
    }
}

// 作者：hikiman
// 链接：https://leetcode-cn.com/problems/accounts-merge/solution/cbing-cha-ji-by-hikiman-2ng4/
// 来源：力扣（LeetCode）
// 著作权归作者所有。商业转载请联系作者获得授权，非商业转载请注明出处。