from collections import deque
from Tuple import Tuple
from Table import Table
from RG import Grammar
from copy import deepcopy

class Controller:
    def __init__(self, inputFile):
        self.inputStack = deque()
        tup = Tuple()
        tup.x = '$'
        tup.y = 0
        self.workingStack = deque([tup])
        self.outputStack = []
        self.inputFile = inputFile
        self.grammar = Grammar()
        #self.grammar.readFromFile("grammar.txt")
        self.grammar.readFromFile("myGrammar.txt")
        self.table = Table(self.grammar)
        self.table.makeCanonicalCollection()
        self.table.makeTable()
        self.operators = ["=", "+", "-", "*", "/", ">", "<", "<=", ">=", "==", "<>"]
        self.separators = ["{", "}", "(", ")", ";"]
        self.reservedWords = ["main", "char", "integer", "READ", "PRINT", "IF", "THEN", "ELSE", "WHILE", "DO"]
        specialSymbols = ["identifier", "constant"] + self.reservedWords + self.operators + self.separators
        self.codificTable = dict([(i, specialSymbols[i]) for i in range(len(specialSymbols))])
        #self.readInput()
        self.readGrammar()
        self.derivString = ""

    def readInput(self):
        """
        Reads the sequence to be parsed and inserts that sequence into the input stack.
        :return: the input stack
        """
        lis = []
        with open(self.inputFile,'r') as file:
            for line in file:
                line = line.strip()
                lis.append(line)
        lis.append('$')
        lis.reverse()
        self.inputStack = deque(lis)
        return self.inputStack

    def readGrammar(self):
        """
        Reads the sequence to be parsed and inserts that sequence into the input stack.(this one reads the pif)
        :return: the input stack
        """
        lis = []
        with open(self.inputFile,'r') as file:
            for line in file:
                line = line.strip()
                token = self.codificTable.get(int(line))
                lis.append(token)
        lis.append('$')
        lis.reverse()
        self.inputStack = deque(lis)
        return self.inputStack

    def advance(self):
        """
        Parses the sequence.
            -if action is accept stops advancing and returns.
            -if action is shift takes the top of the input stack and puts it in working stack along with the goto part
            of the top of the working stack and the top of the input stack and advances
            -if action is reduce pop from the working stack the production that the action parameter (the production number)
            dictates and replaces that production with it's key and with the goto part of the top of the remaining
            working stack and that key (the nonterminal)
        :return:
        """
        topWorkingStack = self.workingStack.pop()
        self.workingStack.append(topWorkingStack)
        action = self.table.table[topWorkingStack.y][0].x
        actionParameter = self.table.table[topWorkingStack.y][0].y
        if action == 'accept':
            return
        elif action == 'shift':
            tup = Tuple()
            tup.x = self.inputStack.pop()
            if tup.x not in self.table.table[topWorkingStack.y][1].keys():
                raise Exception('Gramatical error')
            tup.y = self.table.table[topWorkingStack.y][1][tup.x]
            self.workingStack.append(tup)
            self.advance()
        elif action == 'reduce':
            for value in self.grammar.productions[actionParameter].values():
                length = value.__len__()
            for i in range(length):
                self.workingStack.pop()
            for key in self.grammar.productions[actionParameter].keys():
                topWorkingStack = self.workingStack.pop()
                self.workingStack.append(topWorkingStack)
                tup = Tuple()
                tup.x=key
                tup.y=self.table.table[topWorkingStack.y][1][tup.x]
                self.workingStack.append(tup)
                self.outputStack.append(actionParameter)
                self.advance()

    def createDerivationsString(self, prodNumber, previousProd, nonTerminal):
        """
        Transforms a productions string into a derivations string
        :param prodNumber: the current production in the derivations
        :param previousProd: the previous production
        :param nonTerminal: the non terminal te be replaced by its production
        """
        currentProd = deepcopy(self.grammar.productions[prodNumber])
        vals = currentProd.values()
        previousVals = previousProd.values()
        for prevVal in previousVals:
            previousVal:list = prevVal
        for valCopy in vals:
            posToReplace = -1
            for i in range(previousVal.__len__()):
                if previousVal[i] == nonTerminal:
                    posToReplace = i
            previousVal.remove(previousVal[posToReplace])
            valCopy.reverse()
            for val in valCopy:
                previousVal.insert(posToReplace,val)
            self.derivString+='=> '
            for val in previousVal:
                self.derivString+=val+' '
            if valCopy.__len__()>1:
                for val in valCopy:
                    if val in self.grammar.nonTerminals:
                        self.createDerivationsString(self.outputStack.pop(),previousProd,val)
            elif valCopy.__len__()==1:
                if valCopy[0] in self.grammar.nonTerminals:
                    self.createDerivationsString(self.outputStack.pop(), previousProd, valCopy[0])
                elif valCopy[0] in self.grammar.terminals:
                    return

    def createString(self):
        """
        Creates the derivations string
        """
        firstProdNumber = self.outputStack.pop()
        prod:dict = deepcopy(self.grammar.productions[firstProdNumber])
        nonT = ''
        for val in prod.values():
            for elem in val:
                self.derivString+=elem+' '
            for elem in val:
                if elem in self.grammar.nonTerminals:
                    nonT = elem
                    break
        self.createDerivationsString(self.outputStack.pop(),prod,nonT)

    def run(self):
        self.advance()
        self.createString()
