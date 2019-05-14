function solve(args) {
    let n = args.shift();
    let layer, row, column;
    let matrix = [];
    for (row = 0; row < n; row++) {
        let input = args.shift().split(' | ');
        for (layer = 0; layer < n; layer++) {
            if (!matrix[layer]) matrix[layer] = [];
            if (!matrix[layer][row]) matrix[layer][row] = [];
            let token = input[layer].split(' ');
            for (column = 0; column < n; column++) {
                matrix[layer][row][column] = token[column];
            }
        }
    }
    let input = args.shift();
    while (input !== 'Melolemonmelon') {
        [layer, row, column] = input.split(' ').map(Number);
        matrix[layer][row][column] = '0';
        for (let i = 0; i < n; i++) {
            for (let j = 0; j < n; j++) {
                for (let k = 0; k < n; k++) {
                    if ((i === layer && j === row && k >= column - 1 && k <= column + 1)
                    || (i === layer && k === column && j >= row - 1 && j <= row + 1)
                    || (k === column && j === row && i >= layer - 1 && i <= layer + 1)) {
                        continue;
                    }
                    switch (matrix[i][j][k]) {
                        case 'W':
                            matrix[i][j][k] = 'E';
                            break;
                        case 'E':
                            matrix[i][j][k] = 'F';
                            break;
                        case 'F':
                            matrix[i][j][k] = 'A';
                            break;
                        case 'A':
                            matrix[i][j][k] = 'W';
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        input = args.shift();
    }
    for (let row = 0; row < n; row++) {
        let result = [];
        for (let layer = 0; layer < n; layer++) {
            result.push(matrix[layer][row].join(' '));
        }
        console.log(result.join(' | '));
    }
}

solve([
    '3',
    'W W W | E W A | E E E',
    'F F F | F A F | W W W',
    'A A A | A E A | A A A',
    '1 1 1',
    'Melolemonmelon'
]);
solve([
    '4',
    'A W F A | W W W W | W W W W | A A A A',
    'W F W F | F F F F | A A A A | F F F F',
    'A W E W | E E E E | A A A A | W E E W',
    'A F W E | W W W W | W W W W | W W W W',
    '1 1 1',
    '2 3 2',
    '3 1 3',
    'Melolemonmelon'
]);
