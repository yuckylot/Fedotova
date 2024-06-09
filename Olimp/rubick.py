file = open('input_s1_1.txt')
n, m = map(int, file.readline().strip().split())
x, y, z = map(int, file.readline().strip().split())

for i in range(m):
    axis, cord, direction = file.readline().strip().split()
    cord, direction = int(cord), int(direction)
    
    if axis == "X":
        if x == cord:
            if direction > 0:
                temp = z
                z = n - y + 1
                y = temp
            else:
                temp = y
                y = n - z + 1
                z = temp
    elif axis == "Y":
        if y == cord:
            if direction > 0:
                temp = z
                z = n - x + 1
                x = temp
            else:
                temp = x
                x = n - z + 1
                z = temp
    elif axis == "Z":
        if z == cord:
            if direction > 0:
                temp = y
                y = n - x + 1
                x = temp
            else:
                temp = x
                x = n - y + 1
                y = temp

print(f'{x} {y} {z}')