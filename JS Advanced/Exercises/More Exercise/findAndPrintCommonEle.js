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
    // sort rows individually  
    sortRows(mat, n);

    // current column index of each row is stored  
    // from where the element is being searched in  
    // that row  
    let[] curr_index = new int[n];

    let f = 0;

    for (; curr_index[0] < n; curr_index[0]++) {
        // value present at the current column index  
        // of 1st row  
        let value = mat[0][curr_index[0]];

        let present = true;

        // 'value' is being searched in all the  
        // subsequent rows  
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