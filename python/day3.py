import re
def calculate(nums):
    return nums[0] * nums[1]
for string in {open('day3.txt', 'r').read(), re.sub(r"((don't[(][)].*?)+(do[(][)]))|(don't(.*?)$)", "" , open('day3.txt', 'r').read().replace("\n", ""))}: 
    print(sum([calculate(list(map(int, re.findall(r"[0-9]+", nums)))) for nums in re.findall(r"mul[(][0-9]+,[0-9]+[)]", string)]))