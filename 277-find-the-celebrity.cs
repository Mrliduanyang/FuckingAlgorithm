/* The Knows API is defined in the parent class Relation.
      bool Knows(int a, int b); */

public class Solution : Relation {
    public int FindCelebrity(int n) {
        var candidate = 0;
        for (var i = 0; i < n; i++)
            if (Knows(candidate, i))
                candidate = i;
        for (var i = 0; i < n; i++)
            if (i != candidate) {
                if (!Knows(i, candidate)) return -1;
                if (Knows(candidate, i)) return -1;
            }

        return candidate;
    }
}