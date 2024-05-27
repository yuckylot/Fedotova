s = ['WATER wU vV yrNFcJi LtufjxvYIC', 'WATER 1 KOsbNa vlz hybPwvg', 'WATER 1 QMlhrIlWgM T', 'WATER TvMspsBX 3', 'WATER 2 4']
allZakl = {"MIX":"MX", 'WATER':"WT", "DUST":"DT", "FIRE":"FR"}
results = []
for line in s:
    magic = line.split(' ')
    result = allZakl[magic[0]][::1]
    for i in range(1, len(magic)):
        if magic[i].isdigit():
            element = results[int(magic[i])-1]
        else: element = magic[i]
        result += element
    result += allZakl[magic[0]][::-1]
    results.append(result)
print(result)