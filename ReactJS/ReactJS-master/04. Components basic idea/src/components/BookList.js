import { Component } from 'react';

import Book from './Book';

class BookList extends Component {
    constructor(props) {
        super(props)
    }

    bookClicked(title) {
        console.log(`The book ${title} has beed added to baset!`);
    }
    
    render() {
        return (
            <div className="book-list">
                <h2> Our Book Collection</h2>

                {this.props.books.map(x => {
                    return <Book 
                        title={x.title} 
                        description={x.description} 
                        // clickHandler={this.bookClicked.bind(this, x.title)} 
                        clickHandler={() => this.bookClicked(x.title)} 
                        author={x.author}
                    />;
                })}
            </div>
        )
    }
}

export default BookList;