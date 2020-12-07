import networkx as nx

class Worker:
    def __init__(self, current_instruction, time_still_busy):
        self.current_instruction = current_instruction
        self.time_still_busy = time_still_busy


def load_file(filename):
    file = open(filename, "r")
    data = file.readlines()
    result = []
    for record in data:
        result.append(record.rstrip())

    return result


def read_instructions(data):
    instructions = []
    for line in data:
        first_step = line[5]
        second_step = line[-12]
        instructions.append((first_step, second_step))

    return instructions


def build_graph(instructions):
    graph = nx.DiGraph()
    for instruction in instructions:
        graph.add_edges_from([instruction])

    return graph


def part1(graph):
    alphabetic_nodes = sorted(list(graph.nodes))
    instruction_order = ""

    while len(instruction_order) != len(alphabetic_nodes):
        next_instruction = get_next_instruction(graph, alphabetic_nodes, instruction_order)
        instruction_order += next_instruction

    print("Complete instruction order: " + instruction_order)


def part2(graph):
    alphabetic_nodes = sorted(list(graph.nodes))
    instruction_order = ""
    current_working = ""
    amount_of_workers = 5
    workers = []
    total_time = 0

    for i in range(0, amount_of_workers):
        worker = Worker('.', 0)
        workers.append(worker)

    # print("Second\tWorker1\tWorker2\tWorker3\tWorker4\tWorker5\tDone")

    while len(instruction_order) != len(alphabetic_nodes):
        for worker in workers:
            if worker.time_still_busy == 0 and worker.current_instruction != '.':
                instruction_order += worker.current_instruction
                current_working = current_working.replace(worker.current_instruction, "")

        for worker in workers:
            if worker.time_still_busy == 0:
                next_instruction = get_next_instruction(graph, alphabetic_nodes, instruction_order, current_working)
                if next_instruction != '.':
                    current_working += next_instruction
                worker.current_instruction = next_instruction
                worker.time_still_busy = get_time_instruction(next_instruction)

            if worker.time_still_busy > 0:
                worker.time_still_busy -= 1

        # print("{}\t{}\t{}\t{}\t{}\t{}\t{}".format(total_time, workers[0].current_instruction, workers[1].current_instruction, workers[2].current_instruction, workers[3].current_instruction, workers[4].current_instruction, instruction_order))
        if len(instruction_order) != len(alphabetic_nodes):
            total_time += 1

    print("The instruction order is: {}, while the total time is: {}".format(instruction_order, total_time))


def get_next_instruction(graph, alphabetic_nodes, instruction_order, current_working = ""):
    for node in alphabetic_nodes:
        if node in instruction_order or node in current_working:
            continue

        elif len(list(graph.predecessors(node))) == 0:
            return node

        elif all(character in instruction_order for character in list(graph.predecessors(node))):
            return node

    return '.'


def get_time_instruction(instruction):
    rv = 0
    if instruction == '.':
        rv = 0
    else:
        rv = ord(instruction) - 4

    return rv


def get_data(data):
    instructions = read_instructions(data)
    graph = build_graph(instructions)
    part1(graph)
    part2(graph)


def main():
    data = load_file("Inputs/day7")
    # data = ["Step C must be finished before step A can begin.", "Step C must be finished before step F can begin.",
    #     "Step A must be finished before step B can begin.", "Step A must be finished before step D can begin.",
    #     "Step B must be finished before step E can begin.", "Step D must be finished before step E can begin.",
    #     "Step F must be finished before step E can begin."]
    get_data(data)

main()