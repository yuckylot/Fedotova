def formula(): ## Формула
    print("Решение Формулой:")
    for i in k:
        result = i * (2 * l + 2 * n) + (i ** 2 + i) * m
        print(f"Для k={i}: {result}")
    return "\n"


def cycle(): ## Цикл
    print("Решение Циклом:")
    for i in k:
        result = 0
        for j in range(i):
            result += 2 * l + 2 * n + 2 * m + 2*j*m
        print(f"Для k={i}: {result}")
    return "\n"

l = 7
m = 10
n = 5
k = [1, 2, 3, 20]
##

print(formula())
print(cycle())
