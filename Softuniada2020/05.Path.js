function solve([path]) {
    let pathsToCheck = [path];
    let paths = [];
    while (pathsToCheck.length > 0) {
        let currentPath = pathsToCheck.shift();
        let indexStar = currentPath.indexOf('*');
        if (indexStar >= 0) {
            pathsToCheck.push(currentPath.replace('*', 'L'));
            pathsToCheck.push(currentPath.replace('*', 'R'));
            pathsToCheck.push(currentPath.replace('*', 'S'));
        } else {
            paths.push(currentPath);
        }
    }
    console.log(paths.length);
    console.log(paths.join('\n'));
}

solve(['LSLLRSRL']);
solve(['R*S*L']);
// solve(['**RLR*']);