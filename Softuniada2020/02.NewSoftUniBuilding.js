function newSoftUniBuilding([n]) {
    n = Number(n);
    let pattern = '#...';
    let line = pattern.repeat(Math.ceil((n + 1) / 4) + 1);
    for (let row = 0; row < (n + Math.floor(n / 2)); row++) {
        console.log(line.substr(row % 4, n));
    }
}

// newSoftUniBuilding(5);
newSoftUniBuilding('7');
// newSoftUniBuilding(9);