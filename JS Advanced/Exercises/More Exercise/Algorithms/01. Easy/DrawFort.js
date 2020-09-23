DrawFort(8)

function DrawFort(n){

    let colSize=Math.floor(n/2);
    let width = 2 * n;
 
    // Top part
    let accentCount = n / 2;
    let underlineCount = width - 2 * (accentCount + 2);
    console.log(`/${'^'.repeat(accentCount)}\\${'_'.repeat(underlineCount)}/${'^'.repeat(accentCount)}\\`);

    // Middle part
    for ( let i = 0; i < n - 2; i++ )
    {
        if ( i === n - 3 )
        {
            console.log(`|${' '.repeat(n / 2 + 1)}${'_'.repeat(underlineCount)}${' '.repeat(n / 2 + 1)}|`);
        }
        else
        {
            console.log(`|${' '.repeat(width - 2)}|`);
        }
    }

    // Bottom part
    console.log(`\\${'_'.repeat(accentCount)}/${' '.repeat(underlineCount)}\\${'_'.repeat(accentCount)}/`);
}