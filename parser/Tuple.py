class Tuple:
    def __init__(self):
        self.x = None
        self.y = None

    def __str__(self):
        str = ""
        if self.x is not None:
            str += self.x.__str__()+" "
        if self.y is not None:
            str += self.y.__str__()
        return str
