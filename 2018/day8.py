def load_file(filename):
    file = open(filename, "r")
    data = file.readlines()
    result = ""
    for record in data:
        result += record.rstrip()

    return result


def calculate_metadata(data_list, metadata):
    child_nodes = data_list[0]
    amount_of_metadata = data_list[1]
    data_list = data_list[2:]

    for i in range(0, child_nodes):
        metadata_temp, data_list = calculate_metadata(data_list, 0)
        metadata += metadata_temp

    for k in range(0, amount_of_metadata):
        metadata += data_list[k]

    data_list = data_list[amount_of_metadata:]

    return metadata, data_list


def calculate_root_metadata(data_list, metadata):
    child_nodes = data_list[0]
    amount_of_metadata = data_list[1]
    data_list = data_list[2:]

    if child_nodes != 0:
        metadata_children = []
        for i in range(0, child_nodes):
            metadata_temp, data_list = calculate_root_metadata(data_list, 0)
            metadata_children.append(metadata_temp)

        metadata_indexes = data_list[:amount_of_metadata]
        for index in metadata_indexes:
            if 0 <= index - 1 < len(metadata_children):
                metadata += metadata_children[index - 1]

    else:
        for k in range(0, amount_of_metadata):
            metadata += data_list[k]

    data_list = data_list[amount_of_metadata:]

    return metadata, data_list


def get_data(data):
    return [int(s) for s in data.split(' ')]


def part1(data):
    data_list = get_data(data)
    metadata, data_list = calculate_metadata(data_list, 0)
    print("Total metadata: {}".format(metadata))


def part2(data):
    data_list = get_data(data)
    metadata, data_list = calculate_root_metadata(data_list, 0)
    print("Metadata of root node: {}".format(metadata))


def main():
    data = load_file("Inputs/day8")
    # data = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2"
    part1(data)
    part2(data)

main()