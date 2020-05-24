function deckShuffle([n, x]) {
    let arr = x.split(' ').map(Number);
    let deck = [];
    for (let i = 1; i <= n; i++) {
        deck.push(i);
    }
    for (let index of arr) {
        let leftDeck = deck.slice(0, index);
        let rightDeck = deck.slice(index);
        deck = [];
        while (leftDeck.length > 0 || rightDeck.length > 0) {
            let card = leftDeck.shift();
            if (card) {
                deck.push(card);
            }
            card = rightDeck.shift();
            if (card) {
                deck.push(card);
            }
        }
    }
    console.log(deck.join(' '));
}

deckShuffle([5, '3 3 2'])