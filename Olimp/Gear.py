class Gear:
    def __init__(self, number, points, speed, rotation) -> None:
            self.number = number
            self.points = points
            self.speed = speed
            self.rotation = rotation
            self.conns = []

    def __str__(self) -> str:
        return f"gear:[{self.number}, points: {self.points}, speed(from start): {self.speed}, rotation: {self.rotation}, conns: {self.conns}]"

    def conn(self, what):
        self.conns.append(what)

    def reconnect(self, data):
        for i in self.conns:
            if data[i].rotation == 0:
                data[i].rotation = -self.rotation
                data[i].speed = self.speed * self.points / data[i].points
            elif data[i].rotation == self.rotation:
                return False
            elif round(data[i].speed * data[i].points, 3) != round(self.speed * self.points, 3):
                print("Ошибка скоростей")
                print("уже", data[i].speed * data[i].points, "для", data[i].number)
                print("надо", self.speed * self.points, "для", self.number)
                return False
        return True


    def check(self, data):
        for i in data:
            if i.rotation == self.rotation:
                return False
        return True


with open("a") as f:
    n, m = [int(x) for x in f.readline().split(" ")]
    gears = [None for _ in range(n)]
    for i in range(n):
        number, points = [int(x) for x in f.readline().split(" ")]
        gears[number - 1] = Gear(number, points, 0, 1 if i == 0 else 0)

    error = False
    data = []
    for i in range(m):
        a, b = [int(x) for x in f.readline().split(" ")]
        data.append((a, b) if b > a else (b, a))

    start, end = [int(x) for x in f.readline().split(" ")]
    gears[0].rotation = int(f.readline())
    gears[0].speed = 1

    print(data)

    for i in range(m):
        a, b = data[i]
        gears[a - 1].conn(b - 1)
        gears[b - 1].conn(a - 1)

    connected = []
    for i in gears:
        if not i.reconnect(gears):
            print("Ошибка")

    print("\n".join([str(x) for x in gears]))