import math

a, b, c = map(int, input('Введите размеры комнаты: ').split())
Sx, Sy, Sz = map(int, input('Введите координаты паука: ').split())
Fx, Fy, Fz = map(int, input('Введите координаты мухи: ').split())

# Паук и муха находятся в одной плоскости

if Sx == Fx == 0 or Sy == Fy == 0 or Sz == Fz == 0:
    l = round(math.sqrt((Sx-Fx)**2 + (Sy-Fy)**2 + (Sz-Fz)**2), 3)

elif Sx == Fx == a or Sy == Fy == b or Sz == Fz == c:
    l = round(math.sqrt((Sx-Fx)**2 + (Sy-Fy)**2 + (Sz-Fz)**2), 3)

# Паук и муха находятся в соседних плоскостях

elif Sy == 0 and Fx == a:
    l = round(math.sqrt((a-Sx+Fy)**2 + (Sz-Fz)**2), 3)
elif Fy == 0 and Sx == a:
    l = round(math.sqrt((a-Fx+Sy)**2 + (Sz-Fz)**2), 3)

elif Sy == 0 and Fx == 0:
    l = round(math.sqrt((Sx+Fy)**2 + (Sz-Fz)**2), 3)
elif Fy == 0 and Sx == 0:
    l = round(math.sqrt((Fx+Sy)**2 + (Sz-Fz)**2), 3)

elif Sy == 0 and Fz == c:
    l = round(math.sqrt((Sx-Fx)**2 + (Sz-(c+Fy))**2), 3)
elif Fy == 0 and Sz == c:
    l = round(math.sqrt((Fx-Sx)**2 + (Fz-(c+Sy))**2), 3)

elif Sy == 0 and Fz == 0:
    l = round(math.sqrt((Sz+Fy)**2 + (Sx-Fx)**2), 3)
elif Fy == 0 and Sz == 0:
    l = round(math.sqrt((Fz+Sy)**2 + (Fx-Sx)**2), 3)

elif Sx == a and Fy == b:
    l = round(math.sqrt((a-Fx+b-Sy)**2 + (Sz-Fz)**2), 3)
elif Fx == a and Sy == b:
    l = round(math.sqrt((a-Sx+b-Fy)**2 + (Fz-Xz)**2), 3)
    
elif Sx == a and Fz == 0:
    l = round(math.sqrt((Sz+a-Fx)**2 + ((b-Sy)-(b-Fy))**2), 3)
elif Fx == a and Sz == 0:
    l = round(math.sqrt((Fz+a-Sx)**2 + ((b-Fy)-(b-Sy))**2), 3)
    
elif Sx == a and Fz == c:
    l = round(math.sqrt((c-Sz+a-Fx)**2 + ((b-Fy)-(b-Sy))**2), 3)
elif Fx == a and Sz == 0:
    l = round(math.sqrt((c-Fz+a-Sx)**2 + ((b-Sy)-(b-Fy))**2), 3)

elif Sy == b and Fx == 0:
    l = round(math.sqrt((Sx+b-Fy)**2 + (Sz-Fz)**2), 3)
elif Fy == b and Sx == 0:
    l = round(math.sqrt((Fx+b-Sy)**2 + (Fz-Sz)**2), 3)

elif Sy == b and Fz == 0:
    l = round(math.sqrt((b-Fy+Sz)**2 + (Sx-Fx)**2), 3)
elif Fy == b and Sz == 0:
    l = round(math.sqrt((b-Sy+Fz)**2 + (Fx-Sz)**2), 3)

elif Sy == b and Fz == c:
    l = round(math.sqrt((c-Sz+b-Fy)**2 + (Fx-Sx)**2), 3)
elif Fy == b and Sz == c:
    l = round(math.sqrt((c-Fz+b-Sy)**2 + (Sx-Fx)**2), 3)

elif Sx == 0 and Fz == 0:
    l = round(math.sqrt((Fx+Sz)**2 + ((b-Sy)-(b-Fy))**2), 3)
