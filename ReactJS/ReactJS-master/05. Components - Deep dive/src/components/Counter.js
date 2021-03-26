import { Component } from 'react';

class Counter extends Component {
    constructor(props) {
        super(props);

        this.state = {
            count: 11,
            collectionName: 'My BOoks' 
        };

        this.resetCounter = this.resetCounter.bind(this);
    }

    decrementCounter(e) {
        // this.setState({count: this.state.count - 1})
        this.setState(prevState => ({count: prevState.count - 1}));
    }

    incrementCounter(e) {
        this.setState(prevState => ({count: prevState.count + 1}));   
    }

    resetCounter(e) {
        this.setState({count: 0});
    }

    render() {
        return (
            <div className="counter">
                <h3>{this.state.collectionName} Counter</h3>
                <button onClick={(e) => this.decrementCounter(e)}>-</button>
                <span>{this.state.count}</span>
                <button onClick={this.incrementCounter.bind(this)}>+</button>
                <button onClick={this.resetCounter}>Reset</button>
            </div>
        );
    }
}

export default Counter;