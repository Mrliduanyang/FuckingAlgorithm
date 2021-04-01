/*
// Definition for a QuadTree node.
public class Node {
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node() {
        val = false;
        isLeaf = false;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val, bool _isLeaf) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val,bool _isLeaf,Node _topLeft,Node _topRight,Node _bottomLeft,Node _bottomRight) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
    }
}
*/

public class Solution {
    public Node Construct(int[][] grid) {
                        Node subConstruct(int[][] grid, int i, int j, int length) {
                    if (length == 1) return new Node(grid[i][j] == 1 ? true : false, true);
                    bool mark = true;
                    int num = grid[i][j];
                    for (int a = i; a < i + length; ++a) {
                        for (int b = j; b < j + length; ++b) {
                            if (num != grid[a][b]) {
                                mark = false;
                                break;
                            }
                        }
                    }
                    if (mark) return new Node(grid[i][j] == 1 ? true : false, true);
                    Node curNode = new Node(true, false);
                    curNode.topLeft = subConstruct(grid, i, j, length / 2);
                    curNode.topRight = subConstruct(grid, i, j + length / 2, length / 2);
                    curNode.bottomLeft = subConstruct(grid, i + length / 2, j, length / 2);
                    curNode.bottomRight = subConstruct(grid, i + length / 2, j + length / 2, length / 2);
                    return curNode;
                }
                return subConstruct(grid, 0, 0, grid.Length);
    }
}