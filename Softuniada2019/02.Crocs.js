function draw([n]) {
    n = Number(n);
    let half = Math.floor(n / 2);
    for (let i = 1; i <= half; i++) {
        console.log(' '.repeat(n) + '#'.repeat(3 * n) + ' '.repeat(n));
    }
    console.log('#'.repeat(n) + ' '.repeat(3 * n) + '#'.repeat(n));
    for (let i = 1; i <= (2 * n - 1); i++) {
        if (i % 2 === 0) {
            console.log('#'.repeat(n) + ' ' + ' #'.repeat((3 * n - 3) / 2) + '  ' + '#'.repeat(n));
        } else {
            console.log('#'.repeat(n) + ' #'.repeat((3 * n - 3) / 2 + 1) + ' ' + '#'.repeat(n));
        }
    }
    console.log('#'.repeat(n) + ' '.repeat(3 * n) + '#'.repeat(n));
    for (let i = 1; i <= (n + 2); i++) {
        if (i % 2 === 0) {
            console.log('#'.repeat(n) + ' #'.repeat((3 * n - 3) / 2 + 1) + ' ' + '#'.repeat(n));
        } else {
            console.log('#'.repeat(5 * n));
        }
    }
    for (let i = 1; i <= half; i++) {
        console.log(' '.repeat(n) + '#'.repeat(3 * n) + ' '.repeat(n));
    }
}

draw('3');
draw('5');
