import copy
from State import State
from Tuple import Tuple

class Table:
    def __init__(self,grammar):
        self.table = dict()
        self.stateList = []
        self.grammar = grammar

    def makeCanonicalCollection(self):
        """
        Creates the canonical collection by enriching the grammar and performing closure on the first production, then
        performing goto for each state in the collection until all new states for the given grammar are created
        """
        self.grammar.enrich()
        prod: dict = copy.deepcopy(self.grammar.productions[0])
        prod["!"].insert(0,'.')
        state = State(self.grammar).closure(prod)
        self.stateList.append(state)
        i = 0
        while True:
            elements = self.stateList[i].getElems()
            for elem in elements:
                newSt = self.stateList[i].goto(elem)
                exists = False
                for st in self.stateList:
                    if newSt is not None:
                        if st == newSt:
                            exists = True
                            break
                if not exists and newSt != State(self.grammar):
                    self.stateList.append(newSt)
            i += 1
            if i == self.stateList.__len__():
                break

    def getProductionNumber(self,prod):
        """
        :param prod: the given production
        :return: the number of the given production in the grammars' production list
        """
        productionWithDot = copy.deepcopy(prod)
        valToCompare = list()
        for value in productionWithDot.values():
            value.remove('.')
            valToCompare = value
        for i in range(self.grammar.productions.__len__()):
            for val in self.grammar.productions[i].values():
                if valToCompare == val:
                    return i
        return 0


    def makeTable(self):
        """
        Creates the parsing table by making a tuple of the action to be performed at a state and the actions' parameters
        (which means if the action is reduce, the production number) and making a dictionary for the goto part and filling
        it. These two elements, the tuple and the dictionary, are then put in a list which itself is then put in the
        'table' member of the class.
        """
        for i in range(self.stateList.__len__()):
            actualTable = []

            action = Tuple()
            prod: dict = self.stateList[i].state[0]
            if State(self.grammar).getElementAfterDotInProduction(prod) is None:
                if "!" in prod.keys():
                    if prod["!"] == [self.grammar.startingSymbol,"."]:
                        action.x = "accept"
                else:
                    action.x = "reduce"
                    action.y = self.getProductionNumber(prod)
            else:
                action.x = "shift"

            gotoPart = dict()
            elements = self.stateList[i].getElems()
            for elem in elements:
                for j in range(self.stateList.__len__()):
                    gotoState = self.stateList[i].goto(elem)
                    if gotoState == self.stateList[j]:
                        gotoPart[elem] = j
                        break

            actualTable.append(action)
            actualTable.append(gotoPart)
            self.table[i] = actualTable

    def __str__(self):
        str = ""
        for key in self.table.keys():
            str += key.__str__()+" "
            str += self.table[key][0].__str__()+" "
            for key1 in self.table[key][1].keys():
                str += key1.__str__()+" "+self.table[key][1][key1].__str__()+"   "
            str += "\n"
        return str
