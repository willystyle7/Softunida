function solve([p, r]) {
    let triangles = [];
    for (let a = 2 * r; a > 0; a--) {
        for (let b = 2 * r; b > 0; b--) {
            let c = p - a - b;
            if ((c <= 2 * r) && checkTriangle(a, b, c, r, p / 2)) {
                triangles.push(`${a}.${b}.${c}`);
            }
        }
    }
    console.log(triangles.join('\n'));

    function checkTriangle(a, b, c, r, p) {
        let s1 = a * a * b * b * c * c ;
        let s2 = p * (p - a) * (p - b) * (p - c) * 16 * r * r;
        return s1 === s2;
    }
}

solve([12, 2.5]);
solve([30, 6.5]);