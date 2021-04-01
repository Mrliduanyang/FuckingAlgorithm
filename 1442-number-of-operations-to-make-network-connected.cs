public class Solution {
    public class Uf{
        int[] p;
        public int count;
        public Uf(int n){
            p = new int[n];
            count = n;
            for(int i =0;i<n;i++){
                p[i]=i;
            }
        }
        public bool Union(int x,int y){
            int rootx= Find(x);
            int rooty = Find(y);
            if(rootx == rooty) return false;
            p[rooty] = p[rootx];
            count--;
            return true;
        }
        private int Find(int x){
            return p[x]==x?x:p[x]=Find(p[x]);
        }
    }
    public int MakeConnected(int n, int[][] connections) {
        Uf uf = new Uf(n);
        int lines = 0;
        for(int i =0; i<connections.Length;i++){
            if(uf.count==0) return 0;
            if(false == uf.Union(connections[i][0],connections[i][1])){
                lines++;
            }
        }
        return lines>=uf.count-1?uf.count-1:-1;
    }
}
