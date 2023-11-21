# Интенсификация производства
def proizv(number):
    from datetime import datetime, timedelta

    with open(f".//task_for_proizv//input_s1_{number}.txt") as file:
        first_date = file.readline()
        first_date = list(map(int, first_date.split(".")))
        second_date = file.readline()
        second_date = list(map(int, second_date.split(".")))
        first_prod = int(file.readline())
    
    first_date = datetime(first_date[2], first_date[1], first_date[0])
    second_date = datetime(second_date[2], second_date[1], second_date[0])
    delta = second_date - first_date
    result, prod = first_prod 

    for i in range(delta.days):
        prod += 1
        result += prod
    return result

print(proizv("08"))