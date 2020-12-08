from collections import deque;

class Marble_game:
    player_to_move = 0
    current_marble = 0
    board = deque()

    def __init__(self, marbles, players):
        self.marbles = marbles
        self.players = players

    
    def __str__(self):
        board_to_print = ""
        for marble in self.board:
            if marble == self.current_marble:
                board_to_print += "({}) ".format(marble)
            else:
                board_to_print += "{} ".format(marble)
        to_print = "[{}] {}".format(self.player_to_move, board_to_print)

        return to_print


class Player:
    score = 0

    def __init__(self, player_id):
        self.player_id = player_id


def load_file(filename):
    file = open(filename, "r")
    data = file.readlines()
    result = ""
    for record in data:
        result += record.rstrip()

    return result


def retrieve_data(data):
    players = int(data.split(' ')[0])
    last_marble = int(data.split(' ')[-2])
    return players, last_marble


def play_game(game):
    for marble in game.marbles:
        game.player_to_move = (game.player_to_move + 1) % len(game.players)

        if marble == 0:
            game.board.append(marble)

        elif marble % 23 == 0:
            player = [player for player in game.players if player.player_id == game.player_to_move][0]
            player.score += marble
            game.board.rotate(7)
            player.score += game.board.popleft()

        else:
            game.board.rotate(-2)
            game.board.appendleft(marble)


def preparating_game(players, last_marble):
    all_players = deque()

    for i in range(0, players):
        player = Player(i)
        all_players.append(player)

    game = Marble_game(deque(marble for marble in range(0, last_marble + 1)), all_players)
    play_game(game)
    score_list = list(game.players)
    score_list.sort(key=lambda x: x.score, reverse=True)
    return score_list[0].score


def part1(data):
    players, last_marble = retrieve_data(data)
    winning_score = preparating_game(players, last_marble)
    print("The winning elf's score of part 1 is: {}".format(winning_score))


def part2(data):
    players, last_marble = retrieve_data(data)
    winning_score = preparating_game(players, (last_marble * 100))
    print("The winning elf's score of part 2 is: {}".format(winning_score))


def main():
    data = load_file("Inputs/day9")
    # data = "9 players; last marble is worth 25 points"
    part1(data)

    data = load_file("Inputs/day9")
    part2(data)

main()
