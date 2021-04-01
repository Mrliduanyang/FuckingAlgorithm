public class Solution {
    private int find_another(int n)
    {
        if(n%2==0)
            return n+1;
        return n-1;
    }
    public int MinSwapsCouples(int[] row) {
        int c=0;
        for(int i=0;i<row.Length;i+=2)
        {
            int p1 = row[i];
            int p2 = find_another(p1);
            if(row[i+1]!=p2)
            {
                int j=Array.IndexOf(row,p2);
                row[i+1]^=row[j];
                row[j]^=row[i+1];
                row[i+1]^=row[j];
                c++;
            }
        }
        return c;
    }
}
