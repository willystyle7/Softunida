function solve(args) {
    let arr1 = args.shift().split(' ').filter(x => x.length > 0).map(Number);
    let arr2 = args.shift().split(' ').filter(x => x.length > 0).map(Number);
    let input = args.shift();
    while (input!=='nexus') {
        let pair1, pair2, arr1Index1, arr2Index1, arr1Index2, arr2Index2;
        [pair1, pair2] = input.split('|');
        [arr1Index1, arr2Index1] = pair1.split(':');
        [arr1Index2, arr2Index2] = pair2.split(':');
        if ((arr1Index1 <= arr1Index2 && arr2Index1 >= arr2Index2)
        || (arr1Index1 >= arr1Index2 && arr2Index1 <= arr2Index2)) {
            let sum = arr1[arr1Index1] + arr1[arr1Index2] + arr2[arr2Index1] + arr2[arr2Index2];
            if (arr1Index1 === arr1Index2) sum -= arr1[arr1Index1];
            if (arr2Index1 === arr2Index2) sum -= arr2[arr1Index1];
            let startIndex1 = Math.min(arr1Index1, arr1Index2);
            let startIndex2 = Math.min(arr2Index1, arr2Index2);
            let count1 = Math.abs(arr1Index1 - arr1Index2) + 1;
            let count2 = Math.abs(arr2Index1 - arr2Index2) + 1;
            arr1.splice(startIndex1, count1);
            arr2.splice(startIndex2, count2);
            arr1 = arr1.map(el => el + sum);
            arr2 = arr2.map(el => el + sum);
        }
        input = args.shift();
    }
    console.log(arr1.join(', '));
    console.log(arr2.join(', '));
}

solve(['1 2 3 4 5 6 7 8 9 10', '1 2 3 4 5 6 7 8 9 10', '2:5|5:2', 'nexus']);
solve(['5 10 15 20 25 30', '40 35 30 25 20 15 10 5', '1:6|2:1', 'nexus']);
