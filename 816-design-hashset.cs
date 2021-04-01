public class MyHashSet {
    private readonly int[] data;

    public MyHashSet() {
        data = new int[1000001];
        Array.Fill(data, -1);
    }

    public void Add(int key) {
        data[key] = key;
    }

    public void Remove(int key) {
        data[key] = -1;
    }

    public bool Contains(int key) {
        return data[key] != -1;
    }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */