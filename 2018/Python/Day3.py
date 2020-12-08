def load_file(filename):
    file = open(filename, "r")
    data = file.readlines()
    return data


def print_fabric(fabric):
    for row in fabric:
        print(row)

    print("-----")


def count_double_claims(fabric):
    double_claims = 0
    for row in fabric:
        double_claims += sum(i > 1 for i in row)

    return double_claims


def get_claim_info(claim):
    info = claim.split(" ")
    claim_id = info[0]
    claim_index = info[2].split(",")
    claim_index_x = int(claim_index[0])
    claim_index_y = int(claim_index[1][:-1])

    claim_size = info[3].split("x")
    claim_width = int(claim_size[0])
    claim_height = int(claim_size[1])
    return claim_id, claim_index_x, claim_index_y, claim_width, claim_height


def claim_fabric(claim, fabric):
    claim_id, claim_index_x, claim_index_y, claim_width, claim_height = get_claim_info(claim)
    for i in range(claim_index_y, (claim_index_y + claim_height)):
        for j in range(claim_index_x, (claim_index_x + claim_width)):
            fabric[i][j] += 1

    return fabric


def check_fabric_claim(claim, fabric):
    is_only_claim = 0
    claim_id, claim_index_x, claim_index_y, claim_width, claim_height = get_claim_info(claim)
    for row in range(claim_index_y, (claim_index_y + claim_height)):
        for claim_amounts in range(claim_index_x, (claim_index_x + claim_width)):
            if fabric[row][claim_amounts] != 1:
                return 0

    return claim_id


def part1(data, x_range, y_range):
    fabric = [[0 for x in range(x_range)] for y in range(y_range)]
    for claim in data:
        fabric = claim_fabric(claim, fabric)

    double_claims = count_double_claims(fabric)
    print("The amount of double or more claims is: {}".format(double_claims))

    return fabric


def part2(data, fabric):
    for claim in data:
        claim_id = check_fabric_claim(claim, fabric)
        if claim_id != 0:
            print("The only correct claim is the claim with id: {}".format(claim_id))


def main():
    data = load_file("Inputs/day3")
    fabric = part1(data, 1000, 1000)
    part2(data, fabric)


main()