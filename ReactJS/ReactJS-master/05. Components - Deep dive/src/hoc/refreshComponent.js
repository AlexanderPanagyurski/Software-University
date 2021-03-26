import { Component } from 'react';

function refreshComponent(WrappedComponent, time = 2500) {
    return class extends Component {
        constructor(props) {
            super(props);
            this.state = {
                refreshCount: 0
            }
        }

        componentDidMount() {
            setTimeout(() => {
                this.setState({refreshCount: this.state.refreshCount + 1})
            }, time);
        }

        render() {
            return <WrappedComponent {...this.props} refreshCount={this.state.refreshCount} />;
        }
    }
}

export default refreshComponent;