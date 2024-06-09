def get_info(p):
    with open(p) as f:
        count_words = int(f.readline().strip())
        w = [f.readline().strip() for x in range(count_words)]
        count_starts = int(f.readline().strip())
        s = [f.readline().split() for x in range(count_starts)]
        count_ends = int(f.readline().strip())
        e = [f.readline().split() for x in range(count_ends)]
    return count_words, w, s, e


path = 'input_s1_01.txt'

n, words, starts, ends = get_info(path)
way1 = []
way2 = []

for i in range(n):
    for start in starts:
        for end in ends:
            if words[i][0] == start[0] and words[i][-1] == end[0]:
                if int(start[1]) > 0 and int(end[1]) > 0:
                    way1.append(words[i])
                    start[1] = int(start[1]) - 1
                    end[1] = int(end[1]) - 1

_, _, starts, ends = get_info(path)
starts.sort(key=lambda x: int(x[1]), reverse=True)
ends.sort(key=lambda x: int(x[1]), reverse=True)

for end in ends:
    for start in starts:
        for i in range(n):
            if words[i][0] == start[0] and words[i][-1] == end[0]:
                if int(start[1]) > 0 and int(end[1]) > 0:
                    way2.append(words[i])
                    start[1] = int(start[1]) - 1

result = max(len(way1), len(way2))
print(result)