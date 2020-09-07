from scanner.SymbolTable import SymbolTable
from scanner.PIF import ProgramInternalForm
from scanner.Scanner import Scanner

if __name__ == '__main__':
    fileName = "program.txt"
    symbolTable = SymbolTable()
    pif = ProgramInternalForm()
    scanner = Scanner(symbolTable,pif)

    lineNr = 0
    with open(fileName, 'r') as file:
        for line in file:
            print(line)
            lineNr += 1
            try:
                newLine = list(line)
                newLine.remove("\n")
                scanner.scanLine(newLine,lineNr)
            except ValueError:
                scanner.scanLine(newLine,lineNr)

    with open('input.txt','w') as file2:
        file2.write(scanner.pif.__str__())
    print(scanner)
