import { Component } from 'react';
import bookService from '../services/bookService';
import Book from './Book';

class BookList extends Component {
    constructor(props) {
        super(props)

        this.state = {
            books: []
        }
    }

    bookClicked(title) {
        console.log(`The book ${title} has beed added to baset!`);
    }

    componentDidMount() {
        bookService.getAll()
            .then(books => {
                this.setState(() => ({ books }))
            });
    }

    render() {

        if (this.state.books.length == 0) {
            return <span>Loading books...</span>
        }

        return (
            <div className="book-list">
                <h2> Our Book Collection</h2>

                {this.state.books.map((x, index) => 
                    <Book
                        key={x._id}
                        title={x.title}
                        description={x.description}
                        // clickHandler={this.bookClicked.bind(this, x.title)} 
                        clickHandler={() => this.bookClicked(x.title)}
                        author={x.author}
                    />
                )}

            </div>
        )
    }
}

export default BookList;