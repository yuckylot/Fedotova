v = 7
gr = [[0, 1, 1, 1, 0, 0, 0],
      [1, 0, 1, 0, 1, 0, 1],
      [1, 1, 0, 1, 1, 1, 1],
      [1, 0, 1, 0, 1, 1, 1],
      [0, 1, 1, 1, 0, 1, 0],
      [0, 0, 1, 1, 1, 0, 1],
      [0, 1, 1, 1, 0, 1, 0]]


def next_vertex(path):
    could_be = [i for i, x in enumerate(gr[path[-1]]) if x == 1 and i not in path]
    if could_be == [] and len(path) == v:
        if gr[path[0]][path[-1]] == 1:
            print(list(map(lambda x: x + 1, path)), "цикл")
        else:
            print(list(map(lambda x: x + 1, path)), "путь")
        return

    else:
        for i in could_be:
            next_vertex(path + [i])


next_vertex([0])