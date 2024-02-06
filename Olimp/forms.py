with open(".//task_for_forms//input1.txt") as file:
    count = int(file.readline())
    details = [file.readline().rstrip() for x in range(count)]
    forms = [file.readline().rstrip() for y in range(count*2)]

new_list = [x for x in range(count)]
for i in range(len(details)):
    details[i] = details[i].split()
    new_list = [details[i][0:5], [details[i][5:10]], [details[i][10:15]], [details[i][15:20]]]

print(new_list)