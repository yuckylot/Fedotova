# Обмен денег

a = [int(x) for x in input().split()][1:] 
a_unhappy = sorted([int(x) for x in input().split()][1:], reverse=True)
b = [int(x) for x in input().split()][1:] 
b_unhappy = sorted([int(x) for x in input().split()][1:])

money_a = [int(x) for x in input().split()]
real_money = 0

for index, nom in enumerate(money_a):
    for unhappy in a_unhappy:
        if nom > unhappy:
            nom -= 1
    for perev in a[index:]:
        nom *= perev
    real_money += nom
    
c = []
for perev in reversed(b):
    c += [real_money % perev]
    real_money //= perev
c += [real_money]

for index, nom in enumerate(c):
    for unhappy in b_unhappy:
        if nom >= unhappy:
            nom += 1
    c[index] = nom

for i in reversed(c):
    print(i, end=" ")
    