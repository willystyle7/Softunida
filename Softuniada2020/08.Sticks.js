function solve(input) {
    // permutations helper
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
    // variations with repetitions helper
    var variationsWithRepetion = (function () {
        var res;
        function variations(arr, k, index, current) {
            if (k === index) {
                return res.push(current.slice());
            }
            for (var i = 0; i < arr.length; i += 1) {
                current[index] = arr[i];
                variations(arr, k, index + 1, current);
            }
        }

        return function (arr, k) {
            res = [];
            variations(arr, k, 0, []);
            var temp = res;
            res = undefined;
            return temp;
        };
    }());

    let n = Number(input.shift());
    let sticks = [];
    for (let i = 0; i < n; i++) {
        let stick = input.shift();
        let [width, height] = stick.split(' ');
        sticks.push(`${width}-${height}`);
    }

    let permutations = permutation(sticks);
    let results = [];
    let rotationVarians = variationsWithRepetion([0, 1], n);
    permutations.forEach(row => {
        rotationVarians.forEach(variant => {
            let result = row.map((el, idx) => {
                let [width, height] = el.split('-');
                if (variant[idx] === 0) {
                    // do not rotate
                    return `|${width}-${height}|`
                } else if (variant[idx] === 1) {
                    // do rotate
                    return `|${height}-${width}|`
                }
            });
            results.push(result);
        });
    });

    results = results.map(row => row.join(' # '));
    results = [... new Set(results)];
    results.sort((a, b) => a.localeCompare(b));

    console.log(results.length);
    console.log(results.join('\n'));
}

solve ([3, '2 3', '2 2', '3 2']);