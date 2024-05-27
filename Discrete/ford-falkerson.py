start, end = 0, 4
matrix = [
    [[0, 0], [20, 0], [30, 0], [10, 0], [0, 0]],
    [[0, 0], [0, 0], [40, 0], [0, 0], [30, 0]],
    [[0, 0], [0, 0], [0, 0], [10, 0], [20, 0]],
    [[0, 0], [0, 0], [0, 0], [0, 0], [20, 0]],
    [[0, 0], [0, 0], [0, 0], [0, 0], [0, 0]],
]


def print_matrix():
    for i in range(len(matrix)):
        print(matrix[i])


def find_path(a, b):
    if a == b:
        return [a]

    could = sorted([i for i, pair in enumerate(matrix[a]) if pair[0] > 0], key=lambda i: -matrix[a][i][0])
    for c in could:
        if find_path(c, b):
            return [a] + find_path(c, b)


def find_path_with_backtrace(a, b, come):
    if a == b:
        return [(a, False)]

    could = sorted([i for i, pair in enumerate(matrix[a]) if pair[0] > 0], key=lambda i: -matrix[a][i][0])
    if could:
        for c in could:
            if find_path_with_backtrace(c, b, [a] + come):
                return [(a, False)] + find_path_with_backtrace(c, b, [a] + come)
    else:
        variants = [i for i, row in enumerate(matrix) if row[a][1] > 0 and i not in come]
        for v in variants:
            if find_path_with_backtrace(v, b, [v] + come):
                return [(a, True)] + find_path_with_backtrace(v, b, [a] + come)


def find_min_weight(path):
    weights = []
    for i in range(len(path) - 1):
        a, b = path[i], path[i + 1]
        weights.append(matrix[a][b][0])
    return min(weights)


def find_min_weight_with_backtrace(path):
    weights = []
    for i in range(len(path) - 1):
        a, b = path[i], path[i + 1]
        if not a[1]:
            weights.append(matrix[a[0]][b[0]][0])
        else:
            weights.append(matrix[b[0]][a[0]][0])
    return min(weights)


def recount_by(path, weight):
    for i in range(len(path) - 1):
        a, b = path[i], path[i + 1]
        matrix[a][b][0] -= weight
        matrix[a][b][1] += weight


def recount_by_with_backtrace(path, weight):
    for i in range(len(path) - 1):
        a, b = path[i], path[i + 1]
        if not a[1]:
            matrix[a[0]][b[0]][0] -= weight
            matrix[a[0]][b[0]][1] += weight
        else:
            matrix[a[0]][b[0]][0] += weight
            matrix[a[0]][b[0]][1] -= weight

sums = 0

while True:
    path = find_path(start, end)
    if not path:
        break
    min_weight = find_min_weight(path)
    recount_by(path, min_weight)
    sums += min_weight

while True:
    path = find_path_with_backtrace(start, end, [])
    if not path:
        break
    min_weight = find_min_weight_with_backtrace(path)
    recount_by_with_backtrace(path, min_weight)
    sums += min_weight

print(sums)