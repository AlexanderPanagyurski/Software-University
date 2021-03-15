function solve(arguments) {

    class Hero {
        constructor(name, level, items) {
            this.name = name,
                this.level = level,
                this.items = items
        }
    }

    const result = [];

    for (const item of arguments) {
        let [name, level, items] = item.split(' / ');
        level = Number(level);

        items = items ? items.split(', ') : []; // in case of no items an empty array will be assigned to the hero.

        result.push(new Hero(name, level, items));
    }

    console.log(JSON.stringify(result));
}

solve(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara',
    'David / 100 / '
]);