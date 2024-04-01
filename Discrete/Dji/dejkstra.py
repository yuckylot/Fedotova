verges = [[1, 2, 10], [1, 4, 30], [1, 5, 100], [2, 3, 50], [3, 5, 10], [4, 3, 20], [4, 5, 60]]
vertexes = set()
for i in verges:
    vertexes.add(i[0])
    vertexes.add(i[1])
vertexes = list(vertexes)
print('Input start and finish:')
begin, end = map(int, input().split())

values = []
result = []
wayVert = [begin]
for i in range(len(vertexes)):
    values.append(float('inf'))
    result.append(float('inf'))
values[begin - 1] = 0
curVer = begin
way = 0

for i in range(len(vertexes)):
    minv = min(values)
    way += minv
    curInd = values.index(minv)
    curVer = vertexes[curInd]
    vertexes[curInd] = 0
    values[curInd] = float('inf')
    result[curInd] = minv
    for j in verges:
        if j[0] == curVer and j[1] in vertexes:
            values[j[1] - 1] = min(values[2], j[2] + minv)
            if j[1] == end and not (j[0] in wayVert):
                wayVert.append(j[0])
wayVert.append(end)
print(result[end - 1])
print(wayVert)
