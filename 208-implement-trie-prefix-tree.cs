public class Trie {
    private readonly TireNode root;

    public Trie() {
        root = new TireNode();
    }

    public void Insert(string word) {
        var node = root;
        foreach (var ch in word) {
            if (node.next[ch - 'a'] == null) node.next[ch - 'a'] = new TireNode();
            node = node.next[ch - 'a'];
        }

        node.isEnd = true;
    }

    public bool Search(string word) {
        var node = root;
        foreach (var ch in word) {
            node = node.next[ch - 'a'];
            if (node == null) return false;
        }

        return node.isEnd;
    }

    public bool StartsWith(string prefix) {
        var node = root;
        foreach (var ch in prefix) {
            node = node.next[ch - 'a'];
            if (node == null) return false;
        }

        return true;
    }

    private class TireNode {
        public bool isEnd;
        public readonly TireNode[] next;

        public TireNode() {
            isEnd = false;
            next = new TireNode[26];
        }
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */