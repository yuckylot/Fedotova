f = open('Input.txt')
number = [1, 0]    # 1x + 0
n = f.readline()
for i in range(int(n)):
    s = f.readline()
    operation = s[0]
    operand = s[2]
    if operand != 'x':  
        operand = int(operand)
        if operation == '+':
            number[1] += operand
        if operation == '-':
            number[1] -= operand
        if operation == '*':
            number[0] *= operand
            number[1] *= operand
        if operation == '/':
            number[0] /= operand
            number[1] /= operand
    if operand == 'x':
        if operation == '+':
            number[0] += 1
        if operation == '-':
            number[0] -= 1
result = int(f.readline())
print((result-number[1])/number[0])