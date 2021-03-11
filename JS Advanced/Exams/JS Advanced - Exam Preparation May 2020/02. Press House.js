function solveClasses() {

    class Article {
        _content;
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        get content() {
            return this._content;
        }

        set content(value) {
            if (this.constructor === ShortReports && value.length >= 150) {
                throw new Error('Short reports content should be less then 150 symbols.');
            }

            this._content = value;
        }

        toString() {
            return `Title: ${this.title}\nContent: ${this.content}`;
        }
    }

    class ShortReports extends Article {
        _originalResearch;
        constructor(title, content, originalResearch) {
            super(title, content);
            this.comments = [];
            this.originalResearch = originalResearch;
            let s = this.content;
        }
        get originalResearch() {
            return this._originalResearch;
        }

        set originalResearch(value) {
            if (value.title === undefined || value.author === undefined) {
                throw new Error('The original research should have author and title.');
            }

            this._originalResearch = value;
        }

        addComment(comment) {
            this.comments.push(comment);
            return `The comment is added.`;
        }

        toString() {
            let result;
            result = super.toString();
            result += `\nOriginal Research: ${this.originalResearch['title']} by ${this.originalResearch['author']}`;
            if (this.comments.length > 0) {
                result += `\nComments:`;
                this.comments.forEach((element) => {
                    result += `\n${element}`;
                });
            }

            return result;
        }
    }

    class BookReview extends Article {
        constructor(title, content, book) {
            super(title, content);
            this.clients = []; // {clientName, orderDescription}.
            this.book = book;
        }

        addClient(clientName, orderDescription) {
            this.clients.forEach(client => {
                if (client.clientName === clientName || client.orderDescription === orderDescription) {
                    // not sure to use OR or AND here
                    throw new Error(wrongClientId);
                }
            });

            const newClient = {
                clientName,
                orderDescription
            };

            this.clients.push(newClient); //array of objects with the following structure {clientName, orderDescription}.

            return `${clientName} has ordered a review for ${this.book.name}`;
        }

        toString() {
            let result = super.toString();
            result += `\nBook: ${this.book.name}`;

            if (this.clients.length > 0) {
                result += `\nOrders:`;
                this.clients.forEach(client => {
                    result += `\n${client.clientName} - ${client.orderDescription}`;
                });
            }

            return result;
        }
    }

    return {
        Article,
        ShortReports,
        BookReview
    }

}

// TESTING

let classes = solveClasses();
let lorem = new classes.Article("Lorem", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce non tortor finibus, facilisis mauris vel…");
console.log(lorem.toString());
//------------------------------
let short = new classes.ShortReports("SpaceX and Javascript", "Yes, its damn true.SpaceX in its recent launch Dragon 2 Flight has used a technology based on Chromium and Javascript. What are your views on this ?", { title: "Dragon 2", author: "wikipedia.org" });
console.log(short.addComment("Thank god they didn't use java."));
short.addComment(`"In the end JavaScript"s features are executed in C++ — the underlying language."`);
console.log(short.toString());
//------------------------------
let book = new classes.BookReview("The Great Gatsby is so much more than a love story", "The Great Gatsby is in many ways similar to Romeo and Juliet, yet I believe that it is so much more than just a love story. It is also a reflection on the hollowness of a life of leisure. ...", { name: "The Great Gatsby", author: "F Scott Fitzgerald" });
console.log(book.addClient("The Guardian", "100 symbols"));
console.log(book.addClient("Goodreads", "30 symbols"));
console.log(book.toString());