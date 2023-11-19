# Задача с Разведкой

import math

def razv(n):
    if n ==3:
        return 1
    if n < 3:
        return 0
    else:
        even = math.floor(n/2)
        odd = math.floor(n/2)+(n%2)
        return razv(even)+razv(odd)
    
