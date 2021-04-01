public class Solution {
    public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H) {
        var length = C - A;
        var height = D - B;
        var area = length * height;

        length = G - E;
        height = H - F;
        var area2 = length * height;

        if (A >= G || C <= E || B >= H || D <= F)
            return area + area2;

        int left_x = Math.Max(A, E);
        int right_x = Math.Min(C, G);
        int left_y = Math.Max(B, F);
        int right_y = Math.Min(D, H);

        length = right_x - left_x;
        height = right_y - left_y;
        var area3 = length * height;
        return area + area2 - area3;
    }
}