def run(line):
    print(line)

parts = [parts.split("\n") for parts in open('day4.txt', 'r').read().split("\n\n")]
rules = [rule.split("|") for rule in parts[0]]
[run(line.split(",")) for line in parts[1]]