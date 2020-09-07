class Node:
    def __init__(self):
        self.pos = None
        self.data = None
        self.next = None


class SymbolTable:
    def __init__(self):
        self.head = None
        self.count = -1

    def addSymbol(self, data):
        curr = self.head
        if curr is None:
            n = Node()
            n.data = data
            self.count += 1
            n.pos = self.count
            self.head = n
            return
        if str(curr.data) > str(data):
            n = Node()
            self.count += 1
            n.pos = self.count
            n.data = data
            n.next = curr
            self.head = n
            return
        while curr.next is not None:
            if str(curr.next.data) > str(data):
                break
            curr = curr.next
        n = Node()
        self.count += 1
        n.pos = self.count
        n.data = data
        n.next = curr.next
        curr.next = n
        return

    def getSymbol(self, data):
        curr = self.head
        while curr is not None:
            if curr.data == data:
                return curr.pos
            curr = curr.next
        return None

    def __str__(self):
        st = ""
        curr = self.head
        while curr is not None:
            st += str(curr.pos) + " " + str(curr.data) + "\n"
            curr = curr.next
        return st
