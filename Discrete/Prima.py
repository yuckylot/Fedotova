Is = {1, 2, 3, 4, 5, 6, 7, 8, 9}
U = [[1, 2], [1, 5], [1,4], [2,3], [2,4], [2, 5], [3, 5], [3, 6], [4, 5], [4, 7], [4, 8], [5, 6], [5, 8], [5, 9], [7, 8], [8, 9]]
Weights = [15, 14, 23, 19, 16, 15, 14, 26, 25, 23, 20, 24, 27, 18, 14, 18]
UWeights = []

for i in range(len(U)):
    UWeights.append([Weights[i], U[i]])
  
print(UWeights)

UsedIs = {1}
weight = 0

while UsedIs != Is:
    Ways = []
    for i in range(len(UWeights)):
        if ((UWeights[i][1][0] in UsedIs) and not (UWeights[i][1][1] in UsedIs)) or ((UWeights[i][1][1] in UsedIs) and not (UWeights[i][1][0] in UsedIs)):
            #print(f"{UWeights[i][0]} : {UWeights[i][1]}")
            Ways.append([UWeights[i][0], UWeights[i][1]])
    #print(Ways)
    minU = Ways[0][0]
    for i in range(1, len(Ways)):
        minU = min(Ways[i][0], minU)
    weight += minU
    for i in range(0, len(Ways)):
        if Ways[i][0] == minU:
            UsedIs.add(Ways[i][1][0])
            UsedIs.add(Ways[i][1][1])
            break
    #print(UsedIs)
print(weight)