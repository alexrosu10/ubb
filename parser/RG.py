class Grammar:

    def __init__(self):
        self.nonTerminals = []
        self.terminals = []
        self.productions = []
        self.startingSymbol = ""

    def getElements(self):
        lis = []
        for nonT in self.nonTerminals:
            lis.append(nonT)
        for t in self.terminals:
            lis.append(t)
        lis.remove("!")
        return lis

    def enrich(self):
        self.nonTerminals.insert(0, "!")
        prod = dict()
        prod["!"] = [self.startingSymbol]
        self.productions.insert(0, prod)

    def checkLineWithEquals(self, string):
        array = string.split("=", 1)
        if array[0] == "N":
            nonTs = array[1].split(",")
            for nonT in nonTs:
                self.nonTerminals.append(nonT)
            return
        if array[0] == "sigma":
            ts = array[1].split(",")
            for t in ts:
                self.terminals.append(t)
            return
        if array[0] == "S":
            self.startingSymbol = array[1]
            return
        raise Exception("Incorrect definition of grammar in file!")

    def addProduction(self, key, value):
        product = dict()
        lis = []
        values = value.split(' ')
        for val in values:
            lis.append(val)
        product[key] = lis
        self.productions.append(product)

    def readProductionFromLine(self, line):
        string = line.split(">",1)
        key = string[0]
        vals = string[1].split("|")
        for val in vals:
            self.addProduction(key,val)

    def readFromFile(self, fileName):
        productions = False
        with open(fileName, 'r') as file:
            for line in file:
                line = line.strip()
                if line == ".":
                    productions = False
                    continue
                if productions:
                    self.readProductionFromLine(line)
                    continue
                if line.__contains__("="):
                    self.checkLineWithEquals(line)
                    continue
                if line == "P:":
                    productions = True
                    continue

    def checkForStartingSymbol(self):
        ss = False
        for prod in self.productions:
            for terminal in prod.keys():
                if terminal == self.startingSymbol:
                    ss = True
            if ss:
                ss = False
                continue
            for val in prod.values():
                for nonT in val:
                    if nonT.__contains__(self.startingSymbol):
                        return True
        return False

    def checkRightNormal(self, vals, nonT):
        for val in vals:
            if val == "epsilon":
                if nonT != self.startingSymbol:
                    return False
                continue
            if val.__len__() > 2:
                return False
            if val.__len__() == 2:
                if val[1] not in self.nonTerminals:
                    return False
                if val[0] not in self.terminals:
                    return False
            else:
                if val not in self.terminals:
                    return False
        return True

    def micCheckCheckCheck(self):
        for prod in self.productions:
            for nonT in prod.keys():
                if nonT == self.startingSymbol:
                    for val in prod.values():
                        for v in val:
                            if v == "epsilon":
                                if self.checkForStartingSymbol():
                                    return False
            for vals in prod.values():
                for nonT in prod.keys():
                    if not self.checkRightNormal(vals, nonT):
                        return False
        return True

    def productionOfSymbol(self, nonT):
        for prod in self.productions:
            for key in prod.keys():
                if key == nonT:
                    s = key + "->"
                    for val in prod.values():
                        for v in val:
                            s += v + "|"
                    s = s[:-1]
                    return s
        return None

    def createTransitionsForFA(self):
        lis = []
        for prod in self.productions:
            for key in prod.keys():
                for value in prod.values():
                    for val in value:
                        if val.__len__() == 2:
                            dic = {key: [val[0], val[1]]}
                            lis.append(dic)
                        elif val.__len__() == 1:
                            dic = {key: [val, "K"]}
                            lis.append(dic)
        return lis

    def convertToFA(self):
        if self.micCheckCheckCheck():
            states = self.nonTerminals + ["K"]
            symbols = self.terminals
            initialState = self.startingSymbol
            finalStates = []
            for prod in self.productions:
                for key in prod.keys():
                    for value in prod.values():
                        for val in value:
                            if val == "epsilon" and key == self.startingSymbol and key not in finalStates:
                                finalStates.append(key)
            finalStates.append("K")
            transitions = self.createTransitionsForFA()
            return [states, symbols, transitions, initialState, finalStates]
        else:
            return []

    def getParams(self, lis):
        self.nonTerminals = lis[0]
        self.terminals = lis[1]
        self.productions = lis[2]
        self.startingSymbol = lis[3]

    def printableProductions(self):
        s = ""
        for prod in self.productions:
            for key in prod.keys():
                s += key + "->"
            for val in prod.values():
                for v in val:
                    s += v + " "
            s = s[:-1]
            s += "\n"
        return s

    def __str__(self):
        s = "G=({"
        for nonT in self.nonTerminals:
            s += nonT + ","
        s = s[:-1]
        s += "},{"
        for t in self.terminals:
            s += t + ","
        s = s[:-1]
        s += "},P," + self.startingSymbol + ")\nP:\n"
        for prod in self.productions:
            for key in prod.keys():
                s += key + "->"
            for val in prod.values():
                for v in val:
                    s += v + " "
            s = s[:-1]
            s += "\n"
        return s
