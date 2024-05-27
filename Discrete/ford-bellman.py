import math

# стандартный пример, на котором разбирали
# gr = [(1, 2, 1), (2, 3, 8), (3, 4, 1), (4, 3, 2), (2, 4, 7), (3, 5, -5), (5, 4, 4), (1, 5, 3), (2, 5, 1)]
# number_of_vertices = 5

# контур отрицательного веса для проверки
# gr = [(1, 2, 4), (6, 2, 3), (3, 6, -2), (6, 5, -3), (1, 3, 4), (4, 1, 3), (3, 5, 4), (4, 3, 2), (5, 4, 1), (5, 7, -2), (7, 6, 2), (7, 8, 2), (8, 5, -2)]
# number_of_vertices = 8

# тестовый граф
gr = [(1, 2, 7), (2, 3, 5), (3, 4, 2), (4, 5, 3), (5, 6, 3), (6, 9, 1), (9, 8, 2), (8, 7, 6), (7, 10, 4), (10, 11, 10), (11, 12, 3), (1, 6, 2), (2, 5, 8), (4, 7, 8), (5, 8, 1), (8, 11, 8), (9, 12, 1), (1, 5, 9), (2, 6, 2), (2, 4, 4), (3, 5, 9), (6, 8, 6), (5, 9, 7), (5, 7, 5), (4, 8, 3), (8, 10, 7), (7, 11, 4), (9, 11, 6), (8, 12, 5)]
gr += [(x[1], x[0], x[2]) for x in gr]
number_of_vertices = 12

inf = math.inf
start = 3

class Matrix:
    def __init__(self, number_of_vert):
        self.array = []
        for i in range(number_of_vert):
            ar = [inf for _ in range(number_of_vert)]
            for line in [x for x in gr if x[0] == i + 1]:
                ar[line[1] - 1] = line[2]
            self.array.append(ar)

    def __str__(self):
        return str("\n".join([str(x) for x in self.array]))

    def get_column(self, index):
        return [x[index] for x in self.array]


matrix = Matrix(number_of_vertices)
start -= 1  # сдвиг для индексов
lam = [0 if i == start else inf for i in range(number_of_vertices)]

for i in range(number_of_vertices + 1):
    lam_before = lam[:]
    for k in range(number_of_vertices):
        lam[k] = min(lam[k], min([lam_before[x] + matrix.get_column(k)[x] for x in range(number_of_vertices)]))
    if all([lam[x] == lam_before[x] for x in range(number_of_vertices)]):
        break
    if lam_before != lam and i == number_of_vertices:
        print("Есть контур отрицательного веса!")
        exit(0)

for i in range(number_of_vertices):
    path = [i]
    if i != start:
        length = lam[i]
        while length != 0:
            for j in range(number_of_vertices):
                if lam[j] + matrix.get_column(path[-1])[j] == length:
                    length -= matrix.get_column(path[-1])[j]
                    path.append(j)
                    break

    print("to", i + 1, ", len =", lam[i], ", through", list(reversed([x + 1 for x in path])))