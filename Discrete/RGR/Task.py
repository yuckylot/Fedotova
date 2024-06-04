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



if __name__ == '__main__':
    with open("./Calculating.txt") as file:
        n = int(file.readline())
        graph = []
        for i in range(n):
            l = list(map(int, file.readline().split(" ")))
            for j in range(n):
                if l[j] != 0:
                    graph.append([i, j, l[j]])
                    
    print(bellman_ford(graph, 0))

