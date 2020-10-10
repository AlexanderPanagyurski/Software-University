let mat = [
    [12, 1, 14, 3, 16],
    [14, 2, 1, 3, 35],
    [14, 1, 14, 3, 11],
    [14, 25, 3, 2, 1],
    [1, 18, 3, 21, 14]
];

let n = 5;
findAndPrintCommonElements(mat, n);

function findAndPrintCommonElements(mat, n) {
    sortRows(mat, n);

    let curr_index = [n];

    let f = 0;

    for (; curr_index[0] < n; curr_index[0]++) {
 
        let value = mat[0][curr_index[0]];

        let present = true;

        for (let i = 1; i < n; i++) { 
            while (curr_index[i] < n &&
                mat[i][curr_index[i]] <= value) {
                curr_index[i]++;
            }


            if (mat[i][curr_index[i] - 1] != value) {
                present = false;
            }

            if (curr_index[i] == n) {
                f = 1;
                break;
            }
        }

        if (present) {
            console.log(value + " ");
        }
 
        if (f == 1) {
            break;
        }
    }
}

function sortRows( mat, n) 
{ 
    for (let i = 0; i < n; i++) { 
        Array.Sort(mat[i]); 
    } 
}