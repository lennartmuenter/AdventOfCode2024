from collections import Counter

file = open('day1.txt', 'r')
lines = file.readlines()

left = []
right = []
part1 = 0
part2 = 0

for line in lines:
    tmp = line.strip().split('   ')
    left.append(int(tmp[0]))
    right.append(int(tmp[1]))

rightOcc = Counter(right)
for num in left:
    part2 += num * rightOcc[num]
    
left.sort()
right.sort()

for index in range(0, len(left)):
    result = left[index] - right[index]
    if result < 0: part1 -= result
    else: part1 += result
        
print(part1)
print(part2)