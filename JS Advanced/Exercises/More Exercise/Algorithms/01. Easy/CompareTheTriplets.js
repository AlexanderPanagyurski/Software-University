console.log(CompareTriplets([1,2,3],[3,2,1]));

/*
Alice and Bob each created one problem for HackerRank. A reviewer rates the two challenges,
 awarding points on a scale from 1 to 100 for three categories: problem clarity, originality, and difficulty.

The rating for Alice's challenge is the triplet a = (a[0], a[1], a[2]),
 and the rating for Bob's challenge is the triplet b = (b[0], b[1], b[2]).
*/

function CompareTriplets(firstTriplet,secondTriplet){

    let points = {
        'first':0,
        'second':0
    }

    for (let index = 0; index < 3; index++) {
        let firstTripletEl = firstTriplet[index];
        let secondTripletEl=secondTriplet[index];

        if(firstTripletEl>secondTripletEl){
            points['first']++;
        } else if(secondTripletEl>firstTripletEl){
            points['second']++;
        }
    }

    return points;
}