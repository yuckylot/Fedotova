# Постройка дома

with open('a') as file:

    x, y, l, c1, c2, c3, c4, c5, c6 = [int(i) for i in file.readline().split()]
    
    ost = 0
    summ = 0
    p = (x + y) * 2
    
    if l > p:
        ost = l - p
        p = 0
    else:
        p -= l
    
    if c2 + c3 < c1:
        summ += (l - ost) * (c2 + c3)
        l = 0
    elif c2 + c6 + c4 + c5 < c1:
        summ += (l - ost) * (c2 + c6 + c4 + c5)
        l = 0
        
    else:
        if l < min(x, y):
            summ += l * c1
            l = 0
        else:
            summ += max(x, y) * c1
            l -= max(x, y)
    
    if  c2 + c6 + c4 + c5 < c2 + c3:
        if l > 0:
            summ += (l - ost) * (c2 + c6 + c4 + c5)
        l = 0
    
    
    if l > 0:
        summ += (l - ost) * (c2 + c3)
    
    summ += p * (c4 + c5)
    summ += ost * (c2 + c6)
    print(summ)