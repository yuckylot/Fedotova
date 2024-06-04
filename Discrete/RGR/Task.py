def bellman_ford(graph, source):
    vertices = set()
    for edge in graph:
        vertices.add(edge[0])
        vertices.add(edge[1])

    distances = {vertex: float('infinity') for vertex in vertices}
    distances[source] = 0

    for _ in range(len(vertices) - 1):
        for edge in graph:
            u, v, weight = edge
            if distances[u] + weight < distances[v]:
                distances[v] = distances[u] + weight

    for edge in graph:
        u, v, weight = edge
        if distances[u] + weight < distances[v]:
            return -1 

    return distances

def execute_Bellman():
    sums = 0
    with open("./Calculating.txt") as file:
        n = int(file.readline())
        graph = []
        for i in range(n):
            l = list(map(int, file.readline().split(" ")))
            for j in range(n):
                if l[j] != 0:
                    graph.append([i, j, l[j]])
    for i in range(n):
        ep = bellman_ford(graph, i).values()
        for i in ep:
            sums += i
    print(sums)
    f = open("output.txt", "w")
    f.write(str(sums))
    f.close()
    return
                    

def Menu():
    print("--Меню--")
    print("1. Запуск алгоритма Форда-Беллмана")
    print("2. Об авторе")
    print("3. Описание задачи")
    print("4. Выход")
    choose = int(input())
    match choose:
        case 1:
            execute_Bellman()
        case 2:
            print("Выполнил\nСтудент группы Фит-232 \nХарлов Никита Станиславович ")
        case 3: 
            print("""
Дан ориентированный взвешенный полный граф, рёбрам которого приписаны 
некоторые веса (длины). Веса могут быть и положительные, и отрицательные, и 
нулевые. Нас интересует минимум длин всех возможных путей между всеми парами 
различных вершин этого графа. Нужно будет выяснить, существует ли этот минимум, 
и, если существует, вычислить его. (Минимума не существует в том случае, если в 
графе можно найти путь отрицательной длины, сколь угодно большой по модулю). 
Формат входных данных 
В первой строке входного файла задано число вершин N (3≤ N ≤ 50). Далее идёт 
матрица смежности графа, то есть N строк, в каждой из которых записано N чисел. ј-ое 
число в 1-ой строке матрицы смежности задает длину ребра, ведущего из і-й вершину в 
ј-ую. Длины могут принимать значения, не превосходящие 106 по абсолютной 
величине. Гарантируется, что на главной диагонали матрицы стоят нули. 
Формат выходных данных 
В выходной файл вывести одно число искомый минимум. Если его не 
существует, вывести -1"""
                  )
        case 4:
            return


if __name__ == '__main__':
    Menu()
    