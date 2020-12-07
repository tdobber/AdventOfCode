import operator

def load_file(filename):
    file = open(filename, "r")
    data = file.readlines()
    result = []
    for record in data:
        split_coordinates = record.split(", ")
        coordinates = (int(split_coordinates[0]), int(split_coordinates[1]))
        result.append(coordinates)

    return result


def print_grid(grid):
    for line in grid:
        print(line)


def find_min_max_coordinates(data):
    x_max = y_max = 0
    x_min = y_min = 400
    for (x, y) in data:
        if x > x_max:
            x_max = x

        if y > y_max:
            y_max = y

        if x < x_min:
            x_min = x

        if y < y_min:
            y_min = y

    return x_max, y_max, x_min, y_min


def plant_coordinates(data, grid, x_min, y_min):
    coordinate_number = 0
    for (x, y) in data:
        grid[y - y_min][x - x_min] = str(coordinate_number) + "_"
        coordinate_number += 1

    return grid


def calculate_manhattan_distance(data, x, y, x_min, y_min):
    distances = []
    for (x_coor, y_coor) in data:
        distance = abs((x_coor - x_min) - x) + abs((y_coor - y_min) - y)
        distances.append(distance)

    return distances


def fill_grid(data, grid, x_min, y_min):
    for y in range(0, len(grid)):
        for x in range(0, len(grid[0])):
            if grid[y][x] is ".":
                distances = calculate_manhattan_distance(data, x, y, x_min, y_min)
                index, value = min(enumerate(distances), key=operator.itemgetter(1))
                if distances.count(value) == 1:
                    grid[y][x] = index

    return grid


def distance_to_coords(data, grid, max_distance, x_min, y_min):
    for y in range(0, len(grid)):
        for x in range(0, len(grid[0])):
            distances = calculate_manhattan_distance(data, x, y, x_min, y_min)
            if sum(distances) < max_distance:
                if grid[y][x] is ".":
                    grid[y][x] = "#"
                else:
                    grid[y][x] += "#"

    return grid


def count_surfaces(data, grid, border_coords):
    surfaces = []
    for i in range(0, len(data)):
        if i not in border_coords:
            surface = sum(x.count(i) for x in grid)
            surfaces.append(surface)

    return max(enumerate(surfaces), key=operator.itemgetter(1))


def find_border_coords(grid):
    border_coords = set(grid[0])
    border_coords = border_coords.union(set(grid[-1]))

    for i in range(0, len(grid)):
        border_coords.add(grid[i][0])
        border_coords.add(grid[i][-1])

    return [x for x in set(border_coords) if isinstance(x, int)]


def surface_smaller_than_max_distance(grid):
    surface = 0
    for row in grid:
        surface += sum("#" in i for i in row)

    return surface


def part1(data):
    x_max, y_max, x_min, y_min = find_min_max_coordinates(data)
    grid = [["." for x in range((x_max + 1) - x_min)] for y in range((y_max + 1) - y_min)]
    grid = plant_coordinates(data, grid, x_min, y_min)

    grid = fill_grid(data, grid, x_min, y_min)
    border_coords = find_border_coords(grid)
    print(border_coords)
    index, biggest_surface = count_surfaces(data, grid, border_coords)
    print("The size of the largest area that isn't infinet is {}".format(biggest_surface + 1))


def part2(data, max_distance):
    x_max, y_max, x_min, y_min = find_min_max_coordinates(data)
    grid = [["." for x in range((x_max + 1) - x_min)] for y in range((y_max + 1) - y_min)]
    grid = plant_coordinates(data, grid, x_min, y_min)

    grid = distance_to_coords(data, grid, max_distance, x_min, y_min)
    surface = surface_smaller_than_max_distance(grid)
    print("The size of the region which have a total distance lower than {} is {}".format(max_distance, surface))


def main():
    data = load_file("Inputs/day6")
    part1(data)

    max_distance = 10000
    part2(data, max_distance)

main()