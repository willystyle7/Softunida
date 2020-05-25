function solve(input) {
    let k = +input.shift();
    let n = +input.shift();
    input.sort((a, b) => a - b);
    // console.log(input);
    let minDiff = Number.MAX_SAFE_INTEGER;
    for (let i = 0; i < input.length - k + 1; i++) {
        let diff = input[i + k - 1] - input[i];
        if (diff <= minDiff) {
            minDiff = diff;
        }
    }
    console.log(minDiff);
}

solve([3, 7, 10, 100, 300, 200, 1000, 20, 30]);