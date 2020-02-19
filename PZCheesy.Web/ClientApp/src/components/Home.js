import React, { Component } from 'react';

export class Home extends Component {
    constructor(props) {
        super(props);

        this.state = {
            cheeses: [],
        }
    }

    componentDidMount() {
        fetch('cheese/all')
            .then(results => { return results.json() })
            .then(data => {
                console.log(data);
                let allCheeses = data.map((cheese) => {
                    return (
                        <div key={cheese.id}>
                            <h1>{cheese.name}</h1>
                        </div>
                    )
                });

                this.setState({ cheeses: allCheeses });
            })
            .catch(err => console.log(err));
    }

    render () {
        return (
            <div>
                <h1>Hello, world!</h1>
                {this.state.cheeses}
            </div>
        );
    }
}
