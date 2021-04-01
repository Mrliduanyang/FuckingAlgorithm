public class Solution {
    public int RemoveStones(int[][] stones) {
        //一个连通分量一定可以删到只剩一个石头
        // |
        // v
        //确定连通分量数 -> 答案
        //构建图，DFS
        Uf uf = new Uf(20002);
        for(int i =0;i<stones.Length;i++){
            uf.Union(stones[i][0]+10001,stones[i][1]);
        }
        HashSet<int> ccs = new HashSet<int>();
        for(int i =0;i<stones.Length;i++){
            int a = uf.Find(stones[i][1]);
            if(ccs.Contains(uf.Find(stones[i][1]))==false){
                ccs.Add(a);
            }
        }
        return stones.Length - ccs.Count();
    }
    public class Uf{
        int[] p;
        public Uf(int size){
            p = new int[size];
            for(int i=0;i<size;i++){
                p[i] = i;
            }
        }
        public void Union(int x,int y){
            int a = Find(x);
            int b = Find(y);
            if(a!=b){
                p[a] = b;
            }
            return;
        }
        public int Find(int x){
            return p[x]==x?x:p[x]=Find(p[x]);
        }
    }
}
