import './App.css';
import Heading from './components/Heading';
import BookList from './components/BookList';
import Counter from './components/Counter';
import Footer from './components/Footer';

function App() {
    
    return (
        <div className="site-wrapper">
            <Heading>
                <h1>Our Custom Library Children</h1>
                <h2>Favourite Books</h2>
            </Heading>

            <Counter />

            <BookList />

            <Footer />
        </div>
    );
}

export default App;
