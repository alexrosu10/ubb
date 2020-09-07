from Controller import Controller

if __name__ == '__main__':
    #controller = Controller('input.txt')
    controller = Controller('scanner\\input.txt')
    print(controller.table)
    controller.run()
    print(controller.derivString)
