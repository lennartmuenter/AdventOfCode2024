sum = 0
def checkline(line):
    if(line[0]>line[1]): line.reverse()
    if(all(line[index] < line[index+1] and line[index+1]-line[index] <= 3 for index in range(len(line) - 1))):
        global sum
        sum += 1
all(checkline(list(map(int, line.strip().split(' ')))) for line in open('day2.txt', 'r').readlines())
print(sum)