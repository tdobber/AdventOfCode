from string import ascii_lowercase
import re
import operator

def load_file(filename):
    file = open(filename, "r")
    data = file.readlines()
    result = []
    for record in data:
        result.append(record.rstrip())

    return result[0]


def react(data):
    looped_whole_polymer = False
    had_reaction = False
    while not looped_whole_polymer:
        had_reaction = False
        for i in range(0, len(data) - 2):

            sample = data[i:i+2]
            if (ord(sample[0]) + 32 == ord(sample[1])) or (ord(sample[0]) - 32 == ord(sample[1])):
                data = data[:i] + data[i+2:]
                had_reaction = True
                break

        if had_reaction is False:
            looped_whole_polymer = True

    return len(data)


def part1(data):
    print("The total length of the input is {}".format(len(data)))
    length = react(data)

    print("The length of the remaining polymer is {}".format(length))


def part2(data):
    polymer_size_without_letter = {}
    old_data = data
    for c_lower in ascii_lowercase:
        c_upper = (chr(ord(c_lower)-32))
        regex = "[" + c_lower + "|" + c_upper + "]"

        data = re.sub(regex, "", old_data)
        length = react(data)
        polymer_size_without_letter[c_lower] = length

    print("The length of the smallest polymer is {}".format(min(polymer_size_without_letter.items(), key=operator.itemgetter(1))[1]))


def main():
    data = load_file("Inputs/day5")
    part1(data)
    part2(data)

main()