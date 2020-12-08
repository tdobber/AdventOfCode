from datetime import *
import operator

def load_file(filename):
    file = open(filename, "r")
    data = file.readlines()
    result = []
    for record in data:
        result.append(record.rstrip())

    return result


def find_sleepy_minutes_all(sleep_records):
    guards_asleep = {}
    for record in sleep_records:
        guard = sleep_records[record][0]
        if guard not in guards_asleep:
            guards_asleep[guard] = [0] * 60

        for i in range(0, 60):
            if sleep_records[record][1][i] is "#":
                guards_asleep[guard][i] += 1

    max_value = 0
    sleepy_minute = 0
    sleepy_guard = ""
    for guard in guards_asleep:
        index, value = max(enumerate(guards_asleep[guard]), key=operator.itemgetter(1))
        if value > max_value:
            max_value = value
            sleepy_minute = index
            sleepy_guard = guard

    return sleepy_minute, sleepy_guard



def find_sleepy_minute(sleep_records, sleepy_guard):
    sleep_minutes = [0] * 60
    for record in sleep_records:
        if sleep_records[record][0] in sleepy_guard:
            for i in range(0, 60):
                if sleep_records[record][1][i] is "#":
                    sleep_minutes[i] += 1

    index, value = max(enumerate(sleep_minutes), key=operator.itemgetter(1))
    return index


def find_sleepy_guard(sleep_records):
    sleep_guard = {}

    for record in sleep_records:
        current_guard = sleep_records[record][0]
        if current_guard not in sleep_guard:
            sleep_guard[current_guard] = 0

        sleep_guard[current_guard] += sum(i == "#" for i in sleep_records[record][1])

    return max(sleep_guard.items(), key=operator.itemgetter(1))[0]


def part1(data):
    sleep_records = {}
    for i in range(0, len(data)):
        date = datetime.strptime(data[i][1:17], "%Y-%m-%d %H:%M")
        date_key = str(date.month) + "-" + str(date.day)

        if date.hour == 23:
            date = date + timedelta(days=1)
            date_key = str(date.month) + "-" + str(date.day)

        if date_key not in sleep_records:
            sleep_records[date_key] = (0, ["-"] * 60)

        old_id, old_time_array = sleep_records[date_key]

        if "begins" in data[i][18:]:
            guard = data[i].split(" ")[3][1:]
            sleep_records[date_key] = (guard, old_time_array)

        elif "asleep" in data[i][18:]:
            for i in range(date.minute, len(old_time_array)):
                old_time_array[i] = "#"

        elif "wakes" in data[i][18:]:
            for i in range(date.minute, len(old_time_array)):
                old_time_array[i] = "."

    return sleep_records


def main():
    data = load_file("Inputs/day4")
    data = sorted(data)
    sleep_records = part1(data)
    sleepy_guard = find_sleepy_guard(sleep_records)
    sleepy_minute = find_sleepy_minute(sleep_records, sleepy_guard)
    print("The guard that is the most minutes asleep (#{}) times the minute he is asleep the most ({}) is {}".format(sleepy_guard, sleepy_minute, (int(sleepy_guard) * sleepy_minute)))

    sleepy_minute, sleepy_guard = find_sleepy_minutes_all(sleep_records)
    print("The guard (#{}) that is the most frequently asleep on the same minute ({}); times each other gives {}".format(sleepy_guard, sleepy_minute, (int(sleepy_guard) * sleepy_minute)))


main()