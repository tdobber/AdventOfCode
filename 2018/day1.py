import numpy as np

def load_file(filename):
    data = np.loadtxt(filename, dtype=int)
    return data


def part1(data):
    result = np.sum(data)
    print("The resulting frequency is: {}".format(result))


def part2(data):
    frequency = 0
    frequencies = {frequency}
    found = 0

    while not found:
        for i in data:
            frequency += i
            if frequency in frequencies:
                found = 1
                break

            frequencies.add(frequency)

    print("The first frequency that is reached twice is: {}".format(frequency))


def main():
    data = load_file("Inputs/day1")
    part1(data)
    part2(data)


main()