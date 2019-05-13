function solve(args) {
    let sum = args.reduce((agr, el) => agr + +el, 0);
    let permutations = permutation(args).map( el => el.reduce((agr, e) => agr + e, ''));
    let uniqueNums = [...new Set(permutations)];
    for (let i = 0; i < uniqueNums.length; i++) {
        const num = +uniqueNums[i];
        if (num % sum === 0) {
            console.log('Digitivision successful!');
            return;
        }
    }
    console.log('No digitivision possible.');

    function permutation(array) {
        function p(array, temp) {
            var i, x;
            if (!array.length) {
                result.push(temp);
            }
            for (i = 0; i < array.length; i++) {
                x = array.splice(i, 1)[0];
                p(array, temp.concat(x));
                array.splice(i, 0, x);
            }
        }
        var result = [];
        p(array, []);
        return result;
    }
}

// function from stackoverflow - all permutations in array
function permutation(array) {
    function p(array, temp) {
        var i, x;
        if (!array.length) {
            result.push(temp);
        }
        for (i = 0; i < array.length; i++) {
            x = array.splice(i, 1)[0];
            p(array, temp.concat(x));
            array.splice(i, 0, x);
        }
    }
    var result = [];
    p(array, []);
    return result;
}

solve(['6', '2', '1']);
solve(['3', '3', '4']);
