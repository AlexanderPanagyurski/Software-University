function solve(input) {
    let result = new Map();
    AddSystemComponents();
    PrintSorted();

    function PrintSorted() {
        console.log([...result]
                .sort((a, b) => b[1].size - a[1].size || a[0].localeCompare(b[0]))
                .map(s => `${s[0]}\n${[...s[1]]
                .sort((a, b) => b[1].length - a[1].length)
                .map(i => `|||${i[0]}\n${[...i[1]]
                    .map(c => `||||||${c}`)
                    .join("\n")}`)
                .join("\n")}`)
            .join("\n"));
    }
    function AddSystemComponents() {
        input.forEach(element => {
            let [systemName, componentName, subcomponentName] = element.split(' | ');
            if (!result.get(systemName)) {
                result.set(systemName,new Map());
            }
            if (!result.get(systemName).get(componentName)) {
                result.get(systemName).set(componentName, []);
            }
            
            let subcomponents = result.get(systemName).get(componentName).push(subcomponentName);
        });
    }
}

solve(['SULS | Main Site | Home Page',
'SULS | Main Site | Login Page',
'SULS | Main Site | Register Page',
'SULS | Judge Site | Login Page',
'SULS | Judge Site | Submittion Page',
'Lambda | CoreA | A23',
'SULS | Digital Site | Login Page',
'Lambda | CoreB | B24',
'Lambda | CoreA | A24',
'Lambda | CoreA | A25',
'Lambda | CoreC | C4',
'Indice | Session | Default Storage',
'Indice | Session | Default Security']
);