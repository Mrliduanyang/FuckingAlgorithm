public class Node {
                    public Node(int k, int v) {
                        key = k;
                        val = v;
                    }
                    public int key, val;
                    public Node next, prev;
                }

                public class DoubleList {
                    public Node head, tail;
                    public int size;

                    public DoubleList() {
                        head = new Node(0, 0);
                        tail = new Node(0, 0);
                        head.next = tail;
                        tail.prev = head;
                        size = 0;
                    }

                    public void AddLast(Node x) {
                        // 把x插入到tail之前
                        x.prev = tail.prev;
                        x.next = tail;
                        tail.prev.next = x;
                        tail.prev = x;
                        size++;
                    }

                    public void Remove(Node x) {
                        x.prev.next = x.next;
                        x.next.prev = x.prev;
                        size--;
                    }

                    public Node RemoveFirst() {
                        if (head.next == tail) {
                            return null;
                        }
                        Node first = head.next;
                        Remove(first);
                        return first;
                    }

                    public int Size() {
                        return size;
                    }
                }

public class LRUCache {
                    public Dictionary<int, Node> map;
                    public DoubleList cache;
                    public int cap;

                    public LRUCache(int capacity) {
                        cap = capacity;
                        map = new Dictionary<int, Node>();
                        cache = new DoubleList();
                    }

                    // 将key对应node提升为最近使用的，也就是把node从表头删除，插入到表尾
                    public void MakeRecently(int key) {
                        Node x = map[key];
                        cache.Remove(x);
                        cache.AddLast(x);
                    }

                    // 添加最近使用的node，初始化一个node，并插入到表尾，同时在map中添加映射
                    public void AddRecently(int key, int val) {
                        Node x = new Node(key, val);
                        cache.AddLast(x);
                        map[key] = x;
                    }

                    // 删除某一个key，从表中删除，从map中删除
                    public void DeleteKey(int key) {
                        Node x = map[key];
                        cache.Remove(x);
                        map.Remove(key);
                    }

                    // 删除最久未使用的，即表头节点
                    public void RemoveLeastRecently() {
                        Node deleteNode = cache.RemoveFirst();
                        int key = deleteNode.key;
                        map.Remove(key);
                    }

                    public int Get(int key) {
                        if (!map.ContainsKey(key)) {
                            return -1;
                        }
                        // 如果存在，将该节点提升为最近使用的
                        MakeRecently(key);
                        return map[key].val;
                    }

                    public void Put(int key, int val) {
                        // 如果key存在，将key对应的val修改，并提到最近使用
                        if (map.ContainsKey(key)) {
                            map[key].val = val;
                            MakeRecently(key);
                            return;
                        }
                        // 如果缓存满了，删除掉最近最少使用的元素
                        if (cap == cache.Size()) {
                            RemoveLeastRecently();
                        }
                        // 添加最近使用元素
                        AddRecently(key, val);
                    }
                }