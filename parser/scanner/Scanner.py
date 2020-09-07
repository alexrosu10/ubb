import re


class Scanner:
    def __init__(self, st, pif):
        self.operators = ["=", "+", "-", "*", "/", ">", "<", "<=", ">=", "==", "<>"]
        self.separators = ["{", "}", "(", ")", ";"]
        self.reservedWords = ["main", "char", "integer", "READ", "PRINT", "IF", "THEN", "ELSE", "WHILE", "DO"]
        specialSymbols = ["identifiers", "constants"] + self.reservedWords+self.operators+self.separators
        self.st = st
        self.pif = pif
        self.codifTable = dict([(specialSymbols[i], i) for i in range(len(specialSymbols))])
        print(self.codifTable)

    def isItConstant(self, token):
        if re.fullmatch('^(0|[\+\-]?[1-9][0-9]*)$|^\'.\'$', token) is not None:
            symbol = self.st.getSymbol(token)
            if symbol is not None:
                self.pif.add("1", symbol)
                return True
            self.st.addSymbol(token)
            symbol = self.st.getSymbol(token)
            self.pif.add("1", symbol)
            return True
        return False

    def isItIdentifier(self, token):
        if re.fullmatch('^[a-zA-Z]([a-zA-Z]|[0-9]|_){,249}(\[([0-9]|[1-9][0-9]+)\])?$', token) is not None:
            symbol = self.st.getSymbol(token)
            if symbol is not None:
                self.pif.add("0", symbol)
                return True
            self.st.addSymbol(token)
            symbol = self.st.getSymbol(token)
            self.pif.add("0", symbol)
            return True
        return False

    def isItReserved(self, token):
        if token in self.operators or token in self.separators or token in self.reservedWords:
            self.pif.add(self.codifTable.get(token), "-1")
            return True
        return False

    def scanLine(self, line, lineNr):
        token = ""
        flag = False
        for i in range(len(line)):

            if(line[i] == " "):
                if token != "":
                    if not self.isItConstant(token) and not self.isItReserved(token) and not self.isItIdentifier(token):
                        raise Exception("Error,unexpected token on line " +str(lineNr))
                    token = ""
                continue

            #if character is not operator or separator add it to current token

            if ((line[i] in self.operators) is False) and ((line[i] in self.separators) is False) and (line[i] != " "):
                token += line[i]

            #if character is operator

            if line[i] in self.operators:
                if flag:
                    flag = False
                    continue

                #check if current token is a viable token

                if token != "":
                    if (not self.isItConstant(token)) and (not self.isItReserved(token)) and (not self.isItIdentifier(token)):
                        raise Exception("Error,unexpected token on line "+str(lineNr))
                    token = ""

                #see if we can make compound operator with what comes next unless it's end of line

                if line[i + 1] is not None:

                    #if next character is also an operator, add it to token and check if token is viable

                    if line[i + 1] in self.operators:
                        token = line[i] + line[i + 1]
                        flag = True
                        if not self.isItReserved(token):
                            raise Exception("Error,unexpected token on line " +str(lineNr))
                        token = ""
                        continue

                    #if there isn't another operator after this one, check if this one is viable

                    else:
                        token = line[i]
                        if not self.isItReserved(token):
                            raise Exception("Error,unexpected token on line" +str(lineNr))
                        token = ""
                        continue

                #if what comes next is end of line, just check if this is a viable operator

                else:
                    token = line[i]
                    if not self.isItReserved(token):
                        raise Exception("Error,unexpected token on line "+str(lineNr))
                    token = ""
                    continue

            #if this character is a separator

            if line[i] in self.separators:

                #check if existing token is viable

                if token != "":
                    if not self.isItConstant(token) and not self.isItReserved(token) and not self.isItIdentifier(token):
                        raise Exception("Error,unexpected token on line " +str(lineNr))
                    token = ""

                #now check if this separator is viable

                token = line[i]
                if not self.isItReserved(token):
                    raise Exception("Error,unexpected token on line " +str(lineNr))
                token = ""
                continue
        if token != "":
            if not self.isItConstant(token) and not self.isItReserved(token) and not self.isItIdentifier(token):
                raise Exception("Error,unexpected token on line " + str(lineNr))
            token = ""

    def __str__(self):
        return "st\n" + str(self.st) + "\npif:\n" + str(self.pif)
