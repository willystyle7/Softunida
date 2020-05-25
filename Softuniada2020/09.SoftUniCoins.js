// Dynamic Programming

function solve([n]) {
    // Solve for 0 to 99
    let dp = [];
    for (let i = 0; i < 100; i++) {
        dp[i] = i;
    }

    for (let i = 10; i < 100; i++) {
        dp[i] = Math.min(dp[i - 10] + 1, dp[i]);
    }

    for (let i = 25; i < 100; i++) {
        dp[i] = Math.min(dp[i - 25] + 1, dp[i]);
    }
    // console.log(dp);
    // Solve for n for each 2 digits
    let count = 0;
    while (n > 0) {
        count += dp[n % 100];
        n = Math.floor(n / 100);
    }

    console.log(count);
}

solve([1000]);
// solve([8]);
// solve([30]);
// solve([2772788690199]);
