import copy

class State:
    def __init__(self,grammar):
        self.state = []
        self.grammar = grammar

    def addProduction(self,prod):
        self.state.append(prod)

    def removeProduction(self,prod):
        self.state.remove(prod)

    def getProductions(self):
        return self.state

    def getElems(self):
        """
        :return: the set of elements of the productions contained in the state
        """
        lis = []
        for prod in self.state:
            for val in prod.values():
                for elem in val:
                    if elem not in lis and elem != '.':
                        lis.append(elem)
        return lis

    def getElementAfterDotInProduction(self,prod: dict):
        """
        :param prod: the production on which we work on
        :return: the element after dot in given production
        """
        elementAfterDot = None
        for key in prod.keys():
            vals: list = prod[key]
        for i in range(vals.__len__()):
            if vals[i] == ".":
                if i<vals.__len__()-1:
                    elementAfterDot = vals[i+1]
        return elementAfterDot

    def closure(self, prod: dict):
        """
        Performs closure by doing the following:
            - creates empty state
            - adds to it the given production
            - if the given production has a nonterminal after the dot, add all productions of this nonterminal in the
            state with a dot in front
            - checks each production to see if the dot is in front of a nonterminal and adds their productions as well
        :param prod: the given production
        :return: a state with all the productions
        """
        state = State(self.grammar)
        state.addProduction(prod)
        i = 0
        while True:

            elementAfterDot = self.getElementAfterDotInProduction(state.state[i])
            if elementAfterDot != None:
                if elementAfterDot in self.grammar.nonTerminals:
                    for production in self.grammar.productions:
                        if elementAfterDot in production.keys():
                            vals: list = copy.deepcopy(production[elementAfterDot])
                            newVals = []
                            newVals.append('.')
                            for val in vals:
                                newVals.append(val)
                            newProd = dict()
                            newProd[elementAfterDot] = newVals
                            exists = False
                            for product in state.state:
                                if product == newProd:
                                    exists = True
                            if not exists:
                                state.addProduction(newProd)

            i = i+1
            if i == state.state.__len__():
                break

        return state

    def goto(self,element):
        """
        Performs goto by taking the given element and, if it is located after the dot in the current state, moves the
        dot behind it and then performs closure, or returns empty state otherwise
        :param element: the given element
        :return: the state after closure
        """
        state = copy.deepcopy(self)
        for value in state.state:
            elementAfterDot = self.getElementAfterDotInProduction(value)
            if elementAfterDot == element:
                for key in value.keys():
                    vals:list = value[key]
                    vals.remove('.')
                    for i in range(vals.__len__()):
                        if vals[i] == element:
                            if i == vals.__len__()-1:
                                vals.append('.')
                            else:
                                vals.insert(i+1,'.')
                            return self.closure(value)
        return State(self.grammar)

    def __eq__(self, other):
        if self.state.__len__() != other.state.__len__():
            return False
        differences = self.state.__len__()
        for value in self.state:
            for otherValue in other.state:
                if value == otherValue:
                    differences -= 1
        if differences == 0:
            return True
        return False

    def __str__(self):
        str = ""
        for prod in self.state:
            str += prod.__str__()+"   "
        return str