elif Fx == 0 and Sz == 0:
    l = round(math.sqrt((Sx+Fz)**2 + ((b-Fy)-(b-Sy))**2), 3)

elif Sx == 0 and Fz == c:
    l = round(math.sqrt((c-Sz+Fx)**2 + ((b-Fy)-(b-Sy))**2), 3)
elif Fx == 0 and Sz == c:
    l = round(math.sqrt((c-Fz+Sx)**2 + ((b-Sy)-(b-Fy))**2), 3)

# Паук и муха находятся в параллельных плоскостях

elif Sy == 0 and Fy == b:
    l1 = round(math.sqrt((a-Sx+b+a-Fx)**2 + (Sz-Fz)**2), 3)
    l2 = round(math.sqrt((Sx+b+Fx)**2 + (Sz-Fz)**2), 3)
    l3 = round(math.sqrt((c-Sz+b+c-Fz)**2 + (Sx-Fx)**2), 3)
    l4 = round(math.sqrt((Sz+b+Fz)**2 + (Sx-Fx)**2), 3)
    l = min(l1, l2, l3, l4)
elif Fy == 0 and Sy == b:
    l1 = round(math.sqrt((a-Fx+b+a-Sx)**2 + (Fz-Sz)**2), 3)
    l2 = round(math.sqrt((Fx+b+Sx)**2 + (Fz-Sz)**2), 3)
    l3 = round(math.sqrt((c-Fz+b+c-Sz)**2 + (Fx-Sx)**2), 3)
    l4 = round(math.sqrt((Fz+b+Sz)**2 + (Fx-Sx)**2), 3)
    l = min(l1, l2, l3, l4)
    
elif Sx == a and Fx == 0:
    l1 = round(math.sqrt((b-Fy+a+b-Sy)**2 + (Sz-Fz)**2), 3)
    l2 = round(math.sqrt((Fy+a+Sy)**2 + (Sz-Fz)**2), 3)
    l3 = round(math.sqrt((c-Sz+a+c-Fz)**2 + ((b-Sy)-(b-Fy))**2), 3)
    l4 = round(math.sqrt((Fz+a+Sz)**2 + ((b-Sy)-(b-Fy))**2), 3)
    l = min(l1, l2, l3, l4)
elif Fx == a and Sx == 0:
    l1 = round(math.sqrt((b-Sy+a+b-Fy)**2 + (Fz-Sz)**2), 3)
    l2 = round(math.sqrt((Sy+a+Fy)**2 + (Fz-Sz)**2), 3)
    l3 = round(math.sqrt((c-Fz+a+c-Sz)**2 + ((b-Fy)-(b-Sy))**2), 3)
    l4 = round(math.sqrt((Sz+a+Fz)**2 + ((b-Fy)-(b-Sy))**2), 3)
    l = min(l1, l2, l3, l4)

elif Sz == c and Fz == 0:
    l1 = round(math.sqrt((Fy+c+Sy)**2 + (Sx-Fx)**2), 3)
    l2 = round(math.sqrt((b-Sy+c+b-Fy)**2 + ((a-Sx)-(a-Fx))**2), 3)
    l3 = round(math.sqrt((a-Sx+c+a-Fx)**2 + ((a-Sx)-(a-Fx))**2), 3)
    l4 = round(math.sqrt((Fx+c+Sx)**2 + ((b-Fy)-(b-Sy))**2), 3)
    l = min(l1, l2, l3, l4)
elif Fz == c and Sz == 0:
    l1 = round(math.sqrt((Sy+c+Fy)**2 + (Fx-Sx)**2), 3)
    l2 = round(math.sqrt((b-Fy+c+b-Sy)**2 + ((a-Fx)-(a-Sx))**2), 3)
    l3 = round(math.sqrt((a-Fx+c+a-Sx)**2 + ((a-Fx)-(a-Sx))**2), 3)
    l4 = round(math.sqrt((Sx+c+Fx)**2 + ((b-Sy)-(b-Fy))**2), 3)
    l = min(l1, l2, l3, l4)

print(l)