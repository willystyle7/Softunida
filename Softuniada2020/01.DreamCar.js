// n - starting salary
// m - monthly spends
// x - monthtly increase of salary
// y - prise of dreamed car
// t - number of months

function dreamCar([n, m, x, y, t]) {
    let incomes = t * n + (t * (t - 1) * x) / 2;
    let spent = t * m;
    console.log(incomes - spent >= y ? 'Have a nice ride!' : 'Work harder!');
}

dreamCar([100, 50, 10, 500, 7]);
dreamCar([560.8, 600.4, 15.3, 4356.19, 24]);
dreamCar([1500, 500, 13, 25003,22]);
