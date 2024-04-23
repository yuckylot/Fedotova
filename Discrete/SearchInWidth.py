U = [[1, 2], [2, 3], [2, 10], [2, 6], [3, 4], [4, 10], [5, 6], [5, 7], [5, 10], [8, 9], [8, 11], [9, 11]]
white = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
grey = []
black = []
currentU = white[0]
connected_elements = [[currentU]]
componenta = 0
grey.append(currentU)
white.remove(currentU)
while len(white) > 0:
    print(currentU)
    check = True
    for gran in U:
        if gran[0]==currentU and white.count(gran[1]) == 1:
            grey.append(gran[1])
            white.remove(gran[1])
            check = False
            connected_elements[componenta].append(gran[1])
        elif gran[1]==currentU and white.count(gran[0]) == 1:
            grey.append(gran[0])
            white.remove(gran[0])
            check = False
            connected_elements[componenta].append(gran[0])
    grey.remove(currentU)
    black.append(currentU)
    if len(grey) != 0:
        currentU = grey[0]
    else:
        currentU = white[0]
        white.remove(currentU)
        grey.append(currentU)
        componenta += 1
        connected_elements.append([currentU])

for i in connected_elements:
    print(i)
