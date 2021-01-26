function solve() {
    let text = document.getElementById('input').value;
    let splitSentences = text.split('.');
    if (splitSentences.length > 0) {
        if (splitSentences.length <= 3) {
            let text = '';
            for (let i = 0; i < splitSentences.length; i++) {
                if (splitSentences[i].length > 1 && splitSentences[i] !== '') {
                    text += splitSentences[i];
                }
            }
            if (text !== '') {
                document.getElementById('output').innerHTML += `<p>${text}.</p>`;
            }
            text = '';
        } else {
            let text = '';
            if (splitSentences.length % 3 == 0) {
                for (let i = 0; i < splitSentences.length - 1; i += 3) {
                    for (let j = i; j <= i + 3; j++) {
                        text += splitSentences[j];
                    }
                    document.getElementById('output').innerHTML += `<p>${text}.</p>`;
                    text = '';
                }
            } else {
                let text = '';
                for (let i = 0; i < splitSentences.length - 1; i += 3) {
                    if (splitSentences[i].length > 1 && splitSentences[i]) {
                        for (let j = i; j < i + 3; j++) {
                            if (splitSentences[j] !== undefined) {
                                text += splitSentences[j] + '.';
                            }
                        }
                    }
                    document.getElementById('output').innerHTML += `<p>${text}</p>`;
                    text = '';
                }
            }
        }
    }
}