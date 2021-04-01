public class Solution {
public int RegionsBySlashes(string[] grid) {
            //_______
            //|\ 0 /|
            //|3\ /1|
            //| / \ |
            //|/ 2 \|
            //-------
            int n = grid.Length;
            Uffff uf = new Uffff(n);
            for (int i = 0; i < n; i++)
            {
                string line = grid[i];
                for (int j = 0; j < line.Length; j++)
                {
                    int part1 = i*4*n+j*4;
                    if (line[j]=='\\')
                    {
                        uf.Union(part1,part1+1);
                        uf.Union(part1+2,part1+3);

                    }else if(line[j]=='/'){
                        uf.Union(part1,part1+3);
                        uf.Union(part1+1,part1+2);
                    }
                    else{

                        uf.Union(part1,part1+1);
                        uf.Union(part1,part1+2);
                        uf.Union(part1,part1+3);
                    }
                    //向右向下连接
                    if (i<n-1)
                    {
                        int partDown = (i+1)*4*n+j*4;
                        uf.Union(part1+2,partDown);
                    }
                    if(j<n-1){
                        int partRight = i*4*n+(j+1)*4+3;
                        uf.Union(part1+1,partRight);
                    }
                }
                
            }
            return uf.pCount;
        }
        public class Uffff{
            int[] p;
            public int pCount;
            public Uffff(int n){
                p = new int[n*n*4];
                pCount= n*n*4;
                Init();
            }

            private void Init()
            {
                for (int i = 0; i < p.Length; i++)
                {
                    p[i]=i;
                }
            }

                        public void Union(int x, int y)
            {
                int rootx = Find(x);
                int rooty = Find(y);
                if (rootx==rooty)
                {
                    return;
                }
                p[rooty] = rootx;
                pCount--;
            }

            private int Find(int y)
            {
                return p[y]==y?y:p[y] = Find(p[y]);
            }
        }
    
}
