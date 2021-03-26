import './App.css';
import Heading from './components/Heading';
import BookList from './components/BookList';
import Counter from './components/Counter';

const booksData = [
    {title: 'Harry Potter', description: 'Wizards and stuff'},
    {title: 'Programming with JS', description: 'Guide to programming'},
    {title: 'The Bible', description: 'Most important book', author: 'God'},
    {title: 'Chronicles of Narnia', description: 'Adventure'},
    {title: null, description: 'Missing book'},
];

function App() {
    return (
        <div className="site-wrapper">
            <Heading>
                <h1>Our Custom Library Children</h1>
                <h2>Favourite Books</h2>
            </Heading>

            <Counter />

            <Counter />

            <BookList books={booksData} />
        </div>
    );
}

export default App;
