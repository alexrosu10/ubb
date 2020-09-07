class ProgramInternalForm:
    def __init__(self):
        self.content = []

    def add(self, code, id):
        self.content.append((code, id))

    def __str__(self):
        st = ""
        for entry in self.content:
            st += str(entry[0]) + "\n"
        st = st[:-1]
        return st
