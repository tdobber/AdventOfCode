def load_file(filename):
    file = open(filename, "r")
    data = file.readlines()
    result = []
    for code in data:
        result.append(code.rstrip())

    return result


def part1(data):
    two_times = 0
    two_times_set = 0
    three_times = 0
    three_times_set = 0

    for code in data:
        for letter in code:
            if code.count(letter) == 2 and two_times_set != 1:
                two_times += 1
                two_times_set = 1

            elif code.count(letter) == 3 and three_times_set != 1:
                three_times += 1
                three_times_set = 1

        two_times_set = three_times_set = 0

    print("Two times {} and three times {}".format(two_times, three_times))

    checksum = two_times * three_times
    print("Checksum is: {} * {} = {}".format(two_times, three_times, checksum))


def find_same_code(data):
    code_length = len(data[0])
    for i in range(0, len(data)):
        for j in range(i + 1, len(data)):
            for k in range(0, code_length):
                code_i = data[i][:k] + data[i][k+1:]
                code_j = data[j][:k] + data[j][k+1:]
                if code_i == code_j:
                    print("{}, {}".format(code_i, code_j))
                    return code_j


def part2(data):
    result = find_same_code(data)
    print("The common letters between the two box ID's are: {}".format(result))


def main():
    data = load_file("Inputs/day2")
    part1(data)
    part2(data)


main()