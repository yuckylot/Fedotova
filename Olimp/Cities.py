def ring(made, rest):
    could = [x for x in rest if x[0] == made[-1][-1]]
    if len(could) == 0:
        if made[0][0] == made[-1][-1]:
            return len(made), made
        else:
            return -1, []

    variants = []
    for i in could:
        variants.append(ring(made + [i], [x for x in rest if i != x]))

    return max(variants, key=lambda x: x[0])


rings_length = []
with open("b") as f:
    lines = [x.strip() for x in f.readlines()]

    while lines:
        rings = {x: ring([x], [y for y in lines if x != y]) for x in lines}
        maximum_ring = rings[max(rings, key=lambda x: rings[x][0])]
        lines = [x for x in lines if x not in maximum_ring[1]]
        rings_length.append(maximum_ring[0])

print(len(rings_length))
for i in rings_length:
    print(i)