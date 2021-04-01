public class Solution {
        public int MaxNumEdgesToRemove(int n, int[][] edges) {
            //先添加公用边，然后分别处理Alice和Bob
            //可以并查集
            Uf uf = new Uf(n);
            int[][] edgesA = new int[edges.Length][];
            int[][] edgesB= new int[edges.Length][];
            int endA = 0;
            int endB = 0;
            int result = 0;
            for (int i = 0; i < edges.Length; i++)
            {
                int type = edges[i][0];
                switch (type)
                {
                    case 1:
                        edgesA[endA] = new int[]{edges[i][1]-1,edges[i][2]-1};
                        endA++;
                        break;
                    case 2:
                        edgesB[endB] = new int[]{edges[i][1]-1,edges[i][2]-1};
                        endB++;
                        break;
                    case 3:
                        if (false == uf.Union(edges[i][1]-1,edges[i][2]-1))
                        {
                            result++;
                        }
                        break;
                    default:
                        break;
                }
            }
            Uf ufB = new Uf(uf);
            for (int i = 0; i < endA; i++)
            {
                if (false == uf.Union(edgesA[i][0],edgesA[i][1]))
                {
                    result++;
                }
            }
            if (uf.c!=1)
            {
                return -1;
            }
            for (int i = 0; i < endB; i++)
            {
                if (false == ufB.Union(edgesB[i][0],edgesB[i][1]))
                {
                    result++;
                }
            }
            return ufB.c==1?result:-1;
        }
        public class Uf{
            int[] p;
            public int c;
            public Uf(int n){
                p  =new int[n];
                for (int i = 0; i < p.Length; i++)
                {
                    p[i]=i;
                }
                c = n;
            }
            public Uf(Uf uf){
                p = new int[uf.p.Length];
                for (int i = 0; i < p.Length; i++)
                {
                    p[i] = uf.p[i];
                }
                c = uf.c;
            }
            public bool Union(int x,int y){
                int rootx = Find(x);
                int rooty = Find(y);
                if (rootx==rooty)
                {
                    return false;
                }
                p[rooty] = p[rootx];
                c--;
                return true;
            }

            private int Find(int y)
            {
                return p[y]==y?y:p[y] = Find(p[y]);
            }

        }

}
