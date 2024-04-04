Is = [1, 2, 3, 4, 5, 6, 7, 8, 9]
U = [[1, 2], [1, 5], [1,4], [2,3], [2,4], [2, 5], [3, 5], [3, 6], [4, 5], [4, 7], [4, 8], [5, 6], [5, 8], [5, 9], [7, 8], [8, 9]]
Weights = [15, 14, 23, 19, 16, 15, 14, 26, 25, 23, 20, 24, 27, 18, 14, 18]
UWeights = []

for i in range(len(U)):
    UWeights.append([Weights[i], U[i]])
#UWeights = sorted(UWeights)
print(UWeights)     #[14[1, 5], 14[1, 3]...]

Ways = [[i] for i in Is]
#print(Ways)     # [[1], [2], [3]...]

def indexOfContain(n):
    for i in range(0, len(Ways)):
        if Ways[i].count(n) == 1:
            return i
            break
        
def MultipleAppend(a_from, a_to):
    for i in a_from:
        a_to.append(i)

def MaxLength():
    m = len(Ways[0])
    for i in range(1, len(Ways)):
        m = max(m, len(Ways[i]))
    return m

weight = 0

i = 0
while MaxLength() < len(Is):
    currentIs = UWeights[i][1]
    currentWeight = UWeights[i][0]
    indexes = [indexOfContain(currentIs[0]), indexOfContain(currentIs[1])]
    if indexes[0] != indexes[1]:
        MultipleAppend(Ways[indexes[1]], Ways[indexes[0]])
        Ways.pop(indexes[1])
        print(Ways)
        print(MaxLength())
        weight += currentWeight
        print(weight)
    i += 1
    