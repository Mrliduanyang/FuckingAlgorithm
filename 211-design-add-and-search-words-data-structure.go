package main

type TrieNode struct {
	children [26]*TrieNode
	isEnd    bool
}

func (t *TrieNode) Insert(word string) {
	node := t
	for _, ch := range word {
		ch -= 'a'
		if node.children[ch] == nil {
			node.children[ch] = &TrieNode{}
		}
		node = node.children[ch]
	}
	node.isEnd = true
}

type WordDictionary struct {
	trieRoot *TrieNode
}

func Constructor() WordDictionary {
	return WordDictionary{&TrieNode{}}
}

func (this *WordDictionary) AddWord(word string) {
	this.trieRoot.Insert(word)
}

func (this *WordDictionary) Search(word string) bool {
	var helper func(int, *TrieNode) bool
	helper = func(idx int, node *TrieNode) bool {
		if idx == len(word) {
			return node.isEnd
		}

		ch := word[idx]
		if ch != '.' {
			child := node.children[ch-'a']
			if child != nil && helper(idx+1, child) {
				return true
			}
		} else {
			for i := range node.children {
				child := node.children[i]
				if child != nil && helper(idx+1, child) {
					return true
				}
			}
		}
		return false
	}
	return helper(0, this.trieRoot)
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * obj := Constructor();
 * obj.AddWord(word);
 * param_2 := obj.Search(word);
 */
