rotateMatrix(3,3,[
    [1, 2, 3],
    [4, 5, 6],
    [7, 8, 9]
])

function rotateMatrix(m, n, matrix) {
    let row = 0;
    let col = 0;
    let prev;
    let curr;

    /* 
    row - Staring row index 
    m - ending row index 
    col - starting column index 
    n - ending column index 
    i - iterator 
    */
    while (row < m && col < n) {

        if (row + 1 == m || col + 1 == n)
            break;

        // Store the first element of next 
        // row, this element will replace  
        // first element of current row 
        prev = matrix[row + 1][col];

        // Move elements of first row  
        // from the remaining rows  
        for (let i = col; i < n; i++) {
            curr = matrix[row][i];
            matrix[row][i] = prev;
            prev = curr;
        }
        row++;

        // Move elements of last column 
        // from the remaining columns  
        for (let i = row; i < m; i++) {
            curr = matrix[i, n - 1];
            matrix[i][n - 1] = prev;
            prev = curr;
        }
        n--;

        // Move elements of last row  
        // from the remaining rows  
        if (row < m) {
            for (let i = n - 1; i >= col; i--) {
                curr = matrix[m - 1][i];
                matrix[m - 1][i] = prev;
                prev = curr;
            }
        }
        m--;

        // Move elements of first column 
        // from the remaining rows  
        if (col < n) {
            for (let i = m - 1; i >= row; i--) {
                curr = matrix[i][col];
                matrix[i][col] = prev;
                prev = curr;
            }
        }
        col++;
    }
    let r=3;
    let c=3;

    // Print rotated matrix 
    for (let i = 0; i < r; i++) {
        for (let j = 0; j < c; j++){
        console.log(matrix[i][j] + " ");
        }
        console.log("\n");
    }
}